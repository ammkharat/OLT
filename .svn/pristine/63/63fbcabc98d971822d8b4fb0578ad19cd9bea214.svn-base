using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class OnPremisePersonnelSupervisorGridRenderer : AbstractPageGridRenderer
    {
        private readonly CardEntryStatusImageColumn cardEntryStatusImageColumn;

        public OnPremisePersonnelSupervisorGridRenderer()
        {
            cardEntryStatusImageColumn = new CardEntryStatusImageColumn();
            AddImageColumn(cardEntryStatusImageColumn);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add("Trade", false, true);
            sortedColumns.Add("StartDateTime", false, false);
            sortedColumns.Add("PersonnelName", false, false);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            columnFormatter.FormatAsString(cardEntryStatusImageColumn.ColumnKey, cardEntryStatusImageColumn.ColumnCaption);
            columnFormatter.FormatAsString("Trade", "Trade");
            columnFormatter.FormatAsString("PersonnelName", "Personnel Name");
            columnFormatter.FormatAsString("PrimaryLocation", "Primary Location");
            columnFormatter.FormatAsString("Shifts", "Shift", 60);
            columnFormatter.FormatAsDateTime("StartDateTime", "Start");
            columnFormatter.FormatAsDateTime("EndDateTime", "End");
            columnFormatter.FormatAsString("PhoneNumber", "Phone Number");
            columnFormatter.FormatAsString("Radio", "Radio", 50);
            columnFormatter.FormatAsString("Company", "Company");
            columnFormatter.FormatAsString("Description", "Description of Work");
        }
    }
}