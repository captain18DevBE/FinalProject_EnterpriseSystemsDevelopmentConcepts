using System.ComponentModel.DataAnnotations;

namespace WareHouse_WebApp.Models
{
    public class ProductCatalog
    {
        [Key]
        public string? CatalogId { get; set; }
        [Required]
        [StringLength(250)]
        public string? CatalogName { get; set; }
    }
}
