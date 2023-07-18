using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.ViewComponents.Default
{
    public class Slide: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
