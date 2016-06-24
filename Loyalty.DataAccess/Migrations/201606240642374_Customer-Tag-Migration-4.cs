namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTagMigration4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GroupName = c.String(maxLength: 200),
                        NLeft = c.Int(nullable: false),
                        NRight = c.Int(nullable: false),
                        NLevel = c.Int(nullable: false),
                        Priority = c.Int(),
                        ParentId = c.Guid(),
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
                .ForeignKey("dbo.Principals", t => t.AddedById, false, "FK_dbo.CustomerGroups_dbo.Principals_AddedById2")
                .ForeignKey("dbo.ApplicationOwners", t => t.ApplicationOwnerId, cascadeDelete: false, name: "FK_dbo.CustomerGroups_dbo.ApplicationOwners_ApplicationOwnerId2")
                .ForeignKey("dbo.CustomerGroups", t => t.ParentId)
                .ForeignKey("dbo.DataOwners", t => t.DataOwnerId, cascadeDelete: false, name: "FK_dbo.CustomerGroups_dbo.DataOwners_DataOwnerId2")
                .ForeignKey("dbo.DataOwnerCenters", t => t.DataOwnerCenterId, cascadeDelete: false, name: "FK_dbo.CustomerGroups_dbo.DataOwnerCenters_DataOwnerCenterId2")
                .ForeignKey("dbo.Principals", t => t.LastModifiedById, false, "FK_dbo.CustomerGroups_dbo.Principals_LastModifiedById2")
                .Index(t => t.ParentId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            AddColumn("dbo.Customers", "CustomerGroupId", c => c.Guid());
            CreateIndex("dbo.Customers", "CustomerGroupId");
            AddForeignKey("dbo.Customers", "CustomerGroupId", "dbo.CustomerGroups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "CustomerGroupId", "dbo.CustomerGroups");
            DropForeignKey("dbo.CustomerGroups", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.CustomerGroups", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.CustomerGroups", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.CustomerGroups", "ParentId", "dbo.CustomerGroups");
            DropForeignKey("dbo.CustomerGroups", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.CustomerGroups", "AddedById", "dbo.Principals");
            DropIndex("dbo.CustomerGroups", new[] { "LastModifiedById" });
            DropIndex("dbo.CustomerGroups", new[] { "AddedById" });
            DropIndex("dbo.CustomerGroups", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.CustomerGroups", new[] { "DataOwnerId" });
            DropIndex("dbo.CustomerGroups", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.CustomerGroups", new[] { "ParentId" });
            DropIndex("dbo.Customers", new[] { "CustomerGroupId" });
            DropColumn("dbo.Customers", "CustomerGroupId");
            DropTable("dbo.CustomerGroups");
        }
    }
}
