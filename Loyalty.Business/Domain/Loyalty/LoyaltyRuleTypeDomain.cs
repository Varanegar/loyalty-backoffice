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
    public class LoyaltyRuleTypeDomain : BusinessDomainV3<LoyaltyRuleType>, IBusinessDomainV3<LoyaltyRuleType>
    {
        #region Ctors
        public LoyaltyRuleTypeDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyRuleTypeDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyRuleType currentLoyaltyRuleType, LoyaltyRuleType item)
        {
            if (currentLoyaltyRuleType != null)
            {
               
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }

        public async Task DeleteLoyaltyRuleTypes(List<LoyaltyRuleType> datas)
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
