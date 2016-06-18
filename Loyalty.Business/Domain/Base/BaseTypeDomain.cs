using System;
using System.Linq;
using System.Threading.Tasks;
using Loyalty.DataAccess.Models;
using System.Collections.Generic;
using Anatoli.DataAccess.Interfaces;
using Loyalty.DataAccess.Repositories;
using Loyalty.DataAccess;
using Anatoli.ViewModels.BaseModels;
using Anatoli.Common.DataAccess.Interfaces;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.Business.Domain
{
    public class BaseTypeDomain : BusinessDomainV3<BaseType>, IBusinessDomainV3<BaseType>
    {
        #region Properties
        public IRepository<BaseValue> BaseValueRepository { get; set; }
        #endregion

        #region Ctors
        public BaseTypeDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public BaseTypeDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
            BaseValueRepository = new BaseValueRepository(dbc);

        }
        #endregion

        #region Methods
        public override async Task PublishAsync(List<BaseType> dataListInfo)
        {
            try
            {
                
                var currentTypes = MainRepository.GetQuery().ToList();

                foreach (BaseType item in dataListInfo)
                {
                    var currentType = currentTypes.Find(p => p.Id == item.Id);
                    if (currentType != null)
                    {
                        currentType.BaseTypeDesc = item.BaseTypeDesc;
                        currentType.LastUpdate = DateTime.Now;
                        currentType = await SetBaseValueData(currentType, item.BaseValues.ToList(), ((AnatoliDbContext)MainRepository.DbContext));
                        await MainRepository.UpdateAsync(currentType);
                    }
                    else
                    {
                        item.ApplicationOwnerId = OwnerInfo.ApplicationOwnerKey; item.DataOwnerId = OwnerInfo.DataOwnerKey; item.DataOwnerCenterId = OwnerInfo.DataOwnerCenterKey;
                        item.CreatedDate = item.LastUpdate = DateTime.Now;

                        item.BaseValues.ToList().ForEach(itemDetail =>
                        {
                            itemDetail.ApplicationOwnerId = item.ApplicationOwnerId;
                            itemDetail.DataOwnerId = OwnerInfo.DataOwnerKey;
                            itemDetail.DataOwnerCenterId = OwnerInfo.DataOwnerCenterKey;
                            itemDetail.CreatedDate = itemDetail.LastUpdate = item.CreatedDate;
                        });
                        await MainRepository.AddAsync(item);
                    }
                }
                await MainRepository.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Logger.Error("PublishAsync", ex);
                throw ex;
            }
        }

        public async Task<BaseType> SetBaseValueData(BaseType data, List<BaseValue> baseValues, AnatoliDbContext context)
        {
            await Task.Factory.StartNew(() =>
            {
                foreach (BaseValue item in baseValues)
                {
                    var count = data.BaseValues.ToList().Count(u => u.Id == item.Id);
                    if (count == 0)
                    {
                        item.BaseTypeId = data.Id;
                        item.ApplicationOwnerId = data.ApplicationOwnerId;
                        item.CreatedDate = item.LastUpdate = data.CreatedDate;
                        BaseValueRepository.Add(item);
                    }
                    else
                    {
                        BaseValueRepository.DeleteBatch(p => p.BaseTypeId == data.Id);
                        var currentBaseValue = BaseValueRepository.GetQuery().Where(p => p.Id == item.Id).FirstOrDefault();
                        if (currentBaseValue.BaseValueName != item.BaseValueName)
                        {
                            currentBaseValue.BaseValueName = item.BaseValueName;
                            currentBaseValue.LastUpdate = DateTime.Now;
                            BaseValueRepository.Update(currentBaseValue);
                        }
                    }
                }
                BaseValueRepository.SaveChanges();
            });
            return data;
        }
        #endregion
    }
}
