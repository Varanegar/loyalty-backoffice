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
    public class CustomerTagDomain : BusinessDomainV3<CustomerTag>, IBusinessDomainV3<CustomerTag>
    {
        #region Ctors
        public CustomerTagDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public CustomerTagDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(CustomerTag currentCustomerTag, CustomerTag item)
        {
            if (currentCustomerTag != null)
            {
                if (currentCustomerTag.TagName != item.TagName ||
                    currentCustomerTag.NLeft != item.NLeft ||
                    currentCustomerTag.NRight != item.NRight ||
                    currentCustomerTag.NLevel != item.NLevel )
                {
                    currentCustomerTag.LastUpdate = DateTime.Now;
                    currentCustomerTag.TagName = item.TagName;
                    currentCustomerTag.NLeft = item.NLeft;
                    currentCustomerTag.NRight = item.NRight;
                    currentCustomerTag.NLevel = item.NLevel;
                    MainRepository.Update(currentCustomerTag);
                }
            }
            else
            {
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }

     
        public async Task DeleteCustomerTags(List<CustomerTag> datas)
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
