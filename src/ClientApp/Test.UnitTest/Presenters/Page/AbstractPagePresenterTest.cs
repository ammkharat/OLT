using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    [TestFixture]
    [Ignore("CCTODO - Ignoring until we have Infragistics licenses")]
    public class AbstractPagePresenterTest
    {
        [SetUp]
        public void SetUp()
        {
            User user = UserFixture.CreateUser();
            user.Id = 1;
            ClientSession.GetUserContext().User = user;
        }

        private static LogDTO CreateDto(long id)
        {
            LogDTO dto = LogDTOFixture.CreateLogDTO();
            dto.Id = id;
            return dto;
        }

        [Test]
        public void ShouldDoInitialDataLoad_DoNotSelectRowsIfItemListIsEmpty()
        {
            TestPresenter presenter = new TestPresenter();
            presenter.Dtos.Clear();
            presenter.DoInitialDataLoad();

            Assert.AreEqual(0, presenter.Grid.Selected.Rows.Count);
            Assert.IsNull(presenter.DetailDomainObject);
        }

        [Test]
        public void ShouldDoInitialDataLoad_SelectFirstRowIfItemListIsNotEmpty()
        {
            TestPresenter presenter = new TestPresenter();
            presenter.Dtos.Clear();
            presenter.Dtos.Add(CreateDto(100));
            presenter.Dtos.Add(CreateDto(200));
            presenter.DoInitialDataLoad();

            Assert.AreEqual(1, presenter.Grid.Selected.Rows.Count);
            DomainObject selected = (DomainObject)presenter.Grid.Selected.Rows[0].ListObject;
            Assert.AreEqual(100, selected.Id);
            Assert.IsNotNull(presenter.DetailDomainObject);
            Assert.AreEqual(100, presenter.DetailDomainObject.Id);
        }

        [Test]
        public void ShouldSetDetailsAndButtonOnSelectedItemChanged()
        {
            TestPresenter presenter = new TestPresenter();
            presenter.Dtos.Clear();
            presenter.Dtos.Add(CreateDto(100));
            presenter.Dtos.Add(CreateDto(200));
            presenter.Dtos.Add(CreateDto(300));
            presenter.DoInitialDataLoad();

            presenter.Grid.Selected.Rows.Clear();
            presenter.Grid.Selected.Rows.Add(presenter.Grid.Rows[1]);

            Assert.AreEqual(1, presenter.Grid.Selected.Rows.Count);
            DomainObject selected = (DomainObject)presenter.Grid.Selected.Rows[0].ListObject;
            Assert.AreEqual(200, selected.Id);
            Assert.IsNotNull(presenter.DetailDomainObject);
            Assert.AreEqual(200, presenter.DetailDomainObject.Id);
        }

        [Test]
        public void ShouldHandleRemoveEvent_ItemExistsInGrid()
        {
            TestPresenter presenter = new TestPresenter();
            presenter.Dtos.Clear();
            presenter.Dtos.Add(CreateDto(100));
            presenter.Dtos.Add(CreateDto(200));
            presenter.DoInitialDataLoad();

            Log log = LogFixture.CreateLog(false);
            log.Id = 100;
            presenter.RemoveItem(log);

            Assert.AreEqual(1, presenter.Grid.Rows.Count);
            {
                DomainObject item = (DomainObject)presenter.Grid.Rows[0].ListObject;
                Assert.AreEqual(200, item.Id);
            }
        }

        [Test]
        public void ShouldHandleRemoveEvent_ItemDoesNotExistInGrid()
        {
            TestPresenter presenter = new TestPresenter();
            presenter.Dtos.Clear();
            presenter.Dtos.Add(CreateDto(100));
            presenter.Dtos.Add(CreateDto(200));
            presenter.DoInitialDataLoad();

            Log log = LogFixture.CreateLog(false);
            log.Id = 300;
            presenter.RemoveItem(log);

            Assert.AreEqual(2, presenter.Grid.Rows.Count);
            {
                DomainObject item = (DomainObject)presenter.Grid.Rows[0].ListObject;
                Assert.AreEqual(100, item.Id);
            }
            {
                DomainObject item = (DomainObject)presenter.Grid.Rows[1].ListObject;
                Assert.AreEqual(200, item.Id);
            }
        }

        [Test]
        public void ShouldHandleRemoveEvent_OnlyOneInGrid()
        {
            TestPresenter presenter = new TestPresenter();
            presenter.Dtos.Clear();
            presenter.Dtos.Add(CreateDto(100));
            presenter.DoInitialDataLoad();

            Log log = LogFixture.CreateLog(false);
            log.Id = 100;
            presenter.RemoveItem(log);

            Assert.AreEqual(0, presenter.Grid.Rows.Count);
        }

        private class TestPresenter : LogPagePresenter
        {
            private readonly List<LogDTO> dtos = new List<LogDTO>();
            private DomainObject detailDomainObject;

            public TestPresenter() : base(new LogPage(), new Authorized(), null, null, null, null, null, null)
            {
            }

            public UltraGrid Grid
            {
                get { return page.Grid; }
            }

            public DomainObject DetailDomainObject
            {
                get { return detailDomainObject; }
            }

            public List<LogDTO> Dtos
            {
                get { return dtos; }
            }

            public void RemoveItem(Log item)
            {
                base.ItemRemoved(item);
            }

            protected override Log QueryByDto(LogDTO dto)
            {
                Log log = LogFixture.CreateLog(false);
                log.Id = dto.IdValue;
                return log;
            }

            protected override IList<LogDTO> GetDtos(Range<Date> dateRange)
            {
                return dtos;
            }

            protected override LogDTO CreateDTOFromDomainObject(Log item)
            {
                LogDTO dto = LogDTOFixture.CreateLogDTO();
                dto.Id = item.Id;
                return dto;
            }

            protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
            {
            }

            protected override void ControlDetailButtons()
            {
            }

            protected override void SetDetailData(ILogDetails details, Log item)
            {
                detailDomainObject = item;
            }
        }
    }
}