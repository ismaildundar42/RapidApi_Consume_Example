using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume.Models;

namespace RapidAPIConsume.Controllers
{
    public class BookingByCityController : Controller
    {
        public async Task<IActionResult> Index(string cit_id)
        {
            if (!string.IsNullOrWhiteSpace(cit_id))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?children_number=2&adults_number=2&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_ages=5%2C0&checkout_date=2025-09-03&dest_type=city&page_number=0&units=metric&order_by=popularity&room_number=1&checkin_date=2025-08-31&filter_by_currency=EUR&dest_id={cit_id}&locale=en-gb&include_adjacency=true"),
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
                    var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);
                    return View(values.results.ToList());
                }
            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?children_number=2&adults_number=2&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_ages=5%2C0&checkout_date=2025-09-03&dest_type=city&page_number=0&units=metric&order_by=popularity&room_number=1&checkin_date=2025-08-31&filter_by_currency=EUR&dest_id=-1456928&locale=en-gb&include_adjacency=true"),
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
                    var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);
                    return View(values.results.ToList());
                }
            }
        }
    }
}
