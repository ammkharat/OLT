using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class ReportingServiceClientTest
    {
        private readonly List<Log> logsToRemoveAfterTest = new List<Log>();
        private IFunctionalLocationService flocService;
        private ILogService logService;
        private IReportingService reportingService;
        private Role roleInDb;
        private IRoleService roleService;

        [SetUp]
        public void SetUp()
        {
            reportingService = GenericServiceRegistry.Instance.GetService<IReportingService>();
            logService = GenericServiceRegistry.Instance.GetService<ILogService>();
            flocService = GenericServiceRegistry.Instance.GetService<IFunctionalLocationService>();
            roleService = GenericServiceRegistry.Instance.GetService<IRoleService>();
            var rolesBySite = roleService.QueryRolesBySite(SiteFixture.Oilsands());
            roleInDb = rolesBySite[0];
        }

        [TearDown]
        public void TearDown()
        {
            foreach (var log in logsToRemoveAfterTest)
            {
                logService.Remove(log);
            }
        }

        [Test][Ignore]
        public void ShouldReturnEngineerLogsWithSecondLevelFlocs()
        {
            var firebag = SiteFixture.Firebag();

            var shiftPattern =
                new ShiftPattern(5, "12DA", new Time(7), new Time(19), new DateTime(2008, 10, 15), firebag,
                    new TimeSpan(0, 30, 0), new TimeSpan(0, 30, 0));

            var userSelectedFlocs =
                flocService.GetUnitLevelAndHigherFunctionalLocationsForSite(firebag.IdValue);

            var sectionLevelFloc = userSelectedFlocs.Find(location => location.IsSection);
            var unitLevelFloc = userSelectedFlocs.Find(location => location.IsUnit);

            var sectionLevelLog = GetOperatingEngineerLogForTest(sectionLevelFloc, shiftPattern);
            logsToRemoveAfterTest.Add((Log) logService.Insert(sectionLevelLog)[0].DomainObject);

            var unitLevelLog = GetOperatingEngineerLogForTest(unitLevelFloc, shiftPattern);
            logsToRemoveAfterTest.Add((Log) logService.Insert(unitLevelLog)[0].DomainObject);

            {
                var userShift = UserShiftFixture.CreateUserShift(shiftPattern, new DateTime(2010, 3, 9, 11, 15, 0));

                var shifts = new List<UserShift> {userShift};

                var logReportDTO =
                    reportingService.GetOperatingEngineerShiftLogReportData(firebag, new RootFlocSet(userSelectedFlocs),
                        shifts, null);

                Assert.AreEqual(2, logReportDTO.Logs.Count);
                Assert.IsNotNull(
                    logReportDTO.Logs.Find(dto => dto.FunctionalLocationFullHierarchy == unitLevelFloc.FullHierarchy));
                Assert.IsNotNull(
                    logReportDTO.Logs.Find(dto => dto.FunctionalLocationFullHierarchy == sectionLevelFloc.FullHierarchy));
            }
        }

        private Log GetOperatingEngineerLogForTest(FunctionalLocation floc, ShiftPattern shiftPattern)
        {
            var firebag = SiteFixture.Firebag();
            var user = UserFixture.CreateSupervisor(1, "dustin", firebag);
            var logDate = new DateTime(2010, 3, 9, 11, 15, 0);

            var log = LogFixture.CreateLog(logDate, new List<FunctionalLocation> {floc}, null, shiftPattern, user,
                roleInDb);
            log.IsOperatingEngineerLog = true;
            log.LastModifiedBy = user;

            log.SetRTFAndPlainTextComments("Test Comment");

            return log;
        }
    }
}