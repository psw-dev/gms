using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PSW.Lib.Logs;

namespace PSW.GMS.Api
{
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                // Configure logger using library
                Log.Configure();
                Log.Information("Starting web host");
                var host = CreateHostBuilder(args).Build();
                host.Run();
                return 0;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Logger could not be instantiated please check appsettings configuration");
                return 1;
            }
            catch (Exception ex)
            {
                Log.Fatal("Host terminated unexpectedly {0}", ex);
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               .UsePSWLog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
