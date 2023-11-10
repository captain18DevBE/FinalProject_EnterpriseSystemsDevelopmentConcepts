using Microsoft.AspNetCore.Mvc;

namespace WareHouse_WebApp.Components
{
    public class Navbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
