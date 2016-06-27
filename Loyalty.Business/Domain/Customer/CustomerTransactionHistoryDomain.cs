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
    public class CustomerTransactionHistoryDomain : BusinessDomainV3<CustomerTransactionHistory>, IBusinessDomainV3<CustomerTransactionHistory>
    {
        #region Ctors
        public CustomerTransactionHistoryDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public CustomerTransactionHistoryDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(CustomerTransactionHistory current, CustomerTransactionHistory item)
        {
            if (current != null)
            {
                if (current.CustomerId != item.CustomerId ||
                    current.LoyaltyValueTypeId != item.LoyaltyValueTypeId ||
                    current.TransactionDate != item.TransactionDate ||
                    current.TransactionPDate != item.TransactionPDate ||
                    current.IncreaseValue != item.IncreaseValue ||
                    current.DecreaseValue != item.DecreaseValue ||
                    current.Description != item.Description)
                {
                    current.LastUpdate = DateTime.Now;
                    current.CustomerId = item.CustomerId;
                    current.LoyaltyValueTypeId = item.LoyaltyValueTypeId;
                    current.TransactionDate = item.TransactionDate;
                    current.TransactionPDate = item.TransactionPDate;
                    current.IncreaseValue = item.IncreaseValue;
                    current.DecreaseValue = item.DecreaseValue;
                    current.Description = item.Description;
                    
                    MainRepository.Update(current);
                }
            }
            else
            {
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }


        public async Task DeleteHistory(List<CustomerTransactionHistory> datas)
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
