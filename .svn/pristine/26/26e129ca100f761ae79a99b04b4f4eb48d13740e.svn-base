using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class WorkPermitMudsMarkedTemplateGridRenderer : AbstractPageGridRenderer
    {
        private const string PERMIT_NUMBER_COLUMN_KEY = "PermitNumber";
        private const string FUNCTIONAL_LOCATION_HIERARCHY_COLUMN_KEY = "FunctionalLocationFullHierarchies";
        
        //protected readonly WorkPermitMudsTypeImageColumn typeImageColumn;
        
        

        private readonly IImageGridColumn sourceColumn;
        //private readonly PermitRequestBasedWorkPermitStatusImageColumn<WorkPermitMudsDTO> statusImageColumn;

        public WorkPermitMudsMarkedTemplateGridRenderer()
            : base(FUNCTIONAL_LOCATION_HIERARCHY_COLUMN_KEY)
        {
            

            //typeImageColumn = new WorkPermitMudsTypeImageColumn();
            //AddImageColumn(typeImageColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int position = 1;


            band.Columns["WP_Type"].Format("WorkPermit Type", position++);
            //band.Columns[FUNCTIONAL_LOCATION_HIERARCHY_COLUMN_KEY].Format(RendererStringResources.Floc, position++);
            band.Columns["Categories"].Format("Category", position++);
            band.Columns["TemplateName"].Format("Template Name", position++, 300);
            band.Columns["Global"].Format("Global Template", position++);
            band.Columns["Desc"].Format(RendererStringResources.Description, position++);
            //band.Columns[typeImageColumn.ColumnKey].Format(typeImageColumn.ColumnCaption, position++);
            
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            //sortedColumns.Add(START_DATETIME_COLUMN_KEY, true);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> { };
        }

        protected override List<string> ColumnKeysToRemoveBlanksOptionFor()
        {
            return new List<string> {  };
        }
    }
}