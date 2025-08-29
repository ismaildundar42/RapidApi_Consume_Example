using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume.Models;
using System.Net.Http.Headers;
namespace RapidAPIConsume.Controllers
{
    public class SearchLocationIdController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if (!string.IsNullOrWhiteSpace(cityName))
            {
                List<BookingApiLocationSearchModel> model = new List<BookingApiLocationSearchModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={cityName}"),
                    Headers =
    {
        { "x-rapidapi-key", "4b780e4365msh051c17373b7a5ecp178b08jsn3aeb1d9a94cc" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<BookingApiLocationSearchModel>>(body);
                    return View(model.Take(1).ToList());
                }
            }
            else
            {
                List<BookingApiLocationSearchModel> model = new List<BookingApiLocationSearchModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name=Paris"),
                    Headers =
    {
        { "x-rapidapi-key", "4b780e4365msh051c17373b7a5ecp178b08jsn3aeb1d9a94cc" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<BookingApiLocationSearchModel>>(body);
                    return View(model.Take(1).ToList());
                }
            }

            
        }
    }
}