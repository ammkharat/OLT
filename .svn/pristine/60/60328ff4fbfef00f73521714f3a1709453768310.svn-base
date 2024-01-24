using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class LabAlertDefinitionGridRenderer : AbstractPageGridRenderer
    {
        private const string NAME_COLUMN_KEY = "Name";
        private const string FUNCTIONAL_LOCATION_COLUMN_KEY = "FunctionalLocationName";

        private readonly IImageGridColumn statusColumn;
        private readonly IImageGridColumn isActiveColumn;

        public LabAlertDefinitionGridRenderer() : base(FUNCTIONAL_LOCATION_COLUMN_KEY)
        {
            statusColumn = new LabAlertDefinitionStatusImageColumn();
            AddImageColumn(statusColumn);

            isActiveColumn = new IsActiveImageColumn<LabAlertDefinitionDTO>();
            AddImageColumn(isActiveColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int column = 0;

            band.Columns[statusColumn.ColumnKey].Format(statusColumn.ColumnCaption, column++);
            band.Columns[isActiveColumn.ColumnKey].Format(isActiveColumn.ColumnCaption, column++);

            band.Columns[FUNCTIONAL_LOCATION_COLUMN_KEY].Format(RendererStringResources.Floc, column++);
            band.Columns[NAME_COLUMN_KEY].Format(RendererStringResources.Name, column++);
            band.Columns["TagName"].Format(RendererStringResources.Tag, column++);
            band.Columns["Description"].Format(RendererStringResources.Description, column++, 145);
            band.Columns["LastModifiedFullNameWithUserName"].Format(RendererStringResources.EditedBy, column++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(NAME_COLUMN_KEY, false);
        }
    }
}
