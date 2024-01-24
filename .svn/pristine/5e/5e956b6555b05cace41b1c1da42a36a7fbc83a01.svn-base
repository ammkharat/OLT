using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Details;
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
    public class ActionItemPagePresenterTest
    {
        private ITimeService mockTimeService;
        private IFormEdmontonService mockFormService;

        [SetUp]
        public void SetUp()
        {
            User user = UserFixture.CreateUser();
            user.Id = 1;
            ClientSession.GetUserContext().User = user;

            Site site = SiteFixture.Sarnia();
            ClientSession.GetUserContext().SetSite(site, SiteConfigurationFixture.CreateSiteConfiguration());

            mockTimeService = MockRepository.GenerateStub<ITimeService>();
            mockTimeService.Stub(s => s.GetDate(site.TimeZone)).IgnoreArguments().Return(new Date(2012, 12, 4));
            mockTimeService.Stub(s => s.GetTime(site.TimeZone)).IgnoreArguments().Return(new DateTime(2012, 12, 4, 10, 0, 0));

            mockFormService = MockRepository.GenerateStub<IFormEdmontonService>();
        }

        private static ActionItemDTO CreateDto(long id)
        {
            ActionItemDTO dto = ActionItemDTOFixture.CreateActionItemDto();
            dto.Id = id;
            return dto;
        }

        [Test][Ignore]
        public void ShouldHandleUpdateEvent_UpdateItem()
        {
            SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
            TestPresenter presenter = new TestPresenter(mockTimeService, mockFormService);

            ActionItem actionItem100 = ActionItemFixture.Create();
            actionItem100.Id = 100;
            actionItem100.SetStatus(ActionItemStatus.Current, UserFixture.CreateUser(), new DateTime(2012, 12, 4));
            actionItem100.Name = "100-v1";
            actionItem100.StartDateTime = new DateTime(2012, 12, 4, 10, 0, 0);
            actionItem100.EndDateTime = new DateTime(2012, 12, 4, 13, 0, 0);

            ActionItemDTO aiDto100 = new ActionItemDTO(actionItem100);

            ActionItem actionItem200 = ActionItemFixture.Create();
            actionItem200.Id = 200;
            actionItem200.SetStatus(ActionItemStatus.Current, UserFixture.CreateUser(), new DateTime(2012, 12, 4));
            actionItem200.Name = "200-v1";
            actionItem200.StartDateTime = new DateTime(2012, 12, 4, 10, 0, 0);
            actionItem200.EndDateTime = new DateTime(2012, 12, 4, 13, 0, 0);

            ActionItemDTO aiDto200 = new ActionItemDTO(actionItem200);

            presenter.Dtos.Clear();
            presenter.Dtos.Add(aiDto100);
            presenter.Dtos.Add(aiDto200);
            presenter.DoInitialDataLoad();

            Assert.That(presenter.Grid.Rows.Count, Is.EqualTo(2));

            actionItem200.SetStatus(ActionItemStatus.Current, UserFixture.CreateUser(), new DateTime(2012, 12, 5));
            actionItem200.Name = "200-v2";

            presenter.UpdateItem(actionItem200);
            
            Assert.That(presenter.Grid.Rows.Count, Is.EqualTo(2));
            {
                UltraGridRow ultraGridRow = presenter.Grid.FindRowById(actionItem100.Id);
                Assert.That(ultraGridRow, Is.Not.Null);
                Assert.That(ultraGridRow.ListObject, Has.Property("Name").EqualTo("100-v1"));
            }
            {
                UltraGridRow ultraGridRow = presenter.Grid.FindRowById(actionItem200.Id);
                Assert.That(ultraGridRow, Is.Not.Null);
                Assert.That(ultraGridRow.ListObject, Has.Property("Name").EqualTo("200-v2"));
            }
        }

        [Test]
        [Ignore]
        public void ShouldHandleUpdateEvent_RemoveClearedItem()
        {
            SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
            TestPresenter presenter = new TestPresenter(mockTimeService, mockFormService);
            presenter.Dtos.Clear();
            presenter.Dtos.Add(CreateDto(100));
            presenter.Dtos.Add(CreateDto(200));
            presenter.DoInitialDataLoad();

            ActionItem item = ActionItemFixture.Create();
            item.Id = 100;
            item.SetStatus(ActionItemStatus.Cleared, UserFixture.CreateUser(), new DateTime(2001, 2, 3));
            presenter.UpdateItem(item);

            Assert.AreEqual(1, presenter.Grid.Rows.Count);
            {
                ActionItemDTO row = (ActionItemDTO)presenter.Grid.Rows[0].ListObject;
                Assert.AreEqual(200, row.Id);
            }
        }

        private class TestPresenter : ActionItemPagePresenter
        {
            private readonly List<ActionItemDTO> dtos = new List<ActionItemDTO>();

            public TestPresenter(ITimeService timeService, IFormEdmontonService formService) : base(new ActionItemPage(), null, new Authorized(), null, null, null, timeService, null, formService)
            {
            }

            public DomainSummaryGrid<ActionItemDTO> Grid
            {
                get { return page.Grid; }
            }

            public List<ActionItemDTO> Dtos
            {
                get { return dtos; }
            }

            public void UpdateItem(ActionItem actionItem)
            {
                ItemUpdated(actionItem);
            }

            protected override ActionItem QueryByDto(ActionItemDTO dto)
            {
                ActionItem actionItem = ActionItemFixture.Create();
                actionItem.Id = dto.IdValue;
                return actionItem;
            }

            protected override IList<ActionItemDTO> GetDtos(Range<Date> dateRange)
            {
                return dtos;
            }

            protected override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
            {
            }

            protected override void ControlDetailButtons()
            {
            }

            protected override void SetDetailData(IActionItemDetails details, ActionItem actionItem)
            {
            }

            protected override IBackgroundHelper<Range<Date>> CreateBackgroundHelper(bool synchronous)
            {
                return new FakeBackgroundHelper<Range<Date>, DtosAndDateRange<ActionItemDTO>>(new DtoFetcher(this));
            }
        }
    }
}