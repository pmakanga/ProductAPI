using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    public class ProductAttribute
    {
        [Key]
        public int AttributeId { get; set; }
        public int? ProductId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }

    }
}
