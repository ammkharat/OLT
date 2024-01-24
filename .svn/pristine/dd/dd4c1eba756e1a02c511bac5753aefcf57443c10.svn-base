using System.Collections.Generic;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public class ToeTypeImageColumn : AbstractImageGridColumn<OpmExcursionResponseDTO, ToeType, ToeType, string>
    {
        private const string COLUMN_KEY = "StatusImage";
        private const int WIDTH = 120;

        protected readonly Dictionary<string, ToeType> nameToEntityMap = new Dictionary<string, ToeType>();

        public ToeTypeImageColumn()
            : base(
                GetToeType,
                GetToeType,
                obj => GetToeType(obj).Name,
                GetImageMapItems())
        {
            nameToEntityMap.Add(ToeType.HighSl.Name, ToeType.HighSl);
            nameToEntityMap.Add(ToeType.HighSol.Name, ToeType.HighSol);
            nameToEntityMap.Add(ToeType.LowSl.Name, ToeType.LowSl);
            nameToEntityMap.Add(ToeType.LowSol.Name, ToeType.LowSol);
            nameToEntityMap.Add(ToeType.HighTarget.Name, ToeType.HighTarget);
            nameToEntityMap.Add(ToeType.LowTarget.Name, ToeType.LowTarget);
        }

        public override string ColumnKey
        {
            get { return COLUMN_KEY; }
        }

        public override string ColumnCaption
        {
            get { return "Type"; }
        }

        protected override int ColumnWidth
        {
            get { return WIDTH; }
        }

        private static ToeType GetToeType(OpmExcursionResponseDTO dto)
        {
            return dto.ToeType;
        }

        public static List<IImageMapItem<ToeType>> GetImageMapItems()
        {
            var items = new List<IImageMapItem<ToeType>>();

            items.Add(new SortableSimpleDomainObjectImageMapItem<ToeType>(ToeType.HighSl, ResourceUtils.HIGH_SL));
            items.Add(new SortableSimpleDomainObjectImageMapItem<ToeType>(ToeType.LowSl, ResourceUtils.LOW_SL));
            items.Add(new SortableSimpleDomainObjectImageMapItem<ToeType>(ToeType.HighSol,
                ResourceUtils.HIGH_SOL));
            items.Add(new SortableSimpleDomainObjectImageMapItem<ToeType>(ToeType.LowSol,
                ResourceUtils.LOW_SOL));
            items.Add(new SortableSimpleDomainObjectImageMapItem<ToeType>(ToeType.LowTarget,
                ResourceUtils.LOW_TARGET));
            items.Add(new SortableSimpleDomainObjectImageMapItem<ToeType>(ToeType.HighTarget,
                ResourceUtils.HIGH_TARGET));

            return items;
        }

        protected override void AddFilterItemValueInformationToList(ValueListItemsCollection valueListItems, ToeType key)
        {
            var valueListItem = valueListItems.Add(imageMap[key].FilterItemDisplayName,
                imageMap[key].FilterItemDisplayName);
            valueListItem.DataValue = imageMap[key].FilterItemDisplayName;
        }

        public override void AddFilterComparer(UltraGridColumn column)
        {
            column.RowFilterComparer = new ImageColumnComparer<ToeType>(nameToEntityMap, imageMap);
        }
    }
}