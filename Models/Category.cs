    namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            CategoryBook = new HashSet<CategoryBook>();
        }

        [Key]
        [Display(Name = "Mã thể loại")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên thể loại.")]
        [StringLength(50)]
        [Display(Name = "Thể loại")]
        [Remote("IsExist", "Category", ErrorMessage = "{0} đã tồn tại")]
        public string Name { get; set; }

        public virtual ICollection<CategoryBook> CategoryBook { get; set; }
    }
}
