using System.Net;
using Newtonsoft.Json;

namespace AppTestAPI.Models
{
    public class TerritoryDetails
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("parent")]
        public string? Parent { get; set; }
    }
}
