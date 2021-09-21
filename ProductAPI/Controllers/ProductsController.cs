using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.IRepository;
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        //Get All Prodcuts
        [HttpGet]
        public IActionResult Get()
        {
            var products = productRepository.GetProducts();
            return new OkObjectResult(products);
        }

        // Get Product by Id
        [HttpGet("{id}", Name ="GetProduct")]
        public IActionResult Get(int id)
        {
            var product = productRepository.GetProductById(id);
            return new OkObjectResult(product);
        }

        // Get Product by Id


        [Route("[action]/{category}")]
        [HttpGet]
        public IActionResult GetByCategory(int categoryId)
        {
            var productByCategory = productRepository.GetProductByCategory(categoryId);
            if(productByCategory.Count == 0)
            {
                return NotFound();
            }
            return new OkObjectResult(productByCategory);
        }

        //POST Product
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            using (var scope = new TransactionScope())
            {
                productRepository.AddProduct(product);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = product.ProductId }, product);
            }
        }

        // PUT Product
        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            if (product != null)
            {
                using (var scope = new TransactionScope())
                {
                    productRepository.UpdateProduct(product);
                    scope.Complete();
                    return new OkResult();
                }
            }

            return new NoContentResult();
        }

    }
}
