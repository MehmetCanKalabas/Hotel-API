using HotelProject.BuninessLayer.Abstract;
using HotelProject.Web.DTOS.ServiceDtos;
using HotelProject.Web.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.Web.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync("https://localhost:44375/api/Service");
            if (responsmessage.IsSuccessStatusCode)
            {
                var jsonData = await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddService(CreateServiceDto createServiceDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createServiceDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsmessage = await client.PostAsync("https://localhost:44375/api/Service", content);
            if (responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.DeleteAsync("https://localhost:44375/api/Service?id=" + id);
            if (responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync($"https://localhost:44375/api/Service/{id}");
            if (responsmessage.IsSuccessStatusCode)
            {
                var jsonData = await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsmessage = await client.PutAsync("https://localhost:44375/api/Service/", stringContent);
            if (responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
