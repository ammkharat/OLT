﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    class WorkPermitMarkedTemplateGrid : AbstractPageGridRenderer
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

        //public WorkPermitMarkedTemplateGrid()
        //    : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        //{
        //    typeImageColumn = new WorkPermitTypeImageColumn();
        //    AddImageColumn(typeImageColumn);

        //    statusImageColumn = new WorkPermitStatusImageColumn();
        //    AddImageColumn(statusImageColumn);

        //    sourceImageColumn = new WorkPermitDataSourceImageColumn();
        //    AddImageColumn(sourceImageColumn);
        //}

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int position = 1;
            
           
            band.Columns["WP_Type"].Format("WorkPermit Type", position++);
            
            band.Columns["Categories"].Format("Category", position++);
            band.Columns["TemplateName"].Format("Template Name", position++, 300);
            band.Columns["Global"].Format("Global Template", position++);
            band.Columns["Desc"].Format(RendererStringResources.Description, position++);
            
            
            

        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
           
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> {};
        }

        protected override List<string> ColumnKeysToRemoveBlanksOptionFor()
        {
            return new List<string> {  };
        }
    }
}





