using System;
using System.Linq;
using System.Web.Http;
using System.Threading.Tasks;
using Anatoli.Business.Domain;
using System.Collections.Generic;
using Anatoli.ViewModels.BaseModels;
using Anatoli.ViewModels;
using Anatoli.Common.WebApi;
using Loyalty.WebApi.Classes;
using Loyalty.Business.Domain;
using Loyalty.DataAccess.Models;

namespace Loyalty.WebApi.Controllers
{
    [RoutePrefix("api/base/basedata")]
    public class BaseTypeInfoController : AnatoliApiController
    {
        #region Base Type
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("basedatas")]
        [HttpPost]
        public async Task<IHttpActionResult> GetBaseTypes()
        {
            try
            {
                var result = await new BaseTypeDomain(OwnerInfo).GetAllAsync<BaseTypeViewModel>();

                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("basedatas/compress")]
        [HttpPost]
        [GzipCompression]
        public async Task<IHttpActionResult> GetBaseTypesCompresss()
        {
            return await GetBaseTypes();
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("basedatas/after")]
        [HttpPost]
        public async Task<IHttpActionResult> GetBaseTypes([FromBody]BaseRequestModel data)
        {
            try
            {
                var validDate = GetDateFromString(data.dateAfter);
                var result = await new BaseTypeDomain(OwnerInfo).GetAllChangedAfterAsync<BaseTypeViewModel>(validDate);

                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("basedatas/compress/after")]
        [HttpPost]
        public async Task<IHttpActionResult> GetBaseTypesCompress([FromBody]BaseRequestModel data)
        {
            return await GetBaseTypes(data);
        }
        [Authorize(Roles = "DataSync, BaseDataAdmin")]
        [Route("basedatas/save")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveBaseTypes([FromBody]GeneralRequestModel data)
        {
            try
            {
                await new BaseTypeDomain(OwnerInfo).PublishAsync(AutoMapper.Mapper.Map<BaseType>(data.baseTypeData));
                return Ok(data.baseTypeData);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }

        }

        [Authorize(Roles = "DataSync, BaseDataAdmin")]
        [Route("basedatas/checkdeleted")]
        [HttpPost]
        public async Task<IHttpActionResult> CheckDeletedBaseTypes([FromBody]GeneralRequestModel data)
        {
            try
            {
                await new BaseTypeDomain(OwnerInfo).CheckDeletedAsync(data.baseTypeData);
                return Ok(data.baseTypeData);
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
