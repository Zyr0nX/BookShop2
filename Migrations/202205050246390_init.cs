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
                        IdAuthor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.IdAuthor, cascadeDelete: true)
                .ForeignKey("dbo.Publisher", t => t.IdPublisher, cascadeDelete: true)
                .Index(t => t.IdPublisher)
                .Index(t => t.IdAuthor);
            
            CreateTable(
                "dbo.CategoryBook",
                c => new
                    {
                        IdCategory = c.Int(nullable: false),
                        IdBook = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCategory, t.IdBook })
                .ForeignKey("dbo.Category", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Book_Id);
            
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
                        Order_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdOrder, t.IdBook })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Book_Id);
            
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
                        IdState = c.Int(),
                        IdCustomer = c.Int(),
                        IdInformation = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Information", t => t.IdInformation)
                .ForeignKey("dbo.Customer", t => t.IdCustomer)
                .ForeignKey("dbo.State", t => t.IdState)
                .ForeignKey("dbo.Voucher", t => t.IdVoucher)
                .Index(t => t.IdVoucher)
                .Index(t => t.IdState)
                .Index(t => t.IdCustomer)
                .Index(t => t.IdInformation);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        Password = c.String(maxLength: 500),
                        Name = c.String(maxLength: 50),
                        Sdt = c.String(maxLength: 10),
                        Email = c.String(maxLength: 50),
                        Photo = c.String(maxLength: 50),
                        Gender = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Information",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Address = c.String(maxLength: 100),
                        Sdt = c.String(maxLength: 10),
                        Default = c.Boolean(),
                        IdCustomer = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.IdCustomer)
                .Index(t => t.IdCustomer);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Books", "IdPublisher", "dbo.Publisher");
            DropForeignKey("dbo.DetailOrder", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Orders", "IdVoucher", "dbo.Voucher");
            DropForeignKey("dbo.Orders", "IdState", "dbo.State");
            DropForeignKey("dbo.DetailOrder", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "IdCustomer", "dbo.Customer");
            DropForeignKey("dbo.Orders", "IdInformation", "dbo.Information");
            DropForeignKey("dbo.Information", "IdCustomer", "dbo.Customer");
            DropForeignKey("dbo.CategoryBook", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.CategoryBook", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Books", "IdAuthor", "dbo.Authors");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Information", new[] { "IdCustomer" });
            DropIndex("dbo.Orders", new[] { "IdInformation" });
            DropIndex("dbo.Orders", new[] { "IdCustomer" });
            DropIndex("dbo.Orders", new[] { "IdState" });
            DropIndex("dbo.Orders", new[] { "IdVoucher" });
            DropIndex("dbo.DetailOrder", new[] { "Book_Id" });
            DropIndex("dbo.DetailOrder", new[] { "Order_Id" });
            DropIndex("dbo.CategoryBook", new[] { "Book_Id" });
            DropIndex("dbo.CategoryBook", new[] { "Category_Id" });
            DropIndex("dbo.Books", new[] { "IdAuthor" });
            DropIndex("dbo.Books", new[] { "IdPublisher" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Banners");
            DropTable("dbo.Publisher");
            DropTable("dbo.Voucher");
            DropTable("dbo.State");
            DropTable("dbo.Information");
            DropTable("dbo.Customer");
            DropTable("dbo.Orders");
            DropTable("dbo.DetailOrder");
            DropTable("dbo.Category");
            DropTable("dbo.CategoryBook");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
