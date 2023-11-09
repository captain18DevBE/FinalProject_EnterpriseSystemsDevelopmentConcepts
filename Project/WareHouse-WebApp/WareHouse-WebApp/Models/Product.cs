using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WareHouse_WebApp.Models
{
    public class Product
    {
        [Key]
        public string? ProductId { get; set; }
        [Required]
        [StringLength(150)]
        public string? ProductName { get; set; }
        [Required]
        public int Amount { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal? ProductPrice { get; set; }
        [StringLength(300)]
        public string? ProductPhoto {  get; set; }
        [ForeignKey("Category")]
        public string? CategoryId {get; set; }
    }
}
