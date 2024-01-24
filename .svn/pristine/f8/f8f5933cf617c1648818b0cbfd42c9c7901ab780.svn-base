using System;
using System.Collections.Generic;
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
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    delegate WorkPermitFortHillsFormPresenter CreateFormPresenterFH(WorkPermitFortHills item);

    public class WorkPermitFortHillsPagePresenter :
        AbstractDeletableDomainPagePresenter<WorkPermitFortHillsDTO, WorkPermitFortHills, IWorkPermitFortHillsDetails, IWorkPermitFortHillsPage>, IWorkPermitFortHillsPrintable
    {
        protected readonly IWorkPermitFortHillsService workPermitFortHillsService;
        //private readonly ILogService logService;
        
        private readonly IWorkPermitFortHillsService service;
        private readonly IReportPrintManager<WorkPermitFortHills> reportPrintManager;

        public WorkPermitFortHillsPagePresenter() : this(PageKey.WORK_PERMIT_PAGE)
        {            
        }

        public WorkPermitFortHillsPagePresenter(PageKey pageKey) : this(OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT, pageKey)
        {
        }

        public WorkPermitFortHillsPagePresenter(OltGridAppearance appearance, PageKey pageKey)
            : base(
                new WorkPermitFortHillsPage(appearance, pageKey),
                new Authorized(),
                ClientServiceRegistry.Instance.RemoteEventRepeater,
                ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
                ClientServiceRegistry.Instance.GetService<ITimeService>(),
                ClientServiceRegistry.Instance.GetService<IUserService>())
        {
            workPermitFortHillsService = ClientServiceRegistry.Instance.GetService<IWorkPermitFortHillsService>();
            
            page.Details.CloseWorkPermit += CloseWorkPermit;
            page.Details.Clone += Clone;
            page.Details.Extension += ExtensionWorkpermit;
            page.Details.Revalidation += RevalidationWorkpermit;
            page.Details.Print += Print;
            page.Details.PrintPreview += PrintPreview;
            page.Details.ViewAssociatedLogs += ViewAssociatedLogs;
            page.Details.Merge += Merge;

            reportPrintManager =
                new ReportPrintManager<WorkPermitFortHills, WorkPermitFortHillsReport, WorkPermitFortHillsReportAdapter>(new WorkPermitFortHillsPrintActions(this));
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Details.CloseWorkPermit -= CloseWorkPermit;
            page.Details.Clone -= Clone;
            page.Details.PrintPreview -= PrintPreview;
            page.Details.Print -= Print;
            page.Details.ViewAssociatedLogs -= ViewAssociatedLogs;
            page.Details.Merge -= Merge;
            page.Details.Extension -= ExtensionWorkpermit;
            page.Details.Revalidation -= RevalidationWorkpermit;
        }
        
        protected override WorkPermitFortHills QueryByDto(WorkPermitFortHillsDTO dto)
        {
            return workPermitFortHillsService.QueryById(dto.IdValue);
        }

        protected override IList<WorkPermitFortHillsDTO> GetDtos(Range<Date> dateRange)
        {
            RootFlocSet rootFlocSet = userContext.HasFlocsForWorkPermits ? userContext.RootFlocSetForWorkPermits : userContext.RootFlocSet;
            return workPermitFortHillsService.QueryByDateRangeAndFlocsForAllButTurnaround(dateRange, rootFlocSet);
        }

        protected override WorkPermitFortHillsDTO CreateDTOFromDomainObject(WorkPermitFortHills item)
        {
            return new WorkPermitFortHillsDTO(item);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_WorkPermit; }
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerWorkPermitFortHillsCreated += repeater_Created;
            remoteEventRepeater.ServerWorkPermitFortHillsUpdated += repeater_Updated;
            remoteEventRepeater.ServerWorkPermitFortHillsRemoved += repeater_Removed;
        }
        
        protected override void UnHookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerWorkPermitFortHillsCreated -= repeater_Created;
            remoteEventRepeater.ServerWorkPermitFortHillsUpdated -= repeater_Updated;
            remoteEventRepeater.ServerWorkPermitFortHillsRemoved -= repeater_Removed;
        }

        protected override void ControlDetailButtons()
        {
            UserRoleElements userRoleElements = userContext.UserRoleElements;
            List<WorkPermitFortHillsDTO> selectedItems = page.SelectedItems;
            IWorkPermitFortHillsDetails details = page.Details;
            bool hasSingleItemSelected = selectedItems.Count == 1;
            bool hasItemsSelected = selectedItems.Count > 0;
            bool hasMoreThanOneItemSelected = selectedItems.Count > 1;

            WorkPermitFortHillsDTO firstSelectedItem = page.FirstSelectedItem;
            bool allHaveBeenIssued = selectedItems.TrueForAll(CanPrintBasedOnHasBeenIssued);  // this should be moved to Authorized
            
            details.DeleteEnabled = hasItemsSelected && authorized.ToDeleteWorkPermits(userRoleElements, selectedItems);
            details.EditEnabled = hasSingleItemSelected && authorized.ToEditWorkPermit(userRoleElements, selectedItems[0]);
            details.PrintEnabled = hasItemsSelected && authorized.ToPrintWorkPermits(userRoleElements, selectedItems) && allHaveBeenIssued;
            details.PrintPreviewEnabled = hasSingleItemSelected && authorized.ToPrintWorkPermit(userRoleElements, firstSelectedItem) && allHaveBeenIssued;
            details.CloseEnabled = hasItemsSelected && authorized.ToCloseWorkPermits(userRoleElements, selectedItems);
            details.CloneEnabled = hasSingleItemSelected && (authorized.ToCloneWorkPermitWithNoRestriction(userRoleElements));
            details.ViewEditHistoryEnabled = hasSingleItemSelected;
           // details.MergeEnabled = hasMoreThanOneItemSelected && authorized.ToCreateWorkPermits(userRoleElements);

            EnableViewAssociatedLogsButtonIfNecessary();
            details.ViewAssociatedLogsEnabled = false;
            if (hasSingleItemSelected)
            {
                details.ExtensionEnable = selectedItems.TrueForAll(PermitHasBeenIssued) &&
                                          !selectedItems.TrueForAll(Isworkpermitexpired) &&
                                          !selectedItems.TrueForAll(PermitHasBeenExtended);
                details.RevalidationButtonEnable = selectedItems.TrueForAll(PermitHasBeenIssued) &&
                                                   !selectedItems.TrueForAll(Isworkpermitexpired) && !selectedItems.TrueForAll(Isworkpermitexpiredforrevalidation);
            }
            else
            {
                details.ExtensionEnable = hasSingleItemSelected;
                details.RevalidationButtonEnable = hasSingleItemSelected;
            }
        }

        private static bool CanPrintBasedOnHasBeenIssued(WorkPermitFortHillsDTO dto)
        {
            return (PermitRequestBasedWorkPermitStatus.Pending.Equals(dto.WorkPermitStatus) || dto.HasBeenIssued);            
        }
        private static bool Isworkpermitexpired(WorkPermitFortHillsDTO dto)
        {
           return dto.EndDateTime < Clock.Now; 
        }
        private static bool Isworkpermitexpiredforrevalidation(WorkPermitFortHillsDTO dto)
        {
            return (dto.ExtensionDateTime != null) ? dto.ExtensionDateTime < Clock.Now : dto.EndDateTime < Clock.Now;
            //if (dto.ExtensionDateTime != null) { return dto.ExtensionDateTime < Clock.Now; }
            //else { return dto.EndDateTime < Clock.Now; } 
        }
        private static bool PermitHasBeenIssued(WorkPermitFortHillsDTO dto)
        {
            return (PermitRequestBasedWorkPermitStatus.Issued.Equals(dto.WorkPermitStatus));
        }
        private static bool PermitHasBeenCompleted(WorkPermitFortHillsDTO dto)
        {
            return (PermitRequestBasedWorkPermitStatus.Complete.Equals(dto.WorkPermitStatus));
        }
        private static bool PermitHasBeenExtended(WorkPermitFortHillsDTO dto)
        {
            return (dto.ExtensionDateTime != null);
        }

        private void EnableViewAssociatedLogsButtonIfNecessary()
        {
           /* bool hasSingleItemSelected = page.SelectedItems.Count == 1;
            
            page.Details.ViewAssociatedLogsEnabled = hasSingleItemSelected &&
                                                     (logService.CountOfLogsAssociatedToWorkPermitEdmonton(
                                                         page.FirstSelectedItem.IdValue) > 0);*/
        }

        protected override void SetDetailData(IWorkPermitFortHillsDetails details, WorkPermitFortHills item)
        {
            details.SetDetails(item);
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(WorkPermitFortHills item)
        {
            return new EditWorkPermitFortHillsHistoryFormPresenter(item);
        }
         
        protected override IForm CreateEditForm(WorkPermitFortHills item)
        {
            return CreateWorkPermitFortHillsEditForm(item, workPermitFortHills => new WorkPermitFortHillsFormPresenter(workPermitFortHills));
        }

        private IForm CreateWorkPermitFortHillsEditForm(WorkPermitFortHills item, CreateFormPresenterFH createFormPresenter)
        {
            if (item.WorkPermitStatus == PermitRequestBasedWorkPermitStatus.Requested && item.Id != null )//&& !item.UsePreviousPermitAnswered
            {
                WorkPermitFortHills previousDayPermit = workPermitFortHillsService.QueryPreviousDayIssuedPermitForSamePermitRequest(item);
                if (previousDayPermit != null && ShouldGoAheadWithTheCopyProcess(previousDayPermit))
                {
                    // copy contents of previous day permit into the current permit.                    
                    previousDayPermit.CopyContentsIntoNextDayPermit(ref item);
                }
               // item.UsePreviousPermitAnswered = true;
            }
            return createFormPresenter(item).View;
        }

        private bool ShouldGoAheadWithTheCopyProcess(WorkPermitFortHills permit)
        {            
            string message =
                string.Format(
                    StringResources.WorkPermit_CopyFromPreviousPermit,
                    permit.PermitNumber, permit.IssuedDateTime.ToShortDateAndTimeStringOrEmptyString());

            DialogResult result = OltMessageBox.ShowCustomYesNo(
                page.ParentForm,
                message,
                StringResources.CopyWorkPermitFormTitle,
                MessageBoxIcon.Question,
                StringResources.Yes,
                StringResources.No);
            return result == DialogResult.Yes;
        }

        protected override void Delete(WorkPermitFortHills workPermit)
        {
            workPermit.LastModifiedBy = ClientSession.GetUserContext().User;
            workPermit.LastModifiedDateTime = Clock.Now;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitFortHillsService.Remove, workPermit);
        }

        private DateTime GetExpiryDateTime(WorkPermitFortHills workPermit)
        {
            DateTime? expiryFromSessionStore = SessionStore.GetEdmontonWorkPermitExpiryFromSessionStore();
            if (expiryFromSessionStore.HasValue)
            {
                return expiryFromSessionStore.Value;
            }
            return workPermit.GetDefaultExpiryDateTimeBasedOnGroup(userContext.UserShift);
        }

        private void Clone(object sender, EventArgs e)
        {
            WorkPermitFortHills workPermit = QueryForFirstSelectedItem();

            DateTime expiryDateTimeForClonedWorkPermit = GetExpiryDateTime(workPermit);

            workPermit.ClonedFormDetailFortHills = workPermit.PermitNumber.ToString(); // Added by Vibhor : DMND0011077 - Work Permit Clone History

           // workPermit.ConvertToClone(expiryDateTimeForClonedWorkPermit);
            // Swapnil Patki For DMND0005325 Point Number 3 Start
            workPermit.ConvertToCloneNew();
            string DisplayMsg = null;
            string formList = string.Empty;  //manngesh - clone work permit
            workPermit.Id = null;
            workPermit.PermitNumber = null;
            workPermit.LastModifiedBy = null;
            workPermit.LastModifiedDateTime = Clock.Now;

            //Dharmesh -- Start -- 6Jul2017 for INC0165740 (OLT - Clone / Copy issues with Logs and Work permits)
            //workPermit.DocumentLinks.Clear();
            //Dharmesh end 6Jul2017
            
            workPermit.UseCurrentPermitNumberForZeroEnergyFormNumber = false;

            workPermit.RequestedStartDateTime = Clock.Now;
            workPermit.ExpiredDateTime = expiryDateTimeForClonedWorkPermit;

           
            workPermit.IssuedDateTime = null;
            workPermit.IssuedByUser = null;

            {

                IForm form = CreateWorkPermitFortHillsEditForm(workPermit,
                    WorkPermitFortHillsFormPresenter.CreateForClone);

                if (form != null)
                {
                    form.ShowDialog(page.ParentForm);
                    form.Dispose();
                }
            }
        }

        private void ExtensionWorkpermit(object sender, EventArgs e)
        {
            WorkPermitFortHills workPermit = QueryForFirstSelectedItem();
            IForm form = CreateWorkPermitFortHillsEditForm(workPermit,
                WorkPermitFortHillsFormPresenter.CreateForExtension);
            if (form != null)
            {
                form.ShowDialog(page.ParentForm);
                form.Dispose();
            }
        }

        private void RevalidationWorkpermit(object sender, EventArgs e)
        {
            WorkPermitFortHills workPermit = QueryForFirstSelectedItem();
            workPermit.RevalidationDateTime = Clock.Now;
            //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, workPermit);
            UpdateWorkPermit(workPermit);
            Print();
        }

        private void CloseWorkPermit(object sender, EventArgs e)
        {
            LockMultipleDomainObjects(Close, LockType.Close);
        }

        private void Close(List<WorkPermitFortHills> permits)
        {
            WorkPermitFortHillsCloseFormPresenter presenter = new WorkPermitFortHillsCloseFormPresenter(permits);
            presenter.Run(page.ParentForm);
        }

        private void Print(object sender, EventArgs e)
        {
            PrintWithDialogFocus(Print);
        }

        private void Print()
        {
            LockMultipleDomainObjects(permits => reportPrintManager.PrintReport(permits), LockType.Print);
        }

        private void PrintPreview(object sender, EventArgs args)
        {
            LockDatabaseObjectWhileInUse(PrintPreview, LockType.Preview);
        }

        private void PrintPreview(WorkPermitFortHills workPermitFortHills)
        {
            reportPrintManager.PreviewReport(workPermitFortHills);
        }

        protected override bool IsItemInDateRange(WorkPermitFortHills item, Range<Date> range)
        {
            if (item.CreatedBy.Id == userContext.User.Id)
            {
                return true;
            }
            DateRange theRange = new DateRange(range ?? GetDefaultDateRange());
            return theRange.Overlaps(item.RequestedStartDateTime, item.ExpiredDateTime);
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            return DateRangeUtilities.GetDefaultDateRangeForWorkPermits(userContext.SiteConfiguration);
        }

        protected override bool ShouldBeDisplayed(WorkPermitFortHills item)
        {
            return item.Group == null || (!item.Group.SAPImportPriorityList.Contains(WorkOrderPriority.P3.IdValue) && !item.Group.SAPImportPriorityList.Contains(WorkOrderPriority.P4.IdValue));
        }

        private void ViewAssociatedLogs(object sender, EventArgs e)
        {
            //List<LogDTO> logDtos = logService.QueryDTOsByWorkPermitEdmonton(page.FirstSelectedItem.IdValue);
            //page.ShowAssociatedLogForm(logDtos);
        }

        private void Merge(object sender, EventArgs e)
        {   /* DMND0009632 - Fort Hills OLT - E-Permit Development */
            /*
            List<WorkPermitFortHillsDTO> selectedItems = page.SelectedItems;
            List<WorkPermitFortHills> permits = new List<WorkPermitFortHills>();

            foreach (WorkPermitFortHillsDTO permitDto in selectedItems)
            {
                WorkPermitFortHills permit = workPermitFortHillsService.QueryById(permitDto.IdValue);
                permits.Add(permit);
            }

            WorkPermitFortHillsMergeTool mergeTool = new WorkPermitFortHillsMergeTool(ClientSession.GetUserContext().User);
            WorkPermitFortHills mergedPermit = mergeTool.Merge(permits);

            bool goAhead = true;

            if (mergeTool.HasIncompatibleFunctionalLocations)
            {
                page.DisplayInvalidMergeDueToFunctionalLocationMessage();
                goAhead = false;
            }
            else if (mergeTool.HasIncompatibleFields)
            {
                goAhead = page.DisplayInvalidMergeDueToParticularFieldsMessage(mergeTool.IncompatibleFieldNames);
            }

            if (!goAhead)
            {
                return;
            }

            List<long> mergeSourceIDs = selectedItems.ConvertAll(thing => thing.IdValue);

            WorkPermitFortHillsFormPresenter presenter = new WorkPermitFortHillsFormPresenter(mergedPermit, mergeSourceIDs);
            IForm form = presenter.View;

            if (form != null)
            {
                form.ShowDialog(page.ParentForm);
                form.Dispose();
            }
            */
        }

        public void ShowUnableToPrintWithExpiryDateInPastMessage()
        {
            page.DisplayErrorMessageDialog(StringResources.WorkPermitEdmonton_UnableToPrintWithExpiryDateInPast, StringResources.WorkPermitEdmonton_UnableToPrintWithExpiryDateInPastDialogTitle);
        }

        public void UpdateWorkPermit(WorkPermitFortHills permit)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitFortHillsService.Update, permit);
        }

        public void ShowPrintingFailedMessage()
        {
            page.DisplayInvalidPrintMessage(StringResources.WorkPermitPrintFailureMessageBoxText);
        }

        public bool? AskIfTheyWantToPrintTheForms()
        {
            return page.AskIfTheyWantToPrintTheForms();
        }

        public bool IsOnlyPrintingOnePermit { get; set; }
        public bool ShouldNotPrintForms { get; set; }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.FortHillsRunningUnitWorkPermits; }
        } 
       
    }
}