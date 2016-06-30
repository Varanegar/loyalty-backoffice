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
    [RoutePrefix("api/loyalty/valuetypeattribute")]
    public class LoyaltyValueTypeAttributeController : AnatoliApiController
    {

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("load")]
        [HttpPost]
        public async Task<IHttpActionResult> GetValueTypeAttributes()
        {
            try
            {
                var result = await new LoyaltyValueTypeAttributeDomain(OwnerInfo).GetAllAsync<LoyaltyValueTypeAttributeViewModel>();
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
        public async Task<IHttpActionResult> SaveLoyaltyValueTypeAttribute([FromBody]LoyaltyValueTypeAttributeRequestModel data)
        {
            try
            {
                var domain = new LoyaltyValueTypeAttributeDomain(OwnerInfo);
                await domain.PublishAsync(AutoMapper.Mapper.Map<LoyaltyValueTypeAttribute>(data.valueTypeAttributeData));

                return Ok(data.valueTypeAttributeData);

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
        public async Task<IHttpActionResult> DeleteLoyaltyValueTypeAttribute([FromBody]LoyaltyValueTypeAttributeRequestModel data)
        {
            try
            {
                var domain = new LoyaltyValueTypeAttributeDomain(OwnerInfo);
                var list = new List<LoyaltyValueTypeAttribute>() { AutoMapper.Mapper.Map<LoyaltyValueTypeAttribute>(data.valueTypeAttributeData) };
                await domain.DeleteLoyaltyValueTypeAttribute(list);

                return Ok(data.valueTypeAttributeData);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }


    }


}
