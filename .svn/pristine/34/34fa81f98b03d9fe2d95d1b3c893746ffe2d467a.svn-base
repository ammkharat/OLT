using Com.Suncor.Olt.Client.OltControls;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public interface IGridRenderer
    {
        void SetExistingColumnsInBand(UltraGridBand band);
        void SetupUnboundColumns(UltraGridBand ultraGridBand);

        /// <summary>
        /// If you need the grid to appear with column(s) sorted by default, here is your chance to
        /// set them up. This method will only be called if no sort orders have been specified so far.
        /// </summary>
        void SetDefaultSortColumns(SortedColumnsCollection sortedColumns);

        /// <summary>
        /// Populate the values for unbounded columns in this row.
        /// </summary>
        void SetupRow(UltraGridRow row);
        
        void BeforeFilterDropDownPopulate(object sender, BeforeRowFilterDropDownPopulateEventArgs e);
        void BeforeRowFilterDropDown(object sender, BeforeRowFilterDropDownEventArgs beforeRowFilterDropDownEventArgs);

        void SetupCustomFilters(UltraGrid grid, OltUltraGridFilterUIProvider provider);
        
        void CellClicked(UltraGridCell cell);
        void SetupBand(UltraGridBand band);
    }
}
