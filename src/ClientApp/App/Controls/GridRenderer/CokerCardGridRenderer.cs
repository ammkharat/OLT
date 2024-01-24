using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class CokerCardGridRenderer : AbstractPageGridRenderer
    {
        private const string DATE_TIME_COLUMN = "CreatedDateTime";
        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocationName";

        public CokerCardGridRenderer() : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        {
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int column = 0;
            band.Columns["Name"].FormatAsDateTime(RendererStringResources.Name, column++);
            band.Columns[FUNCTIONAL_LOCATION_COLUMN_KEY].Format(RendererStringResources.Floc, column++, 100);
            band.Columns[DATE_TIME_COLUMN].FormatAsDateTime(RendererStringResources.CreatedDateTime, column++);
            band.Columns["Shift"].Format(RendererStringResources.Shift, column++, 100);
            band.Columns["CreatedByFullnameWithUserName"].Format(RendererStringResources.CreatedBy, column++, 150);
            band.Columns["WorkAssignmentName"].Format(RendererStringResources.Assignment, column++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(DATE_TIME_COLUMN, true);
        }
    }
}