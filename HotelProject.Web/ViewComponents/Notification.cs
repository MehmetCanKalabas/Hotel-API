using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.ViewComponents
{
    public class Notification: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Notification(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client2 = _httpClientFactory.CreateClient();
            var responsmessage2 = await client2.GetAsync("https://localhost:44375/api/Contact/GetContactCount");
            if (responsmessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responsmessage2.Content.ReadAsStringAsync();
                ViewBag.contactCount = jsonData2;

            }
            return View();
        }
    }
}
