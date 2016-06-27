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
    public class CustomerNonMonetaryHistoryDomain : BusinessDomainV3<CustomerNonMonetaryHistory>, IBusinessDomainV3<CustomerNonMonetaryHistory>
    {
        #region Ctors
        public CustomerNonMonetaryHistoryDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public CustomerNonMonetaryHistoryDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(CustomerNonMonetaryHistory current, CustomerNonMonetaryHistory item)
        {
            if (current != null)
            {
                if (current.CustomerId != item.CustomerId ||
                    current.UserId != item.UserId ||
                    current.ActivityPDate != item.ActivityPDate ||
                    current.ActivityDesc != item.ActivityDesc ||
                    current.PlaceDesc != item.PlaceDesc ||
                    current.TerminalDesc != item.TerminalDesc ||
                    current.Description != item.Description)
                {
                    current.LastUpdate = DateTime.Now;
                    current.CustomerId = item.CustomerId;
                    current.UserId = item.UserId;
                    current.ActivityDate = item.ActivityDate;
                    current.ActivityPDate = item.ActivityPDate;
                    current.ActivityDesc = item.ActivityDesc;
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


        public async Task DeleteHistory(List<CustomerNonMonetaryHistory> datas)
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
