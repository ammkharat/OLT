using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class SummaryLogGridRenderer : AbstractPageGridRenderer
    {
        private const string LOGGED_DATE_COLUMN_KEY = "LogDateTime";
        private const string SHIFT_COLUMN_KEY = "Shift";
        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocations";
        private const string COMMENTS_COLUMN_KEY = "PlainTextComments";
        private const string VISIBILITY_GROUPS_COLUMN_KEY = "VisibilityGroupNames";

        private readonly IImageGridColumn threadColumn;
        private readonly IImageGridColumn sourceColumn;
        private readonly IImageGridColumn followUpColumn;

        public SummaryLogGridRenderer() : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        {
            threadColumn = new ThreadImageColumn<SummaryLogDTO>();
            AddImageColumn(threadColumn);

            sourceColumn = new DataSourceImageColumn<SummaryLogDTO>(new[] { DataSource.MANUAL, DataSource.HANDOVER });
            AddImageColumn(sourceColumn);

            followUpColumn = new FollowUpImageColumn<SummaryLogDTO>();
            AddImageColumn(followUpColumn);
        }

        protected override void SetupCustomSortComparers(UltraGridBand band)
        {
            band.Columns[SHIFT_COLUMN_KEY].SortComparer = new DoublePropertyRowComparer<SummaryLogDTO, Date, string>(
                dto => dto.CreatedShiftStartDate, 
                dto => dto.CreatedShiftName);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int position = 0;

            band.Columns[threadColumn.ColumnKey].Format(threadColumn.ColumnCaption, position++);
            band.Columns[sourceColumn.ColumnKey].Format(sourceColumn.ColumnCaption, position++);

            band.Columns[LOGGED_DATE_COLUMN_KEY].FormatAsDateTime(RendererStringResources.LogDate, position++);
            band.Columns[SHIFT_COLUMN_KEY].Format(RendererStringResources.Shift, position++, 150);
            band.Columns[FUNCTIONAL_LOCATION_COLUMN_KEY].Format(RendererStringResources.Floc, position++, 150);

            band.Columns[followUpColumn.ColumnKey].Format(followUpColumn.ColumnCaption, position++);

            if (ClientSession.GetUserContext().SiteConfiguration.UseCreatedByColumnForLogs)
            {
                band.Columns["CreatedByFullnameWithUserName"].Format(RendererStringResources.CreatedBy, position++);
            }
            else
            {
                band.Columns["LastModifiedFullNameWithUserName"].Format(RendererStringResources.EditedBy, position++);    
            }
            

            band.Columns["WorkAssignmentName"].Format(RendererStringResources.Assignment, position++);
            band.Columns[COMMENTS_COLUMN_KEY].Format(RendererStringResources.Comments, position++, 500);

            band.Columns[VISIBILITY_GROUPS_COLUMN_KEY].Format(RendererStringResources.VisibilityGroups, position++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(LOGGED_DATE_COLUMN_KEY, true);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> { COMMENTS_COLUMN_KEY };
        }

    }
}
