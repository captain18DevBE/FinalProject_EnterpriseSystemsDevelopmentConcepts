using System.ComponentModel.DataAnnotations;

namespace WareHouse_WebApp.Models
{
    public class Customer
    {
        [Key]
        public string? CustomerId { get; set; }
        [Required]
        [StringLength(150)]
        public string? CustomerName { get; set; }
        [StringLength(150)]
        public string? CustomerEmail { get; set; }
        [StringLength(150)]
        public string? CustomerPhone { get; set;}
        [StringLength(150)]
        public string? CustomerAddress { get; set; }

    }
}
