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
    public class MontrealCsdFormContext :
        AbstractEdmontonFormContext<MontrealCsdDTO, MontrealCsd, FormMontrealCsdDetails>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (EdmontonOP14FormContext));
        private readonly IReportPrintManager<MontrealCsd> reportPrintManager;
        private readonly WindowsFormsSynchronizationContext synchronizationContext;
        private readonly MontrealCsdTimerManager timerManager;

        public MontrealCsdFormContext(IFormEdmontonService formService, AbstractMultiGridPage page)
            : base(
                formService, page, EdmontonFormType.MontrealCsd, new FormMontrealCsdDetails(),
                new MontrealCsdGridRenderer())
        {
            PrintActions<MontrealCsd, FormMontrealCsdReport, FormMontrealCsdReportAdapter> printActions =
                new MontrealCsdFormPrintActions();
            reportPrintManager =
                new ReportPrintManager<MontrealCsd, FormMontrealCsdReport, FormMontrealCsdReportAdapter>(printActions);
            synchronizationContext = (WindowsFormsSynchronizationContext) SynchronizationContext.Current;
            timerManager = new MontrealCsdTimerManager();
            page.Disposed += HandlePageDisposed;
        }

        public override bool IsItemSelected
        {
            get { return grid.SelectedItem != null; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_FormMontrealCsd; }
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.FormMontrealCsd; }
        }

        protected override IReportPrintManager<MontrealCsd> ReportPrintManager
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

        protected override MontrealCsdDTO CreateDtoFromDomainObject(MontrealCsd item)
        {
            return (MontrealCsdDTO) item.CreateDTO();
        }

        public override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerMontrealCsdFormCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerMontrealCsdFormUpdated += HandleRepeaterUpdated;
            remoteEventRepeater.ServerMontrealCsdFormRemoved += HandleRepeaterRemoved;
        }

        protected override void HandleRepeaterCreated(object sender, DomainEventArgs<MontrealCsd> e)
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

        protected override void HandleRepeaterUpdated(object sender, DomainEventArgs<MontrealCsd> e)
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
            remoteEventRepeater.ServerMontrealCsdFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerMontrealCsdFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerMontrealCsdFormRemoved -= HandleRepeaterRemoved;
        }

        public override void SetDetailData(FormMontrealCsdDetails details, MontrealCsd form)
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
            base.ControlDetailButtons();

            var userRoleElements = userContext.UserRoleElements;
            var selectedItems = GetSelectedItems();
            var hasAtLeastOneItemSelected = selectedItems.Count > 0;
            var hasSingleItemSelected = selectedItems.Count == 1;

            details.DeleteEnabled =
                hasAtLeastOneItemSelected && authorized.ToDeleteMontrealCsd(userRoleElements, selectedItems);
            details.EditEnabled = hasSingleItemSelected &&
                                  authorized.ToEditMontrealCsd(userRoleElements, selectedItems[0].Status);
            details.EmailEnabled = hasSingleItemSelected && (selectedItems[0].Status != FormStatus.Approved && selectedItems[0].Status != FormStatus.Closed);
            details.CloneEnabled = hasSingleItemSelected && authorized.ToCreateMontrealCsdForm(userRoleElements);
            details.CloseEnabled = hasAtLeastOneItemSelected && authorized.ToCloseMontrealCsdForms(userRoleElements, selectedItems);

        }

        public override IList<MontrealCsdDTO> GetData(RootFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            var montrealCsdDtos = formService.QueryMontrealCsdDTOs(flocSet,
                dateRange,
                formStatuses,
                includeAllDraftFormsRegardlessOfDateRange);
            timerManager.Clear();
            montrealCsdDtos.ForEach(RegisterRenderTimer);
            return montrealCsdDtos;
        }

        private void RegisterRenderTimer(MontrealCsdDTO dto)
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

        private void SetupTimerCallback(TimeSpan differenceInTime, MontrealCsdDTO dto)
        {
            var timeRemainingInShift = ClientSession.GetInstance().GetTimeRemainingInShiftWithPostShiftPadding();
            if (differenceInTime < timeRemainingInShift)
            {
                SetupTimerForCallback(dto, differenceInTime);
            }
        }

        private void SetupTimerForCallback(MontrealCsdDTO dto, TimeSpan differenceInTime)
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
            if (!(dto is MontrealCsdDTO)) return;

            if (!(page.Grid is DomainSummaryGrid<MontrealCsdDTO>))
            {
                DataNeedsRefresh = true;

                return;
            }

            var edmontonOp14DTO = (MontrealCsdDTO) dto;
            RegisterRenderTimer(edmontonOp14DTO);

            var domainSummaryGrid = ((DomainSummaryGrid<MontrealCsdDTO>) page.Grid);
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
            return EdmontonFormType.MontrealCsd;
        }

        //ayman generic forms
        public override MontrealCsd QueryByIdAndSiteId(long id, long siteid)
        {
            return formService.QueryMontrealCsdById(id);
        }
        
        
        public override MontrealCsd QueryById(long id)
        {
            return formService.QueryMontrealCsdById(id);
        }

        protected override void Update(MontrealCsd form)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.UpdateMontrealCsd, form);
        }

        protected override IForm CreateEditForm(MontrealCsd item)
        {
            var presenter = new MontrealCsdPresenter(item);
            return presenter.View;
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(MontrealCsd item)
        {
            return new MontrealCsdHistoryPresenter(item);
        }

        protected override void Delete(MontrealCsd item)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.RemoveMontrealCsd, item);
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

        public override DialogResultAndOutput<MontrealCsd> Edit(MontrealCsd domainObject, IBaseForm view)
        {
            var presenter = new MontrealCsdPresenter(domainObject);
            return presenter.RunAndReturnTheEditObject(view);
        }

        public override DialogResultAndOutput<MontrealCsd> CreateNew(IBaseForm view)
        {
            var presenter = new MontrealCsdPresenter();
            return presenter.RunAndReturnTheEditObject(view);
        }
    }
}