using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Reporting;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Domain.UserPreference;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    public class ShiftHandoverReportPresenter :
        AbstractQueryByDateRangeShiftRoleAndWorkAssignmentReportPresenter
            <IDateRangeShiftRoleAndWorkAssignmentReportParametersControl, ShiftHandoverQuestionnaire,
                RtfShiftHandoverQuestionnaireReport, ShiftHandoverQuestionnaireReportAdapter, ReportParameterPreference>
    {
        private readonly IActionItemDefinitionService actionItemDefinitionService;
        private readonly IActionItemService actionItemService;
        private readonly IShiftHandoverService handoverService;
        private readonly IFormEdmontonService lubesCsdService;
        private readonly IFunctionalLocationOperationalModeService operationalModeService;
        private readonly ShiftHandoverQuestionnairePrintActions printActions;
        private readonly IShiftPatternService shiftPatternService;
        private IExcursionResponseService excursionResponseService;

        public ShiftHandoverReportPresenter() : base(
            ClientServiceRegistry.Instance.GetService<IRoleService>(),
            ClientServiceRegistry.Instance.GetService<IWorkAssignmentService>(),
            StringResources.ShiftHandoverReportTitle,
            new RtfReportsPage())
        {
            handoverService = ClientServiceRegistry.Instance.GetService<IShiftHandoverService>();
            actionItemDefinitionService = ClientServiceRegistry.Instance.GetService<IActionItemDefinitionService>();
            shiftPatternService = ClientServiceRegistry.Instance.GetService<IShiftPatternService>();
            actionItemService = ClientServiceRegistry.Instance.GetService<IActionItemService>();
            operationalModeService =
                ClientServiceRegistry.Instance.GetService<IFunctionalLocationOperationalModeService>();
            lubesCsdService = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();
            excursionResponseService = ClientServiceRegistry.Instance.GetService<IExcursionResponseService>();

            printActions = new ShiftHandoverQuestionnairePrintActions(handoverService, actionItemDefinitionService,
                shiftPatternService, actionItemService, operationalModeService, lubesCsdService,excursionResponseService);
        }

        protected override
            PrintActions
                <ShiftHandoverQuestionnaire, RtfShiftHandoverQuestionnaireReport,
                    ShiftHandoverQuestionnaireReportAdapter> PrintActions
        {
            get { return printActions; }
        }

        protected override IDateRangeShiftRoleAndWorkAssignmentReportParametersControl CreateParametersControl()
        {
            return new DateRangeShiftRoleAndWorkAssignmentReportParametersControl(false);
        }

        protected override string GetDomainObjectNamePlural()
        {
            return StringResources.ShiftHandoverDomainObjectNamePlural;
        }
        
        protected override List<ShiftHandoverQuestionnaire> CreateDataSource(UserShift startUserShift,
            UserShift endUserShift,
            List<FunctionalLocation> flocList,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment)
        {
            var questionnaires = service.GetDailyShiftHandoverReportData(
                startUserShift, endUserShift, new RootFlocSet(flocList), workAssignments, includeNullWorkAssignment);

            questionnaires.Sort(ShiftHandoverQuestionnaire.CompareByShiftThenWorkAssignmentThenCreateUser);

            return questionnaires;
        }
        /* created overload added a param to this function bool showFlexibleShiftHandoverData RITM0185797*/
        protected override List<ShiftHandoverQuestionnaire> CreateDataSource(UserShift startUserShift,
            UserShift endUserShift,
            List<FunctionalLocation> flocList,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment, bool showFlexibleShiftHandoverData)
        {
            var questionnaires = service.GetDailyShiftHandoverReportData(
                startUserShift, endUserShift, new RootFlocSet(flocList), workAssignments, includeNullWorkAssignment, showFlexibleShiftHandoverData);

            questionnaires.Sort(ShiftHandoverQuestionnaire.CompareByShiftThenWorkAssignmentThenCreateUser);

            return questionnaires;
        }

        protected override ReportParameterPreference GetReportParameterPreference()
        {
            return new ReportParameterPreference();
        }

        protected override List<Role> GetValidRoles()
        {
            return roleService.QueryAllAvailableInSiteWithAnyRoleElement(
                ClientSession.GetUserContext().Site,
                new List<RoleElement>
                {
                    RoleElement.CREATE_SHIFT_HANDOVER_QUESTIONNAIRE,
                    RoleElement.EDIT_SHIFT_HANDOVER_QUESTIONNAIRE
                });
        }
    }
}