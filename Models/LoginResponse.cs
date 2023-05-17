using Newtonsoft.Json;

namespace AppTestAPI.Models
{
    public class LoginResponse
    {
        [JsonProperty("username")]
        public string Username { get; set; } = string.Empty;

        [JsonProperty("displayName")]
        public string DisplayName { get; set; } = string.Empty;

        [JsonProperty("roles")]
        public ICollection<string> Roles { get; set; }
    }
}
