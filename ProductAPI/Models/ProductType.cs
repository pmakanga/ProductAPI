using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        public ProductTypeName ProductTypeName { get; set; }
        public string ProductTypeDesc { get; set; }
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }

    }

    public enum ProductTypeName
    {
        Standard = 100,
        Variants = 200,
        Composite = 300
    }
}
