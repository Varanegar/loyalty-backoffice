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
                currentLoyaltyActionType.LastUpdate = DateTime.Now;
                currentLoyaltyActionType.LoyaltyActionTypeName = item.LoyaltyActionTypeName;
                currentLoyaltyActionType.LoyaltyActionTypeCode = item.LoyaltyActionTypeCode;
                MainRepository.Update(currentLoyaltyActionType);
            }
            else
            {
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }
        public async Task Delete(List<LoyaltyActionType> datas)
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
