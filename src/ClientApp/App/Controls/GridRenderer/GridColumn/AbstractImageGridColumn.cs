using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities;
using Com.Suncor.Olt.Client.Localization;
using Com.Suncor.Olt.Client.Resources;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn
{
    public abstract class AbstractImageGridColumn<TRow, TCell, TSort, TGroupBy> : IImageGridColumn
        where TCell : IComparable
        where TSort : IComparable
        where TGroupBy : IComparable
    {
        private readonly Converter<TRow, TCell> rowToCellValueConverter;
        private readonly Converter<TRow, TSort> rowToSortValueConverter;
        private readonly Converter<TRow, TGroupBy> rowToGroupByValueConverter;
        protected readonly Dictionary<TCell, IImageMapItem<TCell>> imageMap = new Dictionary<TCell, IImageMapItem<TCell>>();

        protected AbstractImageGridColumn(
            Converter<TRow, TCell> rowToCellValueConverter,
            Converter<TRow, TSort> rowToSortValueConverter,
            Converter<TRow, TGroupBy> rowToGroupByValueConverter,
            List<IImageMapItem<TCell>> imageMapItems)
        {
            this.rowToCellValueConverter = rowToCellValueConverter;
            this.rowToSortValueConverter = rowToSortValueConverter;
            this.rowToGroupByValueConverter = rowToGroupByValueConverter;

            foreach (IImageMapItem<TCell> item in imageMapItems)
            {
                if (!imageMap.ContainsKey(item.Key))
                {
                    imageMap.Add(item.Key, item);
                }
            }
        }

        public abstract string ColumnKey { get; }
        public abstract string ColumnCaption { get; }
        protected abstract int ColumnWidth { get; }

        public IComparer SortComparer
        {
            get { return new PropertyRowComparer<TRow, TSort>(rowToSortValueConverter); }
        }

        public IGroupByEvaluator GroupByEvaluator
        {
            get { return new GroupByEvaluator<TRow, TSort, TGroupBy>(rowToSortValueConverter, rowToGroupByValueConverter); }
        }

        public void AddToBand(UltraGridBand band)
        {
            UltraGridColumn column = band.Columns.Add(ColumnKey, ColumnCaption);
            column.DataType = typeof(Image);
            column.Width = ColumnWidth;
            column.CentreImageColumn();            
        }
        
        public void SetCellValue(UltraGridRow row)
        {
            TRow rowObject = ((TRow)row.ListObject);
            TCell cellValue = rowToCellValueConverter(rowObject);

            UltraGridCell currentCell = row.Cells[ColumnKey];
            if (!imageMap.ContainsKey(cellValue))
            {
                currentCell.Value = ResourceUtils.BLANK;                
            }
            else
            {
                currentCell.Value = imageMap[cellValue].Image;
                currentCell.ToolTipText = GetToolTipText(rowObject);
            }
        }

        protected virtual string GetToolTipText(TRow rowObject)
        {
            TCell cellValue = rowToCellValueConverter(rowObject);
            return imageMap[cellValue].ToolTip;
        }

        public virtual void AddFilterItems(ValueList valueList)
        {
            ValueListItemsCollection valueListItems = valueList.ValueListItems;
            valueListItems.Clear();
            valueListItems.Add(InfragisticsStringResources.RowFilterDropDownAllItem, InfragisticsStringResources.RowFilterDropDownAllItem);

            List<TCell> keys = new List<TCell>(imageMap.Keys);
            keys.Sort(SortFilterValues);
            foreach (TCell key in keys)
            {
                AddFilterItemValueInformationToList(valueListItems, key); 
            }
        }

        protected virtual void AddFilterItemValueInformationToList(ValueListItemsCollection valueListItems, TCell key)
        {
            valueListItems.Add(imageMap[key].Image, imageMap[key].FilterItemDisplayName);
        }

        public virtual void AddFilterComparer(UltraGridColumn column)
        {
            
        }

        protected virtual int SortFilterValues(TCell x, TCell y)
        {
            if (typeof(TCell).IsValueType)
            {
                return x.CompareTo(y);
            }
            else if (x == null && y == null)
            {
                return 0;
            }
            else if (x == null)
            {
                return -1;
            }
            else if (y == null)
            {
                return 1;
            }
            else
            {
                return x.CompareTo(y);
            }
        }
    }
}
