using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public ProductCategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        //Get All ProductsCategories
        [HttpGet]
        public IActionResult Get()
        {
            var categories = categoryRepository.GetCategories();
            return new OkObjectResult(categories);
        }

        // Get Category by Id
        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult Get(int id)
        {
            var category = categoryRepository.GetCategoriesId(id);
            return new OkObjectResult(category);
        }

        //POST Category
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            using (var scope = new TransactionScope())
            {
                categoryRepository.AddCategory(category);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = category.CategoryId }, category);
            }
        }

        // PUT Product
        [HttpPut]
        public IActionResult Put([FromBody] Category category)
        {
            if (category != null)
            {
                using (var scope = new TransactionScope())
                {
                    categoryRepository.UpdateCategory(category);
                    scope.Complete();
                    return new OkResult();
                }
            }

            return new NoContentResult();
        }
    }
}
