using AbstractShipyardContracts.BindingModels;
using AbstractShipyardContracts.ViewModels;
using System.Collections.Generic;

namespace AbstractShipyardContracts.BusinessLogicsContracts
{
    public interface IComponentLogic
    {
        List<ComponentViewModel> Read(ComponentBindingModel model);
        void CreateOrUpdate(ComponentBindingModel model);
        void Delete(ComponentBindingModel model);
    }
}