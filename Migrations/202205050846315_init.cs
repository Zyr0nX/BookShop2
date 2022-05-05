namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Discount = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Photo = c.String(maxLength: 500),
                        Description = c.String(),
                        IdPublisher = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publisher", t => t.IdPublisher)
                .Index(t => t.IdPublisher);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetailOrder",
                c => new
                    {
                        IdOrder = c.Int(nullable: false),
                        IdBook = c.Int(nullable: false),
                        Amount = c.Int(),
                        Price = c.Int(),
                        TotalPrice = c.Int(),
                    })
                .PrimaryKey(t => new { t.IdOrder, t.IdBook })
                .ForeignKey("dbo.Orders", t => t.IdOrder)
                .ForeignKey("dbo.Books", t => t.IdBook)
                .Index(t => t.IdOrder)
                .Index(t => t.IdBook);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(maxLength: 100),
                        OrderDate = c.DateTime(),
                        ReceiveDate = c.DateTime(),
                        TotalPrice = c.Int(),
                        Note = c.String(),
                        Reason = c.String(maxLength: 255),
                        PaymentMethod = c.String(maxLength: 4),
                        IdVoucher = c.Int(),
                        IdState = c.Int(nullable: false),
                        IdCustomer = c.String(nullable: false, maxLength: 128),
                        IdInformation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Information", t => t.IdInformation)
                .ForeignKey("dbo.ApplicationUsers", t => t.IdCustomer)
                .ForeignKey("dbo.State", t => t.IdState)
                .ForeignKey("dbo.Voucher", t => t.IdVoucher)
                .Index(t => t.IdVoucher)
                .Index(t => t.IdState)
                .Index(t => t.IdCustomer)
                .Index(t => t.IdInformation);
            
            CreateTable(
                "dbo.Information",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Address = c.String(maxLength: 100),
                        Sdt = c.String(maxLength: 10),
                        Default = c.Boolean(),
                        IdCustomer = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.IdCustomer)
                .Index(t => t.IdCustomer);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Voucher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Discount = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(maxLength: 100),
                        Website = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photo = c.String(maxLength: 255),
                        State = c.String(maxLength: 10),
                        RefLink = c.String(maxLength: 255),
                        Stt = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryBook",
                c => new
                    {
                        IdBook = c.Int(nullable: false),
                        IdCategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdBook, t.IdCategory })
                .ForeignKey("dbo.Books", t => t.IdBook, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.IdCategory, cascadeDelete: true)
                .Index(t => t.IdBook)
                .Index(t => t.IdCategory);
            
            CreateTable(
                "dbo.AuthorBook",
                c => new
                    {
                        IdAuthor = c.Int(nullable: false),
                        IdBook = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdAuthor, t.IdBook })
                .ForeignKey("dbo.Authors", t => t.IdAuthor, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.IdBook, cascadeDelete: true)
                .Index(t => t.IdAuthor)
                .Index(t => t.IdBook);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.AuthorBook", "IdBook", "dbo.Books");
            DropForeignKey("dbo.AuthorBook", "IdAuthor", "dbo.Authors");
            DropForeignKey("dbo.Books", "IdPublisher", "dbo.Publisher");
            DropForeignKey("dbo.DetailOrder", "IdBook", "dbo.Books");
            DropForeignKey("dbo.Orders", "IdVoucher", "dbo.Voucher");
            DropForeignKey("dbo.Orders", "IdState", "dbo.State");
            DropForeignKey("dbo.Information", "IdCustomer", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Orders", "IdCustomer", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Orders", "IdInformation", "dbo.Information");
            DropForeignKey("dbo.DetailOrder", "IdOrder", "dbo.Orders");
            DropForeignKey("dbo.CategoryBook", "IdCategory", "dbo.Category");
            DropForeignKey("dbo.CategoryBook", "IdBook", "dbo.Books");
            DropIndex("dbo.AuthorBook", new[] { "IdBook" });
            DropIndex("dbo.AuthorBook", new[] { "IdAuthor" });
            DropIndex("dbo.CategoryBook", new[] { "IdCategory" });
            DropIndex("dbo.CategoryBook", new[] { "IdBook" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Information", new[] { "IdCustomer" });
            DropIndex("dbo.Orders", new[] { "IdInformation" });
            DropIndex("dbo.Orders", new[] { "IdCustomer" });
            DropIndex("dbo.Orders", new[] { "IdState" });
            DropIndex("dbo.Orders", new[] { "IdVoucher" });
            DropIndex("dbo.DetailOrder", new[] { "IdBook" });
            DropIndex("dbo.DetailOrder", new[] { "IdOrder" });
            DropIndex("dbo.Books", new[] { "IdPublisher" });
            DropTable("dbo.AuthorBook");
            DropTable("dbo.CategoryBook");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Banners");
            DropTable("dbo.Publisher");
            DropTable("dbo.Voucher");
            DropTable("dbo.State");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.Information");
            DropTable("dbo.Orders");
            DropTable("dbo.DetailOrder");
            DropTable("dbo.Category");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
