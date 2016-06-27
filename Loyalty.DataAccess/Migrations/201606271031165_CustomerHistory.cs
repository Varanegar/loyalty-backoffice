namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerMonetaryHistories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionPDate = c.String(),
                        TransactionDesc = c.String(maxLength: 500),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PlaceDesc = c.String(maxLength: 500),
                        TerminalDesc = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
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
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.CustomerId)
                .Index(t => t.UserId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.CustomerNonMonetaryHistories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                        ActivityDate = c.DateTime(nullable: false),
                        ActivityPDate = c.String(),
                        ActivityDesc = c.String(maxLength: 500),
                        PlaceDesc = c.String(maxLength: 500),
                        TerminalDesc = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
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
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.CustomerId)
                .Index(t => t.UserId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerNonMonetaryHistories", "UserId", "dbo.Users");
            DropForeignKey("dbo.CustomerNonMonetaryHistories", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.CustomerNonMonetaryHistories", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.CustomerNonMonetaryHistories", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.CustomerNonMonetaryHistories", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerNonMonetaryHistories", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.CustomerNonMonetaryHistories", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.CustomerMonetaryHistories", "UserId", "dbo.Users");
            DropForeignKey("dbo.CustomerMonetaryHistories", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.CustomerMonetaryHistories", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.CustomerMonetaryHistories", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.CustomerMonetaryHistories", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerMonetaryHistories", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.CustomerMonetaryHistories", "AddedById", "dbo.Principals");
            DropIndex("dbo.CustomerNonMonetaryHistories", new[] { "LastModifiedById" });
            DropIndex("dbo.CustomerNonMonetaryHistories", new[] { "AddedById" });
            DropIndex("dbo.CustomerNonMonetaryHistories", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.CustomerNonMonetaryHistories", new[] { "DataOwnerId" });
            DropIndex("dbo.CustomerNonMonetaryHistories", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.CustomerNonMonetaryHistories", new[] { "UserId" });
            DropIndex("dbo.CustomerNonMonetaryHistories", new[] { "CustomerId" });
            DropIndex("dbo.CustomerMonetaryHistories", new[] { "LastModifiedById" });
            DropIndex("dbo.CustomerMonetaryHistories", new[] { "AddedById" });
            DropIndex("dbo.CustomerMonetaryHistories", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.CustomerMonetaryHistories", new[] { "DataOwnerId" });
            DropIndex("dbo.CustomerMonetaryHistories", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.CustomerMonetaryHistories", new[] { "UserId" });
            DropIndex("dbo.CustomerMonetaryHistories", new[] { "CustomerId" });
            DropTable("dbo.CustomerNonMonetaryHistories");
            DropTable("dbo.CustomerMonetaryHistories");
        }
    }
}
