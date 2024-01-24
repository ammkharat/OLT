using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using log4net;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public class TemporaryInstallationsFormContext :
        AbstractEdmontonFormContext<TemporaryInstallationsMudsDTO, TemporaryInstallationsMUDS, FormTemporaryInstallationsDetails>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (EdmontonOP14FormContext));
        private readonly IReportPrintManager<TemporaryInstallationsMUDS> reportPrintManager;
        private readonly WindowsFormsSynchronizationContext synchronizationContext;
        private readonly MudsTemporaryInstallationsTimerManager timerManager;

        public TemporaryInstallationsFormContext(IFormEdmontonService formService, AbstractMultiGridPage page)
            : base(
                formService, page, EdmontonFormType.TemporaryInstallationsMuds, new FormTemporaryInstallationsDetails(),
                new MudsTemporaryInstallationFormGridRenderer())
        {
            PrintActions<TemporaryInstallationsMUDS, FormMudsTemporaryInstallationReport, FormMudsTemporaryInstallationsReportAdapter> printActions =
                new MudsTemporaryInstallationFormPrintActions();
            reportPrintManager =
                new ReportPrintManager<TemporaryInstallationsMUDS, FormMudsTemporaryInstallationReport, FormMudsTemporaryInstallationsReportAdapter>(printActions);

            synchronizationContext = (WindowsFormsSynchronizationContext) SynchronizationContext.Current;
            timerManager = new MudsTemporaryInstallationsTimerManager();
            page.Disposed += HandlePageDisposed;
        }

        public override bool IsItemSelected
        {
            get { return grid.SelectedItem != null; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_FormMudsTemporaryInstallations; }
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.FormMudsTemporaryInstallation; }
        }

        protected override IReportPrintManager<TemporaryInstallationsMUDS> ReportPrintManager
        {
            get { return reportPrintManager; }
        }

        private void HandlePageDisposed(object sender, EventArgs eventArgs)
        {
            if (timerManager != null)
            {
                timerManager.Clear();
            }
        }

        public override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();
            page.Disposed -= HandlePageDisposed;
        }

        protected override TemporaryInstallationsMudsDTO CreateDtoFromDomainObject(TemporaryInstallationsMUDS item)
        {
            return (TemporaryInstallationsMudsDTO)item.CreateDTO();
        }

        public override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerMudsTemporaryInstallationsFormCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerMudsTemporaryInstallationsFormUpdated += HandleRepeaterUpdated;
            remoteEventRepeater.ServerMudsTemporaryInstallationsFormRemoved += HandleRepeaterRemoved;
        }

        protected override void HandleRepeaterCreated(object sender, DomainEventArgs<TemporaryInstallationsMUDS> e)
        {
            if (page != null && !page.IsDisposed)
            {
                if (e.SelectedItem != null)
                {
                    RegisterRenderTimer(CreateDtoFromDomainObject(e.SelectedItem));
                }
            }
            base.HandleRepeaterCreated(sender, e);
        }

        protected override void HandleRepeaterUpdated(object sender, DomainEventArgs<TemporaryInstallationsMUDS> e)
        {
            if (page != null && !page.IsDisposed)
            {
                if (e.SelectedItem != null)
                {
                    RegisterRenderTimer(CreateDtoFromDomainObject(e.SelectedItem));
                }
            }
            base.HandleRepeaterUpdated(sender, e);
        }

        public override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerMudsTemporaryInstallationsFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerMudsTemporaryInstallationsFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerMudsTemporaryInstallationsFormRemoved -= HandleRepeaterRemoved;
        }

        public override void SetDetailData(FormTemporaryInstallationsDetails details, TemporaryInstallationsMUDS form)
        {
            details.WorkPermitEdmontonSectionVisible = false;

            details.ValidFromDateTimeLabel = StringResources.FormMontrealCsd_SystemDefeated + ":";
            details.ValidToDateTimeLabel = StringResources.FormMontrealCsd_EstimatedBackInService + ":";

            if (form == null)
            {
                details.ValidFromDateTime = null;
                details.ValidToDateTime = null;
                details.CreatedByUser = null;
                details.CreatedDateTime = null;
                details.LastModifiedByUser = null;
                details.LastModifiedDateTime = null;
                details.FunctionalLocations = null;
                details.Approvals = null;
                details.Content = null;
                details.FormNumber = null;
                details.ClosedDateTime = null;
                details.ApprovedDateTime = null;
                details.WorkPermitEdmontonDTOs = null;
                details.HasAttachments = null;
                details.HasBeenCommunicated = null;
                details.CsdReason = null;
                details.DocumentLinks = null;
                details.IsTheCSDForAPressureSafetyValve = null;
                details.CriticalSystemDefeated = null;
                return;
            }

            details.CreatedByUser = form.CreatedBy;
            details.CreatedDateTime = form.CreatedDateTime;

            details.LastModifiedByUser = form.LastModifiedBy;
            details.LastModifiedDateTime = form.LastModifiedDateTime;

            details.Content = form.Content;

            details.ValidFromDateTime = form.FromDateTime;
            details.ValidToDateTime = form.ToDateTime;
            details.FunctionalLocations = form.FunctionalLocations;
            details.Approvals = form.EnabledApprovals;

            details.FormNumber = form.FormNumber;
            details.ClosedDateTime = form.ClosedDateTime;
            details.ApprovedDateTime = form.ApprovedDateTime;
            details.DocumentLinks = form.DocumentLinks;
            details.HasAttachments = form.HasAttachments;
            details.HasBeenCommunicated = form.HasBeenCommunicated;
            details.IsTheCSDForAPressureSafetyValve = form.IsTheCSDForAPressureSafetyValve;
            details.CriticalSystemDefeated = form.CriticalSystemDefeated;
            details.CsdReason = form.CsdReason;

            details.AdjustTextBoxHeights();
        }

        public override void ControlDetailButtons()
        {
            //base.ControlDetailButtons();

            var userRoleElements = userContext.UserRoleElements;
            var selectedItems = GetSelectedItems();
            var hasAtLeastOneItemSelected = selectedItems.Count > 0;
            var hasSingleItemSelected = selectedItems.Count == 1;
            FormStatus formStatus = hasAtLeastOneItemSelected ? selectedItems[0].Status : null;

            bool hasEdit = authorized.ToEditMudsTemporaryInstallations(userRoleElements, formStatus);
            bool hasCreate = authorized.ToCreateMudsTemporaryInstallationsForm(userRoleElements);
            bool hasApproveOrClose = authorized.ToApproveOrCloseMudsTemporaryInstallationsForms(userRoleElements);
            bool hasDelete = authorized.ToDeleteMudsTemporaryInstallations(userRoleElements) && FormStatus.Draft.Equals(formStatus);
            
            details.ViewEditHistoryEnabled = hasSingleItemSelected;
            details.EditEnabled = hasSingleItemSelected && hasEdit;
            details.DeleteEnabled = hasSingleItemSelected && hasDelete;
            details.CloneEnabled = hasSingleItemSelected && hasCreate;
            details.CloseEnabled = hasAtLeastOneItemSelected && hasApproveOrClose &&
                                   selectedItems.TrueForAll(
                                       item =>
                                           FormStatus.Draft.Equals(item.Status) ||
                                           FormStatus.Approved.Equals(item.Status) ||
                                           FormStatus.Expired.Equals(item.Status) ||
                                           FormStatus.WaitingForApproval.Equals(item.Status));
            details.PrintPreviewEnabled = hasSingleItemSelected;
            details.EmailEnabled = hasSingleItemSelected && (formStatus != FormStatus.Approved && formStatus != FormStatus.Closed);
            details.PrintButtonVisible = false;
            details.PrintVisible = false;
            details.EmailVisible = false;

            bool isSameUser = false;
            if (hasAtLeastOneItemSelected)
            {
                isSameUser = userContext.User.IdValue == selectedItems[0].CreatedByUserId;
            }
            if (!hasEdit && hasSingleItemSelected && hasCreate && isSameUser)
            {
                details.EditEnabled = true;
            }
            else if (details.CloseEnabled)
            {
                details.EditEnabled = true;
            }

            //details.DeleteEnabled = hasAtLeastOneItemSelected && authorized.ToDeleteMudsTemporaryInstallations(userRoleElements, selectedItems);
            //details.EditEnabled = hasSingleItemSelected && authorized.ToEditMudsTemporaryInstallations(userRoleElements, selectedItems[0].Status);
            //details.EmailEnabled = hasSingleItemSelected && (selectedItems[0].Status != FormStatus.Approved && selectedItems[0].Status != FormStatus.Closed);
            //details.CloneEnabled = hasSingleItemSelected && authorized.ToCreateMudsTemporaryInstallationsForm(userRoleElements);
            //details.CloseEnabled = hasAtLeastOneItemSelected && authorized.ToApproveOrCloseMudsTemporaryInstallationsForms(userRoleElements, selectedItems);
            //details.PrintButtonVisible = false;
            //details.PrintVisible = false;
            //details.EmailVisible = false;
            //details.PrintPreviewVisible = false;
        }

        public override IList<TemporaryInstallationsMudsDTO> GetData(RootFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            var montrealCsdDtos = formService.QueryMudsTemporaryInstallationsDTOs(flocSet,
                dateRange,
                formStatuses,
                includeAllDraftFormsRegardlessOfDateRange);
            timerManager.Clear();
            montrealCsdDtos.ForEach(RegisterRenderTimer);
            return montrealCsdDtos;
        }

        private void RegisterRenderTimer(TemporaryInstallationsMudsDTO dto)
        {
            timerManager.Unregister(dto);
            var now = Clock.Now;

            // this will never auto change its grouping
            if (dto.ValidTo < now) return;

            if (dto.ValidFrom > now)
            {
                var timeUntilActive = dto.ValidFrom.Subtract(now);
                SetupTimerCallback(timeUntilActive, dto);
            }
            else
            {
                var timeUntilRequiresApprovalOrExpires = dto.ValidTo.Subtract(now);
                SetupTimerCallback(timeUntilRequiresApprovalOrExpires, dto);
            }
        }

        private void SetupTimerCallback(TimeSpan differenceInTime, TemporaryInstallationsMudsDTO dto)
        {
            var timeRemainingInShift = ClientSession.GetInstance().GetTimeRemainingInShiftWithPostShiftPadding();
            if (differenceInTime < timeRemainingInShift)
            {
                SetupTimerForCallback(dto, differenceInTime);
            }
        }

        private void SetupTimerForCallback(TemporaryInstallationsMudsDTO dto, TimeSpan differenceInTime)
        {
            try
            {
                timerManager.RegisterTimer(dto, differenceInTime, HandleTimerFire);
            }
            catch (TimerDueTimeNegativeException e)
            {
                logger.Error("Encountered negative timer due time for directive:<" + dto.Id + ">", e);
            }
        }

        private void HandleTimerFire(object dto)
        {
            // we are often in a background thread at this point but we need to manipulate the UI, so we make sure to do
            // the real work on the UI thread
            synchronizationContext.Post(RefreshItem, dto);
        }

        private void RefreshItem(object dto)
        {
            if (!(dto is TemporaryInstallationsMudsDTO)) return;

            if (!(page.Grid is DomainSummaryGrid<TemporaryInstallationsMudsDTO>))
            {
                DataNeedsRefresh = true;

                return;
            }

            var edmontonOp14DTO = (TemporaryInstallationsMudsDTO)dto;
            RegisterRenderTimer(edmontonOp14DTO);

            var domainSummaryGrid = ((DomainSummaryGrid<TemporaryInstallationsMudsDTO>) page.Grid);
            var oldVersion =
                domainSummaryGrid.FindItem(edmontonOp14DTO.Id);

            if (oldVersion == null) return;

            var updateIndex = domainSummaryGrid.Items.IndexOf(oldVersion);

            if (updateIndex == -1)
            {
                domainSummaryGrid.AddItem(edmontonOp14DTO);
            }
            else
            {
                domainSummaryGrid.UpdateItem(updateIndex, edmontonOp14DTO);
            }
        }

        protected override EdmontonFormType FormTypeToQuery()
        {
            return EdmontonFormType.TemporaryInstallationsMuds;
        }

        //ayman generic forms
        public override TemporaryInstallationsMUDS QueryByIdAndSiteId(long id, long siteid)
        {
            return formService.QueryMudsTemporaryInstallationsById(id);
        }


        public override TemporaryInstallationsMUDS QueryById(long id)
        {
            return formService.QueryMudsTemporaryInstallationsById(id);
        }

        //RITM0268131 - mangesh
        protected override void Update(TemporaryInstallationsMUDS form)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.UpdateMudsTemporaryInstallations, form);
        }

        protected override IForm CreateEditForm(TemporaryInstallationsMUDS item)
        {
            var presenter = new TemporaryInstallationsFormPresenter(item);
            return presenter.View;
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(TemporaryInstallationsMUDS item)
        {
            return new TemporaryInstallationsMUDSHistoryPresenter(item);
        }

        //RITM0268131 - mangesh
        protected override void Delete(TemporaryInstallationsMUDS item)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.RemoveMudsTemporaryInstallations, item);
        }

        public override Range<Date> GetDefaultDateRange()
        {
            var now = Clock.DateNow;
            var from = now.AddDays(-1*userContext.SiteConfiguration.DaysToDisplayFormsBackwards);
            var to = userContext.SiteConfiguration.DaysToDisplayFormsForwards == null
                ? null
                : now.AddDays(userContext.SiteConfiguration.DaysToDisplayFormsForwards.Value);

            return new Range<Date>(from, to);
        }

        public override DialogResultAndOutput<TemporaryInstallationsMUDS> Edit(TemporaryInstallationsMUDS domainObject, IBaseForm view)
        {
            var presenter = new TemporaryInstallationsFormPresenter(domainObject);
            return presenter.RunAndReturnTheEditObject(view);
        }

        public override DialogResultAndOutput<TemporaryInstallationsMUDS> CreateNew(IBaseForm view)
        {
            var presenter = new TemporaryInstallationsFormPresenter();
            return presenter.RunAndReturnTheEditObject(view);
        }
    }
}