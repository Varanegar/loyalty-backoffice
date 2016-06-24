namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerCodeMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CustomerCode", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "CustomerCode");
        }
    }
}
