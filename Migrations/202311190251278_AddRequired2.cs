namespace WebsiteGiay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequired2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Gender", c => c.String());
            AlterColumn("dbo.Products", "Status", c => c.String());
        }
    }
}
