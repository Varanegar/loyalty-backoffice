using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models.Loyalty;

namespace Loyalty.Business.Domain.Loyalty
{
    public class LoyaltyRuleConditionDomain : BusinessDomainV3<LoyaltyRuleCondition>, IBusinessDomainV3<LoyaltyRuleCondition>
    {
        #region Ctors
        public LoyaltyRuleConditionDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyRuleConditionDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyRuleCondition currentLoyaltyRuleCondition, LoyaltyRuleCondition item)
        {
            foreach (var trigger in item.LoyaltyRuleConditionProducts)
            {
                if (trigger.Id == Guid.Empty)
                    trigger.Id = Guid.NewGuid();
                trigger.CreatedDate = trigger.LastUpdate = DateTime.Now;
                trigger.DataOwnerId = item.DataOwnerId;
                trigger.DataOwnerCenterId = item.DataOwnerCenterId;
                trigger.ApplicationOwnerId = item.ApplicationOwnerId;

            }
            foreach (var trigger in item.LoyaltyRuleConditionProductGroups)
            {
                if (trigger.Id == Guid.Empty)
                    trigger.Id = Guid.NewGuid();
                trigger.CreatedDate = trigger.LastUpdate = DateTime.Now;
                trigger.DataOwnerId = item.DataOwnerId;
                trigger.DataOwnerCenterId = item.DataOwnerCenterId;
                trigger.ApplicationOwnerId = item.ApplicationOwnerId;

            }
            foreach (var trigger in item.LoyaltyRuleConditionValues)
            {
                if (trigger.Id == Guid.Empty)
                    trigger.Id = Guid.NewGuid();
                trigger.CreatedDate = trigger.LastUpdate = DateTime.Now;
                trigger.DataOwnerId = item.DataOwnerId;
                trigger.DataOwnerCenterId = item.DataOwnerCenterId;
                trigger.ApplicationOwnerId = item.ApplicationOwnerId;

            }

            
            if (currentLoyaltyRuleCondition != null)
            {
                currentLoyaltyRuleCondition.LastUpdate = DateTime.Now;
                currentLoyaltyRuleCondition.LoyaltyValueTypeAttributeId = item.LoyaltyValueTypeAttributeId;
                currentLoyaltyRuleCondition.LoyaltyRuleConditionProductGroups = item.LoyaltyRuleConditionProductGroups;
                currentLoyaltyRuleCondition.LoyaltyRuleConditionProducts = item.LoyaltyRuleConditionProducts;
                currentLoyaltyRuleCondition.LoyaltyRuleConditionValues = item.LoyaltyRuleConditionValues;
                MainRepository.Update(currentLoyaltyRuleCondition);
            }
            else
            {
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }
        public async Task DeleteRuleConditions(List<LoyaltyRuleCondition> datas)
        {
            //Validate

            await DeleteAsync(datas);
        }

        public override void SetConditionForFetchingData()
        {
            MainRepository.ExtraPredicate = p => true;
        }
        #endregion
    }
}
