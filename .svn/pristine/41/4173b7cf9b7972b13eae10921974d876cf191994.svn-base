using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Excel;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services.Excel
{
    [TestFixture]
    public class MarkedAsReadReportExcelDataRendererTest
    {
        private const int DATA_START_ROW = 2;
        private const int QUESTION_START_COLUMN = 8;
    
        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        private static MarkedAsReadReportLogDTO CreateDto(LogType logType, int i, string comments, string readUser)
        {
            return CreateDto(
                logType == LogType.DailyDirective ? MarkedAsReadReportLogDTO.DAILY_DIRECTIVE_LOG_TYPE_TEXT : MarkedAsReadReportLogDTO.STANDARD_LOG_TYPE_TEXT,
                i, comments, readUser);            
        }

        private static MarkedAsReadReportLogDTO CreateDto(string logType, int i, string comments, string readUser)
        {
            return new MarkedAsReadReportLogDTO(
                logType,
                new DateTime(2000 + i, i, i),
                string.Format("0{0}/0{0}/200{0} - shift {0}", i),
                "floc" + 1,
                "create user " + i,
                comments,
                new List<ItemReadBy> { new ItemReadBy(readUser, Clock.Now) });
        }

        private static MarkedAsReadReportShiftHandoverQuestionnaireDTO CreateShiftHandoverQuestionnaireDto(
            DateTime createDateTime, List<ShiftHandoverAnswerDTO> answers, string readUser)
        {
            return CreateShiftHandoverQuestionnaireDto("config 1", createDateTime, answers, readUser);
        }

        private static MarkedAsReadReportShiftHandoverQuestionnaireDTO CreateShiftHandoverQuestionnaireDto(
            string configName, DateTime createDateTime, List<ShiftHandoverAnswerDTO> answers, string readUser)
        {
            MarkedAsReadReportShiftHandoverQuestionnaireDTO dto = new MarkedAsReadReportShiftHandoverQuestionnaireDTO(
                configName, createDateTime, "shift 1", "create user 1", "assignment 1", "floc 1", new List<ItemReadBy> { new ItemReadBy(readUser, Clock.Now) });
            dto.Answers.AddRange(answers);
            return dto;
        }

        [Ignore] [Test]
        public void ShouldRenderLogs()
        {
            AssertRenderLog(LogType.Standard, MarkedAsReadReportLogDTO.STANDARD_LOG_TYPE_TEXT, obj => obj.Logs);
        }

        [Ignore] [Test]
        public void ShouldRenderDirectiveLogs()
        {
            AssertRenderLog(LogType.DailyDirective, MarkedAsReadReportLogDTO.DAILY_DIRECTIVE_LOG_TYPE_TEXT, obj => obj.DirectiveLogs);
        }

        private static void AssertRenderLog(LogType logType, string logTypeText, Func<MarkedAsReadReportDTO, List<MarkedAsReadReportLogDTO>> logList)
        {
            const string readUser = "user name 1";
            MarkedAsReadReportDTO dto = new MarkedAsReadReportDTO();
            logList(dto).Add(CreateDto(logType, 1, "comment text", readUser));

            MarkedAsReadReportExcelDataRenderer renderer = new MarkedAsReadReportExcelDataRenderer(dto, true, true, true, true, true,true);

            Workbook workbook = new Workbook();
            renderer.Populate(workbook);

            Worksheet worksheet = workbook.Worksheets[RendererStringResources.ExcelTab_Logs];
            const int row = DATA_START_ROW;
            int column = 0;
            Assert.AreEqual(readUser, worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual(Clock.Now, worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual(logTypeText, worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual(new DateTime(2001, 1, 1), worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual("01/01/2001 - shift 1", worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual("floc1", worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual("create user 1", worksheet.Rows[row].Cells[column++].Value);            
            Assert.AreEqual("comment text", worksheet.Rows[row].Cells[column++].Value);
        }

        [Ignore] [Test]
        public void ShouldRenderDirectives()
        {
            MarkedAsReadReportDTO dto = new MarkedAsReadReportDTO();
            dto.Directives.Add(new MarkedAsReadReportDirectiveDTO(
                new DateTime(2001, 1, 1, 10, 3, 3),
                new DateTime(2001, 1, 1, 10, 6, 6),
                new List<string> { "floc1", "floc2" },
                new List<string> { "wa1", "wa2" }, 
                "last mod by user 1",
                "content!",
                new List<ItemReadBy> { new ItemReadBy("user name 1", Clock.Now) }));

            MarkedAsReadReportExcelDataRenderer renderer = new MarkedAsReadReportExcelDataRenderer(dto, true, true, true, true, true, true);

            Workbook workbook = new Workbook();
            renderer.Populate(workbook);

            Worksheet worksheet = workbook.Worksheets[RendererStringResources.ExcelTab_Directives];
            const int row = DATA_START_ROW;
            int column = 0;
            Assert.AreEqual("user name 1", worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual(Clock.Now, worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual(new DateTime(2001, 1, 1, 10, 3, 3), worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual(new DateTime(2001, 1, 1, 10, 6, 6), worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual("floc1, floc2", worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual("wa1, wa2", worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual("last mod by user 1", worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual("content!", worksheet.Rows[row].Cells[column].Value);
        }

        [Ignore] [Test]
        public void ShouldRenderSummaryLogs()
        {
            MarkedAsReadReportDTO dto = new MarkedAsReadReportDTO();
            dto.SummaryLogs.Add(new MarkedAsReadReportLogDTO(
                MarkedAsReadReportLogDTO.SUMMARY_LOG_TYPE_TEXT,
                new DateTime(2001, 1, 1),
                "11/11/2001 - shift 1",
                "floc1",
                "create user 1",
                "comment text 1a",
                new List<ItemReadBy> { new ItemReadBy("user name 1", Clock.Now) }));

            MarkedAsReadReportExcelDataRenderer renderer = new MarkedAsReadReportExcelDataRenderer(dto, true, true, true, true, true, true);

            Workbook workbook = new Workbook();
            renderer.Populate(workbook);

            Worksheet worksheet = workbook.Worksheets[RendererStringResources.ExcelTab_Logs];
            const int row = DATA_START_ROW;
            int column = 0;
            Assert.AreEqual("user name 1", worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual(Clock.Now, worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual(MarkedAsReadReportLogDTO.SUMMARY_LOG_TYPE_TEXT, worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual(new DateTime(2001, 1, 1), worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual("11/11/2001 - shift 1", worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual("floc1", worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual("create user 1", worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual("comment text 1a", worksheet.Rows[row].Cells[column++].Value);
        }
      
        [Ignore] [Test]
        public void ShouldRenderShiftHandoverQuestionnaires()
        {
            const string readUser = "user name 1";
            MarkedAsReadReportDTO dto = new MarkedAsReadReportDTO();
            dto.ShiftHandoverQuestionnaires.Add(CreateShiftHandoverQuestionnaireDto(new DateTime(2001, 1, 1), 
                new List<ShiftHandoverAnswerDTO>{
                    new ShiftHandoverAnswerDTO(0, true, "comment 1a", "question text 1a", 0),
                    new ShiftHandoverAnswerDTO(0, false, "comment 1b", "question text 1b", 0)
                    },
                readUser));

            MarkedAsReadReportExcelDataRenderer renderer = new MarkedAsReadReportExcelDataRenderer(dto, true, true, true, true, true, true);

            Workbook workbook = new Workbook();
            renderer.Populate(workbook);

            Worksheet worksheet = workbook.Worksheets[RendererStringResources.ExcelTab_ShiftHandover];
            const int row = DATA_START_ROW;
            int column = 0;
            Assert.AreEqual(readUser, worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual(Clock.Now, worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual("config 1", worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual(new DateTime(2001, 1, 1), worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual("shift 1", worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual("floc 1", worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual("create user 1", worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual("assignment 1", worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual(StringResources.Yes, worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual("comment 1a", worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual(StringResources.No, worksheet.Rows[row].Cells[column++].Value);
            Assert.AreEqual("comment 1b", worksheet.Rows[row].Cells[column++].Value);
        }


        [Ignore] [Test]
        public void ShouldRenderMultipleQuestions()
        {
            const string readUser = "user name 1";
            MarkedAsReadReportDTO dto = new MarkedAsReadReportDTO();
            dto.ShiftHandoverQuestionnaires.Add(CreateShiftHandoverQuestionnaireDto(new DateTime(2001, 1, 1),
                new List<ShiftHandoverAnswerDTO>{
                    new ShiftHandoverAnswerDTO(0, true, "comment a", "question text 1", 5),
                    new ShiftHandoverAnswerDTO(0, false, "comment b", "question text 2", 4)
                    },
                readUser));
            dto.ShiftHandoverQuestionnaires.Add(CreateShiftHandoverQuestionnaireDto(new DateTime(2001, 1, 2),
                new List<ShiftHandoverAnswerDTO>{
                    new ShiftHandoverAnswerDTO(0, true, "comment c", "question text 1", 5),
                    new ShiftHandoverAnswerDTO(0, false, "comment d", "question text 3", 3)
                    },
                readUser));
            dto.ShiftHandoverQuestionnaires.Add(CreateShiftHandoverQuestionnaireDto(new DateTime(2001, 1, 3),
                new List<ShiftHandoverAnswerDTO>{
                    new ShiftHandoverAnswerDTO(0, true, "comment e", "question text 5", 1),
                    new ShiftHandoverAnswerDTO(0, true, "comment f", "question text 4", 2),
                    new ShiftHandoverAnswerDTO(0, false, "comment g", "question text 1", 5)
                    },
                readUser));

            MarkedAsReadReportExcelDataRenderer renderer = new MarkedAsReadReportExcelDataRenderer(dto, true, true, true, true, true, true);

            Workbook workbook = new Workbook();
            renderer.Populate(workbook);

            Worksheet worksheet = workbook.Worksheets[RendererStringResources.ExcelTab_ShiftHandover];

            {
                const int row = DATA_START_ROW - 2;
                Assert.AreEqual("question text 5", worksheet.Rows[row].Cells[QUESTION_START_COLUMN + 0].Value);
                Assert.AreEqual("question text 4", worksheet.Rows[row].Cells[QUESTION_START_COLUMN + 2].Value);
                Assert.AreEqual("question text 3", worksheet.Rows[row].Cells[QUESTION_START_COLUMN + 4].Value);
                Assert.AreEqual("question text 2", worksheet.Rows[row].Cells[QUESTION_START_COLUMN + 6].Value);
                Assert.AreEqual("question text 1", worksheet.Rows[row].Cells[QUESTION_START_COLUMN + 8].Value);
            }
            var yes = StringResources.Yes;
            var no = StringResources.No;
            {
                const int row = DATA_START_ROW;
                int column = QUESTION_START_COLUMN;
                Assert.AreEqual(null, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(null, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(null, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(null, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(null, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(null, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(no, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual("comment b", worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(yes, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual("comment a", worksheet.Rows[row].Cells[column++].Value);
            }
            {
                const int row = DATA_START_ROW + 1;
                int column = QUESTION_START_COLUMN;
                Assert.AreEqual(null, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(null, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(null, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(null, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(no, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual("comment d", worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(null, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(null, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(yes, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual("comment c", worksheet.Rows[row].Cells[column++].Value);
            }
            {
                const int row = DATA_START_ROW + 2;
                int column = QUESTION_START_COLUMN;
                Assert.AreEqual(yes, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual("comment e", worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(yes, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual("comment f", worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(null, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(null, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(null, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(null, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual(no, worksheet.Rows[row].Cells[column++].Value);
                Assert.AreEqual("comment g", worksheet.Rows[row].Cells[column++].Value);
            }
        }

        [Ignore] [Test]
        public void ShouldRenderMultipleQuestions_DuplicateQuestionText()
        {
            const string readUser = "user name 1";
            MarkedAsReadReportDTO dto = new MarkedAsReadReportDTO();
            dto.ShiftHandoverQuestionnaires.Add(CreateShiftHandoverQuestionnaireDto("config 1", new DateTime(2001, 1, 1),
                new List<ShiftHandoverAnswerDTO>{
                    new ShiftHandoverAnswerDTO(0, true, "comment a", "question text 1", 5),
                    new ShiftHandoverAnswerDTO(0, false, "comment b", "question text 1", 4)
                    },
                readUser));

            dto.ShiftHandoverQuestionnaires.Add(CreateShiftHandoverQuestionnaireDto("config 2", new DateTime(2001, 1, 2),
                new List<ShiftHandoverAnswerDTO>{
                    new ShiftHandoverAnswerDTO(1, true, "comment c", "question text 1", 5),
                    new ShiftHandoverAnswerDTO(1, false, "comment d", "question text 3", 3)
                    },
                readUser));


            // This will throw an exception if bug #1119 isn't fixed
            MarkedAsReadReportExcelDataRenderer renderer = new MarkedAsReadReportExcelDataRenderer(dto, true, true, true, true, true, true);
            
        }

    }
}
