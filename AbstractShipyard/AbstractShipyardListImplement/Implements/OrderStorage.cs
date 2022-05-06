﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractShipyardContracts.StoragesContracts;
using AbstractShipyardContracts.ViewModels;
using AbstractShipyardContracts.BindingModels;
using AbstractShipyardListImplement.Models;

namespace AbstractShipyardListImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataListSingleton source;
        public OrderStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetFullList()
        {
            var result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                result.Add(CreateModel(order));
            }
            return result;
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if (order.Id == model.Id || (model.DateFrom.HasValue && model.DateTo.HasValue &&
                    order.DateCreate >= model.DateFrom && order.DateCreate <= model.DateTo)
                    || (model.ClientId.HasValue && order.ClientId == model.ClientId.Value)
                    || (model.SearchStatus.HasValue && model.SearchStatus.Value == order.Status)
                    || (model.ImplementerId.HasValue && order.ImplementerId == model.ImplementerId && model.Status == order.Status))
                {
                    result.Add(CreateModel(order));
                }
            }
            return result;
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var order in source.Orders)
            {
                if (model.Id == order.Id)
                {
                    return CreateModel(order);
                }
            }
            return null;
        }
        public void Insert(OrderBindingModel model)
        {
            var tempOrder = new Order { Id = 1 };
            foreach (var order in source.Orders)
            {
                if (order.Id >= tempOrder.Id)
                {
                    tempOrder.Id = order.Id + 1;
                }
            }
            source.Orders.Add(CreateModel(model, tempOrder));
        }
        public void Update(OrderBindingModel model)
        {
            Order tempOrder = null;
            foreach (var order in source.Orders)
            {
                if (model.Id == order.Id)
                {
                    tempOrder = order;
                }
            }
            if (tempOrder == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempOrder);
        }
        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.ProductId = model.ProductId;
            order.ClientId = model.ClientId.Value;
            order.ImplementerId = model.ImplementerId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }

        private OrderViewModel CreateModel(Order order)
        {
            string ProductName = null;
            for (int j = 0; j < source.Products.Count; ++j)
            {
                if (source.Products[j].Id == order.ProductId)
                {
                    ProductName = source.Products[j].ProductName;
                    break;
                }
            }
            string ClientFIO = null;
            for (int j = 0; j < source.Clients.Count; ++j)
            {
                if (source.Clients[j].Id == order.ClientId)
                {
                    ClientFIO = source.Clients[j].ClientFIO;
                    break;
                }
            }
            string ImplementerFIO = null;
            for (int j = 0; j < source.Implementers.Count; ++j)
            {
                if (source.Implementers[j].Id == order.ImplementerId)
                {
                    ImplementerFIO = source.Implementers[j].ImplementerFIO;
                    break;
                }
            }
            return new OrderViewModel
            {
                Id = order.Id,
                ProductId = order.ProductId,
                ClientId = order.ClientId,
                ClientFIO = ClientFIO,
                ImplementerId = order.ImplementerId,
                ImplementerFIO = ImplementerFIO,
                ProductName = ProductName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status.ToString(),
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}