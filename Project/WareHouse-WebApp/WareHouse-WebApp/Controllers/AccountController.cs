using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WareHouse_WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult IndexAsync()
        {
            List<IdentityUser> users = _userManager.Users.ToList();
            return View(users);
        }
        public IActionResult SetPass()
        {
            
            return View();
        }
    }
}
