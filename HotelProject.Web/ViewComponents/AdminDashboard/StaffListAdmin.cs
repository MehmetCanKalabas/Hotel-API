using HotelProject.Web.DTOS.StaffDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HotelProject.Web.ViewComponents.AdminDashboard
{
    public class StaffListAdmin: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffListAdmin(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync("https://localhost:44375/api/Staff");
            if (responsmessage.IsSuccessStatusCode)
            {
                var jsonData = await responsmessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultStaffDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
