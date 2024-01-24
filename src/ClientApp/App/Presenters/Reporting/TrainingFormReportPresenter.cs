using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Reporting;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    public class TrainingFormReportPresenter : AbstractReportPagePresenter<ITrainingFormReportParametersControl, FormOilsandsTraining, FormOilsandsTrainingReport, FormOilsandsTrainingReportAdapter>
    {
        readonly FormOilsandsTrainingPrintActions printActions;
        private readonly IFormOilsandsService formService;
        private readonly IWorkAssignmentService workAssignmentService;
        private readonly IRoleService roleService;
        private readonly IUserService userService;

        public TrainingFormReportPresenter() : base(StringResources.TrainingFormReportTitle, new RtfReportsPage(), false)
        {
            workAssignmentService = ClientServiceRegistry.Instance.GetService<IWorkAssignmentService>();
            roleService = ClientServiceRegistry.Instance.GetService<IRoleService>();
            userService = ClientServiceRegistry.Instance.GetService<IUserService>();
            formService = ClientServiceRegistry.Instance.GetService<IFormOilsandsService>();

            printActions = new FormOilsandsTrainingPrintActions();
        }

        protected override ITrainingFormReportParametersControl CreateParametersControl()
        {
            return new TrainingFormReportParametersControl();
        }

        protected override void InitializeParameters()
        {
            parameters.SetAvailableWorkAssignments(GetWorkAssignments());
            parameters.SetAvailableUsers(GetUsers());
        }

        protected override List<FormOilsandsTraining> CreateDataSource()
        {
            Date fromDate = parameters.StartDate;
            Date toDate = parameters.EndDate;
            List<UserDTO> users = parameters.SelectedUsers;
            List<WorkAssignment> workAssignments = parameters.SelectedWorkAssignments;

            DateRange range = new DateRange(fromDate, toDate);

            List<FormOilsandsTraining> result = formService.QueryFormOilsandsTrainingsByDatesAndUsersAndWorkAssignments(range, users.ConvertAll(u => u.IdValue), workAssignments.ConvertAll(wa => wa.IdValue));
            return result;
        }

        protected override PrintActions<FormOilsandsTraining, FormOilsandsTrainingReport, FormOilsandsTrainingReportAdapter> PrintActions
        {
            get { return printActions; }
        }

        private List<WorkAssignment> GetWorkAssignments()
        {           
            List<Role> validRoles = GetValidRoles();
            List<WorkAssignment> assignments = workAssignmentService.QueryBySite(ClientSession.GetUserContext().Site);
            List<WorkAssignment> allAvailableWorkAssignments = assignments.FindAll(assignment => validRoles.ExistsById(assignment.Role));
            return allAvailableWorkAssignments;            
        }

        private List<UserDTO> GetUsers()
        {
            List<UserDTO> users = userService.QueryUsersWhoHaveCreatedOilsandsTrainingForms();
            return users;
        } 

        protected List<Role> GetValidRoles()
        {
            return roleService.QueryAllAvailableInSiteWithAnyRoleElement(ClientSession.GetUserContext().Site, new List<RoleElement> { RoleElement.CREATE_FORM });
        }       
    }
}
