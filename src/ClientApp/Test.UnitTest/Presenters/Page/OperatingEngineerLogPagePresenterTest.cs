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
    public class OperatingEngineerLogPagePresenterTest
    {
        [SetUp]
        public void SetUp()
        {
            User user = UserFixture.CreateUser();
            user.Id = 1;
            ClientSession.GetUserContext().User = user;
            ClientSession.GetUserContext().SetSite(SiteFixture.Sarnia(), SiteConfigurationFixture.CreateSiteConfiguration());
        }

        private static LogDTO CreateDto(long id)
        {
            LogDTO dto = LogDTOFixture.CreateLogDTO();
            dto.Id = id;
            return dto;
        }

        [Test]
        public void ShouldHandleAddEvent_AddItemThatIsAnOperatingEngineerLog()
        {
            TestPresenter presenter = new TestPresenter();
            presenter.Dtos.Clear();
            presenter.Dtos.Add(CreateDto(100));
            presenter.Dtos.Add(CreateDto(200));
            presenter.DoInitialDataLoad();

            Log log = LogFixture.CreateLog(false);
            log.Id = 300;
            log.IsOperatingEngineerLog = true;
            presenter.AddItem(log);

            Assert.AreEqual(3, presenter.Grid.Rows.Count);
        }

        [Test]
        public void ShouldHandleAddEvent_NotAddItemThatIsNotAnOperatingEngineerLog()
        {
            TestPresenter presenter = new TestPresenter();
            presenter.Dtos.Clear();
            presenter.Dtos.Add(CreateDto(100));
            presenter.Dtos.Add(CreateDto(200));
            presenter.DoInitialDataLoad();

            Log log = LogFixture.CreateLog(false);
            log.Id = 300;
            log.IsOperatingEngineerLog = false;
            presenter.AddItem(log);

            Assert.AreEqual(2, presenter.Grid.Rows.Count);
        }

        [Test]
        public void ShouldHandleUpdateEvent_RemoveItemThatIsNoLongerAnOperatingEngineerLog()
        {
            TestPresenter presenter = new TestPresenter();
            presenter.Dtos.Clear();
            presenter.Dtos.Add(CreateDto(100));
            presenter.Dtos.Add(CreateDto(200));
            presenter.DoInitialDataLoad();

            Log log = LogFixture.CreateLog(false);
            log.Id = 200;
            log.IsOperatingEngineerLog = false;
            presenter.UpdateItem(log);

            Assert.AreEqual(1, presenter.Grid.Rows.Count);
            {
                DomainObject item = (DomainObject)presenter.Grid.Rows[0].ListObject;
                Assert.AreEqual(100, item.Id);
            }
        }

        [Test]
        public void ShouldHandleUpdateEvent_AddItemThatIsNotInTheListButNowIsAnOperatingEngineerLogBecauseOfAnUpdate()
        {
            TestPresenter presenter = new TestPresenter();
            presenter.Dtos.Clear();
            presenter.Dtos.Add(CreateDto(100));
            presenter.Dtos.Add(CreateDto(200));
            presenter.DoInitialDataLoad();

            Log log = LogFixture.CreateLog(false);
            log.Id = 300;
            log.IsOperatingEngineerLog = true;
            presenter.UpdateItem(log);

            Assert.AreEqual(3, presenter.Grid.Rows.Count);
        }

        [Test]
        public void ShouldHandleUpdateEvent_UpdatetemThatIsInTheListNow()
        {
            TestPresenter presenter = new TestPresenter();
            presenter.Dtos.Clear();
            presenter.Dtos.Add(CreateDto(100));
            presenter.Dtos.Add(CreateDto(200));
            presenter.DoInitialDataLoad();

            Log log = LogFixture.CreateLog(false);
            log.Id = 200;
            log.IsOperatingEngineerLog = true;
            log.FunctionalLocations.Clear();
            log.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew("a new floc"));
            presenter.UpdateItem(log);

            Assert.AreEqual(2, presenter.Grid.Rows.Count);
            {
                DomainObject item = (DomainObject)presenter.Grid.Rows[0].ListObject;
                Assert.AreEqual(100, item.Id);
            }
            {
                LogDTO item = (LogDTO)presenter.Grid.Rows[1].ListObject;
                Assert.AreEqual(200, item.Id);
                Assert.AreEqual("a new floc", item.FunctionalLocationNames);
            }
        }


        private class TestPresenter : OperatingEngineerLogPagePresenter
        {
            private readonly List<LogDTO> dtos = new List<LogDTO>();

            public TestPresenter()
                : base(new LogPage(), new Authorized(), null, null, null, null, null, null)
            {
            }

            public UltraGrid Grid
            {
                get { return page.Grid; }
            }

            public List<LogDTO> Dtos
            {
                get { return dtos; }
            }

            public void AddItem(Log item)
            {
                base.ItemCreated(item);
            }

            public void UpdateItem(Log item)
            {
                base.ItemUpdated(item);
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
                return new LogDTO(item);
            }

            protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
            {
            }

            protected override void ControlDetailButtons()
            {
            }

            protected override void SetDetailData(ILogDetails details, Log item)
            {
            }
        }
    }
}