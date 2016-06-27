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
    public class LoyaltyCardBatchDomain : BusinessDomainV3<LoyaltyCardBatch>, IBusinessDomainV3<LoyaltyCardBatch>
    {
        #region Ctors
        public LoyaltyCardBatchDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyCardBatchDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyCardBatch currentLoyaltyCardBatch, LoyaltyCardBatch item)
        {
            if (currentLoyaltyCardBatch != null)
            {
                    currentLoyaltyCardBatch.LastUpdate = DateTime.Now;
                    currentLoyaltyCardBatch.BatchGenerateDate = item.BatchGenerateDate;
                    currentLoyaltyCardBatch.BatchGeneratePDate = item.BatchGeneratePDate;
                    MainRepository.Update(currentLoyaltyCardBatch);
            }
            else
            {
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }

        public async Task DeleteCustomerTags(List<LoyaltyCardBatch> datas)
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
