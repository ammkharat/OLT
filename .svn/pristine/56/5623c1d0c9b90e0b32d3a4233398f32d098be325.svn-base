using Com.Suncor.Olt.Common.Exceptions;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class ColumnFormatter
    {
        // When using "Start Time" and "End Time" this is the width needed to include the text, sort indicator and filter.
        private const int TimeColumnMinWidth = 85;
        // When using "Start Date" and "End Date" this is the width needed to include the text, sort indicator and filter.
        private const int DateColumnMinWidth = 90;

        private readonly UltraGridBand band;
        private int column;

        public ColumnFormatter(UltraGridBand band)
        {
            this.band = band;
        }

        public void FormatAsDate(string columnName, string columnHeaderCaption)
        {
            CheckColumnExists(columnName);
            band.Columns[columnName].FormatAsDate(columnHeaderCaption, column++, DateColumnMinWidth);
        }

        public void FormatAsDate(string columnName, string columnHeaderCaption, string defaultNullText)
        {
            CheckColumnExists(columnName);
            band.Columns[columnName].FormatAsDate(columnHeaderCaption, column++, DateColumnMinWidth);
            band.Columns[columnName].NullText = defaultNullText;
        }

        public void FormatAsString(string columnName, string columnHeaderCaption)
        {
            CheckColumnExists(columnName);
            band.Columns[columnName].Format(columnHeaderCaption, column++);
        }

        public void FormatAsDateTime(string columnName, string columnHeaderCaption)
        {
            CheckColumnExists(columnName);
            band.Columns[columnName].FormatAsDateTime(columnHeaderCaption, column++);
        }

        private void CheckColumnExists(string columnName)
        {
            if (band.Columns.IndexOf(columnName) == -1)
            {
                throw new OLTException("Could not find column '{0}' in grid to apply formatting.", columnName);
            }
        }

        public void FormatAsTime(string columnName, string columnHeaderCaption)
        {
            CheckColumnExists(columnName);
            band.Columns[columnName].FormatAsTime(columnHeaderCaption, column++, TimeColumnMinWidth);
        }

        public void FormatAsTime(string columnName, string columnHeaderCaption, string defaultNullText)
        {
            CheckColumnExists(columnName);
            band.Columns[columnName].FormatAsTime(columnHeaderCaption, column++, TimeColumnMinWidth);
            band.Columns[columnName].NullText = defaultNullText;
        }

        public void FormatAsString(string columnName, string columnHeaderCaption, int width, bool rightJustified)
        {
            CheckColumnExists(columnName);
            band.Columns[columnName].Format(columnHeaderCaption, column++, width, rightJustified);
        }

        public void FormatAsString(string columnName, string columnHeaderCaption, int width)
        {
            CheckColumnExists(columnName);
            band.Columns[columnName].Format(columnHeaderCaption, column++, width);
        }

        public void FormatAsDecimal(string columnName, string columnHeaderCaption, int width, bool rightJustify)
        {
            CheckColumnExists(columnName);
            band.Columns[columnName].FormatAsDecimal(columnHeaderCaption, column++ ,width, rightJustify);
        }
    }
}