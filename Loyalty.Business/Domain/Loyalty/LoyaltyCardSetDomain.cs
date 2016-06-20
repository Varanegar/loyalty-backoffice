using System;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;
using Loyalty.DataAccess.Models.Loyalty;

namespace Loyalty.Business.Domain.Loyalty
{
    public class LoyaltyCardSetDomain : BusinessDomainV3<LoyaltyCardSet>, IBusinessDomainV3<LoyaltyCardSet>
    {
        #region Ctors
        public LoyaltyCardSetDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyCardSetDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyCardSet currentLoyaltyCardSet, LoyaltyCardSet item)
        {
            if (currentLoyaltyCardSet != null)
            {
                if (currentLoyaltyCardSet.IsRemoved != item.IsRemoved)
                {
                    currentLoyaltyCardSet.LastUpdate = DateTime.Now;
                    currentLoyaltyCardSet.IsRemoved = item.IsRemoved;
                    MainRepository.Update(currentLoyaltyCardSet);
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
