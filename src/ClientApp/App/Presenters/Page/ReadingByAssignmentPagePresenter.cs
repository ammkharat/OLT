using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class ReadingByAssignmentPagePresenter : ActionItemPagePresenter
    {
        public ReadingByAssignmentPagePresenter() : base(new ReadingByAssignmentPage())
        {
        }

        protected override IList<ActionItemDTO> GetDtos(Common.Utility.Range<Date> dateRange)
        {
           List<ActionItemDTO> result = service.QueryDTOByFunctionalLocationsAndDisplayLimitsAndWorkAssignment(
                userContext.RootFlocSet, ActionItemStatus.AvailableForCurrentView, userContext.Assignment, dateRange, userContext.ReadableVisibilityGroupIds);

            List<long> RemovalList = new List<long>();
            foreach (var dto in result)
            {
                ActionItemDefinition aidef = service.QueryActionItemDefinitionByActionItemCreatedByActionItemDefId(dto.IdValue);
                if (!aidef.Reading)
                {
                    RemovalList.Add(aidef.IdValue);
                }
            }

            foreach (long dt in RemovalList)
            {
                result.RemoveAll(ddt => ddt.Id == dt);
            }
            return result;
        }

        protected override bool ShouldBeDisplayed(ActionItem item)
        {
            return base.ShouldBeDisplayed(item) && userContext.HasSameAssignment(item.Assignment);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.ReadingsByAssignment; }
        }
    }
}