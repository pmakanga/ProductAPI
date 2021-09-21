using ProductAPI.Data;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.IRepository
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly DataContext dbContext;

        public AttributeRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddProductAttributes(ProductAttribute ProductAttribute)
        {
            dbContext.Add(ProductAttribute);
            Save();
        }

        public IEnumerable<ProductAttribute> GetProductAttributes()
        {
            return dbContext.ProductAttributes.ToList();
        }

        public ProductAttribute GetProductAttributesById(int AttributeId)
        {
            return dbContext.ProductAttributes.Find(AttributeId);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
