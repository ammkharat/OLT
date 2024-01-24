using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Analytics;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Excel;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    public class AnalyticsExcelExportDataRenderer : AbstractExcelDataRenderer, IExcelDataRenderer
    {
        private readonly List<Event> events;
        private readonly Dictionary<string, int> propertyKeyToColumnIndexMap; 

        private const int HEADER_ROW = 1;

        private const int EVENT_NAME_COL_INDEX = 0;
        private const int DATETIME_COL_INDEX = 1;
        private const int USER_ID_COL_INDEX = 2;
        private const int SITE_ID_COL_INDEX = 3;

        public AnalyticsExcelExportDataRenderer(List<Event> events)
        {
            this.events = events;
            this.propertyKeyToColumnIndexMap = new Dictionary<string, int>();
        }

        public void Populate(Workbook workbook)
        {
            Worksheet worksheet = workbook.Worksheets.Add("Events");

            CreateHeader(worksheet);
            CreateDataRows(worksheet);
        }

        private void CreateDataRows(Worksheet worksheet)
        {
            int row = 2;
            foreach (Event @event in events)
            {
                CreateDataRow(row++, worksheet, @event);
            }
        }

        private void CreateDataRow(int row, Worksheet worksheet, Event @event)
        {
            AddDataValue(worksheet, row, EVENT_NAME_COL_INDEX, @event.Name);
            AddDataValue(worksheet, row, DATETIME_COL_INDEX, @event.DateTime);
            AddDataValue(worksheet, row, USER_ID_COL_INDEX, @event.UserId);
            AddDataValue(worksheet, row, SITE_ID_COL_INDEX, @event.SiteId);

            foreach (Property property in @event.Properties)
            {
                string key = property.Key;
                int columnIndex = propertyKeyToColumnIndexMap[key];

                object value = null;
                if (property.Type == PropertyType.DateTime)
                {
                    value = property.DateTimeValue;
                }
                else if (property.Type == PropertyType.Text)
                {
                    value = property.TextValue;
                }
                else if (property.Type == PropertyType.Number)
                {
                    value = property.NumberValue;
                }

                AddDataValue(worksheet, row, columnIndex, value);
            }
        }

        private void AddDataValue(Worksheet worksheet, int rowIndex, int columnIndex, object value)
        {
            worksheet.Rows[rowIndex].Cells[columnIndex].Value = value;
        }

        private void CreateHeader(Worksheet worksheet)
        {
            AddHeaderForColumn(worksheet, EVENT_NAME_COL_INDEX, RendererStringResources.ExcelHeading_Name);
            AddHeaderForColumn(worksheet, DATETIME_COL_INDEX, RendererStringResources.ExcelHeading_Date);
            AddHeaderForColumn(worksheet, USER_ID_COL_INDEX, RendererStringResources.ExcelHeading_User);
            AddHeaderForColumn(worksheet, SITE_ID_COL_INDEX, RendererStringResources.ExcelHeading_Site);

            worksheet.Columns[EVENT_NAME_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
            worksheet.Columns[DATETIME_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
            worksheet.Columns[USER_ID_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 5);
            worksheet.Columns[SITE_ID_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);

            int currentWorksheetColumnIndex = SITE_ID_COL_INDEX + 1;

            foreach (Event @event in events)
            {
                foreach (Property property in @event.Properties)
                {
                    string key = property.Key;
                    if (!propertyKeyToColumnIndexMap.ContainsKey(key))
                    {
                        propertyKeyToColumnIndexMap[key] = currentWorksheetColumnIndex;
                        AddHeaderForColumn(worksheet, currentWorksheetColumnIndex, key);
                        currentWorksheetColumnIndex++;
                    }
                }
            }

            ApplyHeaderFormat(worksheet, HEADER_ROW);
        }

        private void AddHeaderForColumn(Worksheet worksheet, int columnIndex, string headerText)
        {
            MergeWithRowBefore(worksheet, HEADER_ROW, columnIndex, headerText);
        }
    }
}
