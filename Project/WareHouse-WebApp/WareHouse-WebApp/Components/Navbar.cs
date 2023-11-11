using Microsoft.AspNetCore.Mvc;
using WareHouse_WebApp.Data;

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
