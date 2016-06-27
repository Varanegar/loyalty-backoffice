using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Web.Http;
using Anatoli.Business.Domain;
using Anatoli.ViewModels.LoyaltyModels;
using Anatoli.ViewModels.RequestModel;
using Loyalty.DataAccess.Models.Account;
using Loyalty.WebApi.Classes;
using System.Threading.Tasks;
using Loyalty.DataAccess;

namespace Loyalty.WebApi.Controllers.User
{
    [RoutePrefix("api/loyalty/usergroup")]
    public class UserGroupController : AnatoliApiController
    {
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("load")]
        [HttpPost]
        public async Task<IHttpActionResult> LoadLoyaltyUserGroup()
        {
            try
            {
                var result = await new UserGroupDomain(OwnerInfo).GetAllAsync<LoyaltyUserGroupViewModel>();
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
        public async Task<IHttpActionResult> SaveUserGroup([FromBody]LoyaltyUserGroupRequestModel data)
        {
            try
            {
                var domain = new UserGroupDomain(OwnerInfo);

                await domain.PublishAsync(AutoMapper.Mapper.Map<UserGroup>(data.userGroupData));

                return Ok(data.userGroupData);

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
        public async Task<IHttpActionResult> DeleteUserGroup([FromBody]LoyaltyUserGroupRequestModel data)
        {
            try
            {
                var domain = new UserGroupDomain(OwnerInfo);

                var group = new List<UserGroup> { AutoMapper.Mapper.Map<UserGroup>(data.userGroupData) };

                await domain.DeleteUserGroup(group);

                return Ok(true);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("adduser")]
        [HttpPost]
        public async Task<IHttpActionResult> AddUserToGroup([FromBody]LoyaltyUserGroupRequestModel data)
        {
            try
            {
                var usergroupuserdomain = new UserGroupUserDomain(OwnerInfo);
                await usergroupuserdomain.
                    PublishAsync(new UserGroupUser(){UserGroupId = data.uniqueId, UserId = data.userId.ToString()});

                return Ok(true);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("removeuser")]
        [HttpPost]
        public async Task<IHttpActionResult> RemoveFromGroup([FromBody]LoyaltyUserGroupRequestModel data)
        {
            try
            {
                var usergroupuserdomain = new UserGroupUserDomain(OwnerInfo);
                await usergroupuserdomain.RemoveFromGroup(data.uniqueId, data.userId);

                return Ok(true);

            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }
    }
}
