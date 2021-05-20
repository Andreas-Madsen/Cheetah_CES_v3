using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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

        //private const string URL = "http://wa-tl-dk2.azurewebsites.net/telstarroutes";

        private const string jsonBody = "{"+
    "\"Company\":\"TELSTAR_LOGISTICS\"," +
    "\"SecretCompanyCode\":\"KLdsaklwPldTdmWOdcMAwf73Adm1rRFijofdsijterI\"," +
    "\"CityFrom\":\"ADDIS_ABEBA\"," +
    "\"CityTo\":\"AMATAVE\"," +
    "\"Features\":[]," +
    "\"Weight\":2," +
    "\"Height\":2," +
    "\"Width\":2," +
    "\"Length\":2" +
    "}";

        static string CallApi(string url) {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage request = new HttpRequestMessage {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
            };

            var response = client.SendAsync(request).ConfigureAwait(false);
            HttpResponseMessage result = response.GetAwaiter().GetResult();

            string resultString = null;

            if (result.IsSuccessStatusCode) {
                resultString = result.Content.ReadAsStringAsync().Result;
            }
            else {
                Console.WriteLine("{0} ({1})", (int)result.StatusCode, result.ReasonPhrase);
            }

            // Make any other calls using HttpClient here.
            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
            Console.WriteLine(resultString);
            return resultString;
        }


        public static void Main(string[] args)
        {
            CallApi("http://wa-tl-dk2.azurewebsites.net/telstarroutes");
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
