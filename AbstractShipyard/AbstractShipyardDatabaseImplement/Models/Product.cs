using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractShipyardDatabaseImplement.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("ProductId")]
        public virtual List<ProductComponent> ProductComponents { get; set; }
        [ForeignKey("ProductId")]
        public virtual List<Order> Orders { get; set; }
    }
}
