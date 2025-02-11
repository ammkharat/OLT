using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class WorkPermitGridRenderer : AbstractPageGridRenderer
    {
        private const string START_DATETIME_COLUMN_KEY = "StartDate";
        private const string START_TIME_COLUMN_KEY = "StartTime";
        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocationName";
        private const string PERMIT_NUMBER_COLUMN_KEY = "PermitNumber";
        private const string WORK_ORDER_NUMBER_COLUMN_KEY = "WorkOrderNumber";
        private const string JOB_STEPS_DESCRIPTION_COLUMN_KEY = "JobStepsDescription";
        private const string WORK_ORDER_DESCRIPTION_COLUMN_KEY = "WorkOrderDescription";

        protected readonly WorkPermitTypeImageColumn typeImageColumn;
        protected readonly WorkPermitStatusImageColumn statusImageColumn;
        protected readonly WorkPermitDataSourceImageColumn sourceImageColumn;

        public WorkPermitGridRenderer() : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        {
            typeImageColumn = new WorkPermitTypeImageColumn();
            AddImageColumn(typeImageColumn);

            statusImageColumn = new WorkPermitStatusImageColumn();
            AddImageColumn(statusImageColumn);

            sourceImageColumn = new WorkPermitDataSourceImageColumn();
            AddImageColumn(sourceImageColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int position = 1;

            band.Columns[typeImageColumn.ColumnKey].Format(typeImageColumn.ColumnCaption, position++);
            band.Columns[statusImageColumn.ColumnKey].Format(statusImageColumn.ColumnCaption, position++);
            band.Columns[sourceImageColumn.ColumnKey].Format(sourceImageColumn.ColumnCaption, position++);

            band.Columns[START_DATETIME_COLUMN_KEY].FormatAsDate(RendererStringResources.StartDate, position++, 80);

            band.Columns[START_TIME_COLUMN_KEY].FormatAsTime(RendererStringResources.StartTime, position++);
            band.Columns[FUNCTIONAL_LOCATION_COLUMN_KEY].Format(RendererStringResources.Floc, position++);
            band.Columns["CraftOrTradeName"].Format(RendererStringResources.CraftTrade, position++);
            
            band.Columns[WORK_ORDER_DESCRIPTION_COLUMN_KEY].Format(RendererStringResources.WODescription, position++);
            band.Columns[WORK_ORDER_DESCRIPTION_COLUMN_KEY].Width = 140;

            band.Columns[JOB_STEPS_DESCRIPTION_COLUMN_KEY].Format(RendererStringResources.JobSteps, position++);
            band.Columns[JOB_STEPS_DESCRIPTION_COLUMN_KEY].Width = 140;

            band.Columns[WORK_ORDER_NUMBER_COLUMN_KEY].Format(RendererStringResources.WONumber, position++);

            band.Columns["WorkAssignment"].Format(RendererStringResources.Assignment, position++);
            if (ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
            {
                band.Columns["IsConfinedSpace"].Format("Confined Space", position++);   //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
                
            }
            
            band.Columns["LastModifiedByFullNameWithUserName"].Format(RendererStringResources.LastEditor, position++);
            band.Columns["ApprovedByFullNameWithUserName"].Format(RendererStringResources.ApprovedBy, position++);

            band.Columns[PERMIT_NUMBER_COLUMN_KEY].Format(RendererStringResources.PermitNumber, position++);
            band.Columns[PERMIT_NUMBER_COLUMN_KEY].Width = 80;
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(START_DATETIME_COLUMN_KEY, true);
            sortedColumns.Add(START_TIME_COLUMN_KEY, false);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> { PERMIT_NUMBER_COLUMN_KEY, JOB_STEPS_DESCRIPTION_COLUMN_KEY, WORK_ORDER_DESCRIPTION_COLUMN_KEY };
        }

        protected override List<string> ColumnKeysToRemoveBlanksOptionFor()
        {
            return new List<string> { WORK_ORDER_DESCRIPTION_COLUMN_KEY, JOB_STEPS_DESCRIPTION_COLUMN_KEY };
        }
    }
}