using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webgentle.BookStore.Models;
using Webgentle.BookStore.Repository;

namespace Webgentle.BookStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _AccountRepository;
        
        public AccountController(IAccountRepository signUpRepository)
        {
            _AccountRepository = signUpRepository;
        }
        public ViewResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserModel signUpUserModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _AccountRepository.CreateUserAsync(signUpUserModel);
                if(!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View(signUpUserModel);
                }
                ModelState.Clear();
            }
            return View();
        }
        public ViewResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInUserModel signInUserModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _AccountRepository.PasswordSignInAsync(signInUserModel);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "home");
                }
                ModelState.AddModelError("", "Credentials are not correct");
                
            }
            return View(signInUserModel);
        }
        public async Task<IActionResult> Logout()
        {
            await _AccountRepository.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}
