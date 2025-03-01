using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
    public class Admin :BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Username { get; set; }
        [Required]
        [MaxLength(10)]
        public string Password { get; set; }
    }
}
