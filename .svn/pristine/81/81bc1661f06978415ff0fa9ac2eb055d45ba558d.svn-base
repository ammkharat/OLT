using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture] [Category("Database")]
    public class LogDTODaoTest : AbstractDaoTest
    {
        private ILogDTODao logDTODao;
        private ILogDao logDao;
        private IShiftPatternDao shiftPatternDao;
        private IFunctionalLocationDao functionalLocationDao;
        private IUserDao userDao;
        private ILogReadDao logReadDao;
        private FunctionalLocation existingFloc;
        private IWorkAssignmentDao workAssignmentDao;
        private Role roleInDB;
        private IRoleDao roleDao;

        protected override void TestInitialize()
        {
            logDTODao = DaoRegistry.GetDao<ILogDTODao>();
            logDao = DaoRegistry.GetDao<ILogDao>();
            shiftPatternDao = DaoRegistry.GetDao<IShiftPatternDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            existingFloc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            userDao = DaoRegistry.GetDao<IUserDao>();
            logReadDao = DaoRegistry.GetDao<ILogReadDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            
            // Get a Role already in the Database
            roleDao = DaoRegistry.GetDao<IRoleDao>();
            roleInDB = roleDao.QueryByActiveDirectoryKey(SiteFixture.Oilsands(), "RestrictionReportingAdmin");
        }

        protected override void Cleanup()
        {
        }
        [Ignore] [Test]
        public void ShouldReturnDtosForLogsAssociatedWithGivenWorkPermitMontreal()
        {
            User user = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();

            IWorkPermitMontrealDao workPermitMontrealDao = DaoRegistry.GetDao<IWorkPermitMontrealDao>();
            IWorkPermitMontrealGroupDao workPermitMontrealGroupDao = DaoRegistry.GetDao<IWorkPermitMontrealGroupDao>();

            WorkPermitMontrealGroup group = workPermitMontrealGroupDao.QueryAll()[0];

            WorkPermitMontreal permit = WorkPermitMontrealFixture.CreateForInsert();
            workPermitMontrealDao.Insert(permit, null);

            Log log = CreateLogWithValidShiftAndLogTime(user);
            Log insertedLog = logDao.Insert(log, permit);

            {
                int count = logDao.QueryCountOfLogsAssociatedToWorkPermitMontreal(permit.IdValue);
                Assert.AreEqual(1, count);
            }

            {
                List<LogDTO> logDtos = logDTODao.QueryByWorkPermitMontreal(permit.IdValue);

                Assert.AreEqual(1, logDtos.Count);
                Assert.AreEqual(insertedLog.IdValue, logDtos[0].IdValue);
            }
        }
        [Ignore] [Test]
        public void ShouldQueryCreatedAndLastModifiedUser()
        {
            User user1 = UserFixture.CreateUser("username1", "first1", "last1");
            userDao.Insert(user1);
            User user2 = UserFixture.CreateUser("username2", "first2", "last2");
            userDao.Insert(user2);

            Log log = CreateLogWithValidShiftAndLogTime(user1);
            log.IsOperatingEngineerLog = false;
            log.FunctionalLocations.Clear();
            log.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF());
            log.LastModifiedBy = user2;
            logDao.Insert(log);

            Log opEngLog = CreateLogWithValidShiftAndLogTime(user1);
            opEngLog.IsOperatingEngineerLog = true;
            opEngLog.FunctionalLocations.Clear();
            opEngLog.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF());
            opEngLog.LastModifiedBy = user2;
            logDao.Insert(opEngLog);

            {
                List<LogDTO> results = logDTODao.QueryById(new List<long> {log.IdValue});
                LogDTO logDto = results.Find(obj => obj.Id == log.Id);
                Assert.IsNotNull(logDto);
                Assert.AreEqual("last1, first1 [username1]", logDto.CreatedByFullnameWithUserName);
                Assert.AreEqual("last2, first2 [username2]", logDto.LastModifiedFullNameWithUserName);
            }
            DateTime loggedDateTime = log.LogDateTime;
            {
                DateRange range = new DateRange(loggedDateTime.SubtractDays(1).ToDate(), loggedDateTime.AddDays(1).ToDate());
                List<LogDTO> results = logDTODao.QueryByFunctionalLocations(new RootFlocSet(log.FunctionalLocations[0]), range, null);
                LogDTO logDto = results.Find(obj => obj.Id == log.Id);
                Assert.IsNotNull(logDto);
                Assert.AreEqual("last1, first1 [username1]", logDto.CreatedByFullnameWithUserName);
                Assert.AreEqual("last2, first2 [username2]", logDto.LastModifiedFullNameWithUserName);
            }
            {
                List<LogDTO> results = logDTODao.QueryByFunctionalLocations(new RootFlocSet(log.FunctionalLocations[0]), loggedDateTime.SubtractDays(1), loggedDateTime.AddDays(1), log.WorkAssignment, null);
                LogDTO logDto = results.Find(obj => obj.Id == log.Id);
                Assert.IsNotNull(logDto);
                Assert.AreEqual("last1, first1 [username1]", logDto.CreatedByFullnameWithUserName);
                Assert.AreEqual("last2, first2 [username2]", logDto.LastModifiedFullNameWithUserName);
            }
            {
                List<LogDTO> results = logDTODao.QueryOpEngineerLogsByFunctionalLocation(new RootFlocSet(log.FunctionalLocations[0]), loggedDateTime.SubtractDays(1), null);
                LogDTO logDto = results.Find(obj => obj.Id == opEngLog.Id);
                Assert.IsNotNull(logDto);
                Assert.AreEqual("last1, first1 [username1]", logDto.CreatedByFullnameWithUserName);
                Assert.AreEqual("last2, first2 [username2]", logDto.LastModifiedFullNameWithUserName);
            }
            {
                List<LogDTO> results = logDTODao.QueryOpEngLogsByFunctionalLocations(new RootFlocSet(log.FunctionalLocations[0]), loggedDateTime.SubtractDays(1), loggedDateTime.AddDays(1), null);
                LogDTO logDto = results.Find(obj => obj.Id == opEngLog.Id);
                Assert.IsNotNull(logDto);
                Assert.AreEqual("last1, first1 [username1]", logDto.CreatedByFullnameWithUserName);
                Assert.AreEqual("last2, first2 [username2]", logDto.LastModifiedFullNameWithUserName);
            }
            {
                List<LogDTO> results = logDTODao.GetLogsWhereLoggedDateOrActualLoggedDateMatchRange(new RootFlocSet(log.FunctionalLocations[0]), new UserShift(log.CreatedShiftPattern, loggedDateTime), null);
                LogDTO logDto = results.Find(obj => obj.Id == log.Id);
                Assert.IsNotNull(logDto);
                Assert.AreEqual("last1, first1 [username1]", logDto.CreatedByFullnameWithUserName);
                Assert.AreEqual("last2, first2 [username2]", logDto.LastModifiedFullNameWithUserName);
            }
        }

        [Ignore] [Test]
        public void QueryByFunctionalLocationShouldReturnDTOs()
        {
            List<FunctionalLocation> functionalLocations = FunctionalLocationFixture.GetListWith2Units();
            List<LogDTO> dtos = logDTODao.QueryByFunctionalLocations(new RootFlocSet(functionalLocations), new DateRange(null, null), null);
            Assert.IsTrue(dtos.Count > 0);

            foreach (LogDTO dto in dtos)
            {
                Assert.IsTrue(functionalLocations.Exists(floc => dto.FunctionalLocationNames.Contains(floc.FullHierarchy)));
            }            
        }

        [Ignore] [Test]
        public void ShouldQueryByMultipleIds()
        {
            Log log1 = logDao.Insert(CreateLogWithValidShiftAndLogTime());
            Log log2 = logDao.Insert(CreateLogWithValidShiftAndLogTime());

            List<LogDTO> results = logDTODao.QueryById(new List<long> { log1.IdValue, log2.IdValue });
            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.Exists(obj => obj.Id == log1.IdValue));
            Assert.IsTrue(results.Exists(obj => obj.Id == log2.IdValue));  
        }

        [Ignore] [Test]
        public void QueryByIdShouldReturnALogDTO()
        {
            Log log = CreateLogWithValidShiftAndLogTime();
            log.OtherFollowUp = true;
            log.OperationsFollowUp = false;
            log.RecommendForShiftSummary = true;
            log = logDao.Insert(log);

            LogDTO dto = logDTODao.QueryById(new List<long>{log.IdValue})[0];
            Assert.IsNotNull(dto);
            Assert.AreEqual(log.CreationUser.Id, dto.CreatedByUserId);
            Assert.IsTrue(dto.OtherFollowUp);
            Assert.IsFalse(dto.OperationsFollowUp);
            Assert.AreEqual(log.LogDateTime.ToDate(), dto.CreatedShiftStartDate);
            Assert.AreEqual(log.Source.Id, dto.SourceId);
            Assert.IsTrue(dto.RecommendForShiftSummary);
            Assert.IsTrue(log.LastModifiedDate.Subtract(dto.LastModifiedDateTime).TotalSeconds < 1);          
        }

        [Ignore] [Test]
        public void ALogDTOWithoutChildrenShouldHaveTheWithChildrenFlagSetToFalse()
        {
            Log log = CreateLogWithValidShiftAndLogTime();
            log.ReplyToLogId = null;
            log.RootLogId = null;
            log = logDao.Insert(log);

            LogDTO dto = logDTODao.QueryById(new List<long> { log.IdValue })[0];
            Assert.IsFalse(dto.HasChildren);
        }

        [Ignore] [Test]
        public void ALogDTOWithChildrenShouldHaveTheWithChildrenFlagSetToTrue()
        {
            Log log = CreateLogWithValidShiftAndLogTime();
            log.ReplyToLogId = null;
            log.RootLogId = null;
            log.HasChildren = true;
            log = logDao.Insert(log);

            Log childLog = logDao.Insert(CreateLogWithValidShiftAndLogTime());
            childLog.ReplyToLogId = log.IdValue;
            logDao.Update(childLog);

            LogDTO dto = logDTODao.QueryById(new List<long> { log.IdValue })[0];
            Assert.IsTrue(dto.HasChildren);
        }

        [Ignore] [Test]
        public void ALogDTOThatIsPartOfAThreadShouldHaveTheIsPartOfThreadFlagSetToTrue()
        {
            Log parentLog = logDao.Insert(CreateLogWithValidShiftAndLogTime());
            
            {
                Log log = CreateLogWithValidShiftAndLogTime();
                log.ReplyToLogId = parentLog.IdValue;
                log.RootLogId = null;
                log = logDao.Insert(log);

                LogDTO dto = logDTODao.QueryById(new List<long> { log.IdValue })[0];
                Assert.IsTrue(dto.IsPartOfThread);
            }
        }

        [Ignore] [Test]
        public void ALogDTOThatIsNotPartOfAThreadShouldHaveTheIsPartOfThreadFlagSetToFalse()
        {
            Log log = CreateLogWithValidShiftAndLogTime();
            log.ReplyToLogId = null;
            log.RootLogId = null;
            log = logDao.Insert(log);

            LogDTO dto = logDTODao.QueryById(new List<long> { log.IdValue })[0];
            Assert.IsFalse(dto.IsPartOfThread);
        }

        [Ignore] [Test]
        public void ShouldNotContainLogsWithBadShiftAndCreationData()
        {
            ShiftPattern threeToFourShift = ShiftPatternFixture.CreateShiftPattern(new Time(03, 00), new Time(04, 00));
            threeToFourShift = shiftPatternDao.Insert(threeToFourShift);
            var badTimeOutsideShift = new DateTime(2006, 7, 11, 15, 00, 00);
            Log log = UpdateLogForcingLoggedDate(threeToFourShift, badTimeOutsideShift);
            List<LogDTO> retrievedDtos = logDTODao.QueryByFunctionalLocations(new RootFlocSet(existingFloc), new DateRange(null, null), null);

            Assert.That(retrievedDtos, Has.None.Property("Id").EqualTo(log.Id));
        }

        [Ignore] [Test]
        public void ShouldNotGetDeletedLogsWhenGettingLogsByFLOC()
        {          
            var flocs = new List<FunctionalLocation>(1) {existingFloc};
            RootFlocSet flocSet = new RootFlocSet(flocs);

            Log logToInsert = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp();
            logToInsert.FunctionalLocations = new List<FunctionalLocation> { existingFloc };
            logToInsert.LastModifiedDate = DateTimeFixture.DateTimeNow;
            logToInsert.LastModifiedBy = UserFixture.CreateOperatorMickeyInFortMcMurrySite(); //randomly choosing ID
            Log logReturnedFromInsert = logDao.Insert(logToInsert);

            List<LogDTO> dtos = logDTODao.QueryByFunctionalLocations(flocSet, new DateRange(null, null), null);

            LogDTO logDto = dtos.Find(dto => dto.Id == logReturnedFromInsert.Id);
            Assert.IsNotNull(logDto);

            logDao.Remove(logReturnedFromInsert);

            dtos = logDTODao.QueryByFunctionalLocations(flocSet, new DateRange(null, null), null);
            logDto = dtos.Find(dto => dto.Id == logReturnedFromInsert.Id);
            Assert.IsNull(logDto);           
        }

        [Ignore] [Test]
        public void ShouldQueryForLogReportDTO_PopulateFields()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF() };

            ShiftPattern dayShift = ShiftPatternFixture.CreateDayShift();
            UserShift dayUserShift = new UserShift(dayShift, new Date(2005, 11, 17));

            Log expected = logDao.Insert(CreateLog(dayShift, flocs, dayUserShift.StartDateTime.AddMinutes(5), "some comments"));

            List<LogReportDTO> logDTOList = logDTODao.QueryForLogReportDTO(new RootFlocSet(flocs), dayUserShift, false);
            LogReportDTO actual = logDTOList.Find(obj => obj.Id == expected.Id);
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.PlainTextComments, actual.PlainTextComments);
            Assert.AreEqual(expected.CreatedShiftPattern.Id, actual.ShiftId);
            Assert.AreEqual(expected.CreatedShiftPattern.Name, actual.ShiftName);
            Assert.AreEqual(new UserShift(expected.CreatedShiftPattern, expected.LogDateTime).StartDateTime, actual.ShiftStartDateTime);
            Assert.AreEqual("SR1-OFFS-BDOF", actual.FunctionalLocationFullHierarchy);
            Assert.AreEqual("BUILDINGS MAINTENANCE OVERHEAD", actual.FunctionalLocationDescription);
            Assert.AreEqual("SR1-OFFS-BDOF", actual.FunctionalLocationUnitLevel);
            Assert.AreEqual("Simpson, Bartholomew [oltuser2]", actual.LastModifiedByUser);
        }

        [Ignore] [Test]
        public void ShouldQueryForLogReportDTO_VaryDateAndShift()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF() };

            ShiftPattern dayShift = ShiftPatternFixture.CreateDayShift();
            UserShift dayUserShift = new UserShift(dayShift, new Date(2005, 11, 17));
            ShiftPattern nightShift = ShiftPatternFixture.CreateNightShift();
            UserShift nightUserShift = new UserShift(nightShift, new Date(2005, 11, 17));

            Log log1 = logDao.Insert(CreateLog(dayShift, flocs, dayUserShift.StartDateTimeWithPadding.AddMinutes(5), "some comments"));
            Log log2 = logDao.Insert(CreateLog(dayShift, flocs, dayUserShift.StartDateTime, "some comments"));
            Log log3 = logDao.Insert(CreateLog(dayShift, flocs, dayUserShift.StartDateTime.AddMinutes(5), "some comments"));
            Log log4 = logDao.Insert(CreateLog(dayShift, flocs, dayUserShift.EndDateTime.AddMinutes(-5), "some comments"));
            Log log5 = logDao.Insert(CreateLog(dayShift, flocs, dayUserShift.EndDateTime, "some comments"));
            Log log6 = logDao.Insert(CreateLog(dayShift, flocs, dayUserShift.EndDateTimeWithPadding.AddMinutes(-5), "some comments"));

            Log log7 = logDao.Insert(CreateLog(nightShift, flocs, nightUserShift.StartDateTimeWithPadding.AddMinutes(5), "some comments"));
            Log log8 = logDao.Insert(CreateLog(nightShift, flocs, nightUserShift.StartDateTime, "some comments"));
            Log log9 = logDao.Insert(CreateLog(nightShift, flocs, nightUserShift.StartDateTime.AddMinutes(5), "some comments"));
            Log log10 = logDao.Insert(CreateLog(nightShift, flocs, nightUserShift.EndDateTime.AddMinutes(-5), "some comments"));
            Log log11 = logDao.Insert(CreateLog(nightShift, flocs, nightUserShift.EndDateTime, "some comments"));
            Log log12 = logDao.Insert(CreateLog(nightShift, flocs, nightUserShift.EndDateTimeWithPadding.AddMinutes(-5), "some comments"));

            {
                List<LogReportDTO> logDTOList = logDTODao.QueryForLogReportDTO(new RootFlocSet(flocs), dayUserShift, false);
                Assert.IsTrue(logDTOList.Exists(dto => dto.IdValue == log1.IdValue));
                Assert.IsTrue(logDTOList.Exists(dto => dto.IdValue == log2.IdValue));
                Assert.IsTrue(logDTOList.Exists(dto => dto.IdValue == log3.IdValue));
                Assert.IsTrue(logDTOList.Exists(dto => dto.IdValue == log4.IdValue));
                Assert.IsTrue(logDTOList.Exists(dto => dto.IdValue == log5.IdValue));
                Assert.IsTrue(logDTOList.Exists(dto => dto.IdValue == log6.IdValue));
                Assert.IsFalse(logDTOList.Exists(dto => dto.IdValue == log7.IdValue));
                Assert.IsFalse(logDTOList.Exists(dto => dto.IdValue == log8.IdValue));
                Assert.IsFalse(logDTOList.Exists(dto => dto.IdValue == log9.IdValue));
                Assert.IsFalse(logDTOList.Exists(dto => dto.IdValue == log10.IdValue));
                Assert.IsFalse(logDTOList.Exists(dto => dto.IdValue == log11.IdValue));
                Assert.IsFalse(logDTOList.Exists(dto => dto.IdValue == log12.IdValue));
            }
            {
                List<LogReportDTO> logDTOList = logDTODao.QueryForLogReportDTO(new RootFlocSet(flocs), nightUserShift, false);
                Assert.IsFalse(logDTOList.Exists(dto => dto.IdValue == log1.IdValue));
                Assert.IsFalse(logDTOList.Exists(dto => dto.IdValue == log2.IdValue));
                Assert.IsFalse(logDTOList.Exists(dto => dto.IdValue == log3.IdValue));
                Assert.IsFalse(logDTOList.Exists(dto => dto.IdValue == log4.IdValue));
                Assert.IsFalse(logDTOList.Exists(dto => dto.IdValue == log5.IdValue));
                Assert.IsFalse(logDTOList.Exists(dto => dto.IdValue == log6.IdValue));
                Assert.IsTrue(logDTOList.Exists(dto => dto.IdValue == log7.IdValue));
                Assert.IsTrue(logDTOList.Exists(dto => dto.IdValue == log8.IdValue));
                Assert.IsTrue(logDTOList.Exists(dto => dto.IdValue == log9.IdValue));
                Assert.IsTrue(logDTOList.Exists(dto => dto.IdValue == log10.IdValue));
                Assert.IsTrue(logDTOList.Exists(dto => dto.IdValue == log11.IdValue));
                Assert.IsTrue(logDTOList.Exists(dto => dto.IdValue == log12.IdValue));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryForLogReportDTO_VaryOperatingEngineerLogFlag()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF() };

            ShiftPattern dayShift = ShiftPatternFixture.CreateDayShift();
            UserShift dayUserShift = new UserShift(dayShift, new Date(2005, 11, 17));

            Log log1 = CreateLog(dayShift, flocs, dayUserShift.StartDateTime.AddMinutes(5), "some comments");
            log1.IsOperatingEngineerLog = false;
            log1 = logDao.Insert(log1);
            Log log2 = CreateLog(dayShift, flocs, dayUserShift.StartDateTime.AddMinutes(5), "some comments");
            log2.IsOperatingEngineerLog = true;
            log2 = logDao.Insert(log2);

            {
                List<LogReportDTO> logDTOList = logDTODao.QueryForLogReportDTO(new RootFlocSet(flocs), dayUserShift, false);
                Assert.IsTrue(logDTOList.Exists(dto => dto.IdValue == log1.IdValue));
                Assert.IsTrue(logDTOList.Exists(dto => dto.IdValue == log2.IdValue));
            }
            {
                List<LogReportDTO> logDTOList = logDTODao.QueryForLogReportDTO(new RootFlocSet(flocs), dayUserShift, true);
                Assert.IsFalse(logDTOList.Exists(dto => dto.IdValue == log1.IdValue));
                Assert.IsTrue(logDTOList.Exists(dto => dto.IdValue == log2.IdValue));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryForLogReportDTO_VaryFloc()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_PLT3();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            FunctionalLocation floc3 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SCH();
            FunctionalLocation floc4 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SCH_33CR001();
            FunctionalLocation floc5 = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();

            ShiftPattern dayShift = ShiftPatternFixture.CreateDayShift();
            UserShift dayUserShift = new UserShift(dayShift, new Date(2005, 11, 17));
            DateTime loggedDateTime = dayUserShift.StartDateTime.AddHours(1);

            Log log1 = logDao.Insert(CreateLog(dayShift, new List<FunctionalLocation> { floc1, floc5 }, loggedDateTime, "log1"));
            Log log2 = logDao.Insert(CreateLog(dayShift, new List<FunctionalLocation> { floc2, floc5 }, loggedDateTime, "log2"));
            Log log3 = logDao.Insert(CreateLog(dayShift, new List<FunctionalLocation> { floc3, floc5 }, loggedDateTime, "log3"));
            Log log4 = logDao.Insert(CreateLog(dayShift, new List<FunctionalLocation> { floc4, floc5 }, loggedDateTime, "log4"));

            List<FunctionalLocation> queryFlocs = new List<FunctionalLocation> { floc1, floc2, floc3, floc4 };
            {
                List<LogReportDTO> reportDtos = logDTODao.QueryForLogReportDTO(new RootFlocSet(queryFlocs), dayUserShift, false);
                Assert.IsTrue(reportDtos.Exists(reportDto => reportDto.Id == log1.Id)); 
                Assert.IsTrue(reportDtos.Exists(reportDto => reportDto.Id == log2.Id));
                Assert.IsTrue(reportDtos.Exists(reportDto => reportDto.Id == log3.Id));
                Assert.IsTrue(reportDtos.Exists(reportDto => reportDto.Id == log4.Id));
            }

            queryFlocs = new List<FunctionalLocation> { floc2 };
            {
                List<LogReportDTO> reportDtos = logDTODao.QueryForLogReportDTO(new RootFlocSet(queryFlocs), dayUserShift, false);
                Assert.IsFalse(reportDtos.Exists(reportDto => reportDto.Id == log1.Id));
                Assert.IsTrue(reportDtos.Exists(reportDto => reportDto.Id == log2.Id));
                Assert.IsTrue(reportDtos.Exists(reportDto => reportDto.Id == log3.Id));
                Assert.IsTrue(reportDtos.Exists(reportDto => reportDto.Id == log4.Id));
            }

            queryFlocs = new List<FunctionalLocation> { floc5 };
            {
                List<LogReportDTO> reportDtos = logDTODao.QueryForLogReportDTO(new RootFlocSet(queryFlocs), dayUserShift, false);
                Assert.IsTrue(reportDtos.Exists(reportDto => reportDto.Id == log1.Id));
                Assert.IsTrue(reportDtos.Exists(reportDto => reportDto.Id == log2.Id));
                Assert.IsTrue(reportDtos.Exists(reportDto => reportDto.Id == log3.Id));
                Assert.IsTrue(reportDtos.Exists(reportDto => reportDto.Id == log4.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryForLogReportDTO_ReturnOneLogReportDTOPerFloc()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_PLT3();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            FunctionalLocation floc3 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SCH();
            FunctionalLocation floc4 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SCH_33CR001();
            FunctionalLocation floc5 = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();

            ShiftPattern dayShift = ShiftPatternFixture.CreateDayShift();
            UserShift dayUserShift = new UserShift(dayShift, new Date(2005, 11, 17));
            DateTime loggedDateTime = dayUserShift.StartDateTime.AddHours(1);

            logDao.Insert(CreateLog(dayShift, new List<FunctionalLocation> { floc3, floc5 }, loggedDateTime, "some comment"));
            const int numberOfFlocsInLog = 2;

            List<FunctionalLocation> queryFlocs = new List<FunctionalLocation> { floc1, floc2, floc3, floc4 };
            {
                List<LogReportDTO> reportDtos = logDTODao.QueryForLogReportDTO(new RootFlocSet(queryFlocs), dayUserShift, false);
                Assert.AreEqual(numberOfFlocsInLog, reportDtos.Count);
                Assert.IsTrue(reportDtos.Exists(reportDto => reportDto.FunctionalLocationFullHierarchy == floc3.FullHierarchy));
                Assert.IsTrue(reportDtos.Exists(reportDto => reportDto.FunctionalLocationFullHierarchy == floc5.FullHierarchy));
            }
        }

        [Ignore] [Test]
        public void QueryByFunctionalLocationsShouldReturnResultsGivenACertainRange()
        {
            DateTime rightNow = GetRightNowFromTheShiftStartSoThatWeAreAlwaysInAShift();
            DateTime sevenDaysAgo = rightNow.Subtract(new TimeSpan(7, 0, 0, 0));
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();
            CreateAParentLogAndAChildLogAndStickThemInTheDB(floc, sevenDaysAgo, rightNow);
            var flocList = new List<FunctionalLocation>(1) {floc};
            RootFlocSet flocSet = new RootFlocSet(flocList);

            List<LogDTO> resultsSevenDaysAgoToNow = logDTODao.QueryByFunctionalLocations(flocSet, new DateRange(sevenDaysAgo.ToDate(), rightNow.ToDate()), null);
            foreach (LogDTO dto in resultsSevenDaysAgoToNow)
            {
                Assert.IsTrue(dto.LogDateTime >= sevenDaysAgo.ToDate().CreateDateTime(new Time(0)));
                Assert.IsTrue(dto.LogDateTime < rightNow.ToDate().CreateDateTime(new Time(0)).AddDays(1));
            }

            DateTime threeDaysAgo = rightNow.Subtract(new TimeSpan(3, 0, 0, 0));
            List<LogDTO> resultsSevenDaysAgoToThreeDaysAgo = logDTODao.QueryByFunctionalLocations(flocSet, new DateRange(sevenDaysAgo.ToDate(), threeDaysAgo.ToDate()), null);
            foreach (LogDTO dto in resultsSevenDaysAgoToThreeDaysAgo)
            {
                Assert.IsTrue(dto.LogDateTime >= sevenDaysAgo.ToDate().CreateDateTime(new Time(0)));
                Assert.IsTrue(dto.LogDateTime < threeDaysAgo.ToDate().CreateDateTime(new Time(0)).AddDays(1));
            }

            Assert.IsTrue(resultsSevenDaysAgoToNow.Count > resultsSevenDaysAgoToThreeDaysAgo.Count);
        }

        [Ignore] [Test]
        public void QueryByFunctionalLocationsShouldTreatANullEndRangeLikeAWildCard()
        {
            DateTime rightNow = GetRightNowFromTheShiftStartSoThatWeAreAlwaysInAShift();
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();
            var flocList = new List<FunctionalLocation>(1) {floc};
            DateTime threeDaysAgo = rightNow.Subtract(new TimeSpan(3, 0, 0, 0));
            List<LogDTO> resultOfQuery = logDTODao.QueryByFunctionalLocations(new RootFlocSet(flocList), new DateRange(threeDaysAgo.ToDate(), null), null);
            foreach (LogDTO dto in resultOfQuery)
            {
                Assert.IsTrue(dto.LogDateTime >= threeDaysAgo.ToDate().CreateDateTime(new Time(0)));
            }   
        }

        [Ignore] [Test]
        public void QueryByFunctionalLocationsShouldTreatANullStartRangeLikeAWildCard()
        {
            DateTime rightNow = GetRightNowFromTheShiftStartSoThatWeAreAlwaysInAShift();
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();
            var flocList = new List<FunctionalLocation>(1) {floc};
            DateTime threeDaysAgo = rightNow.Subtract(new TimeSpan(3, 0, 0, 0));
            List<LogDTO> resultOfQuery = logDTODao.QueryByFunctionalLocations(new RootFlocSet(flocList), new DateRange(null, threeDaysAgo.ToDate()), null);
            foreach (LogDTO dto in resultOfQuery)
            {
                Assert.IsTrue(dto.LogDateTime < threeDaysAgo.ToDate().CreateDateTime(new Time(0)).AddDays(1));
            }      
        }

        [Ignore] [Test]
        public void QueryByFunctionalLocationsShouldReturnLogsWithAtLeastOneFlocThatIsAChildOfOrEqualToTheGivenFlocs()
        {
            DateTime rightNow = GetRightNowFromTheShiftStartSoThatWeAreAlwaysInAShift();
            DateTime sevenDaysAgo = rightNow.Subtract(new TimeSpan(7, 0, 0, 0));

            FunctionalLocation plt3 = FunctionalLocationFixture.GetReal_SR1_PLT3();
            FunctionalLocation plt3Gen3 = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();
            FunctionalLocation plt3Hydu = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            FunctionalLocation plt3HyduSch33Cr001 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SCH_33CR001();
            FunctionalLocation offsBdof = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            FunctionalLocation offs = FunctionalLocationFixture.GetReal_SR1_OFFS();

            Log log1 = LogFixture.CreateLogItem(sevenDaysAgo, sevenDaysAgo);
            log1.FunctionalLocations = new List<FunctionalLocation> { plt3Gen3, offsBdof };
            log1.WorkAssignment = null;
            logDao.Insert(log1);

            Log log2 = LogFixture.CreateLogItem(sevenDaysAgo, sevenDaysAgo);
            log2.FunctionalLocations = new List<FunctionalLocation> { plt3 };
            log2.WorkAssignment = null;
            logDao.Insert(log2);

            Log log3 = LogFixture.CreateLogItem(sevenDaysAgo, sevenDaysAgo);
            log3.FunctionalLocations = new List<FunctionalLocation> { offs };
            log3.WorkAssignment = null;
            logDao.Insert(log3);

            Log log4 = LogFixture.CreateLogItem(sevenDaysAgo, sevenDaysAgo);
            log4.FunctionalLocations = new List<FunctionalLocation> { offs, plt3HyduSch33Cr001 };
            log4.WorkAssignment = null;
            logDao.Insert(log4);

            // users should see logs having a floc that is a child of (or equal to) one of the flocs they are logged in under
            List<FunctionalLocation> usersFlocs = new List<FunctionalLocation> { plt3, plt3Gen3, plt3Hydu };
            {
                List<LogDTO> resultOfQuery = logDTODao.QueryByFunctionalLocations(new RootFlocSet(usersFlocs), new DateRange(sevenDaysAgo.ToDate(), rightNow.ToDate()), null);
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log1.Id));
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log2.Id));
                Assert.IsFalse(resultOfQuery.Exists(logDto => logDto.Id == log3.Id));
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log4.Id));
            }
            {
                List<LogDTO> resultOfQuery = logDTODao.QueryByFunctionalLocations(new RootFlocSet(usersFlocs), sevenDaysAgo, rightNow, null, null);
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log1.Id));
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log2.Id));
                Assert.IsFalse(resultOfQuery.Exists(logDto => logDto.Id == log3.Id));
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log4.Id));                                                     
            }

            usersFlocs = new List<FunctionalLocation> { offsBdof };
            {
                List<LogDTO> resultOfQuery = logDTODao.QueryByFunctionalLocations(new RootFlocSet(usersFlocs), new DateRange(sevenDaysAgo.ToDate(), rightNow.ToDate()), null);
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log1.Id));
                Assert.IsFalse(resultOfQuery.Exists(logDto => logDto.Id == log2.Id));
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log3.Id));
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log4.Id));
            }
            {
                List<LogDTO> resultOfQuery = logDTODao.QueryByFunctionalLocations(new RootFlocSet(usersFlocs), sevenDaysAgo, rightNow, null, null);
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log1.Id));
                Assert.IsFalse(resultOfQuery.Exists(logDto => logDto.Id == log2.Id));
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log3.Id));
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log4.Id));
            }
        }

        [Ignore] [Test]
        public void ConvertChildrenWithoutParentsToParentsAndFlagShouldSetUnavailableParentFlagAppropriately()
        {
            var list = new List<LogDTO>();
            const long rootlogId = 45678;
            LogDTO parent = LogDTOFixture.CreateLogDTOWithUnavailableParent(rootlogId);
            LogDTO reply = LogDTOFixture.CreateReplyTo(parent);
            list.Add(reply);
            list.Add(parent);
            LogDTODao.ConvertChildrenWithoutParentsToParentsAndFlag(list);
            Assert.IsNull(list[0].RootLogId);
            Assert.AreEqual(list[0].Id, list[1].ReplyToLogId);
            Assert.AreEqual(list[0].Id, list[1].RootLogId);
        }
       
        [Ignore] [Test]
        public void ShouldQueryLogsByLoggedDateAsWellAsCreatedDateTime()
        {
            // By FLOC too           
            Log log1 = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp(
                ShiftPatternFixture.CreateDayShift(), new DateTime(2010, 4, 15, 15, 0, 0));
            log1.CreatedDateTime = new DateTime(2010, 3, 15, 15, 0, 0);
            Log log1ReturnedFromInsert = logDao.Insert(log1);

            Log log2 = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp(
                ShiftPatternFixture.CreateDayShift(), new DateTime(2010, 6, 15, 15, 0, 0));
            log2.CreatedDateTime = new DateTime(2010, 5, 15, 15, 0, 0);
            Log log2ReturnedFromInsert = logDao.Insert(log2);

            List<FunctionalLocation> flocList = log1.FunctionalLocations;

            UserShift userShift1a = new UserShift(log1.CreatedShiftPattern, new Date(2010, 3, 15)); 
            {
                List<LogDTO> resultList = logDTODao.GetLogsWhereLoggedDateOrActualLoggedDateMatchRange(new RootFlocSet(flocList), userShift1a, null);

                Assert.IsNotEmpty(resultList);
                Assert.IsTrue(resultList.Exists(dto => dto.Id == log1ReturnedFromInsert.Id));
                Assert.IsFalse(resultList.Exists(dto => dto.Id == log2ReturnedFromInsert.Id));

            }

            UserShift userShift1b = new UserShift(log1.CreatedShiftPattern, new Date(2010, 4, 15));
            {
                List<LogDTO> resultList = logDTODao.GetLogsWhereLoggedDateOrActualLoggedDateMatchRange(new RootFlocSet(flocList), userShift1b, null);

                Assert.IsNotEmpty(resultList);
                Assert.IsTrue(resultList.Exists(dto => dto.Id == log1ReturnedFromInsert.Id));
                Assert.IsFalse(resultList.Exists(dto => dto.Id == log2ReturnedFromInsert.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldReturnLogsWithAtLeastOneFlocThatIsAChildOfProvidedFlocs()
        {
            DateTime createdDateTime = new DateTime(2010, 3, 15, 15, 0, 0);
            DateTime loggedDateTime = new DateTime(2010, 4, 15, 15, 0, 0);
            
            Log log1 = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp(
                ShiftPatternFixture.CreateDayShift(), loggedDateTime);
            log1.CreatedDateTime = createdDateTime;
            log1.FunctionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF(), FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3() };
            Log log1ReturnedFromInsert = logDao.Insert(log1);

            Log log2 = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp(
                ShiftPatternFixture.CreateDayShift(), loggedDateTime);
            log2.CreatedDateTime = createdDateTime;
            log2.FunctionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3() };
            Log log2ReturnedFromInsert = logDao.Insert(log2);

            UserShift userShift = new UserShift(log1.CreatedShiftPattern, new Date(2010, 3, 15));

            List<FunctionalLocation> flocList = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS(), FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF(), FunctionalLocationFixture.GetReal_SR1_OFFS_TKFM() };
            {
                List<LogDTO> resultList = logDTODao.GetLogsWhereLoggedDateOrActualLoggedDateMatchRange(new RootFlocSet(flocList), userShift, null);

                Assert.IsTrue(resultList.Exists(dto => dto.Id == log1ReturnedFromInsert.Id));
                Assert.IsFalse(resultList.Exists(dto => dto.Id == log2ReturnedFromInsert.Id));
            }

            flocList = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_PLT3(), FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3(), FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3() };
            {
                List<LogDTO> resultList = logDTODao.GetLogsWhereLoggedDateOrActualLoggedDateMatchRange(new RootFlocSet(flocList), userShift, null);

                Assert.IsTrue(resultList.Exists(dto => dto.Id == log1ReturnedFromInsert.Id));
                Assert.IsTrue(resultList.Exists(dto => dto.Id == log2ReturnedFromInsert.Id));
            }

            flocList = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_TKFM() };
            {
                List<LogDTO> resultList = logDTODao.GetLogsWhereLoggedDateOrActualLoggedDateMatchRange(new RootFlocSet(flocList), userShift, null);

                Assert.IsFalse(resultList.Exists(dto => dto.Id == log1ReturnedFromInsert.Id));
                Assert.IsFalse(resultList.Exists(dto => dto.Id == log2ReturnedFromInsert.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByFunctionalLocationAndAssignment()
        {
            Log log = CreateLogWithValidShiftAndLogTime();
            log.WorkAssignment = WorkAssignmentFixture.CreateConsoleOperator();
            log = logDao.Insert(log);

            {
                List<LogDTO> results = logDTODao.QueryByFunctionalLocations(
                    new RootFlocSet(log.FunctionalLocations),
                    log.LogDateTime.AddHours(-1), log.LogDateTime.AddHours(+1),
                    WorkAssignmentFixture.CreateConsoleOperator(), null);
                Assert.IsTrue(results.Exists(obj => obj.Id == log.Id));
            }
            {
                List<LogDTO> results = logDTODao.QueryByFunctionalLocations(
                    new RootFlocSet(log.FunctionalLocations),
                    log.LogDateTime.AddHours(-1), log.LogDateTime.AddHours(+1),
                    WorkAssignmentFixture.CreateShiftEngineer(), null);
                Assert.IsFalse(results.Exists(obj => obj.Id == log.Id));
            }
            {
                List<LogDTO> results = logDTODao.QueryByFunctionalLocations(
                    new RootFlocSet(log.FunctionalLocations),
                    log.LogDateTime.AddHours(-1), log.LogDateTime.AddHours(+1),
                    null, null);
                Assert.IsFalse(results.Exists(obj => obj.Id == log.Id));
            }

            log.WorkAssignment = null;
            logDao.Update(log);

            {
                List<LogDTO> results = logDTODao.QueryByFunctionalLocations(
                    new RootFlocSet(log.FunctionalLocations),
                    log.LogDateTime.AddHours(-1), log.LogDateTime.AddHours(+1),
                    WorkAssignmentFixture.CreateConsoleOperator(), null);
                Assert.IsFalse(results.Exists(obj => obj.Id == log.Id));
            }
            {
                List<LogDTO> results = logDTODao.QueryByFunctionalLocations(
                    new RootFlocSet(log.FunctionalLocations),
                    log.LogDateTime.AddHours(-1), log.LogDateTime.AddHours(+1),
                    WorkAssignmentFixture.CreateShiftEngineer(), null);
                Assert.IsFalse(results.Exists(obj => obj.Id == log.Id));
            }
            {
                List<LogDTO> results = logDTODao.QueryByFunctionalLocations(
                    new RootFlocSet(log.FunctionalLocations),
                    log.LogDateTime.AddHours(-1), log.LogDateTime.AddHours(+1),
                    null, null);
                Assert.IsTrue(results.Exists(obj => obj.Id == log.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryOperatingEngineerLogs()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();

            Log log1 = CreateLogWithValidShiftAndLogTime();
            log1.FunctionalLocations = new List<FunctionalLocation> { floc };
            log1.IsOperatingEngineerLog = true;
            logDao.Insert(log1);

            Log log2 = CreateLogWithValidShiftAndLogTime();
            log2.FunctionalLocations = new List<FunctionalLocation> { floc };
            log2.IsOperatingEngineerLog = false;
            logDao.Insert(log2);

            List<LogDTO> results = logDTODao.QueryOpEngineerLogsByFunctionalLocation(
                new RootFlocSet(new List<FunctionalLocation> { floc }), log1.LogDateTime.AddHours(-1), null);
            Assert.IsTrue(results.Exists(obj => obj.Id == log1.Id));
            Assert.IsFalse(results.Exists(obj => obj.Id == log2.Id));
        }

        [Ignore] [Test]
        public void QueryOperatingEngineerShouldReturnLogsWithAtLeastOneFlocThatIsAChildOfOrEqualToTheGivenFlocs()
        {
            DateTime rightNow = GetRightNowFromTheShiftStartSoThatWeAreAlwaysInAShift();
            DateTime sevenDaysAgo = rightNow.Subtract(new TimeSpan(7, 0, 0, 0));

            FunctionalLocation plt3 = FunctionalLocationFixture.GetReal_SR1_PLT3();
            FunctionalLocation plt3Gen3 = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();
            FunctionalLocation plt3Hydu = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            FunctionalLocation plt3HyduSch33Cr001 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SCH_33CR001();
            FunctionalLocation offsBdof = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            FunctionalLocation offs = FunctionalLocationFixture.GetReal_SR1_OFFS();

            Log log1 = LogFixture.CreateLogItem(sevenDaysAgo, sevenDaysAgo);
            log1.IsOperatingEngineerLog = true;
            log1.FunctionalLocations = new List<FunctionalLocation> { plt3Gen3, offsBdof };
            log1.WorkAssignment = null;
            logDao.Insert(log1);

            Log log2 = LogFixture.CreateLogItem(sevenDaysAgo, sevenDaysAgo);
            log2.IsOperatingEngineerLog = true;
            log2.FunctionalLocations = new List<FunctionalLocation> { plt3 };
            log2.WorkAssignment = null;
            logDao.Insert(log2);

            Log log3 = LogFixture.CreateLogItem(sevenDaysAgo, sevenDaysAgo);
            log3.IsOperatingEngineerLog = true;
            log3.FunctionalLocations = new List<FunctionalLocation> { offs };
            log3.WorkAssignment = null;
            logDao.Insert(log3);

            Log log4 = LogFixture.CreateLogItem(sevenDaysAgo, sevenDaysAgo);
            log4.IsOperatingEngineerLog = true;
            log4.FunctionalLocations = new List<FunctionalLocation> { offs, plt3HyduSch33Cr001 };
            log4.WorkAssignment = null;
            logDao.Insert(log4);

            // users should see logs having a floc that is a child of (or equal to) one of the flocs they are logged in under
            List<FunctionalLocation> usersFlocs = new List<FunctionalLocation> { plt3, plt3Gen3, plt3Hydu };
            RootFlocSet rootFlocSet = new RootFlocSet(usersFlocs);
            {
                List<LogDTO> resultOfQuery = logDTODao.QueryOpEngLogsByFunctionalLocations(rootFlocSet, sevenDaysAgo, rightNow, null);
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log1.Id));
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log2.Id));
                Assert.IsFalse(resultOfQuery.Exists(logDto => logDto.Id == log3.Id));
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log4.Id));
            }
            {
                List<LogDTO> resultOfQuery = logDTODao.QueryOpEngineerLogsByFunctionalLocation(rootFlocSet, sevenDaysAgo, null);
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log1.Id));
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log2.Id));
                Assert.IsFalse(resultOfQuery.Exists(logDto => logDto.Id == log3.Id));
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log4.Id));
            }

            // users logged into a third level floc should not see logs logged at a parent floc
            usersFlocs = new List<FunctionalLocation> { offsBdof };
            rootFlocSet = new RootFlocSet(usersFlocs);
            {
                List<LogDTO> resultOfQuery = logDTODao.QueryOpEngLogsByFunctionalLocations(rootFlocSet, sevenDaysAgo, rightNow, null);
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log1.Id));
                Assert.IsFalse(resultOfQuery.Exists(logDto => logDto.Id == log2.Id));
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log3.Id));
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log4.Id));
            }
            {
                List<LogDTO> resultOfQuery = logDTODao.QueryOpEngineerLogsByFunctionalLocation(rootFlocSet, sevenDaysAgo, null);
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log1.Id));
                Assert.IsFalse(resultOfQuery.Exists(logDto => logDto.Id == log2.Id));
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log3.Id));
                Assert.IsTrue(resultOfQuery.Exists(logDto => logDto.Id == log4.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryOperatingEngineerLogsAtSecondLevel()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS();

            Log log1 = CreateLogWithValidShiftAndLogTime();
            log1.FunctionalLocations = new List<FunctionalLocation> { floc };
            log1.IsOperatingEngineerLog = true;
            logDao.Insert(log1);

            Log log2 = CreateLogWithValidShiftAndLogTime();
            log2.FunctionalLocations = new List<FunctionalLocation> { floc };
            log2.IsOperatingEngineerLog = false;
            logDao.Insert(log2);

            List<LogDTO> results = logDTODao.QueryOpEngineerLogsByFunctionalLocation(
                new RootFlocSet(floc), log1.LogDateTime.AddHours(-1), null);
            Assert.IsTrue(results.Exists(obj => obj.Id == log1.Id));
            Assert.IsFalse(results.Exists(obj => obj.Id == log2.Id));
        }

        [Ignore] [Test]
        public void ShouldQueryLogWithComments()
        {
            Log log = CreateLogWithValidShiftAndLogTime();
            log.RtfComments = "This is a log comment";
            log.PlainTextComments = "This is a log comment in plain text";
         
            log = logDao.Insert(log);

            Date loggedDate = log.LogDateTime.ToDate();
            DateRange range = new DateRange(loggedDate.SubtractDays(1), loggedDate.AddDays(1));
            List<LogDTO> resultOfQuery = logDTODao.QueryByFunctionalLocations(
                new RootFlocSet(log.FunctionalLocations),
                range,
                null);
            
            LogDTO result = resultOfQuery.Find(obj => obj.Id == log.Id);
            Log resultLog = logDao.QueryById(result.IdValue);
            
            Assert.IsNotNull(resultLog);
            Assert.AreEqual("This is a log comment", resultLog.RtfComments);
            Assert.AreEqual("This is a log comment in plain text", resultLog.PlainTextComments);

            Assert.AreEqual("This is a log comment in plain text", result.Comments);            
        }

        [Ignore] [Test]
        public void VariousQueries_VaryVisibilityGroups()
        {
            IVisibilityGroupDao visibilityGroupDao = DaoRegistry.GetDao<IVisibilityGroupDao>();
            IWorkAssignmentVisibilityGroupDao workAssignmentVisibilityGroupDao = DaoRegistry.GetDao<IWorkAssignmentVisibilityGroupDao>();

            VisibilityGroup chapsVisibilityGroup = new VisibilityGroup(-1, "Chaps Department", Site.SARNIA_ID, true);
            VisibilityGroup horseshoeVisibilityGroup = new VisibilityGroup(-1, "Horseshoe Department", Site.SARNIA_ID, false);

            visibilityGroupDao.Insert(chapsVisibilityGroup);
            visibilityGroupDao.Insert(horseshoeVisibilityGroup);

            WorkAssignment horseAssignment = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Horse Supervisor"));
            WorkAssignment clothingAssignment = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Cowboy Clothing Supervisor"));

            // horse supervisor can read info about chaps and horseshoes, but can only write about horseshoes
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup1 = new WorkAssignmentVisibilityGroup(null, horseAssignment.IdValue, chapsVisibilityGroup.IdValue, "Chaps", VisibilityType.Read);
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup2 = new WorkAssignmentVisibilityGroup(null, horseAssignment.IdValue, horseshoeVisibilityGroup.IdValue, "Horseshoe", VisibilityType.Write);
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup3 = new WorkAssignmentVisibilityGroup(null, horseAssignment.IdValue, horseshoeVisibilityGroup.IdValue, "Horseshoe", VisibilityType.Read);

            // cowboy clothing supervisor can read info about chaps and horseshoes, but can only write about chaps
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup4 = new WorkAssignmentVisibilityGroup(null, clothingAssignment.IdValue, chapsVisibilityGroup.IdValue, "Chaps", VisibilityType.Read);
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup5 = new WorkAssignmentVisibilityGroup(null, clothingAssignment.IdValue, chapsVisibilityGroup.IdValue, "Chaps", VisibilityType.Write);
            WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup6 = new WorkAssignmentVisibilityGroup(null, clothingAssignment.IdValue, horseshoeVisibilityGroup.IdValue, "Horseshoe", VisibilityType.Read);

            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup1);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup2);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup3);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup4);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup5);
            workAssignmentVisibilityGroupDao.Insert(workAssignmentVisibilityGroup6);

            DateTime loggedDateTime = new DateTime(2012, 4, 15, 15, 0, 0);

            Log log1 = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp(ShiftPatternFixture.CreateDayShift(), loggedDateTime);
            log1.WorkAssignment = horseAssignment;
            log1.FunctionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF(), FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3() };
            log1.IsOperatingEngineerLog = true;
            logDao.Insert(log1);

            Log log2 = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp(ShiftPatternFixture.CreateDayShift(), loggedDateTime);
            log2.WorkAssignment = clothingAssignment;
            log2.FunctionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3() };
            log2.IsOperatingEngineerLog = true;
            logDao.Insert(log2);

            Log log3 = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp(ShiftPatternFixture.CreateDayShift(), loggedDateTime);
            log3.WorkAssignment = null;
            log3.FunctionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3() };
            log3.IsOperatingEngineerLog = true;
            logDao.Insert(log3);

            UserShift userShift = new UserShift(log1.CreatedShiftPattern, loggedDateTime);

            DateRange queryDateRange = new DateRange(new Date(2012, 4, 15), new Date(2012, 4, 15));
            RootFlocSet queryFlocSet = new RootFlocSet(FunctionalLocationFixture.GetReal_SR1());

            // case: I can read about chaps so I want to see all logs that were made with an assignment that has a chaps write group (and ones with no assignment)
            {
                List<long> visibilityGroupIds = new List<long> { chapsVisibilityGroup.IdValue };

                List<LogDTO> results1 = logDTODao.QueryByFunctionalLocations(queryFlocSet, queryDateRange, visibilityGroupIds);                
                Assert.AreEqual(2, results1.Count);
                Assert.IsTrue(results1.Exists(dto => dto.Id == log2.Id));
                Assert.IsTrue(results1.Exists(dto => dto.Id == log3.Id));

                List<LogDTO> results2 = logDTODao.QueryOpEngineerLogsByFunctionalLocation(queryFlocSet, queryDateRange.SqlFriendlyStart, visibilityGroupIds);
                Assert.AreEqual(2, results2.Count);
                Assert.IsTrue(results2.Exists(dto => dto.Id == log2.Id));
                Assert.IsTrue(results2.Exists(dto => dto.Id == log3.Id));

                List<LogDTO> results3 = logDTODao.QueryByFunctionalLocations(queryFlocSet, queryDateRange.SqlFriendlyStart, queryDateRange.SqlFriendlyEnd, horseAssignment, visibilityGroupIds);
                Assert.AreEqual(0, results3.Count);

                List<LogDTO> results5 = logDTODao.GetLogsWhereLoggedDateOrActualLoggedDateMatchRange(queryFlocSet, userShift, visibilityGroupIds);
                Assert.AreEqual(2, results5.Count);
                Assert.IsTrue(results5.Exists(dto => dto.Id == log2.Id));
                Assert.IsTrue(results5.Exists(dto => dto.Id == log3.Id));
            }

            // case: I can read about horseshoes so I want to see all logs that were made with an assignment that has a horseshoe write group (and ones with no assignment)
            {
                List<long> visibilityGroupIds = new List<long> { horseshoeVisibilityGroup.IdValue };
                List<LogDTO> results = logDTODao.QueryByFunctionalLocations(queryFlocSet, queryDateRange, visibilityGroupIds);

                Assert.AreEqual(2, results.Count);
                Assert.IsTrue(results.Exists(dto => dto.Id == log1.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == log3.Id));

                List<LogDTO> results2 = logDTODao.QueryOpEngineerLogsByFunctionalLocation(queryFlocSet, queryDateRange.SqlFriendlyStart, visibilityGroupIds);
                Assert.AreEqual(2, results2.Count);
                Assert.IsTrue(results2.Exists(dto => dto.Id == log1.Id));
                Assert.IsTrue(results2.Exists(dto => dto.Id == log3.Id));

                List<LogDTO> results3 = logDTODao.QueryByFunctionalLocations(queryFlocSet, queryDateRange.SqlFriendlyStart, queryDateRange.SqlFriendlyEnd, clothingAssignment, visibilityGroupIds);
                Assert.AreEqual(0, results3.Count);

                List<LogDTO> results5 = logDTODao.GetLogsWhereLoggedDateOrActualLoggedDateMatchRange(queryFlocSet, userShift, visibilityGroupIds);
                Assert.AreEqual(2, results5.Count);
                Assert.IsTrue(results5.Exists(dto => dto.Id == log1.Id));
                Assert.IsTrue(results5.Exists(dto => dto.Id == log3.Id));
            }

            // case: I can read about both horseshoes and chaps so I want to see all logs that were made with an assignment that has at least one of those write groups (and ones with no assignment)
            {
                List<long> visibilityGroupIds = new List<long> { horseshoeVisibilityGroup.IdValue, chapsVisibilityGroup.IdValue };
                List<LogDTO> results = logDTODao.QueryByFunctionalLocations(queryFlocSet, queryDateRange, visibilityGroupIds);

                Assert.AreEqual(3, results.Count);
                Assert.IsTrue(results.Exists(dto => dto.Id == log1.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == log2.Id));
                Assert.IsTrue(results.Exists(dto => dto.Id == log3.Id));

                List<LogDTO> results2 = logDTODao.QueryOpEngineerLogsByFunctionalLocation(queryFlocSet, queryDateRange.SqlFriendlyStart, visibilityGroupIds);
                Assert.AreEqual(3, results2.Count);
                Assert.IsTrue(results2.Exists(dto => dto.Id == log1.Id));
                Assert.IsTrue(results2.Exists(dto => dto.Id == log2.Id));
                Assert.IsTrue(results2.Exists(dto => dto.Id == log3.Id));

                List<LogDTO> results3 = logDTODao.QueryByFunctionalLocations(queryFlocSet, queryDateRange.SqlFriendlyStart, queryDateRange.SqlFriendlyEnd, horseAssignment, visibilityGroupIds);
                Assert.AreEqual(1, results3.Count);
                Assert.IsTrue(results3.Exists(dto => dto.Id == log1.Id));

                List<LogDTO> results5 = logDTODao.GetLogsWhereLoggedDateOrActualLoggedDateMatchRange(queryFlocSet, userShift, visibilityGroupIds);
                Assert.AreEqual(3, results5.Count);
                Assert.IsTrue(results5.Exists(dto => dto.Id == log1.Id));
                Assert.IsTrue(results5.Exists(dto => dto.Id == log2.Id));
                Assert.IsTrue(results5.Exists(dto => dto.Id == log3.Id));
            }
        }

        [Ignore] [Test]  
        public void ShouldQueryByMarkedAsRead()
        {
            ShiftPattern shiftPattern = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shiftPattern.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc };

            long id1 = logDao.Insert(AddComments(CreateLog(LogType.Standard, now, shiftPattern, flocs), "c1")).IdValue;
            long id3 = logDao.Insert(AddComments(CreateLog(LogType.DailyDirective, now, shiftPattern, flocs), "c5")).IdValue;

            User user1 = userDao.Insert(UserFixture.CreateUser("user1", "first1", "last1"));
            User user2 = userDao.Insert(UserFixture.CreateUser("user2", "first2", "last2"));
            User user3 = userDao.Insert(UserFixture.CreateUser("user3", "first3", "last3"));

            logReadDao.Insert(new LogRead(id1, user1.IdValue, DateTimeFixture.DateTimeNow));
            logReadDao.Insert(new LogRead(id3, user2.IdValue, DateTimeFixture.DateTimeNow));
            logReadDao.Insert(new LogRead(id3, user3.IdValue, DateTimeFixture.DateTimeNow));

            {
                List<MarkedAsReadReportLogDTO> results = logDTODao.QueryDTOByParentFlocListAndMarkedAsRead(
                    now.SubtractDays(1), now.AddDays(1), new List<FunctionalLocation> { floc });
                Assert.AreEqual(2, results.Count);
                {
                    MarkedAsReadReportLogDTO dto = results.Find(obj => obj.Comments.Equals("c1"));
                    Assert.IsNotNull(dto);
                    Assert.AreEqual(1, dto.ReadByUsers.Count);
                    Assert.IsTrue(dto.ReadByUsers.Exists(obj => obj.UserFullNameWithUserName == "last1, first1 [user1]"));                                        
                    Assert.AreEqual(MarkedAsReadReportLogDTO.STANDARD_LOG_TYPE_TEXT, dto.LogType);
                }
                {
                    MarkedAsReadReportLogDTO dto = results.Find(obj => obj.Comments.Equals("c5"));
                    Assert.IsNotNull(dto);
                    Assert.AreEqual(2, dto.ReadByUsers.Count);
                    Assert.IsTrue(dto.ReadByUsers.Exists(obj => obj.UserFullNameWithUserName == "last2, first2 [user2]"));
                    Assert.IsTrue(dto.ReadByUsers.Exists(obj => obj.UserFullNameWithUserName == "last3, first3 [user3]"));                                      
                    Assert.AreEqual(MarkedAsReadReportLogDTO.DAILY_DIRECTIVE_LOG_TYPE_TEXT, dto.LogType);
                }
            }
        }

        [Ignore] [Test]        
        public void QueryByMarkedAsReadShouldGetLogsWithAtLeastOneFlocThatEqualsOrIsAChildOfTheGivenFlocs()
        {
            ShiftPattern shiftPattern = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shiftPattern.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            FunctionalLocation sr1Offs = FunctionalLocationFixture.GetReal_SR1_OFFS();
            FunctionalLocation sr1OffsBdof = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            FunctionalLocation sr1Plt3 = FunctionalLocationFixture.GetReal_SR1_PLT3();
            FunctionalLocation sr1Plt3Gen3 = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();

            long id1 = logDao.Insert(AddComments(CreateLog(LogType.Standard, now, shiftPattern, new List<FunctionalLocation> { sr1OffsBdof, sr1Plt3 }), "c1")).IdValue;
            long id2 = logDao.Insert(AddComments(CreateLog(LogType.Standard, now, shiftPattern, new List<FunctionalLocation> { sr1Offs, sr1Plt3 }), "c2")).IdValue;

            User user1 = userDao.Insert(UserFixture.CreateUser("user1", "first1", "last1"));
            User user2 = userDao.Insert(UserFixture.CreateUser("user2", "first2", "last2"));

            logReadDao.Insert(new LogRead(id1, user1.IdValue, DateTimeFixture.DateTimeNow));
            logReadDao.Insert(new LogRead(id2, user2.IdValue, DateTimeFixture.DateTimeNow));

            {
                List<MarkedAsReadReportLogDTO> results = logDTODao.QueryDTOByParentFlocListAndMarkedAsRead(
                    now.SubtractDays(1), now.AddDays(1), new List<FunctionalLocation> { sr1Offs });
                
                Assert.AreEqual(2, results.Count);
                {
                    MarkedAsReadReportLogDTO logDto1 = results.Find(obj => obj.Comments.Equals("c1"));
                    Assert.IsNotNull(logDto1);

                    MarkedAsReadReportLogDTO logDto2 = results.Find(obj => obj.Comments.Equals("c2"));
                    Assert.IsNotNull(logDto2);
                }


                results = logDTODao.QueryDTOByParentFlocListAndMarkedAsRead(
                    now.SubtractDays(1), now.AddDays(1), new List<FunctionalLocation> { sr1Plt3Gen3 });
                Assert.AreEqual(0, results.Count);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryLogReportDTOWithMultipleComments() // CCTODO. Delete this test? Probably can still test both kinds of comments here
        {
            ShiftPattern shiftPattern = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shiftPattern.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));
            UserShift userShift = new UserShift(shiftPattern, now);

            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { floc };

            logDao.Insert(AddComments(CreateLog(LogType.Standard, now, shiftPattern, flocs), "c1"));
            logDao.Insert(AddComments(CreateLog(LogType.Standard, now, shiftPattern, flocs), "c3"));
            logDao.Insert(AddComments(CreateLog(LogType.DailyDirective, now, shiftPattern, flocs), "c5"));
            logDao.Insert(AddComments(CreateLog(LogType.DailyDirective, now, shiftPattern, flocs), "c7"));

            {
                List<LogReportDTO> results = logDTODao.QueryForLogReportDTO(new RootFlocSet(flocs), userShift, false);
                Assert.AreEqual(2, results.Count);
                {
                    LogReportDTO dto = results.Find(obj => obj.PlainTextComments.Equals("c1"));
                    Assert.IsNotNull(dto);
                    Assert.IsTrue(dto.PlainTextComments.Contains("c1"));
                }
                {
                    LogReportDTO dto = results.Find(obj => obj.PlainTextComments.Equals("c3"));
                    Assert.IsNotNull(dto);
                    Assert.IsTrue(dto.PlainTextComments.Contains("c3"));
                }
            }
        }

        [Ignore] [Test]
        public void ShouldQueryLogReportDTOWithMultipleCommentsAndMultipleFlocs()
        {
            ShiftPattern shiftPattern = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shiftPattern.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));
            UserShift userShift = new UserShift(shiftPattern, now);

            FunctionalLocation flocbase = FunctionalLocationFixture.GetReal_SR1_PLT3();
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();

            logDao.Insert(AddComments(CreateLog(LogType.Standard, now, shiftPattern, new List<FunctionalLocation> { floc1, floc2 }), "c1"));
            logDao.Insert(AddComments(CreateLog(LogType.Standard, now, shiftPattern, new List<FunctionalLocation> { floc2 }), "c3"));

            {
                List<LogReportDTO> results = logDTODao.QueryForLogReportDTO(
                    new RootFlocSet(new List<FunctionalLocation> { flocbase, floc1, floc2 }), userShift, false);
                Assert.AreEqual(3, results.Count);
                {
                    List<LogReportDTO> dtos = results.FindAll(obj => obj.PlainTextComments.Contains("c1"));
                    Assert.AreEqual(2, dtos.Count);

                    for (int i = 0; i < 2; i++)
                    {
                        Assert.IsTrue(dtos[i].PlainTextComments.Contains("c1"));
                    }

                    Assert.AreEqual(1, dtos.FindAll(dto => dto.FunctionalLocationFullHierarchy == floc1.FullHierarchy).Count);
                    Assert.AreEqual(1, dtos.FindAll(dto => dto.FunctionalLocationFullHierarchy == floc2.FullHierarchy).Count);
                }
                {
                    List<LogReportDTO> dtos = results.FindAll(obj => obj.PlainTextComments.Contains("c3"));
                    Assert.AreEqual(1, dtos.Count);

                    Assert.IsTrue(dtos[0].PlainTextComments.Contains("c3"));
                }
            }            
        }
        [Ignore]
        [Test]
        public void ShouldReturnDtosForLogsAssociatedWithGivenWorkPermitEdmonton()
        {
            User user1 = UserFixture.CreateUser("username1", "first1", "last1");
            userDao.Insert(user1);

            IWorkPermitEdmontonDao workPermitEdmontonDao = DaoRegistry.GetDao<IWorkPermitEdmontonDao>();
            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());
            workPermitEdmontonDao.Insert(permit, null);

            Log log = CreateLogWithValidShiftAndLogTime(user1);
            Log insertedLog = logDao.Insert(log, permit);

            // I'm slipping in this little test of the count method rather than writing a new one
            {
                int count = logDao.QueryCountOfLogsAssociatedToWorkPermitEdmonton(permit.IdValue);
                Assert.AreEqual(1, count);
            }

            {
                List<LogDTO> logDtos = logDTODao.QueryByWorkPermitEdmonton(permit.IdValue);

                Assert.AreEqual(1, logDtos.Count);
                Assert.AreEqual(insertedLog.IdValue, logDtos[0].IdValue);
            }
        }

        [Ignore] [Test]
        public void ShouldReturnDtosForLogsAssociatedWithGivenWorkPermitLubes()
        {
            User user = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();

            IWorkPermitLubesDao workPermitLubesDao = DaoRegistry.GetDao<IWorkPermitLubesDao>();
            IWorkPermitLubesGroupDao workPermitLubesGroupDao = DaoRegistry.GetDao<IWorkPermitLubesGroupDao>();

            WorkPermitLubesGroup group = workPermitLubesGroupDao.QueryAll()[0];

            WorkPermitLubes permit = WorkPermitLubesFixture.CreateForInsert(group);
            workPermitLubesDao.Insert(permit, null);

            Log log = CreateLogWithValidShiftAndLogTime(user);
            Log insertedLog = logDao.Insert(log, permit);

            // I'm slipping in this little test of the count method rather than writing a new one
            {
                int count = logDao.QueryCountOfLogsAssociatedToWorkPermitLubes(permit.IdValue);
                Assert.AreEqual(1, count);
            }

            {
                List<LogDTO> logDtos = logDTODao.QueryByWorkPermitLubes(permit.IdValue);

                Assert.AreEqual(1, logDtos.Count);
                Assert.AreEqual(insertedLog.IdValue, logDtos[0].IdValue);
            }
        }

        [Ignore] [Test]
        public void ShouldReturnDtosForLogsAssociatedWithGivenTargetAlert()
        {
            User user1 = UserFixture.CreateUser("username1", "first1", "last1");
            userDao.Insert(user1);

            ITargetAlertDao targetAlertDao = DaoRegistry.GetDao<ITargetAlertDao>();
            TargetAlert targetAlert = TargetAlertFixture.CreateATargetAlert();
            targetAlertDao.Insert(targetAlert);

            Log log = CreateLogWithValidShiftAndLogTime(user1);
            Log insertedLog = logDao.Insert(log, targetAlert);

            // I'm slipping in this little test of the count method rather than writing a new one
            {
                int count = logDao.QueryCountOfLogsAssociatedToTargetAlert(targetAlert.IdValue);
                Assert.AreEqual(1, count);
            }

            {
                List<LogDTO> logDtos = logDTODao.QueryByTargetAlert(targetAlert.IdValue);

                Assert.AreEqual(1, logDtos.Count);
                Assert.AreEqual(insertedLog.IdValue, logDtos[0].IdValue);
            }
        }

        [Ignore] [Test]
        public void ShouldReturnDtosForLogsAssociatedWithGivenActionItem()
        {
            User user1 = UserFixture.CreateUser("username1", "first1", "last1");
            userDao.Insert(user1);
            User user2 = UserFixture.CreateUser("username2", "first2", "last2");
            userDao.Insert(user2);

            IActionItemDao actionItemDao = DaoRegistry.GetDao<IActionItemDao>();
            ActionItem actionItem = ActionItemFixture.Create(Priority.Elevated);
            actionItemDao.Insert(actionItem);

            Log log = CreateLogWithValidShiftAndLogTime(user1);
            log.LastModifiedBy = user2;
            Log insertedLog = logDao.Insert(log, actionItem);

            List<LogDTO> logDtos = logDTODao.QueryByActionItem(actionItem.IdValue);

            Assert.AreEqual(1, logDtos.Count);
            Assert.AreEqual(insertedLog.Id, logDtos[0].Id);
            Assert.AreEqual("last1, first1 [username1]", logDtos[0].CreatedByFullnameWithUserName);
            Assert.AreEqual("last2, first2 [username2]", logDtos[0].LastModifiedFullNameWithUserName);
        }

        [Ignore] [Test]
        public void ShouldReturnDtosForLogsAssociatedWithGivenActionItemDefinition()
        {
            User user1 = UserFixture.CreateUser("username1", "first1", "last1");
            userDao.Insert(user1);
            User user2 = UserFixture.CreateUser("username2", "first2", "last2");
            userDao.Insert(user2);

            IActionItemDefinitionDao actionItemDefinitionDao = DaoRegistry.GetDao<IActionItemDefinitionDao>();
            ActionItemDefinition actionItemDefinition = ActionItemDefinitionFixture.CreateActionItemDefinition();
            actionItemDefinitionDao.Insert(actionItemDefinition);

            Log log = CreateLogWithValidShiftAndLogTime(user1);
            log.LastModifiedBy = user2;
            Log insertedLog = logDao.Insert(log, actionItemDefinition);

            List<LogDTO> logDtos = logDTODao.QueryByActionItemDefinition(actionItemDefinition.IdValue);

            Assert.AreEqual(1, logDtos.Count);
            Assert.AreEqual(insertedLog.Id, logDtos[0].Id);
            Assert.AreEqual("last1, first1 [username1]", logDtos[0].CreatedByFullnameWithUserName);
            Assert.AreEqual("last2, first2 [username2]", logDtos[0].LastModifiedFullNameWithUserName);
        }

        [Ignore] [Test]
        public void ShouldLoadFlocNames()
        {
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3();
            FunctionalLocation floc3 = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();

            ShiftPattern shiftPattern = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime loggedDateTime = shiftPattern.StartTime.Add(00, 01, 00).ToDateTime(new Date(2005, 12, 1));

            Log log1 = logDao.Insert(CreateLog(shiftPattern, new List<FunctionalLocation> { floc2, floc3 }, loggedDateTime, "some comments"));
            Log log2 = logDao.Insert(CreateLog(shiftPattern, new List<FunctionalLocation> { floc2 }, loggedDateTime, "some comments"));

            List<LogDTO> logDtos = logDTODao.QueryById(new List<long> { log1.IdValue, log2.IdValue });

            LogDTO log1Dto = logDtos.Find(dto => dto.Id == log1.Id);
            Assert.AreEqual("SR1-PLT3-BDP3, SR1-PLT3-GEN3", log1Dto.FunctionalLocationNames);

            LogDTO log2Dto = logDtos.Find(dto => dto.Id == log2.Id);
            Assert.AreEqual("SR1-PLT3-BDP3", log2Dto.FunctionalLocationNames);
        }


        [Ignore] [Test]
        public void ShouldQueryByFlocListDateRangeShiftAndCreateUser_VaryWorkAssignment_TestCustomFieldsAndCustomFieldEntries()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();

            ShiftPattern shift = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            WorkAssignment assignment1 = WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData();
            WorkAssignment assignment2 = WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData();

            long id1;
            {
                Log log = CreateLog(shift, new List<FunctionalLocation> { floc }, now, "Comments", user, assignment1);
                log.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase1().IdValue, "Field Name 1", "Field Entry 1", null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
                log.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase2().IdValue, "Field Name 2", "Field Entry 2", null,null, 2, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
                log.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase3().IdValue, "Field Name 3", "Field Entry 3", null,null, 3, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));

                log.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase1());
                log.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase2());
                log.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase3());

                log = logDao.Insert(log);
                id1 = log.IdValue;
            }

            long id2;
            {
                Log log = CreateLog(shift, new List<FunctionalLocation> { floc }, now, "Comments", user, assignment2);
                log = logDao.Insert(log);
                id2 = log.IdValue;
            }

            // Should Find id1 and not id2
            {
                List<HasCommentsDTO> results = logDTODao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc), shift.IdValue, assignment1.Id, user.IdValue);
                
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                HasCommentsDTO dto = results.Find(obj => obj.Id == id1);
                Assert.IsNotNull(dto);
                Assert.AreEqual(3, dto.CustomFieldEntries.Count);
                Assert.IsTrue(dto.CustomFieldEntries.Exists(
                    e => e.CustomFieldName == "Field Name 1" && e.FieldEntry == "Field Entry 1" && e.DisplayOrder == 1));
                Assert.IsTrue(dto.CustomFieldEntries.Exists(
                    e => e.CustomFieldName == "Field Name 2" && e.FieldEntry == "Field Entry 2" && e.DisplayOrder == 2));
                Assert.IsTrue(dto.CustomFieldEntries.Exists(
                    e => e.CustomFieldName == "Field Name 3" && e.FieldEntry == "Field Entry 3" && e.DisplayOrder == 3));

                Assert.IsTrue(dto.CustomFields.Count >= 3);
                Assert.IsTrue(dto.CustomFields.Exists(e => e.Name == CustomFieldFixture.CustomFieldExistingInDatabase1().Name));
                Assert.IsTrue(dto.CustomFields.Exists(e => e.Name == CustomFieldFixture.CustomFieldExistingInDatabase2().Name));
                Assert.IsTrue(dto.CustomFields.Exists(e => e.Name == CustomFieldFixture.CustomFieldExistingInDatabase3().Name));
            }

            // Should Find id2 and not id1
            {
                List<HasCommentsDTO> results = logDTODao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc), shift.IdValue, assignment2.Id, user.IdValue);
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByFlocListDateRangeShiftAndCreateUser_VaryDateRange()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();

            ShiftPattern shift = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator(1);

            long id1;
            {
                Log log = CreateLog(shift, new List<FunctionalLocation> { floc }, now, "Comments", user, workAssignment);
                log = logDao.Insert(log);
                id1 = log.IdValue;
            }

            {
                List<HasCommentsDTO> results = logDTODao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc), shift.IdValue, workAssignment.Id, user.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
            }
            {
                List<HasCommentsDTO> results = logDTODao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(
                    now.AddSeconds(-1), now.AddSeconds(1), new RootFlocSet(floc), shift.IdValue, workAssignment.Id, user.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
            }
            {
                List<HasCommentsDTO> results = logDTODao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(
                    now.AddSeconds(1), now.AddSeconds(1), new RootFlocSet(floc), shift.IdValue, workAssignment.Id, user.IdValue);
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByFlocListDateRangeShiftAndAssignment_RevertToUserIfAssignmentIsNull()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();

            User user1 = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            User user2 = UserFixture.CreateOperatorOltUser1InFortMcMurrySite();

            ShiftPattern shift = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            WorkAssignment assignment = GetAssignment(floc);

            long id1;
            {
                Log log = CreateLog(shift, new List<FunctionalLocation> { floc }, now, "Comments", user1, assignment);
                log = logDao.Insert(log);
                id1 = log.IdValue;
            }

            long id2;
            {
                Log log = CreateLog(shift, new List<FunctionalLocation> { floc }, now, "Comments", user1, null);
                log = logDao.Insert(log);
                id2 = log.IdValue;
            }

            long id3;
            {
                Log log = CreateLog(shift, new List<FunctionalLocation> { floc }, now, "Comments", user2, assignment);
                log = logDao.Insert(log);
                id3 = log.IdValue;
            }

            long id4;
            {
                Log log = CreateLog(shift, new List<FunctionalLocation> { floc }, now, "Comments", user2, null);
                log = logDao.Insert(log);
                id4 = log.IdValue;
            }

            long id5;
            {
                Log log = CreateLog(shift, new List<FunctionalLocation> { floc }, now, "Comments", user1, null);
                log = logDao.Insert(log);
                id5 = log.IdValue;
            }

            // Should Find id1, id3 because it should match the assignment
            {
                List<HasCommentsDTO> results = logDTODao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc), shift.IdValue, assignment.Id, user1.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsTrue(results.Exists(obj => obj.Id == id3));
                Assert.IsFalse(results.Exists(obj => obj.Id == id4));
                Assert.IsFalse(results.Exists(obj => obj.Id == id5));
            }

            // Should Find Id2, Id5 because it should look for logs with null work assignments that have a matching user.
            {
                List<HasCommentsDTO> results = logDTODao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc), shift.IdValue, null, user1.IdValue);
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
                Assert.IsFalse(results.Exists(obj => obj.Id == id4));
                Assert.IsTrue(results.Exists(obj => obj.Id == id5));
            }
        }

        private WorkAssignment GetAssignment(FunctionalLocation floc)
        {
            WorkAssignment assignment = new WorkAssignment("Diet Coker Bored Man", "WA", "General", floc.Site.IdValue, RoleFixture.GetRealRoleA(floc.Site.IdValue));
            assignment = workAssignmentDao.Insert(assignment);
            return assignment;
        }

        [Ignore] [Test]
        public void ShouldQueryByFlocListDateRangeShiftAndCreateUser_VaryFloc()
        {
            FunctionalLocation floc1 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A"));
            FunctionalLocation floc2 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B"));
            FunctionalLocation floc3 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B-C"));
            FunctionalLocation floc4 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B-C-D"));

            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();

            ShiftPattern shift = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            long id1;
            {
                Log log = CreateLog(shift, new List<FunctionalLocation> { floc1 }, now, "Comments", user, null);
                log = logDao.Insert(log);
                id1 = log.IdValue;
            }
            long id2;
            {
                Log log = CreateLog(shift, new List<FunctionalLocation> { floc2 }, now, "Comments", user, null);
                log = logDao.Insert(log);
                id2 = log.IdValue;
            }
            long id3;
            {
                Log log = CreateLog(shift, new List<FunctionalLocation> { floc3 }, now, "Comments", user, null);
                log = logDao.Insert(log);
                id3 = log.IdValue;
            }
            long id4;
            {
                Log log = CreateLog(shift, new List<FunctionalLocation> { floc4 }, now, "Comments", user, null);
                log = logDao.Insert(log);
                id4 = log.IdValue;
            }

            {
                List<HasCommentsDTO> results = logDTODao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc1), shift.IdValue, null, user.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
            }
            {
                List<HasCommentsDTO> results = logDTODao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(
                    now.AddSeconds(-1), now.AddSeconds(1), new RootFlocSet(floc1), shift.IdValue, null, user.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
            }
            {
                List<HasCommentsDTO> results = logDTODao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(
                    now.AddSeconds(1), now.AddSeconds(1), new RootFlocSet(floc1), shift.IdValue, null, user.IdValue);
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
            }
            {
                List<HasCommentsDTO> results = logDTODao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(new List<FunctionalLocation> { floc1, floc2, floc3, floc4 }), shift.IdValue, null, user.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsTrue(results.Exists(obj => obj.Id == id3));
                Assert.IsTrue(results.Exists(obj => obj.Id == id4));
            }
            {
                List<HasCommentsDTO> results = logDTODao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc1), shift.IdValue, null, user.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsTrue(results.Exists(obj => obj.Id == id3));
                Assert.IsTrue(results.Exists(obj => obj.Id == id4));
            }
            {
                List<HasCommentsDTO> results = logDTODao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc2), shift.IdValue, null, user.IdValue);
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsTrue(results.Exists(obj => obj.Id == id3));
                Assert.IsTrue(results.Exists(obj => obj.Id == id4));
            }
            {
                List<HasCommentsDTO> results = logDTODao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc3), shift.IdValue, null, user.IdValue);
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsTrue(results.Exists(obj => obj.Id == id3));
                Assert.IsTrue(results.Exists(obj => obj.Id == id4));
            }
            {
                List<HasCommentsDTO> results = logDTODao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc4), shift.IdValue, null, user.IdValue);
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
                Assert.IsTrue(results.Exists(obj => obj.Id == id4));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByFlocListDateRangeShiftAndCreateUser_VaryFloc_LogHasMultipleFlocs()
        {
            FunctionalLocation floc1 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A"));
            FunctionalLocation floc2 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B"));

            FunctionalLocation floc5 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("W"));
            FunctionalLocation floc6 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("W-X"));
            FunctionalLocation floc7 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("W-X-Y"));
            FunctionalLocation floc8 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("W-X-Y-Z"));

            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();

            ShiftPattern shift = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            long id1;
            {
                Log log = CreateLog(shift, new List<FunctionalLocation> { floc1, floc7 }, now, "Comments", user, null);
                log = logDao.Insert(log);
                id1 = log.IdValue;
            }
            long id2;
            {
                Log log = CreateLog(shift, new List<FunctionalLocation> { floc2, floc8 }, now, "Comments", user, null);
                log = logDao.Insert(log);
                id2 = log.IdValue;
            }
            long id3;
            {
                Log log = CreateLog(shift, new List<FunctionalLocation> { floc1, floc5 }, now, "Comments", user, null);
                log = logDao.Insert(log);
                id3 = log.IdValue;
            }

            {
                List<HasCommentsDTO> results = logDTODao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc1), shift.IdValue, null, user.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsTrue(results.Exists(obj => obj.Id == id3));
            }
            {
                List<HasCommentsDTO> results = logDTODao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc5), shift.IdValue, null, user.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsTrue(results.Exists(obj => obj.Id == id3));
            }
            {
                List<HasCommentsDTO> results = logDTODao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(new List<FunctionalLocation> { floc1, floc6 }), shift.IdValue, null, user.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsTrue(results.Exists(obj => obj.Id == id3));
            }
            {
                List<HasCommentsDTO> results = logDTODao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(new List<FunctionalLocation> { floc2, floc6 }), shift.IdValue, null, user.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
            }
        }

        [Ignore] [Test]
        public void ShouldPopulateCreatedByRoleOnLogDTO()
        {
            Log logToInsert = LogFixture.CreateLogItemWithSpecificRole(roleInDB);
            Log insertedLog = logDao.Insert(logToInsert);
            List<LogDTO> results = logDTODao.QueryById(new List<long> { insertedLog.IdValue });
            LogDTO logDto = results.Find(obj => obj.Id == insertedLog.Id);
            Assert.AreEqual(roleInDB.IdValue, logDto.CreatedByRoleId);
        }

        [Ignore] [Test]
        public void QueryingDtosShouldIncludeMarkedAsReadInformation()
        {
            FunctionalLocation floc1 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B-C"));
            FunctionalLocation floc2 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("X-Y-Z"));

            User user = userDao.Insert(UserFixture.CreateUser("user", "first", "last"));
            User user1 = userDao.Insert(UserFixture.CreateUser("user1", "first1", "last1"));
            User user2 = userDao.Insert(UserFixture.CreateUser("user3", "first3", "last3"));

            ShiftPattern shift = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            Log log1 = logDao.Insert(CreateLog(shift, new List<FunctionalLocation> { floc1, floc2 }, now, "Comments", user, null));
            Log log2 = logDao.Insert(CreateLog(shift, new List<FunctionalLocation> { floc1, floc2 }, now, "Comments", user, null));
            Log log3 = logDao.Insert(CreateLog(shift, new List<FunctionalLocation> { floc1 }, now, "Comments", user, null));

            logReadDao.Insert(new LogRead(log1, user1, now));
            logReadDao.Insert(new LogRead(log2, user2, now));
            logReadDao.Insert(new LogRead(log3, user2, now));


            DateRange dateRange = new DateRange(new Date(2005, 01, 01), null);
            IFlocSet flocSet = new RootFlocSet(floc1);

            {
                List<LogDTO> results = logDTODao.QueryByRootFLOCsWithMatchingFLOCAncestorsAndDescendants(LogType.Standard, dateRange.SqlFriendlyStart, dateRange.SqlFriendlyEnd, flocSet, user1, null);
                Assert.AreEqual(3, results.Count);
                List<LogDTO> logsReadByUser1 = results.FindAll(dto => dto.IsReadByCurrentUser == true);
                Assert.AreEqual(1, logsReadByUser1.Count);
                Assert.AreEqual(2, results.FindAll(dto => dto.IsReadByCurrentUser == false).Count);
                Assert.AreEqual(log1.IdValue, logsReadByUser1[0].IdValue);
            }

            {
                List<LogDTO> results = logDTODao.QueryByRootFLOCsWithMatchingFLOCAncestorsAndDescendants(LogType.Standard, dateRange.SqlFriendlyStart, dateRange.SqlFriendlyEnd, flocSet, user2, null);
                Assert.AreEqual(3, results.Count);
                List<LogDTO> logsReadByUser2 = results.FindAll(dto => dto.IsReadByCurrentUser == true);
                Assert.AreEqual(2, logsReadByUser2.Count);
                Assert.AreEqual(1, results.FindAll(dto => dto.IsReadByCurrentUser == false).Count);
                Assert.IsTrue(logsReadByUser2.Exists(dto => dto.IdValue == log2.IdValue));
                Assert.IsTrue(logsReadByUser2.Exists(dto => dto.IdValue == log3.IdValue));
            }

            {
                List<LogDTO> results = logDTODao.QueryByRootFLOCsWithMatchingFLOCAncestorsAndDescendants(LogType.Standard, dateRange.SqlFriendlyStart, dateRange.SqlFriendlyEnd, flocSet, null, null);
                Assert.AreEqual(3, results.Count);
                List<LogDTO> logsWithNoReadByInfo = results.FindAll(dto => dto.IsReadByCurrentUser == null);
                Assert.AreEqual(3, logsWithNoReadByInfo.Count);
            }
        }

        private static Log CreateLog(ShiftPattern shiftPattern, List<FunctionalLocation> flocs, DateTime loggedDateTime,
                      string comments, User createdByUser, WorkAssignment workAssignment)
        {
            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            return new Log(null,
                           null,
                           null,
                           DataSource.MANUAL,
                           flocs,
                           false, false, false, false, false, false,                           
                           comments,
                           comments,
                           loggedDateTime,                         
                           shiftPattern,
                           createdByUser,
                           user,
                           loggedDateTime,
                           loggedDateTime,
                           false,
                           false,
                           RoleFixture.GetRealRoleA(Site.OILSAND_ID),
                           LogType.Standard,
                           workAssignment);
        }

        private static Log AddComments(Log log, string comments)
        {
            log.RtfComments = comments;
            log.PlainTextComments = comments;

            return log;
        }

        private static Log CreateLog(LogType logType, DateTime loggedDateTime, ShiftPattern shiftPattern, List<FunctionalLocation> flocs)
        {
            Log log = CreateLog(shiftPattern, flocs, loggedDateTime, "", UserFixture.CreateOperatorGoofyInFortMcMurrySite(), logType);
            return log;
        }

        private static DateTime GetRightNowFromTheShiftStartSoThatWeAreAlwaysInAShift()
        {
            ShiftPattern pattern = ShiftPatternFixture.CreateDayShift();
            Time startTime = pattern.StartTime;
            DateTime startOfShift = DateTimeFixture.DateNow.CreateDateTime(startTime);
            return startOfShift.Add(new TimeSpan(0, 2, 0));
        }

        private void CreateAParentLogAndAChildLogAndStickThemInTheDB(FunctionalLocation floc, DateTime parentLoggedDate, DateTime childLoggedDate)
        {
            Log parentLog = LogFixture.CreateLogItem(parentLoggedDate, parentLoggedDate);
            parentLog.RtfComments = "Parent Log";
            parentLog.PlainTextComments = parentLog.RtfComments;
            parentLog.FunctionalLocations = new List<FunctionalLocation> { floc };
            logDao.Insert(parentLog);
            Log childLog = LogFixture.CreateLogItem(childLoggedDate, childLoggedDate);
            childLog.RtfComments = "Child Log";
            childLog.PlainTextComments = childLog.RtfComments;
            childLog.FunctionalLocations = new List<FunctionalLocation> { floc };
            logDao.Insert(childLog);
        }
        private static Log CreateLog(ShiftPattern shiftPattern, List<FunctionalLocation> flocs, DateTime loggedDateTime,
                                    string comments)
        {
            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();

            return CreateLog(shiftPattern, flocs, loggedDateTime, comments, user, LogType.Standard);
        }

        private static Log CreateLog(ShiftPattern shiftPattern, List<FunctionalLocation> flocs, DateTime loggedDateTime,
                                     string comments, User createdByUser, LogType logType)
        {
            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            return new Log(null,
                           null,
                           null,
                           DataSource.MANUAL,
                           flocs,
                           false, false, false, false, false, false,                           
                           comments,
                           comments,
                           loggedDateTime,
                           shiftPattern,
                           createdByUser,
                           user,
                           loggedDateTime,
                           loggedDateTime,
                           false,
                           false,
                           RoleFixture.GetRealRoleA(Site.OILSAND_ID),
                           logType,
                           null);
        }

        private Log UpdateLogForcingLoggedDate(ShiftPattern shiftPattern, DateTime desiredLoggedDate)
        {
            DateTime goodTimeWithinShift = shiftPattern.StartTime.ToDateTime(new Date(2006, 7, 11));
            Log log = CreateLog(shiftPattern, new List<FunctionalLocation> { existingFloc }, goodTimeWithinShift, "don't care");
            log = logDao.Insert(log);
            // Since we can't insert a log with a bad logged date, we "force" it by manually updating:
            TestDataAccessUtil.ExecuteExpression("UPDATE Log SET LogDateTime = CAST('{0}' AS DATETIME) WHERE Id = {1}",
                                                 desiredLoggedDate.ToString("yyyy/MM/dd HH:mm:ss"), log.Id);
            return log;
        }

        private Log CreateLogWithValidShiftAndLogTime()
        {
            return CreateLogWithValidShiftAndLogTime(UserFixture.CreateOperatorGoofyInFortMcMurrySite());
        }

        private Log CreateLogWithValidShiftAndLogTime(User createUser)
        {
            ShiftPattern shiftPattern = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime loggedDateTime = shiftPattern.StartTime.Add(00, 01, 00).ToDateTime(new Date(2005, 12, 1));
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI() };
            Log log = CreateLog(shiftPattern, flocs, loggedDateTime, "nothing, no group", createUser, LogType.Standard);
            return log;
        }

    }
}
