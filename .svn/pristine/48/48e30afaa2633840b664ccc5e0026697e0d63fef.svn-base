using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Excel;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    public class FormOilsandsTrainingReportExcelDataRenderer : AbstractExcelDataRenderer, IExcelDataRenderer
    {
        private const int HEADER_ROW = 1;

        private const int FORM_NUMBER_COL_INDEX = 0;
        private const int STATUS_COL_INDEX = 1;
        private const int FLOC_COL_INDEX = 2;
        private const int TRAINING_DATE_COL_INDEX = 3;
        private const int WORK_ASSIGNMENT_COL_INDEX = 4;
        private const int CREATED_BY_COL_INDEX = 5;
        private const int BADGE_COL_INDEX = 6;
        private const int CREATED_DATE_TIME_COL_INDEX = 7;
        private const int BLOCK_COL_INDEX = 8;
        private const int TRAINING_CODE_COL_INDEX = 9;
        private const int TRAINING_BLOCK_COMMENTS_COL_INDEX = 10;
        private const int GENERAL_COMMENTS_COL_INDEX = 11;
        private const int TOTAL_HOURS_COL_INDEX = 12;
        private const int BLOCK_COMPLETED_COL_INDEX = 13;
        private const int APPROVAL_NAME_COL_INDEX = 14;
        private const int APPROVED_BY_NAME_COL_INDEX = 15;
        private const int APPROVED_DATE_TIME_COL_INDEX = 16;

        private readonly List<FormOilsandsTrainingReportDTO> dtos;

        public FormOilsandsTrainingReportExcelDataRenderer(List<FormOilsandsTrainingReportDTO> dtos)
        {
            this.dtos = dtos;
        }

        public void Populate(Workbook workbook)
        {
            Worksheet worksheet = workbook.Worksheets.Add("Worksheet");

            CreateHeader(worksheet);
            CreateDataRows(worksheet);
        }

        private void CreateDataRows(Worksheet worksheet)
        {
            int row = 2;
            foreach (FormOilsandsTrainingReportDTO dto in dtos)
            {
                CreateDataRow(row++, worksheet, dto);
            }
        }

        private void CreateDataRow(int row, Worksheet worksheet, FormOilsandsTrainingReportDTO dto)
        {
            int currentWorksheetColumnIndex = 0;

            currentWorksheetColumnIndex = AddDataValue(worksheet, row, FORM_NUMBER_COL_INDEX, dto.FormId, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, STATUS_COL_INDEX, dto.FormStatus.GetName(), currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, FLOC_COL_INDEX, dto.FunctionalLocations.BuildCommaSeparatedList(), currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, TRAINING_DATE_COL_INDEX, dto.TrainingDateString, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, WORK_ASSIGNMENT_COL_INDEX, dto.CreatedByAssignment, currentWorksheetColumnIndex);

            currentWorksheetColumnIndex = AddDataValue(worksheet, row, CREATED_BY_COL_INDEX, dto.CreatedByFullNameWithUserName, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, BADGE_COL_INDEX, dto.Badge, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, CREATED_DATE_TIME_COL_INDEX, dto.CreatedDateTime.ToShortDateAndTimeString(), currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, BLOCK_COL_INDEX, dto.BlockName, currentWorksheetColumnIndex);

            currentWorksheetColumnIndex = AddDataValue(worksheet, row, TRAINING_CODE_COL_INDEX, dto.TrainingCode, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, TRAINING_BLOCK_COMMENTS_COL_INDEX, dto.Comments, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, GENERAL_COMMENTS_COL_INDEX, dto.GeneralComments, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, TOTAL_HOURS_COL_INDEX, dto.Hours, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, BLOCK_COMPLETED_COL_INDEX, dto.BlockCompleted.BooleanToYesNoString(), currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, APPROVAL_NAME_COL_INDEX, dto.Approver, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, APPROVED_BY_NAME_COL_INDEX, dto.ApprovedByName, currentWorksheetColumnIndex);
            AddDataValue(worksheet, row, APPROVED_DATE_TIME_COL_INDEX, dto.ApprovedDateTime.ToShortDateAndTimeStringOrEmptyString(), currentWorksheetColumnIndex);
        }

        private int AddDataValue(Worksheet worksheet, int rowIndex, int columnIndex, object value, int currentWorksheetColumnIndex)
        {
            worksheet.Rows[rowIndex].Cells[columnIndex].Value = value;
            return ++currentWorksheetColumnIndex;
        }

        private void CreateHeader(Worksheet worksheet)
        {
            int currentWorksheetColumnIndex = 0;

            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, FORM_NUMBER_COL_INDEX, RendererStringResources.ExcelHeading_FormNumber, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, STATUS_COL_INDEX, RendererStringResources.ExcelHeading_Status, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, FLOC_COL_INDEX, RendererStringResources.ExcelHeading_FLOC, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, TRAINING_DATE_COL_INDEX, RendererStringResources.ExcelHeading_TrainingDate, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, WORK_ASSIGNMENT_COL_INDEX, RendererStringResources.ExcelHeading_CreatedByWorkAssignment, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, CREATED_BY_COL_INDEX, RendererStringResources.ExcelHeading_CreatedByName, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, BADGE_COL_INDEX, RendererStringResources.ExcelHeading_CreatedByBadge, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, CREATED_DATE_TIME_COL_INDEX, RendererStringResources.ExcelHeading_CreatedDateTime, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, BLOCK_COL_INDEX, RendererStringResources.ExcelHeading_Block, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, TRAINING_CODE_COL_INDEX, RendererStringResources.ExcelHeading_TrainingCode, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, TRAINING_BLOCK_COMMENTS_COL_INDEX, RendererStringResources.ExcelHeading_TrainingBlockComments, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, GENERAL_COMMENTS_COL_INDEX, RendererStringResources.ExcelHeading_GeneralComments, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, TOTAL_HOURS_COL_INDEX, RendererStringResources.ExcelHeading_TotalHours, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, BLOCK_COMPLETED_COL_INDEX, RendererStringResources.ExcelHeading_BlockCompleted, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, APPROVAL_NAME_COL_INDEX, RendererStringResources.ExcelHeading_ApprovedByWorkAssignment, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, APPROVED_BY_NAME_COL_INDEX, RendererStringResources.ExcelHeading_ApprovedByName, currentWorksheetColumnIndex);
            AddHeaderForColumn(worksheet, APPROVED_DATE_TIME_COL_INDEX, RendererStringResources.ExcelHeading_ApprovedDateTime, currentWorksheetColumnIndex);

            worksheet.Columns[FORM_NUMBER_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
            worksheet.Columns[STATUS_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
            worksheet.Columns[FLOC_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 5);
            worksheet.Columns[TRAINING_DATE_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);
            worksheet.Columns[WORK_ASSIGNMENT_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 5);
            worksheet.Columns[CREATED_BY_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);
            worksheet.Columns[BADGE_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
            worksheet.Columns[CREATED_DATE_TIME_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
            worksheet.Columns[BLOCK_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
            worksheet.Columns[TRAINING_CODE_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
            worksheet.Columns[TRAINING_BLOCK_COMMENTS_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);
            worksheet.Columns[GENERAL_COMMENTS_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);
            worksheet.Columns[TOTAL_HOURS_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
            worksheet.Columns[BLOCK_COMPLETED_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
            worksheet.Columns[APPROVAL_NAME_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);
            worksheet.Columns[APPROVED_BY_NAME_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);
            worksheet.Columns[APPROVED_DATE_TIME_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);            

            ApplyHeaderFormat(worksheet, HEADER_ROW);
        }

        private int AddHeaderForColumn(Worksheet worksheet, int columnIndex, string headerText, int currentWorksheetColumnIndex)
        {
            MergeWithRowBefore(worksheet, HEADER_ROW, columnIndex, headerText);
            return ++currentWorksheetColumnIndex;
        }
    }
}
