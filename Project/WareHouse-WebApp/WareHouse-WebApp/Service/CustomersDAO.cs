using Microsoft.EntityFrameworkCore;
using WareHouse_WebApp.Data;
using WareHouse_WebApp.Models;

namespace WareHouse_WebApp.Service
{
    public class CustomersDAO
    {
        private readonly ApplicationDbContext _context;
        public CustomersDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                id = "NC01";
            }

            var customer = await _context.Customers
                .Where(m => m.CustomerId == id)
                .FirstOrDefaultAsync();
            return customer;
        }
    }
}
