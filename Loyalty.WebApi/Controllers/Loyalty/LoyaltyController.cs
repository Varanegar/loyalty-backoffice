using Anatoli.Business.Domain;
using Anatoli.DataAccess;
using Anatoli.ViewModels.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using Loyalty.DataAccess.Models.Account;
using Microsoft.AspNet.Identity.Owin;
using Anatoli.ViewModels;
using Loyalty.WebApi.Classes;
using Loyalty.Business.Domain;
using Loyalty.DataAccess.Repositories;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;
using Anatoli.Common.WebApi;

namespace Anatoli.Cloud.WebApi.Controllers
{
    [RoutePrefix("api/loyalty")]
    public class LoyaltyCardController : AnatoliApiController
    {
        #region Customer
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("cardsets")]
        [HttpPost]
        public async Task<IHttpActionResult> GetLoyaltyCards([FromBody]CustomerRequestModel data)
        {
            try
            {
                var result = await new CustomerDomain(OwnerInfo).GetByIdAsync<CustomerViewModel>(data.customerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "DataSync")]
        [Route("cardsets/save")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveLoyaltyCards([FromBody]CustomerRequestModel data)
        {
            try
            {
                var customerDomain = new CustomerDomain(OwnerInfo);
                data.customerListData.ForEach(p =>
                    {
                        p.CompanyId = DataOwnerKey;
                    });
                await customerDomain.PublishAsync(AutoMapper.Mapper.Map<Customer>(data.customerListData));

                return Ok(data.customerListData);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }
        #endregion

        #region Customer Ship Address
        [Authorize(Roles = "User")]
        [Route("customershipaddresses/active")]
        [HttpPost]
        public async Task<IHttpActionResult> GetActiveCustomerShipAddressByCustomerId([FromBody]CustomerRequestModel data)
        {
            try
            {
                var result = await new CustomerShipAddressDomain(OwnerInfo).GetCustomerShipAddressById(data.customerId, null, true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "User")]
        [Route("customershipaddresses/default")]
        [HttpPost]
        public async Task<IHttpActionResult> GetDefaultCustomerShipAddressByCustomerId([FromBody]CustomerRequestModel data)
        {
            try
            {
                var result = await new CustomerShipAddressDomain(OwnerInfo).GetCustomerShipAddressById(data.customerId, true, null);
                return Ok(result.FirstOrDefault());
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "User")]
        [Route("customershipaddresses")]
        [HttpPost]
        public async Task<IHttpActionResult> GetCustomerShipAddressByCustomerId([FromBody]CustomerRequestModel data)
        {
            try
            {
                var result = await new CustomerShipAddressDomain(OwnerInfo).GetCustomerShipAddressById(data.customerId, null, null);
                return Ok(result.ToList());
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("customershipaddresses/region")]
        [HttpPost]
        public async Task<IHttpActionResult> GetCustomerShipAddressByCustomerIdByLevel4([FromBody]CustomerRequestModel data)
        {
            try
            {
                var result = await new CustomerShipAddressDomain(OwnerInfo).GetCustomerShipAddressByLevel4(data.customerId, data.regionId);
                return Ok(result.ToList());
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "DataSync, User")]
        [Route("customershipaddress/savesingle")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveSingleCustomerShipAddress([FromBody]CustomerRequestModel data)
        {
            try
            {
                List<CustomerShipAddressViewModel> dataList = new List<CustomerShipAddressViewModel>();
                if (data.customerShipAddressData.UniqueId == Guid.Empty) data.customerShipAddressData.UniqueId = Guid.NewGuid();
                dataList.Add(data.customerShipAddressData);
                await new CustomerShipAddressDomain(OwnerInfo).PublishAsync(AutoMapper.Mapper.Map<CustomerShipAddress>(dataList));
                return Ok(dataList);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }
        #endregion

        #region Customer Groups
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("customergroups")]
        [HttpPost]
        public async Task<IHttpActionResult> GetCustomerGroups()
        {
            try
            {
                var customerGroupDomain = new CustomerGroupDomain(OwnerInfo);
                var result = await customerGroupDomain.GetAllAsync<CustomerGroupViewModel>();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("customergroups/compress")]
        [HttpPost]
        [GzipCompression]
        public async Task<IHttpActionResult> GetCustomerGroupsCompress()
        {
            return await GetCustomerGroups();
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("customergroups/after")]
        [HttpPost]
        public async Task<IHttpActionResult> GetCustomerGroups([FromBody]BaseRequestModel model)
        {
            try
            {
                var customerGroupDomain = new CustomerGroupDomain(OwnerInfo);
                var validDate = GetDateFromString(model.dateAfter);
                var result = await customerGroupDomain.GetAllChangedAfterAsync<CustomerGroupViewModel>(validDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("customergroups/compress/after")]
        [HttpPost]
        [GzipCompression]
        public async Task<IHttpActionResult> GetCustomerGroupsCompress([FromBody]BaseRequestModel model)
        {
            return await GetCustomerGroups(model);
        }

        [Authorize(Roles = "DataSync, BaseDataAdmin")]
        [Route("customergroups/save")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveCustomerGroups([FromBody]CustomerRequestModel data)
        {
            try
            {
                var customerGroupDomain = new CustomerGroupDomain(OwnerInfo);
                await customerGroupDomain.PublishAsync(AutoMapper.Mapper.Map<CustomerGroup>(data.customerGroupData));
                return Ok(data.customerGroupData);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "DataSync, BaseDataAdmin")]
        [Route("customergroups/checkdeleted")]
        [HttpPost]
        public async Task<IHttpActionResult> CheckDeletedCustomerGroups([FromBody]CustomerRequestModel data)
        {
            try
            {
                var customerGroupDomain = new CustomerGroupDomain(OwnerInfo);
                await customerGroupDomain.CheckDeletedAsync(data.customerGroupData);
                return Ok(data.customerGroupData);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }
        #endregion

    }
}
