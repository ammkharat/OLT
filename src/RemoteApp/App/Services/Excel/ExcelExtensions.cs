using System;
using System.Text;
using Infragistics.Excel;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    public static class ExcelExtensions
    {
        public static string GetCellValue(this Worksheet worksheet, int column, int row)
        {
            WorksheetCell worksheetCell = worksheet.GetCell(column, row);
            return worksheetCell.Value == null ? null : worksheetCell.Value.ToString();
        }

        public static string GetCellValue(this Worksheet worksheet, ExcelColumn column, int row)
        {
            WorksheetCell worksheetCell = worksheet.GetCell(column.Address(row));
            return worksheetCell.Value == null ? null : worksheetCell.Value.ToString();
        }

        public static string GetCellValue(this Worksheet worksheet, string column, int row)
        {
            WorksheetCell worksheetCell = worksheet.GetCell(column, row);
            return worksheetCell.Value == null ? null : worksheetCell.Value.ToString();
        }

        public static WorksheetCell GetCell(this Worksheet worksheet, string column, int row)
        {
            return worksheet.GetCell(new ExcelColumn(column).Address(row));
        }

        public static WorksheetCell GetCell(this Worksheet worksheet, int column, int row)
        {
            return worksheet.GetCell(new ExcelColumn(column).Address(row));
        }
    }

    public class ExcelColumn 
    {

        public ExcelColumn(int columnNumber)
        {
            ColumnNumber = columnNumber;
        }

        public ExcelColumn(string column)
        {
            ColumnNumber = TranslateColumnNameToNumber(column);
        }

        public int ColumnNumber { get; private set; }

        public void MoveNext()
        {
            ColumnNumber++;
        }

        public string Address(int rowNumber)
        {
            return string.Format("{0}{1}", GetColumnString(ColumnNumber), rowNumber);
        }

        protected bool Equals(ExcelColumn other)
        {
            return ColumnNumber == other.ColumnNumber;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ExcelColumn) obj);
        }

        public override int GetHashCode()
        {
            return ColumnNumber;
        }

        private const string _letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string GetColumnString(int column)
        {
            StringBuilder builder = new StringBuilder();
            do
            {
                if (builder.Length > 0)
                    column--;
                builder.Insert(0, _letters[column % _letters.Length]);
                column /= _letters.Length;
            } while (column > 0);

            return builder.ToString();
        }

        public static int TranslateColumnNameToNumber(string name)
        {
            int position = 0;

            char[] chars = name.ToUpperInvariant().ToCharArray();
            Array.Reverse(chars);
            for (var index = 0; index < chars.Length; index++)
            {
                var c = chars[index] - 64;
                position += index == 0 ? c : (c * (int)Math.Pow(26, index));
            }

            return position - 1;
        }

    }
}