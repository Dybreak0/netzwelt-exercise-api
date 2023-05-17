using Newtonsoft.Json;

namespace AppTestAPI.Models
{
    public class LoginPayload
    {
        [JsonProperty("username")]
        public string Username { get; set; } = string.Empty;

        [JsonProperty("password")]
        public string Password { get; set; } = string.Empty;
    }
}
