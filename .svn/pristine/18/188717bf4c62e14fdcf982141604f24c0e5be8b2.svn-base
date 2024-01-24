using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Excel;
namespace Com.Suncor.Olt.Remote.Services.Excel
{
    class MarkedAsNotReadReportExcelDataRenderer : AbstractExcelDataRenderer, IExcelDataRenderer
    {private readonly bool includeLogs;
        private readonly bool includeSummaryogs;
        private readonly bool includeDirectiveLogs;
        private readonly bool includeShiftHandovers;
        private readonly bool includeDirectives;
        private readonly bool includeFlexiShiftDataonly;

        private readonly List<MarkedAsNotReadReportDataByUser> dataByUser;
        private readonly Dictionary<string, int> questionToColumnIndexMap = new Dictionary<string, int>();
        public MarkedAsNotReadReportExcelDataRenderer(
            MarkedAsNotReadReportDTO reportDto,bool includeDirectiveLogs,
          bool includeShiftHandovers,bool includeDirectives)
        {
           // this.includeLogs = includeLogs;
         //   this.includeSummaryogs = includeSummaryogs;
             this.includeDirectiveLogs = includeDirectiveLogs;
            this.includeShiftHandovers = includeShiftHandovers;
            this.includeDirectives = includeDirectives;
           // this.includeFlexiShiftDataonly = includeFlexiShiftDataonly;

           dataByUser = MarkedAsNotReadReportDataByUser.GroupByUser(reportDto);            
          //  PopulateQuestions();
        }

        public void Populate(Workbook workbook)
        {
          
            if (includeShiftHandovers)
            {
                PopulateShiftHandoverWorksheet(workbook);
            }
            if (includeDirectives)
            {
                PopulateDirectiveWorksheet(workbook);
            }
           
        }
        private void PopulateDirectiveWorksheet(Workbook workbook)
        {
            Worksheet worksheet = workbook.Worksheets.Add(RendererStringResources.ExcelTab_Directives);
            worksheet.DefaultColumnWidth = Convert.ToInt32(worksheet.DefaultColumnWidth * 2.5);

            CreatedDirectiveWorksheetHeader(worksheet);
            CreateDirectiveWorksheetDataRows(worksheet);
        }
        private void CreatedDirectiveWorksheetHeader(Worksheet worksheet)
        {
            const int row = 1;
            int column = 0;

            worksheet.Columns[column].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 1.5);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_User);

            //List<string> columns = new List<string> { RendererStringResources.ExcelHeading_MarkedAsReadTime,
            //                                             RendererStringResources.ActiveFrom,
            //                                             //RendererStringResources.ActiveTo,
            //                                             //RendererStringResources.ExcelHeading_FLOC,
            //                                             //RendererStringResources.ExcelHeading_Assignment,
            //                                             //RendererStringResources.ExcelHeading_EditedBy,
            //                                             //RendererStringResources.ExcelHeading_Comments };

