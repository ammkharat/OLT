
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

// RITM-RITM0164850   Mukesh  Jan 12, 2018
namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    internal class ConfigureRoleGridRender : AbstractSimpleGridRenderer
    {
        private const string COMPANY_NAME_COLUMN_KEY = "Name";

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.HideAllColumns();
            band.Columns[COMPANY_NAME_COLUMN_KEY].Format("RoleName", 1,200);
            band.Columns["activedirectorykey"].Format("ActiveDirectorykey", 2,170);
            band.Columns["alias"].Format("Alias", 3,110);

         }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(COMPANY_NAME_COLUMN_KEY, false);
        }
    }
}
