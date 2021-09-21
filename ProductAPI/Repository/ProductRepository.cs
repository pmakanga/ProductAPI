using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.IRepository;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.IRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext dbContext;

        public ProductRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddProduct(Product Product)
        {
            dbContext.Add(Product);
            Save();
        }

        public void DeleteProduct(int ProductId)
        {
            var product = dbContext.Products.Find(ProductId);
            dbContext.Products.Remove(product);
        }

        public Product GetProductById(int ProductId)
        {
            return dbContext.Products.Find(ProductId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return dbContext.Products.Include(s => s.ProductSKUs).ToList();
        }

        public void UpdateProduct(Product Product)
        {
            dbContext.Entry(Product).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public IList<Product> GetProductByCategory(int CategoryId)
        {
            return dbContext.Products.Where(s => s.CategoryId == CategoryId).ToList();
        }
    }
}
