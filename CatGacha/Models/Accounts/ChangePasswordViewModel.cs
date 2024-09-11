using System.ComponentModel.DataAnnotations;

namespace CatGacha.Models.Accounts
{
    public class ChangePasswordViewModel
    {
        /* thought:
         * in the future, changepassword and addpassword models could be combined into one password model.
         * 
         * as addpassword has two datapoints, changepassword function could be refactored in the frontend to use 2 instances of the 
         * same password model. one for existing password one for new password.
         * 
         * i dont know how to do this yet
         */
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Praegune Salasõna")]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Uus Salasõna")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Uue Salasõna Pimekoopia")]
        public string ConfirmPassword { get; set; }
    }
}
