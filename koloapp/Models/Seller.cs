using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace koloapp.Models
{
    public class Seller
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        public string Name => $"{FirstName} {LastName}";

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("documents")]
        public List<Document> Documents { get; set; }
    }
}
