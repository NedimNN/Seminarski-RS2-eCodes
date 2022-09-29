using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCodes.Services
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            var minDate = new DateTime();
            CreateMap<Database.Product, Models.Products>();
            CreateMap<Database.User, Models.Users>();
            CreateMap<Database.Role, Models.Roles>();
            CreateMap<Database.UserRole, Models.UserRoles>();
            CreateMap<Database.ProductType, Models.ProductTypes>();
            CreateMap<Database.Person, Models.Persons>();
            CreateMap<Database.City, Models.Cities>();
            CreateMap<Models.Cities, Database.City>();
            CreateMap<Database.Country, Models.Countries>();
            CreateMap<Database.Buyer, Models.Buyers>();
            CreateMap<Database.Currency, Models.Currencies>();
            CreateMap<Database.Wallet, Models.Wallets>();
            CreateMap<Database.Employee, Models.Employees>();
            CreateMap<Database.Rating, Models.Ratings>();
            CreateMap<Database.Seller, Models.Sellers>();
            CreateMap<Database.Order, Models.Orders>();
            CreateMap<Database.OrderItem, Models.OrderItems>();


            // Add more conditions on update requests
            CreateMap<Models.Requests.ProductsInsertRequest,Database.Product>();
            CreateMap<Models.Requests.ProductsUpdateRequest, Database.Product>()
                .ForMember(dest => dest.ProductTypeId , opt=> opt.MapFrom((src,dest) => src.ProductTypeId != 0 ? src.ProductTypeId : dest.ProductTypeId))
                .ForMember(dest => dest.Value, opt => opt.MapFrom((src, dest) => src.Value != 0 ? src.Value : dest.Value))
                .ForMember(dest => dest.Price, opt => opt.MapFrom((src, dest) => src.Price != 0 ? src.Price : dest.Price))
                .ForAllMembers(opts =>
                {
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });
            CreateMap<Models.Requests.ProductTypesUpsertRequest, Database.ProductType>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Models.Requests.UserInsertRequest, Database.User>();
            CreateMap<Models.Requests.UserUpdateRequest, Database.User>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Models.Requests.BuyerInsertRequest, Database.Buyer>();
            CreateMap<Models.Requests.BuyerUpdateRequest, Database.Buyer>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            }); 
            CreateMap<Models.Requests.PersonInsertRequest, Database.Person>();
            CreateMap<Models.Requests.PersonUpdateRequest, Database.Person>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom((src, dest) => src.DateOfBirth != minDate ? src.DateOfBirth : dest.DateOfBirth))
                .ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            }); 
            CreateMap<Models.Requests.EmployeeInsertRequest, Database.Employee>();
            CreateMap<Models.Requests.EmployeeUpdateRequest, Database.Employee>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            }); 
            CreateMap<Models.Requests.SellerInsertRequest, Database.Seller>();
            CreateMap<Models.Requests.SellerUpdateRequest, Database.Seller>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });


            CreateMap<Models.Requests.BuyerUpdateRequest, Models.Requests.PersonUpdateRequest>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Models.Requests.BuyerInsertRequest, Models.Requests.PersonInsertRequest>();

            CreateMap<Models.Requests.UserUpdateRequest, Models.Requests.PersonUpdateRequest>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Models.Requests.UserInsertRequest, Models.Requests.PersonInsertRequest>();

            CreateMap<Models.Requests.EmployeeUpdateRequest, Models.Requests.PersonUpdateRequest>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            }); 
            CreateMap<Models.Requests.EmployeeInsertRequest, Models.Requests.PersonInsertRequest>();

            CreateMap<Models.Requests.SellerUpdateRequest, Models.Requests.PersonUpdateRequest>()
                .ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            }); 
            CreateMap<Models.Requests.SellerInsertRequest, Models.Requests.PersonInsertRequest>();

            CreateMap<Models.Requests.OrdersInsertRequest, Database.Order>();
            CreateMap<Models.Requests.OrdersUpdateRequest, Database.Order>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Models.Requests.OrderItemsInsertRequest, Database.OrderItem>();
            CreateMap<Models.Requests.OrderItemsUpdateRequest, Database.OrderItem>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });


            CreateMap<Models.Requests.CityUpsertRequest, Database.City>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            }); 
            CreateMap<Models.Requests.CountryUpsertRequest, Database.Country>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            }); 
            CreateMap<Models.Requests.CurrencyUpsertRequest, Database.Currency>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            }); 
            CreateMap<Models.Requests.WalletUpsertRequest, Database.Wallet>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
            CreateMap<Models.Requests.RatingUpsertRequest, Database.Rating>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });


        }
    }
}
