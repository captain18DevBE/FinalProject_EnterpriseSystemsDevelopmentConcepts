using Microsoft.AspNetCore.Mvc;

namespace WareHouse_WebApp.Components
{
    public class Cards : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
