using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Reporting; 
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    public class DevExpressDailyShiftTargetAlertReportPresenter :
        AbstractReportPagePresenter<IDailyShiftTargetAlertReportParametersControl, TargetAlertReportDetailDTO, DailyShiftTargetAlertReport, DailyShiftTargetAlertReportAdapter>
    {
        public DevExpressDailyShiftTargetAlertReportPresenter()
            : base(StringResources.DailyShiftAlertReportTitle, new RtfReportsPage())
        {
        }

        protected override IDailyShiftTargetAlertReportParametersControl CreateParametersControl()
        {
            return new DailyShiftTargetAlertReportParametersControl();
        }

        protected override void InitializeParameters()
        {
            parameters.AvailableShiftPatterns = GetPossibleShifts();
        }

        protected override List<TargetAlertReportDetailDTO> CreateDataSource()
        {
            RootFlocSet flocSet = ClientSession.GetUserContext().RootFlocSet;
            List<UserShift> userShiftList = GetUserShifts(parameters.SelectedShiftPatterns, parameters.SelectedDate);

            List<TargetAlertReportDetailDTO> dtoList = service.GetDailyShiftAlertReportData(flocSet, userShiftList);
            return dtoList;
        }

        protected override PrintActions<TargetAlertReportDetailDTO, DailyShiftTargetAlertReport, DailyShiftTargetAlertReportAdapter> PrintActions
        {
            get { return new DailyShiftTargetAlertReportPrintActions(); }
        }
    }
}