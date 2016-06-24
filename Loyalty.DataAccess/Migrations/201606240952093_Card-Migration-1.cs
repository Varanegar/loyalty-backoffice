namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CardMigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoyaltyCardSetGenerateTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyCardSetGenerateTypeName = c.String(maxLength: 100),
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
            
            AddColumn("dbo.LoyaltyCardSets", "LoyaltyCardSetGenerateTypeId", c => c.Guid(nullable: false));
            CreateIndex("dbo.LoyaltyCardSets", "LoyaltyCardSetGenerateTypeId");
            AddForeignKey("dbo.LoyaltyCardSets", "LoyaltyCardSetGenerateTypeId", "dbo.LoyaltyCardSetGenerateTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.LoyaltyCardSets", "GenerateNoType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoyaltyCardSets", "GenerateNoType", c => c.Guid(nullable: false));
            DropForeignKey("dbo.LoyaltyCardSets", "LoyaltyCardSetGenerateTypeId", "dbo.LoyaltyCardSetGenerateTypes");
            DropForeignKey("dbo.LoyaltyCardSetGenerateTypes", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyCardSetGenerateTypes", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyCardSetGenerateTypes", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyCardSetGenerateTypes", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyCardSetGenerateTypes", "AddedById", "dbo.Principals");
            DropIndex("dbo.LoyaltyCardSetGenerateTypes", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyCardSetGenerateTypes", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyCardSetGenerateTypes", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyCardSetGenerateTypes", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyCardSetGenerateTypes", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyCardSets", new[] { "LoyaltyCardSetGenerateTypeId" });
            DropColumn("dbo.LoyaltyCardSets", "LoyaltyCardSetGenerateTypeId");
            DropTable("dbo.LoyaltyCardSetGenerateTypes");
        }
    }
}
