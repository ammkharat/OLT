using Com.Suncor.Olt.Client.OltControls;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public abstract class AbstractSimpleGridRenderer : IGridRenderer
    {
        public void SetExistingColumnsInBand(UltraGridBand band)
        {
            band.HideAllColumns();
            SetUpColumns(band);
        }

        protected abstract void SetUpColumns(UltraGridBand band);

        public virtual void SetupUnboundColumns(UltraGridBand ultraGridBand)
        {            
        }

        public virtual void CellClicked(UltraGridCell cell) { }

        public virtual void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {           
        }

        public virtual void SetupRow(UltraGridRow row)
        {            
        }

        public virtual void BeforeFilterDropDownPopulate(object sender, BeforeRowFilterDropDownPopulateEventArgs e)
        {            
        }

        public void BeforeRowFilterDropDown(object sender, BeforeRowFilterDropDownEventArgs beforeRowFilterDropDownEventArgs)
        {            
        }

        public virtual void SetupCustomFilters(UltraGrid grid, OltUltraGridFilterUIProvider provider)
        {
        }

        public void SetupBand(UltraGridBand band)
        {            
        }
    }
}
