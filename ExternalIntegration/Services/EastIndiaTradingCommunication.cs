﻿using ExternalIntegration.Enums;
using ExternalIntegration.Models;
using ExternalIntegration.Utils;
using System;
using System.Text.Json;

namespace ExternalIntegration.Services {
    public class EastIndiaTradingCommunication {
        /**
         * This method builds the url for the request to East India Trading
         * with the parameters since they do not have a body for the request
         */
        private static string BuildUrl(CityEnum cityFrom, CityEnum cityTo, int weight, bool fragile, bool recorded) {
            string url = Config.EAST_INDIA_TRADING_URL +
                "cityFrom=" + cityFrom.ToString() + "&" +
                "cityTo=" + cityTo.ToString() + "&" +
                "date=2021-05-21&" +
                "shipmentType=STANDARD&" +
                "weight=" + weight + "&" +
                "isFragile=" + fragile + "&" +
                "isRecorded=" + recorded;
            url = url.Replace("False", "false").Replace("True", "true");
            return url;
        }

        public static EastIndiaResponse RequestRoute(CityEnum cityTo, CityEnum cityFrom, int weight, bool fragile, bool recorded) {
            string url = BuildUrl(cityTo, cityFrom, weight, fragile, recorded);
            string response = CommunicationController.Send(url, "");
            //Console.WriteLine(response);

            EastIndiaResponse eastIndiaResponse = JsonSerializer.Deserialize<EastIndiaResponse>(response);
            return eastIndiaResponse;
        }
    }
}
