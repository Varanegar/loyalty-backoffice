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
    public class LoyaltyCardController : AnatoliApiController
    {
        #region Loyalty Card Set
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("cardsets")]
        [HttpPost]
        public async Task<IHttpActionResult> GetLoyaltyCardSets()
        {
            try
            {
                var result = await new LoyaltyCardSetDomain(OwnerInfo).GetAllAsync<LoyaltyCardSetViewModel>();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("cardsets/save")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveLoyaltyCardSets([FromBody]LoyaltyRequestModel data)
        {
            try
            {
                var domain = new LoyaltyCardSetDomain(OwnerInfo);
                await domain.PublishAsync(AutoMapper.Mapper.Map<LoyaltyCardSet>(data.loyaltyCardSetListData));

                return Ok(data.loyaltyCardSetListData);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }
        #endregion

        #region Loyalty Card 
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("cards/bycardsetid")]
        [HttpPost]
        public async Task<IHttpActionResult> GetLoyaltyCardsByCardSet([FromBody]LoyaltyRequestModel data)
        {
            try
            {
                var result = await new LoyaltyCardDomain(OwnerInfo).GetAllAsync<LoyaltyCardViewModel>(p => p.LoyaltyCardSetId == data.loyaltyCardSetId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("cards/bycustomerid")]
        [HttpPost]
        public async Task<IHttpActionResult> GetLoyaltyCardsByCustomer([FromBody]LoyaltyRequestModel data)
        {
            try
            {
                var result = await new LoyaltyCardDomain(OwnerInfo).GetAllAsync<LoyaltyCardViewModel>(p => p.CustomerId == data.customerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("cards/save")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveLoyaltyCards([FromBody]LoyaltyRequestModel data)
        {
            try
            {
                var domain = new LoyaltyCardDomain(OwnerInfo);
                await domain.PublishAsync(AutoMapper.Mapper.Map<LoyaltyCard>(data.loyaltyCardListData));

                return Ok(data.loyaltyCardListData);

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
