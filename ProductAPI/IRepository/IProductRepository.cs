using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.IRepository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int ProductId);
        void AddProduct(Product Product);
        void DeleteProduct(int ProductId);
        void UpdateProduct(Product Product);
        IList<Product> GetProductByCategory(int CategoryId);
        void Save();
    }
}
