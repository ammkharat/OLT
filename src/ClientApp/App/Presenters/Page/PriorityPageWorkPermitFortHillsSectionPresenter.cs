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
    class PriorityPageWorkPermitFortHillsSectionPresenter : PriorityPageSectionPresenter<WorkPermitFortHillsDTO, WorkPermitFortHills>
    {
        private readonly IWorkPermitFortHillsService workPermitService;
        private readonly Range<Date> dateRange;
        private readonly bool authorizedToViewPermits;

        public PriorityPageWorkPermitFortHillsSectionPresenter(IPage invokeControl, PriorityPageTree tree, IAuthorized authorized,
                                                          UserContext userContext,
                                                          IRemoteEventRepeater remoteEventRepeater,
                                                          IWorkPermitFortHillsService workPermitService, 
                                                          PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.workPermitService = workPermitService;
            authorizedToViewPermits = authorized.ToViewWorkPermitsOnThePrioritiesPage(userContext.UserRoleElements);
            if (authorizedToViewPermits)
            {
                Date now = Clock.DateNow;
                dateRange = new Range<Date>(now, now.AddDays(1));

                AddSectionNode(PriorityPageSectionKey.WorkPermitFortHills);
                AddCriteriaBasedSubSectionNode(
                    StringResources.PriorityPage_WorkPermitsSubSection_Today,
                    new TodaySubSectionCriteria(now));
                AddCatchAllSubSectionNode(StringResources.PriorityPage_WorkPermitsSubSection_Tomorrow);

                remoteEventRepeater.ServerWorkPermitFortHillsCreated += Repeater_Created;
                remoteEventRepeater.ServerWorkPermitFortHillsUpdated += Repeater_Updated;
                remoteEventRepeater.ServerWorkPermitFortHillsRemoved += Repeater_Removed;
            }
        }

        public List<WorkPermitFortHillsDTO> QueryDtos()
        {
            if (authorizedToViewPermits)
            {
                if (userContext.HasFlocsForWorkPermits)
                {
                    return new List<WorkPermitFortHillsDTO>(workPermitService.QueryByDateRangeAndFlocs(dateRange, userContext.RootFlocSetForWorkPermits));
                }
                return new List<WorkPermitFortHillsDTO>(workPermitService.QueryByDateRangeAndFlocs(dateRange, userContext.RootFlocSet));
            }
            return new List<WorkPermitFortHillsDTO>();
        }

        public void LoadDtos(List<WorkPermitFortHillsDTO> dtos)
        {
            dtos = dtos.OrderByDescending(dto => dto.RequestedOrIssuedDateTime).ToList();

            Load(dtos);
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerWorkPermitFortHillsCreated -= Repeater_Created;
            remoteEventRepeater.ServerWorkPermitFortHillsUpdated -= Repeater_Updated;
            remoteEventRepeater.ServerWorkPermitFortHillsRemoved -= Repeater_Removed;
        }

        protected override bool IsRelevantItemFromServerEvent(WorkPermitFortHills item)
        {
            return new DateRange(dateRange).Overlaps(item.RequestedOrIssuedDateTime, item.ExpiredDateTime);
        }

        //protected override WorkPermitFortHillsDTO GetDto(WorkPermitFortHills item)
        //{
        //    return new WorkPermitFortHillsDTO(item);
        //}

        protected override WorkPermitFortHillsDTO GetDto(WorkPermitFortHills item, string ForAddUpdate)    //ayman action item reading
        {
            return new WorkPermitFortHillsDTO(item);
        }

        protected override NodeData GetNodeData(WorkPermitFortHillsDTO dto)
        {
            return new WorkPermitFortHillsNodeData(dto);
        }

        private class TodaySubSectionCriteria : ISubSectionCriteria
        {
            private readonly DateRange range;

            public TodaySubSectionCriteria(Date today)
            {
                range = new DateRange(today, today);
            }

            public bool Matches(WorkPermitFortHillsDTO dto)
            {
                return range.Overlaps(dto.RequestedOrIssuedDateTime, dto.EndDateTime);
            }
        }
    }
}
