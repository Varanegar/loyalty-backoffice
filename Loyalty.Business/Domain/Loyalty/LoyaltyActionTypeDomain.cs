using System;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;

namespace Loyalty.Business.Domain.Loyalty
{
    public class LoyaltyActionTypeDomain : BusinessDomainV3<LoyaltyActionType>, IBusinessDomainV3<LoyaltyActionType>
    {
        #region Ctors
        public LoyaltyActionTypeDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyActionTypeDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyActionType currentLoyaltyActionType, LoyaltyActionType item)
        {
            if (currentLoyaltyActionType != null)
            {
                if (currentLoyaltyActionType.IsRemoved != item.IsRemoved)
                {
                    currentLoyaltyActionType.LastUpdate = DateTime.Now;
                    currentLoyaltyActionType.IsRemoved = item.IsRemoved;
                    MainRepository.Update(currentLoyaltyActionType);
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
