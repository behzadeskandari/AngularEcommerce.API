using Ecommerce.Business;
using Ecommerce.Business.Services;
using Ecommerce.Common.Interfaces;
using Ecommerce.Common.Models;
using Ecommerce.Data;
using Ecommerce.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using System;
using System.Data.Entity.Infrastructure;
using System.Text;

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

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {

            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
            //        ValidateAudience = false,
            //        ValidateIssuer = false,
            //    };
            //});
            var jwtConfig = Configuration.GetSection("jwtConfig");
            var secretKey = jwtConfig["secret"];

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig["validIssuer"],
                    ValidAudience = jwtConfig["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
            services.AddIdentity<ApplicationUser, IdentityRole>().AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), assembly => assembly.MigrationsAssembly("Ecommerce.Infrastructure"));

            });

            services.Configure<DbContextOptions>(Configuration);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddCors();

            //services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

            services.AddAutoMapper(typeof(DtoEntityMapperProfile));

            DIConfiguration.RegisterServices(services);

            RegisterGenericServices(services);

            //services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();



            services.AddEndpointsApiExplorer();


            //services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecommerce", Version = "v1" });
            });
            services.AddHttpContextAccessor();

            services.AddMemoryCache();

            ////Authentication And Authorization 
            //services.AddAuthentication(opt =>
            //{
            //    opt.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            //});
            services.AddResponseCaching();
            //services.AddLogging(builder =>
            //{
            //    builder.AddProvider(new DatabaseLoggerProvider());
            //});
            services.AddSession();

            services.AddControllersWithViews();

        }

        private static void RegisterGenericServices(IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Address>, GenericRepository<Address>>();
            services.AddScoped<IGenericRepository<OrderItem>, GenericRepository<OrderItem>>();
            services.AddScoped<IGenericRepository<Orders>, GenericRepository<Orders>>();
            services.AddScoped<IGenericRepository<Categories>, GenericRepository<Categories>>();
            services.AddScoped<IGenericRepository<Products>, GenericRepository<Products>>();
            services.AddScoped<IGenericRepository<Team>, GenericRepository<Team>>();
            services.AddScoped<IGenericRepository<Job>, GenericRepository<Job>>();
            services.AddScoped<IGenericRepository<Employee>, GenericRepository<Employee>>();
            services.AddScoped<IGenericRepository<Address>, GenericRepository<Address>>();
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
                //var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            
                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();

                app.UseSession();
                app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:7106"));

                 app.UseAuthentication();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });

                AppDbInitializer.Seed(app);
                AppDbInitializer.SeedUserAndRolesAsync(app).Wait();
            
        }
    }
}
