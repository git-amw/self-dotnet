
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ClientController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:5047/api/Api"),
                Method = HttpMethod.Get
            };

            HttpClient client = httpClientFactory.CreateClient();
            var response = await client.SendAsync(httpRequestMessage);
            var apicontent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(apicontent);
            return Ok(apicontent);
        }
    }
}