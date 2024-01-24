using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class WorkPermitMontrealGridRenderer : AbstractPageGridRenderer
    {
        private const string PERMIT_NUMBER_COLUMN_KEY = "PermitNumber";
        private const string START_DATETIME_COLUMN_KEY = "StartDateTime";
        private const string FUNCTIONAL_LOCATION_HIERARCHY_COLUMN_KEY = "FunctionalLocationFullHierarchies";
        private const string DESCRIPTION_COLUMN_KEY = "Description";
        private const string TRADE_COLUMN_KEY = "Trade";
        private const string LAST_EDITED_BY_COLUMN_KEY = "LastModifiedByFullNameWithUserName";
        private const string WORK_ORDER_NUMBER_COLUMN_KEY = "WorkOrderNumber";
        

        private readonly IImageGridColumn sourceColumn;
        private readonly PermitRequestBasedWorkPermitStatusImageColumn<WorkPermitMontrealDTO> statusImageColumn;

        public WorkPermitMontrealGridRenderer()
            : base(FUNCTIONAL_LOCATION_HIERARCHY_COLUMN_KEY)
        {
            sourceColumn = new DataSourceImageColumn<WorkPermitMontrealDTO>(new[] { DataSource.MANUAL, DataSource.PERMIT_REQUEST });
            AddImageColumn(sourceColumn);

            List<PermitRequestBasedWorkPermitStatus> applicableStatuses = new List<PermitRequestBasedWorkPermitStatus>
                                                                               {
                                                                                   PermitRequestBasedWorkPermitStatus.Requested,
                                                                                   PermitRequestBasedWorkPermitStatus.Pending,
                                                                                   PermitRequestBasedWorkPermitStatus.Issued,
                                                                                   PermitRequestBasedWorkPermitStatus.Complete,
                                                                                   PermitRequestBasedWorkPermitStatus.Incomplete,
                                                                                   PermitRequestBasedWorkPermitStatus.CompletionUnknown,
                                                                                   PermitRequestBasedWorkPermitStatus.NoShow,
                                                                                   PermitRequestBasedWorkPermitStatus.OnHold,
                                                                                   PermitRequestBasedWorkPermitStatus.Void,
                                                                                   PermitRequestBasedWorkPermitStatus.MissingInformation,
                                                                                   PermitRequestBasedWorkPermitStatus.NotReturned
                                                                               };

            statusImageColumn = new PermitRequestBasedWorkPermitStatusImageColumn<WorkPermitMontrealDTO>(applicableStatuses);
            AddImageColumn(statusImageColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int position = 1;

            band.Columns[sourceColumn.ColumnKey].Format(sourceColumn.ColumnCaption, position++);

            // Status 
            band.Columns[statusImageColumn.ColumnKey].Format(statusImageColumn.ColumnCaption, position++);

            band.Columns[PERMIT_NUMBER_COLUMN_KEY].Format(RendererStringResources.PermitNumber, position++);
            band.Columns[FUNCTIONAL_LOCATION_HIERARCHY_COLUMN_KEY].Format(RendererStringResources.Floc, position++);
            band.Columns[START_DATETIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.StartDate, position++);
            band.Columns["RequestedByGroup"].Format(RendererStringResources.RequestedBy, position++);
            band.Columns[TRADE_COLUMN_KEY].Format(RendererStringResources.Trade, position++);
            band.Columns[LAST_EDITED_BY_COLUMN_KEY].Format(RendererStringResources.LastEditor, position++);
            band.Columns[WORK_ORDER_NUMBER_COLUMN_KEY].Format(RendererStringResources.WONumber, position++);
            band.Columns[DESCRIPTION_COLUMN_KEY].Format(RendererStringResources.Description, position++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(START_DATETIME_COLUMN_KEY, true);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> { DESCRIPTION_COLUMN_KEY, PERMIT_NUMBER_COLUMN_KEY };
        }

        protected override List<string> ColumnKeysToRemoveBlanksOptionFor()
        {
            return new List<string> { PERMIT_NUMBER_COLUMN_KEY };
        }
    }
}