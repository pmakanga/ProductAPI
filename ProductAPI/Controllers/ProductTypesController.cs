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
    public class ProductTypesController : ControllerBase
    {
        private readonly IProductTypeRepository productTypesRepository;

        public ProductTypesController(IProductTypeRepository productTypesRepository)
        {
            this.productTypesRepository = productTypesRepository;
        }

        //Get All ProductTypes
        [HttpGet]
        public IActionResult Get()
        {
            var producTypes = productTypesRepository.GetProductTypes();
            return new OkObjectResult(producTypes);
        }

        // Get ProductType by Id
        [HttpGet("{id}", Name = "GetProductType")]
        public IActionResult Get(int id)
        {
            var productType = productTypesRepository.GetProductTypeById(id);
            return new OkObjectResult(productType);
        }

        //POST ProductType
        [HttpPost]
        public IActionResult Post([FromBody] ProductType productType)
        {
            using (var scope = new TransactionScope())
            {
                productTypesRepository.AddProductType(productType);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = productType.ProductTypeId }, productType);
            }
        }
    }
}
