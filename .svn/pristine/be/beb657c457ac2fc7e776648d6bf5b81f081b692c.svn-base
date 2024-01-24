using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Domain.PriorityPage;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPageTargetAlertSectionPresenter : PriorityPageSectionPresenter<TargetAlertDTO, TargetAlert>
    {
        private readonly ITargetAlertService targetAlertService;

        private readonly TargetSectionCriteria outstandingAlertsSubSectionCriteria;
        private readonly TargetSectionCriteria alertsAcknowledgedOnCurrentShiftSubSectionCriteria;
        
        private readonly Range<DateTime> dateTimeRangeForOutstandingAlerts;
        private readonly Range<DateTime> dateTimeRangeForCurrentShift;
        private readonly bool authorizedToViewTargets;

        public PriorityPageTargetAlertSectionPresenter(
            IPage invokeControl, PriorityPageTree tree, IAuthorized authorized, UserContext userContext,
            IRemoteEventRepeater remoteEventRepeater,
            ITargetAlertService targetAlertService, 
            PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.targetAlertService = targetAlertService;

            authorizedToViewTargets = authorized.ToViewTargetsOnPrioritiesPage(userContext.UserRoleElements);
            if (authorizedToViewTargets)
            {
                dateTimeRangeForOutstandingAlerts = new Range<DateTime>(
                    Clock.DateNow.AddDays(-1 * userContext.SiteConfiguration.DaysToDisplayTargetAlertsOnPriorityPage).ToDateTimeAtStartOfDay(),
                    Clock.DateNow.AddDays(1).ToDateTimeAtStartOfDay());

                dateTimeRangeForCurrentShift = userContext.UserShift.DateTimeRangeWithoutPadding;
                AddSectionNode(PriorityPageSectionKey.TargetAlert);

                outstandingAlertsSubSectionCriteria = new TargetSectionCriteria(TargetAlertStatus.AllForPriorityDisplay.ToArray(), dateTimeRangeForOutstandingAlerts, true);
                alertsAcknowledgedOnCurrentShiftSubSectionCriteria = new TargetSectionCriteria(new[] { TargetAlertStatus.Acknowledged }, dateTimeRangeForCurrentShift, false);

                AddCriteriaBasedSubSectionNode(String.Format(StringResources.PriorityPage_TargetAlertsOutstandingAlertsSubSection, dateTimeRangeForOutstandingAlerts.LowerBound.ToShortDateString()), outstandingAlertsSubSectionCriteria);
                AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_TargetAlertsAcknowledgedForCurrentShiftSubSection, alertsAcknowledgedOnCurrentShiftSubSectionCriteria);

                remoteEventRepeater.ServerTargetAlertCreated += Repeater_Created;
                remoteEventRepeater.ServerTargetAlertUpdated += Repeater_Updated;
            }

        }

        public List<TargetAlertDTO> QueryDtos()
        {
            if (!authorizedToViewTargets)
            {
                return new List<TargetAlertDTO>();
            }

            return targetAlertService.QueryByFunctionalLocationsAndStatuses(userContext.RootFlocSet, TargetAlertStatus.AllNeedingAttention);
        }

        public void LoadDtos(List<TargetAlertDTO> dtos)
        {
            Load(dtos);
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerTargetAlertCreated -= Repeater_Created;
            remoteEventRepeater.ServerTargetAlertUpdated -= Repeater_Updated;
        }

        protected override bool IsRelevantItemFromServerEvent(TargetAlert item)
        {
            return item.Status != TargetAlertStatus.Closed && item.Status != TargetAlertStatus.Cleared;
        }

        protected override TargetAlertDTO GetDto(TargetAlert item,string ForAddUpdate)    //ayman action item reading
        {
            TargetAlertDTO dto = new TargetAlertDTO(item);
            return dto;
        }

        protected override NodeData GetNodeData(TargetAlertDTO dto)
        {
            TargetAlertNodeData nodeData = new TargetAlertNodeData(dto);
            return nodeData;
        }

        protected override void Remove(TargetAlertDTO dto)
        {
            NodeData nodeData = GetNodeData(dto);
            PriorityPageSubSectionNode subSectionNode = GetNodeContainingObjectForRemoval(dto);
            if (subSectionNode != null)
            {
                subSectionNode.Remove(nodeData);
            }
        }

        private PriorityPageSubSectionNode GetNodeContainingObjectForRemoval(TargetAlertDTO dto)
        {
            List<PriorityPageSubSectionNode> allNodes = PriorityPageSubSectionNodes;
            foreach (PriorityPageSubSectionNode node in allNodes)
            {
                PriorityPageDataNode foundNode = node.Find(dto.IdValue);
                if (foundNode != null)
                {
                    return node;
                }
            }
            return null;
        }

        private class TargetSectionCriteria : ISubSectionCriteria
        {
            private TargetAlertStatus[] ApplicableStatuses { get; set; }
            private Range<DateTime> SectionDateRange { get; set; }
            private bool IsOutstandingAlertsSection { get; set; }

            public TargetSectionCriteria(TargetAlertStatus[] applicableStatuses, Range<DateTime> sectionDateRange, bool isOutstandingAlertsSection)
            {
                ApplicableStatuses = applicableStatuses;
                SectionDateRange = sectionDateRange;
                IsOutstandingAlertsSection = isOutstandingAlertsSection;
            }

            public bool Matches(TargetAlertDTO dto)
            {
                return MatchesSectionDateRange(dto) && (MatchesAnyStatus(dto.Status));
            }

            private bool MatchesSectionDateRange(TargetAlertDTO dto)
            {
                DateTime? comparisonDateTime = IsOutstandingAlertsSection ? dto.CreatedDateTime : dto.AcknowledgedDateTime;
                return (comparisonDateTime >= SectionDateRange.LowerBound && comparisonDateTime <= SectionDateRange.UpperBound);
            }

            private bool MatchesAnyStatus(TargetAlertStatus targetStatus)
            {
                return ApplicableStatuses.Any(status => status == targetStatus);
            }
        }
    }
}
