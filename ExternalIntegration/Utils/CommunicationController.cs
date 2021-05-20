using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ExternalIntegration.Utils {
    public class CommunicationController {
        public static string Send(string url, string jsonBody) {
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
            } else if (Config.PRINT_SERVER_ERRROS) {
                Console.WriteLine("{0} ({1})", (int)result.StatusCode, result.ReasonPhrase);
            }

            client.Dispose();
            return resultString;
        }
    }
}
