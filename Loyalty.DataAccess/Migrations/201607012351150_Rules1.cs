namespace Loyalty.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rules1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoyaltyRuleActions", "LoyaltyValueTypeId", "dbo.LoyaltyValueTypes");
            DropForeignKey("dbo.LoyaltyRules", "LoyaltyTriggerTypeId", "dbo.LoyaltyTriggerTypes");
            DropForeignKey("dbo.LoyaltyRuleConditions", "LoyaltyRuleConditionTypeId", "dbo.LoyaltyRuleConditionTypes");
            DropIndex("dbo.LoyaltyRuleActions", new[] { "LoyaltyValueTypeId" });
            DropIndex("dbo.LoyaltyRules", new[] { "LoyaltyTriggerTypeId" });
            DropIndex("dbo.LoyaltyRuleConditions", new[] { "LoyaltyRuleConditionTypeId" });
            RenameColumn(table: "dbo.LoyaltyRules", name: "LoyaltyTriggerTypeId", newName: "LoyaltyTriggerType_Id");
            RenameColumn(table: "dbo.LoyaltyRuleConditions", name: "LoyaltyRuleConditionTypeId", newName: "LoyaltyRuleConditionType_Id");
            CreateTable(
                "dbo.LoyaltyRuleGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyRuleGroupCode = c.String(maxLength: 20),
                        LoyaltyRuleGroupName = c.String(maxLength: 100),
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
                "dbo.LoyaltyRuleTriggers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyRuleId = c.Guid(nullable: false),
                        LoyaltyTriggerId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.LoyaltyTriggers", t => t.LoyaltyTriggerId, cascadeDelete: true)
                .Index(t => t.LoyaltyRuleId)
                .Index(t => t.LoyaltyTriggerId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.LoyaltyRuleConditionProductGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyRuleConditionId = c.Guid(nullable: false),
                        ProductGroupId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.LoyaltyRuleConditions", t => t.LoyaltyRuleConditionId, cascadeDelete: true)
                .ForeignKey("dbo.ProductGroups", t => t.ProductGroupId, cascadeDelete: true)
                .Index(t => t.LoyaltyRuleConditionId)
                .Index(t => t.ProductGroupId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.LoyaltyRuleConditionProducts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyRuleConditionId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.LoyaltyRuleConditions", t => t.LoyaltyRuleConditionId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.LoyaltyRuleConditionId)
                .Index(t => t.ProductId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.LoyaltyRuleConditionValues",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoyaltyRuleConditionId = c.Guid(nullable: false),
                        MinValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StepValue = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                .ForeignKey("dbo.LoyaltyRuleConditions", t => t.LoyaltyRuleConditionId, cascadeDelete: true)
                .Index(t => t.LoyaltyRuleConditionId)
                .Index(t => t.ApplicationOwnerId)
                .Index(t => t.DataOwnerId)
                .Index(t => t.DataOwnerCenterId)
                .Index(t => t.AddedById)
                .Index(t => t.LastModifiedById);
            
            AddColumn("dbo.LoyaltyActionTypes", "LoyaltyActionTypeCode", c => c.String(maxLength: 20));
            AddColumn("dbo.LoyaltyRuleActions", "LoyaltyValueTypeAttributeId", c => c.Guid(nullable: false));
            AddColumn("dbo.LoyaltyRuleActions", "LoyaltyTierId", c => c.Guid(nullable: false));
            AddColumn("dbo.LoyaltyRuleActions", "ActionPercent", c => c.Single(nullable: false));
            AddColumn("dbo.LoyaltyRuleActions", "ActionNewValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.LoyaltyRuleActions", "CreditDay", c => c.Int(nullable: false));
            AddColumn("dbo.LoyaltyRules", "LoyaltyRuleCode", c => c.String(maxLength: 20));
            AddColumn("dbo.LoyaltyRules", "HasCondition", c => c.Boolean(nullable: false));
            AddColumn("dbo.LoyaltyRules", "LoyaltyRuleGroupId", c => c.Guid(nullable: false));
            AddColumn("dbo.LoyaltyRuleConditions", "LoyaltyValueTypeAttributeId", c => c.Guid(nullable: false));
            AlterColumn("dbo.LoyaltyRules", "LoyaltyTriggerType_Id", c => c.Guid());
            AlterColumn("dbo.LoyaltyRuleConditions", "LoyaltyRuleConditionType_Id", c => c.Guid());
            CreateIndex("dbo.LoyaltyRuleActions", "LoyaltyValueTypeAttributeId");
            CreateIndex("dbo.LoyaltyRuleActions", "LoyaltyTierId");
            CreateIndex("dbo.LoyaltyRules", "LoyaltyRuleGroupId");
            CreateIndex("dbo.LoyaltyRules", "LoyaltyTriggerType_Id");
            CreateIndex("dbo.LoyaltyRuleConditions", "LoyaltyValueTypeAttributeId");
            CreateIndex("dbo.LoyaltyRuleConditions", "LoyaltyRuleConditionType_Id");
            AddForeignKey("dbo.LoyaltyRules", "LoyaltyRuleGroupId", "dbo.LoyaltyRuleGroups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoyaltyRuleActions", "LoyaltyTierId", "dbo.LoyaltyTiers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoyaltyRuleActions", "LoyaltyValueTypeAttributeId", "dbo.LoyaltyValueTypeAttributes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoyaltyRuleConditions", "LoyaltyValueTypeAttributeId", "dbo.LoyaltyValueTypeAttributes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoyaltyRules", "LoyaltyTriggerType_Id", "dbo.LoyaltyTriggerTypes", "Id");
            AddForeignKey("dbo.LoyaltyRuleConditions", "LoyaltyRuleConditionType_Id", "dbo.LoyaltyRuleConditionTypes", "Id");
            DropColumn("dbo.LoyaltyRuleActions", "LoyaltyValueTypeId");
            DropColumn("dbo.LoyaltyRules", "CalcPriority");
            DropColumn("dbo.LoyaltyRuleConditions", "MinValue");
            DropColumn("dbo.LoyaltyRuleConditions", "MaxValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoyaltyRuleConditions", "MaxValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.LoyaltyRuleConditions", "MinValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.LoyaltyRules", "CalcPriority", c => c.Int(nullable: false));
            AddColumn("dbo.LoyaltyRuleActions", "LoyaltyValueTypeId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.LoyaltyRuleConditions", "LoyaltyRuleConditionType_Id", "dbo.LoyaltyRuleConditionTypes");
            DropForeignKey("dbo.LoyaltyRules", "LoyaltyTriggerType_Id", "dbo.LoyaltyTriggerTypes");
            DropForeignKey("dbo.LoyaltyRuleConditionProductGroups", "ProductGroupId", "dbo.ProductGroups");
            DropForeignKey("dbo.LoyaltyRuleConditionProductGroups", "LoyaltyRuleConditionId", "dbo.LoyaltyRuleConditions");
            DropForeignKey("dbo.LoyaltyRuleConditions", "LoyaltyValueTypeAttributeId", "dbo.LoyaltyValueTypeAttributes");
            DropForeignKey("dbo.LoyaltyRuleConditionValues", "LoyaltyRuleConditionId", "dbo.LoyaltyRuleConditions");
            DropForeignKey("dbo.LoyaltyRuleConditionValues", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRuleConditionValues", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyRuleConditionValues", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyRuleConditionValues", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyRuleConditionValues", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRuleConditionProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.LoyaltyRuleConditionProducts", "LoyaltyRuleConditionId", "dbo.LoyaltyRuleConditions");
            DropForeignKey("dbo.LoyaltyRuleConditionProducts", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRuleConditionProducts", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyRuleConditionProducts", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyRuleConditionProducts", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyRuleConditionProducts", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRuleConditionProductGroups", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRuleConditionProductGroups", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyRuleConditionProductGroups", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyRuleConditionProductGroups", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyRuleConditionProductGroups", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRuleActions", "LoyaltyValueTypeAttributeId", "dbo.LoyaltyValueTypeAttributes");
            DropForeignKey("dbo.LoyaltyRuleActions", "LoyaltyTierId", "dbo.LoyaltyTiers");
            DropForeignKey("dbo.LoyaltyRuleTriggers", "LoyaltyTriggerId", "dbo.LoyaltyTriggers");
            DropForeignKey("dbo.LoyaltyRuleTriggers", "LoyaltyRuleId", "dbo.LoyaltyRules");
            DropForeignKey("dbo.LoyaltyRuleTriggers", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRuleTriggers", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyRuleTriggers", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyRuleTriggers", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyRuleTriggers", "AddedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRules", "LoyaltyRuleGroupId", "dbo.LoyaltyRuleGroups");
            DropForeignKey("dbo.LoyaltyRuleGroups", "LastModifiedById", "dbo.Principals");
            DropForeignKey("dbo.LoyaltyRuleGroups", "DataOwnerCenterId", "dbo.DataOwnerCenters");
            DropForeignKey("dbo.LoyaltyRuleGroups", "DataOwnerId", "dbo.DataOwners");
            DropForeignKey("dbo.LoyaltyRuleGroups", "ApplicationOwnerId", "dbo.ApplicationOwners");
            DropForeignKey("dbo.LoyaltyRuleGroups", "AddedById", "dbo.Principals");
            DropIndex("dbo.LoyaltyRuleConditionValues", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyRuleConditionValues", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyRuleConditionValues", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyRuleConditionValues", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyRuleConditionValues", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyRuleConditionValues", new[] { "LoyaltyRuleConditionId" });
            DropIndex("dbo.LoyaltyRuleConditionProducts", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyRuleConditionProducts", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyRuleConditionProducts", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyRuleConditionProducts", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyRuleConditionProducts", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyRuleConditionProducts", new[] { "ProductId" });
            DropIndex("dbo.LoyaltyRuleConditionProducts", new[] { "LoyaltyRuleConditionId" });
            DropIndex("dbo.LoyaltyRuleConditions", new[] { "LoyaltyRuleConditionType_Id" });
            DropIndex("dbo.LoyaltyRuleConditions", new[] { "LoyaltyValueTypeAttributeId" });
            DropIndex("dbo.LoyaltyRuleConditionProductGroups", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyRuleConditionProductGroups", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyRuleConditionProductGroups", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyRuleConditionProductGroups", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyRuleConditionProductGroups", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyRuleConditionProductGroups", new[] { "ProductGroupId" });
            DropIndex("dbo.LoyaltyRuleConditionProductGroups", new[] { "LoyaltyRuleConditionId" });
            DropIndex("dbo.LoyaltyRuleTriggers", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyRuleTriggers", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyRuleTriggers", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyRuleTriggers", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyRuleTriggers", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyRuleTriggers", new[] { "LoyaltyTriggerId" });
            DropIndex("dbo.LoyaltyRuleTriggers", new[] { "LoyaltyRuleId" });
            DropIndex("dbo.LoyaltyRuleGroups", new[] { "LastModifiedById" });
            DropIndex("dbo.LoyaltyRuleGroups", new[] { "AddedById" });
            DropIndex("dbo.LoyaltyRuleGroups", new[] { "DataOwnerCenterId" });
            DropIndex("dbo.LoyaltyRuleGroups", new[] { "DataOwnerId" });
            DropIndex("dbo.LoyaltyRuleGroups", new[] { "ApplicationOwnerId" });
            DropIndex("dbo.LoyaltyRules", new[] { "LoyaltyTriggerType_Id" });
            DropIndex("dbo.LoyaltyRules", new[] { "LoyaltyRuleGroupId" });
            DropIndex("dbo.LoyaltyRuleActions", new[] { "LoyaltyTierId" });
            DropIndex("dbo.LoyaltyRuleActions", new[] { "LoyaltyValueTypeAttributeId" });
            AlterColumn("dbo.LoyaltyRuleConditions", "LoyaltyRuleConditionType_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.LoyaltyRules", "LoyaltyTriggerType_Id", c => c.Guid(nullable: false));
            DropColumn("dbo.LoyaltyRuleConditions", "LoyaltyValueTypeAttributeId");
            DropColumn("dbo.LoyaltyRules", "LoyaltyRuleGroupId");
            DropColumn("dbo.LoyaltyRules", "HasCondition");
            DropColumn("dbo.LoyaltyRules", "LoyaltyRuleCode");
            DropColumn("dbo.LoyaltyRuleActions", "CreditDay");
            DropColumn("dbo.LoyaltyRuleActions", "ActionNewValue");
            DropColumn("dbo.LoyaltyRuleActions", "ActionPercent");
            DropColumn("dbo.LoyaltyRuleActions", "LoyaltyTierId");
            DropColumn("dbo.LoyaltyRuleActions", "LoyaltyValueTypeAttributeId");
            DropColumn("dbo.LoyaltyActionTypes", "LoyaltyActionTypeCode");
            DropTable("dbo.LoyaltyRuleConditionValues");
            DropTable("dbo.LoyaltyRuleConditionProducts");
            DropTable("dbo.LoyaltyRuleConditionProductGroups");
            DropTable("dbo.LoyaltyRuleTriggers");
            DropTable("dbo.LoyaltyRuleGroups");
            RenameColumn(table: "dbo.LoyaltyRuleConditions", name: "LoyaltyRuleConditionType_Id", newName: "LoyaltyRuleConditionTypeId");
            RenameColumn(table: "dbo.LoyaltyRules", name: "LoyaltyTriggerType_Id", newName: "LoyaltyTriggerTypeId");
            CreateIndex("dbo.LoyaltyRuleConditions", "LoyaltyRuleConditionTypeId");
            CreateIndex("dbo.LoyaltyRules", "LoyaltyTriggerTypeId");
            CreateIndex("dbo.LoyaltyRuleActions", "LoyaltyValueTypeId");
            AddForeignKey("dbo.LoyaltyRuleConditions", "LoyaltyRuleConditionTypeId", "dbo.LoyaltyRuleConditionTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoyaltyRules", "LoyaltyTriggerTypeId", "dbo.LoyaltyTriggerTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoyaltyRuleActions", "LoyaltyValueTypeId", "dbo.LoyaltyValueTypes", "Id", cascadeDelete: true);
        }
    }
}
