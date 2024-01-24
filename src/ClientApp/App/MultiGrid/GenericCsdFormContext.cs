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
    public class GenericCsdFormContext :
        AbstractEdmontonFormContext<GenericCsdDTO, GenericCsd, FormGenericCsdDetails>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (EdmontonOP14FormContext));
        private readonly IReportPrintManager<GenericCsd> reportPrintManager;
        private readonly WindowsFormsSynchronizationContext synchronizationContext;
        private readonly GenericCsdTimerManager timerManager;

        public GenericCsdFormContext(IFormEdmontonService formService, AbstractMultiGridPage page)
            : base(
                formService, page, EdmontonFormType.MontrealCsd, new FormGenericCsdDetails(),
                new GenericCsdGridRenderer())
        {
            PrintActions<GenericCsd, FormGenericCsdReport, FormGenericCsdReportAdapter> printActions =
                new GenericCsdFormPrintActions();
            reportPrintManager =
                new ReportPrintManager<GenericCsd, FormGenericCsdReport, FormGenericCsdReportAdapter>(printActions);
            synchronizationContext = (WindowsFormsSynchronizationContext) SynchronizationContext.Current;
            timerManager = new GenericCsdTimerManager();
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

        protected override IReportPrintManager<GenericCsd> ReportPrintManager
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

        protected override GenericCsdDTO CreateDtoFromDomainObject(GenericCsd item)
        {
            return (GenericCsdDTO) item.CreateDTO();
        }

        public override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGenericCsdFormCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerGenericCsdFormUpdated += HandleRepeaterUpdated;
            remoteEventRepeater.ServerGenericCsdFormRemoved += HandleRepeaterRemoved;
        }

        protected override void HandleRepeaterCreated(object sender, DomainEventArgs<GenericCsd> e)
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

        protected override void HandleRepeaterUpdated(object sender, DomainEventArgs<GenericCsd> e)
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
            remoteEventRepeater.ServerGenericCsdFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerGenericCsdFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerGenericCsdFormRemoved -= HandleRepeaterRemoved;
        }

        public override void SetDetailData(FormGenericCsdDetails details, GenericCsd form)
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
                hasAtLeastOneItemSelected && authorized.ToDeleteGenericCsd(userRoleElements, selectedItems);
            details.EditEnabled = hasSingleItemSelected &&
                                  authorized.ToEditMontrealCsd(userRoleElements, selectedItems[0].Status);
            details.EmailEnabled = hasSingleItemSelected && (selectedItems[0].Status != FormStatus.Approved && selectedItems[0].Status != FormStatus.Closed);
            details.CloneEnabled = hasSingleItemSelected && authorized.ToCreateMontrealCsdForm(userRoleElements);
            details.CloseEnabled = hasAtLeastOneItemSelected && authorized.ToCloseGenericCsdForms(userRoleElements, selectedItems);

        }

        public override IList<GenericCsdDTO> GetData(RootFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            var montrealCsdDtos = formService.QueryGenericCsdDTOs(flocSet,
                dateRange,
                formStatuses,
                includeAllDraftFormsRegardlessOfDateRange);
            timerManager.Clear();
            montrealCsdDtos.ForEach(RegisterRenderTimer);
            return montrealCsdDtos;
        }

        private void RegisterRenderTimer(GenericCsdDTO dto)
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

        private void SetupTimerCallback(TimeSpan differenceInTime, GenericCsdDTO dto)
        {
            var timeRemainingInShift = ClientSession.GetInstance().GetTimeRemainingInShiftWithPostShiftPadding();
            if (differenceInTime < timeRemainingInShift)
            {
                SetupTimerForCallback(dto, differenceInTime);
            }
        }

        private void SetupTimerForCallback(GenericCsdDTO dto, TimeSpan differenceInTime)
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
            if (!(dto is GenericCsdDTO)) return;

            if (!(page.Grid is DomainSummaryGrid<GenericCsdDTO>))
            {
                DataNeedsRefresh = true;

                return;
            }

            var edmontonOp14DTO = (GenericCsdDTO) dto;
            RegisterRenderTimer(edmontonOp14DTO);

            var domainSummaryGrid = ((DomainSummaryGrid<GenericCsdDTO>) page.Grid);
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
        public override GenericCsd QueryByIdAndSiteId(long id, long siteid)
        {
            return formService.QueryGenericCsdById(id);
        }
        
        
        public override GenericCsd QueryById(long id)
        {
            return formService.QueryGenericCsdById(id);
        }

        protected override void Update(GenericCsd form)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.UpdateGenericCsd, form);
        }

        protected override IForm CreateEditForm(GenericCsd item)
        {
            var presenter = new GenericCsdPresenter(item);
            return presenter.View;
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(GenericCsd item)
        {
            return new GenericCsdHistoryPresenter(item);
        }

        protected override void Delete(GenericCsd item)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.RemoveGenericCsd, item);
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

        public override DialogResultAndOutput<GenericCsd> Edit(GenericCsd domainObject, IBaseForm view)
        {
            var presenter = new GenericCsdPresenter(domainObject);
            return presenter.RunAndReturnTheEditObject(view);
        }

        public override DialogResultAndOutput<GenericCsd> CreateNew(IBaseForm view)
        {
            var presenter = new GenericCsdPresenter();
            return presenter.RunAndReturnTheEditObject(view);
        }
    }
}