           // MakeMergedRowBefore(worksheet, row, ref column, RendererStringResources.ExcelHeading_Directive, columns.ToArray());
            ApplyHeaderFormat(worksheet, row);
        }
        private void PopulateShiftHandoverWorksheet(Workbook workbook)
        {
            Worksheet worksheet = workbook.Worksheets.Add(RendererStringResources.ExcelTab_ShiftHandover);
            worksheet.DefaultColumnWidth = Convert.ToInt32(worksheet.DefaultColumnWidth * 2.5);

            CreatedShiftHandoverWorksheetHeader(worksheet);
            CreateShiftHandoverWorksheetDataRows(worksheet);
        }
        private void CreatedShiftHandoverWorksheetHeader(Worksheet worksheet)
        {
            const int row = 1;
            int column = 0;

            worksheet.Columns[column].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 1.5);
           // MergeWithRowBefore(worksheet, row, column++, RendererStringResources.Id);
            
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.UserName);
            //MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_Type);
          //  MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_CreatedDate);
          //  MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_Shift);
          //  MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_FLOC);
           // MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_CreatedBy);
          //  MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_Assignment);


            //List<string> keys = new List<string>(questionToColumnIndexMap.Keys);
            //foreach (string key in keys)
            //{
            //    questionToColumnIndexMap[key] = column;
            //    worksheet.Columns[column].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 0.5);
            //    worksheet.Columns[column + 1].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
            //    MakeMergedRowBefore(worksheet, row, ref column, key, RendererStringResources.ExcelHeading_Answer, StringResources.CommentsHeader);
            //}

            ApplyHeaderFormat(worksheet, row);
        }
        private void CreateShiftHandoverWorksheetDataRows(Worksheet worksheet)
        {
            int row = 2;
            foreach (MarkedAsNotReadReportDataByUser dataForOneUser in dataByUser)
            {
                List<MarkedAsNotReadReportShiftHandoverEntryDto> questionnaireDtos = dataForOneUser.ShiftHandoverQuestionnaires;
              //  questionnaireDtos.Sort((x, y) => DateTime.Compare(x.CreateDateTime, y.CreateDateTime));
                foreach (MarkedAsNotReadReportShiftHandoverEntryDto questionnaireDto in questionnaireDtos)
                {
                    CreateQuestionnaireDataRow(row++, worksheet, dataForOneUser, questionnaireDto);
                }
            }
        }
        private void CreateQuestionnaireDataRow(
           int row,
           Worksheet worksheet,
           MarkedAsNotReadReportDataByUser dataForOneUser,
           MarkedAsNotReadReportShiftHandoverEntryDto questionnaireReadEntry)
        {
            int column = 0;

            worksheet.Rows[row].CellFormat.VerticalAlignment = VerticalCellAlignment.Top;
            worksheet.Rows[row].Height = worksheet.DefaultRowHeight + 1;

            worksheet.Rows[row].Cells[column++].Value = dataForOneUser.UserFullNameWithUserName;
           // worksheet.Rows[row].Cells[column].CellFormat.FormatString = LocaleSpecificFormatPatternResources.ShortDateShortTimePattern;
           // worksheet.Rows[row].Cells[column++].Value = questionnaireReadEntry.ReadTime;

            //worksheet.Rows[row].Cells[column++].Value = questionnaireReadEntry.ShiftHandoverConfigurationName;
           // worksheet.Rows[row].Cells[column].CellFormat.FormatString = LocaleSpecificFormatPatternResources.ShortDateShortTimePattern;
           // worksheet.Rows[row].Cells[column++].Value = questionnaireReadEntry.CreateDateTime;
           // worksheet.Rows[row].Cells[column++].Value = questionnaireReadEntry.ShiftDisplayName;
           // worksheet.Rows[row].Cells[column++].Value = questionnaireReadEntry.FunctionalLocations;
          //  worksheet.Rows[row].Cells[column++].Value = questionnaireReadEntry.CreateUser;
          //  worksheet.Rows[row].Cells[column++].Value = questionnaireReadEntry.AssignmentDisplayName;

            //foreach (ShiftHandoverAnswerDTO answer in questionnaireReadEntry.Answers)
            //{
            //    int columnIndex = questionToColumnIndexMap[answer.QuestionText];
            //    worksheet.Rows[row].Cells[columnIndex].CellFormat.WrapText = ExcelDefaultableBoolean.True;
            //    worksheet.Rows[row].Cells[columnIndex].Value = answer.Answer ? StringResources.Yes : StringResources.No;
            //    worksheet.Rows[row].Cells[columnIndex + 1].Value = answer.Comments;
            //}
        }
        private void CreateDirectiveWorksheetDataRows(Worksheet worksheet)
        {
            int row = 2;
            foreach (MarkedAsNotReadReportDataByUser dataForOneUser in dataByUser)
            {
                {
                    List<MarkedAsNotReadReportDirectiveEntryDto> directives = dataForOneUser.Directives;
                    directives.Sort((x, y) => x.ActiveFromDateTime.CompareTo(y.ActiveFromDateTime));
                    foreach (MarkedAsNotReadReportDirectiveEntryDto directive in directives)
                    {
                        CreateDirectiveDataRow(row++, worksheet, dataForOneUser, directive);
                    }
                }
            }
        }
        private void CreateDirectiveDataRow(int row, Worksheet worksheet, MarkedAsNotReadReportDataByUser data, MarkedAsNotReadReportDirectiveEntryDto directive)
        {
            int column = 0;

            worksheet.Rows[row].CellFormat.VerticalAlignment = VerticalCellAlignment.Top;
            worksheet.Rows[row].Height = worksheet.DefaultRowHeight + 1;

            worksheet.Rows[row].Cells[column++].Value = data.UserFullNameWithUserName;

            //worksheet.Rows[row].Cells[column].CellFormat.FormatString = LocaleSpecificFormatPatternResources.ShortDateShortTimePattern;
            //worksheet.Rows[row].Cells[column++].Value = directive.ReadTime;

            //worksheet.Rows[row].Cells[column].CellFormat.FormatString = LocaleSpecificFormatPatternResources.ShortDateShortTimePattern;
            //worksheet.Rows[row].Cells[column++].Value = directive.ActiveFromDateTime;

            //worksheet.Rows[row].Cells[column].CellFormat.FormatString = LocaleSpecificFormatPatternResources.ShortDateShortTimePattern;
            //worksheet.Rows[row].Cells[column++].Value = directive.ActiveToDateTime;

            //worksheet.Rows[row].Cells[column++].Value = directive.FunctionalLocations;

            //worksheet.Rows[row].Cells[column++].Value = directive.WorkAssignments;

            //worksheet.Rows[row].Cells[column++].Value = directive.LastModifiedByFullNameWithUserName;

            //worksheet.Rows[row].Cells[column].CellFormat.WrapText = ExcelDefaultableBoolean.True;
            //worksheet.Rows[row].Cells[column].Value = directive.Content;
        }

    }


    public class MarkedAsNotReadReportShiftHandoverEntryDto
    {

        private readonly MarkedAsNotReadReportShiftHandoverQuestionnaireDTO dto;
        public string ShiftHandoverConfigurationName
        {
            get { return dto.ShiftHandoverConfigurationName; }
        }

        public DateTime CreateDateTime
        {
            get { return dto.CreateDateTime; }
        }

        public string ShiftDisplayName
        {
            get { return dto.ShiftDisplayName; }
        }

        public string FunctionalLocations
        {
            get { return dto.FunctionalLocations; }
        }

        public string CreateUser
        {
            get { return dto.CreateUser; }
        }

        public string AssignmentDisplayName
        {
            get { return dto.AssignmentDisplayName; }
        }
        public MarkedAsNotReadReportShiftHandoverEntryDto(MarkedAsNotReadReportShiftHandoverQuestionnaireDTO dto)
        {
           // ReadTime = readTime;
            this.dto = dto;
        }
    }
    public class MarkedAsNotReadReportDirectiveEntryDto
    {
        public DateTime ReadTime { get; set; }
        private readonly MarkedAsNotReadReportDirectiveDTO directiveDto;

        public MarkedAsNotReadReportDirectiveEntryDto(MarkedAsNotReadReportDirectiveDTO directiveDto)
        {
           // ReadTime = readTime;
            this.directiveDto = directiveDto;
        }

        public DateTime ActiveFromDateTime
        {
            get { return directiveDto.ActiveFromDateTime; }
        }

        public DateTime ActiveToDateTime
        {
            get { return directiveDto.ActiveToDateTime; }
        }

        public string FunctionalLocations
        {
            get { return directiveDto.FunctionalLocations; }
        }

        public string WorkAssignments
        {
            get { return directiveDto.WorkAssignments.IsNullOrEmptyOrWhitespace() ? string.Empty : directiveDto.WorkAssignments; }
        }

        public string LastModifiedByFullNameWithUserName
        {
            get { return directiveDto.LastModifiedByFullNameWithUserName; }
        }

        public string Content
        {
            get { return directiveDto.Content; }
        }
    }
}
