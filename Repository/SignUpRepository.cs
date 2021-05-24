using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Repository
{
    public class SignUpRepository :ISignUpRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        public SignUpRepository(UserManager<IdentityUser> userManager )
        {
            _userManager = userManager;

        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel signUpUserModel)
        {
            var user = new IdentityUser()
            {
                Email = signUpUserModel.Email,
                UserName = signUpUserModel.Email
            };
           var result = await _userManager.CreateAsync(user, signUpUserModel.Password);
            return result;
        }
       
    }
}
