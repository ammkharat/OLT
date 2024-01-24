using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class FieldChangeGridRenderer : AbstractSimpleGridRenderer
    {
        private const string ORIGINAL_VALUE_COLUMN_KEY = "OriginalValue";
        private const string CHANGED_VALUE_COLUMN_KEY = "ChangedValue";

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.HideAllColumns();
            band.Columns["Label"].Format(RendererStringResources.FieldName, 0);
            band.Columns[ORIGINAL_VALUE_COLUMN_KEY].Format(RendererStringResources.OriginalValue, 1);
            band.Columns[ORIGINAL_VALUE_COLUMN_KEY].AllowRowFiltering = DefaultableBoolean.False;
            band.Columns[CHANGED_VALUE_COLUMN_KEY].Format(RendererStringResources.ChangedValue, 2);
            band.Columns[CHANGED_VALUE_COLUMN_KEY].AllowRowFiltering = DefaultableBoolean.False;
        }
    }
}
