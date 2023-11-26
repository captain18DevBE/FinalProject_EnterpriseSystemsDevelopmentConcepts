using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WareHouse_WebApp.Models
{
    public class DeliveryNote
    {
        [Key]
        public string? DeliveryNoteId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfCreation { get; set; }
        [StringLength(50)]
        public string? Status { get; set; }
        [Column(TypeName = "decimal(12,2)" )]
        public decimal TotalAmount { get; set; }
        [StringLength(50)]
        public string? PayMethod { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal? AmountPaid { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal AmountOwed { get; set; }

        //UPDATE
        public int AmountProduct { get; set; }

        [ForeignKey("Customer")]
        public string? CustomerId { get; set; }
        [ForeignKey("Employee")]
        public string? EmployeeId { get; set; }
        [ForeignKey("ProductDetail")]
        public string? ProductId { get; set; }
    }
}
