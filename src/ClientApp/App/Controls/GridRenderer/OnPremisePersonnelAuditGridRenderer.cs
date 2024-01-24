using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class OnPremisePersonnelAuditGridRenderer : AbstractPageGridRenderer
    {
        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add("Company", false, true);
            sortedColumns.Add("Trade", false, true);
            sortedColumns.Add("PersonnelName", false, false);
            sortedColumns.Add("StartDateTime", false, false);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            columnFormatter.FormatAsString("FormId", "Form#");
            columnFormatter.FormatAsString("Company", "Company");
            columnFormatter.FormatAsString("Trade", "Trade");
            columnFormatter.FormatAsString("PersonnelName", "Personnel Name");
            columnFormatter.FormatAsDateTime("StartDateTime", "Start");
            columnFormatter.FormatAsDateTime("EndDateTime", "End");
            columnFormatter.FormatAsString("PrimaryLocation", "Primary Location");
            columnFormatter.FormatAsDecimal("ExpectedHours", "OT Hrs", 80, false);
            columnFormatter.FormatAsString("Description", "Description");
            columnFormatter.FormatAsString("WorkOrderNumber", "WO#/PO#");
            columnFormatter.FormatAsString("OvertimeFormStatus", "Status");
            columnFormatter.FormatAsString("ApprovedByFullName", "Approver Name");
        }
    }
}