using System.Drawing;
using Infragistics.Excel;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    public abstract class AbstractExcelDataRenderer
    {
        protected static void ApplyHeaderFormat(Worksheet worksheet, int row)
        {
            for (int i = 0; i <= row; i++)
            {
                IWorksheetCellFormat worksheetCellFormat = worksheet.Rows[i].CellFormat;
                ApplyHeaderFormat(worksheetCellFormat);
            }

            foreach (WorksheetMergedCellsRegion region in worksheet.MergedCellsRegions)
            {
                ApplyHeaderFormat(region.CellFormat);
            }
        }

        protected static void ApplyHeaderFormat(IWorksheetCellFormat worksheetCellFormat)
        {
            worksheetCellFormat.WrapText = ExcelDefaultableBoolean.True;
            worksheetCellFormat.Font.Bold = ExcelDefaultableBoolean.True;
            worksheetCellFormat.Alignment = HorizontalCellAlignment.Center;

            worksheetCellFormat.FillPattern = FillPatternStyle.Solid;
            worksheetCellFormat.FillPatternForegroundColor = Color.LightGray;

            worksheetCellFormat.LeftBorderStyle = CellBorderLineStyle.Thin;
            worksheetCellFormat.RightBorderStyle = CellBorderLineStyle.Thin;
            worksheetCellFormat.TopBorderStyle = CellBorderLineStyle.Thin;
            worksheetCellFormat.BottomBorderStyle = CellBorderLineStyle.Thin;

            worksheetCellFormat.LeftBorderColor = Color.Black;
            worksheetCellFormat.RightBorderColor = Color.Black;
            worksheetCellFormat.TopBorderColor = Color.Black;
            worksheetCellFormat.BottomBorderColor = Color.Black;
        }


        protected static void MergeWithRowBefore(Worksheet worksheet, int row, int column, string value)
        {
            worksheet.Rows[row].Cells[column].Value = value;
            worksheet.MergedCellsRegions.Add(row - 1, column, row, column);
        }

        protected static void MakeMergedRowBefore(
            Worksheet worksheet, int row, ref int column, string beforeRowValue, params string[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                string value = values[i];
                worksheet.Rows[row].Cells[column + i].Value = value;
            }

            worksheet.Rows[row - 1].Cells[column].Value = beforeRowValue;
            worksheet.MergedCellsRegions.Add(row - 1, column, row - 1, column + values.Length - 1);

            column += values.Length;
        }

    }
}
