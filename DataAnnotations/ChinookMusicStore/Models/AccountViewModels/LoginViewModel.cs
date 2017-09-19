using System.ComponentModel.DataAnnotations;

namespace ChinookMusicStore.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "NotValidEmail")]
        [Display(Name = "YourEmail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "RememberMe")]
        public bool RememberMe { get; set; }
    }
}
