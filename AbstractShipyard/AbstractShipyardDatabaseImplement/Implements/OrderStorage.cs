using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractShipyardContracts.BindingModels;
using AbstractShipyardContracts.StoragesContracts;
using AbstractShipyardContracts.ViewModels;
using AbstractShipyardDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;


namespace AbstractShipyardDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using var context = new AbstractShipyardDatabase();

            return context.Orders.Include(rec => rec.Product).Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                ProductId = rec.ProductId,
                ProductName = rec.Product.ProductName,
                Count = rec.Count,
                Sum = rec.Sum,
                Status = rec.Status.ToString(),
                DateCreate = rec.DateCreate,
                DateImplement = rec.DateImplement
            }).ToList();
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new AbstractShipyardDatabase();

            return context.Orders.Include(rec => rec.Product).Where(rec => rec.ProductId == model.ProductId ||
            (rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo)).Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                ProductId = rec.ProductId,
                ProductName = rec.Product.ProductName,
                Count = rec.Count,
                Sum = rec.Sum,
                Status = rec.Status.ToString(),
                DateCreate = rec.DateCreate,
                DateImplement = rec.DateImplement
            }).ToList();
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new AbstractShipyardDatabase();

            var order = context.Orders.Include(rec => rec.Product).FirstOrDefault(rec => rec.Id == model.Id);

            return order != null ? CreateModel(order, context) : null;
        }

        public void Insert(OrderBindingModel model)
        {
            using var context = new AbstractShipyardDatabase();

            context.Orders.Add(CreateModel(model, new Order()));
            context.SaveChanges();
        }

        public void Update(OrderBindingModel model)
        {
            using var context = new AbstractShipyardDatabase();
            var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(OrderBindingModel model)
        {
            using var context = new AbstractShipyardDatabase();
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);

            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private static Order CreateModel(OrderBindingModel model, Order order)
        {
            order.ProductId = model.ProductId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }

        private static OrderViewModel CreateModel(Order order, AbstractShipyardDatabase context)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                ProductId = order.ProductId,
                ProductName = order.Product.ProductName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status.ToString(),
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
