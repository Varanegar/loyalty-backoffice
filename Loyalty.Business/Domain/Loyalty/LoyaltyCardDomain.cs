using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;

namespace Loyalty.Business.Domain.Loyalty
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
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
            else{
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }

        public async Task DeleteLoyaltyCards(List<LoyaltyCard> datas)
        {
            //Validate

            await DeleteAsync(datas);
        }


        public async Task ChangeStatusLoyaltyCard(Guid uniqueId, Guid statisId)
        {
            //Validate
            var item = await GetByIdAsync<LoyaltyCard>(uniqueId);
            item.CreatedDate = item.LastUpdate = DateTime.Now;
            item.LoyaltyCardStatusId = statisId;
            MainRepository.Update(item);
        }

        public async Task AllocateLoyaltyCard(Guid uniqueId, Guid customerId)
        {
            //Validate
            var item = await GetByIdAsync<LoyaltyCard>(uniqueId);
            item.CreatedDate = item.LastUpdate = DateTime.Now;
            item.CustomerId = customerId;
            MainRepository.Update(item);
        }
        public async Task DeAllocateLoyaltyCard(Guid uniqueId)
        {
            //Validate
            var item = await GetByIdAsync<LoyaltyCard>(uniqueId);
            item.CreatedDate = item.LastUpdate = DateTime.Now;
            item.CustomerId = null;
            MainRepository.Update(item);
        }

        public override void SetConditionForFetchingData()
        {
            MainRepository.ExtraPredicate = p => true;
        }
        #endregion
    }
}
