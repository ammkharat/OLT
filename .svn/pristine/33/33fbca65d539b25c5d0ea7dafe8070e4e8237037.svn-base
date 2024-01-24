using System;
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
    public class DocumentSuggestionFormContext :
        AbstractEdmontonFormContext<DocumentSuggestionDTO, DocumentSuggestion, FormDocumentSuggestionDetails>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (DocumentSuggestionFormContext));
        private readonly IReportPrintManager<DocumentSuggestion> reportPrintManager;
        private readonly WindowsFormsSynchronizationContext synchronizationContext;
        private readonly DocumentSuggestionTimerManager timerManager;

        public DocumentSuggestionFormContext(IFormEdmontonService formService, AbstractMultiGridPage page)
            : base(
                formService, page, EdmontonFormType.DocumentSuggestion, new FormDocumentSuggestionDetails(),
                new DocumentSuggestionGridRenderer())
        {
            var printActions = new DocumentSuggestionReportPrintActions();
            reportPrintManager =
                new ReportPrintManager
                    <DocumentSuggestion, DocumentSuggestionReport,
                        DocumentSuggestionReportAdapter>(
                    printActions);

            synchronizationContext = (WindowsFormsSynchronizationContext) SynchronizationContext.Current;
            timerManager = new DocumentSuggestionTimerManager();
            page.Disposed += HandlePageDisposed;
        }

        public override bool IsItemSelected
        {
            get { return grid.SelectedItem != null; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_DocumentSuggestionForm; }
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.DocumentSuggestion; }
        }

        protected override IReportPrintManager<DocumentSuggestion> ReportPrintManager
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

        protected override DocumentSuggestionDTO CreateDtoFromDomainObject(DocumentSuggestion item)
        {
            return (DocumentSuggestionDTO) item.CreateDTO();
        }

        protected override void HandleRepeaterCreated(object sender, DomainEventArgs<DocumentSuggestion> e)
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

        protected override void HandleRepeaterUpdated(object sender, DomainEventArgs<DocumentSuggestion> e)
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
            remoteEventRepeater.ServerDocumentSuggestionFormCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerDocumentSuggestionFormUpdated += HandleRepeaterUpdated;
            remoteEventRepeater.ServerDocumentSuggestionFormRemoved += HandleRepeaterRemoved;
        }

        public override void UnHookToServiceEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerDocumentSuggestionFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerDocumentSuggestionFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerDocumentSuggestionFormRemoved -= HandleRepeaterRemoved;
        }

        public override void SetDetailData(FormDocumentSuggestionDetails details, DocumentSuggestion form)
        {
            details.CreatedByUser = form.CreatedBy;
            details.CreatedDateTime = form.CreatedDateTime;

            details.LastModifiedByUser = form.LastModifiedBy;
            details.LastModifiedDateTime = form.LastModifiedDateTime;

            details.FormNumber = form.FormNumber;
            details.FormStatus = form.FormStatus.GetName();

            details.SuggestedCompletionDateTime = form.ToDateTime;
            details.ScheduledCompletionDateTime = form.ScheduledCompletionDateTime;

            details.FunctionalLocations = form.FunctionalLocations;

            details.NumberOfExtensions = form.NumberOfExtensions;
            details.ReasonForExtensions = form.ReasonsForExtensionSortedByCreatedDate;

            details.LocationEquipmentNumber = form.LocationEquipmentNumber;
            details.DocumentLinks = form.DocumentLinks;

            details.ExistingDocument = form.IsExistingDocument;
            details.DocumentOwner = form.DocumentOwner;
            details.DocumentNumber = form.DocumentNumber;
            details.DocumentTitle = form.DocumentTitle;

            details.OriginalMarkedUp = form.OriginalMarkedUp;
            details.HardCopySubmittedTo = form.HardCopySubmittedTo;

            details.RecommendedToBeArchived = form.RecommendedToBeArchived;
            details.ContentRichText = form.RichTextDescription;

            SetApprovals(details, form);

            details.DocumentSuggestion = form;
        }

        private static void SetApprovals(FormDocumentSuggestionDetails details, DocumentSuggestion form)
        {
            var viewApprovals = form.AllApprovals;
            DisplayOrderHelper.SortAndResetDisplayOrder(viewApprovals);
            details.Approvals = viewApprovals;
            details.NotApprovedReason = form.NotApprovedReason;
        }

        public override void ControlDetailButtons()
        {
            base.ControlDetailButtons();

            var selectedItems = GetSelectedItems();
            var hasSingleItemSelected = selectedItems.Count == 1;
            var userRoleElements = userContext.UserRoleElements;

            var selectedForm = hasSingleItemSelected ? selectedItems[0] : null;

            details.DeleteEnabled = hasSingleItemSelected &&
                                    authorized.ToDeleteFormDocumentSuggestion(userRoleElements, userContext.SiteId) &&
                                    selectedForm != null &&
                                    selectedForm.CanDelete(userContext.User.IdValue);
            details.EmailButtonVisible = false;
            details.CancelVisible = false;
            details.EditEnabled = hasSingleItemSelected &&
                                  authorized.ToEditFormDocumentSuggestion(userRoleElements, userContext.SiteId) &&
                                  selectedForm != null &&
                                  selectedForm.CanEdit();

            details.PrintEnabled = selectedItems.Count > 0;
            details.PrintPreviewEnabled = hasSingleItemSelected;
        }

        public override IList<DocumentSuggestionDTO> GetData(RootFlocSet flocSet,
            DateRange dateRange,
            List<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            var dtos = formService.QueryDocumentSuggestionDtos(flocSet, dateRange, userContext.User.IdValue);
            timerManager.Clear();
            dtos.ForEach(RegisterRenderTimer);
            return dtos;
        }

        private void RegisterRenderTimer(DocumentSuggestionDTO dto)
        {
            timerManager.Unregister(dto);
            var now = Clock.Now;

            // forms that are draft, late, or in a final state will never auto change their status
            if (dto.Status == FormStatus.Draft || dto.IsLate(now) || dto.IsComplete()) return;

            if (dto.ValidFrom > now)
            {
                var timeUntilActive = dto.ValidFrom.Subtract(now);
                SetupTimerCallback(timeUntilActive, dto);
            }
            else
            {
                var timeUntilLate = dto.LatestCompletionDate.Subtract(now);
                SetupTimerCallback(timeUntilLate, dto);
            }
        }

        private void SetupTimerCallback(TimeSpan differenceInTime, DocumentSuggestionDTO dto)
        {
            var timeRemainingInShift = ClientSession.GetInstance().GetTimeRemainingInShiftWithPostShiftPadding();
            if ((differenceInTime.Ticks > 0 && (differenceInTime < timeRemainingInShift)))
            {
                SetupTimerForCallback(dto, differenceInTime);
            }
        }

        private void SetupTimerForCallback(DocumentSuggestionDTO dto, TimeSpan differenceInTime)
        {
            try
            {
                timerManager.RegisterTimer(dto, differenceInTime, HandleTimerFire);
            }
            catch (TimerDueTimeNegativeException e)
            {
                logger.Error("Encountered negative timer due time for Document Suggestion:<" + dto.Id + ">", e);
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
            if (!(dto is DocumentSuggestionDTO)) return;

            if (!(page.Grid is DomainSummaryGrid<DocumentSuggestionDTO>))
            {
                DataNeedsRefresh = true;

                return;
            }

            var documentSuggestionDTO = (DocumentSuggestionDTO) dto;
            RegisterRenderTimer(documentSuggestionDTO);

            var domainSummaryGrid = ((DomainSummaryGrid<DocumentSuggestionDTO>) page.Grid);
            var oldVersion =
                domainSummaryGrid.FindItem(documentSuggestionDTO.Id);

            if (oldVersion == null) return;

            var updateIndex = domainSummaryGrid.Items.IndexOf(oldVersion);

            if (updateIndex == -1)
            {
                domainSummaryGrid.AddItem(documentSuggestionDTO);
            }
            else
            {
                domainSummaryGrid.UpdateItem(updateIndex, documentSuggestionDTO);
            }
        }

        protected override EdmontonFormType FormTypeToQuery()
        {
            return EdmontonFormType.DocumentSuggestion;
        }

        //ayman generic forms
        public override DocumentSuggestion QueryByIdAndSiteId(long id,long siteid)
        {
            return formService.QueryDocumentSuggestionFormByIdAndSiteId(id,siteid);
        }

        public override DocumentSuggestion QueryById(long id)
        {
            return formService.QueryDocumentSuggestionFormById(id);
        }

        protected override void Update(DocumentSuggestion form)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                formService.UpdateDocumentSuggestionForm, form);
        }

        protected override IForm CreateEditForm(DocumentSuggestion item)
        {
            var presenter = new DocumentSuggestionFormPresenter(item);
            return presenter.View;
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(DocumentSuggestion item)
        {
            return new DocumentSuggestionHistoryFormPresenter(item);
        }

        protected override void Delete(DocumentSuggestion form)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                formService.DeleteDocumentSuggestionForm, form);
        }

        public override Range<Date> GetDefaultDateRange()
        {
            var now = Clock.DateNow;
            var from = now.AddDays(-1*userContext.SiteConfiguration.DaysToDisplayDocumentSuggestionFormsBackwards);
            var to = userContext.SiteConfiguration.DaysToDisplayDocumentSuggestionFormsForwards == null
                ? null
                : now.AddDays(userContext.SiteConfiguration.DaysToDisplayDocumentSuggestionFormsForwards.Value);

            return new Range<Date>(from, to);
        }

        public override DialogResultAndOutput<DocumentSuggestion> Edit(DocumentSuggestion domainObject, IBaseForm view)
        {
            var presenter = new DocumentSuggestionFormPresenter(domainObject);
            return presenter.RunAndReturnTheEditObject(view);
        }

        public override DialogResultAndOutput<DocumentSuggestion> CreateNew(IBaseForm view)
        {
            var presenter = new DocumentSuggestionFormPresenter();
            return presenter.RunAndReturnTheEditObject(view);
        }
    }
}