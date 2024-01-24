using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class WorkPermitLubesPagePresenter :
        AbstractDeletableDomainPagePresenter
            <WorkPermitLubesDTO, WorkPermitLubes, IWorkPermitLubesDetails, IWorkPermitLubesPage>
    {
        private readonly ILogService logService;

        private readonly IReportPrintManager<WorkPermitLubes> pre418ReportPrintManager;
        private readonly IReportPrintManager<WorkPermitLubes> pre420ReportPrintManager;
        private readonly IReportPrintManager<WorkPermitLubes> reportPrintManager;
        private readonly IWorkPermitLubesService workPermitLubesService;

        public WorkPermitLubesPagePresenter() : this(OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT)
        {
        }

        public WorkPermitLubesPagePresenter(OltGridAppearance appearance)
            : base(
                new WorkPermitLubesPage(appearance),
                new Authorized(),
                ClientServiceRegistry.Instance.RemoteEventRepeater,
                ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
                ClientServiceRegistry.Instance.GetService<ITimeService>(),
                ClientServiceRegistry.Instance.GetService<IUserService>())
        {
            workPermitLubesService = ClientServiceRegistry.Instance.GetService<IWorkPermitLubesService>();
            logService = ClientServiceRegistry.Instance.GetService<ILogService>();

            page.Details.Print += HandlePrint;
            page.Details.Preview += HandlePrintPreview;
            page.Details.Close += HandleClose;
            page.Details.ViewAssociatedLogs += HandleViewAssociatedLogs;
            page.Details.Clone += HandleClone;

            pre418ReportPrintManager =
                new ReportPrintManager<WorkPermitLubes, WorkPermitLubesReport_Pre_4_18, WorkPermitLubesReportAdapter>(
                    new WorkPermitLubesPrintActions_Pre_4_18(workPermitLubesService));

            pre420ReportPrintManager =
                new ReportPrintManager<WorkPermitLubes, WorkPermitLubesReport_Pre_4_20, WorkPermitLubesReportAdapter>(
                    new WorkPermitLubesPrintActions_Pre_4_20(workPermitLubesService));

            reportPrintManager =
                new ReportPrintManager<WorkPermitLubes, WorkPermitLubesReport, WorkPermitLubesReportAdapter>(
                    new WorkPermitLubesPrintActions(workPermitLubesService));
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_WorkPermit; }
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.LubesWorkPermits; }
        }

        private void HandleClone()
        {
            var workPermit = QueryForFirstSelectedItem();
            workPermit.ConvertToClone(Clock.Now, ClientSession.GetUserContext().User);

            var form = CreateEditForm(workPermit);

            if (form != null)
            {
                form.ShowDialog(page.ParentForm);
                form.Dispose();
            }
        }

        private void HandleViewAssociatedLogs()
        {
            var logDtos = logService.QueryDTOsByWorkPermitLubes(page.FirstSelectedItem.IdValue);
            page.ShowAssociatedLogForm(logDtos);
        }

        private void HandlePrint()
        {
            PrintWithDialogFocus(Print);
        }

        private void Print()
        {
            if (!PrintIsAuthorized())
            {
                page.ShowCannotPrintMessage();
                return;
            }
            var selectedItems = page.SelectedItems;
            if (selectedItems.Any(dto => dto.Version == Common.Utility.Constants.VERSION_4_17))
            {
                LockMultipleDomainObjects(
                    permits =>
                        pre418ReportPrintManager.PrintReport(
                            permits.Where(lubes => lubes.Version == Common.Utility.Constants.VERSION_4_17).ToList()),
                    LockType.Print);
            }

            if (selectedItems.Any(dto => dto.Version == Common.Utility.Constants.VERSION_4_18 || dto.Version == Common.Utility.Constants.VERSION_4_19))
            {
                LockMultipleDomainObjects(
                    permits =>
                        pre420ReportPrintManager.PrintReport(
                            permits.Where(lubes => lubes.Version == Common.Utility.Constants.VERSION_4_18 || lubes.Version == Common.Utility.Constants.VERSION_4_19).ToList()),
                    LockType.Print);
            }

            if (selectedItems.Any(dto => dto.Version != Common.Utility.Constants.VERSION_4_17 && dto.Version != Common.Utility.Constants.VERSION_4_18 && dto.Version != Common.Utility.Constants.VERSION_4_19))
            {
                LockMultipleDomainObjects(
                    permits =>
                        reportPrintManager.PrintReport(
                            permits.Where(lubes => lubes.Version != Common.Utility.Constants.VERSION_4_17 && lubes.Version != Common.Utility.Constants.VERSION_4_18 && lubes.Version != Common.Utility.Constants.VERSION_4_19).ToList()),
                    LockType.Print);
            }
        }

        private void HandlePrintPreview()
        {
            if (!PrintIsAuthorized())
            {
                page.ShowCannotPrintMessage();
                return;
            }

            LockDatabaseObjectWhileInUse(PrintPreview, LockType.Preview);
        }

        private void PrintPreview(WorkPermitLubes workPermit)
        {
            if (workPermit.Version == Common.Utility.Constants.VERSION_4_17)
            {
                pre418ReportPrintManager.PreviewReport(workPermit);
            }
            else if (workPermit.Version == Common.Utility.Constants.VERSION_4_18 || workPermit.Version == Common.Utility.Constants.VERSION_4_19) 
            {
                pre420ReportPrintManager.PreviewReport(workPermit);
            }
            else
            {
                reportPrintManager.PreviewReport(workPermit);
            }
        }


        protected override void ControlDetailButtons()
        {
            var userRoleElements = userContext.UserRoleElements;
            var selectedItems = page.SelectedItems;
            var hasSingleItemSelected = selectedItems.Count == 1;
            var hasItemsSelected = selectedItems.Count > 0;

            var details = page.Details;

            details.DeleteEnabled = hasItemsSelected && authorized.ToDeleteWorkPermits(userRoleElements, selectedItems);
            details.EditEnabled = hasSingleItemSelected &&
                                  authorized.ToEditWorkPermit(userRoleElements, selectedItems[0]);
            details.PrintEnabled = hasItemsSelected && PrintIsAuthorized();
            details.PrintPreviewEnabled = hasSingleItemSelected && PrintIsAuthorized();
            details.CloneEnabled = hasSingleItemSelected &&
                                   (authorized.ToCloneWorkPermitWithNoRestriction(userRoleElements));
            details.ViewEditHistoryEnabled = hasSingleItemSelected;
            details.CloseEnabled = hasItemsSelected && authorized.ToCloseWorkPermits(userRoleElements, selectedItems);

            EnableViewAssociatedLogsButtonIfNecessary(hasSingleItemSelected);
        }

        private bool PrintIsAuthorized()
        {
            var selectedItems = page.SelectedItems;
            var canPrintBasedOnHasBeenIssued = selectedItems.TrueForAll(CanPrintBasedOnHasBeenIssued);

            return authorized.ToPrintWorkPermits(userContext.UserRoleElements, selectedItems) &&
                   canPrintBasedOnHasBeenIssued;
        }

        private void EnableViewAssociatedLogsButtonIfNecessary(bool hasSingleItemSelected)
        {
            page.Details.ViewAssociatedLogsEnabled = hasSingleItemSelected &&
                                                     (logService.CountOfLogsAssociatedToWorkPermitLubes(
                                                         page.FirstSelectedItem.IdValue) > 0);
        }

        private static bool CanPrintBasedOnHasBeenIssued(WorkPermitLubesDTO dto)
        {
            var permitHasExpired = dto.ExpireDateTime < Clock.Now;

            return ((PermitRequestBasedWorkPermitStatus.Pending.Equals(dto.Status) && !permitHasExpired) ||
                    dto.HasBeenIssued);
        }

        protected override void SetDetailData(IWorkPermitLubesDetails details, WorkPermitLubes item)
        {
            details.SetDetails(item);
        }

        protected override WorkPermitLubes QueryByDto(WorkPermitLubesDTO dto)
        {
            return workPermitLubesService.QueryById(dto.IdValue);
        }

        protected override IList<WorkPermitLubesDTO> GetDtos(Range<Date> dateRange)
        {
            return workPermitLubesService.QueryByDateRangeAndFlocs(dateRange, userContext.RootFlocSet);
        }

        protected override WorkPermitLubesDTO CreateDTOFromDomainObject(WorkPermitLubes item)
        {
            return new WorkPermitLubesDTO(item);
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerWorkPermitLubesCreated += repeater_Created;
            remoteEventRepeater.ServerWorkPermitLubesUpdated += repeater_Updated;
            remoteEventRepeater.ServerWorkPermitLubesRemoved += repeater_Removed;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerWorkPermitLubesCreated -= repeater_Created;
            remoteEventRepeater.ServerWorkPermitLubesUpdated -= repeater_Updated;
            remoteEventRepeater.ServerWorkPermitLubesRemoved -= repeater_Removed;
        }


        protected override EditHistoryFormPresenter CreateHistoryPresenter(WorkPermitLubes item)
        {
            return new EditWorkPermitLubesHistoryFormPresenter(item);
        }

        protected override IForm CreateEditForm(WorkPermitLubes item)
        {
            if (item.WorkPermitStatus == PermitRequestBasedWorkPermitStatus.Requested && item.Id != null &&
                !item.UsePreviousPermitAnswered)
            {
                var previousDayPermit = workPermitLubesService.QueryPreviousDayIssuedPermitForSamePermitRequest(item);
                if (previousDayPermit != null && ShouldGoAheadWithTheCopyProcess(previousDayPermit))
                {
                    previousDayPermit.CopyContentsIntoNextDayPermit(ref item);
                }
                item.UsePreviousPermitAnswered = true;
            }
            return new WorkPermitLubesFormPresenter(item).View;
        }

        private bool ShouldGoAheadWithTheCopyProcess(WorkPermitLubes permit)
        {
            var message =
                string.Format(
                    StringResources.WorkPermit_CopyFromPreviousPermit,
                    permit.PermitNumberDisplayValue, permit.IssuedDateTime.ToShortDateAndTimeStringOrEmptyString());

            var result = OltMessageBox.ShowCustomYesNo(
                page.ParentForm,
                message,
                StringResources.CopyWorkPermitFormTitle,
                MessageBoxIcon.Question,
                StringResources.Yes,
                StringResources.No);
            return result == DialogResult.Yes;
        }

        protected override void Delete(WorkPermitLubes workPermit)
        {
            workPermit.LastModifiedBy = ClientSession.GetUserContext().User;
            workPermit.LastModifiedDateTime = Clock.Now;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitLubesService.Remove,
                workPermit);
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            return DateRangeUtilities.GetDefaultDateRangeForWorkPermits(userContext.SiteConfiguration);
        }

        protected override bool IsItemInDateRange(WorkPermitLubes workPermit, Range<Date> range)
        {
            if (workPermit.LastModifiedBy.Id == userContext.User.Id)
            {
                return true;
            }
            var dateRange = new DateRange(range ?? GetDefaultDateRange());
            return dateRange.Overlaps(workPermit.StartDateTime, workPermit.ExpireDateTime);
        }

        private void HandleClose()
        {
            LockMultipleDomainObjects(Close, LockType.Close);
        }

        protected virtual void Close(List<WorkPermitLubes> permits)
        {
            var presenter = new WorkPermitLubesCloseFormPresenter(permits);
            presenter.Run(page.ParentForm);
        }
    }
}