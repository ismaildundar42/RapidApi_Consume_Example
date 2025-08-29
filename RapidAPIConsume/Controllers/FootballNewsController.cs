using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume.Models;

namespace RapidAPIConsume.Controllers
{
    public class FootballNewsController : Controller
    {
        public async Task<IActionResult> Index()
        {   
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://football-news11.p.rapidapi.com/api/news-by-date?date=2025-05-01&lang=en&page=1"),
                Headers =
    {
        { "x-rapidapi-key", "4b780e4365msh051c17373b7a5ecp178b08jsn3aeb1d9a94cc" },
        { "x-rapidapi-host", "football-news11.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<FootballNewsViewModel>(body);
                return View(values.result.ToList());
            }
        }
    }
}
