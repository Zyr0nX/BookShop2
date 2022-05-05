namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Publisher")]
    public partial class Publisher
    {
        public Publisher()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên nhà xuất bản")]
        [StringLength(50)]
        [Display(Name = "Tên nhà xuất bản")]
        [Remote("IsExist", "Publisher", ErrorMessage = "{0} đã tồn tại")]
        public string Name { get; set; }

        [StringLength(100)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [StringLength(50)]

        public string Website { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
