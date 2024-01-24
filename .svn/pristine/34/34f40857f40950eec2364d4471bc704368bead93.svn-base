using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Excel;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    public class MarkedAsReadReportExcelDataRenderer : AbstractExcelDataRenderer, IExcelDataRenderer
    {
        private readonly bool includeLogs;
        private readonly bool includeSummaryogs;
        private readonly bool includeDirectiveLogs;
        private readonly bool includeShiftHandovers;
        private readonly bool includeDirectives;
        private readonly bool includeFlexiShiftDataonly;

        private readonly List<MarkedAsReadReportDataByUser> dataByUser;
        private readonly Dictionary<string, int> questionToColumnIndexMap = new Dictionary<string, int>();

        public MarkedAsReadReportExcelDataRenderer(
            MarkedAsReadReportDTO reportDto,
            bool includeLogs, bool includeSummaryogs, bool includeDirectiveLogs, bool includeShiftHandovers, bool includeDirectives, bool includeFlexiShiftDataonly)
        {
            this.includeLogs = includeLogs;
            this.includeSummaryogs = includeSummaryogs;
            this.includeDirectiveLogs = includeDirectiveLogs;
            this.includeShiftHandovers = includeShiftHandovers;
            this.includeDirectives = includeDirectives;
            this.includeFlexiShiftDataonly = includeFlexiShiftDataonly;

            dataByUser = MarkedAsReadReportDataByUser.GroupByUser(reportDto);            
            PopulateQuestions();
        }

        private void PopulateQuestions()
        {
            HashSet<Question> set = new HashSet<Question>();

            foreach (MarkedAsReadReportDataByUser dataForOneUser in dataByUser)
            {
                foreach (MarkedAsReadReportShiftHandoverEntryDto entry in dataForOneUser.ShiftHandoverQuestionnaires)
                {
                    foreach (ShiftHandoverAnswerDTO answer in entry.Answers)
                    {
                        set.Add(new Question(entry.ShiftHandoverConfigurationName, answer.QuestionText, answer.QuestionDisplayOrder));
                    }
                }
            }

            List<Question> questions = new List<Question>(set);
            questions.Sort(Question.Sort);

            foreach (Question question in questions)
            {
                if (!questionToColumnIndexMap.ContainsKey(question.QuestionText))
                {
                    questionToColumnIndexMap.Add(question.QuestionText, 0);
                }                
            }
        }

        public void Populate(Workbook workbook)
        {
            if (includeLogs || includeSummaryogs || includeDirectiveLogs)
            {
                PopulateLogWorksheet(workbook);
            }
            if (includeShiftHandovers)
            {
                PopulateShiftHandoverWorksheet(workbook);
            }
            if (includeDirectives)
            {
                PopulateDirectiveWorksheet(workbook);
            }
            if (includeFlexiShiftDataonly)
            {
                PopulateShiftHandoverWorksheet(workbook);
            }
        }

        private void PopulateLogWorksheet(Workbook workbook)
        {
            Worksheet worksheet = workbook.Worksheets.Add(RendererStringResources.ExcelTab_Logs);
            worksheet.DefaultColumnWidth = Convert.ToInt32(worksheet.DefaultColumnWidth * 2.5);

            CreatedLogWorksheetHeader(worksheet);
            CreateLogWorksheetDataRows(worksheet);
        }

        private void PopulateShiftHandoverWorksheet(Workbook workbook)
        {
            Worksheet worksheet = workbook.Worksheets.Add(RendererStringResources.ExcelTab_ShiftHandover);
            worksheet.DefaultColumnWidth = Convert.ToInt32(worksheet.DefaultColumnWidth * 2.5);

            CreatedShiftHandoverWorksheetHeader(worksheet);
            CreateShiftHandoverWorksheetDataRows(worksheet);
        }

        private void PopulateDirectiveWorksheet(Workbook workbook)
        {
            Worksheet worksheet = workbook.Worksheets.Add(RendererStringResources.ExcelTab_Directives);
            worksheet.DefaultColumnWidth = Convert.ToInt32(worksheet.DefaultColumnWidth * 2.5);

            CreatedDirectiveWorksheetHeader(worksheet);
            CreateDirectiveWorksheetDataRows(worksheet);
        }

        private void CreateLogWorksheetDataRows(Worksheet worksheet)
        {
            int row = 2;
            foreach (MarkedAsReadReportDataByUser dataForOneUser in dataByUser)
            {
                {
                    List<MarkedAsReadReportLogEntryDto> logs = dataForOneUser.SummaryLogs;
                    logs.Sort((x, y) => x.LoggedDateTime.CompareTo(y.LoggedDateTime));
                    foreach (MarkedAsReadReportLogEntryDto log in logs)
                    {
                        CreateLogDataRow(row++, worksheet, dataForOneUser, log);
                    }
                }
                {
                    List<MarkedAsReadReportLogEntryDto> logs = dataForOneUser.DirectiveLogs;
                    logs.Sort((x, y) => x.LoggedDateTime.CompareTo(y.LoggedDateTime));
                    foreach (MarkedAsReadReportLogEntryDto log in logs)
                    {
                        CreateLogDataRow(row++, worksheet, dataForOneUser, log);
                    }
                }
                {
                    List<MarkedAsReadReportLogEntryDto> logs = dataForOneUser.Logs;
                    logs.Sort((x, y) => x.LoggedDateTime.CompareTo(y.LoggedDateTime));
                    foreach (MarkedAsReadReportLogEntryDto log in logs)
                    {
                        CreateLogDataRow(row++, worksheet, dataForOneUser, log);
                    }
                }
            }
        }

        private void CreateLogDataRow(int row, Worksheet worksheet, MarkedAsReadReportDataByUser data, MarkedAsReadReportLogEntryDto log)
        {
            int column = 0;

            worksheet.Rows[row].CellFormat.VerticalAlignment = VerticalCellAlignment.Top;
            worksheet.Rows[row].Height = worksheet.DefaultRowHeight + 1;

            worksheet.Rows[row].Cells[column++].Value = data.UserFullNameWithUserName;
            worksheet.Rows[row].Cells[column].CellFormat.FormatString = LocaleSpecificFormatPatternResources.ShortDateShortTimePattern;
            worksheet.Rows[row].Cells[column++].Value = log.ReadTime;

            worksheet.Rows[row].Cells[column++].Value = log.LogTypeDisplay;
            worksheet.Rows[row].Cells[column].CellFormat.FormatString = LocaleSpecificFormatPatternResources.ShortDateShortTimePattern;
            worksheet.Rows[row].Cells[column++].Value = log.LoggedDateTime;          
            worksheet.Rows[row].Cells[column++].Value = log.Shift;          
            worksheet.Rows[row].Cells[column++].Value = log.FunctionalLocation;          
            worksheet.Rows[row].Cells[column++].Value = log.LastModifiedByFullNameWithUserName;

            worksheet.Rows[row].Cells[column].CellFormat.WrapText = ExcelDefaultableBoolean.True;            
            worksheet.Rows[row].Cells[column].Value = log.Comments;           
        }

        private void CreatedLogWorksheetHeader(Worksheet worksheet)
        {
            const int row = 1;
            int column = 0;
            
            worksheet.Columns[column].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 1.5);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_User);


            List<string> logColumns = new List<string> { RendererStringResources.ExcelHeading_MarkedAsReadTime,
                                                         RendererStringResources.ExcelHeading_Type, 
                                                         RendererStringResources.ExcelHeading_LogDate, 
                                                         RendererStringResources.ExcelHeading_Shift, 
                                                         RendererStringResources.ExcelHeading_FLOC, 
                                                         RendererStringResources.ExcelHeading_EditedBy,
                                                         RendererStringResources.ExcelHeading_Comments };

            // width for Type column
            worksheet.Columns[column + 1].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 0.5);
            // width for Summary column
            worksheet.Columns[column + logColumns.Count - 1].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
            
            MakeMergedRowBefore(worksheet, row, ref column, RendererStringResources.ExcelHeading_Log, logColumns.ToArray());
            ApplyHeaderFormat(worksheet, row);
        }

        private void CreateDirectiveWorksheetDataRows(Worksheet worksheet)
        {
            int row = 2;
            foreach (MarkedAsReadReportDataByUser dataForOneUser in dataByUser)
            {
                {
                    List<MarkedAsReadReportDirectiveEntryDto> directives = dataForOneUser.Directives;
                    directives.Sort((x, y) => x.ActiveFromDateTime.CompareTo(y.ActiveFromDateTime));
                    foreach (MarkedAsReadReportDirectiveEntryDto directive in directives)
                    {
                        CreateDirectiveDataRow(row++, worksheet, dataForOneUser, directive);
                    }
                }
            }
        }

        private void CreateDirectiveDataRow(int row, Worksheet worksheet, MarkedAsReadReportDataByUser data, MarkedAsReadReportDirectiveEntryDto directive)
        {
            int column = 0;

            worksheet.Rows[row].CellFormat.VerticalAlignment = VerticalCellAlignment.Top;
            worksheet.Rows[row].Height = worksheet.DefaultRowHeight + 1;

            worksheet.Rows[row].Cells[column++].Value = data.UserFullNameWithUserName;

            worksheet.Rows[row].Cells[column].CellFormat.FormatString = LocaleSpecificFormatPatternResources.ShortDateShortTimePattern;
            worksheet.Rows[row].Cells[column++].Value = directive.ReadTime;

            worksheet.Rows[row].Cells[column].CellFormat.FormatString = LocaleSpecificFormatPatternResources.ShortDateShortTimePattern;
            worksheet.Rows[row].Cells[column++].Value = directive.ActiveFromDateTime;

            worksheet.Rows[row].Cells[column].CellFormat.FormatString = LocaleSpecificFormatPatternResources.ShortDateShortTimePattern;
            worksheet.Rows[row].Cells[column++].Value = directive.ActiveToDateTime;

            worksheet.Rows[row].Cells[column++].Value = directive.FunctionalLocations;

            worksheet.Rows[row].Cells[column++].Value = directive.WorkAssignments;

            worksheet.Rows[row].Cells[column++].Value = directive.LastModifiedByFullNameWithUserName;

            worksheet.Rows[row].Cells[column].CellFormat.WrapText = ExcelDefaultableBoolean.True;
            worksheet.Rows[row].Cells[column].Value = directive.Content;
        }

        private void CreatedDirectiveWorksheetHeader(Worksheet worksheet)
        {
            const int row = 1;
            int column = 0;

            worksheet.Columns[column].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 1.5);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_User);

            List<string> columns = new List<string> { RendererStringResources.ExcelHeading_MarkedAsReadTime,
                                                         RendererStringResources.ActiveFrom,
                                                         RendererStringResources.ActiveTo,
                                                         RendererStringResources.ExcelHeading_FLOC,
                                                         RendererStringResources.ExcelHeading_Assignment,
                                                         RendererStringResources.ExcelHeading_EditedBy,
                                                         RendererStringResources.ExcelHeading_Comments };

            MakeMergedRowBefore(worksheet, row, ref column, RendererStringResources.ExcelHeading_Directive, columns.ToArray());
            ApplyHeaderFormat(worksheet, row);
        }

        private void CreateShiftHandoverWorksheetDataRows(Worksheet worksheet)
        {
            int row = 2;
            foreach (MarkedAsReadReportDataByUser dataForOneUser in dataByUser)
            {
                List<MarkedAsReadReportShiftHandoverEntryDto> questionnaireDtos = dataForOneUser.ShiftHandoverQuestionnaires;
                questionnaireDtos.Sort((x, y) => DateTime.Compare(x.CreateDateTime, y.CreateDateTime));
                foreach (MarkedAsReadReportShiftHandoverEntryDto questionnaireDto in questionnaireDtos)
                {
                    CreateQuestionnaireDataRow(row++, worksheet, dataForOneUser, questionnaireDto);
                }
            }
        }

        private void CreateQuestionnaireDataRow(
            int row,
            Worksheet worksheet,
            MarkedAsReadReportDataByUser dataForOneUser,
            MarkedAsReadReportShiftHandoverEntryDto questionnaireReadEntry)
        {
            int column = 0;

            worksheet.Rows[row].CellFormat.VerticalAlignment = VerticalCellAlignment.Top;
            worksheet.Rows[row].Height = worksheet.DefaultRowHeight + 1;

            worksheet.Rows[row].Cells[column++].Value = dataForOneUser.UserFullNameWithUserName;
            worksheet.Rows[row].Cells[column].CellFormat.FormatString = LocaleSpecificFormatPatternResources.ShortDateShortTimePattern;
            worksheet.Rows[row].Cells[column++].Value = questionnaireReadEntry.ReadTime;

            worksheet.Rows[row].Cells[column++].Value = questionnaireReadEntry.ShiftHandoverConfigurationName;
            worksheet.Rows[row].Cells[column].CellFormat.FormatString = LocaleSpecificFormatPatternResources.ShortDateShortTimePattern;
            worksheet.Rows[row].Cells[column++].Value = questionnaireReadEntry.CreateDateTime;
            worksheet.Rows[row].Cells[column++].Value = questionnaireReadEntry.ShiftDisplayName;
            worksheet.Rows[row].Cells[column++].Value = questionnaireReadEntry.FunctionalLocations;
            worksheet.Rows[row].Cells[column++].Value = questionnaireReadEntry.CreateUser;
            worksheet.Rows[row].Cells[column++].Value = questionnaireReadEntry.AssignmentDisplayName;

            foreach (ShiftHandoverAnswerDTO answer in questionnaireReadEntry.Answers)
            {
                int columnIndex = questionToColumnIndexMap[answer.QuestionText];
                worksheet.Rows[row].Cells[columnIndex].CellFormat.WrapText = ExcelDefaultableBoolean.True;
                worksheet.Rows[row].Cells[columnIndex].Value = answer.Answer ? StringResources.Yes : StringResources.No;
                worksheet.Rows[row].Cells[columnIndex+1].Value = answer.Comments;
            }
        }

        private void CreatedShiftHandoverWorksheetHeader(Worksheet worksheet)
        {
            const int row = 1;
            int column = 0;

            worksheet.Columns[column].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 1.5);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_User);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_MarkedAsReadTime);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_Type);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_CreatedDate);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_Shift);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_FLOC);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_CreatedBy);
            MergeWithRowBefore(worksheet, row, column++, RendererStringResources.ExcelHeading_Assignment);


            List<string> keys = new List<string>(questionToColumnIndexMap.Keys);
            foreach (string key in keys)
            {
                questionToColumnIndexMap[key] = column;
                worksheet.Columns[column].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 0.5);
                worksheet.Columns[column+1].Width = Convert.ToInt32(worksheet.DefaultColumnWidth * 2);
                MakeMergedRowBefore(worksheet, row, ref column, key, RendererStringResources.ExcelHeading_Answer, StringResources.CommentsHeader);
            }

            ApplyHeaderFormat(worksheet, row);
        }

        private class Question
        {
            private readonly string shiftHandoverType;
            private readonly string questionText;
            private readonly int displayOrder;

            public Question(string shiftHandoverType, string questionText, int displayOrder)
            {
                this.shiftHandoverType = shiftHandoverType;
                this.questionText = questionText;
                this.displayOrder = displayOrder;
            }

            public string QuestionText
            {
                get { return questionText; }
            }

            public bool Equals(Question other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Equals(other.shiftHandoverType, shiftHandoverType) && Equals(other.questionText, questionText);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != typeof (Question)) return false;
                return Equals((Question) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((shiftHandoverType != null ? shiftHandoverType.GetHashCode() : 0)*397) ^ (questionText != null ? questionText.GetHashCode() : 0);
                }
            }

            public static int Sort(Question x, Question y)
            {
                {
                    int compareResult = x.shiftHandoverType.CompareTo(y.shiftHandoverType);
                    if (compareResult != 0)
                    {
                        return compareResult;
                    }
                }
                {
                    int compareResult = x.displayOrder.CompareTo(y.displayOrder);
                    if (compareResult != 0)
                    {
                        return compareResult;
                    }
                }
                {
                    int compareResult = x.questionText.CompareTo(y.questionText);
                    if (compareResult != 0)
                    {
                        return compareResult;
                    }
                }
                return 0;
            }
        }
    }

    public class MarkedAsReadReportShiftHandoverEntryDto
    {
        public DateTime ReadTime { get; set; }

        public List<ShiftHandoverAnswerDTO> Answers
        {
            get { return dto.Answers; }
        }

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
            get { return  dto.CreateUser; }
        }

        public string AssignmentDisplayName
        {
            get { return dto.AssignmentDisplayName; }
        }

        private readonly MarkedAsReadReportShiftHandoverQuestionnaireDTO dto;

        public MarkedAsReadReportShiftHandoverEntryDto(MarkedAsReadReportShiftHandoverQuestionnaireDTO dto, DateTime readTime)
        {
            ReadTime = readTime;
            this.dto = dto;
        }
    }

    public class MarkedAsReadReportLogEntryDto
    {
        public DateTime ReadTime { get; set; }
        private readonly MarkedAsReadReportLogDTO logDto;

        public MarkedAsReadReportLogEntryDto(MarkedAsReadReportLogDTO logDto, DateTime readTime)
        {
            ReadTime = readTime;
            this.logDto = logDto;
        }

        public DateTime LoggedDateTime
        {
            get { return logDto.LoggedDateTime; }
        }

        public string LogTypeDisplay
        {
            get { return logDto.LogTypeDisplay; }
        }

        public string Shift
        {
            get { return logDto.Shift; }
        }

        public string FunctionalLocation
        {
            get { return logDto.FunctionalLocation; }
        }

        public string LastModifiedByFullNameWithUserName
        {
            get { return logDto.LastModifiedByFullNameWithUserName; }
        }

        public string Comments
        {
            get { return logDto.Comments; }
        }
    }

    public class MarkedAsReadReportDirectiveEntryDto
    {
        public DateTime ReadTime { get; set; }
        private readonly MarkedAsReadReportDirectiveDTO directiveDto;

        public MarkedAsReadReportDirectiveEntryDto(MarkedAsReadReportDirectiveDTO directiveDto, DateTime readTime)
        {
            ReadTime = readTime;
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