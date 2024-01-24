using System.Collections;
using Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class WorkPermitMudsTemplateGridRenderer : AbstractSimpleGridRenderer
    {
        private const string TYPE_FIELD = "WorkPermitType";
        private const string STATUS_FIELD = "ActiveValue";
        private const string DISPLAY_NAME_FIELD = "DisplayName";

        protected override void SetUpColumns(UltraGridBand band)
        {
            int i = 0;

            band.HideAllColumns();

            band.Columns[DISPLAY_NAME_FIELD].Format(RendererStringResources.Name, i++, 500);

            band.Columns[TYPE_FIELD].Format(RendererStringResources.Type, i++, 125);
            
            band.Columns[STATUS_FIELD].Format(RendererStringResources.Status, i++);

            band.Columns[DISPLAY_NAME_FIELD].SortComparer = new PropertyRowComparer<WorkPermitMudsTemplate, int>(template => template.TemplateNumber.Value);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(DISPLAY_NAME_FIELD, false);
        }

    }
}
