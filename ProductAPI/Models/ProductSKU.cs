using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Models
{
    public class ProductSKU
    {
        [Key]
        public int SkuId { get; set; }
        public string Sku { get; set; }
        public int? ProductId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public virtual Product Product { get; set; }
    }
}
