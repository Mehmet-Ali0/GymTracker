using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GymTracker.ViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        [Compare("Password",ErrorMessage = "They Do not match")]
        public string ConfirmPassword { get; set; }

    }
}
