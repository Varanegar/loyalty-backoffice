﻿using System;
using System.Threading.Tasks;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess.Interfaces.Product;
using Loyalty.DataAccess.Models;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;

namespace Loyalty.DataAccess.Repositories
{
    public class ProductRepository : AnatoliRepository<Product>, IProductRepository
    {
        #region Ctors
        public ProductRepository() : this(new AnatoliDbContext()) { }
        public ProductRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public ProductRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }

        #endregion

        //notice: new custom methods could be added in here
        public override async Task DeleteAsync(Guid id)
        {
            var model = GetByIdAsync(id);

            if (model == null || model.Result == null)
                return;

            model.Result.IsRemoved = true;

            await UpdateAsync(model.Result);

            await SaveChangesAsync();
        }
        public override async Task DeleteAsync(Product entity)
        {
            await DeleteAsync(entity.Id);
        }
    }
}