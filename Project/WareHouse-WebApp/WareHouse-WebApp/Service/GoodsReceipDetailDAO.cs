using WareHouse_WebApp.Data;
using WareHouse_WebApp.Models;

namespace WareHouse_WebApp.Service
{
    public class GoodsReceipDetailDAO
    {
        private readonly ApplicationDbContext _context;

        public GoodsReceipDetailDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddGoodsReceipDetail(GoodsReceipDetail detail)
        {
            _context.GoodsReceipDetail.Add(detail);
            await _context.SaveChangesAsync();
        }
    }
}
