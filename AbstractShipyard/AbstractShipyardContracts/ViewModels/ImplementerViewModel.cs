using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using AbstractShipyardContracts.Attributes;

namespace AbstractShipyardContracts.ViewModels
{
    public class ImplementerViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }

        [Column(title: "ФИО исполнителя", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ImplementerFIO { get; set; }

        [Column(title: "Время работы", width: 50)]
        public int WorkingTime { get; set; }

        [Column(title: "Время отдыха", width: 50)]
        public int PauseTime { get; set; }
    }
}
