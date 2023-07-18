using HotelProject.Web.Models.SearchLocation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.Web.Controllers
{
    public class SearchLocationIDController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if(!string.IsNullOrEmpty(cityName))
            {
                List<SearchLocationModel> locationModels = new List<SearchLocationModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "389d2f19d5msh6ecc5da32e4b031p18ed9ejsn13404f58ec6d" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    locationModels = JsonConvert.DeserializeObject<List<SearchLocationModel>>(body);
                    return View(locationModels.Take(1).ToList());


                }
            }
            else
            {
                List<SearchLocationModel> locationModels = new List<SearchLocationModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=%C4%B0zmir&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "389d2f19d5msh6ecc5da32e4b031p18ed9ejsn13404f58ec6d" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    locationModels = JsonConvert.DeserializeObject<List<SearchLocationModel>>(body);
                    return View(locationModels.Take(1).ToList());


                }
            }
           
           
        }
    }
}
