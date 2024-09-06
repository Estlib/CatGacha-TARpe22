using CatGacha.Utilities;
using System.ComponentModel.DataAnnotations;

namespace CatGacha.Models.Accounts
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [ValidEmailDomain (allowedDomain: "gmail.com", ErrorMessage = "Emaili aadress peab olema gmail.com")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display (Name = "Kinnita salasõna")]
        [Compare ("Password", ErrorMessage = "Salasõnad ei ühti, proovi uuesti.")]
        public string ConfirmPassword { get; set; }

        public string City { get; set; }
    }
}
