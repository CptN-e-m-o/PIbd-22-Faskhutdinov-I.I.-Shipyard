using AbstractShipyardContracts.BindingModels;
using AbstractShipyardContracts.BusinessLogicsContracts;
using AbstractShipyardContracts.StoragesContracts;
using AbstractShipyardContracts.ViewModels;
using AbstractShipyardContracts.Enums;
using System;
using System.Collections.Generic;

namespace AbstractShipyardBusinessLogic.BusinessLogics
{
    public class ProductLogic : IProductLogic
    {
         private readonly IProductStorage _productStorage;

        public ProductLogic(IProductStorage travelStorage)
        {
            _productStorage = travelStorage;
        }

        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            if (model == null)
            {
                return _productStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ProductViewModel> { _productStorage.GetElement(model) };
            }
            return _productStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ProductBindingModel model)
        {
            var element = _productStorage.GetElement(new ProductBindingModel { ProductName = model.ProductName });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такая машина с таким названием");
            }
            if (model.Id.HasValue)
            {
                _productStorage.Update(model);
            }
            else
            {
                _productStorage.Insert(model);
            }
        }

        public void Delete(ProductBindingModel model)
        {
            var element = _productStorage.GetElement(new ProductBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Путевка не найдена");
            }
            _productStorage.Delete(model);
        }
    }
}
