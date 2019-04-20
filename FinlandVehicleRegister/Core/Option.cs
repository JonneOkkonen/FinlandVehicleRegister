using Newtonsoft.Json;

namespace FinlandVehicleRegister.Core
{
    public class Option
    {
        [JsonProperty("Value")]
        public string Value { get; set; }
        [JsonProperty("Error", NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }
    }
}
