using System.ComponentModel.DataAnnotations;

namespace CatGacha.Models.Accounts
{
    public class AddPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Uus Salasõna")]
        public string NewPassword { get; set; }
        [Required]
        [DataType (DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Salasõnad ei ühti, palun kontrolli et kirjutasid mõlemad samamoodi.")]
        public string ConfirmPassword { get; set;}
    }
}
