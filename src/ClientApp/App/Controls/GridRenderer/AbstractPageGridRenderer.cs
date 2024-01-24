using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities;
using Com.Suncor.Olt.Client.OltControls;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public abstract class AbstractPageGridRenderer : BaseGridRenderer
    {
        private readonly List<IImageGridColumn> imageColumns = new List<IImageGridColumn>();
        private readonly string functionalLocationColumnKey;

        protected AbstractPageGridRenderer() : this(null)
        {            
        }

        protected AbstractPageGridRenderer(string functionalLocationColumnKey)
        {
            this.functionalLocationColumnKey = functionalLocationColumnKey;            
        }

        protected void AddImageColumn(IImageGridColumn column)
        {
            imageColumns.Add(column);
        }

        FunctionalLocationFilterTool filterTool = null;
        StringFilterMenuCustomization stringFilterMenuCustomization = null;

        public override void SetupCustomFilters(UltraGrid grid, OltUltraGridFilterUIProvider provider)
        {
            if (stringFilterMenuCustomization == null)
            {
                stringFilterMenuCustomization = new StringFilterMenuCustomization(grid, provider);  // must be run first; otherwise it will strip menu items added by the FunctionalLocationFilterTool
            }
            
            if (functionalLocationColumnKey != null && filterTool == null)
            {
                filterTool = new FunctionalLocationFilterTool(functionalLocationColumnKey);
                filterTool.SetUp(grid, provider);
            }           
        }
        
        public override void SetupBand(UltraGridBand band)
        {
            SetupCustomSortComparers(band);
            SetupSortAndGroupByForImageGridColumns(band);
        }

        protected virtual void SetupCustomSortComparers(UltraGridBand band)
        {
        }

        private void SetupSortAndGroupByForImageGridColumns(UltraGridBand band)
        {
            foreach (IImageGridColumn column in imageColumns)
            {
                band.Columns[column.ColumnKey].SortComparer = column.SortComparer;
                band.Columns[column.ColumnKey].GroupByEvaluator = column.GroupByEvaluator;                
            }
        }

        public override void SetupUnboundColumns(UltraGridBand band)
        {
            foreach (IImageGridColumn column in imageColumns)
            {
                if (band.Columns.DoesNotHave(column.ColumnKey))
                {
                    column.AddToBand(band);
                }

                column.AddFilterComparer(band.Columns[column.ColumnKey]);
            }
        }

        public override void SetupRow(UltraGridRow row)
        {
            foreach (IImageGridColumn column in imageColumns)
            {
                if (row.Cells.DoesHave(column.ColumnKey))
                {
                    column.SetCellValue(row);
                }
            }
        }

        public override void BeforeFilterDropDownPopulate(object sender, BeforeRowFilterDropDownPopulateEventArgs e)
        {
            foreach (IImageGridColumn column in imageColumns)
            {
                if (e.Column.Key == column.ColumnKey)
                {
                    e.Handled = true;
                    column.AddFilterItems(e.ValueList);
                }
            }

            base.BeforeFilterDropDownPopulate(sender, e);
        }

        /// <summary>
        /// Instead of showing (Blank) in the column filter, change it to some custom text.
        /// </summary>
        /// <param name="columnKey">Column to change the blank filter on</param>
        /// <param name="e">Event args for column being filtered</param>
        /// <param name="blankCellFilterValue">New value to replace "(Blank)"</param>
        protected void CustomizeTextOfBlankFilter(string columnKey, BeforeRowFilterDropDownEventArgs e, string blankCellFilterValue)
        {
            if (string.Equals(columnKey, e.Column.Key, StringComparison.Ordinal))
            {
                Infragistics.Shared.ResourceCustomizer resCustomizer =
                    Infragistics.Win.UltraWinGrid.Resources.Customizer;
                string blanksDataValue = resCustomizer.GetCustomizedString("RowFilterDropDownBlanksItem");
                ValueListItem findByDataValue = e.ValueList.FindByDataValue(blanksDataValue);
                for (int i = e.ValueList.ValueListItems.Count - 1; i >= 0; i--)
                {
                    if (string.Equals(e.ValueList.ValueListItems[i].DisplayText, findByDataValue.DisplayText, StringComparison.CurrentCulture))
                    {
                        e.ValueList.ValueListItems.Remove(i);
                        FilterCondition filterCondition1 = new FilterCondition(FilterComparisionOperator.Equals, FilterCondition.BlankCellValue);
                        e.ValueList.ValueListItems.Insert(i, filterCondition1, blankCellFilterValue);
                    }
                }
            }

        }

    }
}