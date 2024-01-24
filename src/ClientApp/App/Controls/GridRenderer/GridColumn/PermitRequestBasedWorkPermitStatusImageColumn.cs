using System.Collections.Generic;
using Com.Suncor.Olt.Client.Localization;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class PermitRequestBasedWorkPermitStatusImageColumn<T> : StatusImageColumn<T, PermitRequestBasedWorkPermitStatus>
        where T : IHasStatus<PermitRequestBasedWorkPermitStatus>
    {
        private readonly Dictionary<string, PermitRequestBasedWorkPermitStatus> nameToEntityMap = new Dictionary<string, PermitRequestBasedWorkPermitStatus>();

        public PermitRequestBasedWorkPermitStatusImageColumn(List<IImageMapItem<PermitRequestBasedWorkPermitStatus>> imageMapItems) : base(RendererStringResources.Status, imageMapItems)
        {
            foreach (KeyValuePair<PermitRequestBasedWorkPermitStatus, IImageMapItem<PermitRequestBasedWorkPermitStatus>> pair in imageMap)
            {
                PermitRequestBasedWorkPermitStatus status = pair.Key;
                nameToEntityMap.Add(status.GetName(), status);
            }   
        }

        public PermitRequestBasedWorkPermitStatusImageColumn() : this(GetImageMapItems())
        {
        }

        public PermitRequestBasedWorkPermitStatusImageColumn(List<PermitRequestBasedWorkPermitStatus> applicableStatuses) : this(GetImageMapItems(applicableStatuses))
        {                        
        }

        public static List<IImageMapItem<PermitRequestBasedWorkPermitStatus>> GetImageMapItems()
        {
            List<IImageMapItem<PermitRequestBasedWorkPermitStatus>> items = new List<IImageMapItem<PermitRequestBasedWorkPermitStatus>>();

            items.Add(new SortableSimpleDomainObjectImageMapItem<PermitRequestBasedWorkPermitStatus>(PermitRequestBasedWorkPermitStatus.Requested, ResourceUtils.PENDING));
            items.Add(new SortableSimpleDomainObjectImageMapItem<PermitRequestBasedWorkPermitStatus>(PermitRequestBasedWorkPermitStatus.Complete, ResourceUtils.COMPLETED_PERMIT));
            //if (ClientSession.GetUserContext().IsMontrealSulphurSite) // Added By Vibhor : RITM0556998 - Put orange color status for Pending state
            //{
            //    items.Add(new SortableSimpleDomainObjectImageMapItem<PermitRequestBasedWorkPermitStatus>(PermitRequestBasedWorkPermitStatus.Pending, ResourceUtils.WAITINGFORAPPROVAL)); 
            //}
            //else
            //{
            //    items.Add(new SortableSimpleDomainObjectImageMapItem<PermitRequestBasedWorkPermitStatus>(PermitRequestBasedWorkPermitStatus.Pending, ResourceUtils.APPROVED)); 
            //}
            items.Add(new SortableSimpleDomainObjectImageMapItem<PermitRequestBasedWorkPermitStatus>(PermitRequestBasedWorkPermitStatus.Pending, ResourceUtils.APPROVED)); 
            
            items.Add(new SortableSimpleDomainObjectImageMapItem<PermitRequestBasedWorkPermitStatus>(PermitRequestBasedWorkPermitStatus.Issued, ResourceUtils.ISSUED));
            items.Add(new SortableSimpleDomainObjectImageMapItem<PermitRequestBasedWorkPermitStatus>(PermitRequestBasedWorkPermitStatus.Incomplete, ResourceUtils.NOT_COMPLETED_PERMIT));
            items.Add(new SortableSimpleDomainObjectImageMapItem<PermitRequestBasedWorkPermitStatus>(PermitRequestBasedWorkPermitStatus.Void, ResourceUtils.VOID));
            items.Add(new SortableSimpleDomainObjectImageMapItem<PermitRequestBasedWorkPermitStatus>(PermitRequestBasedWorkPermitStatus.CompletionUnknown, ResourceUtils.COMPLETION_UNKNOWN));
            items.Add(new SortableSimpleDomainObjectImageMapItem<PermitRequestBasedWorkPermitStatus>(PermitRequestBasedWorkPermitStatus.NoShow, ResourceUtils.NO_SHOW));
            items.Add(new SortableSimpleDomainObjectImageMapItem<PermitRequestBasedWorkPermitStatus>(PermitRequestBasedWorkPermitStatus.NotReturned, ResourceUtils.NOT_RETURNED));
            items.Add(new SortableSimpleDomainObjectImageMapItem<PermitRequestBasedWorkPermitStatus>(PermitRequestBasedWorkPermitStatus.Merged, ResourceUtils.MERGED));
            items.Add(new SortableSimpleDomainObjectImageMapItem<PermitRequestBasedWorkPermitStatus>(PermitRequestBasedWorkPermitStatus.OnHold, ResourceUtils.ON_HOLD));
            items.Add(new SortableSimpleDomainObjectImageMapItem<PermitRequestBasedWorkPermitStatus>(PermitRequestBasedWorkPermitStatus.MissingInformation, ResourceUtils.MISSING_INFORMATION));

            // Added By Vibhor : RITM0556998 - Add new status signed

            items.Add(new SortableSimpleDomainObjectImageMapItem<PermitRequestBasedWorkPermitStatus>(PermitRequestBasedWorkPermitStatus.Signed, ResourceUtils.LATE)); 

            return items;
        }

        private static List<IImageMapItem<PermitRequestBasedWorkPermitStatus>> GetImageMapItems(List<PermitRequestBasedWorkPermitStatus> applicableStatuses)
        {
            List<IImageMapItem<PermitRequestBasedWorkPermitStatus>> imageMapItems = GetImageMapItems();
            imageMapItems.RemoveAll(item => applicableStatuses.DoesNotContainById(item.Key));

            return imageMapItems;
        }

        public override void AddFilterItems(ValueList valueList)
        {
            ValueListItemsCollection valueListItems = valueList.ValueListItems;
            valueListItems.Clear();
            valueListItems.Add(InfragisticsStringResources.RowFilterDropDownAllItem, InfragisticsStringResources.RowFilterDropDownAllItem);

            List<PermitRequestBasedWorkPermitStatus> keys = new List<PermitRequestBasedWorkPermitStatus>(imageMap.Keys);
            keys.Sort(SortFilterValues);

            foreach (PermitRequestBasedWorkPermitStatus key in keys)
            {
                ValueListItem valueListItem = valueListItems.Add(imageMap[key].FilterItemDisplayName, imageMap[key].FilterItemDisplayName);
                valueListItem.DataValue = imageMap[key].FilterItemDisplayName;
            }
        }

        public override void AddFilterComparer(UltraGridColumn column)
        {
            column.RowFilterComparer = new ImageColumnComparer<PermitRequestBasedWorkPermitStatus>(nameToEntityMap, imageMap);
        }
    }

}