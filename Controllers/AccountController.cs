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
        private readonly ISignUpRepository _signUpRepository;
        public AccountController(ISignUpRepository signUpRepository)
        {
            _signUpRepository = signUpRepository;
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
                var result = await _signUpRepository.CreateUserAsync(signUpUserModel);
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
    }
}
