using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.IRepository
{
    public interface IAttributeRepository
    {
        IEnumerable<ProductAttribute> GetProductAttributes();
        ProductAttribute GetProductAttributesById(int AttributeId);
        void AddProductAttributes(ProductAttribute ProductAttribute);
        void Save();
    }
}
