using System.ComponentModel.DataAnnotations;

namespace WareHouse_WebApp.Models
{
    public class Employee
    {
        [Key]
        public string? EmployeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string? LastName { get; set;}
        [StringLength(250)]
        public string? Address { get; set; }
        [StringLength(250)]
        public string? Email { get; set; }
        [StringLength(15)]
        public string? PhoneNumber { get; set; }
        [StringLength(50)]
        public string? Role { get; set; }
    }
}
