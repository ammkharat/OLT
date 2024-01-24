using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    [Category("Database")]
    public class PermitRequestEdmontonDTODaoTest : AbstractDaoTest
    {
        private IPermitRequestEdmontonDao dao;
        private IPermitRequestEdmontonDTODao dtoDao;
        private IPermitRequestEdmontonDao permitRequestDao;
        private IWorkPermitEdmontonGroupDao groupDao;

        private WorkPermitEdmontonGroup group;
        private FunctionalLocation flocForTesting;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            
        }

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IPermitRequestEdmontonDao>();
            dtoDao = DaoRegistry.GetDao<IPermitRequestEdmontonDTODao>();
            permitRequestDao = DaoRegistry.GetDao<IPermitRequestEdmontonDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitEdmontonGroupDao>();

            flocForTesting = FunctionalLocationFixture.GetReal("MT1-A001-IFST");

            group = groupDao.Insert(WorkPermitEdmontonGroupFixture.CreateForInsert());
        }

        protected override void Cleanup()
        {            
        }

        private PermitRequestEdmonton CreateForInsert()
        {
            return PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, flocForTesting, group);
        }

        [Ignore] [Test]
        public void ShouldReturnDTOsByFlocUnitAndBelow()
        {
            WorkPermitEdmontonGroup group = groupDao.Insert(WorkPermitEdmontonGroupFixture.CreateForInsert());

            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007_SCC();
            FunctionalLocation parentFloc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            PermitRequestEdmonton request = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, floc, group);
            PermitRequestEdmonton insertedRequest = permitRequestDao.Insert(request);

            List<PermitRequestEdmontonDTO> results = dtoDao.QueryByDateRangeAndFlocs(new RootFlocSet(parentFloc), new DateRange(null, null));
           
            Assert.IsNotEmpty(results);

            PermitRequestEdmontonDTO dto = results.Find(thing => thing.IdValue == insertedRequest.IdValue);
            Assert.IsNotNull(dto);
        }

        [Ignore] [Test]
        public void ShouldQueryOnlyThoseRequestsWithPassedInPriorityIds()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A002-U005");
            DateRange range = new DateRange(null, null);
            RootFlocSet flocSet = new RootFlocSet(floc);

            PermitRequestEdmonton request1 = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, floc, group);
            PermitRequestEdmonton request2 = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, floc, group);
            PermitRequestEdmonton request3 = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, floc, group);
            PermitRequestEdmonton request4 = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, floc, group);

            request1.Group = groupDao.Insert(new WorkPermitEdmontonGroup(-1, "A", new List<long> { 5, 6, 7 }, 0, true));
            request2.Group = groupDao.Insert(new WorkPermitEdmontonGroup(-1, "B", new List<long> { 8 }, 0, true));
            request3.Group = groupDao.Insert(new WorkPermitEdmontonGroup(-1, "C", new List<long> { 9 }, 0, true));
            request4.Group = groupDao.Insert(new WorkPermitEdmontonGroup(-1, "D", null, 0, true));

            permitRequestDao.Insert(request1);
            permitRequestDao.Insert(request2);
            permitRequestDao.Insert(request3);
            permitRequestDao.Insert(request4);

            {
                List<PermitRequestEdmontonDTO> result = dtoDao.QueryByDateRangeAndFlocs(flocSet, range, new List<long> { 6, 7, 8 }, false);
                Assert.AreEqual(2, result.Count);
                Assert.IsTrue(result.Exists(dto => dto.Id == request1.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == request2.Id));
            }

            {
                List<PermitRequestEdmontonDTO> result = dtoDao.QueryByDateRangeAndFlocs(flocSet, range, new List<long> { 9 }, false);
                Assert.AreEqual(1, result.Count);
                Assert.IsTrue(result.Exists(dto => dto.Id == request3.Id));
            }

            // if you pass in null for the priority ids list it means "don't do any extra priority/group filtering"
            {
                List<PermitRequestEdmontonDTO> result = dtoDao.QueryByDateRangeAndFlocs(flocSet, range, null, false);
                Assert.AreEqual(4, result.Count);
                Assert.IsTrue(result.Exists(dto => dto.Id == request1.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == request2.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == request3.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == request4.Id));
            }

        }

        [Ignore] [Test]
        public void ShouldQueryOnlyThoseRequestsWithoutThePassedInPriorityIds()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A002-U005");
            DateRange range = new DateRange(null, null);
            RootFlocSet flocSet = new RootFlocSet(floc);

            PermitRequestEdmonton request1 = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, floc, group);
            PermitRequestEdmonton request2 = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, floc, group);
            PermitRequestEdmonton request3 = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, floc, group);
            PermitRequestEdmonton request4 = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, floc, group);

            request1.Group = groupDao.Insert(new WorkPermitEdmontonGroup(-1, "A", new List<long> { 5, 6, 7 }, 0, true));
            request2.Group = groupDao.Insert(new WorkPermitEdmontonGroup(-1, "B", new List<long> { 8 }, 0, true));
            request3.Group = groupDao.Insert(new WorkPermitEdmontonGroup(-1, "C", new List<long> { 9 }, 0, true));
            request4.Group = groupDao.Insert(new WorkPermitEdmontonGroup(-1, "D", null, 0, true));

            permitRequestDao.Insert(request1);
            permitRequestDao.Insert(request2);
            permitRequestDao.Insert(request3);
            permitRequestDao.Insert(request4);

            {
                List<PermitRequestEdmontonDTO> result = dtoDao.QueryByDateRangeAndFlocs(flocSet, range, new List<long> { 5, 6, 7, 8 }, true);
                Assert.AreEqual(2, result.Count);
                Assert.IsTrue(result.Exists(dto => dto.Id == request3.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == request4.Id));
            }

            {
                List<PermitRequestEdmontonDTO> result = dtoDao.QueryByDateRangeAndFlocs(flocSet, range, new List<long> { 9 }, true);
                Assert.AreEqual(3, result.Count);
                Assert.IsTrue(result.Exists(dto => dto.Id == request1.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == request2.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == request4.Id));
            }

            // if you pass in null for the group ids list it means "ignore group"
            {
                List<PermitRequestEdmontonDTO> result = dtoDao.QueryByDateRangeAndFlocs(flocSet, range, null, true);
                Assert.AreEqual(4, result.Count);
                Assert.IsTrue(result.Exists(dto => dto.Id == request1.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == request2.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == request3.Id));
                Assert.IsTrue(result.Exists(dto => dto.Id == request4.Id));
            }

        }

        [Ignore] [Test]
        public void ShouldQueryByCompletenessAndGroupAndDateFallingInRequestedRange_VaryDate()
        {
            WorkPermitEdmontonGroup group1 = groupDao.Insert(new WorkPermitEdmontonGroup(1, "Some Different Group", new List<long> { 123 }, 0, false));

            group1 = groupDao.Insert(group1);

            PermitRequestEdmonton requestOne = CreateForInsert();
            requestOne.RequestedStartDate = new Date(2012, 8, 19);
            requestOne.EndDate = new Date(2012, 8, 22);
            requestOne.Group = group1;
            requestOne.CompletionStatus = PermitRequestCompletionStatus.Complete;
            dao.Insert(requestOne);

            PermitRequestEdmonton requestTwo = CreateForInsert();
            requestTwo.RequestedStartDate = new Date(2012, 8, 21);
            requestTwo.EndDate = new Date(2012, 8, 22);
            requestTwo.CompletionStatus = PermitRequestCompletionStatus.Complete;
            requestTwo.Group = group1;
            dao.Insert(requestTwo);

            {
                List<PermitRequestEdmontonDTO> requests = dtoDao.QueryByCompletenessAndGroupAndDateWithinRange(new List<PermitRequestCompletionStatus> { PermitRequestCompletionStatus.Complete }, group1.IdValue, new Date(2012, 8, 20));
                Assert.AreEqual(1, requests.Count);
                Assert.IsTrue(requests.Exists(req => req.IdValue == requestOne.IdValue));
                Assert.IsFalse(requests.Exists(req => req.IdValue == requestTwo.IdValue));
            }

            {
                List<PermitRequestEdmontonDTO> requests = dtoDao.QueryByCompletenessAndGroupAndDateWithinRange(new List<PermitRequestCompletionStatus> { PermitRequestCompletionStatus.Complete }, group1.IdValue, new Date(2011, 2, 22));
                Assert.AreEqual(0, requests.Count);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByCompletenessAndGroupAndDateFallingInRequestedRange_VaryCompleteness()
        {
            PermitRequestEdmonton requestOne = CreateForInsert();
            requestOne.RequestedStartDate = new Date(2012, 8, 19);
            requestOne.EndDate = new Date(2012, 8, 22);
            requestOne.Group = group;
            requestOne.CompletionStatus = PermitRequestCompletionStatus.Complete;
            dao.Insert(requestOne);

            PermitRequestEdmonton requestTwo = CreateForInsert();
            requestTwo.RequestedStartDate = new Date(2012, 8, 19);
            requestTwo.EndDate = new Date(2012, 8, 22);
            requestTwo.CompletionStatus = PermitRequestCompletionStatus.Incomplete;
            requestTwo.Group = group;
            dao.Insert(requestTwo);

            {
                List<PermitRequestEdmontonDTO> requests = dtoDao.QueryByCompletenessAndGroupAndDateWithinRange(new List<PermitRequestCompletionStatus> { PermitRequestCompletionStatus.Complete }, group.IdValue, new Date(2012, 8, 20));
                Assert.AreEqual(1, requests.Count);
                Assert.IsTrue(requests.Exists(req => req.IdValue == requestOne.IdValue));
                Assert.IsFalse(requests.Exists(req => req.IdValue == requestTwo.IdValue));
            }

            {
                List<PermitRequestEdmontonDTO> requests = dtoDao.QueryByCompletenessAndGroupAndDateWithinRange(new List<PermitRequestCompletionStatus> { PermitRequestCompletionStatus.Complete, PermitRequestCompletionStatus.Incomplete }, group.IdValue, new Date(2012, 8, 20));
                Assert.AreEqual(2, requests.Count);
                Assert.IsTrue(requests.Exists(req => req.IdValue == requestOne.IdValue));
                Assert.IsTrue(requests.Exists(req => req.IdValue == requestTwo.IdValue));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByCompletenessAndGroupAndDateFallingInRequestedRange_VaryGroup()
        {
            WorkPermitEdmontonGroup group1 = groupDao.Insert(new WorkPermitEdmontonGroup(-1, "Some Different Group 1", new List<long> { 1, 2 }, 0, false));
            WorkPermitEdmontonGroup group2 = groupDao.Insert(new WorkPermitEdmontonGroup(-1, "Some Different Group 2", new List<long> { 3 }, 1, false));

            PermitRequestEdmonton requestOne = CreateForInsert();
            requestOne.RequestedStartDate = new Date(2012, 8, 19);
            requestOne.EndDate = new Date(2012, 8, 22);
            requestOne.Group = group1;
            requestOne.CompletionStatus = PermitRequestCompletionStatus.Complete;
            dao.Insert(requestOne);

            PermitRequestEdmonton requestTwo = CreateForInsert();
            requestTwo.RequestedStartDate = new Date(2012, 8, 19);
            requestTwo.EndDate = new Date(2012, 8, 22);
            requestTwo.CompletionStatus = PermitRequestCompletionStatus.Complete;
            requestTwo.Group = group2;
            dao.Insert(requestTwo);

            {
                List<PermitRequestEdmontonDTO> requests = dtoDao.QueryByCompletenessAndGroupAndDateWithinRange(new List<PermitRequestCompletionStatus> { PermitRequestCompletionStatus.Complete }, group1.IdValue, new Date(2012, 8, 20));
                Assert.AreEqual(1, requests.Count);
                Assert.IsTrue(requests.Exists(req => req.IdValue == requestOne.IdValue));
                Assert.IsFalse(requests.Exists(req => req.IdValue == requestTwo.IdValue));
            }
        }
    }

}
