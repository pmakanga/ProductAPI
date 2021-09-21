using ProductAPI.Data;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.IRepository
{
    public class ProductSKURepository : IProductSKURepository
    {
        private readonly DataContext dbContext;

        public ProductSKURepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddProductSKU(ProductSKU ProductSku)
        {
            dbContext.Add(ProductSku);
            Save();
        }

        public IEnumerable<ProductSKU> GetProductSKUs()
        {
            return dbContext.ProductSKUs.ToList();
        }

        public ProductSKU GetProductSKUsById(int SkuId)
        {
            return dbContext.ProductSKUs.Find(SkuId);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
