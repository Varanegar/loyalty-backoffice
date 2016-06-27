using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;
using Loyalty.DataAccess.Models.Account;

namespace Loyalty.Business.Domain
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
       public async Task  DeleteCustomer(List<CustomerLoyaltyTierHistory> datas)
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
