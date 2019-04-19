﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinlandVehicleRegister.Core
{
    public static class VehicleAPI
    {
        private static readonly string APIKey = "9rP91EIhlOfiVVO5SZ1Bf2311U";
        public static string URL = $"https://www.jonneokkonen.com/api/ajoneuvorekisteri.php?apiKey={APIKey}&query=";
        public static string LoadData(string query)
        {
            try
            {
                string result = "";
                using (WebClient client = new WebClient())
                {
                    result = client.DownloadString(URL + query);
                }
                return result;
            }catch
            {
                throw;
            }
        }

        public static List<Vehicle> GetVehicles(string query)
        {
            try
            {
                List<Vehicle> vehicles = new List<Vehicle>();
                string json = LoadData(query);
                vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(json);
                if(vehicles[0].Error != null)
                {
                    switch(vehicles[0].Error)
                    {
                        case "Incorrect API - key":
                            throw new IncorrectAPIKeyException("VehicleAPI: Incorrect API-key");
                        case "Query was empty":
                            throw new QueryEmptyException("VehicleAPI: Query was empty");
                        case "0 results from query":
                            throw new ZeroResultsFromQueryException("VehicleAPI: 0 results from query");
                        default:
                            throw new MySQLErrorException($"VehicleAPI: MySQL Error: {vehicles[0].Error}");
                    }
                }
                return vehicles;
            }
            catch
            {
                throw;
            }
        }
    }
}
