using Microsoft.EntityFrameworkCore;
using WareHouse_WebApp.Data;
using WareHouse_WebApp.Models;

namespace WareHouse_WebApp.Service
{
    public class ManufacturersDAO
    {
        private readonly ApplicationDbContext _context;
        public ManufacturersDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Manufacturer> GetManufacturerById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                id = "NC01";
            }

            var manufacturer = await _context.Manufacturer
                .Where(m => m.ManufacturerId == id)
                .FirstOrDefaultAsync();
            return manufacturer;
        }

        public async Task<List<Manufacturer>> GetAll()
        {
            return await _context.Manufacturer.ToListAsync();
        }
    }
}
