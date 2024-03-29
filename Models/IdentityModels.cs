﻿using System.Data.Entity;
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

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.IdCustomer)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.DetailOrders)
                .WithRequired(e => e.Book)
                .HasForeignKey(e => e.IdBook)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Information>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Information)
                .HasForeignKey(e => e.IdInformation)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.DetailOrders)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.IdOrder)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Publisher>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Publisher)
                .HasForeignKey(e => e.IdPublisher)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Author>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Author)
                .HasForeignKey(e => e.IdAuthor)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.IdCategory)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.State)
                .HasForeignKey(e => e.IdState)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Voucher>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Voucher)
                .HasForeignKey(e => e.IdVoucher)
                .WillCascadeOnDelete(true);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}