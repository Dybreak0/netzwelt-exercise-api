using System.Net;

namespace AppTestAPI.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public class LoginPayload
    {
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public string username { get; set; } = string.Empty;
        public string displayName { get; set; } = string.Empty;
        public ICollection<string> roles { get; set; }
    }

    public class CustomResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Content { get; set; }
    }
}