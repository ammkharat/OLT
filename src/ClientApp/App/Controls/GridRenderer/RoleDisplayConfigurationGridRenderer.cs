using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;
using Nullable = Infragistics.Win.UltraWinGrid.Nullable;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class RoleDisplayConfigurationGridRenderer : AbstractSimpleGridRenderer
    {
        private const string ROLE_COLUMN = "RoleName";
        private const string SECTION_NAME_COLUMN = "SectionName";
        public const string PRIMARY_PAGE_KEY_COLUMN = "PrimaryPageKey";
        public const string SECONDARY_PAGE_KEY_COLUMN = "SecondaryPageKey";

        protected override void SetUpColumns(UltraGridBand band)
        {
            int position = 0;

            band.HideAllColumns();
            band.Columns[SECTION_NAME_COLUMN].Format(RendererStringResources.Section, position++, 100);
            band.Columns[ROLE_COLUMN].Format(RendererStringResources.Role, position++, 150);
            band.Columns[PRIMARY_PAGE_KEY_COLUMN].Format(RendererStringResources.PrimaryDefaultTab, position++, 180);
            band.Columns[SECONDARY_PAGE_KEY_COLUMN].Format(RendererStringResources.SecondaryDefaultTab, position++);

            band.Columns[PRIMARY_PAGE_KEY_COLUMN].Nullable = Nullable.Nothing;
            band.Columns[PRIMARY_PAGE_KEY_COLUMN].Style = ColumnStyle.DropDownList;
            band.Columns[SECONDARY_PAGE_KEY_COLUMN].Nullable = Nullable.Nothing;
            band.Columns[SECONDARY_PAGE_KEY_COLUMN].Style = ColumnStyle.DropDownList;

            foreach (UltraGridColumn column in band.Columns)
            {
                if (column.Key == PRIMARY_PAGE_KEY_COLUMN ||
                    column.Key == SECONDARY_PAGE_KEY_COLUMN)
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
            sortedColumns.Add(SECTION_NAME_COLUMN, false);
            sortedColumns.Add(ROLE_COLUMN, false);
        }
    }
}
