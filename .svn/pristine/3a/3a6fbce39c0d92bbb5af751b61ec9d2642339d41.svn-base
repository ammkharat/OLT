using System;
using System.Collections.Generic;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public abstract class AbstractImageBooleanColumn<TRow> : AbstractImageGridColumn<TRow, bool, bool, string>
    {
        protected readonly Dictionary<string, bool> nameToEntityMap = new Dictionary<string, bool>(); 

        public AbstractImageBooleanColumn(
            Converter<TRow, bool> rowToCellValueConverter, 
            Converter<TRow, bool> rowToSortValueConverter, 
            Converter<TRow, string> rowToGroupByValueConverter, 
            List<IImageMapItem<bool>> imageMapItems) : base(rowToCellValueConverter, rowToSortValueConverter, rowToGroupByValueConverter, imageMapItems)
        {            
        }
        
        protected override void AddFilterItemValueInformationToList(ValueListItemsCollection valueListItems, bool key)
        {
            ValueListItem valueListItem = valueListItems.Add(imageMap[key].FilterItemDisplayName, imageMap[key].FilterItemDisplayName);
            valueListItem.DataValue = imageMap[key].FilterItemDisplayName;
        }

        public override void AddFilterComparer(UltraGridColumn column)
        {
            column.RowFilterComparer = new ImageColumnComparer<bool>(nameToEntityMap, imageMap);
        }
    }
}
