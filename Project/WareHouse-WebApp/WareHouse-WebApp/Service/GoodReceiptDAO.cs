using Microsoft.EntityFrameworkCore;
using WareHouse_WebApp.Data;
using WareHouse_WebApp.Models;

namespace WareHouse_WebApp.Service
{
    public class GoodReceiptDAO
    {
        private readonly ApplicationDbContext _context;
        public GoodReceiptDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GoodsReceipt>> GetAllGoodsReceipts()
        {
            List<GoodsReceipt> list = await _context.GoodsReceipts.ToListAsync();
            return list;
        }

        public async Task<GoodsReceipt> GetLastGoodsReceipt()
        {
            GoodsReceipt goodsReceipt = await _context.GoodsReceipts.OrderByDescending(gr => gr.GoodsReceiptId).FirstOrDefaultAsync();
            return goodsReceipt;
        }
    }
}
