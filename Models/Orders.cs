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
            DetailOrder = new HashSet<DetailOrder>();
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
        [ForeignKey("IdVoucher")]
        public virtual Voucher Voucher { get; set; }

        public int? IdState { get; set; }
        [ForeignKey("IdState")]
        public virtual State State { get; set; }

        public int? IdCustomer { get; set; }
        [ForeignKey("IdCustomer")]
        public virtual Customer Customer { get; set; }

        public int? IdInformation { get; set; }
        [ForeignKey("IdInformation")]
        public virtual Information Information { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailOrder> DetailOrder { get; set; }

        

        

        
    }
}
