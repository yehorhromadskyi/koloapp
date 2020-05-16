using System;
using Newtonsoft.Json;

namespace koloapp.Models
{
    public class Record
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("sellerId")]
        public long SellerId { get; set; }

        [JsonProperty("sellerName")]
        public string SellerName { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }
    }
}
