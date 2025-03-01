using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer.Models
{
    public class AppointmentHour : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Hour { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]        
        public int DayId { get; set; }
        #region
        [ForeignKey("DayId")]
        public AppointmentDay Day { get; set; }
        #endregion
    }
}
