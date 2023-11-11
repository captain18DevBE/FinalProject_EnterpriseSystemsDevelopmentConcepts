using Microsoft.AspNetCore.Mvc;

namespace WareHouse_WebApp.Components
{
    public class ProductTable : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
