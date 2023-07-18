using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.ViewComponents.Default
{
    public class Footer: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
