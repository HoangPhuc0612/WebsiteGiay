namespace WebsiteGiay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveFavorite : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "favorite");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "favorite", c => c.Int(nullable: false));
        }
    }
}
