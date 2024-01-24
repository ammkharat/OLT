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
    public class PermitRequestLubesDTODaoTest : AbstractDaoTest
    {
        private IPermitRequestLubesDTODao dtoDao;
        private IPermitRequestLubesDao permitRequestDao;
        private IWorkPermitLubesGroupDao groupDao;

        private WorkPermitLubesGroup group;
        private WorkPermitLubesGroup anotherGroup;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            
        }

        protected override void TestInitialize()
        {
            dtoDao = DaoRegistry.GetDao<IPermitRequestLubesDTODao>();
            permitRequestDao = DaoRegistry.GetDao<IPermitRequestLubesDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitLubesGroupDao>();

            if (group == null || anotherGroup == null)
            {
                List<WorkPermitLubesGroup> groups = groupDao.QueryAll();
                group = groups[0];
                anotherGroup = groups[1];
            }
        }

        protected override void Cleanup()
        {            
        }

        [Ignore] [Test]
        public void ShouldQueryDtos_VaryFloc()
        {
            FunctionalLocation childFloc = FunctionalLocationFixture.GetReal("ED1-A001-U007-SCH-T0001");
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A001-U007-SCH");
            FunctionalLocation parentFloc = FunctionalLocationFixture.GetReal("ED1-A001-U007");

            PermitRequestLubes request1 = PermitRequestLubesFixture.CreateForInsert(group);
            request1.FunctionalLocation = floc;
            permitRequestDao.Insert(request1);
            Assert.IsNotNull(request1.Id);

            PermitRequestLubes request2 = PermitRequestLubesFixture.CreateForInsert(group);
            request2.FunctionalLocation = childFloc;
            permitRequestDao.Insert(request2);
            Assert.IsNotNull(request2.Id);

            {
                List<PermitRequestLubesDTO> results = dtoDao.QueryByDateRangeAndFlocs(new RootFlocSet(parentFloc), new DateRange(null, null));
                Assert.IsNotNull(results.Find(result => result.IdValue == request1.IdValue));
                Assert.IsNotNull(results.Find(result => result.IdValue == request2.IdValue));
            }

            {
                List<PermitRequestLubesDTO> results = dtoDao.QueryByDateRangeAndFlocs(new RootFlocSet(childFloc), new DateRange(null, null));
                Assert.IsNotNull(results.Find(result => result.IdValue == request1.IdValue));
                Assert.IsNotNull(results.Find(result => result.IdValue == request2.IdValue));
            }

            {
                List<PermitRequestLubesDTO> results = dtoDao.QueryByDateRangeAndFlocs(new RootFlocSet(floc), new DateRange(null, null));
                Assert.IsNotNull(results.Find(result => result.IdValue == request1.IdValue));
                Assert.IsNotNull(results.Find(result => result.IdValue == request2.IdValue));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryDtos_VaryDates()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal("ED1-A001-U007-SCH");

            PermitRequestLubes request1 = PermitRequestLubesFixture.CreateForInsert(group);
            request1.FunctionalLocation = floc;
            request1.RequestedStartDate = new Date(2012, 10, 20);
            request1.EndDate = new Date(2012, 10, 25);
            permitRequestDao.Insert(request1);
            Assert.IsNotNull(request1.Id);

            PermitRequestLubes request2 = PermitRequestLubesFixture.CreateForInsert(group);
            request2.FunctionalLocation = floc;
            request2.RequestedStartDate = new Date(2012, 10, 23);
            request2.EndDate = new Date(2012, 10, 28);
            permitRequestDao.Insert(request2);
            Assert.IsNotNull(request2.Id);

            {
                List<PermitRequestLubesDTO> results = dtoDao.QueryByDateRangeAndFlocs(new RootFlocSet(floc), new DateRange(new Date(2012, 10, 22), new Date(2012, 10, 26)));
                Assert.AreEqual(2, results.Count);
                Assert.IsNotNull(results.Find(result => result.IdValue == request1.IdValue));
                Assert.IsNotNull(results.Find(result => result.IdValue == request2.IdValue));
            }

            {
                List<PermitRequestLubesDTO> results = dtoDao.QueryByDateRangeAndFlocs(new RootFlocSet(floc), new DateRange(new Date(2012, 10, 19), new Date(2012, 10, 21)));
                Assert.AreEqual(1, results.Count);
                Assert.IsNotNull(results.Find(result => result.IdValue == request1.IdValue));
            }

            {
                List<PermitRequestLubesDTO> results = dtoDao.QueryByDateRangeAndFlocs(new RootFlocSet(floc), new DateRange(new Date(2012, 10, 26), new Date(2012, 10, 29)));
                Assert.AreEqual(1, results.Count);
                Assert.IsNotNull(results.Find(result => result.IdValue == request2.IdValue));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByCompletenessAndGroupAndDateFallingInRequestedRange_VaryDate()
        {
            PermitRequestLubes requestOne = PermitRequestLubesFixture.CreateForInsert(group);
            requestOne.RequestedStartDate = new Date(2012, 8, 19);
            requestOne.EndDate = new Date(2012, 8, 22);
            requestOne.CompletionStatus = PermitRequestCompletionStatus.Complete;
            permitRequestDao.Insert(requestOne);

            PermitRequestLubes requestTwo = PermitRequestLubesFixture.CreateForInsert(group);
            requestTwo.RequestedStartDate = new Date(2012, 8, 21);
            requestTwo.EndDate = new Date(2012, 8, 22);
            requestTwo.CompletionStatus = PermitRequestCompletionStatus.Complete;
            permitRequestDao.Insert(requestTwo);

            {
                List<PermitRequestLubesDTO> requests = dtoDao.QueryByCompletenessAndGroupAndDateWithinRange(new List<PermitRequestCompletionStatus> { PermitRequestCompletionStatus.Complete }, group.IdValue, new Date(2012, 8, 20));
                Assert.AreEqual(1, requests.Count);
                Assert.IsTrue(requests.Exists(req => req.IdValue == requestOne.IdValue));
                Assert.IsFalse(requests.Exists(req => req.IdValue == requestTwo.IdValue));
            }

            {
                List<PermitRequestLubesDTO> requests = dtoDao.QueryByCompletenessAndGroupAndDateWithinRange(new List<PermitRequestCompletionStatus> { PermitRequestCompletionStatus.Complete }, group.IdValue, new Date(2011, 2, 22));
                Assert.AreEqual(0, requests.Count);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByCompletenessAndGroupAndDateFallingInRequestedRange_VaryCompleteness()
        {
            PermitRequestLubes requestOne = PermitRequestLubesFixture.CreateForInsert(group);
            requestOne.RequestedStartDate = new Date(2012, 8, 19);
            requestOne.EndDate = new Date(2012, 8, 22);
            requestOne.CompletionStatus = PermitRequestCompletionStatus.Complete;
            permitRequestDao.Insert(requestOne);

            PermitRequestLubes requestTwo = PermitRequestLubesFixture.CreateForInsert(group);
            requestTwo.RequestedStartDate = new Date(2012, 8, 19);
            requestTwo.EndDate = new Date(2012, 8, 22);
            requestTwo.CompletionStatus = PermitRequestCompletionStatus.Incomplete;
            permitRequestDao.Insert(requestTwo);

            {
                List<PermitRequestLubesDTO> requests = dtoDao.QueryByCompletenessAndGroupAndDateWithinRange(new List<PermitRequestCompletionStatus> { PermitRequestCompletionStatus.Complete }, group.IdValue, new Date(2012, 8, 20));
                Assert.AreEqual(1, requests.Count);
                Assert.IsTrue(requests.Exists(req => req.IdValue == requestOne.IdValue));
                Assert.IsFalse(requests.Exists(req => req.IdValue == requestTwo.IdValue));
            }

            {
                List<PermitRequestLubesDTO> requests = dtoDao.QueryByCompletenessAndGroupAndDateWithinRange(new List<PermitRequestCompletionStatus> { PermitRequestCompletionStatus.Complete, PermitRequestCompletionStatus.Incomplete }, group.IdValue, new Date(2012, 8, 20));
                Assert.AreEqual(2, requests.Count);
                Assert.IsTrue(requests.Exists(req => req.IdValue == requestOne.IdValue));
                Assert.IsTrue(requests.Exists(req => req.IdValue == requestTwo.IdValue));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByCompletenessAndGroupAndDateFallingInRequestedRange_VaryGroup()
        {
            PermitRequestLubes requestOne = PermitRequestLubesFixture.CreateForInsert(group);
            requestOne.RequestedStartDate = new Date(2012, 8, 19);
            requestOne.EndDate = new Date(2012, 8, 22);
            requestOne.CompletionStatus = PermitRequestCompletionStatus.Complete;
            permitRequestDao.Insert(requestOne);

            PermitRequestLubes requestTwo = PermitRequestLubesFixture.CreateForInsert(anotherGroup);
            requestTwo.RequestedStartDate = new Date(2012, 8, 19);
            requestTwo.EndDate = new Date(2012, 8, 22);
            requestTwo.CompletionStatus = PermitRequestCompletionStatus.Complete;
            permitRequestDao.Insert(requestTwo);

            {
                List<PermitRequestLubesDTO> requests = dtoDao.QueryByCompletenessAndGroupAndDateWithinRange(new List<PermitRequestCompletionStatus> { PermitRequestCompletionStatus.Complete }, group.IdValue, new Date(2012, 8, 20));
                Assert.AreEqual(1, requests.Count);
                Assert.IsTrue(requests.Exists(req => req.IdValue == requestOne.IdValue));
                Assert.IsFalse(requests.Exists(req => req.IdValue == requestTwo.IdValue));
            }
        }

    }

}
