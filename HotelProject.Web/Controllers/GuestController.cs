using HotelProject.Web.DTOS.GuestDtos;
using HotelProject.Web.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.Web.Controllers
{
    public class GuestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GuestController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync("https://localhost:44375/api/Guest");
            if (responsmessage.IsSuccessStatusCode)
            {
                var jsonData = await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddGuest()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGuest(CreateGuestDto model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responsmessage = await client.PostAsync("https://localhost:44375/api/Guest", content);
                if (responsmessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            else
            {
                return View();
            }
            
        }
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.DeleteAsync("https://localhost:44375/api/Guest?id=" + id);
            if (responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync($"https://localhost:44375/api/Guest/{id}");
            if (responsmessage.IsSuccessStatusCode)
            {
                var jsonData = await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateGuestDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGuest(UpdateGuestDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsmessage = await client.PutAsync("https://localhost:44375/api/Guest/", stringContent);
            if (responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
