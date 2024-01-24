using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class PermitRequestMontrealGridRenderer : AbstractPageGridRenderer
    {
        private const string START_DATE_COLUMN = "StartDateAsDateTime";
        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocationNamesAsString";
        private const string DESCRIPTION_COLUMN_KEY = "Description";
        private const string WORK_ORDER_NUMBER_COLUMN_KEY = "WorkOrderNumber";

        private readonly IImageGridColumn sourceColumn;
        private readonly IImageGridColumn statusColumn;

        public PermitRequestMontrealGridRenderer() : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        {
            this.sourceColumn = new DataSourceImageColumn<PermitRequestMontrealDTO>(new[] { DataSource.MANUAL, DataSource.SAP, DataSource.CLONE });
            AddImageColumn(sourceColumn);

            this.statusColumn = new PermitRequestCompletionStatusImageColumn(new[] { PermitRequestCompletionStatus.Complete, PermitRequestCompletionStatus.Incomplete });
            AddImageColumn(statusColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int column = 0;

            band.Columns[sourceColumn.ColumnKey].Format(sourceColumn.ColumnCaption, column++);
            band.Columns[statusColumn.ColumnKey].Format(statusColumn.ColumnCaption, column++);
            band.Columns[FUNCTIONAL_LOCATION_COLUMN_KEY].Format(RendererStringResources.Floc, column++, 120);
            band.Columns[START_DATE_COLUMN].FormatAsDate(RendererStringResources.Start, column++, 100);
            band.Columns["EndDateAsDateTime"].FormatAsDate(RendererStringResources.End, column++, 100);
            band.Columns["RequestedByGroup"].Format(RendererStringResources.RequestedBy, column++, 100);
            band.Columns["Trade"].Format(RendererStringResources.Trade, column++, 100);
            band.Columns[WORK_ORDER_NUMBER_COLUMN_KEY].Format(RendererStringResources.WONumber, column++, 90);
            band.Columns["OperationNumber"].Format(RendererStringResources.OperationNumber, column++, 40);
            band.Columns[DESCRIPTION_COLUMN_KEY].Format(RendererStringResources.Description, column++, 400);
            band.Columns["LastImportedDateTime"].FormatAsDateTime(RendererStringResources.LastImported, column++);
            band.Columns["LastImportedByFullnamewithUserName"].Format(RendererStringResources.LastImportedBy, column++, 100);
            band.Columns["LastSubmittedDateTime"].FormatAsDateTime(RendererStringResources.LastSubmitted, column++);
            band.Columns["LastSubmittedByFullnamewithUserName"].Format(RendererStringResources.LastSubmittedBy, column++, 100);
            band.Columns["LastModifiedDateTime"].FormatAsDateTime(RendererStringResources.LastModified, column++);
            band.Columns["LastModifiedByFullnameWithUserName"].Format(RendererStringResources.LastEditor, column++, 100);
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
