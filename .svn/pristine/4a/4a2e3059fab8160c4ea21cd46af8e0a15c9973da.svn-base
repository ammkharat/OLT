using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Excel;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    public class CokerCardReportExcelDataRenderer : AbstractExcelDataRenderer, IExcelDataRenderer
    {

        private readonly List<CokerCardCycleStepEntryDTO> dtos;

        public CokerCardReportExcelDataRenderer(List<CokerCardCycleStepEntryDTO> dtos)
        {
            this.dtos = dtos;
        }

        public void Populate(Workbook workbook)
        {
            Worksheet worksheet = workbook.Worksheets.Add(RendererStringResources.ExcelTab_CokerCardReport);
            CreateHeader(worksheet);
            CreateDataRows(worksheet);
        }

        private void CreateDataRows(Worksheet worksheet)
        {
            int row = 2;
            foreach (CokerCardCycleStepEntryDTO dto in dtos)
            {
                CreateDataRow(row++, worksheet, dto);
            }
        }

        private static void CreateDataRow(
            int row,
            Worksheet worksheet,
            CokerCardCycleStepEntryDTO dto)
        {
            int column = 0;            
            worksheet.Rows[row].Cells[column++].Value = dto.Drum;
            worksheet.Rows[row].Cells[column++].Value = dto.Cycle;
            
            worksheet.Rows[row].Cells[column++].Value = dto.StartTimeAsString;          
            worksheet.Rows[row].Cells[column++].Value = dto.EndTimeAsString;

            worksheet.Rows[row].Cells[column++].Value = dto.ShiftDescription;
            worksheet.Rows[row].Cells[column].Value = dto.Comment;         
        }

        private static void CreateHeader(Worksheet worksheet)
        {
            const int row = 1;
            int column = 0;

            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_Drum);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_Cycle);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_Start);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_End);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_Shift);
            MergeWithRowBefore(worksheet, row, column, RendererStringResources.ExcelHeading_Comments);

            ApplyHeaderFormat(worksheet, row);
        }

    }

}
