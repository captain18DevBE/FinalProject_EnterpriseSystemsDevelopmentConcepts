using Microsoft.AspNetCore.Mvc;

namespace WareHouse_WebApp.Components
{
    public class UserInf : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
