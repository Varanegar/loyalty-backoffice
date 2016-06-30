namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProgramGroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoyaltyValueTypeAttributes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyValueTypeAttributeCode = c.String(maxLength: 20),
                        LoyaltyValueTypeAttributeName = c.String(maxLength: 100),
                        LoyaltyValueTypeId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.LoyaltyValueTypes", t => t.LoyaltyValueTypeId, cascadeDelete: true)
                .Index(t => t.LoyaltyValueTypeId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.LoyaltyProgramGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyProgramGroupCode = c.String(maxLength: 20),
                        LoyaltyProgramGroupName = c.String(maxLength: 100),
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
            
            AddColumn("dbo.LoyaltyPrograms", "LoyaltyProgramGroupId", c => c.Guid(nullable: false));
            CreateIndex("dbo.LoyaltyPrograms", "LoyaltyProgramGroupId");
            AddForeignKey("dbo.LoyaltyPrograms", "LoyaltyProgramGroupId", "dbo.LoyaltyProgramGroups", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoyaltyPrograms", "LoyaltyProgramGroupId", "dbo.LoyaltyProgramGroups");
            DropForeignKey("dbo.LoyaltyProgramGroups", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyProgramGroups", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyProgramGroups", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyProgramGroups", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyProgramGroups", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyValueTypeAttributes", "LoyaltyValueTypeId", "dbo.LoyaltyValueTypes");
            DropForeignKey("dbo.LoyaltyValueTypeAttributes", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyValueTypeAttributes", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyValueTypeAttributes", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyValueTypeAttributes", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyValueTypeAttributes", "AddedById", "dbo.Principals");
            DropIndex("dbo.LoyaltyProgramGroups", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyProgramGroups", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyProgramGroups", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyProgramGroups", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyProgramGroups", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyPrograms", new[] { "LoyaltyProgramGroupId" });
            DropIndex("dbo.LoyaltyValueTypeAttributes", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyValueTypeAttributes", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyValueTypeAttributes", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyValueTypeAttributes", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyValueTypeAttributes", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyValueTypeAttributes", new[] { "LoyaltyValueTypeId" });
            DropColumn("dbo.LoyaltyPrograms", "LoyaltyProgramGroupId");
            DropTable("dbo.LoyaltyProgramGroups");
            DropTable("dbo.LoyaltyValueTypeAttributes");
        }
    }
}
