using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AbstractShipyardContracts.BindingModels
{
    /// <summary>
    /// Данные от клиента, для создания заказа
    /// </summary>
    public class CreateOrderBindingModel
    {
        public int ClientId { get; set; }

        public int ProductId { get; set; }

        public string ClientFIO { get; set; }

        public string ProductName { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

    }
}
