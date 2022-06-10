using AbstractShipyardContracts.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AbstractShipyardDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int? ImplementerId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }

        public virtual Product Product { get; set; }

        public virtual Client Client { get; set; }

        public virtual Implementer Implementer { get; set; }
    }
}
