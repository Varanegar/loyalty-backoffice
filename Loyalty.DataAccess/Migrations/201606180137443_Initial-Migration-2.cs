namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BaseTypeDesc = c.String(maxLength: 500),
                        BaseTypeName = c.String(maxLength: 100),
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
                "dbo.BaseValues",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BaseValueName = c.String(maxLength: 200),
                        BaseTypeId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.BaseTypes", t => t.BaseTypeId, cascadeDelete: true)
                .ForeignKey("dbo.DataOwners", t => t.DataOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.DataOwnerCenters", t => t.DataOwnerCenterId, cascadeDelete: false)
                .ForeignKey("dbo.Principals", t => t.LastModifiedById)
                .Index(t => t.BaseTypeId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.CityRegions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GroupName = c.String(),
                        NLeft = c.Int(nullable: false),
                        NRight = c.Int(nullable: false),
                        NLevel = c.Int(nullable: false),
                        Priority = c.Int(),
                        CityRegion2Id = c.Guid(),
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
                .ForeignKey("dbo.CityRegions", t => t.CityRegion2Id)
                .ForeignKey("dbo.DataOwners", t => t.DataOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.DataOwnerCenters", t => t.DataOwnerCenterId, cascadeDelete: false)
                .ForeignKey("dbo.Principals", t => t.LastModifiedById)
                .Index(t => t.CityRegion2Id)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        RegionInfoId = c.Guid(),
                        RegionLevel1Id = c.Guid(),
                        RegionLevel2Id = c.Guid(),
                        RegionLevel3Id = c.Guid(),
                        RegionLevel4Id = c.Guid(),
                        Id = c.Guid(nullable: false),
                        CustomerCode = c.Long(),
                        CustomerName = c.String(maxLength: 200),
                        FirstName = c.String(maxLength: 200),
                        LastName = c.String(maxLength: 200),
                        BirthDay = c.DateTime(),
                        Phone = c.String(maxLength: 20),
                        Mobile = c.String(maxLength: 20),
                        Email = c.String(maxLength: 500),
                        MainStreet = c.String(maxLength: 500),
                        OtherStreet = c.String(maxLength: 500),
                        PostalCode = c.String(maxLength: 20),
                        NationalCode = c.String(maxLength: 20),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        CustomerGroupId = c.Guid(),
                        LoyaltyTierId = c.Guid(),
                        CompanyId = c.Guid(nullable: false),
                        AnatoliAccountId = c.Guid(),
                        CustomerPoint = c.Geometry(),
                        Number_ID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                        ApplicationOwnerId = c.Guid(nullable: false),
                        DataOwnerId = c.Guid(nullable: false),
                        DataOwnerCenterId = c.Guid(nullable: false),
                        AddedById = c.Guid(),
                        LastModifiedById = c.Guid(),
                        CityRegion_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Principals", t => t.AddedById)
                .ForeignKey("dbo.AnatoliAccounts", t => t.AnatoliAccountId)
                .ForeignKey("dbo.ApplicationOwners", t => t.ApplicationOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.CustomerGroups", t => t.CustomerGroupId)
                .ForeignKey("dbo.DataOwners", t => t.DataOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.DataOwnerCenters", t => t.DataOwnerCenterId, cascadeDelete: false)
                .ForeignKey("dbo.Principals", t => t.LastModifiedById)
                .ForeignKey("dbo.LoyaltyTiers", t => t.LoyaltyTierId)
                .ForeignKey("dbo.CityRegions", t => t.RegionInfoId)
                .ForeignKey("dbo.CityRegions", t => t.RegionLevel1Id)
                .ForeignKey("dbo.CityRegions", t => t.RegionLevel2Id)
                .ForeignKey("dbo.CityRegions", t => t.RegionLevel3Id)
                .ForeignKey("dbo.CityRegions", t => t.RegionLevel4Id)
                .ForeignKey("dbo.CityRegions", t => t.CityRegion_Id)
                .Index(t => t.RegionInfoId)
                .Index(t => t.RegionLevel1Id)
                .Index(t => t.RegionLevel2Id)
                .Index(t => t.RegionLevel3Id)
                .Index(t => t.RegionLevel4Id)
                .Index(t => t.CustomerGroupId)
                .Index(t => t.LoyaltyTierId)
                .Index(t => t.CompanyId)
                .Index(t => t.AnatoliAccountId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById)
                .Index(t => t.CityRegion_Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CompanyCode = c.Int(nullable: false),
                        CompanyName = c.String(maxLength: 100),
                        AnatoliAccountId = c.Guid(),
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
                .ForeignKey("dbo.AnatoliAccounts", t => t.AnatoliAccountId)
                .ForeignKey("dbo.ApplicationOwners", t => t.ApplicationOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.DataOwners", t => t.DataOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.DataOwnerCenters", t => t.DataOwnerCenterId, cascadeDelete: false)
                .ForeignKey("dbo.Principals", t => t.LastModifiedById)
                .Index(t => t.AnatoliAccountId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.CompanyCenters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NLeft = c.Int(nullable: false),
                        NRight = c.Int(nullable: false),
                        NLevel = c.Int(nullable: false),
                        Priority = c.Int(),
                        CenterCode = c.Int(nullable: false),
                        CenterName = c.String(maxLength: 100),
                        Address = c.String(maxLength: 200),
                        Phone = c.String(maxLength: 200),
                        Lat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Lng = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CenterTypeId = c.Guid(nullable: false),
                        ParentId = c.Guid(),
                        SupportAppOrder = c.Boolean(nullable: false),
                        SupportWebOrder = c.Boolean(nullable: false),
                        SupportCallCenterOrder = c.Boolean(nullable: false),
                        SupportPOS = c.Boolean(nullable: false),
                        CompanyId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.CompanyCenters", t => t.ParentId)
                .ForeignKey("dbo.DataOwners", t => t.DataOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.DataOwnerCenters", t => t.DataOwnerCenterId, cascadeDelete: false)
                .ForeignKey("dbo.Principals", t => t.LastModifiedById)
                .Index(t => t.ParentId)
                .Index(t => t.CompanyId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
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
                        CustomerGroup2Id = c.Guid(),
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
                .ForeignKey("dbo.CustomerGroups", t => t.CustomerGroup2Id)
                .ForeignKey("dbo.DataOwners", t => t.DataOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.DataOwnerCenters", t => t.DataOwnerCenterId, cascadeDelete: false)
                .ForeignKey("dbo.Principals", t => t.LastModifiedById)
                .Index(t => t.CustomerGroup2Id)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.CustomerLoyaltyTierHistories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        LoyaltyTierId = c.Guid(nullable: false),
                        FromTime = c.DateTime(nullable: false),
                        ToTime = c.DateTime(nullable: false),
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
                .ForeignKey("dbo.LoyaltyTiers", t => t.LoyaltyTierId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.LoyaltyTierId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.LoyaltyTiers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TierName = c.String(maxLength: 100),
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
                "dbo.CustomerShipAddresses",
                c => new
                    {
                        RegionInfoId = c.Guid(),
                        RegionLevel1Id = c.Guid(),
                        RegionLevel2Id = c.Guid(),
                        RegionLevel3Id = c.Guid(),
                        RegionLevel4Id = c.Guid(),
                        Id = c.Guid(nullable: false),
                        AddressName = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 20),
                        Mobile = c.String(maxLength: 20),
                        Email = c.String(maxLength: 50),
                        MainStreet = c.String(maxLength: 500),
                        OtherStreet = c.String(maxLength: 500),
                        PostalCode = c.String(maxLength: 20),
                        Transferee = c.String(maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        Lat = c.Decimal(precision: 18, scale: 2),
                        Lng = c.Decimal(precision: 18, scale: 2),
                        CustomerId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.CityRegions", t => t.RegionInfoId)
                .ForeignKey("dbo.CityRegions", t => t.RegionLevel1Id)
                .ForeignKey("dbo.CityRegions", t => t.RegionLevel2Id)
                .ForeignKey("dbo.CityRegions", t => t.RegionLevel3Id)
                .ForeignKey("dbo.CityRegions", t => t.RegionLevel4Id)
                .Index(t => t.RegionInfoId)
                .Index(t => t.RegionLevel1Id)
                .Index(t => t.RegionLevel2Id)
                .Index(t => t.RegionLevel3Id)
                .Index(t => t.RegionLevel4Id)
                .Index(t => t.CustomerId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.LoyaltyCards",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CardNo = c.String(),
                        ExpireDate = c.DateTime(nullable: false),
                        GenerateDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        AssignDate = c.Boolean(nullable: false),
                        CancelReason = c.Guid(),
                        LoyaltyCardSetId = c.Guid(nullable: false),
                        LoyaltyCardBatchId = c.Guid(),
                        CustomerId = c.Guid(),
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
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.DataOwners", t => t.DataOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.DataOwnerCenters", t => t.DataOwnerCenterId, cascadeDelete: false)
                .ForeignKey("dbo.Principals", t => t.LastModifiedById)
                .ForeignKey("dbo.LoyaltyCardBatches", t => t.LoyaltyCardBatchId)
                .ForeignKey("dbo.LoyaltyCardSets", t => t.LoyaltyCardSetId, cascadeDelete: true)
                .Index(t => t.LoyaltyCardSetId)
                .Index(t => t.LoyaltyCardBatchId)
                .Index(t => t.CustomerId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.LoyaltyCardBatches",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BatchGenerateDate = c.DateTime(nullable: false),
                        BatchGeneratePDate = c.String(),
                        Number_ID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                        ApplicationOwnerId = c.Guid(nullable: false),
                        DataOwnerId = c.Guid(nullable: false),
                        DataOwnerCenterId = c.Guid(nullable: false),
                        AddedById = c.Guid(),
                        LastModifiedById = c.Guid(),
                        LoyaltyCardSet_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Principals", t => t.AddedById)
                .ForeignKey("dbo.ApplicationOwners", t => t.ApplicationOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.DataOwners", t => t.DataOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.DataOwnerCenters", t => t.DataOwnerCenterId, cascadeDelete: false)
                .ForeignKey("dbo.Principals", t => t.LastModifiedById)
                .ForeignKey("dbo.LoyaltyCardSets", t => t.LoyaltyCardSet_Id)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById)
                .Index(t => t.LoyaltyCardSet_Id);
            
            CreateTable(
                "dbo.LoyaltyCardSets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyCardSetName = c.String(maxLength: 100),
                        Seed = c.Int(nullable: false),
                        CurrentNo = c.Long(nullable: false),
                        Initialtext = c.String(),
                        GenerateNoType = c.Guid(nullable: false),
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
                "dbo.CompanyOrgCharts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 200),
                        NLeft = c.Int(nullable: false),
                        NRight = c.Int(nullable: false),
                        NLevel = c.Int(nullable: false),
                        Priority = c.Int(),
                        ParentId = c.Guid(),
                        CompanyPersonnelId = c.Guid(),
                        CompanyCenterId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.CompanyCenters", t => t.CompanyCenterId, cascadeDelete: true)
                .ForeignKey("dbo.CompanyPersonnels", t => t.CompanyPersonnelId)
                .ForeignKey("dbo.DataOwners", t => t.DataOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.DataOwnerCenters", t => t.DataOwnerCenterId, cascadeDelete: false)
                .ForeignKey("dbo.Principals", t => t.LastModifiedById)
                .ForeignKey("dbo.CompanyOrgCharts", t => t.ParentId)
                .Index(t => t.ParentId)
                .Index(t => t.CompanyPersonnelId)
                .Index(t => t.CompanyCenterId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.CompanyPersonnels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LastName = c.String(maxLength: 100),
                        FirstName = c.String(maxLength: 100),
                        Code = c.Int(nullable: false),
                        CompanyId = c.Guid(nullable: false),
                        AnatoliAccountId = c.Guid(),
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
                .ForeignKey("dbo.AnatoliAccounts", t => t.AnatoliAccountId)
                .ForeignKey("dbo.ApplicationOwners", t => t.ApplicationOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.DataOwners", t => t.DataOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.DataOwnerCenters", t => t.DataOwnerCenterId, cascadeDelete: false)
                .ForeignKey("dbo.Principals", t => t.LastModifiedById)
                .Index(t => t.CompanyId)
                .Index(t => t.AnatoliAccountId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.CurrencyTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CurrencyTypeName = c.String(maxLength: 100),
                        IsDefault = c.Boolean(nullable: false),
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
                "dbo.LoyaltyActionTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyActionTypeName = c.String(maxLength: 100),
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
                "dbo.LoyaltyRuleActions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ActionValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoyaltyRuleId = c.Guid(nullable: false),
                        LoyaltyActionTypeId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.LoyaltyActionTypes", t => t.LoyaltyActionTypeId, cascadeDelete: true)
                .ForeignKey("dbo.LoyaltyRules", t => t.LoyaltyRuleId, cascadeDelete: true)
                .ForeignKey("dbo.LoyaltyValueTypes", t => t.LoyaltyValueTypeId, cascadeDelete: true)
                .Index(t => t.LoyaltyRuleId)
                .Index(t => t.LoyaltyActionTypeId)
                .Index(t => t.LoyaltyValueTypeId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.LoyaltyRules",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyRuleName = c.String(maxLength: 100),
                        Description = c.String(maxLength: 2000),
                        CalcPriority = c.Int(nullable: false),
                        LoyaltyRuleTypeId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.LoyaltyRuleTypes", t => t.LoyaltyRuleTypeId, cascadeDelete: true)
                .ForeignKey("dbo.LoyaltyTriggerTypes", t => t.LoyaltyTriggerTypeId, cascadeDelete: true)
                .Index(t => t.LoyaltyRuleTypeId)
                .Index(t => t.LoyaltyTriggerTypeId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.LoyaltyProgramRules",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyRuleId = c.Guid(nullable: false),
                        LoyaltyProgramId = c.Guid(nullable: false),
                        isActive = c.Boolean(nullable: false),
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
                .ForeignKey("dbo.LoyaltyPrograms", t => t.LoyaltyProgramId, cascadeDelete: true)
                .ForeignKey("dbo.LoyaltyRules", t => t.LoyaltyRuleId, cascadeDelete: true)
                .Index(t => t.LoyaltyRuleId)
                .Index(t => t.LoyaltyProgramId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.LoyaltyPrograms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyProgramName = c.String(maxLength: 100),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
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
                "dbo.LoyaltyRuleTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyRuleTypeName = c.String(maxLength: 100),
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
                "dbo.LoyaltyTriggerTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyTriggerTypeName = c.String(maxLength: 100),
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
                "dbo.LoyaltyValueTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyValueTypeName = c.String(maxLength: 100),
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
                "dbo.LoyaltyRuleConditions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyRuleId = c.Guid(nullable: false),
                        MinValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoyaltyRuleConditionTypeId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.LoyaltyRules", t => t.LoyaltyRuleId, cascadeDelete: true)
                .ForeignKey("dbo.LoyaltyRuleConditionTypes", t => t.LoyaltyRuleConditionTypeId, cascadeDelete: true)
                .Index(t => t.LoyaltyRuleId)
                .Index(t => t.LoyaltyRuleConditionTypeId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.LoyaltyRuleConditionTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyRuleConditionTypeName = c.String(maxLength: 100),
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
                "dbo.ProductGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GroupName = c.String(maxLength: 200),
                        NLeft = c.Int(nullable: false),
                        NRight = c.Int(nullable: false),
                        NLevel = c.Int(nullable: false),
                        Priority = c.Int(),
                        ProductGroup2Id = c.Guid(),
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
                .ForeignKey("dbo.ProductGroups", t => t.ProductGroup2Id)
                .Index(t => t.ProductGroup2Id)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductCode = c.String(maxLength: 20),
                        Barcode = c.String(maxLength: 20),
                        ProductName = c.String(maxLength: 200),
                        StoreProductName = c.String(maxLength: 200),
                        PackVolume = c.Decimal(precision: 18, scale: 2),
                        PackWeight = c.Decimal(precision: 18, scale: 2),
                        QtyPerPack = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxCategoryValueId = c.Long(),
                        Desctription = c.String(maxLength: 500),
                        ProductGroupId = c.Guid(),
                        ProductRate = c.Double(nullable: false),
                        IsActiveInOrder = c.Boolean(nullable: false),
                        Number_ID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                        ApplicationOwnerId = c.Guid(nullable: false),
                        DataOwnerId = c.Guid(nullable: false),
                        DataOwnerCenterId = c.Guid(nullable: false),
                        AddedById = c.Guid(),
                        LastModifiedById = c.Guid(),
                        ProductType_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Principals", t => t.AddedById)
                .ForeignKey("dbo.ApplicationOwners", t => t.ApplicationOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.DataOwners", t => t.DataOwnerId, cascadeDelete: false)
                .ForeignKey("dbo.DataOwnerCenters", t => t.DataOwnerCenterId, cascadeDelete: false)
                .ForeignKey("dbo.Principals", t => t.LastModifiedById)
                .ForeignKey("dbo.ProductGroups", t => t.ProductGroupId)
                .ForeignKey("dbo.ProductTypes", t => t.ProductType_Id)
                .Index(t => t.ProductGroupId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById)
                .Index(t => t.ProductType_Id);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductTypeName = c.String(maxLength: 100),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductType_Id", "dbo.ProductTypes");
            DropForeignKey("dbo.ProductTypes", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.ProductTypes", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.ProductTypes", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.ProductTypes", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.ProductTypes", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.Products", "ProductGroupId", "dbo.ProductGroups");
            DropForeignKey("dbo.Products", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.Products", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.Products", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.Products", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.Products", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.ProductGroups", "ProductGroup2Id", "dbo.ProductGroups");
            DropForeignKey("dbo.ProductGroups", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.ProductGroups", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.ProductGroups", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.ProductGroups", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.ProductGroups", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRuleConditions", "LoyaltyRuleConditionTypeId", "dbo.LoyaltyRuleConditionTypes");
            DropForeignKey("dbo.LoyaltyRuleConditionTypes", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRuleConditionTypes", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyRuleConditionTypes", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyRuleConditionTypes", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyRuleConditionTypes", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRuleConditions", "LoyaltyRuleId", "dbo.LoyaltyRules");
            DropForeignKey("dbo.LoyaltyRuleConditions", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRuleConditions", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyRuleConditions", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyRuleConditions", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyRuleConditions", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRuleActions", "LoyaltyValueTypeId", "dbo.LoyaltyValueTypes");
            DropForeignKey("dbo.LoyaltyValueTypes", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyValueTypes", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyValueTypes", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyValueTypes", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyValueTypes", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRuleActions", "LoyaltyRuleId", "dbo.LoyaltyRules");
            DropForeignKey("dbo.LoyaltyRules", "LoyaltyTriggerTypeId", "dbo.LoyaltyTriggerTypes");
            DropForeignKey("dbo.LoyaltyTriggerTypes", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyTriggerTypes", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyTriggerTypes", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyTriggerTypes", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyTriggerTypes", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRules", "LoyaltyRuleTypeId", "dbo.LoyaltyRuleTypes");
            DropForeignKey("dbo.LoyaltyRuleTypes", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRuleTypes", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyRuleTypes", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyRuleTypes", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyRuleTypes", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyProgramRules", "LoyaltyRuleId", "dbo.LoyaltyRules");
            DropForeignKey("dbo.LoyaltyProgramRules", "LoyaltyProgramId", "dbo.LoyaltyPrograms");
            DropForeignKey("dbo.LoyaltyPrograms", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyPrograms", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyPrograms", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyPrograms", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyPrograms", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyProgramRules", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyProgramRules", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyProgramRules", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyProgramRules", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyProgramRules", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRules", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRules", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyRules", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyRules", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyRules", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRuleActions", "LoyaltyActionTypeId", "dbo.LoyaltyActionTypes");
            DropForeignKey("dbo.LoyaltyRuleActions", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRuleActions", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyRuleActions", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyRuleActions", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyRuleActions", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyActionTypes", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyActionTypes", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyActionTypes", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyActionTypes", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyActionTypes", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.CurrencyTypes", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.CurrencyTypes", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.CurrencyTypes", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.CurrencyTypes", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.CurrencyTypes", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.CompanyOrgCharts", "ParentId", "dbo.CompanyOrgCharts");
            DropForeignKey("dbo.CompanyOrgCharts", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.CompanyOrgCharts", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.CompanyOrgCharts", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.CompanyOrgCharts", "CompanyPersonnelId", "dbo.CompanyPersonnels");
            DropForeignKey("dbo.CompanyPersonnels", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.CompanyPersonnels", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.CompanyPersonnels", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.CompanyPersonnels", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.CompanyPersonnels", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.CompanyPersonnels", "AnatoliAccountId", "dbo.AnatoliAccounts");
            DropForeignKey("dbo.CompanyPersonnels", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.CompanyOrgCharts", "CompanyCenterId", "dbo.CompanyCenters");
            DropForeignKey("dbo.CompanyOrgCharts", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.CompanyOrgCharts", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.CityRegions", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.CityRegions", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.CityRegions", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.Customers", "CityRegion_Id", "dbo.CityRegions");
            DropForeignKey("dbo.Customers", "RegionLevel4Id", "dbo.CityRegions");
            DropForeignKey("dbo.Customers", "RegionLevel3Id", "dbo.CityRegions");
            DropForeignKey("dbo.Customers", "RegionLevel2Id", "dbo.CityRegions");
            DropForeignKey("dbo.Customers", "RegionLevel1Id", "dbo.CityRegions");
            DropForeignKey("dbo.Customers", "RegionInfoId", "dbo.CityRegions");
            DropForeignKey("dbo.Customers", "LoyaltyTierId", "dbo.LoyaltyTiers");
            DropForeignKey("dbo.LoyaltyCards", "LoyaltyCardSetId", "dbo.LoyaltyCardSets");
            DropForeignKey("dbo.LoyaltyCardBatches", "LoyaltyCardSet_Id", "dbo.LoyaltyCardSets");
            DropForeignKey("dbo.LoyaltyCardSets", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyCardSets", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyCardSets", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyCardSets", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyCardSets", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyCards", "LoyaltyCardBatchId", "dbo.LoyaltyCardBatches");
            DropForeignKey("dbo.LoyaltyCardBatches", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyCardBatches", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyCardBatches", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyCardBatches", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyCardBatches", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyCards", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyCards", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyCards", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyCards", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.LoyaltyCards", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyCards", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.Customers", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.Customers", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.Customers", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.CustomerShipAddresses", "RegionLevel4Id", "dbo.CityRegions");
            DropForeignKey("dbo.CustomerShipAddresses", "RegionLevel3Id", "dbo.CityRegions");
            DropForeignKey("dbo.CustomerShipAddresses", "RegionLevel2Id", "dbo.CityRegions");
            DropForeignKey("dbo.CustomerShipAddresses", "RegionLevel1Id", "dbo.CityRegions");
            DropForeignKey("dbo.CustomerShipAddresses", "RegionInfoId", "dbo.CityRegions");
            DropForeignKey("dbo.CustomerShipAddresses", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.CustomerShipAddresses", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.CustomerShipAddresses", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.CustomerShipAddresses", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerShipAddresses", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.CustomerShipAddresses", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.CustomerLoyaltyTierHistories", "LoyaltyTierId", "dbo.LoyaltyTiers");
            DropForeignKey("dbo.LoyaltyTiers", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyTiers", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyTiers", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyTiers", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyTiers", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.CustomerLoyaltyTierHistories", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.CustomerLoyaltyTierHistories", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.CustomerLoyaltyTierHistories", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.CustomerLoyaltyTierHistories", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerLoyaltyTierHistories", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.CustomerLoyaltyTierHistories", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.Customers", "CustomerGroupId", "dbo.CustomerGroups");
            DropForeignKey("dbo.CustomerGroups", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.CustomerGroups", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.CustomerGroups", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.CustomerGroups", "CustomerGroup2Id", "dbo.CustomerGroups");
            DropForeignKey("dbo.CustomerGroups", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.CustomerGroups", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.Customers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Companies", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.Companies", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.Companies", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.CompanyCenters", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.CompanyCenters", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.CompanyCenters", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.CompanyCenters", "ParentId", "dbo.CompanyCenters");
            DropForeignKey("dbo.CompanyCenters", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.CompanyCenters", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.CompanyCenters", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.Companies", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.Companies", "AnatoliAccountId", "dbo.AnatoliAccounts");
            DropForeignKey("dbo.Companies", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.Customers", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.Customers", "AnatoliAccountId", "dbo.AnatoliAccounts");
            DropForeignKey("dbo.Customers", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.CityRegions", "CityRegion2Id", "dbo.CityRegions");
            DropForeignKey("dbo.CityRegions", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.CityRegions", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.BaseTypes", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.BaseTypes", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.BaseTypes", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.BaseValues", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.BaseValues", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.BaseValues", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.BaseValues", "BaseTypeId", "dbo.BaseTypes");
            DropForeignKey("dbo.BaseValues", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.BaseValues", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.BaseTypes", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.BaseTypes", "AddedById", "dbo.Principals");
            DropIndex("dbo.ProductTypes", new[] { "LastModifiedById" });
            DropIndex("dbo.ProductTypes", new[] { "AddedById" });
            DropIndex("dbo.ProductTypes", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.ProductTypes", new[] { "DataOwnerId" });
            DropIndex("dbo.ProductTypes", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.Products", new[] { "ProductType_Id" });
            DropIndex("dbo.Products", new[] { "LastModifiedById" });
            DropIndex("dbo.Products", new[] { "AddedById" });
            DropIndex("dbo.Products", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.Products", new[] { "DataOwnerId" });
            DropIndex("dbo.Products", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.Products", new[] { "ProductGroupId" });
            DropIndex("dbo.ProductGroups", new[] { "LastModifiedById" });
            DropIndex("dbo.ProductGroups", new[] { "AddedById" });
            DropIndex("dbo.ProductGroups", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.ProductGroups", new[] { "DataOwnerId" });
            DropIndex("dbo.ProductGroups", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.ProductGroups", new[] { "ProductGroup2Id" });
            DropIndex("dbo.LoyaltyRuleConditionTypes", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyRuleConditionTypes", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyRuleConditionTypes", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyRuleConditionTypes", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyRuleConditionTypes", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyRuleConditions", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyRuleConditions", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyRuleConditions", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyRuleConditions", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyRuleConditions", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyRuleConditions", new[] { "LoyaltyRuleConditionTypeId" });
            DropIndex("dbo.LoyaltyRuleConditions", new[] { "LoyaltyRuleId" });
            DropIndex("dbo.LoyaltyValueTypes", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyValueTypes", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyValueTypes", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyValueTypes", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyValueTypes", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyTriggerTypes", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyTriggerTypes", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyTriggerTypes", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyTriggerTypes", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyTriggerTypes", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyRuleTypes", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyRuleTypes", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyRuleTypes", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyRuleTypes", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyRuleTypes", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyPrograms", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyPrograms", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyPrograms", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyPrograms", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyPrograms", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyProgramRules", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyProgramRules", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyProgramRules", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyProgramRules", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyProgramRules", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyProgramRules", new[] { "LoyaltyProgramId" });
            DropIndex("dbo.LoyaltyProgramRules", new[] { "LoyaltyRuleId" });
            DropIndex("dbo.LoyaltyRules", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyRules", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyRules", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyRules", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyRules", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyRules", new[] { "LoyaltyTriggerTypeId" });
            DropIndex("dbo.LoyaltyRules", new[] { "LoyaltyRuleTypeId" });
            DropIndex("dbo.LoyaltyRuleActions", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyRuleActions", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyRuleActions", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyRuleActions", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyRuleActions", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyRuleActions", new[] { "LoyaltyValueTypeId" });
            DropIndex("dbo.LoyaltyRuleActions", new[] { "LoyaltyActionTypeId" });
            DropIndex("dbo.LoyaltyRuleActions", new[] { "LoyaltyRuleId" });
            DropIndex("dbo.LoyaltyActionTypes", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyActionTypes", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyActionTypes", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyActionTypes", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyActionTypes", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.CurrencyTypes", new[] { "LastModifiedById" });
            DropIndex("dbo.CurrencyTypes", new[] { "AddedById" });
            DropIndex("dbo.CurrencyTypes", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.CurrencyTypes", new[] { "DataOwnerId" });
            DropIndex("dbo.CurrencyTypes", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.CompanyPersonnels", new[] { "LastModifiedById" });
            DropIndex("dbo.CompanyPersonnels", new[] { "AddedById" });
            DropIndex("dbo.CompanyPersonnels", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.CompanyPersonnels", new[] { "DataOwnerId" });
            DropIndex("dbo.CompanyPersonnels", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.CompanyPersonnels", new[] { "AnatoliAccountId" });
            DropIndex("dbo.CompanyPersonnels", new[] { "CompanyId" });
            DropIndex("dbo.CompanyOrgCharts", new[] { "LastModifiedById" });
            DropIndex("dbo.CompanyOrgCharts", new[] { "AddedById" });
            DropIndex("dbo.CompanyOrgCharts", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.CompanyOrgCharts", new[] { "DataOwnerId" });
            DropIndex("dbo.CompanyOrgCharts", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.CompanyOrgCharts", new[] { "CompanyCenterId" });
            DropIndex("dbo.CompanyOrgCharts", new[] { "CompanyPersonnelId" });
            DropIndex("dbo.CompanyOrgCharts", new[] { "ParentId" });
            DropIndex("dbo.LoyaltyCardSets", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyCardSets", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyCardSets", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyCardSets", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyCardSets", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyCardBatches", new[] { "LoyaltyCardSet_Id" });
            DropIndex("dbo.LoyaltyCardBatches", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyCardBatches", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyCardBatches", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyCardBatches", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyCardBatches", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyCards", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyCards", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyCards", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyCards", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyCards", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyCards", new[] { "CustomerId" });
            DropIndex("dbo.LoyaltyCards", new[] { "LoyaltyCardBatchId" });
            DropIndex("dbo.LoyaltyCards", new[] { "LoyaltyCardSetId" });
            DropIndex("dbo.CustomerShipAddresses", new[] { "LastModifiedById" });
            DropIndex("dbo.CustomerShipAddresses", new[] { "AddedById" });
            DropIndex("dbo.CustomerShipAddresses", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.CustomerShipAddresses", new[] { "DataOwnerId" });
            DropIndex("dbo.CustomerShipAddresses", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.CustomerShipAddresses", new[] { "CustomerId" });
            DropIndex("dbo.CustomerShipAddresses", new[] { "RegionLevel4Id" });
            DropIndex("dbo.CustomerShipAddresses", new[] { "RegionLevel3Id" });
            DropIndex("dbo.CustomerShipAddresses", new[] { "RegionLevel2Id" });
            DropIndex("dbo.CustomerShipAddresses", new[] { "RegionLevel1Id" });
            DropIndex("dbo.CustomerShipAddresses", new[] { "RegionInfoId" });
            DropIndex("dbo.LoyaltyTiers", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyTiers", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyTiers", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyTiers", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyTiers", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.CustomerLoyaltyTierHistories", new[] { "LastModifiedById" });
            DropIndex("dbo.CustomerLoyaltyTierHistories", new[] { "AddedById" });
            DropIndex("dbo.CustomerLoyaltyTierHistories", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.CustomerLoyaltyTierHistories", new[] { "DataOwnerId" });
            DropIndex("dbo.CustomerLoyaltyTierHistories", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.CustomerLoyaltyTierHistories", new[] { "LoyaltyTierId" });
            DropIndex("dbo.CustomerLoyaltyTierHistories", new[] { "CustomerId" });
            DropIndex("dbo.CustomerGroups", new[] { "LastModifiedById" });
            DropIndex("dbo.CustomerGroups", new[] { "AddedById" });
            DropIndex("dbo.CustomerGroups", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.CustomerGroups", new[] { "DataOwnerId" });
            DropIndex("dbo.CustomerGroups", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.CustomerGroups", new[] { "CustomerGroup2Id" });
            DropIndex("dbo.CompanyCenters", new[] { "LastModifiedById" });
            DropIndex("dbo.CompanyCenters", new[] { "AddedById" });
            DropIndex("dbo.CompanyCenters", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.CompanyCenters", new[] { "DataOwnerId" });
            DropIndex("dbo.CompanyCenters", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.CompanyCenters", new[] { "CompanyId" });
            DropIndex("dbo.CompanyCenters", new[] { "ParentId" });
            DropIndex("dbo.Companies", new[] { "LastModifiedById" });
            DropIndex("dbo.Companies", new[] { "AddedById" });
            DropIndex("dbo.Companies", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.Companies", new[] { "DataOwnerId" });
            DropIndex("dbo.Companies", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.Companies", new[] { "AnatoliAccountId" });
            DropIndex("dbo.Customers", new[] { "CityRegion_Id" });
            DropIndex("dbo.Customers", new[] { "LastModifiedById" });
            DropIndex("dbo.Customers", new[] { "AddedById" });
            DropIndex("dbo.Customers", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.Customers", new[] { "DataOwnerId" });
            DropIndex("dbo.Customers", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.Customers", new[] { "AnatoliAccountId" });
            DropIndex("dbo.Customers", new[] { "CompanyId" });
            DropIndex("dbo.Customers", new[] { "LoyaltyTierId" });
            DropIndex("dbo.Customers", new[] { "CustomerGroupId" });
            DropIndex("dbo.Customers", new[] { "RegionLevel4Id" });
            DropIndex("dbo.Customers", new[] { "RegionLevel3Id" });
            DropIndex("dbo.Customers", new[] { "RegionLevel2Id" });
            DropIndex("dbo.Customers", new[] { "RegionLevel1Id" });
            DropIndex("dbo.Customers", new[] { "RegionInfoId" });
            DropIndex("dbo.CityRegions", new[] { "LastModifiedById" });
            DropIndex("dbo.CityRegions", new[] { "AddedById" });
            DropIndex("dbo.CityRegions", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.CityRegions", new[] { "DataOwnerId" });
            DropIndex("dbo.CityRegions", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.CityRegions", new[] { "CityRegion2Id" });
            DropIndex("dbo.BaseValues", new[] { "LastModifiedById" });
            DropIndex("dbo.BaseValues", new[] { "AddedById" });
            DropIndex("dbo.BaseValues", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.BaseValues", new[] { "DataOwnerId" });
            DropIndex("dbo.BaseValues", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.BaseValues", new[] { "BaseTypeId" });
            DropIndex("dbo.BaseTypes", new[] { "LastModifiedById" });
            DropIndex("dbo.BaseTypes", new[] { "AddedById" });
            DropIndex("dbo.BaseTypes", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.BaseTypes", new[] { "DataOwnerId" });
            DropIndex("dbo.BaseTypes", new[] { "ApplicationOwnerId" });
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Products");
            DropTable("dbo.ProductGroups");
            DropTable("dbo.LoyaltyRuleConditionTypes");
            DropTable("dbo.LoyaltyRuleConditions");
            DropTable("dbo.LoyaltyValueTypes");
            DropTable("dbo.LoyaltyTriggerTypes");
            DropTable("dbo.LoyaltyRuleTypes");
            DropTable("dbo.LoyaltyPrograms");
            DropTable("dbo.LoyaltyProgramRules");
            DropTable("dbo.LoyaltyRules");
            DropTable("dbo.LoyaltyRuleActions");
            DropTable("dbo.LoyaltyActionTypes");
            DropTable("dbo.CurrencyTypes");
            DropTable("dbo.CompanyPersonnels");
            DropTable("dbo.CompanyOrgCharts");
            DropTable("dbo.LoyaltyCardSets");
            DropTable("dbo.LoyaltyCardBatches");
            DropTable("dbo.LoyaltyCards");
            DropTable("dbo.CustomerShipAddresses");
            DropTable("dbo.LoyaltyTiers");
            DropTable("dbo.CustomerLoyaltyTierHistories");
            DropTable("dbo.CustomerGroups");
            DropTable("dbo.CompanyCenters");
            DropTable("dbo.Companies");
            DropTable("dbo.Customers");
            DropTable("dbo.CityRegions");
            DropTable("dbo.BaseValues");
            DropTable("dbo.BaseTypes");
        }
    }
}
