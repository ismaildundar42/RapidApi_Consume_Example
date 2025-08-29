using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume.Models;

namespace RapidAPIConsume.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {


            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=TRY"),
                Headers =
    {
        { "x-rapidapi-key", "4b780e4365msh051c17373b7a5ecp178b08jsn3aeb1d9a94cc" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                return View(values.data.exchange_rates.ToList());

            }
            
        }
    }
}
