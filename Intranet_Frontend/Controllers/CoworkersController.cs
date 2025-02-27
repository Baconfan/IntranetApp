using Microsoft.AspNetCore.Mvc;

namespace Intranet_Frontend.Controllers
{
    public class CoworkersController(IHttpClientFactory httpClientFactory): Controller
    {
        public IActionResult Index()
        {
            return View("Coworkers");
        }

        [HttpGet("Coworkers/{id:int}")]
        public async Task<IActionResult> SearchCoworkerById(int id)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:5276/api/Employee/ById/{id}");
            var client = httpClientFactory.CreateClient();
            var response = await client.SendAsync(httpRequestMessage);

            if(!response.IsSuccessStatusCode)
            {
                return NotFound($"User with ID {id} doesn't exist.");
            }

            var result = await response.Content.ReadAsStringAsync();
            return Ok(result);
        }
    }
}
