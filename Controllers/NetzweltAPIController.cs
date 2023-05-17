using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using AppTestAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace AppTestAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NetzweltAPIController : Controller
    {
        private readonly ILogger<NetzweltAPIController> _logger;

        public NetzweltAPIController(ILogger<NetzweltAPIController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [ActionName("Login")]
        public IActionResult Login(LoginPayload loginPayload)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // Create and setup the client
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Create and setup the http request
                    var method = new HttpMethod("POST");
                    var api = "https://netzwelt-devtest.azurewebsites.net/Account/SignIn";
                    StringContent postValue = new StringContent(JsonConvert.SerializeObject(loginPayload), Encoding.UTF8, "application/json");

                    //var httpRequestMessage = new HttpRequestMessage(method, api) { Content = postValue };
                    //var httpResponseMessage = client.SendAsync(httpRequestMessage).Result;


                    var httpResponseMessage = client.PostAsync(api, postValue).Result;

                    // If request successfully retrieves data
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var responseData = httpResponseMessage.Content.ReadFromJsonAsync<LoginResponse>().Result;
                        return Ok(responseData);
                    }
                    else
                    {
                        throw new Exception("Invalid username or password.");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return null;

        }
    }
}