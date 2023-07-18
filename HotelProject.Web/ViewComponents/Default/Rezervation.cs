using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.ViewComponents.Default
{
    public class Rezervation: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
