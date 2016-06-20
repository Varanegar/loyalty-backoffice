﻿using System;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;
using Loyalty.DataAccess.Models.Account;

namespace Loyalty.Business.Domain.Customer
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
                    currentCustomerGroup.NLevel != item.NLevel ||
                    currentCustomerGroup.CustomerGroup2Id != item.CustomerGroup2Id)
                {
                    currentCustomerGroup.LastUpdate = DateTime.Now;
                    currentCustomerGroup.GroupName = item.GroupName;
                    currentCustomerGroup.NLeft = item.NLeft;
                    currentCustomerGroup.NRight = item.NRight;
                    currentCustomerGroup.NLevel = item.NLevel;
                    currentCustomerGroup.CustomerGroup2Id = item.CustomerGroup2Id;
                    MainRepository.Update(currentCustomerGroup);
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
