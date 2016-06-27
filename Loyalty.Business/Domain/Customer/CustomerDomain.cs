﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models.Account;

namespace Loyalty.Business.Domain
{
    public class CustomerDomain : BusinessDomainV3<Customer>, IBusinessDomainV3<Customer>
    {
        #region Properties
        #endregion

        #region Ctors
        public CustomerDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public CustomerDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(Customer currentCustomer, Customer item)
        {
            if (currentCustomer != null)
            {
                if (
                        currentCustomer.CustomerName != item.CustomerName ||
                        currentCustomer.FirstName != item.FirstName ||
                        currentCustomer.LastName != item.LastName ||
                        currentCustomer.Phone != item.Phone ||
                        currentCustomer.Email != item.Email ||
                        currentCustomer.MainStreet != item.MainStreet ||
                        currentCustomer.OtherStreet != item.OtherStreet ||
                        currentCustomer.BirthDay != item.BirthDay ||
                        currentCustomer.Mobile != item.Mobile ||
                        currentCustomer.RegionInfoId != item.RegionInfoId ||
                        currentCustomer.RegionLevel1Id != item.RegionLevel1Id ||
                        currentCustomer.RegionLevel2Id != item.RegionLevel2Id ||
                        currentCustomer.RegionLevel3Id != item.RegionLevel3Id ||
                        currentCustomer.RegionLevel4Id != item.RegionLevel4Id ||
                        currentCustomer.PostalCode != item.PostalCode ||
                        currentCustomer.NationalCode != item.NationalCode ||
                        currentCustomer.CustomerType != item.CustomerType ||
                        currentCustomer.CompanyId != item.CompanyId ||
                        currentCustomer.MarriageDate != item.MarriageDate ||
                        currentCustomer.GraduateDate != item.GraduateDate ||
                        currentCustomer.ReagentId != item.ReagentId ||
                        currentCustomer.GetNews != item.GetNews ||
                        currentCustomer.GetMessage != item.GetMessage 
                    )
                {
                    currentCustomer.CustomerName = item.CustomerName;
                    currentCustomer.FirstName = item.FirstName;
                    currentCustomer.LastName = item.LastName;
                    currentCustomer.Phone = item.Phone;
                    currentCustomer.Email = item.Email;
                    currentCustomer.MainStreet = item.MainStreet;
                    currentCustomer.OtherStreet = item.OtherStreet;
                    currentCustomer.BirthDay = item.BirthDay;
                    currentCustomer.Mobile = item.Mobile;
                    currentCustomer.PostalCode = item.PostalCode;
                    currentCustomer.NationalCode = item.NationalCode;
                    currentCustomer.LastUpdate = DateTime.Now;
                    currentCustomer.RegionInfoId = item.RegionInfoId;
                    currentCustomer.RegionLevel1Id = item.RegionLevel1Id;
                    currentCustomer.RegionLevel2Id = item.RegionLevel2Id;
                    currentCustomer.RegionLevel3Id = item.RegionLevel3Id;
                    currentCustomer.RegionLevel4Id = item.RegionLevel4Id;
                    currentCustomer.CustomerType = item.CustomerType;
                    currentCustomer.CompanyId = item.CompanyId;
                    currentCustomer.MarriageDate = item.MarriageDate;
                    currentCustomer.GraduateDate = item.GraduateDate;
                    currentCustomer.ReagentId = item.ReagentId;
                    currentCustomer.GetNews = item.GetNews;
                    currentCustomer.GetMessage = item.GetMessage;
                    currentCustomer.CompanyId = item.CompanyId;
                    currentCustomer.LastUpdate = DateTime.Now;

                    MainRepository.Update(currentCustomer);
                }
            }
            else
            {
                if (item.Id == null || item.Id == Guid.Empty)
                    item.Id = Guid.NewGuid();
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }

        public async Task  DeleteCustomer(List<Customer> customers)
        {
            //Validate

            await DeleteAsync(customers);
        }
        #endregion
    }
}

