using Newtonsoft.Json;

namespace RestSharpDataDriven.DataTypes
{
    class Category
    {
        [JsonProperty("id")]
        public long ctgId { get; set; }
        [JsonProperty("name")]
        public string ctgName { get; set; }
    }
}
