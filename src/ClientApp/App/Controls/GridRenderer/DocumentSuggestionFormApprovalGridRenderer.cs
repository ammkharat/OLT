using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class DocumentSuggestionFormApprovalGridRenderer : AbstractSimpleGridRenderer
    {
        public const string EDIT_COLUMN = "IsApproved";

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.Override.RowSelectors = DefaultableBoolean.False;
            band.ColHeaderLines = 2;

            var position = 0;

            band.Columns[EDIT_COLUMN].Format(string.Empty, position++, 40);
            band.Columns["WorkAssignmentDisplayName"].Format("Status", position++, 150);
            band.Columns["Approver"].Format("Approved By", position++, 325);
            band.Columns["ApprovalDateTime"].FormatAsDateTime("Approved Date", position++);

            foreach (var column in band.Columns)
            {
                column.CellActivation = column.Key != EDIT_COLUMN ? Activation.NoEdit : Activation.AllowEdit;
            }
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
        }
    }
}