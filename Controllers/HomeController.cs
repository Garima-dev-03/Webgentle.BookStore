using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using Webgentle.BookStore.Models;
using Webgentle.BookStore.Service;

namespace Webgentle.BookStore.Controllers
{
    public class HomeController:Controller
    {
        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;

        }

        public IUserService UserService { get; }

        public ViewResult Index()
        {
            var userId = _userService.GetUserId();
            var _isLoggedIn = _userService.IsAuthenticated();
            return View();
        }

        
    }
}
