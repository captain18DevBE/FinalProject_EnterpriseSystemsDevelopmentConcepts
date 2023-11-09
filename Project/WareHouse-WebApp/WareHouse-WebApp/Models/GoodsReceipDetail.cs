using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WareHouse_WebApp.Models
{
    public class GoodsReceipDetail
    {
        [Key]
        [ForeignKey("GoodsReceipt")]
        public string? GoodsReceipId { get; set; }
        [Required]
        [ForeignKey("Product")]
        public string? ProductId { get; set; }

    }
}
