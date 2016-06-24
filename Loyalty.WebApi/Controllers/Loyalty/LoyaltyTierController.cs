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
using Loyalty.Business.Domain.Loyalty;
using Anatoli.ViewModels.LoyaltyModels;
using Loyalty.DataAccess.Models.Loyalty;

namespace Anatoli.Cloud.WebApi.Controllers
{
    [RoutePrefix("api/loyalty")]
    public class LoyaltyTierController : AnatoliApiController
    {
        #region Loyalty Card Set
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("tiers")]
        [HttpPost]
        public async Task<IHttpActionResult> GetLoyaltyTiers()
        {
            try
            {
                var result = await new LoyaltyTierDomain(OwnerInfo).GetAllAsync<LoyaltyTierViewModel>();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("tiers/save")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveLoyaltyTiers([FromBody]LoyaltyRequestModel data)
        {
            try
            {
                var domain = new LoyaltyTierDomain(OwnerInfo);
                await domain.PublishAsync(AutoMapper.Mapper.Map<IEnumerable<LoyaltyTier>>(data.loyaltyTierListData).ToList());

                return Ok(data.loyaltyTierListData);

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
