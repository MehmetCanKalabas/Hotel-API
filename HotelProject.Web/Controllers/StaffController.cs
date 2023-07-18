using HotelProject.Web.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.Web.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync("https://localhost:44375/api/Staff");
            if (responsmessage.IsSuccessStatusCode)
            {
                var jsonData= await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel model)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responsmessage = await client.PostAsync("https://localhost:44375/api/Staff", content);
            if (responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responsmessage = await client.DeleteAsync("https://localhost:44375/api/Staff?id=" + id);
            if (responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync($"https://localhost:44375/api/Staff/{id}");
            if (responsmessage.IsSuccessStatusCode)
            {
                var jsonData= await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8,"application/json");
            var responsmessage = await client.PutAsync("https://localhost:44375/api/Staff/", stringContent);
            if (responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
