﻿using AbstractShipyardBusinessLogic.OfficePackage;
using AbstractShipyardBusinessLogic.OfficePackage.HelperModels;
using AbstractShipyardContracts.BindingModels;
using AbstractShipyardContracts.BusinessLogicsContracts;
using AbstractShipyardContracts.StoragesContracts;
using AbstractShipyardContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractShipyardBusinessLogic.BusinessLogics
{
    public class ReportLogic : IReportLogic
    {

        private readonly IComponentStorage _componentStorage;
        private readonly IProductStorage _productStorage;
        private readonly IOrderStorage _orderStorage;

        private readonly AbstractSaveToExcel _saveToExcel;
        private readonly AbstractSaveToWord _saveToWord;
        private readonly AbstractSaveToPdf _saveToPdf;

        public ReportLogic(IProductStorage travelStorage, IComponentStorage conditionStorage, IOrderStorage orderStorage,
            AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf)
        {
            _productStorage = travelStorage;
            _componentStorage = conditionStorage;
            _orderStorage = orderStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportProductComponentViewModel> GetProductComponent()
        {
            var ingredients = _componentStorage.GetFullList();

            var pizzas = _productStorage.GetFullList();

            var list = new List<ReportProductComponentViewModel>();

            foreach (var pizza in pizzas)
            {
                var record = new ReportProductComponentViewModel
                {
                    ProductName = pizza.ProductName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var ingredient in ingredients)
                {
                    if (pizza.ProductComponents.ContainsKey(ingredient.Id))
                    {
                        record.Components.Add(new Tuple<string, int>(ingredient.ComponentName, pizza.ProductComponents[ingredient.Id].Item2));
                        record.TotalCount += pizza.ProductComponents[ingredient.Id].Item2;
                    }
                }

                list.Add(record);
            }

            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                OrderName = x.ProductName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
            .ToList();
        }
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                Products = _productStorage.GetFullList()
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveProductComponentToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                ProductComponents = GetProductComponent()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}
