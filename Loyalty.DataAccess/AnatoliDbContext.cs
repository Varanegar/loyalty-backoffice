﻿using System.Data.Entity;
using Loyalty.DataAccess.Models.Account;
using Loyalty.DataAccess.Models.Loyalty;
using Microsoft.AspNet.Identity.EntityFramework;
using Anatoli.DataAccess.Models.Identity;
using Loyalty.DataAccess.Models;
using Loyalty.DataAccess.Models;
using Anatoli.DataAccess.Models;

namespace Loyalty.DataAccess
{
    public class AnatoliDbContext : IdentityDbContext<User, Role, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        #region Properties
        #region Base data
        public DbSet<BaseType> BaseTypes { get; set; }
        public DbSet<BaseValue> BaseValues { get; set; }
        public DbSet<CityRegion> CityRegions { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
        #endregion

        #region Product
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        #endregion

        #region company
        public DbSet<CompanyOrgChart> CompanyOrgCharts { get; set; }
        public DbSet<CompanyPersonnel> CompanyPersonnels { get; set; }
        public DbSet<CompanyCenter> CompanyCenters { get; set; }
        public DbSet<Company> Companies { get; set; }
        #endregion

        #region customer
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<CustomerTag> CustomerTags { get; set; }
        public DbSet<CustomerGroup> CustomerGroups { get; set; }
        public DbSet<CustomerLoyaltyTierHistory> CustomerLoyaltyTierHistories { get; set; }
        public DbSet<CustomerShipAddress> CustomerShipAddresses { get; set; }

        public DbSet<CustomerMonetaryHistory> CustomerMonetaryHistories { get; set; }
        public DbSet<CustomerNonMonetaryHistory> CustomerNonMonetaryHistories { get; set; }
        public DbSet<CustomerTransactionHistory> CustomerTransactionHistories { get; set; }
            

        #endregion

        #region Loyalty
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserGroupUser> UserGroupUsers { get; set; }

        public DbSet<LoyaltyActionType> LoyaltyActionTypes { get; set; }
        public DbSet<LoyaltyCard> LoyaltyCards { get; set; }
        public DbSet<LoyaltyCardStatus> LoyaltyCardStatuses { get; set; }
        public DbSet<LoyaltyCardBatch> LoyaltyCardBatchs { get; set; }
        public DbSet<LoyaltyCardSetGenerateType> LoyaltyCardSetGenerateTypes { get; set; }
        public DbSet<LoyaltyCardSet> LoyaltyCardSets { get; set; }
        public DbSet<LoyaltyProgram> LoyaltyPrograms { get; set; }
        public DbSet<LoyaltyProgramRule> LoyaltyProgramRules { get; set; }

        public DbSet<LoyaltyRuleGroup> LoyaltyRuleGroups { get; set; }
        public DbSet<LoyaltyRule> LoyaltyRules { get; set; }
        public DbSet<LoyaltyRuleTrigger> LoyaltyRuleTriggers { get; set; }
        
        public DbSet<LoyaltyRuleAction> LoyaltyRuleActions { get; set; }
        public DbSet<LoyaltyRuleCondition> LoyaltyRuleConditions { get; set; }
        public DbSet<LoyaltyRuleConditionType> LoyaltyRuleConditionTypes { get; set; }
        
        public DbSet<LoyaltyRuleConditionValue> LoyaltyRuleConditionValues { get; set; }
        public DbSet<LoyaltyRuleConditionProductGroup> LoyaltyRuleConditionProductGroups { get; set; }
        public DbSet<LoyaltyRuleConditionProduct> LoyaltyRuleConditionProducts { get; set; }
        

        public DbSet<LoyaltyRuleType> LoyaltyRuleTypes { get; set; }
        public DbSet<LoyaltyTier> LoyaltyTiers { get; set; }
        public DbSet<LoyaltyTriggerType> LoyaltyTriggerTypes { get; set; }
        public DbSet<LoyaltyTrigger> LoyaltyTriggers { get; set; }
        public DbSet<LoyaltyValueType> LoyaltyValueTypes { get; set; }
        public DbSet<LoyaltyValueTypeAttribute> LoyaltyValueTypeAttributes { get; set; }
        public DbSet<LoyaltyProgramGroup> LoyaltyProgramGroups { get; set; }
        #endregion

        #region Identity
        public DbSet<ApplicationOwner> ApplicationOwners { get; set; }
        public DbSet<DataOwner> DataOwners { get; set; }
        public DbSet<DataOwnerCenter> DataOwnerCenters { get; set; }
        public DbSet<AnatoliAccount> AnatoliAccounts { get; set; }
        public DbSet<AnatoliContact> AnatoliContacts { get; set; }
        public DbSet<AnatoliContactType> AnatoliContactTypes { get; set; }
        public DbSet<AnatoliPlace> AnatoliPlaces { get; set; }
        public DbSet<AnatoliRegion> AnatoliRegions { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<IdentityUserRole> UserRoles { get; set; }
        public DbSet<Principal> Principals { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionCatalog> PermissionCatalogs { get; set; }
        public DbSet<PermissionAction> PermissionActions { get; set; }
        public DbSet<ApplicationModuleResource> ApplicationModuleResources { get; set; }
        public DbSet<ApplicationModule> ApplicationModules { get; set; }
        public DbSet<PrincipalPermission> PrincipalPermissions { get; set; }
        #endregion

        #endregion

        #region ctors

        public AnatoliDbContext()
            : base("Name=LoyaltyConnectionString")
        {
        }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public static AnatoliDbContext Create()
        {
            return new AnatoliDbContext();
        }
    }
}
