using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.IRepository
{
    public interface IProductSKURepository
    {
        IEnumerable<ProductSKU> GetProductSKUs();
        ProductSKU GetProductSKUsById(int SkuId);
        void AddProductSKU(ProductSKU ProductSku);
        void Save();
    }
}
