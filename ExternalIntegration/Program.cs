using ExternalIntegration.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ExternalIntegration
{
    public class DataObject {
        public string Name { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            TelstarCommunication.RequestRoute();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
