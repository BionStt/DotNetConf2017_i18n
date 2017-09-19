using System.ComponentModel.DataAnnotations;

namespace ChinookMusicStore.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
