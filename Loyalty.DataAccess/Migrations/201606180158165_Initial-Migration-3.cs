namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ProductType_Id", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "ProductType_Id" });
            RenameColumn(table: "dbo.Products", name: "ProductType_Id", newName: "ProductTypeId");
            AlterColumn("dbo.Products", "ProductTypeId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Products", "ProductTypeId");
            AddForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "ProductTypeId" });
            AlterColumn("dbo.Products", "ProductTypeId", c => c.Guid());
            RenameColumn(table: "dbo.Products", name: "ProductTypeId", newName: "ProductType_Id");
            CreateIndex("dbo.Products", "ProductType_Id");
            AddForeignKey("dbo.Products", "ProductType_Id", "dbo.ProductTypes", "Id");
        }
    }
}
