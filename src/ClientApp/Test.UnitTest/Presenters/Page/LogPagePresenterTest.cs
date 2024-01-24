using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    [TestFixture]
    public class LogPagePresenterTest
    {
        private ILogPage mockLogPage;
        private ILogDetails mockLogDetails;
        private IGridRenderer mockGridRenderer;
        private ITimeService mockTimeService;
        
        [SetUp]
        public void SetUp()
        {
            User user = UserFixture.CreateUser();
            user.Id = 1;
            ClientSession.GetUserContext().User = user;
            Site site = SiteFixture.Sarnia();
            ClientSession.GetUserContext().SetSite(site, SiteConfigurationFixture.CreateSiteConfiguration());        

            mockLogPage = MockRepository.GenerateStub<ILogPage>();
            mockLogDetails = MockRepository.GenerateStub<ILogDetails>();
            mockGridRenderer = MockRepository.GenerateStub<IGridRenderer>();
            mockTimeService = MockRepository.GenerateStub<ITimeService>();


            mockLogPage.Stub(m => m.PageKey).Return(new PageKey(1, "who cares-tab", "who cares-titletext", new SectionKey(213, "who cares-Section")));
            mockLogPage.Stub(m => m.Details).Return(mockLogDetails);

            mockTimeService.Stub(s => s.GetDate(site.TimeZone)).IgnoreArguments().Return(new Date(2012, 12, 4));
        }

        private static LogDTO CreateDto(long id)
        {
            LogDTO dto = LogDTOFixture.CreateLogDTO();
            dto.Id = id;
            return dto;
        }

        [Test]
        public void ShouldLoadLogThreadTree_NoChildLogs()
        {
            mockLogPage.Stub(m => m.SelectedItems).Return(new List<LogDTO>());
            mockLogPage.Stub(m => m.Grid).Return(new DomainSummaryGrid<LogDTO>(mockGridRenderer,
                                                                               OltGridAppearance.MULTI_SELECT, "logs"));

            TestPresenter presenter = new TestPresenter(mockLogPage, mockTimeService);
            presenter.Dtos.Clear();
            presenter.Dtos.Add(CreateDto(100));
            presenter.DoInitialDataLoad();

            presenter.PageBypass_ShowLogThread();
        }

        [Test]
        public void ShouldLoadLogThreadTree_ViewRootLogWithChildLogs()
        {
            LogDTO root = CreateDto(100);
            LogDTO child = LogDTOFixture.CreateReplyTo(root);
            child.Id = 200;

            mockLogPage.Stub(m => m.SelectedItems).Return(new List<LogDTO> { root });
            mockLogPage.Stub(m => m.Grid).Return(new DomainSummaryGrid<LogDTO>(mockGridRenderer,
                                                                               OltGridAppearance.MULTI_SELECT, "logs"));

            TestPresenter presenter = new TestPresenter(mockLogPage, mockTimeService);
            presenter.Dtos.Clear();
            presenter.Dtos.Add(root);
            presenter.Dtos.Add(child);
            presenter.DoInitialDataLoad();

            presenter.PageBypass_ShowLogThread();
        }

        [Test]
        public void ShouldLoadLogThreadTree_ViewChildLogWithRootLog()
        {
            LogDTO root = CreateDto(100);
            LogDTO child = LogDTOFixture.CreateReplyTo(root);
            child.Id = 200;

            mockLogPage.Stub(m => m.SelectedItems).Return(new List<LogDTO> { root });
            mockLogPage.Stub(m => m.Grid).Return(new DomainSummaryGrid<LogDTO>(mockGridRenderer,
                                                                               OltGridAppearance.MULTI_SELECT, "logs"));

            TestPresenter presenter = new TestPresenter(mockLogPage, mockTimeService);
            presenter.Dtos.Clear();
            presenter.Dtos.Add(child);
            presenter.Dtos.Add(root);
            presenter.DoInitialDataLoad();

            presenter.PageBypass_ShowLogThread();
        }

        [Test]
        public void ShouldChangeItemInGridWhenThreadItemIsSelected()
        {
            LogDTO root = CreateDto(100);
            LogDTO child = LogDTOFixture.CreateReplyTo(root);
            child.Id = 200;

            mockLogPage.Stub(m => m.SelectedItems).Return(new List<LogDTO> { root });
            mockLogPage.Stub(m => m.Grid).Return(new DomainSummaryGrid<LogDTO>(mockGridRenderer, OltGridAppearance.MULTI_SELECT, "logs"));

            TestPresenter presenter = new TestPresenter(mockLogPage, mockTimeService);
            presenter.Dtos.Clear();
            presenter.Dtos.Add(root);
            presenter.Dtos.Add(child);
            presenter.DoInitialDataLoad();

            presenter.PageBypass_ShowLogThread();
            presenter.PageBypass_Select(child);
        }

        [Test, Ignore]
        public void ShouldChangeItemInThreadWhenGridItemIsSelected()
        {
            LogDTO root = CreateDto(100);
            LogDTO child = LogDTOFixture.CreateReplyTo(root);
            child.Id = 200;

            mockLogPage.Stub(m => m.SelectedItems).Return(new List<LogDTO> { root });
            mockLogPage.Stub(m => m.Grid).Return(new DomainSummaryGrid<LogDTO>(mockGridRenderer,
                                                                               OltGridAppearance.MULTI_SELECT, "logs"));
            TestPresenter presenter = new TestPresenter(mockLogPage, mockTimeService);
            presenter.Dtos.Clear();
            presenter.Dtos.Add(root);
            presenter.Dtos.Add(child);
            presenter.DoInitialDataLoad();

            presenter.PageBypass_ShowLogThread();
            presenter.Grid.Selected.Rows.Clear();
            presenter.Grid.Selected.Rows.Add(presenter.Grid.Rows[1]);
        }

        [Test]
        public void ShouldUpdateThreadedView_AddLog()
        {
            Log log = LogFixture.CreateLog(true);
            log.Id = 200;


            mockLogPage.Stub(m => m.SelectedItems).Return(new List<LogDTO> { new LogDTO(log) });
            mockLogPage.Stub(m => m.Grid).Return(new DomainSummaryGrid<LogDTO>(mockGridRenderer,
                                                                               OltGridAppearance.MULTI_SELECT, "logs"));

            TestPresenter presenter = new TestPresenter(mockLogPage, mockTimeService); 
            presenter.Dtos.Clear();
            presenter.Dtos.Add(CreateDto(100));
            presenter.DoInitialDataLoad();
            presenter.PageBypass_ShowLogThread();

            presenter.AddItem(log);
        }

        [Test]
        public void ShouldUpdateThreadedView_UpdateLog()
        {
            Log log = LogFixture.CreateLog(true);
            log.Id = 100;

            mockLogPage.Stub(m => m.SelectedItems).Return(new List<LogDTO> { new LogDTO(log) });
            mockLogPage.Stub(m => m.Grid).Return(new DomainSummaryGrid<LogDTO>(mockGridRenderer,
                                                                               OltGridAppearance.MULTI_SELECT, "logs"));

            TestPresenter presenter = new TestPresenter(mockLogPage, mockTimeService);
            presenter.Dtos.Clear();
            presenter.Dtos.Add(CreateDto(100));
            presenter.DoInitialDataLoad();
            presenter.PageBypass_ShowLogThread();

            presenter.UpdateItem(log);
        }

        [Test, Ignore]
        public void ShouldUpdateThreadedView_DeleteLog()
        {
            Log log = LogFixture.CreateLog(true);
            log.Id = 100;

            mockLogPage.Stub(m => m.SelectedItems).Return(new List<LogDTO> { new LogDTO(log) });

            TestPresenter presenter = new TestPresenter(mockLogPage, mockTimeService);
            presenter.Dtos.Clear();
            presenter.Dtos.Add(CreateDto(100));
            presenter.DoInitialDataLoad();
            presenter.PageBypass_ShowLogThread();

            presenter.RemoveItem(log);
        }

        private class TestPresenter : LogPagePresenter
        {
            private readonly List<LogDTO> dtos = new List<LogDTO>();

            public TestPresenter(ILogPage logPage, ITimeService timeService) : base(logPage, new Authorized(), null, null, null, null, timeService, null)
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

            public void PageBypass_ShowLogThread()
            {
                page.ShowLogThread = true;
            }

            public void PageBypass_Select(LogDTO dto)
            {
                page.SelectThreadItem(dto);
            }

            public void AddItem(Log item)
            {
                base.ItemCreated(item);
            }

            public void UpdateItem(Log item)
            {
                base.ItemUpdated(item);
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
            }
        }
    }
}