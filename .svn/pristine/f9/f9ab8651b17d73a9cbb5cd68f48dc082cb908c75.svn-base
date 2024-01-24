using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class CardEntryStatusImageColumn : SortableSimpleDomainObjectImageColumn<OnPremisePersonnelSupervisorDTO, CardEntryStatus>
    {
        private const string COLUMN_KEY = "CardEntryStatusImage";
        private const int COLUMN_WIDTH = 50;

        public CardEntryStatusImageColumn() : base(obj => obj.CardEntryStatus, GetImageMapItems())
        {
            nameToEntityMap.Add(CardEntryStatus.OffSite.Name, CardEntryStatus.OffSite);
            nameToEntityMap.Add(CardEntryStatus.OnSite.Name, CardEntryStatus.OnSite);
            nameToEntityMap.Add(CardEntryStatus.UnKnown.Name, CardEntryStatus.UnKnown);
        }

        public override string ColumnKey { get { return COLUMN_KEY; } }

        public override string ColumnCaption { get { return "Card"; } }

        protected override int ColumnWidth { get { return COLUMN_WIDTH; } }

        private static List<IImageMapItem<CardEntryStatus>> GetImageMapItems()
        {
            var items = new List<IImageMapItem<CardEntryStatus>>();

            items.Add(new SortableSimpleDomainObjectImageMapItem<CardEntryStatus>(CardEntryStatus.OffSite, ResourceUtils.OFFSITE));
            items.Add(new SortableSimpleDomainObjectImageMapItem<CardEntryStatus>(CardEntryStatus.OnSite, ResourceUtils.ONSITE));
            items.Add(new SortableSimpleDomainObjectImageMapItem<CardEntryStatus>(CardEntryStatus.UnKnown, ResourceUtils.UNKNOWN));

            return items;
        }

        protected override void AddFilterItemValueInformationToList(ValueListItemsCollection valueListItems, CardEntryStatus key)
        {
            var valueListItem = valueListItems.Add(imageMap[key].FilterItemDisplayName, imageMap[key].FilterItemDisplayName);
            valueListItem.DataValue = imageMap[key].FilterItemDisplayName;
        }

        public override void AddFilterComparer(UltraGridColumn column)
        {
            column.RowFilterComparer = new ImageColumnComparer<CardEntryStatus>(nameToEntityMap, imageMap);
        }
    }
}