using AbstractShipyardContracts.ViewModels;
using System.Collections.Generic;

namespace AbstractShipyardBusinessLogic.OfficePackage.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
