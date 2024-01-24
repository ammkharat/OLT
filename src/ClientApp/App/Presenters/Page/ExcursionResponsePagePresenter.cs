using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Castle.Core.Internal;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class ExcursionResponsePagePresenter :
        AbstractDeletableDomainPagePresenter
            <OpmExcursionResponseDTO, OpmExcursion, IExcursionResponseDetails, IExcursionResponsePage>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (ExcursionResponsePagePresenter));

        private readonly IAuthorized authorized;
        private readonly ClientBackgroundWorker backgroundWorker;
        private readonly List<OpmExcursion> createdExcursionsBatch = new List<OpmExcursion>();

        private readonly IFunctionalLocationService functionalLocationService;
        private readonly IExcursionImportService importService;
        private readonly IExcursionResponseService service;
        private readonly List<OpmExcursion> updatedExcursionsBatch = new List<OpmExcursion>();

        private DateTime? lastExcursionUpdateDateTime;
        private string opmServiceStatusDescription;

        public ExcursionResponsePagePresenter() : base(new ExcursionResponsePage())
        {
            service = ClientServiceRegistry.Instance.GetService<IExcursionResponseService>();
            importService = ClientServiceRegistry.Instance.GetService<IExcursionImportService>();
            functionalLocationService = ClientServiceRegistry.Instance.GetService<IFunctionalLocationService>();
            backgroundWorker = new ClientBackgroundWorker();
            backgroundWorker.DoWork += GetCurrentTagValue;
            backgroundWorker.RunWorkerCompleted += SetCurrentTagValue;
            backgroundWorker.WorkerSupportsCancellation = true;
            page.Details.ViewEnvelopeCommentsHistory += HandleEnvelopeCommentsHistory;
            authorized = new Authorized();
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_Excursion; }
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.ExcursionEvents; }
        }

        protected override OpmExcursionResponseDTO CreateDTOFromDomainObject(OpmExcursion item)
        {
            return item.CreateExcursionResponseDTO();
        }

        protected override IForm CreateEditForm(OpmExcursion item)
        {
            if (page.SelectedItems.Count > 100)
            {
                OltMessageBox.ShowError(string.Format(StringResources.ExcursionResponse_TooManySelectedMessage,page.SelectedItems.Count));
                return null;
            }

            var opmExcursionEditPackage =
                service.CreateEditPackage(page.SelectedItems.ConvertAll(input => input.IdValue));

            if (opmExcursionEditPackage.IsUniqueToeExcursion)
            {
                var presenter = new EditExcursionResponsePresenter(new ExcursionResponseForm(), opmExcursionEditPackage);
                return presenter.View;
            }
            else
            {
                var presenter = new EditMultiExcursionResponsesPresenter(new MultiExcursionResponsesForm(),
                    opmExcursionEditPackage);
                return presenter.View;
            }
        }

        protected override void Delete(OpmExcursion item)
        {
            // will never delete excursions
        }

        protected override void UnSubscribeFromEvents()
        {
            base.UnSubscribeFromEvents();

            page.Details.ViewEnvelopeCommentsHistory -= HandleEnvelopeCommentsHistory;
        }

        protected override OpmExcursion QueryByDto(OpmExcursionResponseDTO dto)
        {
            return service.QueryById(dto.IdValue);
        }

        protected override IList<OpmExcursionResponseDTO> GetDtos(Range<Date> dateRange)
        {
            var queryDtOsByDateRangeAndFlocs =
                service.QueryDTOsByDateRangeAndFlocs(new DateRange(dateRange.LowerBound, dateRange.UpperBound),
                    userContext.SelectedFunctionalLocations);

            if (firstTimeLoad)
            {
                var lastSuccessfulExcursionImportStatus = importService.GetLastSuccessfulExcursionImportStatus();

                SetOpmExcursionImportStatus(lastSuccessfulExcursionImportStatus);
            }

            return queryDtOsByDateRangeAndFlocs;
        }

        protected override void HookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerOpmExcursionCreated += repeater_Created;
            remoteEventRepeater.ServerOpmExcursionUpdated += repeater_Updated;
            remoteEventRepeater.ServerOpmExcursionRemoved += repeater_Removed;
            remoteEventRepeater.ServerOpmExcursionImportStatusUpdated += HandleRepeaterImportStatusUpdated;
            remoteEventRepeater.ServerOpmExcursionBatchCreated += repeater_BatchCreated;
            remoteEventRepeater.ServerOpmExcursionBatchUpdated += repeater_BatchUpdated;
        }

        protected override void UnHookToServiceEvents(IRemoteEventRepeater repeater)
        {
            remoteEventRepeater.ServerOpmExcursionCreated -= repeater_Created;
            remoteEventRepeater.ServerOpmExcursionUpdated -= repeater_Updated;
            remoteEventRepeater.ServerOpmExcursionRemoved -= repeater_Removed;
            remoteEventRepeater.ServerOpmExcursionImportStatusUpdated -= HandleRepeaterImportStatusUpdated;
            remoteEventRepeater.ServerOpmExcursionBatchCreated -= repeater_BatchCreated;
            remoteEventRepeater.ServerOpmExcursionBatchUpdated -= repeater_BatchUpdated;
        }

        private void HandleRepeaterImportStatusUpdated(object sender, DomainEventArgs<OpmExcursionImportStatusDTO> e)
        {
            var opmExcursionImportStatusDTO = e.SelectedItem;

            SetOpmExcursionImportStatus(opmExcursionImportStatusDTO);
        }

        private void SetOpmExcursionImportStatus(OpmExcursionImportStatusDTO opmExcursionImportStatusDTO)
        {
            Bitmap descriptionImage = null;

            if (opmExcursionImportStatusDTO.Status == OpmExcursionImportStatus.Available)
            {
                lastExcursionUpdateDateTime = opmExcursionImportStatusDTO.LastSuccessfulExcursionImportDateTime ??
                                              DateTime.Now;
                opmServiceStatusDescription =
                    string.Format(
                        StringResources.PriorityPage_ExcursionEventSubSectionLastSuccessfulExcursionImportDateTimeFormat,
                        lastExcursionUpdateDateTime.Value.ToString("MM/dd/yyyy HH:mm"));
            }
            else
            {
                opmServiceStatusDescription = lastExcursionUpdateDateTime.HasValue
                    ? string.Format(
                        StringResources.PriorityPage_ExcursionEventSubSectionLastFailedExcursionImportDateTimeFormat,
                        lastExcursionUpdateDateTime.Value.ToString("MM/dd/yyyy HH:mm"))
                    : StringResources.PriorityPage_ExcursionEventSubSectionLastFailedExcursionImportNoDateTimeFormat;
                descriptionImage = Properties.Resources.Warning_12;
            }

            SetPageTitle();
        }

        protected override string SetSecondLineOfPageTitle()
        {
            return opmServiceStatusDescription;
        }

        protected override void repeater_Created(object sender, DomainEventArgs<OpmExcursion> e)
        {
            var excursion = e.SelectedItem;
            if (IsRelevantItemFromServerEvent(excursion))
            {
                DisableSelectedItemChangedEvent();
                RefreshItem(excursion);
                base.repeater_Created(sender, e);
                EnableSelectedItemChangedEvent();
            }
        }

        protected override void repeater_Updated(object sender, DomainEventArgs<OpmExcursion> e)
        {
            var excursion = e.SelectedItem;
            if (IsRelevantItemFromServerEvent(excursion))
            {
                DisableSelectedItemChangedEvent();
                RefreshItem(excursion);
                base.repeater_Updated(sender, e);
                EnableSelectedItemChangedEvent();
            }
        }

        private void repeater_BatchCreated(object sender, DomainEventArgs<OpmExcursionBatch> e)
        {
            var excursionBatch = e.SelectedItem;
            var relevantExcursions = excursionBatch.Excursions.Where(IsRelevantItemFromServerEvent).ToList();
            if (relevantExcursions.IsNullOrEmpty()) return;

            AddExcursionsToBatch(createdExcursionsBatch, relevantExcursions);
            DisableSelectedItemChangedEvent();
            try
            {
                if (RefreshRelevantExcursionsFromBatch(createdExcursionsBatch))
                {
                    ControlShowingOfDetailsPane();
                }
            }
            catch (Exception ex)
            {
                ControlShowingOfDetailsPane();

                logger.Error("An error occurred while updating excursion objects in the grid", ex);
            }
            finally
            {
                EnableSelectedItemChangedEvent();
            }
        }

        private void repeater_BatchUpdated(object sender, DomainEventArgs<OpmExcursionBatch> e)
        {
            var excursionBatch = e.SelectedItem;
            var relevantExcursions = excursionBatch.Excursions.Where(IsRelevantItemFromServerEvent).ToList();
            if (relevantExcursions.IsNullOrEmpty()) return;

            AddExcursionsToBatch(updatedExcursionsBatch, relevantExcursions);
            DisableSelectedItemChangedEvent();
            try
            {
                if (RefreshRelevantExcursionsFromBatch(updatedExcursionsBatch))
                {
                    ControlShowingOfDetailsPane();
                }
            }
            catch (Exception ex)
            {
                ControlShowingOfDetailsPane();

                logger.Error("An error occurred while updating excursion objects in the grid", ex);
            }
            finally
            {
                EnableSelectedItemChangedEvent();
            }
        }

        private void AddExcursionsToBatch(List<OpmExcursion> excursionBatch, IEnumerable<OpmExcursion> excursions)
        {
            try
            {
                Monitor.TryEnter(excursionBatch, 100);

                excursionBatch.AddRange(excursions);
            }
            finally
            {
                Monitor.Exit(excursionBatch);
            }
        }

        private bool RefreshRelevantExcursionsFromBatch(List<OpmExcursion> excursionBatch)
        {
            var itemsUpdated = false;

            try
            {
                Monitor.TryEnter(excursionBatch, 100);

                itemsUpdated = RefreshItemsFromBatch(excursionBatch) > 0;
            }
            finally
            {
                excursionBatch.Clear();
                Monitor.Exit(excursionBatch);
            }

            return itemsUpdated;
        }

        private int RefreshItemsFromBatch(List<OpmExcursion> excursionBatch)
        {
            if (page.IsDisposed || excursionBatch.IsNullOrEmpty())
            {
                return 0;
            }

            var dtos = excursionBatch.Select(excursion => excursion.CreateExcursionResponseDTO()).ToList();

            if (page.Grid.InvokeRequired)
            {
                page.Grid.BeginInvoke(
                    new MethodInvoker(delegate
                    {
                        page.Grid.BeginUpdate();
                        page.Grid.AddOrUpdateItems(dtos);
                        page.Grid.EndUpdate();
                    }));
            }
            else
            {
                page.Grid.BeginUpdate();
                page.Grid.AddOrUpdateItems(dtos);
                page.Grid.EndUpdate();
            }

            AddOrUpdateItemsBeforeSearch(excursionBatch);

            return excursionBatch.Count;
        }

        private void RefreshItem(OpmExcursion excursion)
        {
            if (page.IsDisposed || excursion == null)
            {
                return;
            }

            var excursionResponseDto = excursion.CreateExcursionResponseDTO();

            var oldVersion = page.Grid.FindItem(excursionResponseDto.Id);
            var updateIndex = page.Grid.Items.IndexOf(oldVersion);

            if (updateIndex == -1)
            {
                if (page.Grid.InvokeRequired)
                {
                    page.Grid.BeginInvoke(new MethodInvoker(delegate
                    {
                        page.Grid.BeginUpdate();
                        page.Grid.AddItem(excursionResponseDto);
                        page.Grid.EndUpdate();
                    }));
                }
                else
                {
                    page.Grid.BeginUpdate();
                    page.Grid.AddItem(excursionResponseDto);
                    page.Grid.EndUpdate();
                }
            }
            else
            {
                if (page.Grid.InvokeRequired)
                {
                    page.Grid.BeginInvoke(new MethodInvoker(delegate
                    {
                        page.Grid.BeginUpdate();
                        page.Grid.UpdateItem(updateIndex, excursionResponseDto);
                        page.Grid.EndUpdate();
                    }));
                }
                else
                {
                    page.Grid.BeginUpdate();
                    page.Grid.UpdateItem(updateIndex, excursionResponseDto);
                    page.Grid.EndUpdate();
                }
            }
        }

        protected bool IsRelevantItemFromServerEvent(OpmExcursion item)
        {
            if (item == null) return false;

            // Check flocs
            var excursionFloc = functionalLocationService.QueryByFullHierarchy(item.FunctionalLocation,
                userContext.SiteId);
            if (excursionFloc == null) return false;

            var flocsMatch =
                userContext.RootsForSelectedFunctionalLocations.Exists(excursionFloc.IsOrIsAncestorOfOrIsDescendantOf);

            return flocsMatch;
        }

        protected override void ControlDetailButtons()
        {
            var details = page.Details;

            var selectedItems = page.SelectedItems;
            var hasItemsSelected = selectedItems.Count > 0;
            var hasSingleItemSelected = selectedItems.Count == 1;

            var userRoleElements = userContext.UserRoleElements;
            var canRespond = authorized.ToRespondToExcursionEvents(userRoleElements);

            var now = Clock.Now;
            details.EditEnabled = canRespond && hasItemsSelected;
            details.DeleteEnabled = false;
            details.ViewEditHistoryEnabled = hasSingleItemSelected;
            details.EnvelopeCommentsHistoryEnabled = hasSingleItemSelected;
        }

        protected override void SetDetailData(IExcursionResponseDetails details, OpmExcursion excursion)
        {
            var detailsPage = details as ExcursionResponseDetails;
            if (detailsPage != null && !detailsPage.IsDisposed)
            {
                if (detailsPage.InvokeRequired)
                {
                    detailsPage.Invoke(new MethodInvoker(() => detailsPage.SetDetails(excursion)));
                }
                else
                {
                    detailsPage.SetDetails(excursion);
                }
            }

            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
                Thread.Sleep(50);
            }
            if (!backgroundWorker.CancellationPending)
            {
                backgroundWorker.RunWorkerAsync(excursion.HistorianTag);
            }
        }

        private void SetCurrentTagValue(object sender, RunWorkerCompletedEventArgs e)
        {
            if (page == null || page.IsOnNonUiThread() || e.Cancelled) return;

            var opmCurrentTagValueDto = e.Result as OpmTagValueDTO;
            if (opmCurrentTagValueDto != null)
            {
                page.Details.SetCurrentTagValue(opmCurrentTagValueDto.Value.FormatToThreePlaces());
            }
            else
            {
                page.Details.SetCurrentTagValue("N/A from OPM");
            }
        }

        private void GetCurrentTagValue(object sender, DoWorkEventArgs e)
        {
            e.Result = importService.GetCurrentOpmTagValue(e.Argument.ToString());
            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void HandleEnvelopeCommentsHistory(object sender, EventArgs e)
        {
            var item = QueryForFirstSelectedItem();
            if (item != null && item.OpmToeDefinition != null)
            {
                var presenter =
                    new OpmToeDefinitionCommentHistoryPresenter(item.OpmToeDefinition);
                presenter.Run(page.ParentForm);
            }
        }

        protected override EditHistoryFormPresenter CreateHistoryPresenter(OpmExcursion item)
        {
            return new ExcursionResponseHistoryPresenter(item.OpmExcursionResponse);
        }


        protected override Range<Date> GetDefaultDateRange()
        {
            var daysToDisplayCokerCards = userContext.SiteConfiguration.DaysToDisplayEventsBackwards;
            if (!daysToDisplayCokerCards.HasValue) daysToDisplayCokerCards = 3;
            var lowerBound = Clock.Now.SubtractDays(daysToDisplayCokerCards.Value).GetNetworkPortable();
            var defaultRange = new Range<Date>(new Date(lowerBound), new Date(Clock.Now));
            return defaultRange;
        }
    }
}