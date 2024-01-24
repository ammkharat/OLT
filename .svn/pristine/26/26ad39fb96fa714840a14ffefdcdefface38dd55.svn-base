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
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using log4net;

namespace Com.Suncor.Olt.Client.MultiGrid
{
    public class LubesAlarmDisableFormContext :
        AbstractEdmontonFormContext<LubesAlarmDisableFormDTO, LubesAlarmDisableForm, FormLubesAlarmDisableDetails>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (LubesAlarmDisableFormContext));
        private readonly IReportPrintManager<LubesAlarmDisableForm> reportPrintManager;
        private readonly WindowsFormsSynchronizationContext synchronizationContext;
        private readonly LubesAlarmDisableTimerManager timerManager;

        public LubesAlarmDisableFormContext(IFormEdmontonService formService, AbstractMultiGridPage page)
            : base(
                formService, page, EdmontonFormType.LubesAlarmDisable, new FormLubesAlarmDisableDetails(),
                new LubesAlarmDisableFormGridRenderer())
        {
            PrintActions<LubesAlarmDisableForm, FormLubesAlarmDisableReport, FormLubesAlarmDisableReportAdapter>
                printActions =
                    new LubesAlarmDisableFormPrintActions();
            reportPrintManager =
                new ReportPrintManager
                    <LubesAlarmDisableForm, FormLubesAlarmDisableReport, FormLubesAlarmDisableReportAdapter>(
                    printActions);
            synchronizationContext = (WindowsFormsSynchronizationContext) SynchronizationContext.Current;
            timerManager = new LubesAlarmDisableTimerManager();
            page.Disposed += HandlePageDisposed;
        }

        public override bool IsItemSelected
        {
            get { return grid.SelectedItem != null; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_LubesAlarmDisableForm; }
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.FormLubesAlarmDisable; }
        }

        protected override IReportPrintManager<LubesAlarmDisableForm> ReportPrintManager
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

        protected override LubesAlarmDisableFormDTO CreateDtoFromDomainObject(LubesAlarmDisableForm item)
        {
            return (LubesAlarmDisableFormDTO) item.CreateDTO();
        }

        public override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerLubesAlarmDisableFormCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerLubesAlarmDisableFormUpdated += HandleRepeaterUpdated;
            remoteEventRepeater.ServerLubesAlarmDisableFormRemoved += HandleRepeaterRemoved;
        }

        protected override void HandleRepeaterCreated(object sender, DomainEventArgs<LubesAlarmDisableForm> e)
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

        protected override void HandleRepeaterUpdated(object sender, DomainEventArgs<LubesAlarmDisableForm> e)
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
            remoteEventRepeater.ServerLubesAlarmDisableFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerLubesAlarmDisableFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerLubesAlarmDisableFormRemoved -= HandleRepeaterRemoved;
        }

        public override void SetDetailData(FormLubesAlarmDisableDetails details, LubesAlarmDisableForm form)
        {
            details.WorkPermitEdmontonSectionVisible = false;

            details.ValidFromDateTimeLabel = StringResources.FormLubesAlarmDisable_DisableOn + ":";
            details.ValidToDateTimeLabel = StringResources.FormLubesAlarmDisable_Expires + ":";

            if (form == null)
            {
                details.ClearDetails();
                return;
            }

            details.CreatedByUser = form.CreatedBy;
            details.CreatedDateTime = form.CreatedDateTime;

            details.LastModifiedByUser = form.LastModifiedBy;
            details.LastModifiedDateTime = form.LastModifiedDateTime;

            details.Content = form.Content;

            details.ValidFromDateTime = form.FromDateTime;
            details.ValidToDateTime = form.ToDateTime;
            details.FunctionalLocation = form.FunctionalLocation;
            details.FormLocation = form.Location;
            details.Approvals = form.EnabledApprovals;

            details.FormNumber = form.FormNumber;
            details.ClosedDateTime = form.ClosedDateTime;
            details.ApprovedDateTime = form.ApprovedDateTime;
            details.DocumentLinks = form.DocumentLinks;

            details.Criticality = form.Criticality;
            details.Alarm = form.Alarm;
            details.SapNotification = form.SapNotification;

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
                hasAtLeastOneItemSelected && authorized.ToDeleteLubesAlarmDisableForms(userRoleElements, selectedItems);
            details.EditEnabled = hasSingleItemSelected &&
                                  authorized.ToEditFormLubesAlarmDisable(userRoleElements, selectedItems[0].Status);

            details.CloneEnabled = hasSingleItemSelected && authorized.ToCreateLubesAlarmDisableForm(userRoleElements);
            details.EmailEnabled = hasSingleItemSelected && (selectedItems[0].Status != FormStatus.Approved && selectedItems[0].Status != FormStatus.Closed);
            details.CloseEnabled = hasAtLeastOneItemSelected &&
                                   authorized.ToCloseLubesAlarmDisableForms(userRoleElements, selectedItems);
        }

        public override IList<LubesAlarmDisableFormDTO> GetData(RootFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            var lubesAlarmDisableFormDtOs = formService.QueryLubesAlarmDisableFormDTOs(flocSet,
                dateRange,
                formStatuses,
                includeAllDraftFormsRegardlessOfDateRange);
            timerManager.Clear();
            lubesAlarmDisableFormDtOs.ForEach(RegisterRenderTimer);
            return lubesAlarmDisableFormDtOs;
        }

        private void RegisterRenderTimer(LubesAlarmDisableFormDTO dto)
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

        private void SetupTimerCallback(TimeSpan differenceInTime, LubesAlarmDisableFormDTO dto)
        {
            var timeRemainingInShift = ClientSession.GetInstance().GetTimeRemainingInShiftWithPostShiftPadding();
            if (differenceInTime < timeRemainingInShift)
            {
                SetupTimerForCallback(dto, differenceInTime);
            }
        }

        private void SetupTimerForCallback(LubesAlarmDisableFormDTO dto, TimeSpan differenceInTime)
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
            if (!(dto is LubesAlarmDisableFormDTO)) return;
            
            if (!(page.Grid is DomainSummaryGrid<LubesAlarmDisableFormDTO>))
            {
                DataNeedsRefresh = true;

                return;
            }

            var alarmDisableFormDTO = (LubesAlarmDisableFormDTO) dto;
            RegisterRenderTimer(alarmDisableFormDTO);

            var domainSummaryGrid = ((DomainSummaryGrid<LubesAlarmDisableFormDTO>) page.Grid);
            var oldVersion =
                domainSummaryGrid.FindItem(alarmDisableFormDTO.Id);

            if (oldVersion == null) return;

            var updateIndex = domainSummaryGrid.Items.IndexOf(oldVersion);

            if (updateIndex == -1)
            {
                domainSummaryGrid.AddItem(alarmDisableFormDTO);
            }
            else
            {
                domainSummaryGrid.UpdateItem(updateIndex, alarmDisableFormDTO);
            }
        }

        protected override EdmontonFormType FormTypeToQuery()
        {
            return EdmontonFormType.LubesAlarmDisable;
        }

        //ayman generic forms
        public override LubesAlarmDisableForm QueryByIdAndSiteId(long id,long siteid)
        {
            return formService.QueryLubesAlarmDisableFormById(id);  //ayman disable siteid 
        }
        
        
        public override LubesAlarmDisableForm QueryById(long id)
        {
            return formService.QueryLubesAlarmDisableFormById(id);
        }

        protected override void Update(LubesAlarmDisableForm form)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                formService.UpdateLubesAlarmDisable, form);
        }

        protected override IForm CreateEditForm(LubesAlarmDisableForm item)
        {
            var presenter = new FormLubesAlarmDisableFormPresenter(item);
            return presenter.View;
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(LubesAlarmDisableForm item)
        {
            return new LubesAlarmDisableHistoryFormPresenter(item);
        }

        protected override void Delete(LubesAlarmDisableForm item)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                formService.RemoveLubesAlarmDisable, item);
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

        public override DialogResultAndOutput<LubesAlarmDisableForm> Edit(LubesAlarmDisableForm domainObject,
            IBaseForm view)
        {
            var presenter = new FormLubesAlarmDisableFormPresenter(domainObject);
            return presenter.RunAndReturnTheEditObject(view);
        }

        public override DialogResultAndOutput<LubesAlarmDisableForm> CreateNew(IBaseForm view)
        {
            var presenter = new FormLubesAlarmDisableFormPresenter();
            return presenter.RunAndReturnTheEditObject(view);
        }
    }
}