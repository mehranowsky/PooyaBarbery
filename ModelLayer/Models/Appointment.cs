using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer.Models
{
    public class Appointment : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
        [Required]
        [MaxLength(15)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(12)]
        public string PhoneNumber { get; set; }
        [Required]
        public int AppointmentDayId { get; set; }
        [Required]
        public int AppointmentHourId { get; set; }

        #region
        [ForeignKey("AppointmentDayId")]
        public AppointmentDay AppointmentDay { get; set; }

        #endregion
    }
}
