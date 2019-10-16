using Newtonsoft.Json;

namespace RestSharpDataDriven.DataTypes
{
    class ApiResponse
    {
        [JsonProperty("code")]
        public int code { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
    }
}
