using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WareHouse_WebApp.Models
{
    public class GoodsReceipt
    {
        [Key]
        public string? GoodsReceiptId { get; set; }
        [StringLength(50)]
        public string? Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfCreation { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalAmount { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal? Discount { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal? AmountPaid { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal AmountOwed { get; set; }
        [StringLength(50)]
        public string? PayMethod { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public string? EmployeeId { get; set; }

        [ForeignKey("ProductDetail")]
        public string? ProductId { get; set; }

        [ForeignKey("Manufacturer")]
        public string? ManufacturerId { get; set; }
    }
}
