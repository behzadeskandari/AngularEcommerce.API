using Ecommerce.Business;
using Ecommerce.Business.Services;
using Ecommerce.Common.Interfaces;
using Ecommerce.Common.Models;
using Ecommerce.Data;
using Ecommerce.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;

namespace Ecommerce
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(opt => {
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), assembly => assembly.MigrationsAssembly("Ecommerce.Infrastructure"));
                
            });

            /////Services Configuration
            //services.AddScoped<IActorService, ActorService>();

            //services.AddScoped<IProducersService, ProducersService>();

            //services.AddScoped<ICinemaService, CinemaService>();

            //services.AddScoped<IMovieService, MovieService>();
            //services.AddScoped<IOrderService, OrderService>();

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            //services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

            ////Authentication And Authorization 
            services.AddAutoMapper(typeof(DtoEntityMapperProfile));

            DIConfiguration.RegisterServices(services);
            services.AddScoped<IGenericRepository<Address>, GenericRepository<Address>>();
            services.AddScoped<IGenericRepository<OrderItem>, GenericRepository<OrderItem>>();
            services.AddScoped<IGenericRepository<Orders>, GenericRepository<Orders>>();
            services.AddScoped<IGenericRepository<Categories>, GenericRepository<Categories>>();
            services.AddScoped<IGenericRepository<Products>, GenericRepository<Products>>();
            services.AddScoped<IGenericRepository<Team>, GenericRepository<Team>>();
            services.AddScoped<IGenericRepository<Job>, GenericRepository<Job>>();
            services.AddScoped<IGenericRepository<Employee>, GenericRepository<Employee>>();
            services.AddScoped<IGenericRepository<Address>, GenericRepository<Address>>();

            //services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            
            services.AddEndpointsApiExplorer();

            //services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecommerce", Version = "v1" });
            });
            services.AddHttpContextAccessor();

            services.AddMemoryCache();


            services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            });

            services.AddSession();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecommerce v1"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();


            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            AppDbInitializer.Seed(app);
           // AppDbInitializer.SeedUserAndRolesAsync(app).Wait();

        }
    }
}
