using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class DirectiveStatusImageColumn : AbstractImageGridColumn<DirectiveDTO, DirectiveStatus, DirectiveStatus, string>
    {
        private const string COLUMN_KEY = "StatusImage";
        private const int WIDTH = 50;

        protected readonly Dictionary<string, DirectiveStatus> nameToEntityMap = new Dictionary<string, DirectiveStatus>();

        public DirectiveStatusImageColumn()
            : base(
            GetStatus,
            GetStatus,
            obj => GetStatus(obj).Name,
            GetImageMapItems())
        {
            nameToEntityMap.Add(DirectiveStatus.Future.Name, DirectiveStatus.Future);
            nameToEntityMap.Add(DirectiveStatus.Active.Name, DirectiveStatus.Active);
            nameToEntityMap.Add(DirectiveStatus.Expired.Name, DirectiveStatus.Expired);
        }

        private static DirectiveStatus GetStatus(DirectiveDTO dto)
        {
            if (dto.IsInFuture(Clock.Now))
            {
                return DirectiveStatus.Future;
            }

            if (dto.IsExpired(Clock.Now))
            {
                return DirectiveStatus.Expired;
            }

            return DirectiveStatus.Active;
        }

        public static List<IImageMapItem<DirectiveStatus>> GetImageMapItems()
        {
            List<IImageMapItem<DirectiveStatus>> items = new List<IImageMapItem<DirectiveStatus>>();

            items.Add(new SortableSimpleDomainObjectImageMapItem<DirectiveStatus>(DirectiveStatus.Future, ResourceUtils.FUTURE_DIRECTIVE));
            items.Add(new SortableSimpleDomainObjectImageMapItem<DirectiveStatus>(DirectiveStatus.Active, ResourceUtils.ACTIVE_DIRECTIVE));
            items.Add(new SortableSimpleDomainObjectImageMapItem<DirectiveStatus>(DirectiveStatus.Expired, ResourceUtils.EXPIRED_DIRECTIVE));

            return items;
        }

        protected override void AddFilterItemValueInformationToList(ValueListItemsCollection valueListItems, DirectiveStatus key)
        {
            ValueListItem valueListItem = valueListItems.Add(imageMap[key].FilterItemDisplayName, imageMap[key].FilterItemDisplayName);
            valueListItem.DataValue = imageMap[key].FilterItemDisplayName;
        }
        
        public override void AddFilterComparer(UltraGridColumn column)
        {
            column.RowFilterComparer = new ImageColumnComparer<DirectiveStatus>(nameToEntityMap, imageMap);
        }

        public override string ColumnKey
        {
            get { return COLUMN_KEY; }
        }

        public override string ColumnCaption
        {
            get { return RendererStringResources.State; }
        }

        protected override int ColumnWidth
        {
            get { return WIDTH; }
        }
    }
}
