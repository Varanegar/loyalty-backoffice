using System;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;
using Anatoli.DataAccess.Interfaces;
using Anatoli.ViewModels.BaseModels;
using Loyalty.DataAccess.Repositories;
using System.Linq.Expressions;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.Business.Domain
{
    public class LoyaltyCardDomain : BusinessDomainV3<LoyaltyCard>, IBusinessDomainV3<LoyaltyCard>
    {
        #region Ctors
        public LoyaltyCardDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyCardDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyCard currentLoyaltyCard, LoyaltyCard item)
        {
            if (currentLoyaltyCard != null)
            {
                if (currentLoyaltyCard.IsRemoved != item.IsRemoved)
                {
                    currentLoyaltyCard.LastUpdate = DateTime.Now;
                    currentLoyaltyCard.IsRemoved = item.IsRemoved;
                    MainRepository.Update(currentLoyaltyCard);
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
