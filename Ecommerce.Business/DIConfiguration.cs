
using Ecommerce.Business.Services;
using Ecommerce.Common.Interfaces;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business
{
    public class DIConfiguration
    {
        public static void RegisterServices(IServiceCollection services)
        {

            
            services.AddScoped<IOrderItemServices, OrederItemServices>();
            services.AddScoped<IOrdersService,OrdersService>();
            services.AddScoped<ICategoriesServices, CategoriesServices>();
            services.AddScoped<IProductsServices, ProductsServices>();
            services.AddScoped<IProductsServices, ProductsServices>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ITokenService, TokenServices>();
        }
    }
}