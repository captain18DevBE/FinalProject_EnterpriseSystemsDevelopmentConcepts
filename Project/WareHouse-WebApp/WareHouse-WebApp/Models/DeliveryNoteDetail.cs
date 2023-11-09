using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WareHouse_WebApp.Models
{
    public class DeliveryNoteDetail
    {
        [Key]
        [ForeignKey("DeliveryNote")]
        public string? DeliveryNoteId {  get; set; }
        [Required]
        [ForeignKey("Customer")]
        public string? CustomerId { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public string? EmployeeId { get; set; }
    }
}
