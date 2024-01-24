using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Reporting;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.UserPreference;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    public class DevExpressDetailedLogReportPresenter :
        AbstractQueryByDateRangeShiftRoleAndWorkAssignmentReportPresenter
            <IDateRangeShiftRoleAndWorkAssignmentReportParametersControl, DetailedLogReportDTO, RtfGenericMultiLogReport,
                GenericMultiLogReportAdapter, DetailedLogReportParameterPreference>
    {
        public DevExpressDetailedLogReportPresenter()
            : base(ClientServiceRegistry.Instance.GetService<IRoleService>(),
                ClientServiceRegistry.Instance.GetService<IWorkAssignmentService>(),
                StringResources.DetailedLogReportTitle, new RtfReportsPage())
        {
        }

        protected override PrintActions<DetailedLogReportDTO, RtfGenericMultiLogReport, GenericMultiLogReportAdapter>
            PrintActions
        {
            get { return new DevExpressDetailedLogReportPrintActions(parameters.SelectedGroupBy); }
        }

        protected override IDateRangeShiftRoleAndWorkAssignmentReportParametersControl CreateParametersControl()
        {
            return new DateRangeShiftRoleAndWorkAssignmentReportParametersControl(true);
        }

        protected override string GetDomainObjectNamePlural()
        {
            return StringResources.LogDomainObjectNamePlural;
        }

        protected override List<Role> GetValidRoles()
        {
            return roleService.QueryRolesBySite(ClientSession.GetUserContext().Site).FindAll(obj => !obj.IsReadOnlyRole);
        }

        protected override List<DetailedLogReportDTO> CreateDataSource(UserShift startUserShift,
            UserShift endUserShift,
            List<FunctionalLocation> flocList,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment)
        {
            return GetDetailedLogReportDataForEachDayInUserShiftDateRange(startUserShift, endUserShift, flocList,
                workAssignments, includeNullWorkAssignment);
        }
        /*flexi shift handover function overloaded RITM0185797*/
        protected override List<DetailedLogReportDTO> CreateDataSource(UserShift startUserShift,
            UserShift endUserShift,
            List<FunctionalLocation> flocList,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment, bool a)
        {
            return GetDetailedLogReportDataForEachDayInUserShiftDateRange(startUserShift, endUserShift, flocList,
                workAssignments, includeNullWorkAssignment);
        }

        private List<DetailedLogReportDTO> GetDetailedLogReportDataForEachDayInUserShiftDateRange(
            UserShift startUserShift,
            UserShift endUserShift,
            List<FunctionalLocation> flocList,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment)
        {
            var dtos = new List<DetailedLogReportDTO>();

            var start = startUserShift.StartDateTime;
            var end = endUserShift.EndDateTime;

            //Start Migle Story : #3999 Add new parameter to view report 
            //foreach (var day in start.EachDay(end))
            //{
            //    Date selectedDay = new Date(day);
            //    var selectedDayUserShift = CreateCorrectUserShift(startUserShift.ShiftPattern, startUserShift.StartDate);

            //    var selectedDayEndUserShift = CreateCorrectUserShift(endUserShift.ShiftPattern, endUserShift.StartDate); //Migle Story : #3999 Add new parameter to view report 

            //    //var selectedDayResults = service.GetDetailedLogReportData(
            //    //    selectedDayUserShift,
            //    //    selectedDayUserShift,
            //    //    new RootFlocSet(flocList),
            //    //    workAssignments,
            //    //    includeNullWorkAssignment);

            //    var selectedDayResults = service.GetDetailedLogReportData(
            //        selectedDayUserShift,
            //        selectedDayEndUserShift,
            //        new RootFlocSet(flocList),
            //        workAssignments,
            //        includeNullWorkAssignment);

            //    dtos.AddRange(selectedDayResults);
            //}
            var selectedDayUserShift = CreateCorrectUserShift(startUserShift.ShiftPattern, startUserShift.StartDate);

            var selectedDayEndUserShift = CreateCorrectUserShift(endUserShift.ShiftPattern, endUserShift.StartDate);

            var selectedDayResults = service.GetDetailedLogReportData(
                    selectedDayUserShift,
                    selectedDayEndUserShift,
                    new RootFlocSet(flocList),
                    workAssignments,
                    includeNullWorkAssignment);

            dtos.AddRange(selectedDayResults);

            //End Migle Story : #3999 Add new parameter to view report 

            return dtos;
        }

        protected override DetailedLogReportParameterPreference GetReportParameterPreference()
        {
            return new DetailedLogReportParameterPreference();
        }

        protected override void LoadDefaultData(
            IDateRangeShiftRoleAndWorkAssignmentReportParametersControl parameterControl)
        {
            base.LoadDefaultData(parameterControl);
            parameterControl.GroupByItems =
                new List<AssignmentSectionUnitReportGroupBy>(AssignmentSectionUnitReportGroupBy.All);
        }

        protected override void PopulateControlFromPreference(
            DetailedLogReportParameterPreference reportParameterPreference,
            IDateRangeShiftRoleAndWorkAssignmentReportParametersControl parameterControl)
        {
            base.PopulateControlFromPreference(reportParameterPreference, parameterControl);
            parameterControl.SelectedGroupBy =
                AssignmentSectionUnitReportGroupBy.GetById(reportParameterPreference.GroupById);
        }

        protected override void PopulatePreferenceFromControl(
            DetailedLogReportParameterPreference reportParameterPreference,
            IDateRangeShiftRoleAndWorkAssignmentReportParametersControl parameterControl)
        {
            base.PopulatePreferenceFromControl(reportParameterPreference, parameterControl);
            reportParameterPreference.GroupById = (int) parameterControl.SelectedGroupBy.IdValue;
        }
    }
}