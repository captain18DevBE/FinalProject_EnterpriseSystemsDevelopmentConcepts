using Microsoft.AspNetCore.Mvc;

namespace WareHouse_WebApp.Components
{
    public class CreateProduct : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
