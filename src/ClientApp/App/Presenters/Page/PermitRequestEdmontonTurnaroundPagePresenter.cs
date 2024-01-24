using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PermitRequestEdmontonTurnaroundPagePresenter : PermitRequestEdmontonPagePresenter
    {
        public PermitRequestEdmontonTurnaroundPagePresenter() : base(PageKey.PERMIT_REQUEST_TURNAROUND_PAGE)
        {
        }

        protected override IList<PermitRequestEdmontonDTO> GetDtos(Range<Date> dateRange)
        {
            DateRange queryDateRange = new DateRange(dateRange);

            if (userContext.HasFlocsForWorkPermits)
            {
                return permitRequestEdmontonService.QueryByDateRangeAndFlocsForTurnaround(userContext.RootFlocSetForWorkPermits, queryDateRange);
            }
            else
            {
                return permitRequestEdmontonService.QueryByDateRangeAndFlocsForTurnaround(userContext.RootFlocSet, queryDateRange);
            }
        }

        protected override bool ShouldBeDisplayed(PermitRequestEdmonton item)
        {
            return item.Group != null && (item.Group.SAPImportPriorityList.Contains(WorkOrderPriority.P3.IdValue) || item.Group.SAPImportPriorityList.Contains(WorkOrderPriority.P4.IdValue));
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.EdmontonTurnaroundPermitRequests; }
        }
    }
}
