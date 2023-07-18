using HotelProject.Web.DTOS.StaffDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.Web.ViewComponents.Default
{
    public class Staff: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Staff(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client= _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync("https://localhost:44375/api/Staff");
            if(responsmessage.IsSuccessStatusCode)
            {
                var jsonData= await responsmessage.Content.ReadAsStringAsync();
                var value= JsonConvert.DeserializeObject<List<ResultStaffDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
