using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class DeviationAlertResponseReasonCodeAssignmentGridRenderer : AbstractSimpleGridRenderer
    {
        private const string REASON_CODE_NAME_COLUMN_KEY = "ReasonCodeName";

        protected override void SetUpColumns(UltraGridBand band)
        {
            int column = 0;
            
            band.HideAllColumns();
            band.Columns[REASON_CODE_NAME_COLUMN_KEY].Format(RendererStringResources.AssociatedReasonCode, column++, 160); 
            band.Columns["PlantState"].Format(RendererStringResources.PlantState, column++, 125); 
            band.Columns["ReasonCodeFunctionalLocationName"].Format(RendererStringResources.AssociatedReasonCodeFloc, column++, 290);
            band.Columns["Comments"].Format(RendererStringResources.Comments, column++, 160); 
            band.Columns["AssignedAmount"].Format(RendererStringResources.AssignedAmount, column, 125); 
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(REASON_CODE_NAME_COLUMN_KEY, false);
        }
    }
}