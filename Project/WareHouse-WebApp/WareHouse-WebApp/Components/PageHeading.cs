using Microsoft.AspNetCore.Mvc;

namespace WareHouse_WebApp.Components
{
    public class PageHeading : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
