using CatGacha.Core.Domain;
using CatGacha.Data;
using CatGacha.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CatGacha.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly CatGachaContext _context;

        public AccountsController
            (
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager,
                CatGachaContext catGachaContext
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = catGachaContext;
        }

        [HttpGet]
        public async Task<IActionResult> AddPassword()
        {
            var userWithoutPassword = await _userManager.GetUserAsync(User);
            var userThatHasPassword = await _userManager.HasPasswordAsync(userWithoutPassword);

            if (userThatHasPassword)
            {
                RedirectToAction("ChangePassword");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPassword(AddPasswordViewModel apm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _userManager.AddPasswordAsync(user, apm.NewPassword);

                if (!result.Succeeded)
                {
                    foreach ( var error in result.Errors )
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }

                await _signInManager.RefreshSignInAsync(user);
                return View("AddPasswordConfirmation");

            }

            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel cpm)
        {
            if (ModelState.IsValid)
            {
                var userThatWantsNewPassword = await _userManager.GetUserAsync(User);
                if (userThatWantsNewPassword == null)
                {
                    return RedirectToAction("Login");
                }

                var result = await _userManager.ChangePasswordAsync(userThatWantsNewPassword, cpm.CurrentPassword, cpm.NewPassword);

                if (!result.Succeeded)
                {
                    foreach( var error in result.Errors )
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }
                await _signInManager.RefreshSignInAsync(userThatWantsNewPassword);
                return View("ChangePasswordConfirmation");
            }
            return View(cpm);
        }





        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new ApplicationUser
                {
                    /*
                     * Todo: add actual username at signup time.
                     * consider the two as possible aliases for oneanother at login.  Email <-=-> Username
                     */
                    UserName = model.Email,
                    Email = model.Email,
                    City = model.City,
                };

                var result = await _userManager.CreateAsync(newUser, model.Password);

                if (result.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                    var confirmationLink = Url.Action("ConfirmEmail", "Accounts", new { userId = newUser.Id, token = token}, Request.Scheme);
                    
                    if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin") ) 
                    {
                        return RedirectToAction("ListUsers", "Administrations");
                    }
                    ViewBag.ErrorTitle = "Registreerimine edukas";
                    ViewBag.ErrorMessage = "Enne kui saad sisse logida, palun vajuta lingile emailis mis saatsime su aadressile.";
                    return View("Error");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }


    }
}
