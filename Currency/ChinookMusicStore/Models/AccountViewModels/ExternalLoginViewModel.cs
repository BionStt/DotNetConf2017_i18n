using System.ComponentModel.DataAnnotations;

namespace ChinookMusicStore.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
