﻿using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    class PermitRequestEdmontonTemplateGridRenderer : AbstractPageGridRenderer
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

        //public PermitRequestEdmontonTemplateGridRenderer()
        //{
        //    sourceColumn = new DataSourceImageColumn<PermitRequestEdmontonDTO>(new[] { DataSource.MANUAL, DataSource.SAP, DataSource.CLONE });
        //    AddImageColumn(sourceColumn);

        //    ////commented and added by Dharmesh Start on 24-Nov-2016 for INC0029812 (#3380)
        //    //statusColumn = new PermitRequestCompletionStatusImageColumn();
        //    statusColumn = new PermitRequestCompletionStatusImageColumn(new[] { PermitRequestCompletionStatus.Complete, PermitRequestCompletionStatus.Incomplete, PermitRequestCompletionStatus.ForReview });
        //    ////commented and added by Dharmesh Start on 24-Nov-2016 for INC0029812 (#3380)


        //    AddImageColumn(statusColumn);

        //    priorityColumn = new PriorityImageColumn<PermitRequestEdmontonDTO>(new List<Priority>(WorkPermitEdmonton.Priorities));
        //    AddImageColumn(priorityColumn);

        //    craftOrTradeColumnHeaderText = RendererStringResources.Occupation;
        //}

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int column = 0;

            band.Columns["WP_Type"].Format("WorkPermit Type", column++);
            //band.Columns[FUNCTIONAL_LOCATION_COLUMN_KEY].Format(RendererStringResources.Floc, column++, 120);
            band.Columns["Categories"].Format("Category", column++);
            band.Columns["TemplateName"].Format("Template Name", column++, 300);
            band.Columns["Global"].Format("Global Template", column++);
            band.Columns["Desc"].Format(RendererStringResources.Description, column++);
            
            
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            //sortedColumns.Add(START_DATE_COLUMN, true);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> {  };
        }
    }
}