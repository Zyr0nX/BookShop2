using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {

        public Book()
        {
            DetailOrders = new HashSet<DetailOrder>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Tên sách")]
        public string Name { get; set; }

        [Display(Name = "Giảm giá")]
        [Range(0, 100, ErrorMessage = ("{0} phải lớn hơn {1} và nhỏ hơn {2}"))]
        public int Discount { get; set; }

        [Display(Name = "Giá tiền")]
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = ("{0} phải lớn hơn {1}"))]
        public int Price { get; set; }

        [Display(Name = "Số lượng")]
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = ("{0} phải lớn hơn {1}"))]
        public int Amount { get; set; }

        [StringLength(500)]
        [Display(Name = "Ảnh")]
        public string Photo { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Nhà xuất bản")]
        [Required]
        public int? IdPublisher { get; set; }

        public virtual Publisher Publisher { get; set; }

        [Display(Name = "Tác giả")]
        [Required]
        public int? IdAuthor { get; set; }

        public virtual Author Author { get; set; }

        [Display(Name = "Thể loại")]
        [Required]
        public int? IdCategory { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailOrder> DetailOrders { get; set; }
    }
}