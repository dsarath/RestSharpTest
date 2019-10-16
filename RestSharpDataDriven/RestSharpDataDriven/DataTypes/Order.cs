using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestSharpDataDriven.DataTypes
{
    class Order
    {
        [JsonProperty("id")]
        public long orderId { get; set; }
        [JsonProperty("petId")]
        public long petId { get; set; }
        [JsonProperty("quantity")]
        public int quantity { get; set; }
        [JsonProperty("shipDate")]
        public string shipDate { get; set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderStatus orderStatus { get; set; }
        [JsonProperty("complete")]
        public bool complete { get; set; }
        // default: false

        public enum OrderStatus { placed, approved, delivered }
    }
}
