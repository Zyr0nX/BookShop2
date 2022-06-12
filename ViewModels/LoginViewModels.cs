using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    public class LoginViewModels
    {
        [Key]
        [Required(ErrorMessage = "Bạn phải nhập tên đăng nhập")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string Password { get; set; }
    }
}