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
        public static TelstarResponse RequestRoute(TelstarRequest request) {
            string jsonString = JsonSerializer.Serialize(request);
            string response = CommunicationController.Send(Config.TELSTAR_URL, jsonString);
            //Console.WriteLine(response);
            
            TelstarResponse telstarResponse = JsonSerializer.Deserialize<TelstarResponse>(response);
            return telstarResponse;
        }
    }
}
