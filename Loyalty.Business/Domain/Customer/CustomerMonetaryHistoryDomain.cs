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
    public class CustomerMonetaryHistoryDomain : BusinessDomainV3<CustomerMonetaryHistory>, IBusinessDomainV3<CustomerMonetaryHistory>
    {
        #region Ctors
        public CustomerMonetaryHistoryDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public CustomerMonetaryHistoryDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(CustomerMonetaryHistory current, CustomerMonetaryHistory item)
        {
            if (current != null)
            {
                if (current.CustomerId != item.CustomerId ||
                    current.UserId != item.UserId ||
                    current.TransactionDate != item.TransactionDate ||
                    current.TransactionPDate != item.TransactionPDate ||
                    current.TransactionDesc != item.TransactionDesc ||
                    current.Amount != item.Amount ||
                    current.NetAmount != item.NetAmount ||
                    current.Discount != item.Discount ||
                    current.PlaceDesc != item.PlaceDesc ||
                    current.TerminalDesc != item.TerminalDesc ||
                    current.Description != item.Description)
                {
                    current.LastUpdate = DateTime.Now;
                    current.CustomerId = item.CustomerId;
                    current.UserId = item.UserId;
                    current.TransactionDate = item.TransactionDate;
                    current.TransactionPDate = item.TransactionPDate;
                    current.TransactionDesc = item.TransactionDesc;
                    current.Amount = item.Amount;
                    current.NetAmount = item.NetAmount;
                    current.Discount = item.Discount;
                    current.PlaceDesc = item.PlaceDesc;
                    current.TerminalDesc = item.TerminalDesc;
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


        public async Task DeleteHistory(List<CustomerMonetaryHistory> datas)
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
