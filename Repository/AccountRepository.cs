using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Repository
{
    public class AccountRepository :IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel signUpUserModel)
        {
            var user = new ApplicationUser()
            {
                Email = signUpUserModel.Email,
                UserName = signUpUserModel.Email
            };
           var result = await _userManager.CreateAsync(user, signUpUserModel.Password);
            return result;
        }
        public async Task<SignInResult> PasswordSignInAsync (SignInUserModel signInUserModel)
        {

           var result = await _signInManager.PasswordSignInAsync(signInUserModel.Email,signInUserModel.Password,false,false);
            return result;
        }
       public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
