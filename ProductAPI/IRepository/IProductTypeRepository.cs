using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.IRepository
{
    public interface IProductTypeRepository
    {
        IEnumerable<ProductType> GetProductTypes();
        ProductType GetProductTypeById(int ProductTypeId);
        void AddProductType(ProductType ProductType);
        void Save();
    }
}
