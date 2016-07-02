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
        #region Rule
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
        [Route("byid")]
        [HttpPost]
        public async Task<IHttpActionResult> GetRuleById([FromBody]LoyaltyRuleRequestModel data)
        {
            try
            {
                var result = await new LoyaltyRuleDomain(OwnerInfo).GetAllAsync<LoyaltyRuleViewModel>(x => x.Id == data.uniqueId);
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

        #endregion

        #region RuleAction
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("action/save")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveActionRule([FromBody]LoyaltyRuleRequestModel data)
        {
            try
            {
                var domain = new LoyaltyRuleActionDomain(OwnerInfo);
                await domain.PublishAsync(AutoMapper.Mapper.Map<LoyaltyRuleAction>(data.ruleActionData));
                return Ok(data.ruleActionData);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("action/loadbyruleid")]
        [HttpPost]
        public async Task<IHttpActionResult> GetRuleActionsByRuleId([FromBody]LoyaltyRuleRequestModel data)
        {
            try
            {
                var result = await new LoyaltyRuleActionDomain(OwnerInfo).GetAllAsync<LoyaltyRuleActionViewModel>(x => x.LoyaltyRuleId == data.uniqueId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("action/delete")]
        [HttpPost]
        public async Task<IHttpActionResult> DeleteRuleActions([FromBody]LoyaltyRuleRequestModel data)
        {
            try
            {
                var domain = new LoyaltyRuleActionDomain(OwnerInfo);
                var list = new List<LoyaltyRuleAction>() { AutoMapper.Mapper.Map<LoyaltyRuleAction>(data.ruleActionData) };
                await domain.DeleteRuleActions(list);

                return Ok(data.ruleData);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }
        #endregion
       
        #region RuleCondition
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("condition/save")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveConditionRule([FromBody]LoyaltyRuleRequestModel data)
        {
            try
            {
                var domain = new LoyaltyRuleConditionDomain(OwnerInfo);
                await domain.PublishAsync(AutoMapper.Mapper.Map<LoyaltyRuleCondition>(data.ruleConditionData));
                return Ok(data.ruleConditionData);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("condition/loadbyruleid")]
        [HttpPost]
        public async Task<IHttpActionResult> GetRuleConditionByRuleId([FromBody]LoyaltyRuleRequestModel data)
        {
            try
            {
                var result = await new LoyaltyRuleConditionDomain(OwnerInfo).GetAllAsync<LoyaltyRuleConditionViewModel>(x => x.LoyaltyRuleId == data.uniqueId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("condition/delete")]
        [HttpPost]
        public async Task<IHttpActionResult> DeleteRuleConditions([FromBody]LoyaltyRuleRequestModel data)
        {
            try
            {
                var domain = new LoyaltyRuleConditionDomain(OwnerInfo);
                var list = new List<LoyaltyRuleCondition>() { AutoMapper.Mapper.Map<LoyaltyRuleCondition>(data.ruleConditionData) };
                await domain.DeleteRuleConditions(list);

                return Ok(data.ruleConditionData);

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
