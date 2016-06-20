using System;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;

namespace Loyalty.Business.Domain.Loyalty
{
    public class LoyaltyProgramRuleDomain : BusinessDomainV3<LoyaltyProgramRule>, IBusinessDomainV3<LoyaltyProgramRule>
    {
        #region Ctors
        public LoyaltyProgramRuleDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyProgramRuleDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyProgramRule currentLoyaltyProgramRule, LoyaltyProgramRule item)
        {
            if (currentLoyaltyProgramRule != null)
            {
                if (currentLoyaltyProgramRule.IsRemoved != item.IsRemoved)
                {
                    currentLoyaltyProgramRule.LastUpdate = DateTime.Now;
                    currentLoyaltyProgramRule.IsRemoved = item.IsRemoved;
                    MainRepository.Update(currentLoyaltyProgramRule);
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
