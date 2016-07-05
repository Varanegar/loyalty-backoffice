using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Anatoli.Business.Domain;
using Anatoli.Common.WebApi;
using Anatoli.ViewModels;
using Anatoli.ViewModels.CustomerModels;
using Loyalty.Business.Domain;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models.Account;
using Loyalty.DataAccess.Repositories;
using Loyalty.WebApi.Classes;
using Microsoft.AspNet.Identity.Owin;

namespace Loyalty.WebApi.Controllers
{
    [RoutePrefix("api/loyalty/customer")]
    public class CustomerController : AnatoliApiController
    {
        #region Customer
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("customers/byid")]
        [HttpPost]
        public async Task<IHttpActionResult> GetCustomerById([FromBody]CustomerRequestModel data)
        {
            try
            {
                var result = await new CustomerDomain(OwnerInfo).GetAllAsync<CustomerViewModel>(x => x.Id == data.customerId);
                //var result = await new CustomerDomain(OwnerInfo).GetByIdAsync<CustomerViewModel>(data.customerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("search/bycodeormobile")]
        [HttpPost]
        public async Task<IHttpActionResult> GetCustomerToFindReagent([FromBody]CustomerRequestModel data)
        {
            try
            {
                var result = await new CustomerDomain(OwnerInfo).GetAllAsync<CustomerViewModel>(p => p.CustomerCode.Contains(data.searchTerm) || p.Mobile.Contains(data.searchTerm));
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("customers/compress")]
        [HttpPost, GzipCompression]
        public async Task<IHttpActionResult> GetCustomersCompress()
        {
            try
            {
                var result = await new CustomerDomain(OwnerInfo).GetAllAsync<CustomerViewModel>();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("savesingle")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveSingleCustomer([FromBody]CustomerRequestModel data)
        {
            try
            {

                var context = Request.GetOwinContext().Get<AnatoliDbContext>();

                var customerDomain = new CustomerDomain(OwnerInfo, context);
                var userDomain = new UserDomain(OwnerKey, DataOwnerKey, context);
                if (data.customerData.Email != null)
                {
                    var emailUser = await userDomain.GetByEmailAsync(data.customerData.Email);
                    if (emailUser != null && data.customerData.UniqueId.ToString() != emailUser.Id)
                        return GetErrorResult("ايميل شما قبلا استفاده شده است");
                }

                if (data.customerData.Phone != null)
                {
                    var pheonUser = await userDomain.GetByEmailAsync(data.customerData.Phone);
                    if (pheonUser != null && data.customerData.UniqueId.ToString() != pheonUser.Id)
                        return GetErrorResult("موبايل شما قبلا استفاده شده است");
                }
                var userStore = new AnatoliUserStore(context);
                var userStoreData = await userStore.FindByIdAsync(data.customerData.UniqueId.ToString());
                if (userStoreData != null)
                {
                    //userDomain..sa
                    if (userStoreData.Email != data.customerData.Email)
                    {
                        userStoreData.Email = data.customerData.Email;
                        await userStore.ChangeEmailAddress(userStoreData, data.customerData.Email);
                    }
                    userStoreData.FullName = data.customerData.FirstName + " " + data.customerData.LastName;
                    await userStore.UpdateAsync(userStoreData);

                }

                if(data.customerData.Mobile != null)
                {

                }

                await customerDomain.PublishAsync(AutoMapper.Mapper.Map<Customer>(data.customerData));

                return Ok(data.customerData);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }


        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("active")]
        [HttpPost]
        public async Task<IHttpActionResult> ActiveCustomer([FromBody]CustomerRequestModel data)
        {
            try
            {
                var customerDomain = new CustomerDomain(OwnerInfo);
                await customerDomain.ChangeStatusCustomer(data.customerData.UniqueId, 1);

                return Ok(data.customerData);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("inactive")]
        [HttpPost]
        public async Task<IHttpActionResult> InActiveCustomer([FromBody]CustomerRequestModel data)
        {
            try
            {
                var customerDomain = new CustomerDomain(OwnerInfo);

                await customerDomain.ChangeStatusCustomer(data.customerData.UniqueId, 0);

                return Ok(data.customerData);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }


        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("customer/delete")]
        [HttpPost]
        public async Task<IHttpActionResult> DeleteCustomer([FromBody]CustomerRequestModel data)
        {
            try
            {
                var customerDomain = new CustomerDomain(OwnerInfo);
                
                var customers = new List<Customer> {AutoMapper.Mapper.Map<Customer>(data.customerData)};

                await customerDomain.DeleteCustomer(customers);

                return Ok(true);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("savesinglequick")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveSingleCustomerQuick([FromBody]CustomerRequestModel data)
        {
            return await SaveSingleCustomer(data);
        }

        [Authorize(Roles = "DataSync")]
        [Route("savebatch")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveBatchCustomer([FromBody]CustomerRequestModel data)
        {
            try
            {
                var customerDomain = new CustomerDomain(OwnerInfo);
                data.customerListData.ForEach(p =>
                    {
                        p.CompanyId = DataOwnerKey;
                    });
                await customerDomain.PublishAsync(AutoMapper.Mapper.Map<IEnumerable<Customer>>(data.customerListData).ToList());

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

        #region Customer Tag
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("customertags")]
        [HttpPost]
        public async Task<IHttpActionResult> GetCustomerTags()
        {
            try
            {
                var customerTagDomain = new CustomerTagDomain(OwnerInfo);
                var result = await customerTagDomain.GetAllAsync<CustomerTagViewModel>();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("customertags/compress")]
        [HttpPost]
        [GzipCompression]
        public async Task<IHttpActionResult> GetCustomerTagsCompress()
        {
            return await GetCustomerTags();
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("customertags/after")]
        [HttpPost]
        public async Task<IHttpActionResult> GetCustomerTags([FromBody]BaseRequestModel model)
        {
            try
            {
                var customerTagDomain = new CustomerTagDomain(OwnerInfo);
                var validDate = GetDateFromString(model.dateAfter);
                var result = await customerTagDomain.GetAllChangedAfterAsync<CustomerTagViewModel>(validDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("customertags/compress/after")]
        [HttpPost]
        [GzipCompression]
        public async Task<IHttpActionResult> GetCustomerTagsCompress([FromBody]BaseRequestModel model)
        {
            return await GetCustomerTags(model);
        }

        [Authorize(Roles = "DataSync, BaseDataAdmin")]
        [Route("customertags/save")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveCustomerTags([FromBody]CustomerRequestModel data)
        {
            try
            {
                var customerTagDomain = new CustomerTagDomain(OwnerInfo);
                await customerTagDomain.PublishAsync(AutoMapper.Mapper.Map<IEnumerable<CustomerTag>>(data.customerTagData).ToList());
                return Ok(data.customerTagData);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "DataSync, BaseDataAdmin")]
        [Route("customertags/delete")]
        [HttpPost]
        public async Task<IHttpActionResult> DeleteCustomerTags([FromBody]CustomerRequestModel data)
        {
            try
            {
                var customerTagDomain = new CustomerTagDomain(OwnerInfo);
                await customerTagDomain.DeleteAsync(AutoMapper.Mapper.Map< IEnumerable<CustomerTag>>(data.customerTagData).ToList());
                return Ok(data.customerTagData);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }
        [Authorize(Roles = "DataSync, BaseDataAdmin")]
        [Route("customertags/checkdeleted")]
        [HttpPost]
        public async Task<IHttpActionResult> CheckDeletedCustomerTags([FromBody]CustomerRequestModel data)
        {
            try
            {
                var customerTagDomain = new CustomerTagDomain(OwnerInfo);
                await customerTagDomain.CheckDeletedAsync(data.customerTagData);
                return Ok(data.customerTagData);
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
                await customerGroupDomain.PublishAsync(AutoMapper.Mapper.Map<IEnumerable<CustomerGroup>>(data.customerGroupData).ToList());
                return Ok(data.customerGroupData);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "DataSync, BaseDataAdmin")]
        [Route("customergroups/delete")]
        [HttpPost]
        public async Task<IHttpActionResult> DeleteCustomerGroups([FromBody]CustomerRequestModel data)
        {
            try
            {
                var customerGroupDomain = new CustomerGroupDomain(OwnerInfo);
                await customerGroupDomain.DeleteCustomerGroups(AutoMapper.Mapper.Map<IEnumerable<CustomerGroup>>(data.customerGroupData).ToList());
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
