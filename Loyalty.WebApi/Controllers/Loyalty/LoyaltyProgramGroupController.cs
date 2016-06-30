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
    [RoutePrefix("api/loyalty/programgroup")]
    public class LoyaltyProgramGroupController : AnatoliApiController
    {
        
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("load")]
        [HttpPost]
        public async Task<IHttpActionResult> GetProgramGroups()
        {
            try
            {
                var result = await new LoyaltyProgramGroupDomain(OwnerInfo).GetAllAsync<LoyaltyProgramGroupViewModel>();
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
        public async Task<IHttpActionResult> SaveProgramGroups([FromBody]LoyaltyProgramGroupRequestModel data)
        {
            try
            {
                var domain = new LoyaltyProgramGroupDomain(OwnerInfo);
                await domain.PublishAsync(AutoMapper.Mapper.Map<LoyaltyProgramGroup>(data.programGroupData));

                return Ok(data.programGroupData);

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
        public async Task<IHttpActionResult> DeleteProgramGroups([FromBody]LoyaltyProgramGroupRequestModel data)
        {
            try
            {
                var domain = new LoyaltyProgramGroupDomain(OwnerInfo);
                var list = new List<LoyaltyProgramGroup>() { AutoMapper.Mapper.Map<LoyaltyProgramGroup>(data.programGroupData) };
                await domain.DeleteLoyaltyProgramGroups(list);

                return Ok(data.programGroupData);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }


    }
}
