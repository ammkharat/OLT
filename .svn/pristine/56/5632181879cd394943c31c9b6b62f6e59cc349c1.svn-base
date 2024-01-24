using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class WorkPermitEdmontonTurnaroundPagePresenter : WorkPermitEdmontonPagePresenter
    {
        public WorkPermitEdmontonTurnaroundPagePresenter() : base(PageKey.WORK_PERMIT_TURNAROUND_PAGE)
        {
        }

        protected override IList<WorkPermitEdmontonDTO> GetDtos(Range<Date> dateRange)
        {
            if (userContext.HasFlocsForWorkPermits)
            {
                return workPermitEdmontonService.QueryByDateRangeAndFlocsForTurnaround(dateRange, userContext.RootFlocSetForWorkPermits);
            }
            return workPermitEdmontonService.QueryByDateRangeAndFlocsForTurnaround(dateRange, userContext.RootFlocSet);
        }

        protected override bool ShouldBeDisplayed(WorkPermitEdmonton item)
        {
            return item.Group != null && (item.Group.SAPImportPriorityList.Contains(WorkOrderPriority.P3.IdValue) || item.Group.SAPImportPriorityList.Contains(WorkOrderPriority.P4.IdValue));
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.EdmontonTurnaroundWorkPermits; }
        }        
    }
}
