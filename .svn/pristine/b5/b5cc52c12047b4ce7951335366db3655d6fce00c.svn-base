using System;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class ActionItemReportAdapter : AbstractLocalizedReportAdapter
    {
        private readonly ActionItemDTO actionItemDto;
        private readonly string parentId;

        public ActionItemReportAdapter(string parentId, ActionItemDTO actionItemDto)
        {
            this.parentId = parentId;
            this.actionItemDto = actionItemDto;
        }

        public string ActionItemName
        {
            get { return actionItemDto.Name; }
        }

        public string ParentId
        {
            get { return parentId; }
        }

        public string Priority
        {
            get { return actionItemDto.Priority.Name; }
        }

        public string Source
        {
            get { return actionItemDto.SourceName; }
        }

        public string FunctionalLocations
        {
            get { return actionItemDto.FunctionalLocationNamesWithDescription; }
        }

        public string Category
        {
            get { return actionItemDto.CategoryName; }
        }

        public string Description
        {
            get { return actionItemDto.Description.Truncate(300, StringResources.Truncated); }
        }

        public string ResponseRequired
        {
            get
            {
                if (actionItemDto.ResponseRequired == string.Empty)
                {
                    return StringResources.No;
                }
                return actionItemDto.ResponseRequired;
            }
        }

        public string DateRange
        {
            get
            {
                return string.Format("({0} - {1})", actionItemDto.StartDateTime.ToShortDateAndTimeString(),
                    actionItemDto.EndDateTime.ToShortDateAndTimeString());
            }
        }

        public DateTime GetRawStartDateTime()
        {
            return actionItemDto.StartDateTime;
        }
    }
}