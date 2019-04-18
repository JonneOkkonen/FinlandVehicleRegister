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
        private static readonly string URL = $"https://www.jonneokkonen.com/api/ajoneuvorekisteri.php?apiKey={APIKey}&query=";
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
    }
}
