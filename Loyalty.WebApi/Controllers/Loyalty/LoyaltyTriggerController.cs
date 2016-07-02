using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Anatoli.ViewModels.LoyaltyModels;
using Anatoli.ViewModels.RequestModel;
using Loyalty.Business.Domain.Loyalty;
using System.Threading.Tasks;
using Loyalty.DataAccess.Models;
using Loyalty.DataAccess.Models.Loyalty;
using Loyalty.WebApi.Classes;

namespace Loyalty.WebApi.Controllers.Loyalty
{
    [RoutePrefix("api/loyalty/triggers")]
    public class LoyaltyTriggerController : AnatoliApiController
    {
        #region trigger
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("load")]
        [HttpPost]
        public async Task<IHttpActionResult> GetLoyaltyTriggers()
        {
            try
            {
                var result = await new LoyaltyTriggerDomain(OwnerInfo).GetAllAsync<LoyaltyTriggerViewModel>();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("save")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveLoyaltyTrigger([FromBody]LoyaltyTriggerRequestModel data)
        {
            try
            {
                var domain = new LoyaltyTriggerDomain(OwnerInfo);
                await domain.PublishAsync(AutoMapper.Mapper.Map<LoyaltyTrigger>(data.loyaltyTriggerData));

                return Ok(data.loyaltyTriggerData);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("delete")]
        [HttpPost]
        public async Task<IHttpActionResult> DeleteLoyaltyTrigger([FromBody]LoyaltyTriggerRequestModel data)
        {
            try
            {
                var domain = new LoyaltyTriggerDomain(OwnerInfo);
                var list = new List<LoyaltyTrigger>() { AutoMapper.Mapper.Map<LoyaltyTrigger>(data.loyaltyTriggerData) };
                await domain.DeleteLoyaltyTrigger(list);

                return Ok(data.loyaltyTriggerData);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }
        #endregion

        #region trigger type
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("loadtypes")]
        [HttpPost]
        public async Task<IHttpActionResult> GetLoyaltyTriggerTypes()
        {
            try
            {
                var result = await new LoyaltyTriggerTypeDomain(OwnerInfo).GetAllAsync<LoyaltyTriggerTypeViewModel>();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("savetype")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveLoyaltyTriggerType([FromBody]LoyaltyTriggerRequestModel data)
        {
            try
            {
                var domain = new LoyaltyTriggerTypeDomain(OwnerInfo);
                await domain.PublishAsync(AutoMapper.Mapper.Map<LoyaltyTriggerType>(data.loyaltyTriggerTypeData));

                return Ok(data.loyaltyTriggerTypeData);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("deletetype")]
        [HttpPost]
        public async Task<IHttpActionResult> DeleteLoyaltyTriggerType([FromBody]LoyaltyTriggerRequestModel data)
        {
            try
            {
                var domain = new LoyaltyTriggerTypeDomain(OwnerInfo);
                var list = new List<LoyaltyTriggerType>() { AutoMapper.Mapper.Map<LoyaltyTriggerType>(data.loyaltyTriggerTypeData) };
                await domain.DeleteLoyaltyTriggerType(list);

                return Ok(data.loyaltyTriggerTypeData);

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
