﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CSDPipelineFormContext  :
        AbstractEdmontonFormContext<FormEdmontonOP14DTO, FormOP14, FormPipelineOP14Details>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(CSDPipelineFormContext));
        private readonly IReportPrintManager<FormOP14> reportPrintManager;
        private readonly WindowsFormsSynchronizationContext synchronizationContext;
        private readonly OP14TimerManager timerManager;

        public CSDPipelineFormContext(IFormEdmontonService formService, AbstractMultiGridPage page)
            : base(formService, page, EdmontonFormType.OP14, new FormPipelineOP14Details(), new OP14FormGridRenderer())
        {
            PrintActions<FormOP14, FormOP14PipelineReport, FormOP14ReportAdapter> printActions =
                new EdmontonPipelineOP14FormPrintAction();
            reportPrintManager = new ReportPrintManager<FormOP14, FormOP14PipelineReport, FormOP14ReportAdapter>(printActions);
            synchronizationContext = (WindowsFormsSynchronizationContext)SynchronizationContext.Current;
            timerManager = new OP14TimerManager();
            page.Disposed += HandlePageDisposed;
        }

        public override bool IsItemSelected { get { return grid.SelectedItem != null; } }
        protected override string DomainObjectName { get { return StringResources.DomainObjectName_FormOP14; } }
        protected override UserGridLayoutIdentifier GridIdentifier { get { return UserGridLayoutIdentifier.FormOP14; } }

        protected override IReportPrintManager<FormOP14> ReportPrintManager { get { return reportPrintManager; } }

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

        protected override FormEdmontonOP14DTO CreateDtoFromDomainObject(FormOP14 item)
        {
            return (FormEdmontonOP14DTO)item.CreateDTO();
        }

        public override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerOP14FormCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerOP14FormUpdated += HandleRepeaterUpdated;
            remoteEventRepeater.ServerOP14FormRemoved += HandleRepeaterRemoved;
        }

        protected override void HandleRepeaterCreated(object sender, DomainEventArgs<FormOP14> e)
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

        protected override void HandleRepeaterUpdated(object sender, DomainEventArgs<FormOP14> e)
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
            remoteEventRepeater.ServerOP14FormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerOP14FormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerOP14FormRemoved -= HandleRepeaterRemoved;
        }

        public override void SetDetailData(FormPipelineOP14Details details, FormOP14 form)
        {
            details.WorkPermitEdmontonSectionVisible = false;

            details.ValidFromDateTimeLabel = StringResources.FormOP14_SystemDefeated + ":";
            details.ValidToDateTimeLabel = StringResources.FormOP14_EstimatedBackInService + ":";

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
                details.Department = null;
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
            details.Department = form.Department;
            details.IsTheCSDForAPressureSafetyValve = form.IsTheCSDForAPressureSafetyValve;
            details.CriticalSystemDefeated = form.CriticalSystemDefeated;
            details.IsTheCSDForSCADAeDataLabel = form.IsSCADASupport;
            details.AdjustTextBoxHeights();
            /*RITM0265746 - Sarnia CSD marked as read start */
            details.MarkAsReadVisible = false;
            details.MarkedAsReadPannelVisible = false;
            /*RITM0265746 - Sarnia CSD marked as read end */
        }

        public override void ControlDetailButtons()
        {
            base.ControlDetailButtons();
            /*RITM0265746 - Sarnia CSD marked as read start */
            details.MarkAsReadVisible = false;
            details.MarkedAsReadPannelVisible = false;
            /*RITM0265746 - Sarnia CSD marked as read end */
            var userRoleElements = userContext.UserRoleElements;
            var selectedItems = GetSelectedItems();
            var hasSingleItemSelected = selectedItems.Count == 1;

            details.EditEnabled = hasSingleItemSelected &&
                                  authorized.ToEditFormOP14(userRoleElements, selectedItems[0].Status);
        }

        public override IList<FormEdmontonOP14DTO> GetData(RootFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            var op14Dtos = formService.QueryFormOP14DTOs(flocSet,
                dateRange,
                formStatuses,
                includeAllDraftFormsRegardlessOfDateRange);
            timerManager.Clear();
            op14Dtos.ForEach(RegisterRenderTimer);
            return op14Dtos;
        }

        private void RegisterRenderTimer(FormEdmontonOP14DTO dto)
        {
            timerManager.Unregister(dto);
            var now = Clock.Now;

            // this will never auto change its grouping
            if (dto.ValidTo < now) return;


            if (ClientSession.GetUserContext().IsSarniaSite) //ayman sarnia timer manager
            {
                if (dto.ValidFrom.AddDays(3) > now)
                {
                    var timeUntilActive = dto.ValidFrom.AddDays(3).Subtract(now);
                    SetupTimerCallback(timeUntilActive, dto);
                }
                else
                {
                    var timeUntilRequiresApprovalOrExpires = dto.ValidTo.Subtract(now);
                    SetupTimerCallback(timeUntilRequiresApprovalOrExpires, dto);
                }
            }
            else
            {

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
        }

        private void SetupTimerCallback(TimeSpan differenceInTime, FormEdmontonOP14DTO dto)
        {
            var timeRemainingInShift = ClientSession.GetInstance().GetTimeRemainingInShiftWithPostShiftPadding();
            if (differenceInTime < timeRemainingInShift)
            {
                SetupTimerForCallback(dto, differenceInTime);
            }
        }

        private void SetupTimerForCallback(FormEdmontonOP14DTO dto, TimeSpan differenceInTime)
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
            if (!(dto is FormEdmontonOP14DTO)) return;

            if (!(page.Grid is DomainSummaryGrid<FormEdmontonOP14DTO>))
            {
                DataNeedsRefresh = true;

                return;
            }

            var edmontonOp14DTO = (FormEdmontonOP14DTO)dto;
            RegisterRenderTimer(edmontonOp14DTO);

            var domainSummaryGrid = ((DomainSummaryGrid<FormEdmontonOP14DTO>)page.Grid);
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
            return EdmontonFormType.OP14;
        }

        public override FormOP14 QueryById(long id)
        {
            return formService.QueryFormOP14ById(id);
        }

        public override FormOP14 QueryByIdAndSiteId(long id, long siteid)   //ayman generic forms
        {
            return formService.QueryFormOP14ByIdAndSiteId(id, siteid);   //ayman generic forms
        }

        protected override void Update(FormOP14 form)
        {
            form.SiteId = ClientSession.GetUserContext().SiteId;            //ayman generic forms set siteid to the form
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.UpdateOP14, form);
        }

        protected override IForm CreateEditForm(FormOP14 item)
        {
            var presenter = new EdmontonPipelineOP14Presenter(item);
            return presenter.View;
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(FormOP14 item)
        {
            return new EditFormOP14HistoryFormPresenter(item);
        }

        protected override void Delete(FormOP14 item)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formService.RemoveOP14, item);
        }

        public override Range<Date> GetDefaultDateRange()
        {
            var now = Clock.DateNow;
            var from = now.AddDays(-1 * userContext.SiteConfiguration.DaysToDisplayFormsBackwards);
            var to = userContext.SiteConfiguration.DaysToDisplayFormsForwards == null
                ? null
                : now.AddDays(userContext.SiteConfiguration.DaysToDisplayFormsForwards.Value);

            return new Range<Date>(from, to);
        }

        public override DialogResultAndOutput<FormOP14> Edit(FormOP14 domainObject, IBaseForm view)
        {
            var presenter = new EdmontonPipelineOP14Presenter(domainObject);
            return presenter.RunAndReturnTheEditObject(view);
        }

        public override DialogResultAndOutput<FormOP14> CreateNew(IBaseForm view)
        {
            var presenter = new EdmontonPipelineOP14Presenter();
            return presenter.RunAndReturnTheEditObject(view);
        }

        /*RITM0265746 - Sarnia CSD marked as read start */
        /* protected override void InsertMarkAsReadFormOp14(long id, long userId, DateTime datetimenow, long shiftId)
         {
             List<ItemReadBy> markAsReadForShift = formService.UserMarkedFormOp14AsRead(id, userId);
             if (markAsReadForShift.Count > 0)
             {
                 markAsReadForShift =
                     markAsReadForShift.Where(
                         x =>
                             x.DateTime >= ClientSession.GetUserContext().UserShift.StartDateTimeWithPadding &&
                             x.DateTime <= ClientSession.GetUserContext().UserShift.EndDateTimeWithPadding &&
                             x.UserFullNameWithUserName == ClientSession.GetUserContext().User.FullNameWithUserName).ToList();
             }
             if (markAsReadForShift.Count == 0)
                 formService.InsertFormOp14MarkAsRead(id, userId, datetimenow, shiftId);
         }

         protected override void HandleMarkedAsReadByToggled(long formOp14Id)
         {
             details.MarkedAsReadBy = formService.UserMarkedFormOp14AsRead(formOp14Id, null).Where(
                     x =>
                         x.DateTime >= ClientSession.GetUserContext().UserShift.StartDateTimeWithPadding &&
                         x.DateTime <= ClientSession.GetUserContext().UserShift.EndDateTimeWithPadding).ToList(); ;
         }
        */
        /*RITM0265746 - Sarnia CSD marked as read end*/
    }
}