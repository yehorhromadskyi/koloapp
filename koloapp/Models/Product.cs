using System.Collections.Generic;
using Newtonsoft.Json;

namespace koloapp.Models
{
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("harvestYear")]
        public short HarvestYear { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("quantetyKG")]
        public int Quantity { get; set; }

        [JsonProperty("selerId")]
        public int SellerId { get; set; }

        [JsonProperty("documents")]
        public List<Document> Documents { get; set; }
    }
}
