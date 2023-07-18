using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.ViewComponents
{
    public class SidebarLayout: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
