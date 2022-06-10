﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using AbstractShipyardContracts.Enums;
using System.Runtime.Serialization;
using AbstractShipyardContracts.Attributes;

namespace AbstractShipyardContracts.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary> 
    public class OrderViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int? ImplementerId { get; set; }

        public int ProductId { get; set; }


        [Column(title: "Клиент", width: 150)]
        public string ClientFIO { get; set; }

        [Column(title: "Исполнитель", width: 150)]
        [DataMember]
        public string ImplementerFIO { get; set; }

        [Column(title: "Продукт", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ProductName { get; set; }
        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }

        [Column(title: "Сумма", width: 50)]
        public decimal Sum { get; set; }

        [Column(title: "Статус", width: 100)]
        public string Status { get; set; }

        [Column(title: "Дата создания", width: 100)]
        public DateTime DateCreate { get; set; }

        [Column(title: "Дата выполнения", width: 100)]
        public DateTime? DateImplement { get; set; }
    }
}
