using HotelProject.Web.DTOS.AboutDtos;
using HotelProject.Web.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.Web.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminAboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync("https://localhost:44375/api/About");
            if (responsmessage.IsSuccessStatusCode)
            {
                var jsonData = await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync($"https://localhost:44375/api/About/id?id={id}");
            if (responsmessage.IsSuccessStatusCode)
            {
                var jsonData = await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsmessage = await client.PutAsync("https://localhost:44375/api/About", stringContent);
            if (responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
