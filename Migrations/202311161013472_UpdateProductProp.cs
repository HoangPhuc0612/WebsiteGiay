namespace WebsiteGiay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "favorite", c => c.Int(nullable: false,defaultValue:0));
            AlterColumn("dbo.Products", "Size", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Size", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "favorite");
        }
    }
}
