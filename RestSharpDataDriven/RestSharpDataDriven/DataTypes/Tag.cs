using Newtonsoft.Json;

namespace RestSharpDataDriven.DataTypes
{
    class Tag
    {
        [JsonProperty("id")]
        public long tagId { get; set; }
        [JsonProperty("name")]
        public string tagName { get; set; }
    }
}
