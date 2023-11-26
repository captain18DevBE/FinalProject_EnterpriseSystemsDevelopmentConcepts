using Microsoft.EntityFrameworkCore;
using WareHouse_WebApp.Data;
using WareHouse_WebApp.Models;

namespace WareHouse_WebApp.Service
{
    public class DeliveryNoteDAO
    {
        private readonly ApplicationDbContext _context;
        public DeliveryNoteDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DeliveryNote> getLastAsync()
        {
            var lastDeliver = await _context.DeliveryNotes
                .OrderByDescending(x => x.DeliveryNoteId).FirstOrDefaultAsync();

            return lastDeliver;
        }

    }
}
