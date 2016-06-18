using System;
using System.Linq;
using System.Threading.Tasks;
using Loyalty.DataAccess.Models;
using System.Collections.Generic;
using Anatoli.DataAccess.Interfaces;
using Loyalty.DataAccess.Repositories;
using Loyalty.DataAccess;
using System.Data.Entity;
using Anatoli.ViewModels.StockModels;
using System.Linq.Expressions;
using Anatoli.Common.DataAccess.Interfaces;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Anatoli.ViewModels.ProductModels;

namespace Anatoli.Business.Domain
{
    public class ProductDomain : BusinessDomainV3<Product>,
                                IBusinessDomainV3<Product>
    {
        #region Properties

        #endregion

        #region Ctors
        public ProductDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public ProductDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public async Task<List<ProductViewModel>> GetAllChangedAfter(DateTime selectedDate)
        {
            try
            {
                DBContext.Configuration.AutoDetectChangesEnabled = false;
                var model = await base.GetAllChangedAfterAsync<ProductViewModel>(selectedDate);

                model.Where(p => p.ProductTypeInfo == null).ToList().ForEach(itm => itm.ProductTypeInfo = new ProductTypeViewModel());
                DBContext.Configuration.AutoDetectChangesEnabled = true;

                return model;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAll ");
                throw ex;
            }
        }
        //public override Expression<Func<Product, ProductViewModel>> GetAllSelector<ProductViewModel>()
        //{
        //    return data => new ProductViewModel
        //            {
        //                ID = data.Number_ID,
        //                CreatedDate = data.CreatedDate,
        //                LastUpdate = data.LastUpdate,
        //                UniqueId = data.Id,
        //                ProductCode = data.ProductCode,
        //                Desctription = data.Desctription,
        //                PackVolume = data.PackVolume,
        //                PackWeight = data.PackWeight,
        //                Barcode = data.Barcode,
        //                StoreProductName = data.StoreProductName,
        //                ProductTypeId = data.ProductTypeId,
        //                QtyPerPack = data.QtyPerPack,
        //                IsRemoved = data.IsRemoved,
        //                ProductGroupId = data.ProductGroupId,
        //                IsActiveInOrder = data.IsActiveInOrder,
        //                ProductTypeInfo = data.ProductType != null ? new ProductTypeViewModel
        //                {
        //                    ProductTypeName = data.ProductType.ProductTypeName,
        //                    UniqueId = data.ProductType.Id
        //                } : null
        //            };
        //}
        public override void AddDataToRepository(Product currentProduct, Product item)
        {
            if (currentProduct != null)
            {
                currentProduct.ProductName = item.ProductName;
                currentProduct.ProductGroupId = item.ProductGroupId;
                currentProduct.Desctription = item.Desctription;
                currentProduct.QtyPerPack = item.QtyPerPack;
                currentProduct.PackVolume = item.PackVolume;
                currentProduct.PackWeight = item.PackWeight;
                currentProduct.ProductCode = item.ProductCode;
                currentProduct.Barcode = item.Barcode;
                currentProduct.ProductName = item.ProductName;
                currentProduct.StoreProductName = item.StoreProductName;
                currentProduct.TaxCategoryValueId = item.TaxCategoryValueId;
                currentProduct.LastUpdate = DateTime.Now;

                if (item.ProductType != null)
                    currentProduct.ProductTypeId = item.ProductTypeId;

                MainRepository.Update(currentProduct);
            }
            else
            {
                item.ApplicationOwnerId = OwnerInfo.ApplicationOwnerKey; item.DataOwnerId = OwnerInfo.DataOwnerKey; item.DataOwnerCenterId = OwnerInfo.DataOwnerCenterKey;

                item.CreatedDate = item.LastUpdate = DateTime.Now;
                if (item.ProductTypeId == null)
                    item.ProductType = null;
                MainRepository.Add(item);
            }
        }
        #endregion
    }
}
