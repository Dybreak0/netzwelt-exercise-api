using System.Net;
using Newtonsoft.Json;

namespace AppTestAPI.Models
{
    public class Territory
    {
        [JsonProperty("data")]
        public ICollection<TerritoryDetails> Data { get; set; }
    }
}
