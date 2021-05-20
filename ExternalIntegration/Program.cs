using ExternalIntegration.Enums;
using ExternalIntegration.Services;
using ExternalIntegration.Utils;
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
            OceanicAirlinesCommunication.RequestRoute(CompanyEnum.TELSTAR_LOGISTICS, CityEnum.ADDIS_ABEBA, CityEnum.AMATAVE, "parcelType", 2, 3, 4, 5);
            TelstarCommunication.RequestRoute(new TelstarRequest {
                Company = CompanyEnum.TELSTAR_LOGISTICS.ToString(),
                SecretCompanyCode = CompanySecrets.GetTelstarSecret(),
                CityFrom = CityEnum.ADDIS_ABEBA.ToString(),
                CityTo = CityEnum.CAIRO.ToString(),
                Features = new string[0],
                Weight = 2,
                Height = 2,
                Width = 2,
                Length = 2
            });
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
