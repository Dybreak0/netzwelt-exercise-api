using System.Net;

namespace AppTestAPI.Models
{
    public class CustomResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Content { get; set; }
    }
}
