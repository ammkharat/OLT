﻿using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class WorkPermitEdmontonTemplateGridRender : AbstractPageGridRenderer
    {
        private readonly DataSourceImageColumn<WorkPermitEdmontonDTO> sourceColumn;
        private readonly PermitRequestBasedWorkPermitStatusImageColumn<WorkPermitEdmontonDTO> statusImageColumn;
        private readonly PriorityImageColumn<WorkPermitEdmontonDTO> priorityImageColumn;
        
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
        private const string AREA_LABEL_COLUMN_KEY = "AreaLabelName";

        //public WorkPermitEdmontonTemplateGridRender()
        //    : base(FUNCTIONAL_LOCATION_NAME_COLUMN_KEY)
        //{
        //    sourceColumn = new DataSourceImageColumn<WorkPermitEdmontonDTO>(new[] { DataSource.MANUAL, DataSource.PERMIT_REQUEST, DataSource.MERGE, DataSource.CLONE });
        //    AddImageColumn(sourceColumn);

        //    List<PermitRequestBasedWorkPermitStatus> applicableStatuses = new List<PermitRequestBasedWorkPermitStatus>(PermitRequestBasedWorkPermitStatus.All);
        //    applicableStatuses.RemoveAll(status => status == PermitRequestBasedWorkPermitStatus.OnHold || status == PermitRequestBasedWorkPermitStatus.MissingInformation);

        //    statusImageColumn = new PermitRequestBasedWorkPermitStatusImageColumn<WorkPermitEdmontonDTO>(applicableStatuses);
        //    AddImageColumn(statusImageColumn);

        //    priorityImageColumn = new PriorityImageColumn<WorkPermitEdmontonDTO>(new List<Priority>(WorkPermitEdmonton.Priorities));
        //    AddImageColumn(priorityImageColumn);
        //}

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int column = 0;
            band.Columns["WP_Type"].Format("WorkPermit Type", column++);
            band.Columns["Categories"].Format("Category", column++);
            band.Columns["TemplateName"].Format("Template Name", column++,300);
            //band.Columns[PERMIT_NUMBER_COLUMN_KEY].Format(RendererStringResources.PermitNumber, column++, 68);
            band.Columns["Global"].Format("Global Template", column++);
            band.Columns["Desc"].Format(RendererStringResources.Description, column++);
            
            
                        
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            //sortedColumns.Add(REQUESTED_START_DATE_COLUMN_KEY, true);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> {  };
        }

        protected override List<string> ColumnKeysToRemoveBlanksOptionFor()
        {
            return new List<string> { PERMIT_NUMBER_COLUMN_KEY };
        }
    }
}

