using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Excel;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    public class SafewWorkPermitAssessmentReportExcelDataRenderer : AbstractExcelDataRenderer, IExcelDataRenderer
    {
        private const int HEADER_ROW = 1;

        private const int SITE_COL_INDEX = 0;
        private const int FORM_NUMBER_COL_INDEX = 1;
        private const int VERSION_NUMBER_COL_INDEX = 2;
        private const int STATUS_COL_INDEX = 3;
        private const int FLOC_COL_INDEX = 4;
        private const int LOCATION_EQUIPMENT_NUMBER_COL_INDEX = 5;
        private const int PERMIT_START_DATE_TIME_COL_INDEX = 6;
        private const int PERMIT_EXPIRE_DATE_TIME_COL_INDEX = 7;
        private const int CREATED_BY_COL_INDEX = 8;
        private const int CREATED_DATE_TIME_COL_INDEX = 9;
        private const int LAST_MODIFIED_BY_COL_INDEX = 10;
        private const int LAST_MODIFIED_DATE_TIME_COL_INDEX = 11;
        private const int ILP_RECOMMENDED_COL_INDEX = 12;
        private const int PERMIT_NUMBER_COL_INDEX = 13;
        private const int PERMIT_TYPE_COL_INDEX = 14;
        private const int ISSUED_TO_SUNCOR_COL_INDEX = 15;
        private const int ISSUED_TO_CONTRACTOR_COL_INDEX = 16;
        private const int CONTRACTOR_COL_INDEX = 17;
        private const int TRADE_COL_INDEX = 18;
        private const int JOB_COORDINATOR_COL_INDEX = 19;
        private const int JOB_DESCRIPTION_COL_INDEX = 20;
        private const int CREW_SIZE_COL_INDEX = 21;
        private const int SECTION_COL_INDEX = 22;
        private const int QUESTION_NUMBER_COL_INDEX = 23;
        private const int QUESTION_COL_INDEX = 24;
        private const int SCORE_COL_INDEX = 25;
        private const int WEIGHT_COL_INDEX = 26;
        private const int QUESTION_FEEDBACK_COL_INDEX = 27;
        private const int OVERALL_SCORE_COL_INDEX = 28;
        private const int SECTION_WEIGHT_PERCENTAGE_COL_INDEX = 29;
        private const int SECTION_SCORE_PERCENTAGE_COL_INDEX = 30;
        private const int TOTAL_SCORE_PERCENTAGE_COL_INDEX = 31;
        private const int FEEDBACK_COL_INDEX = 32;
        
        private readonly List<SafeWorkPermitAssessmentReportDTO> dtos;

        public SafewWorkPermitAssessmentReportExcelDataRenderer(List<SafeWorkPermitAssessmentReportDTO> dtos)
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
            foreach (SafeWorkPermitAssessmentReportDTO dto in dtos)
            {
                CreateDataRow(row++, worksheet, dto);
            }
        }

        private void CreateDataRow(int row, Worksheet worksheet, SafeWorkPermitAssessmentReportDTO dto)
        {
            int currentWorksheetColumnIndex = 0;

            currentWorksheetColumnIndex = AddDataValue(worksheet, row, SITE_COL_INDEX, dto.Site, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, FORM_NUMBER_COL_INDEX, dto.FormNumber, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, VERSION_NUMBER_COL_INDEX, dto.VersionNumber, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, STATUS_COL_INDEX, dto.Status, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, FLOC_COL_INDEX, dto.Floc, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, LOCATION_EQUIPMENT_NUMBER_COL_INDEX, dto.LocationEquipmentNumber, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, PERMIT_START_DATE_TIME_COL_INDEX, dto.PermitStartDateTime.ToShortDateAndTimeString(), currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, PERMIT_EXPIRE_DATE_TIME_COL_INDEX, dto.PermitExpireDateTime.ToShortDateAndTimeString(), currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, CREATED_BY_COL_INDEX, dto.CreatedBy,currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, CREATED_DATE_TIME_COL_INDEX, dto.CreatedDateTime.ToShortDateAndTimeString(), currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, LAST_MODIFIED_BY_COL_INDEX, dto.LastModifiedBy,currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, LAST_MODIFIED_DATE_TIME_COL_INDEX, dto.LastModifiedDateTime.ToShortDateAndTimeString(), currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, ILP_RECOMMENDED_COL_INDEX, dto.IlpRecommended, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, PERMIT_NUMBER_COL_INDEX, dto.PermitNumber, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, PERMIT_TYPE_COL_INDEX, dto.PermitType, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, ISSUED_TO_SUNCOR_COL_INDEX, dto.IssuedToSuncor, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, ISSUED_TO_CONTRACTOR_COL_INDEX, dto.IssuedToContractor, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, CONTRACTOR_COL_INDEX, dto.Contractor, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, TRADE_COL_INDEX, dto.Trade, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, JOB_COORDINATOR_COL_INDEX, dto.JobCoordinator, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, JOB_DESCRIPTION_COL_INDEX, dto.JobDescription, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, CREW_SIZE_COL_INDEX, dto.CrewSize, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, SECTION_COL_INDEX, dto.Section, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, QUESTION_NUMBER_COL_INDEX, dto.QuestionNumber, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, QUESTION_COL_INDEX, dto.Question, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, SCORE_COL_INDEX, dto.Score, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, WEIGHT_COL_INDEX, dto.Weight, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, QUESTION_FEEDBACK_COL_INDEX, dto.QuestionFeedback, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, OVERALL_SCORE_COL_INDEX, dto.OverallScore, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, SECTION_WEIGHT_PERCENTAGE_COL_INDEX, dto.SectionWeightPercentage, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, SECTION_SCORE_PERCENTAGE_COL_INDEX, dto.SectionScorePercentage, currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddDataValue(worksheet, row, TOTAL_SCORE_PERCENTAGE_COL_INDEX, dto.TotalScorePercentage,currentWorksheetColumnIndex);
            AddDataValue(worksheet, row, FEEDBACK_COL_INDEX, dto.Feedback,currentWorksheetColumnIndex);
        
            
        }

        private int AddDataValue(Worksheet worksheet, int rowIndex, int columnIndex, object value, int currentWorksheetColumnIndex)
        {
            worksheet.Rows[rowIndex].Cells[columnIndex].Value = value;
            return ++currentWorksheetColumnIndex;
        }

        private void CreateHeader(Worksheet worksheet)
        {
            int currentWorksheetColumnIndex = 0;

            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, SITE_COL_INDEX, "Site", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, FORM_NUMBER_COL_INDEX, "Form Number", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, VERSION_NUMBER_COL_INDEX, "Questionnaire Version", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, STATUS_COL_INDEX, "Status", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, FLOC_COL_INDEX, "Functional Locations", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, LOCATION_EQUIPMENT_NUMBER_COL_INDEX, "Location/Equipment #", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, PERMIT_START_DATE_TIME_COL_INDEX, "Permit Start Date/Time", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, PERMIT_EXPIRE_DATE_TIME_COL_INDEX, "Permit Expire Date/Time", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, CREATED_BY_COL_INDEX, "Created By", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, CREATED_DATE_TIME_COL_INDEX, "Created On", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, LAST_MODIFIED_BY_COL_INDEX, "Last Modified By", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, LAST_MODIFIED_DATE_TIME_COL_INDEX, "Last Modified On", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, ILP_RECOMMENDED_COL_INDEX, "Is an ILP Recommended?", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, PERMIT_NUMBER_COL_INDEX, "Permit #", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, PERMIT_TYPE_COL_INDEX, "Permit Type", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, ISSUED_TO_SUNCOR_COL_INDEX, "Issued to Suncor?", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, ISSUED_TO_CONTRACTOR_COL_INDEX, "Issued to Contractor?", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, CONTRACTOR_COL_INDEX, "Contractor", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, TRADE_COL_INDEX, "Trade", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, JOB_COORDINATOR_COL_INDEX, "Job Coordinator", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, JOB_DESCRIPTION_COL_INDEX, "Job Description", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, CREW_SIZE_COL_INDEX, "Crew Size", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, SECTION_COL_INDEX, "Section", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, QUESTION_NUMBER_COL_INDEX, "Question Number", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, QUESTION_COL_INDEX, "Question", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, SCORE_COL_INDEX, "Score", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, WEIGHT_COL_INDEX, "Weight", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, QUESTION_FEEDBACK_COL_INDEX, "Question Feedback", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, OVERALL_SCORE_COL_INDEX, "Overall Score", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, SECTION_WEIGHT_PERCENTAGE_COL_INDEX, "Section Weight Percentage", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, SECTION_SCORE_PERCENTAGE_COL_INDEX, "Section Score Percentage", currentWorksheetColumnIndex);
            currentWorksheetColumnIndex = AddHeaderForColumn(worksheet, TOTAL_SCORE_PERCENTAGE_COL_INDEX, "Total Score Percentage", currentWorksheetColumnIndex);
            AddHeaderForColumn(worksheet, FEEDBACK_COL_INDEX, "Overall Feedback", currentWorksheetColumnIndex);
      
             worksheet.Columns[SITE_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);
             worksheet.Columns[FORM_NUMBER_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
             worksheet.Columns[VERSION_NUMBER_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);
             worksheet.Columns[STATUS_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 4);
             worksheet.Columns[FLOC_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 5);
             worksheet.Columns[LOCATION_EQUIPMENT_NUMBER_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
             worksheet.Columns[PERMIT_START_DATE_TIME_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);
             worksheet.Columns[PERMIT_EXPIRE_DATE_TIME_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);
             worksheet.Columns[CREATED_BY_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 4);
             worksheet.Columns[CREATED_DATE_TIME_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);
             worksheet.Columns[LAST_MODIFIED_BY_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 4);
             worksheet.Columns[LAST_MODIFIED_DATE_TIME_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);
             worksheet.Columns[ILP_RECOMMENDED_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);
             worksheet.Columns[PERMIT_NUMBER_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
             worksheet.Columns[PERMIT_TYPE_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
             worksheet.Columns[ISSUED_TO_SUNCOR_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
             worksheet.Columns[ISSUED_TO_CONTRACTOR_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);
             worksheet.Columns[CONTRACTOR_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 4);
             worksheet.Columns[TRADE_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 4);
             worksheet.Columns[JOB_COORDINATOR_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 5);
             worksheet.Columns[JOB_DESCRIPTION_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 5);
             worksheet.Columns[CREW_SIZE_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
             worksheet.Columns[SECTION_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 5);
             worksheet.Columns[QUESTION_NUMBER_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
             worksheet.Columns[QUESTION_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 7);
             worksheet.Columns[SCORE_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
             worksheet.Columns[WEIGHT_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
             worksheet.Columns[QUESTION_FEEDBACK_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 7);
             worksheet.Columns[OVERALL_SCORE_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);
             worksheet.Columns[SECTION_WEIGHT_PERCENTAGE_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);
             worksheet.Columns[SECTION_SCORE_PERCENTAGE_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);
             worksheet.Columns[TOTAL_SCORE_PERCENTAGE_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 3);
            worksheet.Columns[FEEDBACK_COL_INDEX].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 7);

            ApplyHeaderFormat(worksheet, HEADER_ROW);
        }

        private int AddHeaderForColumn(Worksheet worksheet, int columnIndex, string headerText, int currentWorksheetColumnIndex)
        {
            MergeWithRowBefore(worksheet, HEADER_ROW, columnIndex, headerText);
            return ++currentWorksheetColumnIndex;
        }
    }
}
