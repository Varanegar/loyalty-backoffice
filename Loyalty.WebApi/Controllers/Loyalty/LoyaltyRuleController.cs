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
    [RoutePrefix("api/loyalty/rule")]
    public class LoyaltyRuleController : AnatoliApiController
    {
        
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("load")]
        [HttpPost]
        public async Task<IHttpActionResult> GetRules()
        {
            try
            {
                var result = await new LoyaltyRuleDomain(OwnerInfo).GetAllAsync<LoyaltyRuleViewModel>();
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
        public async Task<IHttpActionResult> SaveRule([FromBody]LoyaltyRuleRequestModel data)
        {
            try
            {
                var domain = new LoyaltyRuleDomain(OwnerInfo);
                await domain.PublishAsync(AutoMapper.Mapper.Map<LoyaltyRule>(data.ruleData));

                return Ok(data.ruleData);

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
        public async Task<IHttpActionResult> DeleteRules([FromBody]LoyaltyRuleRequestModel data)
        {
            try
            {
                var domain = new LoyaltyRuleDomain(OwnerInfo);
                var list = new List<LoyaltyRule>() { AutoMapper.Mapper.Map<LoyaltyRule>(data.ruleData) };
                await domain.DeleteLoyaltyRules(list);

                return Ok(data.ruleData);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }


    }
}
