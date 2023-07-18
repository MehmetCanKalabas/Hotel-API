using HotelProject.Web.DTOS.RoomDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.Web.ViewComponents.Default
{
    public class Rooms: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Rooms(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client= _httpClientFactory.CreateClient();
            var responsmessage = await client.GetAsync("https://localhost:44375/api/Room");
            if(responsmessage.IsSuccessStatusCode)
            {
                var jsonData= await responsmessage.Content.ReadAsStringAsync();
                var value= JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
