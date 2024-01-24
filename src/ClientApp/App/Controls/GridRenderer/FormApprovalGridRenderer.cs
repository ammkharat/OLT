using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class FormApprovalGridRenderer : AbstractSimpleGridRenderer
    {
        public const string EDIT_COLUMN = "IsApproved";

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            band.ColHeaderLines = 2;

            int position = 0;

            band.Columns[EDIT_COLUMN].Format(RendererStringResources.Add, position++, 40);
            band.Columns["Approver"].Format(RendererStringResources.Approver, position++, 230);
            band.Columns["ApprovedByUserName"].Format(RendererStringResources.Name, position++, 230);
            band.Columns["ApprovalDateTime"].FormatAsDateTime(RendererStringResources.DateApproved, position++);

            foreach (UltraGridColumn column in band.Columns)
            {
                column.CellActivation = column.Key != EDIT_COLUMN ? Activation.NoEdit : Activation.AllowEdit;
            }
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
        }
    }
}
