using eCodes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Braintree;
using eCodes.Models.Exceptions;
using eCodes.Services.Database;
using AutoMapper;
using eCodes.Models.Requests;
using eCodes.Models.SearchObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using eCodes.Services.Properties;

namespace eCodes.Services
{
    public class PaymentService : IPaymentService
    {
        public _210331Context _context;
        public IMapper _mapper;
        public PaymentService(_210331Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Payments BeginTransaction(Payments payment)
        {
            var products = _context.Products.Include(i=> i.Seller).Where(w => w.ProductId == payment.ProductId);
            var product = products.FirstOrDefault();
            //Implement payment here (recive nonce and device data and begin transaction)
            var gateway = new BraintreeGateway()
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = Resources.PaymentMerchantId, 
                PublicKey = Resources.PaymentPublicKey,  
                PrivateKey = Resources.PaymentPrivateKey,  
            };

            decimal percentage = payment.UsedLoyaltyPoints / 100;
            decimal priceToPay = payment.Amount - (payment.Amount * percentage);
            priceToPay = Convert.ToDecimal(string.Format("{0:0.00}", priceToPay));

            TransactionRequest request = new TransactionRequest()
            {
                Amount = priceToPay,
                PaymentMethodNonce = payment.PaymentMethodNonce,
                DeviceData = payment.DeviceData,
                Options = new TransactionOptionsRequest()
                {
                    SubmitForSettlement = true,
                    PayPal = new TransactionOptionsPayPalRequest()
                    {
                        Description = "This is your confirmation of payment to the eCodes app for product: " + product.Name + " from seller: " + product.Seller.Name,
                        PayeeEmail = product.Seller.PayPalEmail,
                    }
                },
                TaxAmount = Convert.ToDecimal(0.5),

            };

            var result = gateway.Transaction.Sale(request);

            if (result.IsSuccess())
            {
                payment.Successful = true;
                _context.SaveChanges();
            }
            else if (result.Transaction != null)
            {

               throw new PaymentException(" Transaction Status: " + result.Transaction.Status + "\n" +
                                      " Code: " + result.Transaction.ProcessorResponseCode + "\n" +
                                      " Text: " + result.Transaction.ProcessorResponseText);
               
            }
            else
            {
                throw new Exception();
            }

            return payment;
        }

        public Orders SaveTransaction(int orderId,decimal loyaltyPoints)
        {
            // Save transaction in database
            OrdersService orderService = new OrdersService(_context, _mapper);
            OutputService outputService = new OutputService(_context, _mapper);
            OutputItemsService outputItemsService = new OutputItemsService(_context, _mapper);
            var order = orderService.GetbyId(orderId);
            if(order == null)
            {
                return null;
            }
            Outputs insertedOutput = null;

            OutputUpsertRequest output = new OutputUpsertRequest()
            {
                Date = DateTime.Now,
                PaymentMethod = "PayPal",
                BuyerId = order.BuyerId,
                Concluded = true,
                AmountWithTax = Convert.ToDecimal(order.Price),
                AmountWithoutTax = Convert.ToDecimal(order.Price) - Convert.ToDecimal(0.5),
                OrderId = order.OrderId,
                ReceiptNumber = order.OrderNumber + "/" + order.Date.Year.ToString(),
            };
            insertedOutput = outputService.Insert(output);
            if(insertedOutput != null)
            {
                foreach (var item in order.OrderItems)
                {
                    OutputItemUpsertRequest outputitem = new OutputItemUpsertRequest()
                    {
                        OutputId = insertedOutput.OutputId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Price = Convert.ToDecimal(item.Price),
                        Discount = loyaltyPoints,
                        SellerId = item.Product.SellerId,
                    };
                    outputItemsService.Insert(outputitem);

                }
            }
            LoyaltyPointService pointsService = new LoyaltyPointService(_context, _mapper);
            LoyaltyPointsSearchObject search = new LoyaltyPointsSearchObject() { BuyerId = order.BuyerId };
            var points = pointsService.Get(search);
            if (points.FirstOrDefault() != null)
            {
                LoyaltyPointsUpsertRequest update = new LoyaltyPointsUpsertRequest();
                update.BuyerId = order.BuyerId;
                update.Balance = points.FirstOrDefault().Balance;
                if (loyaltyPoints > 0)
                {
                    update.Balance -= loyaltyPoints;
                    pointsService.Update(points.FirstOrDefault().LoyaltyPointsId, update);
                }
                else
                {
                    update.Balance += Convert.ToDecimal(order.Price) / 12;
                    pointsService.Update(order.BuyerId, update);
                }
            }


            return order;
        }

    }
}
