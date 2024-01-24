using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Excel;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    public class CustomFieldTrendReportExcelDataRenderer : AbstractExcelDataRenderer, IExcelDataRenderer
    {
        private const int HEADER_ROW = 1;

        private const int LOG_TYPE_COL_INDEX = 0;
        private const int LOG_DATE_TIME_COL_INDEX = 1;
        private const int SHIFT_COL_INDEX = 2;
        private const int FLOC_COL_INDEX = 3;
        private const int EDITED_BY_COL_INDEX = 4;
        private const int ASSIGNMENT_COL_INDEX = 5;

        private const int NUMBER_OF_STATIC_COLUMNS = 6;

        private readonly List<CustomFieldTrendReportDTO> dtos;
        private readonly int maxColumnsPerWorksheet;

        public CustomFieldTrendReportExcelDataRenderer(List<CustomFieldTrendReportDTO> dtos)
            : this(dtos, 256)  // 256 columns is an Excel 2003 limitation; if Suncor upgrades and we start saving in a new format, we can change this
        {
        }

        public CustomFieldTrendReportExcelDataRenderer(List<CustomFieldTrendReportDTO> dtos, int maxColumnsPerWorksheet)
        {
            if (maxColumnsPerWorksheet <= NUMBER_OF_STATIC_COLUMNS)
            {
                throw new ArgumentOutOfRangeException(String.Format("The max. number of columns per worksheet must be greater than {0}", NUMBER_OF_STATIC_COLUMNS));
            }

            this.dtos = dtos;
            this.maxColumnsPerWorksheet = maxColumnsPerWorksheet;
        }

        public void Populate(Workbook workbook)
        {
            int numberOfCustomFieldEntries = 0;
            if (dtos.Count != 0)
            {
                numberOfCustomFieldEntries = dtos[0].CustomFieldEntries.Count;
            }

            int totalNumberOfColumns = NUMBER_OF_STATIC_COLUMNS + numberOfCustomFieldEntries;

            for (int i = 0; i < totalNumberOfColumns; i += maxColumnsPerWorksheet)
            {
                Worksheet worksheet = workbook.Worksheets.Add(String.Format("Page {0}", (i / maxColumnsPerWorksheet) + 1));

                int startColumnIndex = i;
                int endColumnIndex = i + maxColumnsPerWorksheet - 1;
                CreateHeader(worksheet, startColumnIndex, endColumnIndex);
                CreateDataRows(worksheet, startColumnIndex, endColumnIndex);
            }
        }

        private void CreateHeader(Worksheet worksheet, int startColumn, int endColumn)
        {
            int currentWorksheetColumnIndex = 0;

            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, LOG_TYPE_COL_INDEX, RendererStringResources.ExcelHeading_Type, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, LOG_DATE_TIME_COL_INDEX, RendererStringResources.ExcelHeading_LogDate, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, SHIFT_COL_INDEX, RendererStringResources.ExcelHeading_Shift, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, FLOC_COL_INDEX, RendererStringResources.ExcelHeading_FLOC, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, EDITED_BY_COL_INDEX, RendererStringResources.ExcelHeading_EditedBy, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, ASSIGNMENT_COL_INDEX, RendererStringResources.ExcelHeading_Assignment, currentWorksheetColumnIndex);

            worksheet.Columns[LOG_DATE_TIME_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
            worksheet.Columns[ASSIGNMENT_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 5);
            worksheet.Columns[FLOC_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 5);
            worksheet.Columns[EDITED_BY_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);

            if (dtos.Count > 0)
            {
                int startingCustomFieldIndex = (startColumn - NUMBER_OF_STATIC_COLUMNS);
                int endingCustomFieldIndex = (endColumn - NUMBER_OF_STATIC_COLUMNS);

                if (startingCustomFieldIndex < 0)
                {
                    startingCustomFieldIndex = 0;
                }

                CustomFieldTrendReportDTO dto = dtos[0];
                for (int i = startingCustomFieldIndex; i <= endingCustomFieldIndex; i++)
                {
                    if (dto.CustomFieldEntries.HasIndex(i))
                    {
                        CustomFieldEntry customFieldEntry = dto.CustomFieldEntries[i];
                        MergeWithRowBefore(worksheet, HEADER_ROW, currentWorksheetColumnIndex, customFieldEntry.CustomFieldName);
                        currentWorksheetColumnIndex += 1;
                    }
                }
            }

            ApplyHeaderFormat(worksheet, HEADER_ROW);
        }

        private int AddHeaderForColumn(Worksheet worksheet, int columnIndex, string headerText, int currentWorksheetColumnIndex)
        {
            MergeWithRowBefore(worksheet, HEADER_ROW, columnIndex, headerText);
            return ++currentWorksheetColumnIndex;
        }

        private int AddDataValue(Worksheet worksheet, int rowIndex, int columnIndex, object value, int currentWorksheetColumnIndex)
        {
            worksheet.Rows[rowIndex].Cells[columnIndex].Value = value;
            return ++currentWorksheetColumnIndex;
        }

        private void CreateDataRows(Worksheet worksheet, int startColumn, int endColumn)
        {
            int row = 2;
            foreach (CustomFieldTrendReportDTO dto in dtos)
            {
                CreateDataRow(row++, worksheet, dto, startColumn, endColumn);
            }
        }

        private void CreateDataRow(int row, Worksheet worksheet, CustomFieldTrendReportDTO dto, int startColumn, int endColumn)
        {
            int currentWorksheetColumnIndex = 0;

            currentWorksheetColumnIndex = AddDataValue(worksheet, row, LOG_TYPE_COL_INDEX, dto.LogTypeName, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, LOG_DATE_TIME_COL_INDEX, dto.LogDateTime, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, SHIFT_COL_INDEX, dto.ShiftName, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, FLOC_COL_INDEX, dto.FunctionalLocationNames, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, EDITED_BY_COL_INDEX, dto.LastModifiedByFullNameWithUserName, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, ASSIGNMENT_COL_INDEX, dto.WorkAssignmentName, currentWorksheetColumnIndex);

            int startingCustomFieldIndex = (startColumn - NUMBER_OF_STATIC_COLUMNS);
            int endingCustomFieldIndex = (endColumn - NUMBER_OF_STATIC_COLUMNS);

            if (startingCustomFieldIndex < 0)
            {
                startingCustomFieldIndex = 0;
            }

            for (int i = startingCustomFieldIndex; i <= endingCustomFieldIndex; i++)
            {
                if (dto.CustomFieldEntries.HasIndex(i))
                {
                    CustomFieldEntry customFieldEntry = dto.CustomFieldEntries[i];
                    if (customFieldEntry.Type.Equals(CustomFieldType.NumericValue))
                    {
                        worksheet.Rows[row].Cells[currentWorksheetColumnIndex].Value = customFieldEntry.NumericFieldEntry;
                    }
                    else
                    {
                        decimal result;
                        bool parseWasSuccessful = Decimal.TryParse(customFieldEntry.FieldEntry, out result);
                        if (parseWasSuccessful)
                        {
                            worksheet.Rows[row].Cells[currentWorksheetColumnIndex].Value = result;
                        }
                        else
                        {
                            worksheet.Rows[row].Cells[currentWorksheetColumnIndex].Value = customFieldEntry.FieldEntryForDisplay;
                        }
                    }
                    currentWorksheetColumnIndex += 1;
                }
            }
        }
    }
}
