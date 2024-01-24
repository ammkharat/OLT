using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Reporting;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    public class DevExpressDailyShiftTargetAlertGapReasonReportPresenter :
        AbstractReportPagePresenter<IDailyShiftTargetAlertGapReasonReportParametersControl, ShiftGapReasonReportDTO, DailyShiftTargetAlertGapReasonReport, DailyShiftTargetAlertGapReasonReportAdapter>
    {
        public DevExpressDailyShiftTargetAlertGapReasonReportPresenter() : base(StringResources.ShiftGapReasonReportTitle, new RtfReportsPage())
        {
        }

        protected override IDailyShiftTargetAlertGapReasonReportParametersControl CreateParametersControl()
        {
            return new DailyShiftTargetAlertGapReasonReportParametersControl();
        }

        protected override void InitializeParameters()
        {
            parameters.AvailableShiftPatterns = GetPossibleShifts();
        }

        protected override List<ShiftGapReasonReportDTO> CreateDataSource()
        {
            List<ShiftGapReasonReportDTO> data
                    = service.GetShiftGapReasonReportData(parameters.SelectedShiftPatterns, 
                                                          ClientSession.GetUserContext().RootFlocSet,
                                                          parameters.SelectedStartDate,
                                                          parameters.SelectedEndDate);
            return data;
        }

        protected override PrintActions<ShiftGapReasonReportDTO, DailyShiftTargetAlertGapReasonReport, DailyShiftTargetAlertGapReasonReportAdapter> PrintActions
        {
            get { return new DailyShiftTargetAlertGapReasonReportPrintActions(); }
        }
    }
}