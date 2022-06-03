namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdetailorder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DetailOrder", "Amount", c => c.Int(nullable: false));
            AlterColumn("dbo.DetailOrder", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.DetailOrder", "TotalPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DetailOrder", "TotalPrice", c => c.Int());
            AlterColumn("dbo.DetailOrder", "Price", c => c.Int());
            AlterColumn("dbo.DetailOrder", "Amount", c => c.Int());
        }
    }
}
