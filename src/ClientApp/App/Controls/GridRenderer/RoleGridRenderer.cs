
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class RoleGridRenderer : AbstractSimpleGridRenderer
    {
        private const string ROLE_COLUMN = "Name";
        private const string WARN_COLUMN = "WarnIfWorkAssignmentNotSelected";

        protected override void SetUpColumns(UltraGridBand band)
        {
            int position = 0;

            band.HideAllColumns();
            band.Columns[ROLE_COLUMN].Format(RendererStringResources.Role, position++, 250);
            band.Columns[WARN_COLUMN].Format(RendererStringResources.WarnIfWorkAssignmentIsNotSelectedDuringLogIn, position++);

            foreach (UltraGridColumn column in band.Columns)
            {
                if (column.Key == WARN_COLUMN)
                {
                    column.CellActivation = Activation.AllowEdit;
                }
                else
                {
                    column.CellActivation = Activation.NoEdit;
                }
            }
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(ROLE_COLUMN, false);
        }
    }
}
