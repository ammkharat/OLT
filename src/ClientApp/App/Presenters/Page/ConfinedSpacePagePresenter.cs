using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class ConfinedSpacePagePresenter : AbstractDeletableDomainPagePresenter<ConfinedSpaceDTO, ConfinedSpace, IConfinedSpaceDetails, IConfinedSpacePage>
    {
        private readonly IConfinedSpaceService confinedSpaceService;
        private readonly IReportPrintManager<ConfinedSpace> reportPrintManager;

        public ConfinedSpacePagePresenter() : this(OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT)
        {
        }

        public ConfinedSpacePagePresenter(OltGridAppearance appearance) : base(
            new ConfinedSpacePage(appearance),
            new Authorized(),
            ClientServiceRegistry.Instance.RemoteEventRepeater,
            ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
            ClientServiceRegistry.Instance.GetService<ITimeService>(),
            ClientServiceRegistry.Instance.GetService<IUserService>())
        {
            confinedSpaceService = ClientServiceRegistry.Instance.GetService<IConfinedSpaceService>();
            SubscribeToEvents();

            reportPrintManager = new ReportPrintManager<ConfinedSpace, ConfinedSpaceMontrealReport, ConfinedSpaceMontrealReportAdapter>(
                    new ConfinedSpaceMontrealPrintActions(page, confinedSpaceService));
        }

        private void SubscribeToEvents()
        {
            page.Details.Clone += Details_Clone;
            page.Details.Print += Details_Print;
            page.Details.PrintPreview += Details_PrintPreview;
        }

        protected override void UnSubscribeFromEvents()
        {
            page.Details.Clone -= Details_Clone;
            page.Details.Print -= Details_Print;
            page.Details.PrintPreview -= Details_PrintPreview;
        }

        private void Details_Clone(object sender, EventArgs e)
        {
            ConfinedSpace item = QueryForFirstSelectedItem();
            IForm form = CreateEditForm(item.CreateCopy());

            if (form != null)
            {
                form.ShowDialog(page.ParentForm);
                form.Dispose();
            }
        }

        private void Details_Print(object sender, EventArgs args)
        {
            PrintWithDialogFocus(Print);
        }

        private void Print()
        {
            reportPrintManager.PrintReport(ConvertAllTo(page.SelectedItems));
        }

        private void Details_PrintPreview(object sender, EventArgs args)
        {
            reportPrintManager.PreviewReport(QueryForFirstSelectedItem());
        }

        protected override ConfinedSpace QueryByDto(ConfinedSpaceDTO dto)
        {
            return confinedSpaceService.QueryById(dto.IdValue);
        }

        protected override IList<ConfinedSpaceDTO> GetDtos(Range<Date> dateRange)
        {
            return confinedSpaceService.QueryByFlocUnitAndBelow(userContext.RootFlocSet, new DateRange(dateRange));
        }

        protected override ConfinedSpaceDTO CreateDTOFromDomainObject(ConfinedSpace item)
        {
            return new ConfinedSpaceDTO(item);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_ConfinedSpace; }
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerConfinedSpaceCreated += repeater_Created;
            remoteEventRepeater.ServerConfinedSpaceUpdated += repeater_Updated;
            remoteEventRepeater.ServerConfinedSpaceRemoved += repeater_Removed;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerConfinedSpaceCreated -= repeater_Created;
            remoteEventRepeater.ServerConfinedSpaceUpdated -= repeater_Updated;
            remoteEventRepeater.ServerConfinedSpaceRemoved -= repeater_Removed;
        }

        protected override void ControlDetailButtons()
        {
            List<ConfinedSpaceDTO> selectedDtos = page.SelectedItems;
            bool hasSingleItemSelected = selectedDtos.Count == 1;
            bool hasItemsSelected = selectedDtos.Count > 0;

            UserRoleElements userRoleElements = userContext.UserRoleElements;

            IConfinedSpaceDetails details = page.Details;
            details.PrintEnabled = hasItemsSelected && authorized.ToPrintConfinedSpace(userRoleElements);
            details.PrintPreviewEnabled = hasSingleItemSelected && authorized.ToPrintConfinedSpace(userRoleElements);
            details.EditEnabled = hasSingleItemSelected &&
                                  authorized.ToEditConfinedSpace(userRoleElements, selectedDtos[0]);
            details.DeleteEnabled = hasItemsSelected &&
                                    authorized.ToDeleteConfinedSpace(userRoleElements, selectedDtos);
            details.CloneEnabled = hasSingleItemSelected &&
                                   authorized.ToCreateConfinedSpace(userRoleElements);
            details.ViewEditHistoryEnabled = hasSingleItemSelected;
        }

        protected override void SetDetailData(IConfinedSpaceDetails details, ConfinedSpace item)
        {
            details.SetDetails(item);
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(ConfinedSpace item)
        {
            return new ConfinedSpaceHistoryFormPresenter(item);
        }

        protected override IForm CreateEditForm(ConfinedSpace item)
        {
            ConfinedSpaceFormPresenter confinedSpaceFormPresenter = new ConfinedSpaceFormPresenter(item);
            return confinedSpaceFormPresenter.View;
        }

        protected override void Delete(ConfinedSpace item)
        {
            item.LastModifiedBy = ClientSession.GetUserContext().User;
            item.LastModifiedDateTime = Clock.Now;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(confinedSpaceService.Remove, item);
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            Date now = Clock.DateNow;
            Date start = now.SubtractDays(1);
            return new Range<Date>(start, null);
        }

        protected override bool IsItemInDateRange(ConfinedSpace confinedSpace, Range<Date> range)
        {
            if (confinedSpace.CreatedBy.Id == userContext.User.Id)
            {
                return true;
            }
            else
            {
                DateRange dateRange = new DateRange(range ?? GetDefaultDateRange());
                return dateRange.Overlaps(confinedSpace.StartDateTime, confinedSpace.EndDateTime);
            }
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.ConfinedSpace; }
        }
    }
}