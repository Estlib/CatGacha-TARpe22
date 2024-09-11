using System.ComponentModel.DataAnnotations;

namespace CatGacha.Models.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string RecoveryEmail { get; set; }
    }
}
