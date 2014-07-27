using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Security.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng điền địa chỉ email.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng điền mật khẩu.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Duy trì đăng nhập?")]
        public bool RememberMe { get; set; }
    }
}