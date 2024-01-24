using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class WorkPermitLubesGridRenderer : AbstractPageGridRenderer
    {        
        private const string PERMIT_NUMBER_COLUMN_KEY = "PermitNumber";
        private const string FUNCTIONAL_LOCATION_NAME_COLUMN_KEY = "FunctionalLocation";    
        private const string START_DATE_COLUMN_KEY = "StartDateTime";
        private const string ISSUED_DATE_COLUMN_KEY = "IssuedDateTime";
        private const string OCCUPATION_COLUMN_KEY = "Trade";
        private const string REQUESTED_BY_COLUMN_KEY = "RequestedByGroup";
        private const string DESCRIPTION_COLUMN_KEY = "Description";
        private const string WORK_ORDER_NUMBER_COLUMN_KEY = "WorkOrderNumber";
        private const string LAST_EDITOR = "LastEditorFullNameWithUserName";
        private const string REQUESTED_BY_USER = "RequestedByUserFullNameWithUserName";
        private const string SUBMITTED_BY_USER = "SubmittedByUserFullNameWithUserName";
        private const string CONTRACTOR_COLUMN_KEY = "Company";
        private const string ISSUED_BY_COLUMN_KEY = "IssuedByUserFullNameWithUserName";

        private readonly DataSourceImageColumn<WorkPermitLubesDTO> sourceColumn;
        private readonly PermitRequestBasedWorkPermitStatusImageColumn<WorkPermitLubesDTO> statusImageColumn;
        private readonly IImageGridColumn followUpColumn;

        public WorkPermitLubesGridRenderer() : base(FUNCTIONAL_LOCATION_NAME_COLUMN_KEY)
        {
            sourceColumn = new DataSourceImageColumn<WorkPermitLubesDTO>(new[] { DataSource.MANUAL, DataSource.PERMIT_REQUEST, DataSource.CLONE });
            AddImageColumn(sourceColumn);

            List<PermitRequestBasedWorkPermitStatus> applicableStatuses = new List<PermitRequestBasedWorkPermitStatus>(PermitRequestBasedWorkPermitStatus.All);
            applicableStatuses.Remove(PermitRequestBasedWorkPermitStatus.Merged);
            applicableStatuses.Remove(PermitRequestBasedWorkPermitStatus.NotReturned);
            applicableStatuses.Remove(PermitRequestBasedWorkPermitStatus.MissingInformation);

            statusImageColumn = new PermitRequestBasedWorkPermitStatusImageColumn<WorkPermitLubesDTO>(applicableStatuses);
            AddImageColumn(statusImageColumn);

            followUpColumn = new FollowUpRequiredImageColumn();
            AddImageColumn(followUpColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int column = 0;
            
            band.Columns[sourceColumn.ColumnKey].Format(sourceColumn.ColumnCaption, column++, 40);
            band.Columns[statusImageColumn.ColumnKey].Format(statusImageColumn.ColumnCaption, column++, 40);
            band.Columns[followUpColumn.ColumnKey].Format(followUpColumn.ColumnCaption, column++, 40);
            band.Columns[PERMIT_NUMBER_COLUMN_KEY].Format(RendererStringResources.PermitNumber, column++, 68);
            band.Columns[FUNCTIONAL_LOCATION_NAME_COLUMN_KEY].Format(RendererStringResources.Floc, column++, 120);
            band.Columns[START_DATE_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Start, column++, 110);
            band.Columns[ISSUED_DATE_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Issued, column++, 110);
            band.Columns[OCCUPATION_COLUMN_KEY].Format(RendererStringResources.Occupation, column++, 100);
            band.Columns[REQUESTED_BY_COLUMN_KEY].Format(RendererStringResources.RequestedBy, column++, 127);
            band.Columns[DESCRIPTION_COLUMN_KEY].Format(RendererStringResources.Description, column++, 200);
            band.Columns[WORK_ORDER_NUMBER_COLUMN_KEY].Format(RendererStringResources.WONumber, column++, 90);
            band.Columns[LAST_EDITOR].Format(RendererStringResources.LastEditor, column++, 100);
            band.Columns[ISSUED_BY_COLUMN_KEY].Format(RendererStringResources.IssuedBy, column++, 100);
            band.Columns[REQUESTED_BY_USER].Format(RendererStringResources.RequestedByUser, column++, 100);
            band.Columns[SUBMITTED_BY_USER].Format(RendererStringResources.SubmittedByUser, column++, 100);
            band.Columns[CONTRACTOR_COLUMN_KEY].Format(RendererStringResources.Contractor, column++, 100);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(START_DATE_COLUMN_KEY, true);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> { DESCRIPTION_COLUMN_KEY };
        }

        protected override List<string> ColumnKeysToRemoveBlanksOptionFor()
        {
            return new List<string> { PERMIT_NUMBER_COLUMN_KEY };
        }
    }
}
