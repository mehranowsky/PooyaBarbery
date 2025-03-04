using System.ComponentModel.DataAnnotations;

namespace MainApp.Models.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name ="نام کاربری")]
        [Required(ErrorMessage ="{0} نمیتواند خالی باشد!")]
        [MaxLength(15)]
        public string Username { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد!")]
        [MaxLength(10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
