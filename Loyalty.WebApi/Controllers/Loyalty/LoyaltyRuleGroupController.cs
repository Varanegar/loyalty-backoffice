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
    [RoutePrefix("api/loyalty/rulegroup")]
    public class LoyaltyRuleGroupController : AnatoliApiController
    {
        
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("load")]
        [HttpPost]
        public async Task<IHttpActionResult> GetRuleGroups()
        {
            try
            {
                var result = await new LoyaltyRuleGroupDomain(OwnerInfo).GetAllAsync<LoyaltyRuleGroupViewModel>();
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
        public async Task<IHttpActionResult> SaveRuleGroup([FromBody]LoyaltyRuleGroupRequestModel data)
        {
            try
            {
                var domain = new LoyaltyRuleGroupDomain(OwnerInfo);
                await domain.PublishAsync(AutoMapper.Mapper.Map<LoyaltyRuleGroup>(data.ruleGroupData));

                return Ok(data.ruleGroupData);

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
        public async Task<IHttpActionResult> DeleteRuleGroups([FromBody]LoyaltyRuleGroupRequestModel data)
        {
            try
            {
                var domain = new LoyaltyRuleGroupDomain(OwnerInfo);
                var list = new List<LoyaltyRuleGroup>() { AutoMapper.Mapper.Map<LoyaltyRuleGroup>(data.ruleGroupData) };
                await domain.Delete(list);

                return Ok(data.ruleGroupData);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }


    }
}
