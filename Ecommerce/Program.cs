
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Identity.Web;
using NLog;
using NLog.Web;

namespace Ecommerce { 
    public class Program
    {
        public static void Main(string[] args)
        {

            var logger = LogManager.Setup()
                                 .LoadConfigurationFromAppSettings()
                                 .GetCurrentClassLogger();
            try
            {
                logger.Debug("init main");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception exception)
            {
                //NLog: catch setup errors
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            };
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                     //builder.Logging.AddDbLogger(options =>
                    //{
                    //    builder.Configuration.GetSection("Logging").GetSection("Database").Bind(options);
                    //});
                    
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);

                }).UseNLog();
    
    }
}