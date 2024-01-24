using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Client.Localization;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class PermitRequestCompletionStatusImageColumn : StatusImageColumn<IHasStatus<PermitRequestCompletionStatus>, PermitRequestCompletionStatus>
    {
        private readonly Dictionary<string, PermitRequestCompletionStatus> nameToEntityMap = new Dictionary<string, PermitRequestCompletionStatus>();

        public PermitRequestCompletionStatusImageColumn()
            : this(new[] { PermitRequestCompletionStatus.Complete, PermitRequestCompletionStatus.Incomplete, PermitRequestCompletionStatus.ForReview, PermitRequestCompletionStatus.Expired })
        {            
        }

        public PermitRequestCompletionStatusImageColumn(PermitRequestCompletionStatus[] applicableStatuses)
            : base(RendererStringResources.Status, GetImageMapItems(applicableStatuses))
        {
            foreach (KeyValuePair<PermitRequestCompletionStatus, IImageMapItem<PermitRequestCompletionStatus>> pair in imageMap)
            {
                PermitRequestCompletionStatus status = pair.Key;
                nameToEntityMap.Add(status.GetName(), status);
            }   
        }

        private static List<IImageMapItem<PermitRequestCompletionStatus>> GetImageMapItems(PermitRequestCompletionStatus[] applicableStatuses)
        {
            List<IImageMapItem<PermitRequestCompletionStatus>> items = new List<IImageMapItem<PermitRequestCompletionStatus>>();

            foreach (PermitRequestCompletionStatus status in applicableStatuses)
            {
                items.Add(new SortableSimpleDomainObjectImageMapItem<PermitRequestCompletionStatus>(status, GetImage(status)));
            }

            return items;
        }

        private static Bitmap GetImage(PermitRequestCompletionStatus status)
        {
            if (status == PermitRequestCompletionStatus.Complete)
            {
                return ResourceUtils.APPROVED;
            }

            if (status == PermitRequestCompletionStatus.Incomplete)
            {
                return ResourceUtils.PENDING;
            }

            if (status == PermitRequestCompletionStatus.ForReview)
            {
                return ResourceUtils.FOR_REVIEW;
            }

            if (status == PermitRequestCompletionStatus.Expired)
            {
                return ResourceUtils.EXPIRED;
            }

            return null;
        }

        public override void AddFilterItems(ValueList valueList)
        {
            ValueListItemsCollection valueListItems = valueList.ValueListItems;
            valueListItems.Clear();
            valueListItems.Add(InfragisticsStringResources.RowFilterDropDownAllItem, InfragisticsStringResources.RowFilterDropDownAllItem);

            List<PermitRequestCompletionStatus> keys = new List<PermitRequestCompletionStatus>(imageMap.Keys);
            keys.Sort(SortFilterValues);

            foreach (PermitRequestCompletionStatus key in keys)
            {
                ValueListItem valueListItem = valueListItems.Add(imageMap[key].FilterItemDisplayName, imageMap[key].FilterItemDisplayName);
                valueListItem.DataValue = imageMap[key].FilterItemDisplayName;
            }
        }

        public override void AddFilterComparer(UltraGridColumn column)
        {
            column.RowFilterComparer = new ImageColumnComparer<PermitRequestCompletionStatus>(nameToEntityMap, imageMap);
        }
    }
}
