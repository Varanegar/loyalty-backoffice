using System;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;

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
            if (currentLoyaltyRuleCondition != null)
            {
                if (currentLoyaltyRuleCondition.IsRemoved != item.IsRemoved)
                {
                    currentLoyaltyRuleCondition.LastUpdate = DateTime.Now;
                    currentLoyaltyRuleCondition.IsRemoved = item.IsRemoved;
                    MainRepository.Update(currentLoyaltyRuleCondition);
                }
            }
            else
            {
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }

        public override void SetConditionForFetchingData()
        {
            MainRepository.ExtraPredicate = p => true;
        }
        #endregion
    }
}
