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
    public class LoyaltyTriggerTypeDomain : BusinessDomainV3<LoyaltyTriggerType>, IBusinessDomainV3<LoyaltyTriggerType>
    {
        #region Ctors
        public LoyaltyTriggerTypeDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyTriggerTypeDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyTriggerType currentLoyaltyTriggerType, LoyaltyTriggerType item)
        {
            if (currentLoyaltyTriggerType != null)
            {
                currentLoyaltyTriggerType.LastUpdate = DateTime.Now;
                currentLoyaltyTriggerType.LoyaltyTriggerTypeCode = item.LoyaltyTriggerTypeCode;
                currentLoyaltyTriggerType.LoyaltyTriggerTypeName = item.LoyaltyTriggerTypeName;
                MainRepository.Update(currentLoyaltyTriggerType);
            }
            else
            {
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }

        public async Task DeleteLoyaltyTriggerType(List<LoyaltyTriggerType> datas)
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
