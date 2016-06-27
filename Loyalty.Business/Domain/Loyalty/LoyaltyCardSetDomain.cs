using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }

        public async Task DeleteLoyaltyCardSets(List<LoyaltyCardSet> datas)
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
