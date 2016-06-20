using System;
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
                if (currentCustomer.CustomerCode != item.CustomerCode ||
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
                        currentCustomer.NationalCode != item.NationalCode)
                {
                    currentCustomer.CustomerCode = item.CustomerCode;
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

        #endregion
    }
}

