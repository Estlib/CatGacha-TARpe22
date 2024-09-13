using CatGacha.Core.Domain;
using CatGacha.Core.Dto.AccountDtos;
using CatGacha.Core.ServiceInterface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatGacha.ApplicationServices.Services
{
    public class AccountsServices : IAccountsServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountsServices
            (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> Register(ApplicationUserDto dto)
        {
            var newUser = new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                City = dto.City,
            };

            var result = await _userManager.CreateAsync( newUser, dto.Password );

            if ( result.Succeeded )
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            }
            return newUser;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> ConfirmEmail(string userId, string token)
        {
            var userToConfirm = await _userManager.FindByIdAsync( userId );
            if (userToConfirm == null)
            {
                string errorReturned = $"Kasutaja id {userId} pole õige";
            }

            var result = await _userManager.ConfirmEmailAsync( userToConfirm, token );

            return userToConfirm;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> Login(LoginDto dto)
        {
            dto.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            var user = await _userManager.FindByEmailAsync(dto.Email);

            if ( user == null )
            {
                await Console.Out.WriteLineAsync("ConsoleMessage: Kasutajat ei leitud.");
                await Console.Out.WriteLineAsync("ConsoleMessage: User is null");
            }
            return user;
        }
    }
}
