using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.ViewModels
{
    public class RegisterViewModel
    {
        //[Required]
        //[Display(Name = "Email")]
        //public string Email { get; set; }

        [Required]
        [Display(Name = "Логін")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        [DataType(DataType.Password)]
        [Display(Name =  "Підтвердити пароль")]
        public string ConfirmPassword { get; set; }
      
        public string ReturnUrl { get; set; }
    }
}
