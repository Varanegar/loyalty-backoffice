using System;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;
using Loyalty.DataAccess.Models.Account;

namespace Loyalty.Business.Domain.Customer
{
    public class CustomerLoyaltyTierHistoryDomain : BusinessDomainV3<CustomerLoyaltyTierHistory>, IBusinessDomainV3<CustomerLoyaltyTierHistory>
    {
        #region Ctors
        public CustomerLoyaltyTierHistoryDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public CustomerLoyaltyTierHistoryDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(CustomerLoyaltyTierHistory currentCustomerLoyaltyTierHistory, CustomerLoyaltyTierHistory item)
        {
            if (currentCustomerLoyaltyTierHistory != null)
            {
                if (currentCustomerLoyaltyTierHistory.IsRemoved != item.IsRemoved)
                {
                    currentCustomerLoyaltyTierHistory.LastUpdate = DateTime.Now;
                    currentCustomerLoyaltyTierHistory.IsRemoved = item.IsRemoved;
                    MainRepository.Update(currentCustomerLoyaltyTierHistory);
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
