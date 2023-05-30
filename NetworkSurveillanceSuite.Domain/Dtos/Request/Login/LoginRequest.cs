using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace NetworkSurveillanceSuite.Domain.Dtos.Request.Login
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Email")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
