using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Anatoli.ViewModels.CustomerModels;
using Anatoli.ViewModels.RequestModel;
using Loyalty.Business.Domain;
using Loyalty.DataAccess.Models.Account;
using Loyalty.WebApi.Classes;

namespace Loyalty.WebApi.Controllers
{
     [RoutePrefix("api/loyalty/customerhistory")]
    public class CustomerHistoryController : AnatoliApiController
    {
        #region CustomerNonMonetaryHistory
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("loadnonmonetary")]
        [HttpPost]
         public async Task<IHttpActionResult> LoadCustomerNonMonetaryHistory([FromBody]CustomerHistoryRequestModel data)
        {
            try
            {
                var result = await new CustomerNonMonetaryHistoryDomain(OwnerInfo).GetAllAsync<CustomerNonMonetaryHistoryViewModel>(x => x.CustomerId == data.customerNonMonetaryHistoryData.CustomerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("savenonmonetary")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveCustomerNonMonetaryHistory([FromBody]CustomerHistoryRequestModel data)
        {
            try
            {
                var domain = new CustomerNonMonetaryHistoryDomain(OwnerInfo);
                
                await domain.PublishAsync(AutoMapper.Mapper.Map<CustomerNonMonetaryHistory>(data.customerNonMonetaryHistoryData));

                return Ok(data.customerNonMonetaryHistoryData);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("deletenonmonetary")]
        [HttpPost]
        public async Task<IHttpActionResult> DeleteNonCustomerMonetaryHistory([FromBody]CustomerHistoryRequestModel data)
        {
            try
            {
                var domain = new CustomerNonMonetaryHistoryDomain(OwnerInfo);

                var group = new List<CustomerNonMonetaryHistory> { AutoMapper.Mapper.Map<CustomerNonMonetaryHistory>(data.customerNonMonetaryHistoryData) };

                await domain.DeleteHistory(group);

                return Ok(true);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        #endregion

        #region CustomerMonetaryHistory
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("loadmonetary")]
        [HttpPost]
        public async Task<IHttpActionResult> LoadCustomerMonetaryHistory([FromBody]CustomerHistoryRequestModel data)
        {
            try
            {
                var result = await new CustomerMonetaryHistoryDomain(OwnerInfo).GetAllAsync<CustomerMonetaryHistoryViewModel>(x => x.CustomerId == data.customerMonetaryHistoryData.CustomerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("savemonetary")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveCustomerMonetaryHistory([FromBody]CustomerHistoryRequestModel data)
        {
            try
            {
                var domain = new CustomerMonetaryHistoryDomain(OwnerInfo);

                await domain.PublishAsync(AutoMapper.Mapper.Map<CustomerMonetaryHistory>(data.customerMonetaryHistoryData));

                return Ok(data.customerMonetaryHistoryData);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("deletemonetary")]
        [HttpPost]
        public async Task<IHttpActionResult> DeleteCustomerMonetaryHistory([FromBody]CustomerHistoryRequestModel data)
        {
            try
            {
                var domain = new CustomerMonetaryHistoryDomain(OwnerInfo);

                var group = new List<CustomerMonetaryHistory> { AutoMapper.Mapper.Map<CustomerMonetaryHistory>(data.customerMonetaryHistoryData) };

                await domain.DeleteHistory(group);

                return Ok(true);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        #endregion


        #region CustomerTransactionHistory
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("loadtransaction")]
        [HttpPost]
        public async Task<IHttpActionResult> LoadCutomerTransactionHistory([FromBody]CustomerHistoryRequestModel data)
        {
            try
            {
                var result = await new CustomerTransactionHistoryDomain(OwnerInfo).GetAllAsync<CustomerTransactionHistoryViewModel>(x => x.CustomerId == data.customerTransactionHistoryData.CustomerId && 
                    x.LoyaltyValueTypeId == data.customerTransactionHistoryData.LoyaltyValueTypeId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("savetransaction")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveCustomerTransactionHistory([FromBody]CustomerHistoryRequestModel data)
        {
            try
            {                    
                var domain = new CustomerTransactionHistoryDomain(OwnerInfo);

                await domain.PublishAsync(AutoMapper.Mapper.Map<CustomerTransactionHistory>(data.customerTransactionHistoryData));

                return Ok(data.customerTransactionHistoryData);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("deletetransaction")]
        [HttpPost]
        public async Task<IHttpActionResult> DeleteCustomerTransactionHistory([FromBody]CustomerHistoryRequestModel data)
        {
            try
            {
                var domain = new CustomerTransactionHistoryDomain(OwnerInfo);

                var group = new List<CustomerTransactionHistory> { AutoMapper.Mapper.Map<CustomerTransactionHistory>(data.customerTransactionHistoryData) };

                await domain.DeleteHistory(group);

                return Ok(true);

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
