using ExternalIntegration.Enums;
using ExternalIntegration.Utils;
using System;
using System.Text.Json;

namespace ExternalIntegration.Services {
    public class TelstarCommunication {

        /**
         * This method will not be used by our system but it is nice
         * to have in order to test that we can call our own service
         * through code.
         */
        public static void RequestRoute() {
            TelstarRequest request = new TelstarRequest {
                Company = CompanyEnum.TELSTAR_LOGISTICS.ToString(),
                SecretCompanyCode = CompanySecrets.GetTelstarSecret(),
                CityFrom = CityEnum.ADDIS_ABEBA.ToString(),
                CityTo = CityEnum.CAIRO.ToString(),
                Features = new string[0],
                Weight = 2,
                Height = 2,
                Width = 2,
                Length = 2
            };
            string jsonString = JsonSerializer.Serialize(request);
            Console.WriteLine(CommunicationController.Send(Config.TELSTAR_URL, jsonString));
        }
    }
}
