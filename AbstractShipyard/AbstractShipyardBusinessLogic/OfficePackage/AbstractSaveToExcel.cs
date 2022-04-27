using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractShipyardBusinessLogic.OfficePackage.HelperEnums;
using AbstractShipyardBusinessLogic.OfficePackage.HelperModels;

namespace AbstractShipyardBusinessLogic.OfficePackage
{
	public abstract class AbstractSaveToExcel
	{
		// Создание отчета
		public void CreateReport(ExcelInfo info)
		{
			CreateExcel(info);

			InsertCellInWorksheet(new ExcelCellParameters
			{
				ColumnName = "A",
				RowIndex = 1,
				Text = info.Title,
				StyleInfo = ExcelStyleInfoType.Title
			});

			MergeCells(new ExcelMergeParameters
			{
				CellFromName = "A1",
				CellToName = "C1"
			});

			uint rowIndex = 2;
			foreach (var tc in info.ProductComponents)
			{
				InsertCellInWorksheet(new ExcelCellParameters
				{
					ColumnName = "A",
					RowIndex = rowIndex,
					Text = tc.ProductName,
					StyleInfo = ExcelStyleInfoType.Text
				});
				rowIndex++;

				foreach (var condition in tc.Components)
				{
					InsertCellInWorksheet(new ExcelCellParameters
					{
						ColumnName = "B",
						RowIndex = rowIndex,
						Text = condition.Item1,
						StyleInfo = ExcelStyleInfoType.TextWithBroder
					});

					InsertCellInWorksheet(new ExcelCellParameters
					{
						ColumnName = "C",
						RowIndex = rowIndex,
						Text = condition.Item2.ToString(),
						StyleInfo = ExcelStyleInfoType.TextWithBroder
					});
					rowIndex++;
				}

				InsertCellInWorksheet(new ExcelCellParameters
				{
					ColumnName = "C",
					RowIndex = rowIndex,
					Text = tc.TotalCount.ToString(),
					StyleInfo = ExcelStyleInfoType.Text
				});
				rowIndex++;
			}

			SaveExcel(info);
		}

		// Создание excel-файла
		protected abstract void CreateExcel(ExcelInfo info);

		// Добавляем новую ячейку в лист
		protected abstract void InsertCellInWorksheet(ExcelCellParameters excelParams);

		// Объединение ячеек
		protected abstract void MergeCells(ExcelMergeParameters excelParams);

		// Сохранение файла
		protected abstract void SaveExcel(ExcelInfo info);
	}
}
