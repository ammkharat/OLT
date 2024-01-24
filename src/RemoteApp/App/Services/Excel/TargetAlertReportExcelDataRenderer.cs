using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Excel;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    public class TargetAlertReportExcelDataRenderer : AbstractExcelDataRenderer, IExcelDataRenderer
    {
        private readonly List<TargetAlertExcelReportDTO> dtos;

        private const int CREATED_COL_INDEX = 0;
        private const int LAST_VIOLATED_COL_INDEX = 1;
        private const int FLOC_COL_INDEX = 2;
        private const int STATUS_COL_INDEX = 3;
        private const int DEF_NAME_COL_INDEX = 4;
        private const int TAG_NAME_COL_INDEX = 5;
        private const int VALUE_COL_INDEX = 6;
        private const int VALUE_EVAL_COL_INDEX = 7;
        private const int NTE_MAX_EVAL_COL_INDEX = 8;
        private const int NTE_MIN_EVAL_COL_INDEX = 9;
        private const int MAX_EVAL_COL_INDEX = 10;
        private const int MIN_EVAL_COL_INDEX = 11;

        private const int IS_ACTIVE_COL_INDEX = 12;

        private const int BIGGEST_INDEX = 12;

        private int globalDynamicColumnMarker = 0;

        private const int AverageCharacterWidth = 290; // just a guess that works good enough.

        public TargetAlertReportExcelDataRenderer(List<TargetAlertExcelReportDTO> dtos)
        {
            this.dtos = dtos;
        }

        public void Populate(Workbook workbook)
        {
            Worksheet worksheet = workbook.Worksheets.Add(RendererStringResources.ExcelTab_TargetAlertReport);
            CreatedHeader(worksheet);
            CreateDataRows(worksheet);
        }

        private void CreateDataRows(Worksheet worksheet)
        {
            int row = 2;
            foreach (TargetAlertExcelReportDTO dto in dtos)
            {
                CreateDataRow(row++, worksheet, dto);
            }

            worksheet.Columns[CREATED_COL_INDEX].Width = 19 * AverageCharacterWidth;
            worksheet.Columns[LAST_VIOLATED_COL_INDEX].Width = 19 * AverageCharacterWidth;
            worksheet.Columns[FLOC_COL_INDEX].Width = 27 * AverageCharacterWidth;
            worksheet.Columns[DEF_NAME_COL_INDEX].Width = 27 * AverageCharacterWidth;
            worksheet.Columns[VALUE_EVAL_COL_INDEX].Width = 12 * AverageCharacterWidth;
            worksheet.Columns[NTE_MAX_EVAL_COL_INDEX].Width = 12 * AverageCharacterWidth;
            worksheet.Columns[NTE_MIN_EVAL_COL_INDEX].Width = 12 * AverageCharacterWidth;
        }

        private void CreateDataRow(int row, Worksheet worksheet, TargetAlertExcelReportDTO dto)
        {                  
            worksheet.Rows[row].Cells[CREATED_COL_INDEX].Value = dto.CreatedDateTime;
            worksheet.Rows[row].Cells[LAST_VIOLATED_COL_INDEX].Value = dto.LastViolatedDateTime;            
            worksheet.Rows[row].Cells[FLOC_COL_INDEX].Value = dto.FunctionalLocationName;
            worksheet.Rows[row].Cells[STATUS_COL_INDEX].Value = dto.TypeOfViolationStatus != null ? dto.Status.GetName() : "";
            worksheet.Rows[row].Cells[DEF_NAME_COL_INDEX].Value = dto.TargetDefinitionName;
            worksheet.Rows[row].Cells[TAG_NAME_COL_INDEX].Value = dto.TagNameFromAlert;
            worksheet.Rows[row].Cells[VALUE_COL_INDEX].Value = dto.ActualValue;
            worksheet.Rows[row].Cells[VALUE_EVAL_COL_INDEX].Value = dto.ActualValueAtEvaluation;
            worksheet.Rows[row].Cells[NTE_MAX_EVAL_COL_INDEX].Value = dto.NTEMaxAtEvaluation;
            worksheet.Rows[row].Cells[NTE_MIN_EVAL_COL_INDEX].Value = dto.NTEMinAtEvaluation;
            worksheet.Rows[row].Cells[MAX_EVAL_COL_INDEX].Value = dto.MaxAtEvaluation;
            worksheet.Rows[row].Cells[MIN_EVAL_COL_INDEX].Value = dto.MinAtEvaluation;            
            worksheet.Rows[row].Cells[IS_ACTIVE_COL_INDEX].Value = dto.DefinitionIsActive ? StringResources.Yes : StringResources.No;

            BuildResponseColumns(worksheet, row, dto);            
        }

        private void BuildResponseColumns(Worksheet worksheet, int row, TargetAlertExcelReportDTO dto)
        {            
            List<TargetAlertResponseReportDetailDTO> responses = new List<TargetAlertResponseReportDetailDTO>(dto.Responses);

            responses.Sort((r1, r2) => r1.ResponseDateTime.CompareTo(r1.ResponseDateTime));

            int responseDateTimeIndex = BIGGEST_INDEX + 1;
            int responseNameIndex = BIGGEST_INDEX + 2;
            int reasonForGapIndex = BIGGEST_INDEX + 3;           
            int responseTextIndex = BIGGEST_INDEX + 4;

            int columnSetCount = 1;

            foreach (TargetAlertResponseReportDetailDTO response in responses)
            {
                string reducedCommentText = ReduceCommentText(response.CommentText);

                worksheet.Rows[row].Cells[responseDateTimeIndex].Value = response.ResponseDateTime;
                worksheet.Rows[row].Cells[responseNameIndex].Value = response.ResponseBy != null ? response.ResponseBy.FullName : "";
                worksheet.Rows[row].Cells[reasonForGapIndex].Value = response.TargetGapReason != null ? response.TargetGapReason.GetName() : "";
                worksheet.Rows[row].Cells[responseTextIndex].Value = reducedCommentText;
                
                if(columnSetCount > globalDynamicColumnMarker)
                {
                    MergeWithRowBefore(worksheet, 1, responseDateTimeIndex, string.Format(RendererStringResources.ExcelHeading_ResponseDateTime, columnSetCount));
                    MergeWithRowBefore(worksheet, 1, responseNameIndex, string.Format(RendererStringResources.ExcelHeading_Responder, columnSetCount));
                    MergeWithRowBefore(worksheet, 1, reasonForGapIndex, string.Format(RendererStringResources.ExcelHeading_GapReason, columnSetCount));
                    MergeWithRowBefore(worksheet, 1, responseTextIndex, string.Format(RendererStringResources.ExcelHeading_ResponseText, columnSetCount));

                    worksheet.Columns[responseDateTimeIndex].Width = 21 * AverageCharacterWidth;
                    worksheet.Columns[responseNameIndex].Width = 20 * AverageCharacterWidth;
                    worksheet.Columns[reasonForGapIndex].Width = 20 * AverageCharacterWidth;
                    worksheet.Columns[responseTextIndex].Width = 30 * AverageCharacterWidth;            

                    globalDynamicColumnMarker++;
                }

                responseDateTimeIndex += 4;
                responseNameIndex += 4;
                reasonForGapIndex += 4;
                responseTextIndex += 4;

                columnSetCount++;                
            }            
        }

        private static string ReduceCommentText(string commentText)
        {
            int index = commentText.IndexOf(StringResources.TargetAlertResponseTemplateLabel);
            
            if (index != -1)
            {
                return commentText.Substring(0, index);
            }

            return commentText;
        }

        private static void CreatedHeader(Worksheet worksheet)
        {
            const int row = 1;

            MergeWithRowBefore(worksheet, row, CREATED_COL_INDEX, RendererStringResources.ExcelHeading_CreatedDateTime);
            MergeWithRowBefore(worksheet, row, LAST_VIOLATED_COL_INDEX, RendererStringResources.ExcelHeading_LastViolated);
            MergeWithRowBefore(worksheet, row, FLOC_COL_INDEX, RendererStringResources.ExcelHeading_FLOC);
            MergeWithRowBefore(worksheet, row, STATUS_COL_INDEX, RendererStringResources.ExcelHeading_Status);
            MergeWithRowBefore(worksheet, row, DEF_NAME_COL_INDEX, RendererStringResources.ExcelHeading_DefinitionName);
            MergeWithRowBefore(worksheet, row, TAG_NAME_COL_INDEX, RendererStringResources.ExcelHeading_Tag);
            MergeWithRowBefore(worksheet, row, VALUE_COL_INDEX, RendererStringResources.ExcelHeading_ActualValue);
            MergeWithRowBefore(worksheet, row, VALUE_EVAL_COL_INDEX, RendererStringResources.ExcelHeading_ActualValueViolated);
            MergeWithRowBefore(worksheet, row, NTE_MAX_EVAL_COL_INDEX, RendererStringResources.ExcelHeading_NTESOLMaxViolated);
            MergeWithRowBefore(worksheet, row, NTE_MIN_EVAL_COL_INDEX, RendererStringResources.ExcelHeading_NTESOLMinViolated);
            MergeWithRowBefore(worksheet, row, MAX_EVAL_COL_INDEX, RendererStringResources.ExcelHeading_MaxViolated);
            MergeWithRowBefore(worksheet, row, MIN_EVAL_COL_INDEX, RendererStringResources.ExcelHeading_MinViolated);
            MergeWithRowBefore(worksheet, row, IS_ACTIVE_COL_INDEX, RendererStringResources.ExcelHeading_DefinitionActive);

            ApplyHeaderFormat(worksheet, row);
        }

    }

}
