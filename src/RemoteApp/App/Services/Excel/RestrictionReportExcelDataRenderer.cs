using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Excel;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    public class RestrictionReportExcelDataRenderer : AbstractExcelDataRenderer, IExcelDataRenderer
    {
        private readonly Dictionary<long, List<DeviationAlertReportDTO>> groupedDtos;
        private readonly string reasonCodeTextFormat = RendererStringResources.AssociatedReasonCode + " #{0}";

        public RestrictionReportExcelDataRenderer(List<DeviationAlertReportDTO> dtos)
        {
            groupedDtos = dtos.GroupUsing(item => item.Id);
        }

        public void Populate(Workbook workbook)
        {
            Worksheet worksheet = workbook.Worksheets.Add(RendererStringResources.ExcelTab_RestrictionReport);
            CreatedHeader(worksheet);
            CreateDataRows(worksheet);
        }

        private void CreateDataRows(Worksheet worksheet)
        {
            int row = 2;
            foreach (List<DeviationAlertReportDTO> group in groupedDtos.Values)
            {
                CreateDataRow(row++, worksheet, group);
            }
        }

        private static void CreateDataRow(int row, Worksheet worksheet, List<DeviationAlertReportDTO> responsesByDeviationId)
        {
            DeviationAlertReportDTO dto = responsesByDeviationId[0];

            int column = 0;
            worksheet.Rows[row].Cells[column++].Value = dto.Id;
            worksheet.Rows[row].Cells[column++].Value = dto.Name;
            worksheet.Rows[row].Cells[column++].Value = dto.FlocDivision;
            worksheet.Rows[row].Cells[column++].Value = dto.FlocSection;
            worksheet.Rows[row].Cells[column++].Value = dto.FlocUnit;
            worksheet.Rows[row].Cells[column++].Value = dto.FlocEquipment1;
            worksheet.Rows[row].Cells[column++].Value = dto.FlocEquipment2;
            worksheet.Rows[row].Cells[column++].Value = dto.MeasurementTag;
            worksheet.Rows[row].Cells[column++].Value = dto.MeasurementValue;
            worksheet.Rows[row].Cells[column++].Value = dto.TargetTag;
            worksheet.Rows[row].Cells[column++].Value = dto.TargetValue;
            worksheet.Rows[row].Cells[column++].Value = dto.DeviationValue;

            worksheet.Rows[row].Cells[column].CellFormat.Alignment = HorizontalCellAlignment.Center;
            worksheet.Rows[row].Cells[column++].Value = dto.IsHiddenDeviation.BooleanToYesNoString();

            worksheet.Rows[row].Cells[column].CellFormat.FormatString = LocaleSpecificFormatPatternResources.ShortDateShortTimePattern;
            worksheet.Rows[row].Cells[column++].Value = dto.StartDateTime;
            worksheet.Rows[row].Cells[column].CellFormat.FormatString = LocaleSpecificFormatPatternResources.ShortDateShortTimePattern;
            worksheet.Rows[row].Cells[column++].Value = dto.EndDateTime;

            foreach (DeviationAlertReportDTO reason in responsesByDeviationId)
            {
                worksheet.Rows[row].Cells[column++].Value = reason.ReasonCode;
                worksheet.Rows[row].Cells[column].CellFormat.WrapText = ExcelDefaultableBoolean.True;
                
                worksheet.Rows[row].Cells[column++].Value = reason.AssignedAmount;
                worksheet.Rows[row].Cells[column++].Value = reason.PlantState;
                worksheet.Rows[row].Cells[column].CellFormat.WrapText = ExcelDefaultableBoolean.True;

                worksheet.Rows[row].Cells[column++].Value = reason.ReasonCodeFlocDivision;
                worksheet.Rows[row].Cells[column++].Value = reason.ReasonCodeFlocSection;
                worksheet.Rows[row].Cells[column++].Value = reason.ReasonCodeFlocUnit;
                worksheet.Rows[row].Cells[column++].Value = reason.ReasonCodeFlocEquipment1;
                worksheet.Rows[row].Cells[column++].Value = reason.ReasonCodeFlocEquipment2;
                worksheet.Rows[row].Cells[column++].Value = reason.ReasonCodeFlocDescription;
                worksheet.Rows[row].Cells[column].CellFormat.WrapText = ExcelDefaultableBoolean.True;
                worksheet.Rows[row].Cells[column++].Value = reason.ReasonCodeAssignmentComments;
                worksheet.Rows[row].Cells[column].CellFormat.WrapText = ExcelDefaultableBoolean.True;
            }
        }

        private void CreatedHeader(Worksheet worksheet)
        {
            int maxNumberOfReasonCodes = 0;
            groupedDtos.Values.ForEach(group =>
            {
                maxNumberOfReasonCodes = Math.Max(maxNumberOfReasonCodes, group.Count);
            });

            const int row = 1;
            int column = 0;

            worksheet.Columns[column].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 1.25); 
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_DeviationId);

            worksheet.Columns[column].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2.25);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_DeviationName);

            MakeMergedRowBefore(worksheet, row, ref column, RendererStringResources.ExcelHeading_DeviationFunctionalLocation,
                RendererStringResources.ExcelHeading_Division,
                RendererStringResources.ExcelHeading_Section,
                RendererStringResources.ExcelHeading_Unit,
                RendererStringResources.ExcelHeading_Equipment1,
                RendererStringResources.ExcelHeading_Equipment2);

            worksheet.Columns[column-2].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 1.5);
            worksheet.Columns[column-1].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 1.5);

            worksheet.Columns[column].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 1.25); 
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_MeasuredTag);

            worksheet.Columns[column].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 1.25); 
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_MeasuredValue);

            worksheet.Columns[column].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2.25);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_TargetTag);
            
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_TargetValue);

            worksheet.Columns[column].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 1.25); 
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_DeviationAmount);

            worksheet.Columns[column].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 1.25);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_HiddenDeviation);

            worksheet.Columns[column].Width = Convert.ToInt32(worksheet.DefaultColumnWidth*2.0);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_Start);

            worksheet.Columns[column].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2.0);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_End);

            for (int i = 0; i < maxNumberOfReasonCodes; i++)
            {
                MakeMergedRowBefore(worksheet, row, ref column, string.Format(reasonCodeTextFormat, i + 1),
                    RendererStringResources.ExcelHeading_ReasonCode,
                    RendererStringResources.ExcelHeading_AssignedAmount,
                    RendererStringResources.ExcelHeading_PlantState,
                    RendererStringResources.ExcelHeading_Division,
                    RendererStringResources.ExcelHeading_Section,
                    RendererStringResources.ExcelHeading_Unit,
                    RendererStringResources.ExcelHeading_Equipment1,
                    RendererStringResources.ExcelHeading_Equipment2,
                    RendererStringResources.ExcelHeading_Description,
                    RendererStringResources.ExcelHeading_Comments);
                
                worksheet.Columns[column-10].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2.0);
                worksheet.Columns[column-8].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2.5);
                worksheet.Columns[column-4].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 1.5);
                worksheet.Columns[column-3].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 1.5);
                worksheet.Columns[column-2].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 1.5);
                worksheet.Columns[column-1].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
            }
            
            ApplyHeaderFormat(worksheet, row);
        }

    }

}