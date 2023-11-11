using Microsoft.AspNetCore.Mvc;

namespace WareHouse_WebApp.Components
{
    public class Notification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
