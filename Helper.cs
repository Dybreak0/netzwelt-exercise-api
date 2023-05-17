using AppTestAPI.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace AppTestAPI
{
    public static class Helper
    {
        public static CustomResponse ComposeResponse(HttpStatusCode statusCode, object responseData)
        {
            var resp = new CustomResponse
            {
                StatusCode = statusCode,
                Content = responseData
            };

            return resp;
        }

        public static void GetErrors(Exception ex, out HttpStatusCode responseCode, out object responseData)
        {

            responseCode = HttpStatusCode.BadRequest;
            responseData = new { message = ex.Message };
        }
    }
}
