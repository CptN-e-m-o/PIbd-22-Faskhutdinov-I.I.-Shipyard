using System;
using System.Collections.Generic;
using AbstractShipyardContracts.BindingModels;
using AbstractShipyardContracts.ViewModels;

namespace AbstractShipyardContracts.StoragesContracts
{
    public interface IProductStorage
    {
        List<ProductViewModel> GetFullList();
        List<ProductViewModel> GetFilteredList(ProductBindingModel model);
        ProductViewModel GetElement(ProductBindingModel model);
        void Insert(ProductBindingModel model);
        void Update(ProductBindingModel model);
        void Delete(ProductBindingModel model);
    }
}
