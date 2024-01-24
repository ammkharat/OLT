using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win.UltraWinGrid;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    [TestFixture]
    public class WorkPermitPagePresenterTest
    {
        private Mockery mocks;
        private IWorkPermitService workPermitService;

        [SetUp]
        public void SetUp()
        {
            User user = UserFixture.CreateUser();
            user.Id = 1;
            ClientSession.GetUserContext().User = user;

            mocks = new Mockery();
            workPermitService = mocks.NewMock<IWorkPermitService>();
            Stub.On(workPermitService).Method("Update").With(Is.Anything).Will(Return.Value(new List<NotifiedEvent>()));

            ClientSession.GetNewInstance();
            ClientSession.GetUserContext().User = UserFixture.CreateSarniaUserWithUserPrintPreference();

        }

        private static WorkPermitDTO CreateDto(long id)
        {
            WorkPermitDTO dto = WorkPermitDTOFixture.CreateWorkPermitDTO();
            dto.Id = id;
            return dto;
        }

        [Test][Ignore]
        public void ShouldApprove_FinalizeStartEndTimes()
        {
            TestPresenter presenter = new TestPresenter(workPermitService);

            WorkPermit permit = WorkPermitFixture.CreateValidWorkPermit(200);
            permit.SetWorkPermitStatus(WorkPermitStatus.Pending);
            Assert.IsFalse(permit.StartAndOrEndTimesFinalized);

            presenter.ApproveItem(permit);
            Assert.IsTrue(permit.StartAndOrEndTimesFinalized);
            Assert.AreEqual(WorkPermitStatus.Approved, permit.WorkPermitStatus);
        }

        [Test]
        public void ShouldHandleUpdateEvent_RemoveWorkPermitFromPageIfPermitArchived()
        {
            TestPresenter presenter = new TestPresenter(workPermitService);
            presenter.Dtos.Clear();
            presenter.Dtos.Add(CreateDto(100));
            presenter.Dtos.Add(CreateDto(200));
            presenter.DoInitialDataLoad();

            WorkPermit permit = WorkPermitFixture.CreateValidWorkPermit(200);
            permit.SetWorkPermitStatus(WorkPermitStatus.Archived);
            presenter.UpdateItem(permit);

            Assert.AreEqual(1, presenter.Grid.Rows.Count);
        }

        private class TestPresenter : WorkPermitPagePresenter
        {
            private readonly List<WorkPermitDTO> dtos = new List<WorkPermitDTO>();

            public TestPresenter(IWorkPermitService workPermitService)
                : base(new WorkPermitPage(), null, new Authorized(), null, null, null, workPermitService, null, null, null)
            {
            }

            public UltraGrid Grid
            {
                get { return page.Grid; }
            }

            public List<WorkPermitDTO> Dtos
            {
                get { return dtos; }
            }

            public void UpdateItem(WorkPermit item)
            {
                base.ItemUpdated(item);
            }

            public void ApproveItem(WorkPermit item)
            {
                base.Approve(item);
            }

            protected override WorkPermit QueryByDto(WorkPermitDTO dto)
            {
                WorkPermit item = WorkPermitFixture.CreateValidWorkPermit(dto.IdValue);
                return item;
            }

            protected override IList<WorkPermitDTO> GetDtos(Range<Date> dateRange)
            {
                return dtos;
            }

            protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
            {
            }

            protected override void ControlDetailButtons()
            {
            }

            protected override void SetDetailData(Controls.Details.IWorkPermitDetails details, WorkPermit permit)
            {
            }

            protected override IBackgroundHelper<Range<Date>> CreateBackgroundHelper(bool synchronous)
            {
                return new FakeBackgroundHelper<Range<Date>, DtosAndDateRange<WorkPermitDTO>>(new DtoFetcher(this));
            }
        }
    }
}
