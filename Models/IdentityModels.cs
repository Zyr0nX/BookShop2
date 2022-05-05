using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShop.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
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
        public virtual DbSet<CategoryBook> CategoryBooks { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DetailOrder> DetailOrders { get; set; }
        public virtual DbSet<Information> Informations { get; set; }
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.DetailOrder)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Book>()
               .HasMany(e => e.DetailOrder)
               .WithRequired(e => e.Book)
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<Book>()
               .HasMany(e => e.CategoryBook)
               .WithRequired(e => e.Book)
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<Category>()
               .HasMany(e => e.CategoryBook)
               .WithRequired(e => e.Category)
               .WillCascadeOnDelete(true);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}