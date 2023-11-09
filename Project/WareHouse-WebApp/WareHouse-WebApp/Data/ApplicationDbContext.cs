using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WareHouse_WebApp.Models;

namespace WareHouse_WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DeliveryNote> DeliveryNotes { get; set;}
        public DbSet<DeliveryNoteDetail> DeliveryNotesDetail { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<GoodsReceipt> GoodsReceipts { get; set; }
        public DbSet<GoodsReceipDetail> GoodsReceipDetail { get;set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCatalog> ProductCatalog { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }

    }
}