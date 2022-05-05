namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            DetailOrders = new HashSet<DetailOrder>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Address { get; set; }
        [Display(Name = "Ngày đặt")]
        public DateTime? OrderDate { get; set; }

        public DateTime? ReceiveDate { get; set; }
        [Display(Name = "Tổng tiền")]
        public int? TotalPrice { get; set; }

        public string Note { get; set; }

        [StringLength(255)]
        public string Reason { get; set; }

        [StringLength(4)]
        [Display(Name = "Thanh toán")]
        public string PaymentMethod { get; set; }

        public int? IdVoucher { get; set; }

        public int IdState { get; set; }

        [Required]
        [StringLength(128)]
        public string IdCustomer { get; set; }

        public int IdInformation { get; set; }

        public virtual ApplicationUser User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailOrder> DetailOrders { get; set; }

        public virtual Information Information { get; set; }
        public virtual State State { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}
