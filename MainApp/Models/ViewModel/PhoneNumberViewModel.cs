using System.ComponentModel.DataAnnotations;

namespace MainApp.Models.ViewModel
{
    public class PhoneNumberViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }
        [Display(Name = "شماره تماس")]
        public string PhoneNumber { get; set; }
    }
}
