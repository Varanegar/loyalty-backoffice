namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTagMigration2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CustomerTagCustomers", name: "CustomerGroupId", newName: "CustomerTagId");
            RenameIndex(table: "dbo.CustomerTagCustomers", name: "IX_CustomerGroupId", newName: "IX_CustomerTagId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CustomerTagCustomers", name: "IX_CustomerTagId", newName: "IX_CustomerGroupId");
            RenameColumn(table: "dbo.CustomerTagCustomers", name: "CustomerTagId", newName: "CustomerGroupId");
        }
    }
}
