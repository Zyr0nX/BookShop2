namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascadedelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Book", "IdAuthor", "dbo.Author");
            DropForeignKey("dbo.Book", "IdCategory", "dbo.Category");
            DropForeignKey("dbo.DetailOrder", "IdBook", "dbo.Book");
            DropForeignKey("dbo.Book", "IdPublisher", "dbo.Publisher");
            DropForeignKey("dbo.DetailOrder", "IdOrder", "dbo.Orders");
            DropForeignKey("dbo.Orders", "IdCustomer", "dbo.Customer");
            DropForeignKey("dbo.Orders", "IdInformation", "dbo.Information");
            DropForeignKey("dbo.Orders", "IdState", "dbo.State");
            DropForeignKey("dbo.Orders", "IdVoucher", "dbo.Voucher");
            AddForeignKey("dbo.Book", "IdAuthor", "dbo.Author", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Book", "IdCategory", "dbo.Category", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DetailOrder", "IdBook", "dbo.Book", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Book", "IdPublisher", "dbo.Publisher", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DetailOrder", "IdOrder", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "IdCustomer", "dbo.Customer", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "IdInformation", "dbo.Information", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "IdState", "dbo.State", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "IdVoucher", "dbo.Voucher", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "IdVoucher", "dbo.Voucher");
            DropForeignKey("dbo.Orders", "IdState", "dbo.State");
            DropForeignKey("dbo.Orders", "IdInformation", "dbo.Information");
            DropForeignKey("dbo.Orders", "IdCustomer", "dbo.Customer");
            DropForeignKey("dbo.DetailOrder", "IdOrder", "dbo.Orders");
            DropForeignKey("dbo.Book", "IdPublisher", "dbo.Publisher");
            DropForeignKey("dbo.DetailOrder", "IdBook", "dbo.Book");
            DropForeignKey("dbo.Book", "IdCategory", "dbo.Category");
            DropForeignKey("dbo.Book", "IdAuthor", "dbo.Author");
            AddForeignKey("dbo.Orders", "IdVoucher", "dbo.Voucher", "Id");
            AddForeignKey("dbo.Orders", "IdState", "dbo.State", "Id");
            AddForeignKey("dbo.Orders", "IdInformation", "dbo.Information", "Id");
            AddForeignKey("dbo.Orders", "IdCustomer", "dbo.Customer", "Id");
            AddForeignKey("dbo.DetailOrder", "IdOrder", "dbo.Orders", "Id");
            AddForeignKey("dbo.Book", "IdPublisher", "dbo.Publisher", "Id");
            AddForeignKey("dbo.DetailOrder", "IdBook", "dbo.Book", "Id");
            AddForeignKey("dbo.Book", "IdCategory", "dbo.Category", "Id");
            AddForeignKey("dbo.Book", "IdAuthor", "dbo.Author", "Id");
        }
    }
}
