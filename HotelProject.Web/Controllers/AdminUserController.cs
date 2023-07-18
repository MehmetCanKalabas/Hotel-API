using HotelProject.EntityLayer.Concrete;
using HotelProject.Web.DTOS.AppUserDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.Web.Controllers
{
    public class AdminUserController : Controller
    {
       private readonly IHttpClientFactory _httpClientFactory;

        public AdminUserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client= _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync("https://localhost:44375/api/AppUser");
            if(responsmessage.IsSuccessStatusCode)
            {
                var jsonData= await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultAppUserDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
