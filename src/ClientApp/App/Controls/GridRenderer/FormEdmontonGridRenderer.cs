using System;
using System.Drawing;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class FormEdmontonGridRenderer : AbstractPageGridRenderer
    {
        private readonly Range<Date> dateRangeOfPermitRequest;
        private readonly Range<DateTime> dateTimeRangeOfWorkPermit;

        private readonly FormStatusImageColumn statusImageColumn;

        protected const string FUNCTIONAL_LOCATION_NAME_COLUMN_KEY = "FunctionalLocationNames";
        private const string TRADE_CHECKLIST_NAMES_COLUMN_KEY = "TradeChecklistNames";
        protected const string FORM_NUMBER_COLUMN_KEY = "FormNumber";
        protected const string VALID_FROM_COLUMN_KEY = "ValidFrom";
        protected const string VALID_TO_COLUMN_KEY = "ValidTo";
        protected const string CREATED_BY_COLUMN_KEY = "CreatedByFullNameWithUserName";
        protected const string REMAINING_APPROVALS_COLUMN_KEY = "RemainingApprovalsString";
        protected const string APPROVED_DATE_TIME_COLUMN_KEY = "ApprovedDateTime";
        protected const string CLOSED_DATE_TIME_COLUMN_KEY = "ClosedDateTime";
        protected const string CREATED_DATE_TIME_COLUMN_KEY = "CreatedDateTime";

        //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950321922 - 10-Oct-2018 - start
        protected const string TITLE_COLUMN_KEY = "CriticalSystemDefeated";
        //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950321922 - 10-Oct-2018 - end

        private readonly bool useValidFromWordingForDateColumns = true;
        private readonly bool _showTrades;

        public FormEdmontonGridRenderer(bool useValidFromWordingForDateColumns)
            : base(FUNCTIONAL_LOCATION_NAME_COLUMN_KEY)
        {
            statusImageColumn = new FormStatusImageColumn();
            AddImageColumn(statusImageColumn);
            this.useValidFromWordingForDateColumns = useValidFromWordingForDateColumns;
        }

        public FormEdmontonGridRenderer() : this(true)
        {
        }

        public FormEdmontonGridRenderer(Range<Date> dateRangeOfPermitRequest) : this(true)
        {
            this.dateRangeOfPermitRequest = dateRangeOfPermitRequest;
        }

        public FormEdmontonGridRenderer(Range<Date> dateRangeOfPermitRequest, bool useValidFromWordingForDateColumns,bool showTradescolumn)
            : this(useValidFromWordingForDateColumns)
        {
            this.dateRangeOfPermitRequest = dateRangeOfPermitRequest;
            _showTrades = showTradescolumn;
        }

        
        public FormEdmontonGridRenderer(Range<DateTime> dateTimeRangeOfWorkPermit) : this(true)
        {
            this.dateTimeRangeOfWorkPermit = dateTimeRangeOfWorkPermit;
        }

        public FormEdmontonGridRenderer(Range<DateTime> dateTimeRangeOfWorkPermit,
            bool useValidFromWordingForDateColumns, bool showTradesColumn) : this(useValidFromWordingForDateColumns)
        {
            this.dateTimeRangeOfWorkPermit = dateTimeRangeOfWorkPermit;
            _showTrades = showTradesColumn;
        }

        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            int column = 0;

            band.Columns[FORM_NUMBER_COLUMN_KEY].Format(RendererStringResources.FormNumber, column++);
            band.Columns[statusImageColumn.ColumnKey].Format(statusImageColumn.ColumnCaption, column++);
           
            if(_showTrades)
            {
                band.Columns[TRADE_CHECKLIST_NAMES_COLUMN_KEY].Format(RendererStringResources.Trades, column++, 180);
            }
            
            band.Columns[FUNCTIONAL_LOCATION_NAME_COLUMN_KEY].Format(RendererStringResources.Floc, column++);

            //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950321922 - 10-Oct-2018 - start
            if (this.GetType().Name == "OP14FormGridRenderer")
                band.Columns[TITLE_COLUMN_KEY].Format(RendererStringResources.CriticalSystemDefeatedTitle, column++);
            //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950321922 - 10-Oct-2018 - end

            string fromDateCaption;
            string toDateCaption;

            if (useValidFromWordingForDateColumns)
            {
                fromDateCaption = RendererStringResources.ValidFrom;
                toDateCaption = RendererStringResources.ValidTo;
            }
            else
            {
                fromDateCaption = RendererStringResources.Start;
                toDateCaption = RendererStringResources.End;
            }

            band.Columns[VALID_FROM_COLUMN_KEY].FormatAsDateTime(fromDateCaption, column++);
            band.Columns[VALID_TO_COLUMN_KEY].FormatAsDateTime(toDateCaption, column++);

            band.Columns[CREATED_BY_COLUMN_KEY].Format(RendererStringResources.CreatedBy, column++);
            band.Columns[REMAINING_APPROVALS_COLUMN_KEY].Format(RendererStringResources.RemainingApprovals, column++);
            band.Columns[CREATED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Created, column++);
            band.Columns[APPROVED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Approved, column++);
            band.Columns[CLOSED_DATE_TIME_COLUMN_KEY].FormatAsDateTime(RendererStringResources.Closed, column++);
            
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(VALID_FROM_COLUMN_KEY, true);
        }

        public override void SetupRow(UltraGridRow row)
        {
            base.SetupRow(row);

            if (dateTimeRangeOfWorkPermit != null)
            {
                IFormEdmontonDTO formEdmontonDto = row.ListObject as IFormEdmontonDTO;
                if (formEdmontonDto != null &&
                    !formEdmontonDto.IsWorkPermitDateTimesWithinFormDateTimes(dateTimeRangeOfWorkPermit))
                {
                    row.Appearance.ForeColor = Color.Red;
                }
            }
            else if (dateRangeOfPermitRequest != null)
            {
                IFormEdmontonDTO formEdmontonDto = row.ListObject as IFormEdmontonDTO;
                if (formEdmontonDto != null &&
                    !formEdmontonDto.IsPermitRequestDatesWithinFormDates(dateRangeOfPermitRequest))
                {
                    row.Appearance.ForeColor = Color.Red;
                }
            }
        }
    }
}