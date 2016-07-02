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
            if (currentLoyaltyRule != null)
            {
                if (currentLoyaltyRule.IsRemoved != item.IsRemoved)
                {
                    currentLoyaltyRule.LastUpdate = DateTime.Now;
                    currentLoyaltyRule.IsRemoved = item.IsRemoved;
                    MainRepository.Update(currentLoyaltyRule);
                }
            }
            else
            {
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
