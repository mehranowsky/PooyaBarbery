using System.ComponentModel.DataAnnotations;

namespace MainApp.Models.ViewModel
{
    public class AppointmentViewModel
    {
        [Display(Name ="نام")]
        [Required(ErrorMessage ="{0} را وارد کنید")]        
        [StringLength(15,MinimumLength =3,ErrorMessage = "{0} باید بین 3 تا 15 حرف باشد")]
        public string Name { get; set; }
        [Display(Name ="نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "{0} باید بین 3 تا 15 حرف باشد")]
        public string LastName { get; set; }
        [Display(Name = "شماره تماس")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(11)]
        [RegularExpression("(09)[0-9]{9}",ErrorMessage ="{0} اشتباه میباشد")]
        public string PhoneNumber { get; set; }
        [Display(Name = "روز")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public int AppointmentDayId { get; set; }
        [Display(Name = "ساعت")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public int AppointmentHourId { get; set; }
    }
}
