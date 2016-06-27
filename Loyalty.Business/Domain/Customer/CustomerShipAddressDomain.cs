using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Anatoli.ViewModels.CustomerModels;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;
using Loyalty.DataAccess.Models.Account;

namespace Loyalty.Business.Domain
{
    public class CustomerShipAddressDomain : BusinessDomainV3<CustomerShipAddress>, IBusinessDomainV3<CustomerShipAddress>
    {
        #region Properties
        #endregion

        #region Ctors
        public CustomerShipAddressDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public CustomerShipAddressDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public async Task<ICollection<CustomerShipAddressViewModel>> GetCustomerShipAddressById(Guid customerId, bool? isDetault, bool? isActive)
        {
            ICollection<CustomerShipAddressViewModel> customerShipAddresses = null;
            if (isDetault == null && isActive == null)
                customerShipAddresses = await GetAllAsync<CustomerShipAddressViewModel>(p => p.CustomerId == customerId);
            else if (isDetault == true)
                customerShipAddresses = await GetAllAsync<CustomerShipAddressViewModel>(p => p.CustomerId == customerId && p.IsDefault);
            else if (isActive == true)
                customerShipAddresses = await GetAllAsync<CustomerShipAddressViewModel>(p => p.CustomerId == customerId && p.IsActive);

            return customerShipAddresses;
        }
        public async Task<ICollection<CustomerShipAddressViewModel>> GetCustomerShipAddressByLevel4(Guid customerId, Guid levelId)
        {
            return await GetAllAsync<CustomerShipAddressViewModel>(p => p.CustomerId == customerId && p.RegionLevel4Id == levelId);
        }
        public override void AddDataToRepository(CustomerShipAddress currentCustomerShipAddress, CustomerShipAddress item)
        {
            if (item.Id == null || item.Id == Guid.Empty)
                item.Id = Guid.NewGuid();

            if (currentCustomerShipAddress != null)
            {
                currentCustomerShipAddress.Phone = item.Phone;
                currentCustomerShipAddress.AddressName = item.AddressName;
                currentCustomerShipAddress.Email = item.Email;
                currentCustomerShipAddress.MainStreet = item.MainStreet;
                currentCustomerShipAddress.OtherStreet = item.OtherStreet;
                currentCustomerShipAddress.Mobile = item.Mobile;
                currentCustomerShipAddress.PostalCode = item.PostalCode;
                currentCustomerShipAddress.LastUpdate = DateTime.Now;
                currentCustomerShipAddress.RegionInfoId = item.RegionInfoId;
                currentCustomerShipAddress.RegionLevel1Id = item.RegionLevel1Id;
                currentCustomerShipAddress.RegionLevel2Id = item.RegionLevel2Id;
                currentCustomerShipAddress.RegionLevel3Id = item.RegionLevel3Id;
                currentCustomerShipAddress.RegionLevel4Id = item.RegionLevel4Id;
                currentCustomerShipAddress.MainStreet = item.MainStreet;
                currentCustomerShipAddress.OtherStreet = item.OtherStreet;
                currentCustomerShipAddress.Lat = item.Lat;
                currentCustomerShipAddress.Lng = item.Lng;
                currentCustomerShipAddress.CustomerId = item.CustomerId;
                currentCustomerShipAddress.IsActive = item.IsActive;
                currentCustomerShipAddress.IsDefault = item.IsDefault;
                currentCustomerShipAddress.Transferee = item.Transferee;
                MainRepository.Update(currentCustomerShipAddress);
            }
            else
            {
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }

        public async Task DeleteCustomerShipAddress(List<CustomerShipAddress> datas)
        {
            //Validate

            await DeleteAsync(datas);
        }


        #endregion
    }
}
