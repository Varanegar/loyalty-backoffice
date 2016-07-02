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
    public class LoyaltyRuleDomain : BusinessDomainV3<LoyaltyRule>, IBusinessDomainV3<LoyaltyRule>
    {
        #region Ctors
        public LoyaltyRuleDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyRuleDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyRule currentLoyaltyRule, LoyaltyRule item)
        {
            foreach (var trigger in item.LoyaltyRuleTriggers)
            {
                if (trigger.Id == Guid.Empty)
                    trigger.Id = Guid.NewGuid();
                trigger.CreatedDate = trigger.LastUpdate = DateTime.Now;
                trigger.DataOwnerId = item.DataOwnerId;
                trigger.DataOwnerCenterId = item.DataOwnerCenterId;
                trigger.ApplicationOwnerId = item.ApplicationOwnerId;

            }

            if (currentLoyaltyRule != null)
            {
                currentLoyaltyRule.LastUpdate = DateTime.Now;
                currentLoyaltyRule.LoyaltyRuleCode = item.LoyaltyRuleCode;
                currentLoyaltyRule.LoyaltyRuleName = item.LoyaltyRuleName;
                currentLoyaltyRule.Description = item.Description;
                currentLoyaltyRule.HasCondition = item.HasCondition;
                currentLoyaltyRule.LoyaltyRuleGroupId = item.LoyaltyRuleGroupId;
                currentLoyaltyRule.LoyaltyRuleTypeId = item.LoyaltyRuleTypeId;
                currentLoyaltyRule.LoyaltyRuleTriggers = item.LoyaltyRuleTriggers;

                MainRepository.Update(currentLoyaltyRule);
            }
            else
            {
                if (item.Id == Guid.Empty)
                    item.Id = Guid.NewGuid();
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }

        public async Task DeleteLoyaltyRules(List<LoyaltyRule> datas)
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
