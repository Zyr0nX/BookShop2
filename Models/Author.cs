using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookShop.Models
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên tác giả.")]
        [StringLength(50)]
        [Display(Name = "Tên tác giả")]
        [Remote("IsExist", "Author", ErrorMessage = "{0} đã tồn tại")]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}