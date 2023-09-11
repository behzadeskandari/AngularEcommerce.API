
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
        }
    }
}