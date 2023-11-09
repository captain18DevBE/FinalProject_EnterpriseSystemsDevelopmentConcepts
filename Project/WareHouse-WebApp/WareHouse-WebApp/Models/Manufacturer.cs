using System.ComponentModel.DataAnnotations;

namespace WareHouse_WebApp.Models
{
    public class Manufacturer
    {
        [Key]
        public string? ManufacturerId {  get; set; }
        [Required]
        [StringLength(300)]
        public string? ManufacturerName { get; set;}
        [StringLength(15)]
        public string? PhoneNumber { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }
        [StringLength(250)]
        public string? Address { get; set; }
        [StringLength(500)]
        public string? Note { get; set; }

    }
}
