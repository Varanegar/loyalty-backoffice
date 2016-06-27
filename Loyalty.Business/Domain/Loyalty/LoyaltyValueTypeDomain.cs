using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;

namespace Loyalty.Business.Domain.Loyalty
{
    public class LoyaltyValueTypeDomain : BusinessDomainV3<LoyaltyValueType>, IBusinessDomainV3<LoyaltyValueType>
    {
        #region Ctors
        public LoyaltyValueTypeDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyValueTypeDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyValueType currentLoyaltyValueType, LoyaltyValueType item)
        {
            if (currentLoyaltyValueType != null)
            {
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }

        public async Task DeleteLoyaltyTiers(List<LoyaltyValueType> datas)
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
