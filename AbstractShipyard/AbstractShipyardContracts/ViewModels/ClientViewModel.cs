using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;
using AbstractShipyardContracts.Attributes;

namespace AbstractShipyardContracts.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [Column(title: "Номер", width: 100)]
        [DataMember]
        public int Id { get; set; }

        [Column(title: "Клиент", width: 150)]
        [DataMember]
        public string ClientFIO { get; set; }

        [Column(title: "Email", width: 150)]
        [DataMember]
        public string Login { get; set; }

        [Column(title: "Пароль", width: 100)]
        [DataMember]
        public string Password { get; set; }
    }
}
