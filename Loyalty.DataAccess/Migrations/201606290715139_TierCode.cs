namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TierCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoyaltyTiers", "TierCode", c => c.String(maxLength: 20));
            AlterColumn("dbo.UserGroups", "UserGroupCode", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserGroups", "UserGroupCode", c => c.String());
            DropColumn("dbo.LoyaltyTiers", "TierCode");
        }
    }
}
