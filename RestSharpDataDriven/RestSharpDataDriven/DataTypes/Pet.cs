using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace RestSharpDataDriven.DataTypes
{
    class Pet
    {
        [JsonProperty("id")]
        public long petId { get; set; }
        [JsonProperty("category")]
        public Category category { get; set; }
        [JsonProperty("name")]
        public string petName { get; set; }
        [JsonProperty("photoUrls")]
        public ICollection<string> photoUrls { get; set; }
        [JsonProperty("tags")]
        public ICollection<Tag> tag { get; set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PetStatus petStatus { get; set; }

        public enum PetStatus { available, pending, sold }
    }
}
