using System.Collections.Generic;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    class SAPNotificationGridRenderer : AbstractPageGridRenderer
    {
        private const string PROCESSED_COLUMN_KEY = "IsProcessedDisplay";
        private const string DESCRIPTION_COLUMN_KEY = "Description";
        private const string CREATION_DATETIME_COLUMN_KEY = "CreationDateTime";
        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocationName";

        public SAPNotificationGridRenderer() : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        {
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            band.Columns[PROCESSED_COLUMN_KEY].FormatAsDateTime("Submitted to Log", 0);
            band.Columns[CREATION_DATETIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Created, 1);
            band.Columns[FUNCTIONAL_LOCATION_COLUMN_KEY].Format(RendererStringResources.Floc, 2);
            band.Columns["NotificationNumber"].Format(RendererStringResources.Number, 3);
            band.Columns["NotificationType"].Format(RendererStringResources.Type, 4);
            band.Columns["IncidentID"].Format(RendererStringResources.IncidentId, 5);
            band.Columns[DESCRIPTION_COLUMN_KEY].Format(RendererStringResources.Description, 6);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(CREATION_DATETIME_COLUMN_KEY, true);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> { DESCRIPTION_COLUMN_KEY };
        }
    }
}
