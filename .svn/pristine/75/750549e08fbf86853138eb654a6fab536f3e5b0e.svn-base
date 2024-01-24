using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public abstract class SortableSimpleDomainObjectImageColumn<TRow, TCell> : AbstractImageGridColumn<TRow, TCell, TCell, string> where TCell : SortableSimpleDomainObject
    {
        protected readonly Dictionary<string, TCell> nameToEntityMap = new Dictionary<string, TCell>(); 

        protected SortableSimpleDomainObjectImageColumn(Converter<TRow, TCell> rowToCellValueConverter, List<IImageMapItem<TCell>> imageMapItems) 
            : base(
                rowToCellValueConverter,
                rowToCellValueConverter,
                obj => rowToCellValueConverter(obj).Name,
                imageMapItems)
        {
        }

        public override void AddFilterComparer(UltraGridColumn column)
        {
            column.RowFilterComparer = new ImageColumnComparer<TCell>(nameToEntityMap, imageMap);
        }

        protected override void AddFilterItemValueInformationToList(ValueListItemsCollection valueListItems, TCell key)
        {
            ValueListItem valueListItem = valueListItems.Add(imageMap[key].FilterItemDisplayName, imageMap[key].FilterItemDisplayName);
            valueListItem.DataValue = imageMap[key].FilterItemDisplayName;
        }
    }
}
