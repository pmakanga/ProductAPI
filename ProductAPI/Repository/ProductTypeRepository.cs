using ProductAPI.Data;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.IRepository
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly DataContext dbContext;

        public ProductTypeRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddProductType(ProductType ProductType)
        {
            try
            {
                dbContext.Add(ProductType);
                Save();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ProductType GetProductTypeById(int ProductTypeId)
        {
            return dbContext.ProductTypes.Find(ProductTypeId);
        }

        public IEnumerable<ProductType> GetProductTypes()
        {
            return dbContext.ProductTypes.ToList();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
