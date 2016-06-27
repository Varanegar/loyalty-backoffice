using Anatoli.Common.WebApi;
using Anatoli.ViewModels;
using Anatoli.ViewModels.BaseModels;
using Loyalty.Business.Domain;
using Loyalty.Business.Domain.Base;
using Loyalty.DataAccess.Models;
using Loyalty.WebApi.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Loyalty.WebApi.Controllers
{
    [RoutePrefix("api/base/region")]
    public class RegionController : AnatoliApiController
    {
        #region CityRegion
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("cityregions")]
        [HttpPost]
        public async Task<IHttpActionResult> GetCityRegion()
        {
            try
            {
                var result = await new CityRegionDomain(OwnerInfo).GetAllAsync<CityRegionViewModel>();

                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("cityregions/byparentid")]
        [HttpPost]
        public async Task<IHttpActionResult> GetCityRegionByParentId([FromBody]BaseRequestModel data)
        {
            try
            {
                var result = await new CityRegionDomain(OwnerInfo).GetAllAsync<CityRegionViewModel>(p => p.CityRegion2Id == data.parentUniqueId);


                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("cityregions/compress")]
        [GzipCompression]
        [HttpPost]
        public async Task<IHttpActionResult> GetCityRegionCompress()
        {
            return await GetCityRegion();
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("cityregions/after")]
        [HttpPost]
        public async Task<IHttpActionResult> GetCityRegion([FromBody]BaseRequestModel data)
        {
            try
            {
                var cityRegionDomain = new CityRegionDomain(OwnerInfo);
                var validDate = GetDateFromString(data.dateAfter);
                var result = await cityRegionDomain.GetAllChangedAfterAsync<CityRegionViewModel>(validDate);

                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("cityregions/compress/after")]
        [GzipCompression]
        [HttpPost]
        public async Task<IHttpActionResult> GetCityRegionCompress([FromBody]BaseRequestModel data)
        {
            return await GetCityRegion(data);
        }

        [Authorize(Roles = "DataSync, BaseDataAdmin")]
        [Route("save")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveCityRegionInfo([FromBody]GeneralRequestModel data)
        {
            try
            {
                var cityRegionDomain = new CityRegionDomain(OwnerInfo);
                await cityRegionDomain.PublishAsync(AutoMapper.Mapper.Map<CityRegion>(data.cityRegionData));
                return Ok(data.cityRegionData);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "DataSync, BaseDataAdmin")]
        [Route("checkdeleted")]
        [HttpPost]
        public async Task<IHttpActionResult> CheckDeletedCityRegionInfo([FromBody]GeneralRequestModel data)
        {
            try
            {
                var cityRegionDomain = new CityRegionDomain(OwnerInfo);
                await cityRegionDomain.CheckDeletedAsync(data.cityRegionData);
                return Ok(data.cityRegionData);
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
