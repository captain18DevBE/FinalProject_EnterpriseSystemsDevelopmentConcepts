using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WareHouse_WebApp.Models
{
    public class ProductDetail
    {
        [Key]
        [ForeignKey("Product")]
        public string? ProductId { get; set; }
        [Required]
        [StringLength(100)]
        public string? ProductName { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal? CostPrice { get; set; }
        [StringLength(250)]
        public string? ProductPhoto {  get; set; }
        [Required]
        [StringLength(25)]
        public string? Type { get; set;}
        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal? SellingPrice { get; set; }
        [StringLength(50)]

        //update
        public DateTime? DateOfBuy { get; set; }

        public string? Status { get; set; }
        [ForeignKey("Catalog")]
        public string? CatalogId { get; set; }
    }
}
