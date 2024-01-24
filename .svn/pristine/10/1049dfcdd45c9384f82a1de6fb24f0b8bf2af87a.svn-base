using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class FormOilsandsTrainingGridRenderer : AbstractPageGridRenderer
    {
        private const string FUNCTIONAL_LOCATION_NAME_COLUMN_KEY = "FunctionalLocationNames";
        private const string TRAINING_DATE_COLUMN_KEY = "TrainingDateAsDateTime";                

        private readonly FormOilsandsTrainingStatusImageColumn statusImageColumn;
        private readonly FormOilsandsTrainingIrregularHoursImageColumn irregularHoursColumn;

        public FormOilsandsTrainingGridRenderer() : base(FUNCTIONAL_LOCATION_NAME_COLUMN_KEY)
        {
            statusImageColumn = new FormOilsandsTrainingStatusImageColumn();
            AddImageColumn(statusImageColumn);

            irregularHoursColumn = new FormOilsandsTrainingIrregularHoursImageColumn();
            AddImageColumn(irregularHoursColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int column = 0;

            band.Columns["FormNumber"].Format(RendererStringResources.FormNumber, column++);            
            band.Columns[statusImageColumn.ColumnKey].Format(statusImageColumn.ColumnCaption, column++);
            band.Columns[irregularHoursColumn.ColumnKey].Format(irregularHoursColumn.ColumnCaption, column++);
            band.Columns[FUNCTIONAL_LOCATION_NAME_COLUMN_KEY].Format(RendererStringResources.Floc, column++, 200);
            band.Columns["CreatedByFullNameWithUserName"].Format(RendererStringResources.CreatedBy, column++);
            band.Columns[TRAINING_DATE_COLUMN_KEY].FormatAsDate(RendererStringResources.TrainingDate, column++);
            band.Columns["ShiftName"].Format(RendererStringResources.Shift, column++, 80);    
            band.Columns["TotalHours"].FormatAsDecimal(RendererStringResources.TotalHours, column++, 80, true);
            band.Columns["Assignment"].Format(RendererStringResources.Assignment, column++);
            band.Columns["CreatedDateTime"].FormatAsDateTime(RendererStringResources.Created, column++);
            band.Columns["ApprovedDateTime"].FormatAsDateTime(RendererStringResources.Approved, column++);
            band.Columns["LastModifiedDateTime"].FormatAsDateTime(RendererStringResources.LastModified, column++);
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(TRAINING_DATE_COLUMN_KEY, true);
        }
    }
}
