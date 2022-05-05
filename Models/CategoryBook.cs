namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("CategoryBook")]
    public partial class CategoryBook
    {
        [Key]
        [Display(Name = "Mã thể loại")]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCategory { get; set; }

        public virtual Category Category { get; set; }

        [Key]
        [Display(Name = "Mã sách")]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdBook { get; set; }

        public virtual Book Book { get; set; }
    }
}
