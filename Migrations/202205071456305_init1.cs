namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AuthorBook", "IdAuthor", "dbo.Author");
            DropForeignKey("dbo.AuthorBook", "IdBook", "dbo.Book");
            AddForeignKey("dbo.AuthorBook", "IdAuthor", "dbo.Author", "Id");
            AddForeignKey("dbo.AuthorBook", "IdBook", "dbo.Book", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuthorBook", "IdBook", "dbo.Book");
            DropForeignKey("dbo.AuthorBook", "IdAuthor", "dbo.Author");
            AddForeignKey("dbo.AuthorBook", "IdBook", "dbo.Book", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AuthorBook", "IdAuthor", "dbo.Author", "Id", cascadeDelete: true);
        }
    }
}
