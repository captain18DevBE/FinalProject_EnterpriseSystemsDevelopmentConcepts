using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WareHouse_WebApp.Models
{
    public class Employee
    {
        [Key, MaxLength(10)]
        public string? EmployeeId { get; set; }
        [MaxLength(30)]
        public string? FirstName { get; set; }
        [MaxLength(30)]
        public string? LastName { get; set; }
        public string? Address { get; set; }
        [EmailAddress, MaxLength(256)]
        public string? Email { get; set; }
        [Phone, MaxLength(10)] 
        public string Phone { get; set; }
        [MaxLength(10)]
        public string? Role { get; set; }
    }
}
