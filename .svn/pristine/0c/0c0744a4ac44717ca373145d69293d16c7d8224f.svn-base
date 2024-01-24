using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class SummaryLogServiceClientTest
    {
        private IFunctionalLocationService flocService;
        private Role role;
        private ISummaryLogService service;
        private IShiftPatternService shiftPatternService;

        [SetUp]
        public void SetUp()
        {
            service = GenericServiceRegistry.Instance.GetService<ISummaryLogService>();
            flocService = GenericServiceRegistry.Instance.GetService<IFunctionalLocationService>();
            shiftPatternService = GenericServiceRegistry.Instance.GetService<IShiftPatternService>();

            var roleService = GenericServiceRegistry.Instance.GetService<IRoleService>();
            role = roleService.QueryRolesBySite(SiteFixture.Sarnia())[0];
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test][Ignore]
        public void ShouldGetShiftSummaryLogDTOs()
        {
            var floc = flocService.QueryByFullHierarchy("DN1-3003-0000", Site.DENVER_ID);
            var now = DateTimeFixture.DateTimeNow.TruncateToDay().AddHours(9);

            var shiftPattern = shiftPatternService.GetShiftBySiteAndDateTime(SiteFixture.Denver(), now);

            var log1 = SummaryLogFixture.CreateSummaryLog(now.SubtractDays(10), shiftPattern, role);
            log1.FunctionalLocations = new List<FunctionalLocation> {floc};
            log1 = (SummaryLog) service.Insert(log1)[0].DomainObject;

            var log2 = SummaryLogFixture.CreateSummaryLog(now.SubtractDays(5), shiftPattern, role);
            log2.FunctionalLocations = new List<FunctionalLocation> {floc};
            log2 = (SummaryLog) service.Insert(log2)[0].DomainObject;

            var flocList =
                new List<FunctionalLocation> {flocService.QueryByFullHierarchy("DN1", Site.DENVER_ID)};

            {
                var results = service.QuerySummaryLogDTOsByParentFloc(new RootFlocSet(flocList), null);
                Assert.IsFalse(results.Exists(obj => obj.Id == log1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == log2.Id));
            }
            {
                var results = service.QueryShiftSummaryDTOsByParentFlocAndDateRange(
                    new RootFlocSet(flocList),
                    new Range<Date>(new Date(now.SubtractDays(20)), new Date(now.AddDays(20))), null);
                Assert.IsTrue(results.Exists(obj => obj.Id == log1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == log2.Id));
            }
            {
                var results = service.QueryShiftSummaryDTOsByParentFlocAndDateRange(
                    new RootFlocSet(flocList),
                    new Range<Date>(new Date(now.SubtractDays(20)), new Date(now.SubtractDays(20))), null);
                Assert.IsFalse(results.Exists(obj => obj.Id == log1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == log2.Id));
            }
            {
                var results = service.QueryShiftSummaryDTOsByParentFlocAndDateRange(
                    new RootFlocSet(flocList),
                    new Range<Date>(new Date(now.SubtractDays(5)), new Date(now.SubtractDays(5))), null);
                Assert.IsFalse(results.Exists(obj => obj.Id == log1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == log2.Id));
            }
            {
                var results = service.QueryShiftSummaryDTOsByParentFlocAndDateRange(
                    new RootFlocSet(flocList),
                    new Range<Date>(new Date(now.SubtractDays(6)), new Date(now.SubtractDays(5))), null);
                Assert.IsFalse(results.Exists(obj => obj.Id == log1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == log2.Id));
            }
            {
                var results = service.QueryShiftSummaryDTOsByParentFlocAndDateRange(
                    new RootFlocSet(flocList),
                    new Range<Date>(new Date(now.SubtractDays(5)), new Date(now.SubtractDays(4))), null);
                Assert.IsFalse(results.Exists(obj => obj.Id == log1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == log2.Id));
            }
        }

        [Test][Ignore]
        public void ShouldInsertAndQuerySummaryLogById()
        {
            var floc = flocService.QueryByFullHierarchy("SR1-OFFS", Site.SARNIA_ID);

            var now = DateTimeFixture.DateTimeNow.TruncateToDay().AddHours(9);
            var shiftPattern = shiftPatternService.GetShiftBySiteAndDateTime(SiteFixture.Sarnia(), now);
            var log = SummaryLogFixture.CreateSummaryLog(now.SubtractDays(10), shiftPattern, role);

            log.FunctionalLocations.Clear();
            log.FunctionalLocations.Add(floc);

            var returnedFromInsert = (SummaryLog) service.Insert(log)[0].DomainObject;

            var queried = service.QueryById(returnedFromInsert.IdValue);
            Assert.IsNotNull(queried);
        }

        [Test][Ignore]
        public void ShouldUpdateParentSummaryLogToHaveChildren()
        {
            var floc = flocService.QueryByFullHierarchy("SR1-OFFS", Site.SARNIA_ID);

            var now = DateTimeFixture.DateTimeNow;
            var shiftPattern = shiftPatternService.GetShiftBySiteAndDateTime(SiteFixture.Sarnia(), now);
            var parent = SummaryLogFixture.CreateSummaryLog(now, shiftPattern, role);

            parent.FunctionalLocations.Clear();
            parent.FunctionalLocations.Add(floc);

            parent = service.Insert(parent)[0].DomainObject as SummaryLog;
            Assert.That(parent.HasChildren, Is.False);
            Assert.That(parent.IsPartOfThread, Is.False);

            var child = SummaryLogFixture.CreateSummaryLog(now, shiftPattern, role);
            child.SetReplyTo(parent);
            child.FunctionalLocations.Clear();
            child.FunctionalLocations.Add(floc);

            child = service.Insert(child)[0].DomainObject as SummaryLog;
            Assert.That(child.IsPartOfThread, Is.True);

            var summaryLog = service.QueryById(parent.IdValue);
            Assert.That(summaryLog.HasChildren, Is.True);
            Assert.That(summaryLog.HasChildren, Is.True);
        }
    }
}