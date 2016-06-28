using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Anatoli.Business.Domain;
using Anatoli.ViewModels.User;
using Loyalty.WebApi.Classes;

namespace Loyalty.WebApi.Controllers.User
{
    [RoutePrefix("api/loyalty/user")]
    public class UserController : AnatoliApiController
    {
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("profile")]
        [HttpPost]
        public async Task<IHttpActionResult> GetUserProfile()
        {
            try
            {
                var userDomain = new UserDomain(OwnerKey, DataOwnerKey);

                var user = await userDomain.GetByIdAsync(CurrentUserId);
                
                if (user != null)
                    return Ok(AutoMapper.Mapper.Map<UserProfileModel>(user));
                return NotFound();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

    }
}
