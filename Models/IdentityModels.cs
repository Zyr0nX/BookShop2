using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ApplicationUser()
        {
            Orders = new HashSet<Order>();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DetailOrder> DetailOrders { get; set; }
        public virtual DbSet<Information> Information { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdCustomer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Author>()
                .HasMany(e => e.Books)
                .WithMany(e => e.Authors)
                .Map(m => m.ToTable("AuthorBook").MapLeftKey("IdAuthor").MapRightKey("IdBook"));

            modelBuilder.Entity<Book>()
                .HasMany(e => e.DetailOrders)
                .WithRequired(e => e.Book)
                .HasForeignKey(e => e.IdBook)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Categories)
                .WithMany(e => e.Books)
                .Map(m => m.ToTable("CategoryBook").MapLeftKey("IdBook").MapRightKey("IdCategory"));

            modelBuilder.Entity<Information>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Information)
                .HasForeignKey(e => e.IdInformation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.DetailOrders)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.IdOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Publisher>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Publisher)
                .HasForeignKey(e => e.IdPublisher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.State)
                .HasForeignKey(e => e.IdState)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Voucher>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Voucher)
                .HasForeignKey(e => e.IdVoucher);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}