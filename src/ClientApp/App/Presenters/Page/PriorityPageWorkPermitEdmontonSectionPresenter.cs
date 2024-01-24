using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Domain.PriorityPage;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    class PriorityPageWorkPermitEdmontonSectionPresenter : PriorityPageSectionPresenter<WorkPermitEdmontonDTO, WorkPermitEdmonton>
    {
        private readonly IWorkPermitEdmontonService workPermitService;
        private readonly Range<Date> dateRange;
        private readonly bool authorizedToViewPermits;

        public PriorityPageWorkPermitEdmontonSectionPresenter(IPage invokeControl, PriorityPageTree tree, IAuthorized authorized,
                                                          UserContext userContext,
                                                          IRemoteEventRepeater remoteEventRepeater,
                                                          IWorkPermitEdmontonService workPermitService, 
                                                          PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.workPermitService = workPermitService;
            authorizedToViewPermits = authorized.ToViewWorkPermitsOnThePrioritiesPage(userContext.UserRoleElements);
            if (authorizedToViewPermits)
            {
                Date now = Clock.DateNow;
                dateRange = new Range<Date>(now, now.AddDays(1));

                AddSectionNode(PriorityPageSectionKey.WorkPermitEdmonton);
                AddCriteriaBasedSubSectionNode(
                    StringResources.PriorityPage_WorkPermitsSubSection_Today,
                    new TodaySubSectionCriteria(now));
                AddCatchAllSubSectionNode(StringResources.PriorityPage_WorkPermitsSubSection_Tomorrow);

                remoteEventRepeater.ServerWorkPermitEdmontonCreated += Repeater_Created;
                remoteEventRepeater.ServerWorkPermitEdmontonUpdated += Repeater_Updated;
                remoteEventRepeater.ServerWorkPermitEdmontonRemoved += Repeater_Removed;
            }
        }

        public List<WorkPermitEdmontonDTO> QueryDtos()
        {
            if (authorizedToViewPermits)
            {
                if (userContext.HasFlocsForWorkPermits)
                {
                    return new List<WorkPermitEdmontonDTO>(workPermitService.QueryByDateRangeAndFlocs(dateRange, userContext.RootFlocSetForWorkPermits));
                }
                return new List<WorkPermitEdmontonDTO>(workPermitService.QueryByDateRangeAndFlocs(dateRange, userContext.RootFlocSet));
            }
            return new List<WorkPermitEdmontonDTO>();
        }

        public void LoadDtos(List<WorkPermitEdmontonDTO> dtos)
        {
            dtos = dtos.OrderByDescending(dto => dto.RequestedOrIssuedDateTime).ToList();

            Load(dtos);
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerWorkPermitEdmontonCreated -= Repeater_Created;
            remoteEventRepeater.ServerWorkPermitEdmontonUpdated -= Repeater_Updated;
            remoteEventRepeater.ServerWorkPermitEdmontonRemoved -= Repeater_Removed;
        }

        protected override bool IsRelevantItemFromServerEvent(WorkPermitEdmonton item)
        {
            return new DateRange(dateRange).Overlaps(item.RequestedOrIssuedDateTime, item.ExpiredDateTime);
        }

        protected override WorkPermitEdmontonDTO GetDto(WorkPermitEdmonton item,string ForAddUpdate)    //ayman action item reading
        {
            return new WorkPermitEdmontonDTO(item);
        }

        protected override NodeData GetNodeData(WorkPermitEdmontonDTO dto)
        {
            return new WorkPermitEdmontonNodeData(dto);
        }

        private class TodaySubSectionCriteria : ISubSectionCriteria
        {
            private readonly DateRange range;

            public TodaySubSectionCriteria(Date today)
            {
                range = new DateRange(today, today);
            }

            public bool Matches(WorkPermitEdmontonDTO dto)
            {
                return range.Overlaps(dto.RequestedOrIssuedDateTime, dto.EndDateTime);
            }
        }
    }
}
