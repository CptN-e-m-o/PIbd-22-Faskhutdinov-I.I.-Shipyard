using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AbstractShipyardContracts.ViewModels
{
    public class ImplementerViewModel
    {
        public int Id { get; set; }

        [DisplayName("ФИО исполнителя")]
        public string ImplementerFIO { get; set; }

        [DisplayName("Время работы")]
        public int WorkingTime { get; set; }

        [DisplayName("Время отдыха")]
        public int PauseTime { get; set; }
    }
}
