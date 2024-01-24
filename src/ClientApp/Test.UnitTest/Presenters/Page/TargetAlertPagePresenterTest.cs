using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    [TestFixture]
    public class TargetAlertPagePresenterTest
    {
        [SetUp]
        public void SetUp()
        {
            User user = UserFixture.CreateUser();
            user.Id = 1;
            ClientSession.GetUserContext().User = user;
        }

        private static TargetAlertDTO CreateDto(long id, TargetAlertStatus status)
        {
            TargetAlert alert = TargetAlertFixture.CreateATargetAlert(status);
            TargetAlertDTO dto = new TargetAlertDTO(alert);
            dto.Id = id;
            return dto;
        }

        [Test]
        public void ShouldHandleUpdateEvent_UpdatedToStatusNeedingAttention()
        {
            TestPresenter presenter = new TestPresenter();
            presenter.Dtos.Clear();
            presenter.Dtos.Add(CreateDto(100, TargetAlertStatus.NeverToExceedAlert));
            presenter.Dtos.Add(CreateDto(200, TargetAlertStatus.StandardAlert));
            presenter.DoInitialDataLoad();

            TargetAlert alert = TargetAlertFixture.CreateATargetAlert(TargetAlertStatus.NeverToExceedAlert);
            alert.Id = 200;
            presenter.UpdateItem(alert);

            Assert.AreEqual(2, presenter.Grid.Rows.Count);
            {
                TargetAlertDTO item = (TargetAlertDTO)presenter.Grid.Rows[0].ListObject;
                Assert.AreEqual(100, item.Id);
                Assert.AreEqual(TargetAlertStatus.NeverToExceedAlert, item.Status);
            }
            {
                TargetAlertDTO item = (TargetAlertDTO)presenter.Grid.Rows[1].ListObject;
                Assert.AreEqual(200, item.Id);
                Assert.AreEqual(TargetAlertStatus.NeverToExceedAlert, item.Status);
            }
        }

        [Test]
        public void ShouldHandleUpdateEvent_RemoveIfStatusIsClosed()
        {
            TestPresenter presenter = new TestPresenter();
            presenter.Dtos.Clear();
            presenter.Dtos.Add(CreateDto(100, TargetAlertStatus.NeverToExceedAlert));
            presenter.Dtos.Add(CreateDto(200, TargetAlertStatus.StandardAlert));
            presenter.DoInitialDataLoad();

            TargetAlert alert = TargetAlertFixture.CreateATargetAlert(TargetAlertStatus.Closed);
            alert.Id = 200;
            presenter.UpdateItem(alert);

            Assert.AreEqual(1, presenter.Grid.Rows.Count);
        }

        private class TestPresenter : TargetAlertPagePresenter
        {
            private readonly List<TargetAlertDTO> dtos = new List<TargetAlertDTO>();

            public TestPresenter() : base(new TargetAlertPage(), new Authorized(), null, null, null, null, null, null)
            {
            }

            public UltraGrid Grid
            {
                get { return page.Grid; }
            }

            public List<TargetAlertDTO> Dtos
            {
                get { return dtos; }
            }

            public void UpdateItem(TargetAlert item)
            {
                base.ItemUpdated(item);
            }

            protected override TargetAlert QueryByDto(TargetAlertDTO dto)
            {
                TargetAlert item = TargetAlertFixture.CreateATargetAlert();
                item.Id = dto.IdValue;
                return item;
            }

            protected override IList<TargetAlertDTO> GetDtos(Range<Date> dateRange)
            {
                return dtos;
            }

            protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
            {
            }

            protected override void ControlDetailButtons()
            {
            }

            protected override void SetDetailData(Controls.Details.ITargetAlertDetails details, TargetAlert value)
            {
            }

            protected override IBackgroundHelper<Range<Date>> CreateBackgroundHelper(bool synchronous)
            {
                return new FakeBackgroundHelper<Range<Date>, DtosAndDateRange<TargetAlertDTO>>(new DtoFetcher(this));
            }
        }
    }
}
