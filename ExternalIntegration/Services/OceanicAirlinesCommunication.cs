using ExternalIntegration.Enums;
using ExternalIntegration.Models;
using ExternalIntegration.Utils;
using System;
using System.Text.Json;

namespace ExternalIntegration.Services {
    public class OceanicAirlinesCommunication {

        /**
         * This method builds the url for the request to Oceanic Airlines
         * with the parameters since they do not have a body for the request
         */
        private static string BuildUrl(CompanyEnum companyCode, CityEnum cityFrom, CityEnum cityTo, string parcelTyoe, int weight, int height, int width, int length) {
            string url = Config.OCEANIC_AIRLINES_URL;
            url += "companyCode=" + companyCode.ToString() + "&";
            url += "cityFrom=" + cityFrom.ToString() + "&";
            url += "&cityTo=" + cityTo.ToString() + "&";
            url += "parceltype=" + parcelTyoe + "&";
            url += "weight=" + weight + "&";
            url += "height=" + height + "&";
            url += "width=" + width + "&";
            url += "lenght=" + length;

            return url;
        }

        public static OceanicResponse RequestRoute(CompanyEnum companyCode, CityEnum cityFrom, CityEnum cityTo, string parcelTyoe, int weight, int height, int width, int length) {
            try {
                string url = BuildUrl(companyCode, cityFrom, cityTo, parcelTyoe, weight, height, width, length);
                string response = CommunicationController.Send(url, "");
                //Console.WriteLine(response);

                OceanicResponse oceanicResponse = JsonSerializer.Deserialize<OceanicResponse>(response);

                if (oceanicResponse.price == -1 || oceanicResponse.time == -1) {
                    return null;
                }

                return oceanicResponse;
            }
            catch (Exception) {
                return null;
            }
        }
    }
}
