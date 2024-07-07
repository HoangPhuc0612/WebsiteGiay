namespace WebsiteGiay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShoppingCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.String(maxLength: 128),
                        Soluong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "ProductId", "dbo.Products");
            DropIndex("dbo.ShoppingCarts", new[] { "ProductId" });
            DropTable("dbo.ShoppingCarts");
        }
    }
}
