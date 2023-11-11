using Microsoft.AspNetCore.Mvc;
using WareHouse_WebApp.Data;

namespace WareHouse_WebApp.Components
{
    public class ProductTable : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ProductTable(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.ProductDetail.ToList());
        }
    }
}
