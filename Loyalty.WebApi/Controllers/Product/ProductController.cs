using Anatoli.Business.Domain;
using Anatoli.Common.WebApi;
using Anatoli.ViewModels;
using Anatoli.ViewModels.ProductModels;
using Loyalty.Business.Domain.Product;
using Loyalty.DataAccess.Models;
using Loyalty.WebApi.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Anatoli.Cloud.WebApi.Controllers
{
    [RoutePrefix("api/gateway/product")]
    public class ProductController : AnatoliApiController
    {

        #region Products
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("products")]
        [HttpPost]
        public async Task<IHttpActionResult> GetProducts()
        {
            try
            {
                var productDomain = new ProductDomain(OwnerInfo);
                var result = await productDomain.GetAllAsync<ProductViewModel>();

                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [AnatoliAuthorize(Roles = "AuthorizedApp, User")] //, Resource = "Product", Action = "List"
        [Route("products/compress")]
        [HttpPost]
        [GzipCompression]
        public async Task<IHttpActionResult> GetProductsCompress()
        {
            return await GetProducts();
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("products/after")]
        [HttpPost]
        public async Task<IHttpActionResult> GetProducts([FromBody] BaseRequestModel data)
        {
            try
            {
                var productDomain = new ProductDomain(OwnerInfo);
                var validDate = GetDateFromString(data.dateAfter);
                var result = await productDomain.GetAllChangedAfterAsync<ProductViewModel>(validDate);

                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("products/compress/after")]
        [GzipCompression]
        [HttpPost]
        public async Task<IHttpActionResult> GetProductsCompress([FromBody] BaseRequestModel data)
        {
            return await GetProducts(data);
        }

        [Authorize(Roles = "DataSync, BaseDataAdmin"), HttpPost]
        [Route("save")]
        public async Task<IHttpActionResult> SaveProducts([FromBody] ProductRequestModel data)
        {
            try
            {
                if (data != null) log.Info("save product count : " + data.productData.Count);
                var productDomain = new ProductDomain(OwnerInfo);
                await productDomain.PublishAsync(AutoMapper.Mapper.Map<Product>(data.productData));
                return Ok(data.productData);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "DataSync, BaseDataAdmin")]
        [Route("checkdeleted"), HttpPost]
        public async Task<IHttpActionResult> CheckeDeletedProducts([FromBody] ProductRequestModel data)
        {
            try
            {
                if (data != null) log.Info("save product count : " + data.productData.Count);
                var productDomain = new ProductDomain(OwnerInfo);
                await productDomain.CheckDeletedAsync(data.productData);
                return Ok(data.productData);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [AnatoliAuthorize(Roles = "AuthorizedApp, User", Resource = "Product", Action = "ProductTypes")]
        [Route("productTypes"), HttpPost]
        public async Task<IHttpActionResult> GetProductTypes()
        {
            try
            {
                var model = await new ProductTypeDomain(OwnerInfo).GetAllAsync<ProductType>();

                return Ok(model);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }
        #endregion

        #region Product Groups
        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("productgroups")]
        [HttpPost]
        public async Task<IHttpActionResult> GetProductGroups()
        {
            try
            {
                var productGroupDomain = new ProductGroupDomain(OwnerInfo);
                var result = await productGroupDomain.GetAllAsync<ProductGroupViewModel>();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("productgroups/compress")]
        [HttpPost]
        [GzipCompression]
        public async Task<IHttpActionResult> GetProductGroupsCompress()
        {
            return await GetProductGroups();
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("productgroups/after")]
        [HttpPost]
        public async Task<IHttpActionResult> GetProductGroups([FromBody]BaseRequestModel model)
        {
            try
            {
                var productGroupDomain = new ProductGroupDomain(OwnerInfo);
                var validDate = GetDateFromString(model.dateAfter);
                var result = await productGroupDomain.GetAllChangedAfterAsync<ProductGroupViewModel>(validDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "AuthorizedApp, User")]
        [Route("productgroups/compress/after")]
        [HttpPost]
        [GzipCompression]
        public async Task<IHttpActionResult> GetProductGroupsCompress([FromBody]BaseRequestModel model)
        {
            return await GetProductGroups(model);
        }

        [Authorize(Roles = "DataSync, BaseDataAdmin")]
        [Route("productgroups/save")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveProductGroups([FromBody]ProductRequestModel data)
        {
            try
            {
                var productGroupDomain = new ProductGroupDomain(OwnerInfo);
                await productGroupDomain.PublishAsync(AutoMapper.Mapper.Map<ProductGroup>(data.productGroupData));
                return Ok(data.productGroupData);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Web API Call Error");
                return GetErrorResult(ex);
            }
        }

        [Authorize(Roles = "DataSync, BaseDataAdmin")]
        [Route("productgroups/checkdeleted")]
        [HttpPost]
        public async Task<IHttpActionResult> CheckDeletedProductGroups([FromBody]ProductRequestModel data)
        {
            try
            {
                var productGroupDomain = new ProductGroupDomain(OwnerInfo);
                await productGroupDomain.CheckDeletedAsync(data.productGroupData);
                return Ok(data.productGroupData);
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
