using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public partial class Book
    {
        public Book()
        {
            DetailOrder = new HashSet<DetailOrder>();
            CategoryBook = new HashSet<CategoryBook>();
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
        public int? Price { get; set; }


        [Display(Name = "Số lượng")]
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = ("{0} phải lớn hơn {1}"))]
        public int? Amount { get; set; }


        [StringLength(500)]
        [Display(Name = "Ảnh")]

        public string Photo { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }


        [Display(Name = "Nhà xuất bản")]
        [Required]
        public int? IdPublisher { get; set; }
        [ForeignKey("IdPublisher")]
        public virtual Publisher Publisher { get; set; }

        public virtual ICollection<CategoryBook> CategoryBook { get; set; }



        [Display(Name = "Tác giả")]
        [Required]
        public int? IdAuthor { get; set; }
        [ForeignKey("IdAuthor")]

        public virtual Author Author { get; set; }

        public virtual ICollection<DetailOrder> DetailOrder { get; set; }
    }
}