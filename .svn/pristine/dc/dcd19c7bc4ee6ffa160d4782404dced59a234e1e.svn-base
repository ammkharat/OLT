using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Reporting;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    public class DevExpressDailyShiftLogReportPresenter : AbstractReportPagePresenter<IDailyShiftLogReportParametersControl, DailyShiftLogReportDTO, DailyShiftLogReport , DailyShiftLogReportAdapter>
    {
        private readonly ITagInfoGroupService tagInfoGroupService;
        private readonly PrintActions<DailyShiftLogReportDTO, DailyShiftLogReport , DailyShiftLogReportAdapter> printActions;

        public DevExpressDailyShiftLogReportPresenter()
            : base(StringResources.DailyShiftLogReportTitle, new RtfReportsPage())
        {
            tagInfoGroupService = ClientServiceRegistry.Instance.GetService<ITagInfoGroupService>();
            printActions = new DailyShiftLogReportPrintActions(StringResources.ReportLabel_Title_DailyShiftLog);
        }

        protected override IDailyShiftLogReportParametersControl CreateParametersControl()
        {
            return new DailyShiftLogReportParametersControl();
        }

        protected override void InitializeParameters()
        {
            parameters.AvailableShiftPatterns = GetPossibleShifts();
            parameters.AvailableTagInfoGroups = GetAvailableTagInfoGroupList();
        }

        protected override List<DailyShiftLogReportDTO> CreateDataSource()
        {
            RootFlocSet flocSet = ClientSession.GetUserContext().RootFlocSet;
            List<UserShift> userShiftList = GetUserShifts(parameters.SelectedShiftPatterns, parameters.SelectedDate);
            TagInfoGroup selectedTagInfoGroup = parameters.SelectedTagInfoGroup;

            DailyShiftLogReportDTO reportDto = service.GetDailyShiftLogReportData(flocSet, userShiftList, selectedTagInfoGroup);
            return new List<DailyShiftLogReportDTO>{reportDto};

        }

        protected override PrintActions<DailyShiftLogReportDTO, DailyShiftLogReport, DailyShiftLogReportAdapter> PrintActions
        {
            get { return printActions; }
        }

        private List<TagInfoGroup> GetAvailableTagInfoGroupList()
        {
            Site site = ClientSession.GetUserContext().Site;
            return tagInfoGroupService.QueryTagInfoGroupListBySite(site);
        }
    }
}