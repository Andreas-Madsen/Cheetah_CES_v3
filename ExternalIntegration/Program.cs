using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ExternalIntegration.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExternalIntegration
{
    public class DataObject {
        public string Name { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            TelstarRequest request = new TelstarRequest {
                Company = "TELSTAR_LOGISTICS",
                SecretCompanyCode = "KLdsaklwPldTdmWOdcMAwf73Adm1rRFijofdsijterI",
                CityFrom = "ADDIS_ABEBA",
                CityTo = "AMATAVE",
                Features = new string[0],
                Weight = 2,
                Height = 2,
                Width = 2,
                Length = 2
            };
            string jsonString = JsonSerializer.Serialize(request);
            Console.WriteLine(CommunicationController.Send(Config.TELSTAR_URL, jsonString));

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
