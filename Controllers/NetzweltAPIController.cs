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

        public NetzweltAPIController()
        {
        }

        [HttpPost]
        [ActionName("Account/SignIn")]
        public IActionResult Login(LoginPayload loginPayload)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Create and setup the client
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Create and setup the http request
                    string api = "https://netzwelt-devtest.azurewebsites.net/Account/SignIn";
                    StringContent postValue = new StringContent(JsonConvert.SerializeObject(loginPayload), Encoding.UTF8, "application/json");

                    HttpResponseMessage httpResponseMessage = client.PostAsync(api, postValue).Result;

                    // If request successfully post data
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        LoginResponse responseData = httpResponseMessage.Content.ReadFromJsonAsync<LoginResponse>().Result;
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
        }

        [HttpGet]
        [ActionName("Territories/All")]
        public IActionResult GetAllTerritories()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Create and setup the client
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Create and setup the http request
                    string api = "https://netzwelt-devtest.azurewebsites.net/Territories/All";
                    HttpResponseMessage httpResponseMessage = client.GetAsync(api).Result;

                    // If request successfully retrieves data
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        Territory responseData = httpResponseMessage.Content.ReadFromJsonAsync<Territory>().Result;
                        return Ok(responseData);
                    }
                    else
                    {
                        throw new Exception("Failed to retrieve territories");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}