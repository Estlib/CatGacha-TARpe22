using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace CatGacha.Models.Accounts
{
    //public enum DeviceLoginSetting
    //{
    //    No, NotOnThisDevice, ThisDeviceOnly, Yes, NotControllableByUser_IsNo,
    //}
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Jäta mind meelde siin")]
        public bool KeepLoggedIn { get; set; }
        //public DeviceLoginSetting KeepMeLoggedIn { get; set; } 
        ////the enum is supposed to replace the boolean
        ////allowing for options other than yes or no
        ////the two added options are for
        //// - this device only (would log out of all other devices the login cookies are on with setting other than no being changed into no)
        //// - not on this device (would set the setting no for this device, if it is set to yes on other devices)
        //// - not controllable by user (option for group policy to dictate the selection, by default, it is no)
        public string ReturnURL { get; set; }
        public IList<AuthenticationScheme> ExternalLoginSessions { get; set; }
    }
}
