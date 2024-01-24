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
    class PriorityPageWorkPermitLubesSectionPresenter : PriorityPageSectionPresenter<WorkPermitLubesDTO, WorkPermitLubes>
    {
        private readonly IWorkPermitLubesService workPermitService;
        private readonly Range<Date> dateRange;
        private readonly bool authorizedToViewPermits;

        public PriorityPageWorkPermitLubesSectionPresenter(IPage invokeControl, PriorityPageTree tree, IAuthorized authorized,
                                                          UserContext userContext,
                                                          IRemoteEventRepeater remoteEventRepeater,
                                                          IWorkPermitLubesService workPermitService,
                                                          PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.workPermitService = workPermitService;
            authorizedToViewPermits = authorized.ToViewWorkPermitsOnThePrioritiesPage(userContext.UserRoleElements);
            if (authorizedToViewPermits)
            {
                Date now = Clock.DateNow;
                dateRange = new Range<Date>(now, now.AddDays(1));

                AddSectionNode(PriorityPageSectionKey.WorkPermitLubes);
                AddCriteriaBasedSubSectionNode(
                    StringResources.PriorityPage_WorkPermitsSubSection_Today,
                    new TodaySubSectionCriteria(now));
                AddCatchAllSubSectionNode(StringResources.PriorityPage_WorkPermitsSubSection_Tomorrow);

                remoteEventRepeater.ServerWorkPermitLubesCreated += Repeater_Created;
                remoteEventRepeater.ServerWorkPermitLubesUpdated += Repeater_Updated;
                remoteEventRepeater.ServerWorkPermitLubesRemoved += Repeater_Removed;

            }
        }

        public List<WorkPermitLubesDTO> QueryDtos()
        {
            if (authorizedToViewPermits)
            {
                return new List<WorkPermitLubesDTO>(workPermitService.QueryByDateRangeAndFlocs(dateRange, userContext.RootFlocSet));
            }
            return new List<WorkPermitLubesDTO>();
        }

        public void LoadDtos(List<WorkPermitLubesDTO> dtos)
        {
            dtos = dtos.OrderBy(dto => dto.StartOrIssuedDateTime).ToList();

            Load(dtos);
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerWorkPermitLubesCreated -= Repeater_Created;
            remoteEventRepeater.ServerWorkPermitLubesUpdated -= Repeater_Updated;
            remoteEventRepeater.ServerWorkPermitLubesRemoved -= Repeater_Removed;
        }

        protected override bool IsRelevantItemFromServerEvent(WorkPermitLubes item)
        {
            return new DateRange(dateRange).Overlaps(item.StartOrIssuedDateTime, item.ExpireDateTime);
        }

        protected override WorkPermitLubesDTO GetDto(WorkPermitLubes item,string ForAddUpdate)     //ayman action item reading
        {
            return new WorkPermitLubesDTO(item);
        }

        protected override NodeData GetNodeData(WorkPermitLubesDTO dto)
        {
            return new WorkPermitLubesNodeData(dto);
        }

        private class TodaySubSectionCriteria : ISubSectionCriteria
        {
            private readonly DateRange range;

            public TodaySubSectionCriteria(Date today)
            {
                range = new DateRange(today, today);
            }

            public bool Matches(WorkPermitLubesDTO dto)
            {
                return range.Overlaps(dto.StartOrIssuedDateTime, dto.ExpireDateTime);
            }
        }
    }
}
