namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CardMigration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LoyaltyCards", "ExpireDate", c => c.DateTime());
            AlterColumn("dbo.LoyaltyCards", "AssignDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LoyaltyCards", "AssignDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LoyaltyCards", "ExpireDate", c => c.DateTime(nullable: false));
        }
    }
}
