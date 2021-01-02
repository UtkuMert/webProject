using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.webUI.Models
{
    public class RegisterModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")] //password ile kontrol edip eslestirme yapicak
        public string RePassword { get; set; }

        [Required(ErrorMessage ="Deneme")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
