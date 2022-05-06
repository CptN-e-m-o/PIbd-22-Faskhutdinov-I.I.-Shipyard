﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using AbstractShipyardContracts.Enums;
using System.Runtime.Serialization;

namespace AbstractShipyardContracts.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        public int? ImplementerId { get; set; }
        [DisplayName("ФИО исполнителя")]
        public string ImplementerFIO { get; set; }
        [DataMember]
        [DisplayName("ФИО клиента")]
        public string ClientFIO { get; set; }

        [DataMember]
        [DisplayName("Изделие")]
        public string ProductName { get; set; }

        [DataMember]
        [DisplayName("Количество")]
        public int Count { get; set; }

        [DataMember]
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }

        [DataMember]
        [DisplayName("Статус")]
        public string Status { get; set; }

        [DataMember]
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        [DataMember]
        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }


}
