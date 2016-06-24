namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CardStatusMigration5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LoyaltyCards", "AssignDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LoyaltyCards", "AssignDate", c => c.Boolean(nullable: false));
        }
    }
}
