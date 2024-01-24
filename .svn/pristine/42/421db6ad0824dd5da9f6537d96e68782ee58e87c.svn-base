using System;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class FormEdmontonGN75BGridRenderer : AbstractPageGridRenderer
    {
        private readonly FormStatusImageColumn statusImageColumn;
        private readonly ITimerManager timerManager;                      //ayman Sarnia eip DMND0008992
        private const string FUNCTIONAL_LOCATION_NAME_COLUMN_KEY = "FunctionalLocation";
        private const string LOCATION_COLUMN_KEY = "Location";
        private const string EQUIPMENT_TYPE_COLUMN_KEY = "EquipmentType";
        private const string FORM_NUMBER_COLUMN_KEY = "FormNumber";
        private const string CREATED_BY_COLUMN_KEY = "CreatedByFullNameWithUserName";
        private const string CLOSED_DATE_TIME_COLUMN_KEy = "ClosedDateTime";
        private const string CREATED_DATE_TIME_COLUMN_KEY = "CreatedDateTime";
        private const string LAST_MODIFIED_COLUMN_KEY = "LastModifiedDateTime";
        private const string LAST_MODIFIED_BY_COLUMN_KEY = "LastModifiedByFullName";

        public FormEdmontonGN75BGridRenderer()
            : base(FUNCTIONAL_LOCATION_NAME_COLUMN_KEY)
        {
            statusImageColumn = new FormStatusImageColumn();
            AddImageColumn(statusImageColumn);
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            if (ClientSession.GetUserContext().IsSarniaSite)            //ayman Sarnia eip DMND0008992
            {
                columnFormatter.FormatAsString(FORM_NUMBER_COLUMN_KEY, "Issue");
                columnFormatter.FormatAsString(statusImageColumn.ColumnKey, statusImageColumn.ColumnCaption);
                columnFormatter.FormatAsString(FUNCTIONAL_LOCATION_NAME_COLUMN_KEY, RendererStringResources.Floc);
                columnFormatter.FormatAsString(LOCATION_COLUMN_KEY, "Work Scope");
                columnFormatter.FormatAsString(EQUIPMENT_TYPE_COLUMN_KEY, RendererStringResources.EquipmentType);
                columnFormatter.FormatAsString(CREATED_BY_COLUMN_KEY, RendererStringResources.CreatedBy);
                columnFormatter.FormatAsDateTime(CREATED_DATE_TIME_COLUMN_KEY, RendererStringResources.Created);
                columnFormatter.FormatAsDateTime(LAST_MODIFIED_BY_COLUMN_KEY, RendererStringResources.LastEditor);
                columnFormatter.FormatAsDateTime(LAST_MODIFIED_COLUMN_KEY, RendererStringResources.LastModified);
                columnFormatter.FormatAsDateTime(CLOSED_DATE_TIME_COLUMN_KEy, RendererStringResources.Closed);
            }
            else
            {
                columnFormatter.FormatAsString(FORM_NUMBER_COLUMN_KEY, RendererStringResources.FormNumber);
                columnFormatter.FormatAsString(statusImageColumn.ColumnKey, statusImageColumn.ColumnCaption);
                columnFormatter.FormatAsString(FUNCTIONAL_LOCATION_NAME_COLUMN_KEY, RendererStringResources.Floc);
                columnFormatter.FormatAsString(LOCATION_COLUMN_KEY, RendererStringResources.Location);
                columnFormatter.FormatAsString(EQUIPMENT_TYPE_COLUMN_KEY, RendererStringResources.EquipmentType);
                columnFormatter.FormatAsString(CREATED_BY_COLUMN_KEY, RendererStringResources.CreatedBy);
                columnFormatter.FormatAsDateTime(CREATED_DATE_TIME_COLUMN_KEY, RendererStringResources.Created);
                columnFormatter.FormatAsDateTime(LAST_MODIFIED_BY_COLUMN_KEY, RendererStringResources.LastEditor);
                columnFormatter.FormatAsDateTime(LAST_MODIFIED_COLUMN_KEY, RendererStringResources.LastModified);
                columnFormatter.FormatAsDateTime(CLOSED_DATE_TIME_COLUMN_KEy, RendererStringResources.Closed);
            }
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(FORM_NUMBER_COLUMN_KEY, true);
        }

        //private void SetupTimerForCallback(FormEdmontonGN75BDTO eipissuedto, TimeSpan differenceInTime, UltraGridRow row)
        //{
        //    try
        //    {
        //        timerManager.RegisterTimer(eipissuedto, differenceInTime, RenderItemFromBackgroundThread, row);
        //    }
        //    catch (TimerDueTimeNegativeException e)
        //    {
        //        logger.Error("Encountered negative timer due time for action item:<" + eipissuedto.Id + ">", e);
        //    }
        //}
    }
}