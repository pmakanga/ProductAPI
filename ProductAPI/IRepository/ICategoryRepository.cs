using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.IRepository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoriesId(int CategoryId);
        void AddCategory(Category Category);

        void UpdateCategory(Category Category);

        void Save();
    }
}
