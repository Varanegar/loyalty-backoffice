namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTagMigration1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CustomerGroupCustomers", newName: "CustomerTagCustomers");
            RenameTable(name: "dbo.CustomerGroups", newName: "CustomerTags");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CustomerTags", newName: "CustomerGroups");
            RenameTable(name: "dbo.CustomerTagCustomers", newName: "CustomerGroupCustomers");
        }
    }
}
