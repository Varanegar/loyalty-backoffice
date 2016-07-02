using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Anatoli.ViewModels.LoyaltyModels;
using Anatoli.ViewModels.RequestModel;
using Loyalty.Business.Domain.Loyalty;
using Loyalty.DataAccess.Models.Loyalty;
using Loyalty.WebApi.Classes;

namespace Loyalty.WebApi.Controllers.Loyalty
{
    [RoutePrefix("api/loyalty/actiontype")]
    public class LoyaltyActionTypeController : AnatoliApiController
    {
        
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("load")]
        [HttpPost]
        public async Task<IHttpActionResult> GetActionTypes()
        {
            try
            {
                var result = await new LoyaltyActionTypeDomain(OwnerInfo).GetAllAsync<LoyaltyActionTypeViewModel>();
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
        public async Task<IHttpActionResult> SaveActionType([FromBody]LoyaltyActionTypeRequestModel data)
        {
            try
            {
                var domain = new LoyaltyActionTypeDomain(OwnerInfo);
                await domain.PublishAsync(AutoMapper.Mapper.Map<LoyaltyActionType>(data.actionTypeData));

                return Ok(data.actionTypeData);

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
        public async Task<IHttpActionResult> DeleteActionTypes([FromBody]LoyaltyActionTypeRequestModel data)
        {
            try
            {
                var domain = new LoyaltyActionTypeDomain(OwnerInfo);
                var list = new List<LoyaltyActionType>() { AutoMapper.Mapper.Map<LoyaltyActionType>(data.actionTypeData) };
                await domain.Delete(list);

                return Ok(data.actionTypeData);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }


    }
}
