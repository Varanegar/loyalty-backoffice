using System;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;

namespace Loyalty.Business.Domain.Loyalty
{
    public class LoyaltyTierDomain : BusinessDomainV3<LoyaltyTier>, IBusinessDomainV3<LoyaltyTier>
    {
        #region Ctors
        public LoyaltyTierDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyTierDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyTier currentLoyaltyTier, LoyaltyTier item)
        {
            if (currentLoyaltyTier != null)
            {
                if (currentLoyaltyTier.IsRemoved != item.IsRemoved)
                {
                    currentLoyaltyTier.LastUpdate = DateTime.Now;
                    currentLoyaltyTier.IsRemoved = item.IsRemoved;
                    MainRepository.Update(currentLoyaltyTier);
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
