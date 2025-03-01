using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
    public class AppointmentDay:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Day { get; set; }
        public virtual IEnumerable<AppointmentHour> Hours { get; set; }
    }
}
