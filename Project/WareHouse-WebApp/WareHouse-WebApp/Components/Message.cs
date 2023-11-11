using Microsoft.AspNetCore.Mvc;

namespace WareHouse_WebApp.Components
{
    public class Message : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
