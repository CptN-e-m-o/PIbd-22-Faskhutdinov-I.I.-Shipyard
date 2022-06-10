using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using AbstractShipyardContracts.Attributes;

namespace AbstractShipyardContracts.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое на верфи
    /// </summary>
    [DataContract]
    public class ProductViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }

        [Column(title: "Название продукта", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ProductName { get; set; }


        [Column(title: "Цена", gridViewAutoSize: GridViewAutoSize.Fill)]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> ProductComponents { get; set; }
    }
}