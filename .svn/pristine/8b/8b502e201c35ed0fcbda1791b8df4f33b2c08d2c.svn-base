using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    [Category("Database")]
    public class CustomFieldTrendReportDTODaoTest : AbstractDaoTest
    {
        private ILogDao logDao;
        private ISummaryLogDao summaryLogDao;
        private ICustomFieldTrendReportDTODao customFieldTrendReportDtoDao;

        protected override void TestInitialize()
        {
            customFieldTrendReportDtoDao = DaoRegistry.GetDao<ICustomFieldTrendReportDTODao>();
            logDao = DaoRegistry.GetDao<ILogDao>();
            summaryLogDao = DaoRegistry.GetDao<ISummaryLogDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldQueryCustomFieldTrendReportDtosForStandardLogs()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3();

            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            ShiftPattern shift = ShiftPatternFixture.CreateNightShift();
            DateTime now = shift.EndTime.Add(-4).ToDateTime(new Date(2010, 04, 20));
            UserShift userShift = new UserShift(shift, now);

            Log log = CreateLog(shift, new List<FunctionalLocation> { floc1, floc2 }, now, user, null);            
            log.RtfComments = "Comments";
            log.PlainTextComments = "Comments";
            log.WorkAssignment = WorkAssignmentFixture.CreateConsoleOperator();
            log.CustomFieldEntries.Clear();
            CustomField customFieldExistingInDatabase1 = CustomFieldFixture.CustomFieldExistingInDatabase1();
            CustomField customFieldExistingInDatabase3 = CustomFieldFixture.CustomFieldExistingInDatabase3();
            CustomField customFieldExistingInDatabase2 = CustomFieldFixture.CustomFieldExistingInDatabase2();

            log.CustomFieldEntries.Add(new CustomFieldEntry(null, customFieldExistingInDatabase1.IdValue, customFieldExistingInDatabase1.Name, "Field Entry 1", null,null,
                                                            customFieldExistingInDatabase1.DisplayOrder, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            log.CustomFieldEntries.Add(new CustomFieldEntry(null, customFieldExistingInDatabase3.IdValue, customFieldExistingInDatabase3.Name, null, new decimal(3.14),null,
                                                            customFieldExistingInDatabase3.DisplayOrder, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null));
            log.CustomFields.Clear();
            log.CustomFields.Add(customFieldExistingInDatabase1);
            log.CustomFields.Add(customFieldExistingInDatabase2);
            log.CustomFields.Add(customFieldExistingInDatabase3);
            log = logDao.Insert(log);

            List<CustomFieldTrendReportDTO> results = customFieldTrendReportDtoDao.QueryCustomFieldTrendReportDataForLogs(new RootFlocSet(floc1), userShift.StartDateTimeWithPadding,
                                                                                                                          userShift.EndDateTimeWithPadding,
                                                                                                                          new List<WorkAssignment> {log.WorkAssignment}, false,
                                                                                                                          LogType.Standard);

            List<CustomFieldTrendReportDTO> dtos = results.FindAll(x => x.Id == log.Id);
            Assert.AreEqual(1, dtos.Count);

            CustomFieldTrendReportDTO resultDto = dtos[0];

            Assert.AreEqual(log.LogDateTime, resultDto.LogDateTime);
            Assert.AreEqual("4/19/2010 - 12NT", resultDto.ShiftName);

            List<string> flocs = resultDto.FunctionalLocationNames.BuildListFromCommaSeparatedList();
            Assert.AreEqual(2, flocs.Count);
            Assert.IsTrue(flocs.Exists(obj => obj == floc1.FullHierarchy));
            Assert.IsTrue(flocs.Exists(obj => obj == floc2.FullHierarchy));

            Assert.AreEqual(2, resultDto.CustomFieldEntries.Count);
            Assert.IsTrue(resultDto.CustomFieldEntries.Exists(
                e => string.Equals(e.CustomFieldName, customFieldExistingInDatabase1.Name) && string.Equals(e.FieldEntryForDisplay, "Field Entry 1") && e.DisplayOrder == customFieldExistingInDatabase1.DisplayOrder));
            Assert.IsTrue(resultDto.CustomFieldEntries.Exists(
                e => string.Equals(e.CustomFieldName, customFieldExistingInDatabase3.Name) && string.Equals(e.FieldEntryForDisplay, "3.14") && e.DisplayOrder == customFieldExistingInDatabase3.DisplayOrder));

            Assert.IsTrue(resultDto.CustomFields.Exists(e => e.Name == customFieldExistingInDatabase1.Name));
            Assert.IsTrue(resultDto.CustomFields.Exists(e => e.Name == customFieldExistingInDatabase2.Name));
            Assert.IsTrue(resultDto.CustomFields.Exists(e => e.Name == customFieldExistingInDatabase3.Name));
        }

        [Ignore] [Test]
        public void ShouldQueryCustomFieldTrendReportDtosForStandardLogs_VaryDateRange()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3();

            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));
            UserShift userShift = new UserShift(shift, now);

            Log log = CreateLog(shift, new List<FunctionalLocation> { floc1, floc2 }, now, user, null);
            log.RtfComments = "Comments";
            log.PlainTextComments = "Comments";
            log.WorkAssignment = WorkAssignmentFixture.CreateConsoleOperator();
            log.CustomFieldEntries.Clear();
            log.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase1().IdValue, "Field Name 1", "Field Entry 1", null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            log.CustomFields.Clear();
            log.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase1());
            log = logDao.Insert(log);

            // in range
            {
                List<CustomFieldTrendReportDTO> results = customFieldTrendReportDtoDao.QueryCustomFieldTrendReportDataForLogs(new RootFlocSet(floc1), userShift.StartDateTimeWithPadding, userShift.EndDateTimeWithPadding, new List<WorkAssignment> { log.WorkAssignment }, false, LogType.Standard);
                List<CustomFieldTrendReportDTO> dtos = results.FindAll(x => x.Id == log.Id);
                Assert.AreEqual(1, dtos.Count);
            }

            // out of range
            {
                List<CustomFieldTrendReportDTO> results = customFieldTrendReportDtoDao.QueryCustomFieldTrendReportDataForLogs(new RootFlocSet(floc1), now.AddDays(-2), now.AddDays(-1), new List<WorkAssignment> { log.WorkAssignment }, false, LogType.Standard);
                List<CustomFieldTrendReportDTO> dtos = results.FindAll(x => x.Id == log.Id);
                Assert.AreEqual(0, dtos.Count);                
            }
        }

        [Ignore] [Test]
        public void ShouldQueryCustomFieldTrendReportDtosForStandardLogs_VaryFloc()
        {
            FunctionalLocation parent = FunctionalLocationFixture.GetReal_SR1_PLT3();
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3();

            FunctionalLocation unrelatedFloc = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();

            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));
            UserShift userShift = new UserShift(shift, now);

            Log log = CreateLog(shift, new List<FunctionalLocation> { floc1, floc2 }, now, user, null);
            log.RtfComments = "Comments";
            log.PlainTextComments = "Comments";
            log.WorkAssignment = WorkAssignmentFixture.CreateConsoleOperator();
            log.CustomFieldEntries.Clear();
            log.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase1().IdValue, "Field Name 1", "Field Entry 1", null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            log.CustomFields.Clear();
            log.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase1());
            log = logDao.Insert(log);

            // querying on parent floc
            {
                List<CustomFieldTrendReportDTO> results = customFieldTrendReportDtoDao.QueryCustomFieldTrendReportDataForLogs(new RootFlocSet(parent), userShift.StartDateTimeWithPadding, userShift.EndDateTimeWithPadding, new List<WorkAssignment> { log.WorkAssignment }, false, LogType.Standard);
                List<CustomFieldTrendReportDTO> dtos = results.FindAll(x => x.Id == log.Id);
                Assert.AreEqual(1, dtos.Count);
            }

            // querying on unrelated floc
            {
                List<CustomFieldTrendReportDTO> results = customFieldTrendReportDtoDao.QueryCustomFieldTrendReportDataForLogs(new RootFlocSet(unrelatedFloc), now.AddDays(-2), now.AddDays(-1), new List<WorkAssignment> { log.WorkAssignment }, false, LogType.Standard);
                List<CustomFieldTrendReportDTO> dtos = results.FindAll(x => x.Id == log.Id);
                Assert.AreEqual(0, dtos.Count);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryCustomFieldTrendReportDtosForDirectives()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3();

            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));
            UserShift userShift = new UserShift(shift, now);
            
            

            Log log = LogFixture.CreateLog(now, new List<FunctionalLocation> {floc1, floc2},
                                 WorkAssignmentFixture.CreateConsoleOperator(), shift, user, LogType.DailyDirective,
                                 RoleFixture.GetRealRoleA(Site.OILSAND_ID));
            log.RtfComments = "Comments";
            log.PlainTextComments = "Comments";
            log.CustomFieldEntries.Clear();
            log.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase1().IdValue, "Field Name 1", "Field Entry 1", null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            log.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase2().IdValue, "Field Name 2", "Field Entry 2", null,null, 2, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            log.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase3().IdValue, "Field Name 3", "Field Entry 3", null,null, 3, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            log.CustomFields.Clear();
            log.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase1());
            log.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase2());
            log.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase3());
            log = logDao.Insert(log);

            // make sure querying for standard logs doesn't bring back our directive
            {
                List<CustomFieldTrendReportDTO> standardLogResults = customFieldTrendReportDtoDao.QueryCustomFieldTrendReportDataForLogs(new RootFlocSet(floc1), userShift.StartDateTimeWithPadding, userShift.EndDateTimeWithPadding, new List<WorkAssignment> { log.WorkAssignment }, false, LogType.Standard);    
                Assert.AreEqual(0, standardLogResults.Count);
            }

            List<CustomFieldTrendReportDTO> results = customFieldTrendReportDtoDao.QueryCustomFieldTrendReportDataForLogs(new RootFlocSet(floc1), userShift.StartDateTimeWithPadding, userShift.EndDateTimeWithPadding, new List<WorkAssignment> { log.WorkAssignment }, false, LogType.DailyDirective);

            List<CustomFieldTrendReportDTO> dtos = results.FindAll(x => x.Id == log.Id);
            Assert.AreEqual(1, dtos.Count);

            CustomFieldTrendReportDTO resultDto = dtos[0];

            Assert.AreEqual(log.LogDateTime, resultDto.LogDateTime);
            Assert.AreEqual("3/20/2010 - 12DA", resultDto.ShiftName);

            List<string> flocs = resultDto.FunctionalLocationNames.BuildListFromCommaSeparatedList();
            Assert.AreEqual(2, flocs.Count);
            Assert.IsTrue(flocs.Exists(obj => obj == floc1.FullHierarchy));
            Assert.IsTrue(flocs.Exists(obj => obj == floc2.FullHierarchy));

            Assert.IsTrue(resultDto.CustomFieldEntries.Exists(
                e => e.CustomFieldName == "Field Name 1" && e.FieldEntry == "Field Entry 1" && e.DisplayOrder == 1));
            Assert.IsTrue(resultDto.CustomFieldEntries.Exists(
                e => e.CustomFieldName == "Field Name 2" && e.FieldEntry == "Field Entry 2" && e.DisplayOrder == 2));
            Assert.IsTrue(resultDto.CustomFieldEntries.Exists(
                e => e.CustomFieldName == "Field Name 3" && e.FieldEntry == "Field Entry 3" && e.DisplayOrder == 3));
        }

        [Ignore] [Test]
        public void ShouldQueryCustomFieldTrendReportDtosForSummaryLogs()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3();

            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));
            UserShift userShift = new UserShift(shift, now);

            SummaryLog summaryLog = CreateSummaryLog(
                shift,
                floc1,
                now,
                "comments 1");
            summaryLog.FunctionalLocations = new List<FunctionalLocation> { floc1, floc2 };
            summaryLog.WorkAssignment = WorkAssignmentFixture.CreateConsoleOperator();

            summaryLog.CustomFieldEntries.Clear();
            summaryLog.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase1().IdValue, "Field Name 1", "Field Entry 1", null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            summaryLog.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase3().IdValue, "Field Name 3", "Field Entry 3", null,null, 3, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            summaryLog.CustomFields.Clear();
            summaryLog.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase1());
            summaryLog.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase2());
            summaryLog.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase3());
            summaryLog = summaryLogDao.Insert(summaryLog);

            List<CustomFieldTrendReportDTO> results = customFieldTrendReportDtoDao.QueryCustomFieldTrendReportDataForSummaryLogs(new RootFlocSet(floc1), userShift.StartDateTimeWithPadding, userShift.EndDateTimeWithPadding, new List<WorkAssignment> { summaryLog.WorkAssignment }, false);

            List<CustomFieldTrendReportDTO> dtos = results.FindAll(x => x.Id == summaryLog.Id);
            Assert.AreEqual(1, dtos.Count);

            CustomFieldTrendReportDTO resultDto = dtos[0];

            Assert.AreEqual(summaryLog.LogDateTime, resultDto.LogDateTime);
            Assert.AreEqual("3/20/2010 - 12DA", resultDto.ShiftName);

            List<string> flocs = resultDto.FunctionalLocationNames.BuildListFromCommaSeparatedList();
            Assert.AreEqual(2, flocs.Count);
            Assert.IsTrue(flocs.Exists(obj => obj == floc1.FullHierarchy));
            Assert.IsTrue(flocs.Exists(obj => obj == floc2.FullHierarchy));

            Assert.AreEqual(2, resultDto.CustomFieldEntries.Count);
            Assert.IsTrue(resultDto.CustomFieldEntries.Exists(
                e => e.CustomFieldName == "Field Name 1" && e.FieldEntry == "Field Entry 1" && e.DisplayOrder == 1));
            Assert.IsTrue(resultDto.CustomFieldEntries.Exists(
                e => e.CustomFieldName == "Field Name 3" && e.FieldEntry == "Field Entry 3" && e.DisplayOrder == 3));

            Assert.IsTrue(resultDto.CustomFields.Exists(e => e.Name == CustomFieldFixture.CustomFieldExistingInDatabase1().Name));
            Assert.IsTrue(resultDto.CustomFields.Exists(e => e.Name == CustomFieldFixture.CustomFieldExistingInDatabase2().Name));
            Assert.IsTrue(resultDto.CustomFields.Exists(e => e.Name == CustomFieldFixture.CustomFieldExistingInDatabase3().Name));
        }

        private static SummaryLog CreateSummaryLog(ShiftPattern shift, FunctionalLocation floc1, DateTime now, string comments)
        {
            return SummaryLogFixture.CreateSummaryLog(shift, floc1, now, comments);
        }

        private static Log CreateLog(ShiftPattern shiftPattern, List<FunctionalLocation> flocs, DateTime loggedDateTime, User createdByUser, WorkAssignment workAssignment)
        {
            return LogFixture.CreateLog(
                loggedDateTime, flocs, workAssignment, shiftPattern, createdByUser, LogType.Standard,
                RoleFixture.GetRealRoleA(Site.OILSAND_ID));
        }

    }
}
