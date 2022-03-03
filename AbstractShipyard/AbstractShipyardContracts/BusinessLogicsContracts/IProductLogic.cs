using System.Collections.Generic;
using AbstractShipyardContracts.BindingModels;
using AbstractShipyardContracts.ViewModels;


namespace AbstractShipyardContracts.BusinessLogicsContracts
{
    public interface IProductLogic
    {
        List<ProductViewModel> Read(ProductBindingModel model);
        void CreateOrUpdate(ProductBindingModel model);
        void Delete(ProductBindingModel model);
    }
}