using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.IRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext dbContext;

        public CategoryRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddCategory(Category Category)
        {
            dbContext.Add(Category);
            Save();
        }

        public Category GetCategoriesId(int CategoryId)
        {
            return dbContext.Categories.Find(CategoryId);
        }

        public IEnumerable<Category> GetCategories()
        {
            return dbContext.Categories.ToList();
        }

        public void UpdateCategory(Category Category)
        {
            dbContext.Entry(Category).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

    }
}
