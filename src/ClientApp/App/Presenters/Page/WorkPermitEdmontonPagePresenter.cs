﻿using System;
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
    delegate WorkPermitEdmontonFormPresenter CreateFormPresenter(WorkPermitEdmonton item);

    public class WorkPermitEdmontonPagePresenter :
        AbstractDeletableDomainPagePresenter<WorkPermitEdmontonDTO, WorkPermitEdmonton, IWorkPermitEdmontonDetails, IWorkPermitEdmontonPage>, IWorkPermitEdmontonPrintable
    {
        protected readonly IWorkPermitEdmontonService workPermitEdmontonService;
        private readonly ILogService logService;

        private readonly IReportPrintManager<WorkPermitEdmonton> reportPrintManager;

        public WorkPermitEdmontonPagePresenter() : this(PageKey.WORK_PERMIT_PAGE)
        {            
        }

        public WorkPermitEdmontonPagePresenter(PageKey pageKey) : this(OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT, pageKey)
        {
        }

        public WorkPermitEdmontonPagePresenter(OltGridAppearance appearance, PageKey pageKey)
            : base(
                new WorkPermitEdmontonPage(appearance, pageKey),
                new Authorized(),
                ClientServiceRegistry.Instance.RemoteEventRepeater,
                ClientServiceRegistry.Instance.GetService<IObjectLockingService>(),
                ClientServiceRegistry.Instance.GetService<ITimeService>(),
                ClientServiceRegistry.Instance.GetService<IUserService>())
        {
            workPermitEdmontonService = ClientServiceRegistry.Instance.GetService<IWorkPermitEdmontonService>();
            logService = ClientServiceRegistry.Instance.GetService<ILogService>();
            
            page.Details.CloseWorkPermit += CloseWorkPermit;
            page.Details.Clone += Clone;
            page.Details.Print += Print;
            page.Details.PrintPreview += PrintPreview;
            page.Details.ViewAssociatedLogs += ViewAssociatedLogs;
            page.Details.Merge += Merge;

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
            page.Details.MarkAsTemplate += MarkAsTemplate;
            page.Details.UnMarkTemplate += UnMarkTemplate;
            page.Details.RefreshAll += RefreshAll;

            page.Details.ViewAttachment += ViewAttachment;
            reportPrintManager =
                new ReportPrintManager<WorkPermitEdmonton, WorkPermitEdmontonReport, WorkPermitEdmontonReportAdapter>(new WorkPermitEdmontonPrintActions(this));
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
         
//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
            page.Details.MarkAsTemplate -= MarkAsTemplate;
            page.Details.UnMarkTemplate -= UnMarkTemplate;
            

            page.Details.RefreshAll -= RefreshAll;

        }
        
        protected override WorkPermitEdmonton QueryByDto(WorkPermitEdmontonDTO dto)
        {
            return workPermitEdmontonService.QueryById(dto.IdValue);
        }

        protected override IList<WorkPermitEdmontonDTO> GetDtos(Range<Date> dateRange)
        {
            RootFlocSet rootFlocSet = userContext.HasFlocsForWorkPermits ? userContext.RootFlocSetForWorkPermits : userContext.RootFlocSet;
            
//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
            if (page.TabText == StringResources.WorkPermitTemplates)
            {
                var username = ClientSession.GetUserContext().User.Username;
                return workPermitEdmontonService.QueryByDateRangeAndFlocsForTemplate(dateRange, rootFlocSet, username); 
            }
            else
            {
                return workPermitEdmontonService.QueryByDateRangeAndFlocsForAllButTurnaround(dateRange, rootFlocSet);
            }
        }

        protected override WorkPermitEdmontonDTO CreateDTOFromDomainObject(WorkPermitEdmonton item)
        {
            return new WorkPermitEdmontonDTO(item);
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_WorkPermit; }
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerWorkPermitEdmontonCreated += repeater_Created;
            remoteEventRepeater.ServerWorkPermitEdmontonUpdated += repeater_Updated;
            remoteEventRepeater.ServerWorkPermitEdmontonRemoved += repeater_Removed;
        }
        
        protected override void UnHookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerWorkPermitEdmontonCreated -= repeater_Created;
            remoteEventRepeater.ServerWorkPermitEdmontonUpdated -= repeater_Updated;
            remoteEventRepeater.ServerWorkPermitEdmontonRemoved -= repeater_Removed;
        }

        protected override void ControlDetailButtons()
        {
            UserRoleElements userRoleElements = userContext.UserRoleElements;
            List<WorkPermitEdmontonDTO> selectedItems = page.SelectedItems;
            WorkPermitEdmonton workPermit = QueryForFirstSelectedItem(); //Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
            IWorkPermitEdmontonDetails details = page.Details;
            bool hasSingleItemSelected = selectedItems.Count == 1;
            bool hasItemsSelected = selectedItems.Count > 0;
            bool hasMoreThanOneItemSelected = selectedItems.Count > 1;

            WorkPermitEdmontonDTO firstSelectedItem = page.FirstSelectedItem;
            bool allHaveBeenIssued = selectedItems.TrueForAll(CanPrintBasedOnHasBeenIssued);  // this should be moved to Authorized
            
            details.DeleteEnabled = hasItemsSelected && authorized.ToDeleteWorkPermits(userRoleElements, selectedItems);
            details.EditEnabled = hasSingleItemSelected && authorized.ToEditWorkPermit(userRoleElements, selectedItems[0]);
            details.PrintEnabled = hasItemsSelected && authorized.ToPrintWorkPermits(userRoleElements, selectedItems) && allHaveBeenIssued;
            details.PrintPreviewEnabled = hasSingleItemSelected && authorized.ToPrintWorkPermit(userRoleElements, firstSelectedItem) && allHaveBeenIssued;
            details.CloseEnabled = hasItemsSelected && authorized.ToCloseWorkPermits(userRoleElements, selectedItems);
            details.CloneEnabled = hasSingleItemSelected && (authorized.ToCloneWorkPermitWithNoRestriction(userRoleElements));
            details.ViewEditHistoryEnabled = hasSingleItemSelected;
            details.MergeEnabled = hasMoreThanOneItemSelected && authorized.ToCreateWorkPermits(userRoleElements);

           // DMND0010609-OLT - Edmonton Work permit Scan
            details.ViewAttachEnabled = hasSingleItemSelected && workPermitEdmontonService.GetWorkpermitScan(Convert.ToString(selectedItems[0].PermitNumber), Convert.ToInt32(userContext.Site.Id)).Count > 0;
            details.ViewScanEnabled = hasSingleItemSelected && userRoleElements.HasRoleElement(RoleElement.WORKPERMIT_SCAN);
            // End DMND0010609-OLT - Edmonton Work permit Scan

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
            details.MarkTemplateEnabled = hasSingleItemSelected &&
                                              ClientSession.GetUserContext()
                                                  .SiteConfiguration.EnableTemplateFeatureForWorkPermit &&
                                              (authorized.ToCreateWorkPermits(userRoleElements))
                                              && workPermit.PermitNumber != null; 

            details.UnMarkTemplateEnabled = false;
            details.editTemplateVisible = false;

            EnableViewAssociatedLogsButtonIfNecessary();

            
        }

        private static bool CanPrintBasedOnHasBeenIssued(WorkPermitEdmontonDTO dto)
        {
            return (PermitRequestBasedWorkPermitStatus.Pending.Equals(dto.WorkPermitStatus) || dto.HasBeenIssued);            
        }

        private void EnableViewAssociatedLogsButtonIfNecessary()
        {
            bool hasSingleItemSelected = page.SelectedItems.Count == 1;
            page.Details.ViewAssociatedLogsEnabled = hasSingleItemSelected &&
                                                     (logService.CountOfLogsAssociatedToWorkPermitEdmonton(
                                                         page.FirstSelectedItem.IdValue) > 0);
        }

        protected override void SetDetailData(IWorkPermitEdmontonDetails details, WorkPermitEdmonton item)
        {
            details.SetDetails(item);
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(WorkPermitEdmonton item)
        {
            return new EditWorkPermitEdmontonHistoryFormPresenter(item);
        }

        protected override IForm CreateEditForm(WorkPermitEdmonton item)
        {
            return CreateWorkPermitEdmontonEditForm(item, workPermitEdmonton => new WorkPermitEdmontonFormPresenter(workPermitEdmonton));
        }

        private IForm CreateWorkPermitEdmontonEditForm(WorkPermitEdmonton item, CreateFormPresenter createFormPresenter)
        {
            if (item.WorkPermitStatus == PermitRequestBasedWorkPermitStatus.Requested && item.Id != null && !item.UsePreviousPermitAnswered)
            {
                WorkPermitEdmonton previousDayPermit = workPermitEdmontonService.QueryPreviousDayIssuedPermitForSamePermitRequest(item);
                if (previousDayPermit != null && ShouldGoAheadWithTheCopyProcess(previousDayPermit))
                {
                    // copy contents of previous day permit into the current permit.                    
                    previousDayPermit.CopyContentsIntoNextDayPermit(ref item);
                }
                item.UsePreviousPermitAnswered = true;
            }
            return createFormPresenter(item).View;
        }

        private bool ShouldGoAheadWithTheCopyProcess(WorkPermitEdmonton permit)
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

        protected override void Delete(WorkPermitEdmonton workPermit)
        {
            workPermit.LastModifiedBy = ClientSession.GetUserContext().User;
            workPermit.LastModifiedDateTime = Clock.Now;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitEdmontonService.Remove, workPermit);
        }

        private DateTime GetExpiryDateTime(WorkPermitEdmonton workPermit)
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
            WorkPermitEdmonton workPermit = QueryForFirstSelectedItem();

            DateTime expiryDateTimeForClonedWorkPermit = GetExpiryDateTime(workPermit);
           // workPermit.ConvertToClone(expiryDateTimeForClonedWorkPermit);
            // Swapnil Patki For DMND0005325 Point Number 3 Start
            workPermit.ClonedFormDetailEdmonton = workPermit.PermitNumber.ToString(); // Added by Vibhor : DMND0011077 - Work Permit Clone History
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

            // only include the forms where the work permit is within the date range of the form.
            if (workPermit.FormGN59 != null &&
                (workPermit.FormGN59.IsDeleted || //(workPermit.FormGN59.FormStatus.Equals("Approved") || workPermit.FormGN59.FormStatus.Equals("Draft")) ||
                 !workPermit.FormGN59.IsWorkPermitDatesWithinFormDates(workPermit)))
            {
                formList += "GN-59" + "\n";
                DisplayMsg = Convert.ToString(workPermit.FormGN59.IdValue);
                workPermit.FormGN59 = null;
            }
            if (workPermit.FormGN7 != null &&
                (workPermit.FormGN7.IsDeleted ||// !FormGN7.FormStatus.IsOneOf(FormStatus.Draft, FormStatus.Approved) ||
                 !workPermit.FormGN7.IsWorkPermitDatesWithinFormDates(workPermit)))
            {
                formList += "GN-7" + "\n";
                DisplayMsg += Convert.ToString(workPermit.FormGN7.IdValue);
                workPermit.FormGN7 = null;
            }
            if (workPermit.FormGN24 != null &&
                (workPermit.FormGN24.IsDeleted ||// !FormGN24.FormStatus.IsOneOf(FormStatus.Draft, FormStatus.Approved) ||
                 !workPermit.FormGN24.IsWorkPermitDatesWithinFormDates(workPermit)))
            {
                formList += "GN-24" + "\n";
                DisplayMsg += Convert.ToString(workPermit.FormGN24.IdValue);
                workPermit.FormGN24 = null;
            }
            if (workPermit.FormGN6 != null &&
                (workPermit.FormGN6.IsDeleted || //!FormGN6.FormStatus.IsOneOf(FormStatus.Draft, FormStatus.Approved) ||
                 !workPermit.FormGN6.IsWorkPermitDatesWithinFormDates(workPermit)))
            {
                formList += "GN-6" + "\n";
                DisplayMsg += Convert.ToString(workPermit.FormGN6.IdValue);
                workPermit.FormGN6 = null;
            }
            if (workPermit.FormGN75A != null &&
                (workPermit.FormGN75A.IsDeleted || //!FormGN75A.FormStatus.IsOneOf(FormStatus.Draft, FormStatus.Approved) ||
                 !workPermit.FormGN75A.IsWorkPermitDatesWithinFormDates(workPermit)))
            {
                formList += "GN-75A" + "\n";
                workPermit.FormGN75A = null;
            }
            if (workPermit.FormGN1 != null &&
                (workPermit.FormGN1.IsDeleted || //!FormGN1.FormStatus.IsOneOf(FormStatus.Draft, FormStatus.Approved) ||
                 !workPermit.FormGN1.IsWorkPermitDatesWithinFormDates(workPermit)))
            {
                formList += "GN-1" + "\n";
                DisplayMsg += workPermit.FormGN1.TradeChecklistNames;
                workPermit.FormGN1 = null;
                workPermit.FormGN1TradeChecklistDisplayNumber = null;
                workPermit.FormGN1TradeChecklistId = null;
                // don't clone these when the FormGN1 is selected, but that existing FormGN1 can't be cloned.
                workPermit.RescuePlanFormNumber = null;
                workPermit.ConfinedSpaceCardNumber = null;
                
            }

            workPermit.IssuedDateTime = null;
            workPermit.IssuedByUser = null;

            if (formList != string.Empty) //if (DisplayMsg != null)
            {
                //DialogResult est = OltMessageBox.Show(page.ParentForm,
                //    "Forms" + DisplayMsg +
                //    " is/are either Deleted or Expired. If Do You Want to Continue Click Yes Else No. ", "Messege",
                //    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                DialogResult est = OltMessageBox.Show(page.ParentForm,
                    "Following forms were not extended as they have expired\n\n" + formList +
                    "\nDo You Want to continue.", "Messege",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (est.Equals(DialogResult.Yes))
                {
                    IForm form1 = CreateWorkPermitEdmontonEditForm(workPermit,
                        WorkPermitEdmontonFormPresenter.CreateForClone);
                    if (form1 != null)
                    {
                        form1.ShowDialog(page.ParentForm);
                        form1.Dispose();
                    }
                }
            } // Swapnil Patki For DMND0005325 Point Number 3 End
            else
            {

                IForm form = CreateWorkPermitEdmontonEditForm(workPermit,
                    WorkPermitEdmontonFormPresenter.CreateForClone);

                if (form != null)
                {
                    form.ShowDialog(page.ParentForm);
                    form.Dispose();
                }
            }
        }

        private void CloseWorkPermit(object sender, EventArgs e)
        {
            LockMultipleDomainObjects(Close, LockType.Close);
        }

        private void Close(List<WorkPermitEdmonton> permits)
        {
            WorkPermitEdmontonCloseFormPresenter presenter = new WorkPermitEdmontonCloseFormPresenter(permits);
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

        private void PrintPreview(WorkPermitEdmonton workPermitEdmonton)
        {
            reportPrintManager.PreviewReport(workPermitEdmonton);
        }

        protected override bool IsItemInDateRange(WorkPermitEdmonton item, Range<Date> range)
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

        protected override bool ShouldBeDisplayed(WorkPermitEdmonton item)
        {
            return item.Group == null || (!item.Group.SAPImportPriorityList.Contains(WorkOrderPriority.P3.IdValue) && !item.Group.SAPImportPriorityList.Contains(WorkOrderPriority.P4.IdValue));
        }

        private void ViewAssociatedLogs(object sender, EventArgs e)
        {
            List<LogDTO> logDtos = logService.QueryDTOsByWorkPermitEdmonton(page.FirstSelectedItem.IdValue);
            page.ShowAssociatedLogForm(logDtos);
        }

        private void Merge(object sender, EventArgs e)
        {
            List<WorkPermitEdmontonDTO> selectedItems = page.SelectedItems;
            List<WorkPermitEdmonton> permits = new List<WorkPermitEdmonton>();

            foreach (WorkPermitEdmontonDTO permitDto in selectedItems)
            {
                WorkPermitEdmonton permit = workPermitEdmontonService.QueryById(permitDto.IdValue);
                permits.Add(permit);
            }

            WorkPermitEdmontonMergeTool mergeTool = new WorkPermitEdmontonMergeTool(ClientSession.GetUserContext().User);
            WorkPermitEdmonton mergedPermit = mergeTool.Merge(permits);

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

            WorkPermitEdmontonFormPresenter presenter = new WorkPermitEdmontonFormPresenter(mergedPermit, mergeSourceIDs);
            IForm form = presenter.View;

            if (form != null)
            {
                form.ShowDialog(page.ParentForm);
                form.Dispose();
            }
        }

        public void ShowUnableToPrintWithExpiryDateInPastMessage()
        {
            page.DisplayErrorMessageDialog(StringResources.WorkPermitEdmonton_UnableToPrintWithExpiryDateInPast, StringResources.WorkPermitEdmonton_UnableToPrintWithExpiryDateInPastDialogTitle);
        }

        public void UpdateWorkPermit(WorkPermitEdmonton permit)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitEdmontonService.Update, permit);
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
            get { return UserGridLayoutIdentifier.EdmontonRunningUnitWorkPermits; }
        }




        private void ViewAttachment(object sender, EventArgs e)
        {

            WorkPermitEdmonton workPermit = QueryForFirstSelectedItem();
            List<WorkpermitScan> lst = workPermitEdmontonService.GetWorkpermitScan(Convert.ToString(workPermit.PermitNumber), Convert.ToInt32(userContext.Site.Id));
            WorkPermitAttachment AttachementForm = new WorkPermitAttachment(lst);
           
            if (lst != null && lst.Count > 0)
            {
              
                AttachementForm.ShowDialog();
            }
            //workPermit.Id
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        private void MarkAsTemplate(object sender, EventArgs e)
        {
            bool isWorkPermit = true;
            MarkAsTemplateNameForm nameForm = new MarkAsTemplateNameForm(isWorkPermit);
            nameForm.ShowDialog();
            //MarkAsTemplateNameFormPresenter presenter_template = new MarkAsTemplateNameFormPresenter(nameForm);

            WorkPermitEdmonton workPermit = QueryForFirstSelectedItem();
            workPermit.TemplateName = nameForm.WorkPermitTemplateName;
            workPermit.Categories = nameForm.Category;
            workPermit.Global = nameForm.Global;
            workPermit.Individual = nameForm.Individual;

            //workPermit.TemplateName = presenter_template.WpTemplatename;
            //workPermit.Categories = presenter_template.category;
            //workPermit.Global = presenter_template.global;
            //workPermit.Individual = presenter_template.individual;
           
            var wp = workPermitEdmontonService.QueryByIdTemplate(workPermit.IdValue, workPermit.TemplateName, workPermit.Categories);

            if (wp != null)
            {
                if (workPermit.TemplateName == wp._templateName && workPermit.Categories == wp._categories)
                {
                    //nameForm.Error = true;
                    OltMessageBox.ShowError("Same Template Name and Category entry is already present. " +
                                           "Cannot proceed further, please change the Temlate name and Category");

                }
            }
            else
            {
                if (workPermit.TemplateName != string.Empty && nameForm.Save == true)
                {
                    workPermit.IsTemplate = true;
                    workPermit.TemplateCreatedBy = ClientSession.GetUserContext().User.Username;
                    ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitEdmontonService.Update, workPermit);
                }
                else
                {
                    workPermit.IsTemplate = false;
                }
            }

        }

        private void UnMarkTemplate(object sender, EventArgs e)
        {
            //WorkPermitEdmonton workPermit = QueryForFirstSelectedItem();

            //if (workPermit.IsTemplate)
            //{
            //    workPermit.IsTemplate = false;
            //    workPermit.TemplateName = "";
            //}
            //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitEdmontonService.Update, workPermit);
        }

        private void RefreshAll(object sender, EventArgs e)
        {
            RefreshData();
        }

    }
}