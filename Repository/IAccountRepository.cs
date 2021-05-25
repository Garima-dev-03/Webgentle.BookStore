using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Repository
{
   public interface IAccountRepository
    {
        public  Task<IdentityResult> CreateUserAsync(SignUpUserModel signUpUserModel);
        public Task<SignInResult> PasswordSignInAsync(SignInUserModel signInUserModel);
        public Task SignOutAsync();
    }
}
