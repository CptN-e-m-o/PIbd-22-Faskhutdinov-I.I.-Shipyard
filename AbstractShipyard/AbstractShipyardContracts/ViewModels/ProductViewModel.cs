using System.Collections.Generic;
using System.ComponentModel;

namespace AbstractShipyardContracts.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое на верфи
    /// </summary>
    public class ProductViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        public string ProductName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> ProductComponents { get; set; }
    }
}