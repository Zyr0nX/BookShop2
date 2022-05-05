namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Voucher")]
    public partial class Voucher
    {
        public Voucher()
        {
            Order = new HashSet<Order>();
        }


        public int Id { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập mã voucher")]
        [Display(Name = "Mã voucher")]
        [StringLength(50)]
        [Remote("IsExist", "Voucher", ErrorMessage = "{0} đã tồn tại")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập phần trăm giảm")]
        [Display(Name = "Phần trăm giảm")]
        [Range(1,100,ErrorMessage = "Vui lòng nhập giá trị từ 1 - 100")]



        public int Discount { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày bắt đầu")]
        [Display(Name = "Ngày bắt đầu")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}",ApplyFormatInEditMode = true)]


        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày kết thúc")]
        [Display(Name = "Ngày kết thúc")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
