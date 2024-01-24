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
    public class LubesCsdFormContext :
        AbstractEdmontonFormContext<LubesCsdFormDTO, LubesCsdForm, FormLubesCsdDetails>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (LubesCsdFormContext));
        private readonly IReportPrintManager<LubesCsdForm> reportPrintManager;
        private readonly WindowsFormsSynchronizationContext synchronizationContext;
        private readonly LubesCsdTimerManager timerManager;

        public LubesCsdFormContext(IFormEdmontonService formService, AbstractMultiGridPage page)
            : base(formService, page, EdmontonFormType.LubesCsd, new FormLubesCsdDetails(), new LubesCsdFormGridRenderer())
        {
            PrintActions<LubesCsdForm, FormLubesCsdReport, FormLubesCsdReportAdapter> printActions =
                new LubesCsdFormPrintActions();
            reportPrintManager =
                new ReportPrintManager<LubesCsdForm, FormLubesCsdReport, FormLubesCsdReportAdapter>(printActions);
            synchronizationContext = (WindowsFormsSynchronizationContext) SynchronizationContext.Current;
            timerManager = new LubesCsdTimerManager();
            page.Disposed += HandlePageDisposed;
        }

        public override bool IsItemSelected
        {
            get { return grid.SelectedItem != null; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_LubesCsdForm; }
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.FormLubesCsd; }
        }

        protected override IReportPrintManager<LubesCsdForm> ReportPrintManager
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

        protected override LubesCsdFormDTO CreateDtoFromDomainObject(LubesCsdForm item)
        {
            return (LubesCsdFormDTO) item.CreateDTO();
        }

        public override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerLubesCsdFormCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerLubesCsdFormUpdated += HandleRepeaterUpdated;
            remoteEventRepeater.ServerLubesCsdFormRemoved += HandleRepeaterRemoved;
        }

        protected override void HandleRepeaterCreated(object sender, DomainEventArgs<LubesCsdForm> e)
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

        protected override void HandleRepeaterUpdated(object sender, DomainEventArgs<LubesCsdForm> e)
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
            remoteEventRepeater.ServerLubesCsdFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerLubesCsdFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerLubesCsdFormRemoved -= HandleRepeaterRemoved;
        }

        public override void SetDetailData(FormLubesCsdDetails details, LubesCsdForm form)
        {
            details.WorkPermitEdmontonSectionVisible = false;

            details.ValidFromDateTimeLabel = StringResources.FormLubesCsd_SystemDefeated + ":";
            details.ValidToDateTimeLabel = StringResources.FormLubesCsd_EstimatedBackInService + ":";

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
            details.IsTheCSDForAPressureSafetyValve = form.IsTheCSDForAPressureSafetyValve;
            details.CriticalSystemDefeated = form.CriticalSystemDefeated;

            details.AdjustTextBoxHeights();
        }

        public override void ControlDetailButtons()
        {
            base.ControlDetailButtons();

            var userRoleElements = userContext.UserRoleElements;
            var selectedItems = GetSelectedItems();
            var hasAtLeastOneItemSelected = selectedItems.Count > 0;
            var hasSingleItemSelected = selectedItems.Count == 1;
            details.EmailEnabled = hasSingleItemSelected && (selectedItems[0].Status != FormStatus.Approved && selectedItems[0].Status != FormStatus.Closed);
            details.CloneEnabled = hasSingleItemSelected && authorized.ToCreateLubesCsdForm(userRoleElements);
            details.CloseEnabled = hasAtLeastOneItemSelected &&  authorized.ToCloseLubesCsdForms(userRoleElements, selectedItems);
                details.DeleteEnabled =
                    hasAtLeastOneItemSelected && authorized.ToDeleteLubesCsdForms(userRoleElements, selectedItems);
            details.EditEnabled = hasSingleItemSelected &&
                                  authorized.ToEditFormLubesCsd(userRoleElements, selectedItems[0].Status);
        }

        public override IList<LubesCsdFormDTO> GetData(RootFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            var lubesCsdDtos = formService.QueryLubesCsdFormDTOs(flocSet,
                dateRange,
                formStatuses,
                includeAllDraftFormsRegardlessOfDateRange);
            timerManager.Clear();
            lubesCsdDtos.ForEach(RegisterRenderTimer);
            return lubesCsdDtos;
        }

        private void RegisterRenderTimer(LubesCsdFormDTO dto)
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

        private void SetupTimerCallback(TimeSpan differenceInTime, LubesCsdFormDTO dto)
        {
            var timeRemainingInShift = ClientSession.GetInstance().GetTimeRemainingInShiftWithPostShiftPadding();
            if (differenceInTime < timeRemainingInShift)
            {
                SetupTimerForCallback(dto, differenceInTime);
            }
        }

        private void SetupTimerForCallback(LubesCsdFormDTO dto, TimeSpan differenceInTime)
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
            if (!(dto is LubesCsdFormDTO)) return;

            if (!(page.Grid is DomainSummaryGrid<LubesCsdFormDTO>))
            {
                DataNeedsRefresh = true;

                return;
            }

            var lubesCsdDto = (LubesCsdFormDTO) dto;
            RegisterRenderTimer(lubesCsdDto);

            var domainSummaryGrid = ((DomainSummaryGrid<LubesCsdFormDTO>) page.Grid);
            var oldVersion =
                domainSummaryGrid.FindItem(lubesCsdDto.Id);

            if (oldVersion == null) return;

            var updateIndex = domainSummaryGrid.Items.IndexOf(oldVersion);

            if (updateIndex == -1)
            {
                domainSummaryGrid.AddItem(lubesCsdDto);
            }
            else
            {
                domainSummaryGrid.UpdateItem(updateIndex, lubesCsdDto);
            }
        }

        protected override EdmontonFormType FormTypeToQuery()
        {
            return EdmontonFormType.LubesCsd;
        }

        //ayman generic forms
        public override LubesCsdForm QueryByIdAndSiteId(long id,long siteid)
        {
            return formService.QueryLubesCsdFormByIdAndSiteId(id,siteid);
        }
        
        
        public override LubesCsdForm QueryById(long id)
        {
            return formService.QueryLubesCsdFormById(id);
        }

        protected override void Update(LubesCsdForm form)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.UpdateLubesCsd, form);
        }

        protected override IForm CreateEditForm(LubesCsdForm item)
        {
            var presenter = new FormLubesCsdFormPresenter(item);
            return presenter.View;
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(LubesCsdForm item)
        {
            return new LubesCsdHistoryFormPresenter(item);
        }

        protected override void Delete(LubesCsdForm item)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.RemoveLubesCsdForm, item);
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

        public override DialogResultAndOutput<LubesCsdForm> Edit(LubesCsdForm domainObject, IBaseForm view)
        {
            var presenter = new FormLubesCsdFormPresenter(domainObject);
            return presenter.RunAndReturnTheEditObject(view);
        }

        public override DialogResultAndOutput<LubesCsdForm> CreateNew(IBaseForm view)
        {
            var presenter = new FormLubesCsdFormPresenter();
            return presenter.RunAndReturnTheEditObject(view);
        }
    }
}