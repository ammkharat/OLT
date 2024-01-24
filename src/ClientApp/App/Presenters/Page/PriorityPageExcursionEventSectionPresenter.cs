using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Castle.Core.Internal;
using Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Domain.PriorityPage;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using DevExpress.Charts.Native;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPageExcursionEventSectionPresenter :
        PriorityPageSectionPresenter<ExcursionEventPriorityPageDTO, OpmExcursion>
    {
        private readonly List<ExcursionEventPriorityPageDTO> excursionEventPriorityPageDtos;
        private readonly IExcursionImportService excursionImportService;
        private readonly DateTime excursionQueryFromDateTime;
        private readonly IExcursionResponseService excursionResponseService;
        private readonly IFunctionalLocationService functionalLocationService;
        private readonly int maxAllowableDurationMins;
        private readonly PriorityPage priorityPage;
        private readonly bool shouldShowSection;
        private readonly ExcursionEventTimerManager timerManager;
        private DateTime? lastExcursionUpdateDateTime;

        public PriorityPageExcursionEventSectionPresenter(IPage invokeControl,
            PriorityPageTree tree,
            IAuthorized authorized,
            UserContext userContext,
            IRemoteEventRepeater remoteEventRepeater,
            IExcursionResponseService excursionResponseService,
            PriorityPageSectionConfiguration sectionConfiguration,
            IFunctionalLocationService functionalLocationService,
            IExcursionImportService excursionImportService)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.excursionResponseService = excursionResponseService;
            this.functionalLocationService = functionalLocationService;
            this.excursionImportService = excursionImportService;

            priorityPage = invokeControl as PriorityPage;

            excursionEventPriorityPageDtos = new List<ExcursionEventPriorityPageDTO>();

            shouldShowSection = authorized.ToViewEventsOnPrioritiesPage(userContext.UserRoleElements);
            if (!shouldShowSection) return;

            var allowableTimeFrameMins = userContext.SiteConfiguration.MaximumAllowableExcursionEventTimeframeMins;
            excursionQueryFromDateTime =
                userContext.UserShift.StartDateTime.Subtract(TimeSpan.FromMinutes(allowableTimeFrameMins));

            maxAllowableDurationMins = userContext.SiteConfiguration.MaximumAllowableExcursionEventDurationMins;

            timerManager = new ExcursionEventTimerManager();

            this.invokeControl.Disposed += InvokeControlOnDisposed;
            AddSectionNode(PriorityPageSectionKey.ExcursionEvent);
            AddCriteriaBasedSubSectionNode(
                StringResources.PriorityPage_ExcursionEventSubSectionUnrespondedSolOpenOrRecentlyClosed,
                new UnrespondedOpenOrRecentlyClosedSolExcursionEventSectionCriteria(ExcursionQueryFromDateTime,
                    MaxAllowableDurationMins));
            AddCriteriaBasedSubSectionNode(
                StringResources.PriorityPage_ExcursionEventSubSectionUnrespondedSlOpenOrRecentlyClosed,
                new UnrespondedOpenOrRecentlyClosedSlExcursionEventSectionCriteria(ExcursionQueryFromDateTime,
                    MaxAllowableDurationMins));
            AddCriteriaBasedSubSectionNode(
                StringResources.PriorityPage_ExcursionEventSubSectionUnrespondedTargetOpenOrRecentlyClosed,
                new UnrespondedOpenOrRecentlyClosedTargetExcursionEventSectionCriteria(ExcursionQueryFromDateTime,
                    MaxAllowableDurationMins));
            AddCriteriaBasedSubSectionNode(
                StringResources.PriorityPage_ExcursionEventSubSectionRespondedExceedingOperatingLimits,
                new RespondedStillExceedingOperatingLimitExcursionEventSectionCriteria(MaxAllowableDurationMins));

            SubscribeToEvents(remoteEventRepeater);
        }

        private DateTime ExcursionQueryFromDateTime
        {
            get { return excursionQueryFromDateTime; }
        }

        private int MaxAllowableDurationMins
        {
            get { return maxAllowableDurationMins; }
        }

        private void InvokeControlOnDisposed(object sender, EventArgs eventArgs)
        {
            if (timerManager != null)
            {
                timerManager.Clear();
            }
        }

        private void HandleRepeaterCreated<T>(object sender, DomainEventArgs<T> e) where T : DomainObject
        {
            if (e.SelectedItem is OpmExcursion)
            {
                var excursion = e.SelectedItem as OpmExcursion;
                AddOrUpdateOpmExcursion(excursion);
            }
        }

        private void HandleRepeaterUpdated<T>(object sender, DomainEventArgs<T> e) where T : DomainObject
        {
            if (e.SelectedItem is OpmExcursion)
            {
                var excursion = e.SelectedItem as OpmExcursion;
                AddOrUpdateOpmExcursion(excursion);
            }
        }

        private void AddOrUpdateOpmExcursion(OpmExcursion excursion)
        {
            if (!IsRelevantItemFromServerEvent(excursion)) return;

            var dto = GetDto(excursion,"");

            if (dto != null)
            {
                dto.UpdateFromExcursion(excursion);
                excursionEventPriorityPageDtos.Remove(dto);
                if (dto.ExcursionCount > 0)
                {
                    excursionEventPriorityPageDtos.Add(dto);
                }
                RefreshItem(dto);
            }
            else
            {
                var newDto = new ExcursionEventPriorityPageDTO(excursion);
                excursionEventPriorityPageDtos.Add(newDto);
                RefreshItem(newDto);
            }
        }

        private void HandleRepeaterBatchCreated(object sender, DomainEventArgs<OpmExcursionBatch> e)
        {
            var excursionBatch = e.SelectedItem;
            if (excursionBatch == null) return;

            AddOrUpdateOpmExcursions(excursionBatch.Excursions);
        }

        private void HandleRepeaterBatchUpdated(object sender, DomainEventArgs<OpmExcursionBatch> e)
        {
            var excursionBatch = e.SelectedItem;
            if (excursionBatch == null) return;

            AddOrUpdateOpmExcursions(excursionBatch.Excursions);
        }

        private void AddOrUpdateOpmExcursions(List<OpmExcursion> excursions)
        {
            if (excursions.IsNullOrEmpty()) return;

            foreach (var opmExcursion in excursions)
            {
                AddOrUpdateOpmExcursion(opmExcursion);
            }
        }

        private void HandleRepeaterExcursionItemRefresh(object sender, DomainEventArgs<Site> e)
        {
            if (invokeControl.IsOnNonUiThread())
            {
                invokeControl.Invoke(
                    new Action<object, DomainEventArgs<Site>>(Invoked_Repeater_ServerExcursionItemRefresh), sender, e);
            }
            else
            {
                Invoked_Repeater_ServerExcursionItemRefresh(sender, e);
            }
        }

        private void Invoked_Repeater_ServerExcursionItemRefresh(object sender, DomainEventArgs<Site> e)
        {
            if (invokeControl.IsNotDisposed() && e.SelectedItem != null && e.SelectedItem.Id == userContext.Site.Id)
            {
                priorityPage.BeginUpdateTreeList();
                ClearAllDataNodes();
                LoadDtos(QueryDtos());
                priorityPage.EndUpdateTreeList();
            }
        }

        private void HandleRepeaterImportStatusUpdated(object sender, DomainEventArgs<OpmExcursionImportStatusDTO> e)
        {
            var opmExcursionImportStatusDTO = e.SelectedItem;

            string description;
            Bitmap descriptionImage = null;

            if (opmExcursionImportStatusDTO.Status == OpmExcursionImportStatus.Available)
            {
                lastExcursionUpdateDateTime = opmExcursionImportStatusDTO.LastSuccessfulExcursionImportDateTime ??
                                              DateTime.Now;
                description =
                    string.Format(
                        StringResources.PriorityPage_ExcursionEventSubSectionLastSuccessfulExcursionImportDateTimeFormat,
                        lastExcursionUpdateDateTime.Value.ToString("MM/dd/yyyy HH:mm"));
            }
            else
            {
                description = lastExcursionUpdateDateTime.HasValue
                    ? string.Format(
                        StringResources.PriorityPage_ExcursionEventSubSectionLastFailedExcursionImportDateTimeFormat,
                        lastExcursionUpdateDateTime.Value.ToString("MM/dd/yyyy HH:mm"))
                    : StringResources.PriorityPage_ExcursionEventSubSectionLastFailedExcursionImportNoDateTimeFormat;
                descriptionImage = Properties.Resources.Warning_12;
            }

            priorityPage.UpdateSectionNodeDescription(PriorityPageSectionKey.ExcursionEvent, description,
                descriptionImage);
        }

        public List<ExcursionEventPriorityPageDTO> QueryDtos()
        {
            var dtos = new List<ExcursionEventPriorityPageDTO>();

            if (!shouldShowSection)
            {
                return dtos;
            }

            // Combine the unresponded open or recently closed with the responded and still exceeding operating limits

            var unrespondedOpenOrRecentlyClosedDtos =
                excursionResponseService.QueryUnrespondedExcursionEventPriorityPageDTOsThatAreOpenOrRecentlyClosed(
                    ExcursionQueryFromDateTime, userContext.SelectedFunctionalLocations);
            dtos.AddRange(unrespondedOpenOrRecentlyClosedDtos);

            var respondedStillExceedingOperatingLimitsDtos =
                excursionResponseService
                    .QueryRespondedExcursionEventPriorityPageDTOsThatAreStillExceedingOperatingLimits(
                        ExcursionQueryFromDateTime, userContext.SelectedFunctionalLocations);
            dtos.AddRange(respondedStillExceedingOperatingLimitsDtos);

            return dtos;
        }

        public void LoadDtos(List<ExcursionEventPriorityPageDTO> dtos)
        {
            dtos.ForEach(RegisterRenderTimer);
            Load(dtos);

            excursionEventPriorityPageDtos.Clear();
            excursionEventPriorityPageDtos.AddRange(dtos);

            var lastSuccessfulExcursionImportStatus = excursionImportService.GetLastSuccessfulExcursionImportStatus();
            lastExcursionUpdateDateTime = lastSuccessfulExcursionImportStatus.LastSuccessfulExcursionImportDateTime;

            var lastExcursionUpdateDateTimeDisplay = lastExcursionUpdateDateTime.HasValue
                ? lastExcursionUpdateDateTime.Value.ToString("MM/dd/yyyy HH:mm")
                : "N/A";

            var description =
                string.Format(
                    StringResources.PriorityPage_ExcursionEventSubSectionLastSuccessfulExcursionImportDateTimeFormat,
                    lastExcursionUpdateDateTimeDisplay);
            priorityPage.UpdateSectionNodeDescription(PriorityPageSectionKey.ExcursionEvent, description, null);
        }

        private void SubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerOpmExcursionCreated += HandleRepeaterCreated;
            remoteEventRepeater.ServerOpmExcursionUpdated += HandleRepeaterUpdated;
            remoteEventRepeater.ServerOpmExcursionImportStatusUpdated += HandleRepeaterImportStatusUpdated;
            remoteEventRepeater.ServerOpmExcursionBatchCreated += HandleRepeaterBatchCreated;
            remoteEventRepeater.ServerOpmExcursionBatchUpdated += HandleRepeaterBatchUpdated;
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerOpmExcursionCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerOpmExcursionUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerOpmExcursionImportStatusUpdated -= HandleRepeaterImportStatusUpdated;
            remoteEventRepeater.ServerOpmExcursionBatchCreated -= HandleRepeaterBatchCreated;
            remoteEventRepeater.ServerOpmExcursionBatchUpdated -= HandleRepeaterBatchUpdated;

            invokeControl.Disposed -= InvokeControlOnDisposed;
        }

        protected override bool IsRelevantItemFromServerEvent(OpmExcursion item)
        {
            if (item == null) return false;

            // If this is an old excursion, closed and responded and we don't have it in our page already - ignore it
            if (IsOldRespondedAndClosedExcursion(item, ExcursionQueryFromDateTime)) return false;

            // Check flocs
            var excursionFloc = functionalLocationService.QueryByFullHierarchy(item.FunctionalLocation,
                userContext.SiteId);
            if (excursionFloc == null) return false;

            var flocsMatch =
                userContext.RootsForSelectedFunctionalLocations.Exists(excursionFloc.IsOrIsAncestorOfOrIsDescendantOf);

            return flocsMatch;
        }

        private bool IsOldRespondedAndClosedExcursion(OpmExcursion item, DateTime allowableTimeframeStartDateTime)
        {
            return item.OpmExcursionResponse != null && item.OpmExcursionResponse.HasResponse &&
                   item.Status == ExcursionStatus.Closed && item.EndDateTime.HasValue &&
                   item.EndDateTime.Value.Ticks < allowableTimeframeStartDateTime.Ticks;
        }

        protected override ExcursionEventPriorityPageDTO GetDto(OpmExcursion item,string ForAddUpdate)        //ayman action item reading
        {
            if (item == null) return null;

            // Find a group that contains this excursion
            var dto = excursionEventPriorityPageDtos.FirstOrDefault(
                excursionEventPriorityPageDto => excursionEventPriorityPageDto.ContainsExcursionById(item.IdValue));

            // If no group found with this excursion - check for a group with the same floc, toe name and version
            if (dto == null)
            {
                dto = excursionEventPriorityPageDtos.FirstOrDefault(
                    excursionEventPriorityPageDto =>
                        excursionEventPriorityPageDto.FunctionalLocationNames.Contains(item.FunctionalLocation) &&
                        excursionEventPriorityPageDto.HistorianTag == item.HistorianTag &&
                        excursionEventPriorityPageDto.ToeName == item.ToeName &&
                        excursionEventPriorityPageDto.ToeVersion == item.ToeVersion &&
                        excursionEventPriorityPageDto.ToeType == item.ToeType);
            }

            if (dto == null) return null;

            Debug.Assert(dto.FunctionalLocationNames.Contains(item.FunctionalLocation),
                "Found an ExcursionEventPriorityPageDTO node for an excursion id with different FLOC; this should never happen.");
            Debug.Assert(dto.ToeName == item.ToeName,
                "Found an ExcursionEventPriorityPageDTO node for an excursion id with different TOE definition name; this should never happen.");

            return dto;
        }

        protected override NodeData GetNodeData(ExcursionEventPriorityPageDTO dto)
        {
            if (dto == null) return null;

            // If the dto isn't already in the tree, create a new NodeData adapter
            NodeData excursionEventNodeData = new ExcursionEventNodeData(dto);

            // Find the subsection where this dto belongs, based on the criteria
            var subSectionNode = GetSubSectionNode(dto);
            if (subSectionNode != null)
            {
                var match = subSectionNode.FindMatchingExcursionEventNodeData(dto.IdValue);

                if (match != null)
                {
                    excursionEventNodeData = match;
                }
            }

            return excursionEventNodeData;
        }

        private void RegisterRenderTimer(ExcursionEventPriorityPageDTO dto)
        {
            // TODO: 
            return;

            timerManager.Unregister(dto);
            var now = Clock.Now;

            // this will never auto change its grouping
            if (dto.EndDateTime < now) return;

            // TODO: what if enddatetime is null?

//            var timeUntilRequiresApprovalOrExpires = dto.EndDateTime.Value.Subtract(now);
//            SetupTimerCallback(timeUntilRequiresApprovalOrExpires, dto);
        }

        private void SetupTimerCallback(TimeSpan differenceInTime, ExcursionEventPriorityPageDTO dto)
        {
            var timeRemainingInShift = ClientSession.GetInstance().GetTimeRemainingInShiftWithPostShiftPadding();
            if (differenceInTime < timeRemainingInShift)
            {
                timerManager.RegisterTimer(dto, differenceInTime, HandleTimerFire);
            }
        }

        private void HandleTimerFire(object dto)
        {
            // Execute on same thread that created the timer
            if (invokeControl.IsOnNonUiThread())
            {
                invokeControl.Invoke(new Action<ExcursionEventPriorityPageDTO>(RefreshItem), dto);
            }
            else
            {
                RefreshItem(dto);
            }
        }

        private void RefreshItem(object dto)
        {
            if (!(dto is ExcursionEventPriorityPageDTO)) return;
            var item = (ExcursionEventPriorityPageDTO) dto;
            RegisterRenderTimer(item);

            // Remove and re-add the DTO so that it ends up in the correct section (or gets removed from the priorities page)
            if (priorityPage.IsOnNonUiThread())
            {
                priorityPage.BeginInvoke(new MethodInvoker(delegate
                {
                    Remove(item);
                    if (item.ExcursionCount > 0)
                    {
                        Add(item);
                    }
                }));
            }
            else
            {
                Remove(item);
                if (item.ExcursionCount > 0)
                {
                    Add(item);
                }
            }
        }

        private class RespondedStillExceedingOperatingLimitExcursionEventSectionCriteria : ISubSectionCriteria
        {
            private readonly int maxAllowableDurationMins;

            public RespondedStillExceedingOperatingLimitExcursionEventSectionCriteria(int maxAllowableDurationMins)
            {
                this.maxAllowableDurationMins = maxAllowableDurationMins;
            }

            public bool Matches(ExcursionEventPriorityPageDTO dto)
            {
                var belongsInThisGroup =
                    dto.IsRespondedStillExceedingOperatingLimits(TimeSpan.FromMinutes(maxAllowableDurationMins));
                return belongsInThisGroup;
            }
        }

        private class UnrespondedOpenOrRecentlyClosedTargetExcursionEventSectionCriteria : ISubSectionCriteria
        {
            private readonly DateTime allowableTimeframeStartDateTime;
            private readonly int maxAllowableDurationMins;

            public UnrespondedOpenOrRecentlyClosedTargetExcursionEventSectionCriteria(
                DateTime allowableTimeframeStartDateTime, int maxAllowableDurationMins)
            {
                this.allowableTimeframeStartDateTime = allowableTimeframeStartDateTime;
                this.maxAllowableDurationMins = maxAllowableDurationMins;
            }

            public bool Matches(ExcursionEventPriorityPageDTO dto)
            {
                var belongsInThisGroup = dto.IsUnrespondedOpenOrRecentlyClosedTarget(allowableTimeframeStartDateTime,
                    TimeSpan.FromMinutes(maxAllowableDurationMins));
                return belongsInThisGroup;
            }
        }

        private class UnrespondedOpenOrRecentlyClosedSlExcursionEventSectionCriteria : ISubSectionCriteria
        {
            private readonly DateTime allowableTimeframeStartDateTime;
            private readonly int maxAllowableDurationMins;

            public UnrespondedOpenOrRecentlyClosedSlExcursionEventSectionCriteria(
                DateTime allowableTimeframeStartDateTime, int maxAllowableDurationMins)
            {
                this.allowableTimeframeStartDateTime = allowableTimeframeStartDateTime;
                this.maxAllowableDurationMins = maxAllowableDurationMins;
            }

            public bool Matches(ExcursionEventPriorityPageDTO dto)
            {
                var belongsInThisGroup = dto.IsUnrespondedOpenOrRecentlyClosedSl(allowableTimeframeStartDateTime,
                    TimeSpan.FromMinutes(maxAllowableDurationMins));
                return belongsInThisGroup;
            }
        }

        private class UnrespondedOpenOrRecentlyClosedSolExcursionEventSectionCriteria : ISubSectionCriteria
        {
            private readonly DateTime allowableTimeframeStartDateTime;
            private readonly int maxAllowableDurationMins;

            public UnrespondedOpenOrRecentlyClosedSolExcursionEventSectionCriteria(
                DateTime allowableTimeframeStartDateTime, int maxAllowableDurationMins)
            {
                this.allowableTimeframeStartDateTime = allowableTimeframeStartDateTime;
                this.maxAllowableDurationMins = maxAllowableDurationMins;
            }

            public bool Matches(ExcursionEventPriorityPageDTO dto)
            {
                var belongsInThisGroup = dto.IsUnrespondedOpenOrRecentlyClosedSol(allowableTimeframeStartDateTime,
                    TimeSpan.FromMinutes(maxAllowableDurationMins));
                return belongsInThisGroup;
            }
        }
    }
}