using System.Drawing;
using Com.Suncor.Olt.Client.Localization;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class TagInfoGroupGridRender : IGridRenderer
    {
        private const string DESCRIPTION_OBJECT_NAME = "Description";
        private const string NAME_OBJECT_NAME = "Name";
        private const string UNITS_OBJECT_NAME = "Units";
        private const string ERROR_ICON_KEY = "ErrorIconKey";

        public void SetupCustomFilters(UltraGrid grid, OltUltraGridFilterUIProvider provider){}

        public void CellClicked(UltraGridCell cell) { }

        public void SetExistingColumnsInBand(UltraGridBand band)
        {
            int column = 0;
            band.HideAllColumns();
            band.Columns[ERROR_ICON_KEY].Format(string.Empty, column++);
            band.Columns[NAME_OBJECT_NAME].Format(RendererStringResources.TagName, column++);
            band.Columns[DESCRIPTION_OBJECT_NAME].Format(RendererStringResources.Description, column++);
            band.Columns[UNITS_OBJECT_NAME].Format(RendererStringResources.Units, column++);
            band.Columns[DESCRIPTION_OBJECT_NAME].PerformAutoResize();
        }

        public void SetupUnboundColumns(UltraGridBand ultraGridBand)
        {
            if (ultraGridBand.Columns.DoesNotHave(ERROR_ICON_KEY))
            {
                UltraGridColumn column = ultraGridBand.Columns.Add(ERROR_ICON_KEY, string.Empty);
                column.DataType = typeof(Image);
                column.Width = 50;
                column.CellAppearance.ImageHAlign = HAlign.Center; 
            }
        }

        public void SetDefaultSortColumns(SortedColumnsCollection sortedColumns) {}

        public void SetupRow(UltraGridRow row)
        {
            if (row.Cells.DoesHave(ERROR_ICON_KEY) && row.Cells.DoesHave("HasError"))
            {
                var isError = (bool)row.Cells["HasError"].Value;
                UltraGridCell currentCell = row.Cells[ERROR_ICON_KEY];
                WidgetAppearance app = Constants.GetPlantHistorianReadAppearance(!isError);
                currentCell.Value = app.Icon;
                currentCell.ToolTipText = app.LongText;
            }
        }

        public void BeforeFilterDropDownPopulate(object sender, BeforeRowFilterDropDownPopulateEventArgs e)
        {
            if (e.Column.Key == ERROR_ICON_KEY)
            {
                e.Handled = true;
                e.ValueList.ValueListItems.Clear();
                e.ValueList.ValueListItems.Add(InfragisticsStringResources.RowFilterDropDownAllItem, InfragisticsStringResources.RowFilterDropDownAllItem);

                e.ValueList.ValueListItems.Add(Constants.PH_TAG_READ_VALID_STATUS_APPEARANCE.Icon, Constants.PH_TAG_READ_VALID_STATUS_APPEARANCE.LongText);
                e.ValueList.ValueListItems.Add(Constants.PH_TAG_READ_INVALID_STATUS_APPEARANCE.Icon, Constants.PH_TAG_READ_INVALID_STATUS_APPEARANCE.LongText);
            }
        }

        public void BeforeRowFilterDropDown(object sender, BeforeRowFilterDropDownEventArgs beforeRowFilterDropDownEventArgs)
        {            
        }

        public void SetupBand(UltraGridBand band)
        {            
        }
    }
}