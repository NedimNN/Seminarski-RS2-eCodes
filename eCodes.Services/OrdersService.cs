﻿using AutoMapper;
using eCodes.Models;
using eCodes.Models.Requests;
using eCodes.Models.SearchObjects;
using eCodes.Services.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCodes.Services.HelperMethods;
using eCodes.Models.Exceptions;

namespace eCodes.Services
{
    public class OrdersService : BaseCRUDService<Models.Orders, Database.Order, OrderSearchObject, OrdersInsertRequest, OrdersUpdateRequest>, IOrdersService
    {
        public OrdersService(_210331Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<Order> AddInclude(IQueryable<Order> query, OrderSearchObject search = null)
        {
            if (search?.IncludeBuyer == true)
            {
                query = query.Include(i=> i.Buyer);

            }
            if(search?.IncludeItems == true)
            {
                query = query.Include("OrderItems.Product.ProductType");
            }

            return query;
        }
        public override void BeforeDelete(Order dbentity)
        {
            var orderService = new OrderItemsService(_context, _mapper);
            var orders  = _context.OrderItems.Where(w=> w.OrderId == dbentity.OrderId).ToList();
            var ordersToDelete = orders;
            foreach (var orderItem in ordersToDelete)
            {
                orderService.Delete(orderItem.OrderItemId);
            }

            base.BeforeDelete(dbentity);
        }
        public override Order AddIncludeforGetById(Order query)
        {
            query.OrderItems = _context.OrderItems.Include("Product.ProductType")
                                                  .Include("Product.Seller").Where(w => w.OrderId == query.OrderId).ToList();
            return query;
        }
        public override IQueryable<Order> AddFilter(IQueryable<Order> query, OrderSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);
            var date = new DateTime();

            if (!string.IsNullOrWhiteSpace(search?.BuyerName))
            {
                filter = filter.Where(w => w.Buyer.Username.Contains(search.BuyerName));
            }

            if (!string.IsNullOrWhiteSpace(search?.OrderNumber))
            {
                filter = filter.Where(w=> w.OrderNumber.Contains(search.OrderNumber));
            }
            //if (search?.Date != date)
            //{
            //    filter = filter.Where(w => w.Date.Equals(search.Date));
            //}
            if (search?.Canceled != null)
            {
                filter = filter.Where(w => w.Canceled == search.Canceled);
            }

            return filter;
        }
        public override void BeforeInsert(OrdersInsertRequest insert, Order dbentity)
        {
            dbentity.Date = DateTime.Now;
            dbentity.OrderNumber = (_context.Orders.Count() + 1).ToString();
            if(LoginHelper.GetAccType(LoginHelper.Username).Contains("Buyer")) 
                 dbentity.BuyerId = LoginHelper.ID;
            else
            {
                throw new UserErrorException("Not a valid buyer !");
            }

            base.BeforeInsert(insert, dbentity);
        }

        public override Orders Insert(OrdersInsertRequest insert)
        {
            var result = base.Insert(insert);
            OrderItemsService orderItemsService = new OrderItemsService(_context, _mapper);

            if (insert.Items.Count() > 0)
            {
                foreach (var item in insert.Items)
                {
                    OrderItemsInsertRequest dbitem = new OrderItemsInsertRequest();
                    dbitem.OrderId = result.OrderId;
                    dbitem.ProductId = item.ProductId;
                    dbitem.Quantity = item.Quantity;

                    orderItemsService.Insert(dbitem);
                }
            }

            return result;
        }
        public override Orders Update(int id, OrdersUpdateRequest update)
        {
            var order = base.GetbyId(id);
            OrderItemsService orderItemsService = new OrderItemsService(_context, _mapper);

            if (order != null)
            {
                var orderItems = _context.OrderItems.Where(w => w.OrderId == order.OrderId).ToList();

                if(orderItems != null)
                {
                    foreach (var orderItem in orderItems)
                    {
                        foreach (var item in update.Items)
                        {
                            if(orderItem.ProductId == item.ProductId)
                            {
                                OrderItemsUpdateRequest dbitem = new OrderItemsUpdateRequest();
                                dbitem.Quantity = item.Quantity;
                                dbitem.ProductId = item.ProductId;
                                orderItemsService.Update(orderItem.OrderItemId, dbitem);
                            }
                        }

                    }

                   order = base.Update(order.OrderId, update);
                
                }
            }
            return order;
        }



    }
}