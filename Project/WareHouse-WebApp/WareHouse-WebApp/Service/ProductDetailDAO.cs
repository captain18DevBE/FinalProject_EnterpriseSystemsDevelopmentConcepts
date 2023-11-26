using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WareHouse_WebApp.Data;
using WareHouse_WebApp.Models;

namespace WareHouse_WebApp.Service
{
    public class ProductDetailDAO
    {
        private readonly ApplicationDbContext _context;
        public ProductDetailDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDetail> GetProductById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Lỗi dữ liệu Id Product");
            }

            var productDetail = await _context.ProductDetail
                .Where(m => m.ProductId == id)
                .FirstOrDefaultAsync();

            return productDetail;
        }
    }
}
