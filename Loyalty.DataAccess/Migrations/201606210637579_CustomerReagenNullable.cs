namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerReagenNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "ReagentId", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "ReagentId", c => c.Guid(nullable: false));
        }
    }
}
