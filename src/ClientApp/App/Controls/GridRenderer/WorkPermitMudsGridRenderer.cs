using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class WorkPermitMudsGridRenderer : AbstractPageGridRenderer
    {
        private const string PERMIT_NUMBER_COLUMN_KEY = "PermitNumber";
        private const string START_DATETIME_COLUMN_KEY = "StartDate";
        private const string FUNCTIONAL_LOCATION_HIERARCHY_COLUMN_KEY = "FunctionalLocationFullHierarchies";
        private const string DESCRIPTION_COLUMN_KEY = "Description";
        private const string TRADE_COLUMN_KEY = "Trade";
        private const string LAST_EDITED_BY_COLUMN_KEY = "LastModifiedByFullNameWithUserName";
        private const string WORK_ORDER_NUMBER_COLUMN_KEY = "WorkOrderNumber";
        private const string Interrupteurs_KEY = "InterrupteursFCO"; // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

        private readonly HasYesAnswerImageColumnForMuds hasYesAnswerImageColumn;
        
        

        private readonly IImageGridColumn sourceColumn;
        private readonly PermitRequestBasedWorkPermitStatusImageColumn<WorkPermitMudsDTO> statusImageColumn;

        public WorkPermitMudsGridRenderer()
            : base(FUNCTIONAL_LOCATION_HIERARCHY_COLUMN_KEY)
        {
            sourceColumn = new DataSourceImageColumn<WorkPermitMudsDTO>(new[] { DataSource.MANUAL, DataSource.PERMIT_REQUEST });
            AddImageColumn(sourceColumn);

            List<PermitRequestBasedWorkPermitStatus> applicableStatuses = new List<PermitRequestBasedWorkPermitStatus>
                                                                               {
                                                                                   PermitRequestBasedWorkPermitStatus.Requested,
                                                                                   PermitRequestBasedWorkPermitStatus.Pending,
                                                                                   PermitRequestBasedWorkPermitStatus.Issued,
                                                                                   PermitRequestBasedWorkPermitStatus.Complete,
                                                                                   PermitRequestBasedWorkPermitStatus.Incomplete,
                                                                                   PermitRequestBasedWorkPermitStatus.CompletionUnknown,
                                                                                   PermitRequestBasedWorkPermitStatus.NoShow,
                                                                                   PermitRequestBasedWorkPermitStatus.OnHold,
                                                                                   PermitRequestBasedWorkPermitStatus.Void,
                                                                                   PermitRequestBasedWorkPermitStatus.MissingInformation,
                                                                                   PermitRequestBasedWorkPermitStatus.NotReturned,
                                                                                   PermitRequestBasedWorkPermitStatus.Signed // Added By Vibhor : RITM0556998 - Add new status signed
                                                                               };

            statusImageColumn = new PermitRequestBasedWorkPermitStatusImageColumn<WorkPermitMudsDTO>(applicableStatuses);
            AddImageColumn(statusImageColumn);

            hasYesAnswerImageColumn = new HasYesAnswerImageColumnForMuds();
            AddImageColumn(hasYesAnswerImageColumn);

        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int position = 1;

            band.Columns[sourceColumn.ColumnKey].Format(sourceColumn.ColumnCaption, position++);

            // Status 
            band.Columns[statusImageColumn.ColumnKey].Format(statusImageColumn.ColumnCaption, position++);
            band.Columns[hasYesAnswerImageColumn.ColumnKey].Format(hasYesAnswerImageColumn.ColumnCaption, position++);

            band.Columns[PERMIT_NUMBER_COLUMN_KEY].Format(RendererStringResources.PermitNumber, position++);
            band.Columns[FUNCTIONAL_LOCATION_HIERARCHY_COLUMN_KEY].Format(RendererStringResources.Floc, position++);
            band.Columns[START_DATETIME_COLUMN_KEY].FormatAsDate(RendererStringResources.StartDate, position++);

            //Added By Vibhor - RITM0624137 - OLT : Separate the start hours than the start date in 
                                                //different columns as the same as in work request.

            band.Columns["StartTime"].FormatAsDate("Heure de début", position++, 100);

            band.Columns["RequestedByGroup"].Format(RendererStringResources.RequestedBy, position++);
            //band.Columns[TRADE_COLUMN_KEY].Format(RendererStringResources.Trade, position++);
            band.Columns[LAST_EDITED_BY_COLUMN_KEY].Format(RendererStringResources.LastEditor, position++);
            //band.Columns[WORK_ORDER_NUMBER_COLUMN_KEY].Format(RendererStringResources.WONumber, position++);
            band.Columns["FCO"].Format("# FCO", position++);  //Added By Vibhor : RITM0555766
            band.Columns[Interrupteurs_KEY].Format("Numéro FCO", position++); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            band.Columns[DESCRIPTION_COLUMN_KEY].Format(RendererStringResources.Description, position++);
            
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(START_DATETIME_COLUMN_KEY, true);
        }

        protected override List<string> ColumnKeysToRemoveFilterValuesFor()
        {
            return new List<string> { DESCRIPTION_COLUMN_KEY, PERMIT_NUMBER_COLUMN_KEY };
        }

        protected override List<string> ColumnKeysToRemoveBlanksOptionFor()
        {
            return new List<string> { PERMIT_NUMBER_COLUMN_KEY };
        }
    }
}