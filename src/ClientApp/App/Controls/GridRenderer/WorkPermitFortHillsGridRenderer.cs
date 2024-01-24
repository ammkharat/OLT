using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class WorkPermitFortHillsGridRenderer : AbstractPageGridRenderer
    {
        private readonly DataSourceImageColumn<WorkPermitFortHillsDTO> sourceColumn;
        private readonly PermitRequestBasedWorkPermitStatusImageColumn<WorkPermitFortHillsDTO> statusImageColumn;
        private readonly PriorityImageColumn<WorkPermitFortHillsDTO> priorityImageColumn;
        
        private const string PERMIT_NUMBER_COLUMN_KEY = "PermitNumber";
        private const string FUNCTIONAL_LOCATION_NAME_COLUMN_KEY = "FunctionalLocation";        
        private const string REQUESTED_START_DATE_COLUMN_KEY = "RequestedStartDateTime";
        private const string ISSUED_DATE_COLUMN_KEY = "StartDateTime";
        private const string DESCRIPTION_COLUMN_KEY = "Description";
        private const string OCCUPATION_COLUMN_KEY = "Occupation";
        private const string LAST_EDITOR = "LastModifiedByFullnameWithUserName";
        private const string ISSUED_BY = "IssuedByFullnameWithUserName";
        private const string WORK_ORDER_NUMBER_COLUMN_KEY = "WorkOrderNumber";
        private const string GROUP_COLUMN_KEY = "Group";
        private const string REQUESTED_BY_COLUMN_KEY = "PermitRequestCreatedByFullnameWithUserName";
        private const string COMPANY_COLUMN_KEY = "Company";
        private const string PERMIT_ACCEPTOR_COLUMN_KEY = "PermitAcceptor";
       // private const string AREA_LABEL_COLUMN_KEY = "AreaLabelName";

        public WorkPermitFortHillsGridRenderer() : base(FUNCTIONAL_LOCATION_NAME_COLUMN_KEY)
        {
            sourceColumn = new DataSourceImageColumn<WorkPermitFortHillsDTO>(new[] { DataSource.MANUAL, DataSource.PERMIT_REQUEST, DataSource.MERGE, DataSource.CLONE });
            AddImageColumn(sourceColumn);

            List<PermitRequestBasedWorkPermitStatus> applicableStatuses = new List<PermitRequestBasedWorkPermitStatus>(PermitRequestBasedWorkPermitStatus.All);
            applicableStatuses.RemoveAll(status => status == PermitRequestBasedWorkPermitStatus.OnHold || status == PermitRequestBasedWorkPermitStatus.MissingInformation);

            statusImageColumn = new PermitRequestBasedWorkPermitStatusImageColumn<WorkPermitFortHillsDTO>(applicableStatuses);
            AddImageColumn(statusImageColumn);

            priorityImageColumn = new PriorityImageColumn<WorkPermitFortHillsDTO>(new List<Priority>(WorkPermitFortHills.Priorities));
            AddImageColumn(priorityImageColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int column = 0;

            band.Columns[priorityImageColumn.ColumnKey].Format(priorityImageColumn.ColumnCaption, column++, 40);
            band.Columns[sourceColumn.ColumnKey].Format(sourceColumn.ColumnCaption, column++, 40);
            band.Columns[statusImageColumn.ColumnKey].Format(statusImageColumn.ColumnCaption, column++, 40);
            band.Columns[PERMIT_NUMBER_COLUMN_KEY].Format(RendererStringResources.PermitNumber, column++, 68);
            
            band.Columns[FUNCTIONAL_LOCATION_NAME_COLUMN_KEY].Format(RendererStringResources.Floc, column++, 120);
            
            band.Columns[REQUESTED_START_DATE_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Requested, column++, 110);
            band.Columns[ISSUED_DATE_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Issued, column++, 110);
            band.Columns[GROUP_COLUMN_KEY].Format(RendererStringResources.RequestedBy, column++, 90);
            band.Columns[OCCUPATION_COLUMN_KEY].Format(RendererStringResources.Occupation, column++, 100);
            band.Columns[DESCRIPTION_COLUMN_KEY].Format(RendererStringResources.Description, column++, 200);
            band.Columns[LAST_EDITOR].Format(RendererStringResources.LastEditor, column++, 100);
            band.Columns[ISSUED_BY].Format(RendererStringResources.IssuedBy, column++, 100);

            band.Columns[REQUESTED_BY_COLUMN_KEY].Format(RendererStringResources.RequestedByUser, column++, 127);
            band.Columns[COMPANY_COLUMN_KEY].Format(RendererStringResources.Contractor, column++, 100);
            band.Columns[PERMIT_ACCEPTOR_COLUMN_KEY].Format(RendererStringResources.PermitAcceptor, column++, 110);

            band.Columns[WORK_ORDER_NUMBER_COLUMN_KEY].Format(RendererStringResources.WONumber, column++, 90);
            //band.Columns[AREA_LABEL_COLUMN_KEY].Format(RendererStringResources.AreaLabel, column++, 100);            
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(REQUESTED_START_DATE_COLUMN_KEY, true);
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
