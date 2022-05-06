using AbstractShipyardContracts.BindingModels;
using AbstractShipyardContracts.BusinessLogicsContracts;
using AbstractShipyardContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AbstractShipyardRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IProductLogic _product;
        public MainController(IOrderLogic order, IProductLogic product)
        {
            _order = order;
            _product = product;
        }

        [HttpGet]
        public List<ProductViewModel> GetProductList() => _product.Read(null)?.ToList();

        [HttpGet]
        public ProductViewModel GetProduct(int productId) => _product.Read(new ProductBindingModel { Id = productId })?[0];

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _order.CreateOrder(model);
    }
}
