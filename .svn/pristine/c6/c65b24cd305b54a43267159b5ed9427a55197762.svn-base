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
    public class PriorityPageWorkPermitMudsSectionPresenter : PriorityPageSectionPresenter<WorkPermitMudsDTO, WorkPermitMuds>
    {
        private readonly IWorkPermitMudsService workPermitMudsService;
        private readonly bool authorizedToViewPermits;
        private readonly Range<Date> dateRange;

        public PriorityPageWorkPermitMudsSectionPresenter(
            IPage invokeControl, PriorityPageTree tree, IAuthorized authorized, UserContext userContext, IRemoteEventRepeater remoteEventRepeater,
            IWorkPermitMudsService workPermitMudsService, PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.workPermitMudsService = workPermitMudsService;
            authorizedToViewPermits = authorized.ToViewWorkPermitsOnThePrioritiesPage(userContext.UserRoleElements);
            if (authorizedToViewPermits)
            {
                Date now = Clock.DateNow;
                dateRange = new Range<Date>(now, now.AddDays(1));

                AddSectionNode(PriorityPageSectionKey.WorkPermitMuds);
                AddCriteriaBasedSubSectionNode(
                    StringResources.PriorityPage_WorkPermitsSubSection_Today,
                    new TodaySubSectionCriteria(now));
                AddCatchAllSubSectionNode(StringResources.PriorityPage_WorkPermitsSubSection_Tomorrow);

                remoteEventRepeater.ServerWorkPermitMudsCreated += Repeater_Created;
                remoteEventRepeater.ServerWorkPermitMudsUpdated += Repeater_Updated;
                remoteEventRepeater.ServerWorkPermitMudsRemoved += Repeater_Removed;
            }
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerWorkPermitMudsCreated -= Repeater_Created;
            remoteEventRepeater.ServerWorkPermitMudsUpdated -= Repeater_Updated;
            remoteEventRepeater.ServerWorkPermitMudsRemoved -= Repeater_Removed;            
        }

        public List<WorkPermitMudsDTO> QueryDtos()
        {
            if (authorizedToViewPermits)
            {
                return workPermitMudsService.QueryByDateRangeAndFlocs(dateRange, userContext.RootFlocSet);
            }
            return new List<WorkPermitMudsDTO>();
        }

        public void LoadDtos(List<WorkPermitMudsDTO> dtos)
        {
            dtos = dtos.OrderByDescending(dto => dto.StartDateTime).ToList();

            Load(dtos);
        }

        protected override bool IsRelevantItemFromServerEvent(WorkPermitMuds item)
        {
            return new DateRange(dateRange).Overlaps(item.StartDateTime, item.EndDateTime);
        }

        protected override WorkPermitMudsDTO GetDto(WorkPermitMuds item, string addUpdate)
        {
            return new WorkPermitMudsDTO(item); 
        }

        protected override NodeData GetNodeData(WorkPermitMudsDTO dto)
        {
            return new WorkPermitMudsNodeData(dto);
        }

        private class TodaySubSectionCriteria : ISubSectionCriteria
        {
            private readonly DateRange range;

            public TodaySubSectionCriteria(Date today)
            {
                range = new DateRange(today, today);
            }

            public bool Matches(WorkPermitMudsDTO dto)
            {
                return range.Overlaps(dto.StartDateTime, dto.EndDateTime);
            }
        }
    }




}
