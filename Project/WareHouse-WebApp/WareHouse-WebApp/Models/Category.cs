using System.ComponentModel.DataAnnotations;

namespace WareHouse_WebApp.Models
{
    public class Category
    {
        [Key]
        public string? CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string? CategoryName { get; set;}
    }
}
