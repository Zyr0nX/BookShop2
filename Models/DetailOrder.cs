namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetailOrder")]
    public partial class DetailOrder
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdOrder { get; set; }



        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdBook { get; set; }
        
        public int? Amount { get; set; }

        public int? Price { get; set; }
        public int? TotalPrice { get; set; }
        public virtual Book Book { get; set; }

        public virtual Order Order { get; set; }
    }
}
