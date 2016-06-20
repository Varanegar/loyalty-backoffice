namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migratecustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "AnatoliAccountId", "dbo.AnatoliAccounts");
            DropIndex("dbo.Customers", new[] { "AnatoliAccountId" });
            RenameColumn(table: "dbo.Customers", name: "CustomerGroupId", newName: "CustomerGroup_Id");
            RenameIndex(table: "dbo.Customers", name: "IX_CustomerGroupId", newName: "IX_CustomerGroup_Id");
            CreateTable(
                "dbo.CustomerGroupCustomers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        CustomerGroupId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.CustomerGroups", t => t.CustomerGroupId, cascadeDelete: true)
                .ForeignKey("dbo.DataOwners", t => t.DataOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.DataOwnerCenters", t => t.DataOwnerCenterId, cascadeDelete: false)
                .ForeignKey("dbo.Principals", t => t.LastModifiedById)
                .Index(t => t.CustomerId)
                .Index(t => t.CustomerGroupId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            AddColumn("dbo.Customers", "CustomerType", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Gender", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "PBirthDay", c => c.String());
            AddColumn("dbo.Customers", "MarriageDate", c => c.DateTime());
            AddColumn("dbo.Customers", "PMarriageDate", c => c.String());
            AddColumn("dbo.Customers", "GraduateDate", c => c.DateTime());
            AddColumn("dbo.Customers", "PGraduateDate", c => c.String());
            AddColumn("dbo.Customers", "ReagentId", c => c.Guid(nullable: false));
            AddColumn("dbo.Customers", "GetNews", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "GetMessage", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "PostalCode", c => c.String());
            DropColumn("dbo.Customers", "CustomerCode");
            DropColumn("dbo.Customers", "AnatoliAccountId");
            DropColumn("dbo.Customers", "CustomerPoint");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CustomerPoint", c => c.Geometry());
            AddColumn("dbo.Customers", "AnatoliAccountId", c => c.Guid());
            AddColumn("dbo.Customers", "CustomerCode", c => c.Long());
            DropForeignKey("dbo.CustomerGroupCustomers", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.CustomerGroupCustomers", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.CustomerGroupCustomers", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.CustomerGroupCustomers", "CustomerGroupId", "dbo.CustomerGroups");
            DropForeignKey("dbo.CustomerGroupCustomers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerGroupCustomers", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.CustomerGroupCustomers", "AddedById", "dbo.Principals");
            DropIndex("dbo.CustomerGroupCustomers", new[] { "LastModifiedById" });
            DropIndex("dbo.CustomerGroupCustomers", new[] { "AddedById" });
            DropIndex("dbo.CustomerGroupCustomers", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.CustomerGroupCustomers", new[] { "DataOwnerId" });
            DropIndex("dbo.CustomerGroupCustomers", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.CustomerGroupCustomers", new[] { "CustomerGroupId" });
            DropIndex("dbo.CustomerGroupCustomers", new[] { "CustomerId" });
            AlterColumn("dbo.Customers", "PostalCode", c => c.String(maxLength: 20));
            DropColumn("dbo.Customers", "Status");
            DropColumn("dbo.Customers", "GetMessage");
            DropColumn("dbo.Customers", "GetNews");
            DropColumn("dbo.Customers", "ReagentId");
            DropColumn("dbo.Customers", "PGraduateDate");
            DropColumn("dbo.Customers", "GraduateDate");
            DropColumn("dbo.Customers", "PMarriageDate");
            DropColumn("dbo.Customers", "MarriageDate");
            DropColumn("dbo.Customers", "PBirthDay");
            DropColumn("dbo.Customers", "Gender");
            DropColumn("dbo.Customers", "CustomerType");
            DropTable("dbo.CustomerGroupCustomers");
            RenameIndex(table: "dbo.Customers", name: "IX_CustomerGroup_Id", newName: "IX_CustomerGroupId");
            RenameColumn(table: "dbo.Customers", name: "CustomerGroup_Id", newName: "CustomerGroupId");
            CreateIndex("dbo.Customers", "AnatoliAccountId");
            AddForeignKey("dbo.Customers", "AnatoliAccountId", "dbo.AnatoliAccounts", "Id");
        }
    }
}
