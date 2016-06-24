namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CardStatusMigration4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoyaltyCardStatus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyCardStatusName = c.String(maxLength: 100),
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
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            AddColumn("dbo.LoyaltyCards", "LoyaltyCardStatusId", c => c.Guid(nullable: false));
            CreateIndex("dbo.LoyaltyCards", "LoyaltyCardStatusId");
            AddForeignKey("dbo.LoyaltyCards", "LoyaltyCardStatusId", "dbo.LoyaltyCardStatus", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoyaltyCards", "LoyaltyCardStatusId", "dbo.LoyaltyCardStatus");
            DropForeignKey("dbo.LoyaltyCardStatus", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyCardStatus", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyCardStatus", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyCardStatus", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyCardStatus", "AddedById", "dbo.Principals");
            DropIndex("dbo.LoyaltyCardStatus", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyCardStatus", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyCardStatus", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyCardStatus", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyCardStatus", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyCards", new[] { "LoyaltyCardStatusId" });
            DropColumn("dbo.LoyaltyCards", "LoyaltyCardStatusId");
            DropTable("dbo.LoyaltyCardStatus");
        }
    }
}
