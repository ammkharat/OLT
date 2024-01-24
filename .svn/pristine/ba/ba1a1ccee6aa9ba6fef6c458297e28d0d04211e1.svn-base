using System.Collections.Generic;
using Com.Suncor.Olt.Client.Localization;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Extension;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public abstract class BaseGridRenderer : IGridRenderer
    {
        public abstract void SetupCustomFilters(UltraGrid grid, OltUltraGridFilterUIProvider provider);
        public abstract void SetupUnboundColumns(UltraGridBand ultraGridBand);
        public abstract void SetDefaultSortColumns(SortedColumnsCollection sortedColumns);
        public abstract void SetupRow(UltraGridRow row);
        protected abstract void LoadDefaultColumnLayout(UltraGridBand band);
        
        protected ColumnFormatter columnFormatter;

        public virtual void CellClicked(UltraGridCell cell) { }

        public void SetExistingColumnsInBand(UltraGridBand band)
        {
            band.HideAllColumns();
            columnFormatter = new ColumnFormatter(band);
            LoadDefaultColumnLayout(band);
            SetupBand(band);
        }

        public virtual void SetupBand(UltraGridBand band)
        {
        }

        protected virtual List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string>();
        }

        protected virtual List<string>  ColumnKeysToRemoveBlanksOptionFor()
        {
            return new List<string>();
        }

        public virtual void BeforeFilterDropDownPopulate(object sender, BeforeRowFilterDropDownPopulateEventArgs e)
        {
            if (ColumnKeysToRemoveFilterValuesFor().Contains(e.Column.Key))
            {
                // prevent Infragistics from populating the dropdown with values (except'the 'all' and 'blanks' options)
                e.Handled = true;
            }
        }

        public virtual void BeforeRowFilterDropDown(object sender, BeforeRowFilterDropDownEventArgs e)
        {
            if (ColumnKeysToRemoveBlanksOptionFor().Contains(e.Column.Key))
            {
                ValueListItem blanksValueListItem =
                    e.ValueList.ValueListItems.Find((ValueListItem valueListItem) => valueListItem.DisplayText.Equals(InfragisticsStringResources.RowFilterDropDownBlanksItem));
                e.ValueList.ValueListItems.Remove(blanksValueListItem);
            }
        }
    }
}