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
    public class LoyaltyTriggerDomain : BusinessDomainV3<LoyaltyTrigger>, IBusinessDomainV3<LoyaltyTrigger>
    {
        #region Ctors
        public LoyaltyTriggerDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyTriggerDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyTrigger currentLoyaltyTrigger, LoyaltyTrigger item)
        {
            if (currentLoyaltyTrigger != null)
            {
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }

        public async Task DeleteLoyaltyTrigger(List<LoyaltyTrigger> datas)
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
