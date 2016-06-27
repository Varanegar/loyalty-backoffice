using System;
using System.Threading.Tasks;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;
using Loyalty.DataAccess.Models.Account;
using System.Collections.Generic;

namespace Loyalty.Business.Domain
{
    public class CustomerGroupDomain : BusinessDomainV3<CustomerGroup>, IBusinessDomainV3<CustomerGroup>
    {
        #region Ctors
        public CustomerGroupDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public CustomerGroupDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(CustomerGroup currentCustomerGroup, CustomerGroup item)
        {
            if (currentCustomerGroup != null)
            {
                if (currentCustomerGroup.GroupName != item.GroupName ||
                    currentCustomerGroup.NLeft != item.NLeft ||
                    currentCustomerGroup.NRight != item.NRight ||
                    currentCustomerGroup.NLevel != item.NLevel )
                {
                    currentCustomerGroup.LastUpdate = DateTime.Now;
                    currentCustomerGroup.GroupName = item.GroupName;
                    currentCustomerGroup.NLeft = item.NLeft;
                    currentCustomerGroup.NRight = item.NRight;
                    currentCustomerGroup.NLevel = item.NLevel;
                    MainRepository.Update(currentCustomerGroup);
                }
            }
            else
            {
                if (item.ParentId == Guid.Empty) item.ParentId = null;
                item.Id = Guid.NewGuid();
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }

        public async Task DeleteCustomerGroups(List<CustomerGroup> customerGroups)
        {
            //Validate

            await DeleteAsync(customerGroups);
        }
 
        
        
        public override void SetConditionForFetchingData()
        {
            MainRepository.ExtraPredicate = p => true;
        }
        #endregion
    }
}
