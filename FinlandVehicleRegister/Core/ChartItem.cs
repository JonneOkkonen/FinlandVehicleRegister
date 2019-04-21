using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinlandVehicleRegister.Core
{
    public class ChartItem
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Value")]
        public double Value { get; set; }
        [JsonProperty("Error", NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }
    }
}
