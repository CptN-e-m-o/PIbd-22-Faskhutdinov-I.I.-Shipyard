﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractShipyardContracts.BindingModels;
using AbstractShipyardContracts.StoragesContracts;
using AbstractShipyardContracts.ViewModels;
using AbstractShipyardDatabaseImplement.Models;

namespace AbstractShipyardDatabaseImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        public List<MessageInfoViewModel> GetFullList()
        {
            using var context = new AbstractShipyardDatabase();
            return context.Messages
            .Select(rec => new MessageInfoViewModel
            {
                MessageId = rec.MessageId,
                SenderName = rec.SenderName,
                DateDelivery = rec.DateDelivery,
                Subject = rec.Subject,
                Body = rec.Body
            })
            .ToList();
        }
        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new AbstractShipyardDatabase();
            return context.Messages
            .Where(rec => (model.ClientId.HasValue && rec.ClientId ==
            model.ClientId) ||
            (!model.ClientId.HasValue &&
            rec.DateDelivery.Date == model.DateDelivery.Date))
            .Select(rec => new MessageInfoViewModel
            {
                MessageId = rec.MessageId,
                SenderName = rec.SenderName,
                DateDelivery = rec.DateDelivery,
                Subject = rec.Subject,
                Body = rec.Body
            })
            .ToList();
        }
        public void Insert(MessageInfoBindingModel model)
        {
            using var context = new AbstractShipyardDatabase();
            if (context.Messages.FirstOrDefault(rec => rec.MessageId == model.MessageId) != null) return;
            if (model.ClientId == null) model.ClientId = context.Clients.FirstOrDefault(rec => rec.Login == model.FromMailAddress).Id;
            context.Messages.Add(new MessageInfo
            {
                MessageId = model.MessageId,
                ClientId = model.ClientId,
                SenderName = model.FromMailAddress,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                Body = model.Body
            });
            context.SaveChanges();
        }
    }
}
