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
    public class ProductAttributesController : ControllerBase
    {
        private readonly IAttributeRepository attributeRepository;

        public ProductAttributesController(IAttributeRepository attributeRepository)
        {
            this.attributeRepository = attributeRepository;
        }

        //Get All ProductAttributes
        [HttpGet]
        public IActionResult Get()
        {
            var atrributes = attributeRepository.GetProductAttributes();
            return new OkObjectResult(atrributes);
        }

        // Get ProductAttributes by AttributeId
        [HttpGet("{id}", Name = "GetAttribute")]
        public IActionResult Get(int id)
        {
            var attribute = attributeRepository.GetProductAttributesById(id);
            return new OkObjectResult(attribute);
        }

        //POST Category
        [HttpPost]
        public IActionResult Post([FromBody] ProductAttribute productAttribute)
        {
            using (var scope = new TransactionScope())
            {
                attributeRepository.AddProductAttributes(productAttribute);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = productAttribute.ProductId }, productAttribute);
            }
        }
    }
}
