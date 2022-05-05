using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookShop.Models
{
    public partial class Banner
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Display(Name = "Ảnh")]
        public string Photo { get; set; }

        [StringLength(10)]
        [Display(Name = "Trạng thái")]
        public string State { get; set; }

        [StringLength(255)]
        [Display(Name = "Đường dẫn")]
        public string RefLink { get; set; }

        [Display(Name = "Số thứ tự")]
        public int? Stt { get; set; }
    }
}