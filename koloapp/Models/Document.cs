using Newtonsoft.Json;

namespace koloapp.Models
{
    public class Document
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; }
    }
}