using System;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;

namespace Loyalty.Business.Domain.Loyalty
{
    public class LoyaltyRuleConditionTypeDomain : BusinessDomainV3<LoyaltyRuleConditionType>, IBusinessDomainV3<LoyaltyRuleConditionType>
    {
        #region Ctors
        public LoyaltyRuleConditionTypeDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyRuleConditionTypeDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyRuleConditionType currentLoyaltyRuleConditionType, LoyaltyRuleConditionType item)
        {
            if (currentLoyaltyRuleConditionType != null)
            {
                if (currentLoyaltyRuleConditionType.IsRemoved != item.IsRemoved)
                {
                    currentLoyaltyRuleConditionType.LastUpdate = DateTime.Now;
                    currentLoyaltyRuleConditionType.IsRemoved = item.IsRemoved;
                    MainRepository.Update(currentLoyaltyRuleConditionType);
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
