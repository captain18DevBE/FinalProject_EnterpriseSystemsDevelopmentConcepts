using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WareHouse_WebApp.Models
{
    public class Account
    {
        [Key]
        [ForeignKey("Employee")]
        public string EmployeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(20)]
        public string Status { get; set; }
    }
}
