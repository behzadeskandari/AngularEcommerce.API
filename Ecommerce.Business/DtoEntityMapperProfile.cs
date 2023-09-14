using AutoMapper;
using Ecommerce.Common.Dtos.Address;
using Ecommerce.Common.Dtos.CategoriesDto;
using Ecommerce.Common.Dtos.Employee;
using Ecommerce.Common.Dtos.Jobs;
using Ecommerce.Common.Dtos.OrderItemDto;
using Ecommerce.Common.Dtos.OrdersDto;
using Ecommerce.Common.Dtos.ProductsDto;
using Ecommerce.Common.Dtos.Team;
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


            CreateMap<AddressCreate, Address>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<AddressDelete, Address>();
            CreateMap<AddressUpdate, Address>();
            CreateMap<Address, AddressGet>();

            CreateMap<JobCreate, Job>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<JobUpdate, Job>();
            CreateMap<Job, JobGet>();


            CreateMap<EmployeeCreate, Employee>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Teams, opt => opt.Ignore())
                .ForMember(dest => dest.job, opt => opt.Ignore());

            CreateMap<EmployeeUpdate, Employee>();
            CreateMap<Employee, EmployeeDetails>().ForMember(dest => dest.Id, opt => opt.Ignore())
                //.ForMember(dest => dest.Teams, opt => opt.Ignore())
                .ForMember(dest => dest.Job, opt => opt.Ignore())
                .ForMember(dest => dest.Address, opt => opt.Ignore());
            //CreateMap<Employee, EmployeeGet>();

            CreateMap<Employee, EmployeeList>();

            CreateMap<TeamCreate, Team>().ForMember(dest => dest.Id, opt => opt.Ignore()).ForMember(dest => dest.Employees, opt => opt.Ignore());

            CreateMap<TeamUpdate, Team>().ForMember(dest => dest.Employees, opt => opt.Ignore());

            CreateMap<Team, TeamGet>();

        }
    }
}
