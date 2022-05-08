namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Author")]
    public partial class Author
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Author()
        {
            AuthorBooks = new HashSet<AuthorBook>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên tác giả.")]
        [StringLength(50)]
        [Display(Name = "Tên tác giả")]
        [Remote("IsExist", "Author", ErrorMessage = "{0} đã tồn tại")]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
    }
}