using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class LogDefinitionGridRenderer : AbstractPageGridRenderer
    {
        private const string COMMENTS_COLUMN_KEY = "Comments";
        private const string LOGGED_DATETIME_COLUMN_KEY = "LogDateTime";
        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocationNames";
        private const string VISIBILITY_GROUPS_COLUMN_KEY = "VisibilityGroupNames";

        private readonly IImageGridColumn isActiveColumn;
        private readonly bool showActiveImageColumn;

        public LogDefinitionGridRenderer(bool showActiveImageColumn) : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        {
            this.showActiveImageColumn = showActiveImageColumn;

            if (showActiveImageColumn)
            {
                isActiveColumn = new IsActiveImageColumn<LogDefinitionDTO>();
                AddImageColumn(isActiveColumn);                
            }                
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int i = 0;

            if (showActiveImageColumn)
            {
                band.Columns[isActiveColumn.ColumnKey].Format(isActiveColumn.ColumnCaption, i++);
            }

            band.Columns[LOGGED_DATETIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Created, i++);
            band.Columns["ScheduleInformation"].Format(RendererStringResources.Scheduling, i++);
            band.Columns[FUNCTIONAL_LOCATION_COLUMN_KEY].Format(RendererStringResources.Floc, i++);
            band.Columns["LastModifiedFullNameWithUserName"].Format(RendererStringResources.EditedBy, i++);
            band.Columns[COMMENTS_COLUMN_KEY].Format(RendererStringResources.Comments, i++, 500);
            band.Columns[VISIBILITY_GROUPS_COLUMN_KEY].Format(RendererStringResources.VisibilityGroups, i++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(LOGGED_DATETIME_COLUMN_KEY, true);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> { COMMENTS_COLUMN_KEY };
        }

    }
}
