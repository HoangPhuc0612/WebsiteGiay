namespace WebsiteGiay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ImageURL", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ImageURL", c => c.String(nullable: false));
        }
    }
}
