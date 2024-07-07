namespace WebsiteGiay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ImageURL", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Size", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Size", c => c.String());
            AlterColumn("dbo.Products", "ImageURL", c => c.String());
        }
    }
}
