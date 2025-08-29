using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume.Models;
using System.Net.Http.Headers;
namespace RapidAPIConsume.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-1000-movies-series.p.rapidapi.com/list/1"),
                Headers =
    {
        { "x-rapidapi-key", "4b780e4365msh051c17373b7a5ecp178b08jsn3aeb1d9a94cc" },
        { "x-rapidapi-host", "imdb-top-1000-movies-series.p.rapidapi.com" },
    },
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();

            var root = JsonConvert.DeserializeObject<ApiMovieResponse>(body);
            var movies = root?.Result ?? new List<ApiMovieViewModel>();

            return View(movies);
        }
    }
}
