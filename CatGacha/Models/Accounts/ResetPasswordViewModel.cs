using System.ComponentModel.DataAnnotations;

namespace CatGacha.Models.Accounts
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string BackupEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Salasõnad ei ühti, palun kontrolli et kirjutasid mõlemad samamoodi.")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}
