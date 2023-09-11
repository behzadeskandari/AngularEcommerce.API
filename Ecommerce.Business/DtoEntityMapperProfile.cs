using AutoMapper;
using Ecommerce.Common.Dtos.CategoriesDto;
using Ecommerce.Common.Dtos.OrderItemDto;
using Ecommerce.Common.Dtos.OrdersDto;
using Ecommerce.Common.Dtos.ProductsDto;
using Ecommerce.Common.Dtos.UserDto;
using Ecommerce.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business
{
    public class DtoEntityMapperProfile : Profile
    {
        public DtoEntityMapperProfile()
        {
            //CreateMap<AddressCreate, Address>().ForMember(dest => dest.Id, opt => opt.Ignore());
            //CreateMap<AddressDelete, Address>();
            //CreateMap<AddressUpdate, Address>();
            //CreateMap<Address, AddressGet>();
            CreateMap<ProductsGet, Products>();
            CreateMap<ProductsDelete, Products>();
            CreateMap<ProductsUpdate, Products>();
            CreateMap<Products, ProductsGet>();


            CreateMap<CategoriesGet, Categories>();
            CreateMap<CategoriesDelete, Categories>();
            CreateMap<CategoriesUpdate, Categories>();
            CreateMap<Categories, CategoriesGet>();


            CreateMap<OrdersGet, Orders>();
            CreateMap<OrdersDelete, Orders>();
            CreateMap<OrdersUpdate, Orders>();
            CreateMap<Orders, OrdersGet>();

            CreateMap<OrderItemGet, OrderItem>();
            CreateMap<OrderItemDelete, OrderItem>();
            CreateMap<OrderItemUpdate, OrderItem>();
            CreateMap<OrderItem, OrderItemGet>();


            CreateMap<ApplicationUser, ApplicationUserDto>();


        }
    }
}
