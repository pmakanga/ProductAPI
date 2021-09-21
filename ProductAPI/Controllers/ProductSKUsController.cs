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
    public class ProductSKUsController : ControllerBase
    {
        private readonly IProductSKURepository productSkuRepository;

        public ProductSKUsController(IProductSKURepository productSkuRepository)
        {
            this.productSkuRepository = productSkuRepository;
        }

        //Get All ProductSKUs
        [HttpGet]
        public IActionResult Get()
        {
            var producSku = productSkuRepository.GetProductSKUs();
            return new OkObjectResult(producSku);
        }

        // Get ProductSKU by Id
        [HttpGet("{id}", Name = "GetProductSKU")]
        public IActionResult Get(int id)
        {
            var productSku = productSkuRepository.GetProductSKUsById(id);
            return new OkObjectResult(productSku);
        }

        //POST ProductSKU
        [HttpPost]
        public IActionResult Post([FromBody] ProductSKU productSku)
        {
            using (var scope = new TransactionScope())
            {
                productSkuRepository.AddProductSKU(productSku);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = productSku.SkuId }, productSku);
            }
        }
    }
}
