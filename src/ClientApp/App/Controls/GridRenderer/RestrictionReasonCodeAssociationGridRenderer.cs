using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class RestrictionReasonCodeAssociationGridRenderer : AbstractSimpleGridRenderer
    {
        private const string REASON_CODE_NAME_KEY = "RestrictionReasonCodeName";

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.HideAllColumns();
            band.Columns[REASON_CODE_NAME_KEY].Format(RendererStringResources.AssociatedReasonCode, 0, 200);
            band.Columns["Limit"].Format(RendererStringResources.Limit, 1, 50);    
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(REASON_CODE_NAME_KEY, false);
        }
    }
}