namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserGroup1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserGroupCode = c.Int(nullable: false),
                        UserGroupName = c.String(maxLength: 100),
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
            
            CreateTable(
                "dbo.UserGroupUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                        UserGroupId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.UserGroups", t => t.UserGroupId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.UserGroupId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGroupUsers", "UserGroupId", "dbo.UserGroups");
            DropForeignKey("dbo.UserGroupUsers", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserGroupUsers", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.UserGroupUsers", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.UserGroupUsers", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.UserGroupUsers", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.UserGroupUsers", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.UserGroups", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.UserGroups", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.UserGroups", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.UserGroups", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.UserGroups", "AddedById", "dbo.Principals");
            DropIndex("dbo.UserGroupUsers", new[] { "LastModifiedById" });
            DropIndex("dbo.UserGroupUsers", new[] { "AddedById" });
            DropIndex("dbo.UserGroupUsers", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.UserGroupUsers", new[] { "DataOwnerId" });
            DropIndex("dbo.UserGroupUsers", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.UserGroupUsers", new[] { "UserGroupId" });
            DropIndex("dbo.UserGroupUsers", new[] { "UserId" });
            DropIndex("dbo.UserGroups", new[] { "LastModifiedById" });
            DropIndex("dbo.UserGroups", new[] { "AddedById" });
            DropIndex("dbo.UserGroups", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.UserGroups", new[] { "DataOwnerId" });
            DropIndex("dbo.UserGroups", new[] { "ApplicationOwnerId" });
            DropTable("dbo.UserGroupUsers");
            DropTable("dbo.UserGroups");
        }
    }
}
