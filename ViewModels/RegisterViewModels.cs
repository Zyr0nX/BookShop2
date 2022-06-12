using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    public class RegisterViewModels
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên đăng nhập")]
        public string Username { get; set; }
        
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự")]
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string ConfirmPassword { get; set; }
    }
}