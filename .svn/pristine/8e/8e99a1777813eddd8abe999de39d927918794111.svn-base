using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    [Category("Database")]
    public class DetailedLogReportDTODaoTest : AbstractDaoTest
    {
        private IDetailedLogReportDTODao reportDTODao;
        private ILogDao logDao;
        private ISummaryLogDao summaryLogDao;
        private IWorkAssignmentDao workAssignmentDao;

        protected override void TestInitialize()
        {
            reportDTODao = DaoRegistry.GetDao<IDetailedLogReportDTODao>();
            logDao = DaoRegistry.GetDao<ILogDao>();
            summaryLogDao = DaoRegistry.GetDao<ISummaryLogDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }

        protected override void Cleanup()
        {
        }

        private WorkAssignment GetAssignment(FunctionalLocation floc)
        {
            WorkAssignment assignment = new WorkAssignment("Diet Coker Bored Man", "WA", "General", floc.Site.IdValue, RoleFixture.GetRealRoleA(floc.Site.IdValue));
            assignment = workAssignmentDao.Insert(assignment);
            return assignment;
        }

        private static Log CreateLog(
            ShiftPattern shiftPattern, List<FunctionalLocation> flocs, DateTime logDateTime,
            string comments, User createdByUser, WorkAssignment workAssignment)
        {
            return new Log(null,
                           null,
                           null,
                           DataSource.MANUAL,
                           flocs,
                           false, false, false, false, false, false,
                           comments,
                           comments,
                           logDateTime,
                           shiftPattern,
                           createdByUser,
                           createdByUser,
                           logDateTime,
                           logDateTime,
                           false,
                           false,
                           RoleFixture.GetRealRoleA(Site.OILSAND_ID),
                           LogType.Standard,
                           workAssignment);
        }

        private long InsertLog(ShiftPattern shift, DateTime logDateTime, FunctionalLocation floc)
        {
            return InsertLog(shift, logDateTime, floc, null);
        }

        private long InsertLog(ShiftPattern shift, DateTime logDateTime, FunctionalLocation floc, WorkAssignment workAssignment)
        {
            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            Log log = CreateLog(shift, new List<FunctionalLocation> { floc }, logDateTime, "Comments", user, workAssignment);
            log = logDao.Insert(log);
            return log.IdValue;
        }

        private static SummaryLog CreateSummaryLog(
            ShiftPattern shiftPattern, List<FunctionalLocation> flocs, DateTime logDateTime,
            string comments, User createdByUser, WorkAssignment workAssignment)
        {
            return new SummaryLog(
                flocs, comments, comments, null, DataSource.MANUAL,
                false, false, false, false, false, false,
                logDateTime, logDateTime, shiftPattern, createdByUser, RoleFixture.GetRealRoleA(Site.OILSAND_ID), createdByUser, logDateTime,
                new List<DocumentLink>(), 
                workAssignment, 
                new List<CustomFieldEntry>(), new List<CustomField>(), 
                null, null, false);
        }

        private long InsertSummaryLog(ShiftPattern shift, DateTime logDateTime, FunctionalLocation floc)
        {
            return InsertSummaryLog(shift, logDateTime, floc, null);
        }

        private long InsertSummaryLog(ShiftPattern shift, DateTime logDateTime, FunctionalLocation floc, WorkAssignment workAssignment)
        {
            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            SummaryLog log = CreateSummaryLog(shift, new List<FunctionalLocation> { floc }, logDateTime, "Comments", user, workAssignment);
            log = summaryLogDao.Insert(log);
            return log.IdValue;
        }

        private static void AssertExists(bool expectExists, List<DetailedLogReportDTO> results, params long[] ids)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DetailedLogReportDTO dto in results)
            {
                sb.Append(dto.Id);
                sb.Append(", ");
            }
            string actualString = sb.ToString();
            string expectedString = expectExists ? "exist" : "not exist";
            foreach (long id in ids)
            {
                string errorMesasge = "- Expected " + expectedString + ": " + id + Environment.NewLine + "  - Actual: " + actualString;
                Assert.AreEqual(expectExists, results.Exists(obj => obj.Id == id), errorMesasge);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryForLogs_VaryFloc()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_PLT3();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            FunctionalLocation floc3 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SCH();
            FunctionalLocation floc4 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SCH_33CR001();
            FunctionalLocation floc5 = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();

            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            long id1 = InsertLog(shift, now, floc1);
            long id2 = InsertLog(shift, now, floc2);
            long id3 = InsertLog(shift, now, floc3);
            long id4 = InsertLog(shift, now, floc4);
            long id5 = InsertLog(shift, now, floc5);

            UserShift userShift = new UserShift(shift, now);
            List<WorkAssignment> workAssignments = new List<WorkAssignment>();
            const bool includeNullWorkAssignment = true;
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForLogs(
                    userShift, userShift, new RootFlocSet(new List<FunctionalLocation> { floc1, floc2, floc5 }), workAssignments, includeNullWorkAssignment);
                AssertExists(true, results, id1, id2, id3, id4, id5);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForLogs(
                    userShift, userShift, new RootFlocSet(new List<FunctionalLocation> { floc1 }), workAssignments, includeNullWorkAssignment);
                AssertExists(true, results, id1, id2, id3, id4);
                AssertExists(false, results, id5);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForLogs(
                    userShift, userShift, new RootFlocSet(new List<FunctionalLocation> { floc2 }), workAssignments, includeNullWorkAssignment);
                AssertExists(true, results, id2, id3, id4);
                AssertExists(false, results, id1, id5);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForLogs(
                    userShift, userShift, new RootFlocSet(new List<FunctionalLocation> { floc5 }), workAssignments, includeNullWorkAssignment);
                AssertExists(true, results, id5);
                AssertExists(false, results, id1, id2, id3, id4);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryForLogs_VaryShiftRange()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            ShiftPattern dayShift = ShiftPatternFixture.CreateDayShift();
            ShiftPattern nightShift = ShiftPatternFixture.CreateNightShift();

            UserShift shift1 = new UserShift(dayShift, new Date(2010, 03, 20));
            UserShift shift2 = new UserShift(nightShift, new Date(2010, 03, 20));
            UserShift shift3 = new UserShift(dayShift, new Date(2010, 03, 21));
            UserShift shift4 = new UserShift(nightShift, new Date(2010, 03, 21));

            long id1 = InsertLog(dayShift, shift1.StartDateTime.AddMinutes(-30), floc);
            long id2 = InsertLog(dayShift, shift1.StartDateTime, floc);
            long id3 = InsertLog(dayShift, shift1.StartDateTime.AddHours(4), floc);
            long id4 = InsertLog(dayShift, shift1.EndDateTime, floc);
            long id5 = InsertLog(dayShift, shift1.EndDateTime.AddMinutes(30), floc);
            long id6 = InsertLog(nightShift, shift2.StartDateTime.AddMinutes(-30), floc);
            long id7 = InsertLog(nightShift, shift2.StartDateTime, floc);
            long id8 = InsertLog(nightShift, shift2.StartDateTime.AddHours(4), floc);
            long id9 = InsertLog(nightShift, shift2.EndDateTime, floc);
            long id10 = InsertLog(nightShift, shift2.EndDateTime.AddMinutes(30), floc);
            long id11 = InsertLog(dayShift, shift3.StartDateTime.AddMinutes(-30), floc);
            long id12 = InsertLog(dayShift, shift3.StartDateTime, floc);
            long id13 = InsertLog(dayShift, shift3.StartDateTime.AddHours(4), floc);
            long id14 = InsertLog(dayShift, shift3.EndDateTime, floc);
            long id15 = InsertLog(dayShift, shift3.EndDateTime.AddMinutes(30), floc);
            long id16 = InsertLog(nightShift, shift4.StartDateTime.AddMinutes(-30), floc);
            long id17 = InsertLog(nightShift, shift4.StartDateTime, floc);
            long id18 = InsertLog(nightShift, shift4.StartDateTime.AddHours(4), floc);
            long id19 = InsertLog(nightShift, shift4.EndDateTime, floc);
            long id20 = InsertLog(nightShift, shift4.EndDateTime.AddMinutes(30), floc);

            List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc };
            RootFlocSet flocSet = new RootFlocSet(flocs);
            List<WorkAssignment> workAssignments = new List<WorkAssignment>();
            const bool includeNullWorkAssignment = true;
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForLogs(
                    shift1, shift4, flocSet, workAssignments, includeNullWorkAssignment);
                AssertExists(true, results, id1, id2, id3, id4, id5, id6, id7, id8, id9, id10, id11, id12, id13, id14, id15, id16, id17, id18, id19, id20);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForLogs(
                    shift1, shift3, flocSet, workAssignments, includeNullWorkAssignment);
                AssertExists(true, results, id1, id2, id3, id4, id5, id6, id7, id8, id9, id10, id11, id12, id13, id14, id15);
                AssertExists(false, results, id16, id17, id18, id19, id20);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForLogs(
                    shift1, shift2, flocSet, workAssignments, includeNullWorkAssignment);
                AssertExists(true, results, id1, id2, id3, id4, id5, id6, id7, id8, id9, id10);
                AssertExists(false, results, id11, id12, id13, id14, id15, id16, id17, id18, id19, id20);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForLogs(
                    shift1, shift1, flocSet, workAssignments, includeNullWorkAssignment);
                AssertExists(true, results, id1, id2, id3, id4, id5);
                AssertExists(false, results, id6, id7, id8, id9, id10, id11, id12, id13, id14, id15, id16, id17, id18, id19, id20);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryForLogs_VaryAssignment()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            WorkAssignment assignment1 = GetAssignment(floc);
            WorkAssignment assignment2 = GetAssignment(floc);

            long id1 = InsertLog(shift, now, floc, null);
            long id2 = InsertLog(shift, now, floc, assignment1);
            long id3 = InsertLog(shift, now, floc, assignment2);

            UserShift userShift = new UserShift(shift, now);
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc };
            RootFlocSet flocSet = new RootFlocSet(flocs);
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForLogs(
                    userShift, userShift, flocSet, new List<WorkAssignment>(), false);
                AssertExists(false, results, id1, id2, id3);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForLogs(
                    userShift, userShift, flocSet, new List<WorkAssignment> { assignment1, assignment2 }, true);
                AssertExists(true, results, id1, id2, id3);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForLogs(
                    userShift, userShift, flocSet, new List<WorkAssignment>(), true);
                AssertExists(true, results, id1);
                AssertExists(false, results, id2, id3);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForLogs(
                    userShift, userShift, flocSet, new List<WorkAssignment> { assignment1 }, false);
                AssertExists(true, results, id2);
                AssertExists(false, results, id1, id3);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForLogs(
                    userShift, userShift, flocSet, new List<WorkAssignment> { assignment2 }, false);
                AssertExists(true, results, id3);
                AssertExists(false, results, id1, id2);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForLogs(
                    userShift, userShift, flocSet, new List<WorkAssignment> { assignment1, assignment2 }, false);
                AssertExists(true, results, id2, id3);
                AssertExists(false, results, id1);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForLogs(
                    userShift, userShift, flocSet, new List<WorkAssignment> { assignment2 }, true);
                AssertExists(true, results, id1, id3);
                AssertExists(false, results, id2);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryForLogs_IncludeFields()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3();

            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));
            UserShift userShift = new UserShift(shift, now);

            Log log = CreateLog(shift, new List<FunctionalLocation> { floc1, floc2 }, now, "", user, null);
            log.RtfComments = "Comments";
            log.PlainTextComments = "Comments";
            log.DocumentLinks.Clear();
            log.DocumentLinks.Add(new DocumentLink("Url1", "Title1"));
            log.DocumentLinks.Add(new DocumentLink("Url2", "Title2"));
            log.DocumentLinks.Add(new DocumentLink("Url3", "Title3"));
            log.CustomFieldEntries.Clear();
            log.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase1().IdValue, "Field Name 1", "Field Entry 1", null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            // purposefully leave out a field entry for custom field 2 so we can make sure it gets created as an empty entry
            log.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase3().IdValue, "Field Name 3", "Field Entry 3", null,null, 3, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            log.CustomFields.Clear();
            log.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase1());
            log.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase2());
            log.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase3());
            log = logDao.Insert(log);

            List<DetailedLogReportDTO> results = reportDTODao.QueryForLogs(
                userShift, userShift,
                new RootFlocSet(new List<FunctionalLocation> { floc1 }),
                new List<WorkAssignment>(), true);

            DetailedLogReportDTO resultDto = results.Find(obj => obj.Id == log.Id);

            Assert.AreEqual(log.LogDateTime, resultDto.LogDateTime);
            Assert.AreEqual(log.CreatedShiftPattern.IdValue, resultDto.ShiftId);
            Assert.AreEqual(log.PlainTextComments, resultDto.PlainTextComments);

            Assert.AreEqual(2, resultDto.FunctionalLocationNames.Count);
            Assert.IsTrue(resultDto.FunctionalLocationNames.Exists(obj => obj == floc1.FullHierarchyWithDescription));
            Assert.IsTrue(resultDto.FunctionalLocationNames.Exists(obj => obj == floc2.FullHierarchyWithDescription));
            Assert.AreEqual(2, resultDto.FunctionalLocationSegmentDtos.Count);
            Assert.IsTrue(resultDto.FunctionalLocationSegmentDtos.Exists(obj => obj.Division == floc1.Division && obj.Section == floc1.Section && obj.Unit == floc1.Unit));
            Assert.IsTrue(resultDto.FunctionalLocationSegmentDtos.Exists(obj => obj.Division == floc2.Division && obj.Section == floc2.Section && obj.Unit == floc2.Unit));

            Assert.AreEqual(3, resultDto.DocumentLinks.Count);
            Assert.IsTrue(resultDto.DocumentLinks.Exists(obj => obj.Url == "Url1" && obj.Title == "Title1"));
            Assert.IsTrue(resultDto.DocumentLinks.Exists(obj => obj.Url == "Url2" && obj.Title == "Title2"));
            Assert.IsTrue(resultDto.DocumentLinks.Exists(obj => obj.Url == "Url3" && obj.Title == "Title3"));

            Assert.IsTrue(resultDto.CustomFieldEntries.Count >= 3);
            Assert.IsTrue(resultDto.CustomFieldEntries.Exists(
                e => e.CustomFieldName == "Field Name 1" && e.FieldEntry == "Field Entry 1" && e.DisplayOrder == 0));
            Assert.IsTrue(resultDto.CustomFieldEntries.Exists(
                e => e.CustomFieldName == CustomFieldFixture.CustomFieldExistingInDatabase2().Name && e.FieldEntry == null && e.DisplayOrder == 1));
            Assert.IsTrue(resultDto.CustomFieldEntries.Exists(
                e => e.CustomFieldName == "Field Name 3" && e.FieldEntry == "Field Entry 3" && e.DisplayOrder == 2));
        }

        [Ignore] [Test]
        public void ShouldQueryForSummaryLogs_VaryFloc()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_PLT3();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            FunctionalLocation floc3 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SCH();
            FunctionalLocation floc4 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SCH_33CR001();
            FunctionalLocation floc5 = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();

            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            long id1 = InsertSummaryLog(shift, now, floc1);
            long id2 = InsertSummaryLog(shift, now, floc2);
            long id3 = InsertSummaryLog(shift, now, floc3);
            long id4 = InsertSummaryLog(shift, now, floc4);
            long id5 = InsertSummaryLog(shift, now, floc5);

            UserShift userShift = new UserShift(shift, now);
            List<WorkAssignment> workAssignments = new List<WorkAssignment>();
            const bool includeNullWorkAssignment = true;
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForSummaryLogs(
                    userShift, userShift, new RootFlocSet(new List<FunctionalLocation> { floc1, floc2, floc5 }), workAssignments, includeNullWorkAssignment);
                AssertExists(true, results, id1, id2, id3, id4, id5);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForSummaryLogs(
                    userShift, userShift, new RootFlocSet(new List<FunctionalLocation> { floc1 }), workAssignments, includeNullWorkAssignment);
                AssertExists(true, results, id1, id2, id3, id4);
                AssertExists(false, results, id5);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForSummaryLogs(
                    userShift, userShift, new RootFlocSet(new List<FunctionalLocation> { floc2 }), workAssignments, includeNullWorkAssignment);
                AssertExists(true, results, id2, id3, id4);
                AssertExists(false, results, id1, id5);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForSummaryLogs(
                    userShift, userShift, new RootFlocSet(new List<FunctionalLocation> { floc5 }), workAssignments, includeNullWorkAssignment);
                AssertExists(true, results, id5);
                AssertExists(false, results, id1, id2, id3, id4);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryForSummaryLogs_VaryShiftRange()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            ShiftPattern dayShift = ShiftPatternFixture.CreateDayShift();
            ShiftPattern nightShift = ShiftPatternFixture.CreateNightShift();

            UserShift shift1 = new UserShift(dayShift, new Date(2010, 03, 20));
            UserShift shift2 = new UserShift(nightShift, new Date(2010, 03, 20));
            UserShift shift3 = new UserShift(dayShift, new Date(2010, 03, 21));
            UserShift shift4 = new UserShift(nightShift, new Date(2010, 03, 21));

            long id1 = InsertSummaryLog(dayShift, shift1.StartDateTime.AddMinutes(-30), floc);
            long id2 = InsertSummaryLog(dayShift, shift1.StartDateTime, floc);
            long id3 = InsertSummaryLog(dayShift, shift1.StartDateTime.AddHours(4), floc);
            long id4 = InsertSummaryLog(dayShift, shift1.EndDateTime, floc);
            long id5 = InsertSummaryLog(dayShift, shift1.EndDateTime.AddMinutes(30), floc);
            long id6 = InsertSummaryLog(nightShift, shift2.StartDateTime.AddMinutes(-30), floc);
            long id7 = InsertSummaryLog(nightShift, shift2.StartDateTime, floc);
            long id8 = InsertSummaryLog(nightShift, shift2.StartDateTime.AddHours(4), floc);
            long id9 = InsertSummaryLog(nightShift, shift2.EndDateTime, floc);
            long id10 = InsertSummaryLog(nightShift, shift2.EndDateTime.AddMinutes(30), floc);
            long id11 = InsertSummaryLog(dayShift, shift3.StartDateTime.AddMinutes(-30), floc);
            long id12 = InsertSummaryLog(dayShift, shift3.StartDateTime, floc);
            long id13 = InsertSummaryLog(dayShift, shift3.StartDateTime.AddHours(4), floc);
            long id14 = InsertSummaryLog(dayShift, shift3.EndDateTime, floc);
            long id15 = InsertSummaryLog(dayShift, shift3.EndDateTime.AddMinutes(30), floc);
            long id16 = InsertSummaryLog(nightShift, shift4.StartDateTime.AddMinutes(-30), floc);
            long id17 = InsertSummaryLog(nightShift, shift4.StartDateTime, floc);
            long id18 = InsertSummaryLog(nightShift, shift4.StartDateTime.AddHours(4), floc);
            long id19 = InsertSummaryLog(nightShift, shift4.EndDateTime, floc);
            long id20 = InsertSummaryLog(nightShift, shift4.EndDateTime.AddMinutes(30), floc);

            RootFlocSet flocSet = new RootFlocSet(new List<FunctionalLocation> { floc });
            List<WorkAssignment> workAssignments = new List<WorkAssignment>();
            const bool includeNullWorkAssignment = true;
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForSummaryLogs(
                    shift1, shift4, flocSet, workAssignments, includeNullWorkAssignment);
                AssertExists(true, results, id1, id2, id3, id4, id5, id6, id7, id8, id9, id10, id11, id12, id13, id14, id15, id16, id17, id18, id19, id20);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForSummaryLogs(
                    shift1, shift3, flocSet, workAssignments, includeNullWorkAssignment);
                AssertExists(true, results, id1, id2, id3, id4, id5, id6, id7, id8, id9, id10, id11, id12, id13, id14, id15);
                AssertExists(false, results, id16, id17, id18, id19, id20);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForSummaryLogs(
                    shift1, shift2, flocSet, workAssignments, includeNullWorkAssignment);
                AssertExists(true, results, id1, id2, id3, id4, id5, id6, id7, id8, id9, id10);
                AssertExists(false, results, id11, id12, id13, id14, id15, id16, id17, id18, id19, id20);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForSummaryLogs(
                    shift1, shift1, flocSet, workAssignments, includeNullWorkAssignment);
                AssertExists(true, results, id1, id2, id3, id4, id5);
                AssertExists(false, results, id6, id7, id8, id9, id10, id11, id12, id13, id14, id15, id16, id17, id18, id19, id20);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryForSummaryLogs_VaryAssignment()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            WorkAssignment assignment1 = GetAssignment(floc);
            WorkAssignment assignment2 = GetAssignment(floc);

            long id1 = InsertSummaryLog(shift, now, floc, null);
            long id2 = InsertSummaryLog(shift, now, floc, assignment1);
            long id3 = InsertSummaryLog(shift, now, floc, assignment2);

            UserShift userShift = new UserShift(shift, now);
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc };
            RootFlocSet flocSet = new RootFlocSet(flocs);
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForSummaryLogs(
                    userShift, userShift, flocSet, new List<WorkAssignment>(), false);
                AssertExists(false, results, id1, id2, id3);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForSummaryLogs(
                    userShift, userShift, flocSet, new List<WorkAssignment> { assignment1, assignment2 }, true);
                AssertExists(true, results, id1, id2, id3);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForSummaryLogs(
                    userShift, userShift, flocSet, new List<WorkAssignment>(), true);
                AssertExists(true, results, id1);
                AssertExists(false, results, id2, id3);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForSummaryLogs(
                    userShift, userShift, flocSet, new List<WorkAssignment> { assignment1 }, false);
                AssertExists(true, results, id2);
                AssertExists(false, results, id1, id3);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForSummaryLogs(
                    userShift, userShift, flocSet, new List<WorkAssignment> { assignment2 }, false);
                AssertExists(true, results, id3);
                AssertExists(false, results, id1, id2);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForSummaryLogs(
                    userShift, userShift, flocSet, new List<WorkAssignment> { assignment1, assignment2 }, false);
                AssertExists(true, results, id2, id3);
                AssertExists(false, results, id1);
            }
            {
                List<DetailedLogReportDTO> results = reportDTODao.QueryForSummaryLogs(
                    userShift, userShift, flocSet, new List<WorkAssignment> { assignment2 }, true);
                AssertExists(true, results, id1, id3);
                AssertExists(false, results, id2);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryForSummaryLogs_IncludeFields()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3();

            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));
            UserShift userShift = new UserShift(shift, now);

            SummaryLog log = CreateSummaryLog(shift, new List<FunctionalLocation> { floc1, floc2 }, now, "", user, null);
            log.RtfComments = "Comments";
            log.PlainTextComments = "Comments";
            log.DocumentLinks.Clear();
            log.DocumentLinks.Add(new DocumentLink("Url1", "Title1"));
            log.DocumentLinks.Add(new DocumentLink("Url2", "Title2"));
            log.DocumentLinks.Add(new DocumentLink("Url3", "Title3"));
            log.CustomFieldEntries.Clear();
            log.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase1().IdValue, "Field Name 1", "Field Entry 1", null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            // purposefully leave out a field entry for custom field 2 so we can make sure it gets created as an empty entry
            log.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase3().IdValue, "Field Name 3", "Field Entry 3", null,null, 3, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            log.CustomFields.Clear();
            log.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase1());
            log.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase2());
            log.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase3());
            log = summaryLogDao.Insert(log);

            List<DetailedLogReportDTO> results = reportDTODao.QueryForSummaryLogs(
                userShift, userShift,
                new RootFlocSet(new List<FunctionalLocation> { floc1 }),
                new List<WorkAssignment>(), true);

            DetailedLogReportDTO resultDto = results.Find(obj => obj.Id == log.Id);

            Assert.AreEqual(log.LogDateTime, resultDto.LogDateTime);
            Assert.AreEqual(log.CreatedShiftPattern.IdValue, resultDto.ShiftId);
            Assert.IsFalse(resultDto.RecommendForSummary);
            Assert.AreEqual(log.PlainTextComments, resultDto.PlainTextComments);

            Assert.AreEqual(2, resultDto.FunctionalLocationNames.Count);
            Assert.IsTrue(resultDto.FunctionalLocationNames.Exists(obj => obj == floc1.FullHierarchyWithDescription));
            Assert.IsTrue(resultDto.FunctionalLocationNames.Exists(obj => obj == floc2.FullHierarchyWithDescription));
            Assert.AreEqual(2, resultDto.FunctionalLocationSegmentDtos.Count);
            Assert.IsTrue(resultDto.FunctionalLocationSegmentDtos.Exists(obj => obj.Division == floc1.Division && obj.Section == floc1.Section && obj.Unit == floc1.Unit));
            Assert.IsTrue(resultDto.FunctionalLocationSegmentDtos.Exists(obj => obj.Division == floc2.Division && obj.Section == floc2.Section && obj.Unit == floc2.Unit));

            Assert.AreEqual(3, resultDto.DocumentLinks.Count);
            Assert.IsTrue(resultDto.DocumentLinks.Exists(obj => obj.Url == "Url1" && obj.Title == "Title1"));
            Assert.IsTrue(resultDto.DocumentLinks.Exists(obj => obj.Url == "Url2" && obj.Title == "Title2"));
            Assert.IsTrue(resultDto.DocumentLinks.Exists(obj => obj.Url == "Url3" && obj.Title == "Title3"));

            Assert.IsTrue(resultDto.CustomFieldEntries.Count >= 3);
            Assert.IsTrue(resultDto.CustomFieldEntries.Exists(
                e => e.CustomFieldName == "Field Name 1" && e.FieldEntry == "Field Entry 1" && e.DisplayOrder == 0));
            Assert.IsTrue(resultDto.CustomFieldEntries.Exists(
                e => e.CustomFieldName == CustomFieldFixture.CustomFieldExistingInDatabase2().Name && e.FieldEntry == null && e.DisplayOrder == 1));
            Assert.IsTrue(resultDto.CustomFieldEntries.Exists(
                e => e.CustomFieldName == "Field Name 3" && e.FieldEntry == "Field Entry 3" && e.DisplayOrder == 2));
        }

    }
}
