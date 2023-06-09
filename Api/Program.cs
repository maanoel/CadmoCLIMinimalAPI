using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            try
            {
                //   logger.Debug("init main");
                var host = CreateHostBuilder(args).Build();
                host.Run();
            }
            catch (System.Exception)
            {
            // logger.Error(ex, "Program stopped.");
            // throw ex;
            }
            finally
            {
            //  NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
        {
            // webBuilder.UseStartup<Startup>().ConfigureLogging(logging =>
            // {
            //     logging.ClearProviders();
            //     logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            // }).UseNLog();
            webBuilder.UseStartup<Startup>();
        });
    }
}