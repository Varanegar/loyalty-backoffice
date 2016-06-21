namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerGroupRemove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "CustomerGroupId", "dbo.CustomerGroups");
            DropIndex("dbo.Customers", new[] { "CustomerGroup_Id" });
            DropColumn("dbo.Customers", "CustomerGroup_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CustomerGroup_Id", c => c.Guid());
            CreateIndex("dbo.Customers", "CustomerGroup_Id");
            AddForeignKey("dbo.Customers", "CustomerGroupId", "dbo.CustomerGroups", "Id");
        }
    }
}
