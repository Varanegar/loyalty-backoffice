namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Trigger : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoyaltyTriggers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyTriggerCode = c.String(maxLength: 20),
                        LoyaltyTriggerName = c.String(maxLength: 100),
                        LoyaltyTriggerTypeId = c.Guid(nullable: false),
                        Number_ID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                        ApplicationOwnerId = c.Guid(nullable: false),
                        DataOwnerId = c.Guid(nullable: false),
                        DataOwnerCenterId = c.Guid(nullable: false),
                        AddedById = c.Guid(),
                        LastModifiedById = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Principals", t => t.AddedById)
                .ForeignKey("dbo.ApplicationOwners", t => t.ApplicationOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.DataOwners", t => t.DataOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.DataOwnerCenters", t => t.DataOwnerCenterId, cascadeDelete: false)
                .ForeignKey("dbo.Principals", t => t.LastModifiedById)
                .ForeignKey("dbo.LoyaltyTriggerTypes", t => t.LoyaltyTriggerTypeId, cascadeDelete: true)
                .Index(t => t.LoyaltyTriggerTypeId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            AddColumn("dbo.LoyaltyTriggerTypes", "LoyaltyTriggerTypeCode", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoyaltyTriggers", "LoyaltyTriggerTypeId", "dbo.LoyaltyTriggerTypes");
            DropForeignKey("dbo.LoyaltyTriggers", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyTriggers", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyTriggers", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyTriggers", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyTriggers", "AddedById", "dbo.Principals");
            DropIndex("dbo.LoyaltyTriggers", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyTriggers", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyTriggers", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyTriggers", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyTriggers", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyTriggers", new[] { "LoyaltyTriggerTypeId" });
            DropColumn("dbo.LoyaltyTriggerTypes", "LoyaltyTriggerTypeCode");
            DropTable("dbo.LoyaltyTriggers");
        }
    }
}
