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
using Com.Suncor.Olt.Client.Utilities;
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
    public class ProcedureDeviationFormContext :
        AbstractEdmontonFormContext<ProcedureDeviationDTO, ProcedureDeviation, FormProcedureDeviationDetails>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (ProcedureDeviationFormContext));
        private readonly IReportPrintManager<ProcedureDeviation> reportPrintManager;
        private readonly WindowsFormsSynchronizationContext synchronizationContext;
        private readonly ProcedureDeviationTimerManager timerManager;

        public ProcedureDeviationFormContext(IFormEdmontonService formService, AbstractMultiGridPage page)
            : base(
                formService, page, EdmontonFormType.ProcedureDeviation, new FormProcedureDeviationDetails(),
                new ProcedureDeviationGridRenderer())
        {

            var printActions = new ProcedureDeviationReportPrintActions();
            reportPrintManager =
                new ReportPrintManager
                    <ProcedureDeviation, ProcedureDeviationReport,
                        ProcedureDeviationReportAdapter>(
                    printActions);

            synchronizationContext = (WindowsFormsSynchronizationContext) SynchronizationContext.Current;
            timerManager = new ProcedureDeviationTimerManager();
            page.Disposed += HandlePageDisposed;
        }

        public override bool IsItemSelected
        {
            get { return grid.SelectedItem != null; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_ProcedureDeviationForm; }
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.ProcedureDeviation; }
        }

        protected override IReportPrintManager<ProcedureDeviation> ReportPrintManager
        {
            get { return reportPrintManager; }
        }

        private void HandlePageDisposed(object sender, EventArgs e)
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

        protected override ProcedureDeviationDTO CreateDtoFromDomainObject(ProcedureDeviation item)
        {
            return (ProcedureDeviationDTO) item.CreateDTO();
        }

        protected override void HandleRepeaterCreated(object sender, DomainEventArgs<ProcedureDeviation> e)
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

        protected override void HandleRepeaterUpdated(object sender, DomainEventArgs<ProcedureDeviation> e)
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

        public override void HookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerProcedureDeviationFormCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerProcedureDeviationFormUpdated += HandleRepeaterUpdated;
            remoteEventRepeater.ServerProcedureDeviationFormRemoved += HandleRepeaterRemoved;
        }

        public override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerProcedureDeviationFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerProcedureDeviationFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerProcedureDeviationFormRemoved -= HandleRepeaterRemoved;
        }

        public override void SetDetailData(FormProcedureDeviationDetails details, ProcedureDeviation form)
        {
            // TODO:

            details.CreatedByUser = form.CreatedBy;
            details.CreatedDateTime = form.CreatedDateTime;

            details.LastModifiedByUser = form.LastModifiedBy;
            details.LastModifiedDateTime = form.LastModifiedDateTime;

            details.FormNumber = form.FormNumber;
            details.FormStatus = form.FormStatus.GetName();

            details.SuggestedCompletionDateTime = form.ToDateTime;
//            details.ScheduledCompletionDateTime = form.ScheduledCompletionDateTime;

            details.FunctionalLocations = form.FunctionalLocations;

            details.NumberOfExtensions = form.NumberOfExtensions;
            details.ReasonForExtensions = form.ReasonsForExtensionSortedByCreatedDate;

            details.LocationEquipmentNumber = form.LocationEquipmentNumber;
            details.DocumentLinks = form.DocumentLinks;

//            details.ExistingDocument = form.IsExistingDocument;
//            details.DocumentOwner = form.DocumentOwner;
//            details.DocumentNumber = form.DocumentNumber;
//            details.DocumentTitle = form.DocumentTitle;
//
//            details.OriginalMarkedUp = form.OriginalMarkedUp;
//            details.HardCopySubmittedTo = form.HardCopySubmittedTo;
//
//            details.RecommendedToBeArchived = form.RecommendedToBeArchived;
            details.ContentRichText = form.RichTextDescription;

            SetApprovals(details, form);

            details.ProcedureDeviation = form;
        }

        private static void SetApprovals(FormProcedureDeviationDetails details, ProcedureDeviation form)
        {
            var viewApprovals = form.AllApprovals;
            DisplayOrderHelper.SortAndResetDisplayOrder(viewApprovals);
            details.Approvals = viewApprovals;
//            details.NotApprovedReason = form.NotApprovedReason;
        }

        public override void ControlDetailButtons()
        {
            // TODO: implement and enable Clone button as per #3983
            base.ControlDetailButtons();

            var selectedItems = GetSelectedItems();
            var hasSingleItemSelected = selectedItems.Count == 1;
            var userRoleElements = userContext.UserRoleElements;

            var selectedForm = hasSingleItemSelected ? selectedItems[0] : null;

            details.DeleteEnabled = hasSingleItemSelected &&
                                    authorized.ToDeleteFormProcedureDeviation(userRoleElements, userContext.SiteId) &&
                                    selectedForm != null &&
                                    selectedForm.CanDelete(userContext.User.IdValue);
            details.CloneEnabled = hasSingleItemSelected &&
                                   authorized.ToCreateFormProcedureDeviation(userRoleElements, userContext.SiteId) &&
                                   selectedForm != null;
            details.EmailButtonVisible = false;
            details.CancelVisible = false;
            details.EditEnabled = hasSingleItemSelected &&
                                  authorized.ToEditFormProcedureDeviation(userRoleElements, userContext.SiteId) &&
                                  selectedForm != null &&
                                  selectedForm.CanEdit();

            details.PrintEnabled = selectedItems.Count > 0;
            details.PrintPreviewEnabled = hasSingleItemSelected;
        }

        public override IList<ProcedureDeviationDTO> GetData(RootFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            var dtos = formService.QueryProcedureDeviationDtos(flocSet, dateRange, userContext.User.IdValue);
            timerManager.Clear();
            dtos.ForEach(RegisterRenderTimer);
            return dtos;
        }

        private void RegisterRenderTimer(ProcedureDeviationDTO dto)
        {
            timerManager.Unregister(dto);
            var now = Clock.Now;

            // forms that are draft, expired, or in a final state will never auto change their status
            if (dto.Status == FormStatus.Draft ||
                dto.IsExpired(now) ||
                dto.Status == FormStatus.Complete ||
                dto.Status == FormStatus.Cancelled) return;

            if (dto.ValidFrom > now)
            {
                var timeUntilActive = dto.ValidFrom.Subtract(now);
                SetupTimerCallback(timeUntilActive, dto);
            }
            else
            {
                var timeUntilExpired = dto.ValidTo.Subtract(now);
                SetupTimerCallback(timeUntilExpired, dto);
            }
        }

        private void SetupTimerCallback(TimeSpan differenceInTime, ProcedureDeviationDTO dto)
        {
            var timeRemainingInShift = ClientSession.GetInstance().GetTimeRemainingInShiftWithPostShiftPadding();
            if ((differenceInTime.Ticks > 0 && (differenceInTime < timeRemainingInShift)))
            {
                SetupTimerForCallback(dto, differenceInTime);
            }
        }

        private void SetupTimerForCallback(ProcedureDeviationDTO dto, TimeSpan differenceInTime)
        {
            try
            {
                timerManager.RegisterTimer(dto, differenceInTime, HandleTimerFire);
            }
            catch (TimerDueTimeNegativeException e)
            {
                logger.Error("Encountered negative timer due time for Procedure Deviation:<" + dto.Id + ">", e);
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
            if (!(dto is ProcedureDeviationDTO)) return;

            if (!(page.Grid is DomainSummaryGrid<ProcedureDeviationDTO>))
            {
                DataNeedsRefresh = true;

                return;
            }

            var procedureDeviationDTO = (ProcedureDeviationDTO) dto;
            RegisterRenderTimer(procedureDeviationDTO);

            var domainSummaryGrid = ((DomainSummaryGrid<ProcedureDeviationDTO>) page.Grid);
            var oldVersion =
                domainSummaryGrid.FindItem(procedureDeviationDTO.Id);

            if (oldVersion == null) return;

            var updateIndex = domainSummaryGrid.Items.IndexOf(oldVersion);

            if (updateIndex == -1)
            {
                domainSummaryGrid.AddItem(procedureDeviationDTO);
            }
            else
            {
                domainSummaryGrid.UpdateItem(updateIndex, procedureDeviationDTO);
            }
        }

        protected override EdmontonFormType FormTypeToQuery()
        {
            return EdmontonFormType.ProcedureDeviation;
        }

        //ayman generic forms
        public override ProcedureDeviation QueryByIdAndSiteId(long id,long siteid)
        {
            return formService.QueryProcedureDeviationFormByIdAndSiteId(id,siteid);
        }
        
        public override ProcedureDeviation QueryById(long id)
        {
            return formService.QueryProcedureDeviationFormById(id);
        }

        protected override void Update(ProcedureDeviation form)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                formService.UpdateProcedureDeviationForm, form);
        }

        protected override IForm CreateEditForm(ProcedureDeviation item)
        {
            var presenter = new ProcedureDeviationFormPresenter(item);
            return presenter.View;
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(ProcedureDeviation item)
        {
            return new ProcedureDeviationHistoryFormPresenter(item);
        }

        protected override void Delete(ProcedureDeviation form)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                formService.DeleteProcedureDeviationForm, form);
        }

        protected override void HandleClone()
        {
            var context = ClientSession.GetUserContext();
            var defaultEndDateForImmediateDeviation = context.UserShift.EndDateTime.AddHours(ProcedureDeviation.DefaultEndDateHoursForImmediateDeviation);
            var defaultEndDateForTemporaryDeviation = context.UserShift.EndDateTime.AddYears(ProcedureDeviation.DefaultEndDateYearsForTemporaryDeviation);

            ProcedureDeviation form = QueryForFirstSelectedItem();
            form.ConvertToClone(ClientSession.GetUserContext().User);

            var startDateTime = context.UserShift.StartDateTime;
            var endDateTime = form.Type == ProcedureDeviationType.Immediate
                ? defaultEndDateForImmediateDeviation
                : defaultEndDateForTemporaryDeviation;

            form.FromDateTime = startDateTime;
            form.ToDateTime = endDateTime;

            IForm editForm = CreateEditForm(form);

            if (editForm != null)
            {
                editForm.ShowDialog(page.ParentForm);
                editForm.Dispose();
            }
        }

        public override Range<Date> GetDefaultDateRange()
        {
            // TODO: add site config params - piggy backing off doc suggestion for now

            var now = Clock.DateNow;
            var from = now.AddDays(-1*userContext.SiteConfiguration.DaysToDisplayDocumentSuggestionFormsBackwards);
            var to = userContext.SiteConfiguration.DaysToDisplayDocumentSuggestionFormsForwards == null
                ? null
                : now.AddDays(userContext.SiteConfiguration.DaysToDisplayDocumentSuggestionFormsForwards.Value);

            return new Range<Date>(from, to);
        }

        public override DialogResultAndOutput<ProcedureDeviation> Edit(ProcedureDeviation domainObject, IBaseForm view)
        {
            var presenter = new ProcedureDeviationFormPresenter(domainObject);
            return presenter.RunAndReturnTheEditObject(view);
        }

        public override DialogResultAndOutput<ProcedureDeviation> CreateNew(IBaseForm view)
        {
            var presenter = new ProcedureDeviationFormPresenter();
            return presenter.RunAndReturnTheEditObject(view);
        }
    }
}