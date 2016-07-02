namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RuleActionNulable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoyaltyRuleActions", "LoyaltyTierId", "dbo.LoyaltyTiers");
            DropForeignKey("dbo.LoyaltyRuleActions", "LoyaltyValueTypeAttributeId", "dbo.LoyaltyValueTypeAttributes");
            DropIndex("dbo.LoyaltyRuleActions", new[] { "LoyaltyValueTypeAttributeId" });
            DropIndex("dbo.LoyaltyRuleActions", new[] { "LoyaltyTierId" });
            AlterColumn("dbo.LoyaltyRuleActions", "LoyaltyValueTypeAttributeId", c => c.Guid());
            AlterColumn("dbo.LoyaltyRuleActions", "LoyaltyTierId", c => c.Guid());
            CreateIndex("dbo.LoyaltyRuleActions", "LoyaltyValueTypeAttributeId");
            CreateIndex("dbo.LoyaltyRuleActions", "LoyaltyTierId");
            AddForeignKey("dbo.LoyaltyRuleActions", "LoyaltyTierId", "dbo.LoyaltyTiers", "Id");
            AddForeignKey("dbo.LoyaltyRuleActions", "LoyaltyValueTypeAttributeId", "dbo.LoyaltyValueTypeAttributes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoyaltyRuleActions", "LoyaltyValueTypeAttributeId", "dbo.LoyaltyValueTypeAttributes");
            DropForeignKey("dbo.LoyaltyRuleActions", "LoyaltyTierId", "dbo.LoyaltyTiers");
            DropIndex("dbo.LoyaltyRuleActions", new[] { "LoyaltyTierId" });
            DropIndex("dbo.LoyaltyRuleActions", new[] { "LoyaltyValueTypeAttributeId" });
            AlterColumn("dbo.LoyaltyRuleActions", "LoyaltyTierId", c => c.Guid(nullable: false));
            AlterColumn("dbo.LoyaltyRuleActions", "LoyaltyValueTypeAttributeId", c => c.Guid(nullable: false));
            CreateIndex("dbo.LoyaltyRuleActions", "LoyaltyTierId");
            CreateIndex("dbo.LoyaltyRuleActions", "LoyaltyValueTypeAttributeId");
            AddForeignKey("dbo.LoyaltyRuleActions", "LoyaltyValueTypeAttributeId", "dbo.LoyaltyValueTypeAttributes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoyaltyRuleActions", "LoyaltyTierId", "dbo.LoyaltyTiers", "Id", cascadeDelete: true);
        }
    }
}
