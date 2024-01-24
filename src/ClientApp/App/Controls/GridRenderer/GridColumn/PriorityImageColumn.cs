using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class PriorityImageColumn<TRow> : SortableSimpleDomainObjectImageColumn<TRow, Priority> 
        where TRow : IHasPriority
    {
        private const string COLUMN_KEY = "PriorityImage";
        private const int WIDTH = 50;
        
        public PriorityImageColumn(List<Priority> applicablePriorities) : base(obj => obj.Priority, GetImageMapItems(applicablePriorities))
        {
            foreach (KeyValuePair<Priority, IImageMapItem<Priority>> pair in imageMap)
            {
                Priority priority = pair.Key;
                nameToEntityMap.Add(priority.GetName(), priority);
            }   
        }

        public static List<IImageMapItem<Priority>> GetImageMapItems(List<Priority> applicablePriorities)
        {
            List<IImageMapItem<Priority>> items = new List<IImageMapItem<Priority>>();

            items.Add(new SortableSimpleDomainObjectImageMapItem<Priority>(Priority.High, ResourceUtils.HIGH_PRIORITY));
            items.Add(new SortableSimpleDomainObjectImageMapItem<Priority>(Priority.Elevated, ResourceUtils.ELEVATED_PRIORITY));
            items.Add(new SortableSimpleDomainObjectImageMapItem<Priority>(Priority.Normal, ResourceUtils.NORMAL_PRIORITY));
            items.Add(new SortableSimpleDomainObjectImageMapItem<Priority>(Priority.CriticalPath, ResourceUtils.HIGH_PRIORITY));

            items.RemoveAll(item => applicablePriorities.DoesNotContainById(item.Key));

            return items;
        }

        public override string ColumnKey
        {
            get { return COLUMN_KEY; }
        }

        public override string ColumnCaption
        {
            get { return RendererStringResources.Priority; }
        }

        protected override int ColumnWidth
        {
            get { return WIDTH; }
        }        
    }
}
