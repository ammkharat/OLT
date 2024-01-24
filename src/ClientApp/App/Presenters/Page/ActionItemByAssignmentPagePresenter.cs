using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class ActionItemByAssignmentPagePresenter : ActionItemPagePresenter
    {
        public ActionItemByAssignmentPagePresenter() : base(new ActionItemByAssignmentPage())
        {
        }

        protected override IList<ActionItemDTO> GetDtos(Common.Utility.Range<Date> dateRange)
        {
            return service.QueryDTOByFunctionalLocationsAndDisplayLimitsAndWorkAssignment(
                userContext.RootFlocSet, ActionItemStatus.AvailableForCurrentView, userContext.Assignment, dateRange, userContext.ReadableVisibilityGroupIds);
        }

        protected override bool ShouldBeDisplayed(ActionItem item)
        {
            return base.ShouldBeDisplayed(item) && userContext.HasSameAssignment(item.Assignment);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.ActionItemsByAssignment; }
        }
    }
}