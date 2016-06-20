using System;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;

namespace Loyalty.Business.Domain.Product
{
    public class ProductTypeDomain : BusinessDomainV3<ProductType>, IBusinessDomainV3<ProductType>
    {
        #region Properties
        #endregion

        #region Ctors
        public ProductTypeDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public ProductTypeDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(ProductType currentData, ProductType item)
         {
             if (currentData != null)
             {
                 if (currentData.ProductTypeName != item.ProductTypeName)
                 {
                     currentData.ProductTypeName = item.ProductTypeName;
                     currentData.LastUpdate = DateTime.Now;
                     MainRepository.Update(currentData);
                 }
             }
             else
             {
                 item.CreatedDate = item.LastUpdate = DateTime.Now;
                 MainRepository.Add(item);
             }
         }

        #endregion
    }
}
