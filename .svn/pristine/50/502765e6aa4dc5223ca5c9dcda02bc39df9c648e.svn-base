using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class PermitAssessmentGridRenderer : FormEdmontonGridRenderer
    {

        private readonly EdmontonOvertimeFormStatusImageColumn statusImageColumn;
        private const string PERMIT_TYPE_COLUMN_KEY = "WorkPermitType";
        private readonly PermitAssessmentYesAnswerImageColumn hasYesAnswerImageColumn;
        private const string PERMIT_NUMBER_COLUMN_KEY = "PermitNumber";
        private const string TOTAL_SCORE_COLUMN_KEY = "TotalScore";
        private const string JOB_DESCRIPTION_COLUMN_KEY = "JobDescription";
        private const string LAST_MODIFIED_DATE_TIME_COLUMN_KEY = "LastModified";
        private const string LAST_MODIFIED_BY_COLUMN_KEY = "LastModifiedBy";
        private const string OVERALL_FEEDBACK_COLUMN_KEY = "OverallFeedback";

        public PermitAssessmentGridRenderer()
        {
            statusImageColumn = new EdmontonOvertimeFormStatusImageColumn();
            AddImageColumn(statusImageColumn);
        }


        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            var column = 0;
            band.Columns[FORM_NUMBER_COLUMN_KEY].Format(RendererStringResources.FormNumber, column++);
            band.Columns[statusImageColumn.ColumnKey].Format(statusImageColumn.ColumnCaption, column++);
            band.Columns[FUNCTIONAL_LOCATION_NAME_COLUMN_KEY].Format(RendererStringResources.Floc, column++);
            band.Columns[PERMIT_TYPE_COLUMN_KEY].Format(RendererStringResources.PermitType, column++);
            band.Columns[PERMIT_NUMBER_COLUMN_KEY].Format(RendererStringResources.PermitNumber, column++);
            band.Columns[VALID_FROM_COLUMN_KEY].FormatAsDateTime("Started", column++);
            band.Columns[VALID_TO_COLUMN_KEY].FormatAsDateTime("Expired", column++);
            band.Columns[TOTAL_SCORE_COLUMN_KEY].Format("Total Score %", column++);
            band.Columns["IsIlpRecommended"].Format("ILP Recommended", column++);
            band.Columns[JOB_DESCRIPTION_COLUMN_KEY].Format(RendererStringResources.JobDescription, column++);
            band.Columns[CREATED_BY_COLUMN_KEY].FormatAsDateTime(RendererStringResources.CreatedBy, column++);
            band.Columns[CREATED_DATE_TIME_COLUMN_KEY].FormatAsDateTime("Created", column++);
            band.Columns[LAST_MODIFIED_BY_COLUMN_KEY].Format("Last Editor", column++);
            band.Columns[LAST_MODIFIED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.LastModified, column++);
            band.Columns[OVERALL_FEEDBACK_COLUMN_KEY].Format(RendererStringResources.OverallFeedback, column++);
        }
    }
}