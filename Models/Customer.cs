namespace BookShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Customer")]
    public partial class Customer
    {
        public Customer()
        {
            Infomation = new HashSet<Information>();
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(500)]
        public string Password { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ tên")]
        public string Name { get; set; }

        [StringLength(10)]
        [Display(Name = "SĐT")]
        public string Sdt { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Ảnh")]
        public string Photo { get; set; }

        [StringLength(4)]
        [Display(Name = "Giới tính")]
        public string Gender { get; set; }

        public virtual ICollection<Information> Infomation { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
