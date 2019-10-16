using Newtonsoft.Json;

namespace RestSharpDataDriven.DataTypes
{
    class User
    {
        [JsonProperty("id")]
        public long userId { get; set; }
        [JsonProperty("username")]
        public string userName { get; set; }
        [JsonProperty("firstName")]
        public string firstName { get; set; }
        [JsonProperty("lastName")]
        public string lastName { get; set; }
        [JsonProperty("email")]
        public string email { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }
        [JsonProperty("phone")]
        public string phone { get; set; }
        [JsonProperty("userStatus")]
        public int userStatus { get; set; }
    }
}
