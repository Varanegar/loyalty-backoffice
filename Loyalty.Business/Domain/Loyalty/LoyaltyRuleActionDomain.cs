using System;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;

namespace Loyalty.Business.Domain.Loyalty
{
    public class LoyaltyRuleActionDomain : BusinessDomainV3<LoyaltyRuleAction>, IBusinessDomainV3<LoyaltyRuleAction>
    {
        #region Ctors
        public LoyaltyRuleActionDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyRuleActionDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyRuleAction currentLoyaltyRuleAction, LoyaltyRuleAction item)
        {
            if (currentLoyaltyRuleAction != null)
            {
                if (currentLoyaltyRuleAction.IsRemoved != item.IsRemoved)
                {
                    currentLoyaltyRuleAction.LastUpdate = DateTime.Now;
                    currentLoyaltyRuleAction.IsRemoved = item.IsRemoved;
                    MainRepository.Update(currentLoyaltyRuleAction);
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
