using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class WorkPermitMontrealServiceTest
    {
        private Mockery mocks;
        private EventQueueTestWrapper eventQueue;
        private IWorkPermitMontrealService service;
        private IWorkPermitMontrealDao mockDao;
        private IWorkPermitMontrealDTODao mockDTODao;
        private IWorkPermitMontrealGroupDao mockGroupDao;
        private IEditHistoryService mockEditHistoryService;
        private ILogService mockLogServiceService;
        private IConfiguredDocumentLinkDao mockConfiguredDocumentLinkDao;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockDao = mocks.NewMock<IWorkPermitMontrealDao>();
            mockDTODao = mocks.NewMock<IWorkPermitMontrealDTODao>();
            mockGroupDao = mocks.NewMock<IWorkPermitMontrealGroupDao>();
            mockEditHistoryService = mocks.NewMock<IEditHistoryService>();
            mockLogServiceService = mocks.NewMock<ILogService>();
            mockConfiguredDocumentLinkDao = mocks.NewMock<IConfiguredDocumentLinkDao>();

            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor(mockDao);
            DaoRegistry.RegisterDaoFor(mockDTODao);
            DaoRegistry.RegisterDaoFor(mockConfiguredDocumentLinkDao);
            DaoRegistry.RegisterDaoFor(mockGroupDao);

            service = new WorkPermitMontrealService(mockEditHistoryService, mockLogServiceService);

            eventQueue = new EventQueueTestWrapper();
        }

        [TearDown]
        public void TearDown()
        {
            eventQueue.Cleanup();
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldQueryByDateRange()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_MT1_A003_U120() };
            RootFlocSet rootFlocSet = new RootFlocSet(flocs);
            Range<Date> range = new Range<Date>(new Date(2011, 01, 01), new Date(DateTimeFixture.DateTimeNow));
            var workPermitMontrealDtos = new List<WorkPermitMontrealDTO>();

            Expect.Once.On(mockDTODao).Method("QueryByDateRangeAndFlocs").With(range, rootFlocSet).Will(Return.Value(workPermitMontrealDtos));

            service.QueryByDateRangeAndFlocs(range, rootFlocSet);
        }

        [Ignore] [Test]
        public void ShouldInsertUserHasReadDocumentLinkData()
        {
            WorkPermitMontreal permit = WorkPermitMontrealFixture.CreateForInsert();
            permit.Id = 3;
            permit.LastModifiedBy = UserFixture.CreateUserWithGivenId(1);

            Stub.On(mockEditHistoryService).Method("TakeSnapshot");
            Expect.Once.On(mockDao).Method("Insert").With(permit, null).Will(Return.Value(permit));
            Expect.Once.On(mockDao).Method("HasUserReadAtLeastOneDocumentLink").With(permit.LastModifiedBy.IdValue, permit.IdValue).Will(Return.Value(false));
            Expect.Once.On(mockDao).Method("InsertWorkPermitMontrealUserReadDocumentLinkAssociation").With(permit.LastModifiedBy.IdValue, permit.IdValue);

            service.InsertWithUserReadDocumentLinkAssociation(permit, true);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldNotInsertUserHasReadDocumentLinkData()
        {
            WorkPermitMontreal permit = WorkPermitMontrealFixture.CreateForInsert();
            permit.Id = 3;
            permit.LastModifiedBy = UserFixture.CreateUserWithGivenId(1);

            Stub.On(mockEditHistoryService).Method("TakeSnapshot");
            Expect.Once.On(mockDao).Method("Insert").With(permit, null).Will(Return.Value(permit));
            Expect.Never.On(mockDao).Method("InsertWorkPermitMontrealUserReadDocumentLinkAssociation");

            service.InsertWithUserReadDocumentLinkAssociation(permit, false);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldNotInsertUserHasReadDocumentLinkDataOnUpdateIfDataAlreadyExists()
        {
            WorkPermitMontreal permit = WorkPermitMontrealFixture.CreateForInsert();
            permit.Id = 3;
            permit.LastModifiedBy = UserFixture.CreateUserWithGivenId(1);

            Stub.On(mockEditHistoryService).Method("TakeSnapshot");
            Expect.Once.On(mockDao).Method("Update").With(permit);
            Expect.Once.On(mockDao).Method("HasUserReadAtLeastOneDocumentLink").With(permit.LastModifiedBy.IdValue, permit.IdValue).Will(Return.Value(true));
            Expect.Never.On(mockDao).Method("InsertWorkPermitMontrealUserReadDocumentLinkAssociation");

            service.UpdateWithUserReadDocumentLinkAssociation(permit, true);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldInsertUserHasReadDocumentLinkDataOnUpdateIfDataDoesNotAlreadyExist()
        {
            WorkPermitMontreal permit = WorkPermitMontrealFixture.CreateForInsert();
            permit.Id = 3;
            permit.LastModifiedBy = UserFixture.CreateUserWithGivenId(1);

            Stub.On(mockEditHistoryService).Method("TakeSnapshot");
            Expect.Once.On(mockDao).Method("Update").With(permit);
            Expect.Once.On(mockDao).Method("HasUserReadAtLeastOneDocumentLink").With(permit.LastModifiedBy.IdValue, permit.IdValue).Will(Return.Value(false));
            Expect.Once.On(mockDao).Method("InsertWorkPermitMontrealUserReadDocumentLinkAssociation").With(permit.LastModifiedBy.IdValue, permit.IdValue);

            service.UpdateWithUserReadDocumentLinkAssociation(permit, true);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldNotInsertUserHasReadDocumentLinkDataIfDataAlreadyExists()
        {
            WorkPermitMontreal permit = WorkPermitMontrealFixture.CreateForInsert();
            permit.Id = 3;
            permit.LastModifiedBy = UserFixture.CreateUserWithGivenId(1);

            Expect.Once.On(mockDao).Method("HasUserReadAtLeastOneDocumentLink").With(permit.LastModifiedBy.IdValue, permit.IdValue).Will(Return.Value(true));
            Expect.Never.On(mockDao).Method("InsertWorkPermitMontrealUserReadDocumentLinkAssociation");

            service.InsertUserReadDocumentLinkAssociation(permit.IdValue, permit.LastModifiedBy.IdValue);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldInsertUserHasReadDocumentLinkDataIfDataDoesNotAlreadyExist()
        {
            WorkPermitMontreal permit = WorkPermitMontrealFixture.CreateForInsert();
            permit.Id = 3;
            permit.LastModifiedBy = UserFixture.CreateUserWithGivenId(1);

            Expect.Once.On(mockDao).Method("HasUserReadAtLeastOneDocumentLink").With(permit.LastModifiedBy.IdValue, permit.IdValue).Will(Return.Value(false));
            Expect.Once.On(mockDao).Method("InsertWorkPermitMontrealUserReadDocumentLinkAssociation").With(permit.LastModifiedBy.IdValue, permit.IdValue);

            service.InsertUserReadDocumentLinkAssociation(permit.IdValue, permit.LastModifiedBy.IdValue);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
    }
}
