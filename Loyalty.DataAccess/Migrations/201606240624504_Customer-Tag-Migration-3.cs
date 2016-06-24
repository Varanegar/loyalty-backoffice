namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTagMigration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerTypeName = c.String(maxLength: 100),
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
            
            AddColumn("dbo.Customers", "CustomerTypeId", c => c.Guid());
            AddColumn("dbo.Customers", "CustomerTag_Id", c => c.Guid());
            AddColumn("dbo.CustomerTags", "TagName", c => c.String(maxLength: 200));
            AddColumn("dbo.CustomerTags", "ParentId", c => c.Guid());
            CreateIndex("dbo.Customers", "CustomerTypeId");
            CreateIndex("dbo.Customers", "CustomerTag_Id");
            CreateIndex("dbo.CustomerTags", "ParentId");
            AddForeignKey("dbo.Customers", "CustomerTag_Id", "dbo.CustomerTags", "Id");
            AddForeignKey("dbo.CustomerTags", "ParentId", "dbo.CustomerTags", "Id");
            AddForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes", "Id");
            DropColumn("dbo.Customers", "CustomerType");
            DropColumn("dbo.CustomerTags", "GroupName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerTags", "GroupName", c => c.String(maxLength: 200));
            AddColumn("dbo.Customers", "CustomerType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes");
            DropForeignKey("dbo.CustomerTypes", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.CustomerTypes", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.CustomerTypes", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.CustomerTypes", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.CustomerTypes", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.CustomerTags", "ParentId", "dbo.CustomerTags");
            DropForeignKey("dbo.Customers", "CustomerTag_Id", "dbo.CustomerTags");
            DropIndex("dbo.CustomerTypes", new[] { "LastModifiedById" });
            DropIndex("dbo.CustomerTypes", new[] { "AddedById" });
            DropIndex("dbo.CustomerTypes", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.CustomerTypes", new[] { "DataOwnerId" });
            DropIndex("dbo.CustomerTypes", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.CustomerTags", new[] { "ParentId" });
            DropIndex("dbo.Customers", new[] { "CustomerTag_Id" });
            DropIndex("dbo.Customers", new[] { "CustomerTypeId" });
            DropColumn("dbo.CustomerTags", "ParentId");
            DropColumn("dbo.CustomerTags", "TagName");
            DropColumn("dbo.Customers", "CustomerTag_Id");
            DropColumn("dbo.Customers", "CustomerTypeId");
            DropTable("dbo.CustomerTypes");
        }
    }
}
