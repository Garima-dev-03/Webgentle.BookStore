using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.BookStore.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Please enter the firstname")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please enter lastname")]
        public string Lastname { get; set; }

        [Required(ErrorMessage ="Please enter the email")]
        [Display(Name ="Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [Display(Name = "Password")]
        [Compare("ConfirmPassword",ErrorMessage ="Password does not match")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
