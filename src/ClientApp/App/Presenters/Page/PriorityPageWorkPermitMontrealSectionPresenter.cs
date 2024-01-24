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
    public class PriorityPageWorkPermitMontrealSectionPresenter : PriorityPageSectionPresenter<WorkPermitMontrealDTO, WorkPermitMontreal>
    {
        private readonly IWorkPermitMontrealService workPermitMontrealService;
        private readonly bool authorizedToViewPermits;
        private readonly Range<Date> dateRange;

        public PriorityPageWorkPermitMontrealSectionPresenter(
            IPage invokeControl, PriorityPageTree tree, IAuthorized authorized, UserContext userContext, IRemoteEventRepeater remoteEventRepeater,
            IWorkPermitMontrealService workPermitMontrealService, PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.workPermitMontrealService = workPermitMontrealService;
            authorizedToViewPermits = authorized.ToViewWorkPermitsOnThePrioritiesPage(userContext.UserRoleElements);
            if (authorizedToViewPermits)
            {
                Date now = Clock.DateNow;
                dateRange = new Range<Date>(now, now.AddDays(1));

                AddSectionNode(PriorityPageSectionKey.WorkPermitMontreal);
                AddCriteriaBasedSubSectionNode(
                    StringResources.PriorityPage_WorkPermitsSubSection_Today,
                    new TodaySubSectionCriteria(now));
                AddCatchAllSubSectionNode(StringResources.PriorityPage_WorkPermitsSubSection_Tomorrow);

                remoteEventRepeater.ServerWorkPermitMontrealCreated += Repeater_Created;
                remoteEventRepeater.ServerWorkPermitMontrealUpdated += Repeater_Updated;
                remoteEventRepeater.ServerWorkPermitMontrealRemoved += Repeater_Removed;
            }
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerWorkPermitMontrealCreated -= Repeater_Created;
            remoteEventRepeater.ServerWorkPermitMontrealUpdated -= Repeater_Updated;
            remoteEventRepeater.ServerWorkPermitMontrealRemoved -= Repeater_Removed;            
        }

        public List<WorkPermitMontrealDTO> QueryDtos()
        {
            if (authorizedToViewPermits)
            {
                return workPermitMontrealService.QueryByDateRangeAndFlocs(dateRange, userContext.RootFlocSet);
            }
            return new List<WorkPermitMontrealDTO>();
        }

        public void LoadDtos(List<WorkPermitMontrealDTO> dtos)
        {
            dtos = dtos.OrderByDescending(dto => dto.StartDateTime).ToList();

            Load(dtos);
        }

        protected override bool IsRelevantItemFromServerEvent(WorkPermitMontreal item)
        {
            return new DateRange(dateRange).Overlaps(item.StartDateTime, item.EndDateTime);
        }

        protected override WorkPermitMontrealDTO GetDto(WorkPermitMontreal item,string ForAddUpdate)    //ayman action item reading
        {
            return new WorkPermitMontrealDTO(item); 
        }

        protected override NodeData GetNodeData(WorkPermitMontrealDTO dto)
        {
            return new WorkPermitMontrealNodeData(dto);
        }

        private class TodaySubSectionCriteria : ISubSectionCriteria
        {
            private readonly DateRange range;

            public TodaySubSectionCriteria(Date today)
            {
                range = new DateRange(today, today);
            }

            public bool Matches(WorkPermitMontrealDTO dto)
            {
                return range.Overlaps(dto.StartDateTime, dto.EndDateTime);
            }
        }
    }




}
