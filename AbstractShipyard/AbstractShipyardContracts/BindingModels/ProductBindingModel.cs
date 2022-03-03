using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShipyardContracts.BindingModels
{
    /// <summary>
    /// Изделие, изготавливаемое на верфи
    /// </summary>
    public class ProductBindingModel
    {
        public int? Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> ProductComponents { get; set; }
    }
}
