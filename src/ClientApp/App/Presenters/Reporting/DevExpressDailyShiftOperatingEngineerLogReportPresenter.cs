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
    public class DevExpressDailyShiftOperatingEngineerLogReportPresenter :
        AbstractReportPagePresenter<IDailyShiftLogReportParametersControl, DailyShiftLogReportDTO, DailyShiftLogReport, DailyShiftLogReportAdapter>
    {
        private readonly ITagInfoGroupService tagInfoGroupService;
        private readonly PrintActions<DailyShiftLogReportDTO, DailyShiftLogReport, DailyShiftLogReportAdapter> printActions;

        public DevExpressDailyShiftOperatingEngineerLogReportPresenter()
            : base(ReportName, new RtfReportsPage())
        {
            tagInfoGroupService = ClientServiceRegistry.Instance.GetService<ITagInfoGroupService>();
            printActions = new DailyShiftLogReportPrintActions(StringResources.ReportLabel_Title_DailyShiftOperatingEngineerLog);
        }

        private static string ReportName
        {
            get
            {
                string displayName = ClientSession.GetUserContext().SiteConfiguration.OperatingEngineerLogDisplayName;
                return displayName.Insert(displayName.IndexOf("Log", System.StringComparison.CurrentCulture), "Shift ");
            }
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
            UserContext userContext = ClientSession.GetUserContext();
            RootFlocSet flocSet = userContext.RootFlocSet;

            List<UserShift> selectedUserShifts = GetUserShifts(parameters.SelectedShiftPatterns, parameters.SelectedDate);
            TagInfoGroup selectedTagInfoGroup = parameters.SelectedTagInfoGroup;

            DailyShiftLogReportDTO data = service.GetOperatingEngineerShiftLogReportDataForDevEx(flocSet,
                                                                                                selectedUserShifts,
                                                                                                selectedTagInfoGroup);

            return data.IsEmpty
                       ? new List<DailyShiftLogReportDTO>(0)
                       : new List<DailyShiftLogReportDTO> { data };
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