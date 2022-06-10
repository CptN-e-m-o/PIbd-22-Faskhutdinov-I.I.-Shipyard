using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using AbstractShipyardContracts.Attributes;

namespace AbstractShipyardContracts.ViewModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class ComponentViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }

        [Column(title: "Название ингредиента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }
    }
}
