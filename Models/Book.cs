using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public partial class Book
    {
        public Book()
        {
            DetailOrders = new HashSet<DetailOrder>();
            Authors = new HashSet<Author>();
            Categories = new HashSet<Category>();
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
        public int IdPublisher { get; set; }
        [ForeignKey("IdPublisher")]
        public virtual Publisher Publisher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailOrder> DetailOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Author> Authors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories { get; set; }
    }
}