using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    class PermitRequestEdmontonGridRenderer : AbstractPageGridRenderer
    {
        private const string START_DATE_COLUMN = "StartDateAsDateTime";
        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocationNamesAsString";
        private const string DESCRIPTION_COLUMN_KEY = "Description";
        private const string WORK_ORDER_NUMBER_COLUMN_KEY = "WorkOrderNumber";

        public const string END_DATE_COLUMN_KEY = "EndDateAsDateTime";

        private readonly string craftOrTradeColumnHeaderText;

        private readonly IImageGridColumn sourceColumn;
        private readonly IImageGridColumn statusColumn;
        private readonly IImageGridColumn priorityColumn;

        public PermitRequestEdmontonGridRenderer()
        {
            sourceColumn = new DataSourceImageColumn<PermitRequestEdmontonDTO>(new[] { DataSource.MANUAL, DataSource.SAP, DataSource.CLONE });
            AddImageColumn(sourceColumn);

            ////commented and added by Dharmesh Start on 24-Nov-2016 for INC0029812 (#3380)
            //statusColumn = new PermitRequestCompletionStatusImageColumn();
            statusColumn = new PermitRequestCompletionStatusImageColumn(new[] { PermitRequestCompletionStatus.Complete, PermitRequestCompletionStatus.Incomplete, PermitRequestCompletionStatus.ForReview });
            ////commented and added by Dharmesh Start on 24-Nov-2016 for INC0029812 (#3380)


            AddImageColumn(statusColumn);

            priorityColumn = new PriorityImageColumn<PermitRequestEdmontonDTO>(new List<Priority>(WorkPermitEdmonton.Priorities));
            AddImageColumn(priorityColumn);

            craftOrTradeColumnHeaderText = RendererStringResources.Occupation;
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int column = 0;

            band.Columns[priorityColumn.ColumnKey].Format(priorityColumn.ColumnCaption, column++, 40);
            band.Columns[sourceColumn.ColumnKey].Format(sourceColumn.ColumnCaption, column++, 40);
            band.Columns[statusColumn.ColumnKey].Format(statusColumn.ColumnCaption, column++, 40);
            band.Columns[FUNCTIONAL_LOCATION_COLUMN_KEY].Format(RendererStringResources.Floc, column++, 120);
            band.Columns[START_DATE_COLUMN].FormatAsDateTime(RendererStringResources.Start, column++, 100);
            band.Columns[END_DATE_COLUMN_KEY].FormatAsDate(RendererStringResources.End, column++, 90);
            band.Columns["Group"].Format(RendererStringResources.RequestedBy, column++, 80);
            band.Columns["Trade"].Format(craftOrTradeColumnHeaderText, column++, 100);
            band.Columns[WORK_ORDER_NUMBER_COLUMN_KEY].Format(RendererStringResources.WONumber, column++, 90);
            band.Columns[DESCRIPTION_COLUMN_KEY].Format(RendererStringResources.Description, column++, 300);
            band.Columns["LastImportedDateTime"].FormatAsDateTime(RendererStringResources.LastImported, column++);
            band.Columns["LastSubmittedDateTime"].FormatAsDateTime(RendererStringResources.LastSubmitted, column++);
            band.Columns["LastSubmittedByFullnamewithUserName"].Format(RendererStringResources.LastSubmittedBy, column++, 100);
            band.Columns["LastModifiedDateTime"].FormatAsDateTime(RendererStringResources.LastModified, column++);
            band.Columns["LastModifiedByFullnameWithUserName"].Format(RendererStringResources.LastEditor, column++, 100);
            band.Columns["AreaLabelName"].Format(RendererStringResources.AreaLabel, column++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(START_DATE_COLUMN, true);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> { DESCRIPTION_COLUMN_KEY };
        }
    }
}