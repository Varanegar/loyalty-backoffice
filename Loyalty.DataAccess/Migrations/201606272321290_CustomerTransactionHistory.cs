namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTransactionHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerTransactionHistories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        LoyaltyValueTypeId = c.Guid(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionPDate = c.String(maxLength: 10),
                        Description = c.String(maxLength: 500),
                        IncreaseValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DecreaseValue = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                .ForeignKey("dbo.DataOwners", t => t.DataOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.DataOwnerCenters", t => t.DataOwnerCenterId, cascadeDelete: false)
                .ForeignKey("dbo.Principals", t => t.LastModifiedById)
                .ForeignKey("dbo.LoyaltyValueTypes", t => t.LoyaltyValueTypeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.LoyaltyValueTypeId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerTransactionHistories", "LoyaltyValueTypeId", "dbo.LoyaltyValueTypes");
            DropForeignKey("dbo.CustomerTransactionHistories", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.CustomerTransactionHistories", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.CustomerTransactionHistories", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.CustomerTransactionHistories", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerTransactionHistories", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.CustomerTransactionHistories", "AddedById", "dbo.Principals");
            DropIndex("dbo.CustomerTransactionHistories", new[] { "LastModifiedById" });
            DropIndex("dbo.CustomerTransactionHistories", new[] { "AddedById" });
            DropIndex("dbo.CustomerTransactionHistories", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.CustomerTransactionHistories", new[] { "DataOwnerId" });
            DropIndex("dbo.CustomerTransactionHistories", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.CustomerTransactionHistories", new[] { "LoyaltyValueTypeId" });
            DropIndex("dbo.CustomerTransactionHistories", new[] { "CustomerId" });
            DropTable("dbo.CustomerTransactionHistories");
        }
    }
}
