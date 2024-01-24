using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;

namespace Com.Suncor.Olt.Client.Fixtures
{
    public class UserRoleElementsFixture
    {
        public static UserRoleElements CreateRoleElementsForOperatingEngineer()
        {
            UserRoleElements roleElements = CreateRoleElementsForOperator();

            roleElements.AddRoleElement(RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            roleElements.AddRoleElement(RoleElement.CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            roleElements.AddRoleElement(RoleElement.DELETE_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);

            return roleElements;
        }


        public static UserRoleElements CreateRoleElementsForOperator()
        {
            List<RoleElement> roleElements = new List<RoleElement>
                                                 {
                                                     RoleElement.VIEW_ACTIONITEMDEFINITION,
                                                     RoleElement.COMMENT_ACTIONITEMDEFINITION,
                                                     RoleElement.VIEW_TARGETDEFINITION,
                                                     RoleElement.REVIEW_TARGETDEFINITION,
                                                     RoleElement.CREATE_PERMIT,
                                                     RoleElement.VIEW_PERMIT,
                                                     RoleElement.APPROVE_PERMIT,
                                                     RoleElement.REJECT_PERMIT,
                                                     RoleElement.CLOSE_PERMIT,
                                                     RoleElement.PRINT_PERMIT,
                                                     RoleElement.DELETE_PERMIT,
                                                     RoleElement.UPDATE_PERMIT_NO_RESTRICTIONS,
                                                     RoleElement.VIEW_LOG,
                                                     RoleElement.CREATE_LOG,
                                                     RoleElement.REPLY_TO_LOG,
                                                     RoleElement.EDIT_LOG,
                                                     RoleElement.DELETE_LOG,
                                                     RoleElement.CANCEL_LOG,
                                                     RoleElement.VIEW_ACTIONITEM,
                                                     RoleElement.RESPOND_ACTIONITEM,
                                                     RoleElement.VIEW_TARGET_ALERTS,
                                                     RoleElement.RESPOND_TO_TARGET_ALERTS,
                                                     RoleElement.CLONE_PERMIT_WITH_NO_RESTRICTION,
                                                     RoleElement.VIEW_SAP_NOTIFICATIONS,
                                                     RoleElement.PROCESS_SAP_NOTIFICATIONS,
                                                     RoleElement.COPY_PERMIT_WITH_NO_RESTRICTION,
                                                     RoleElement.COMMENT_WORK_PERMIT,
                                                     RoleElement.VIEW_LOG_DEFINITION,
                                                     RoleElement.CONFIGURE_PLANT_HISTORIAN_TAG_LIST
                                                 };

            return new UserRoleElements(RoleFixture.CreateOperatorRole(), roleElements);
        }

        public static UserRoleElements CreateRoleElementsForSupervisor()
        {
            List<RoleElement> roleElements = new List<RoleElement>
                                                 {
                                                     RoleElement.CREATE_ACTIONITEMDEFINITION,
                                                     RoleElement.VIEW_ACTIONITEMDEFINITION,
                                                     RoleElement.APPROVE_ACTIONITEMDEFINITION,
                                                     RoleElement.REJECT_ACTIONITEMDEFINITION,
                                                     RoleElement.DELETE_ACTIONITEMDEFINITION,
                                                     RoleElement.EDIT_ACTIONITEMDEFINITION,
                                                     RoleElement.COMMENT_ACTIONITEMDEFINITION,
                                                     RoleElement.TOGGLE_ACTIONITEMDEFINITION_APPROVAL_REQUIRED,
                                                     RoleElement.CREATE_TARGETDEFINITION,
                                                     RoleElement.VIEW_TARGETDEFINITION,
                                                     RoleElement.APPROVE_TARGETDEFINITION,
                                                     RoleElement.REJECT_TARGETDEFINITION,
                                                     RoleElement.EDIT_TARGETDEFINITION,
                                                     RoleElement.DELETE_TARGETDEFINITION,
                                                     RoleElement.REVIEW_TARGETDEFINITION,
                                                     RoleElement.TOGGLE_TARGETDEFINITION_APPROVAL_REQUIRED,
                                                     RoleElement.CREATE_PERMIT,
                                                     RoleElement.VIEW_PERMIT,
                                                     RoleElement.DELETE_PERMIT,
                                                     RoleElement.UPDATE_PERMIT_NO_RESTRICTIONS,
                                                     RoleElement.APPROVE_PERMIT,
                                                     RoleElement.REJECT_PERMIT,
                                                     RoleElement.CLOSE_PERMIT,
                                                     RoleElement.PRINT_PERMIT,
                                                     RoleElement.CREATE_LOG,
                                                     RoleElement.REPLY_TO_LOG,
                                                     RoleElement.VIEW_LOG,
                                                     RoleElement.EDIT_LOG,
                                                     RoleElement.DELETE_LOG,
                                                     RoleElement.VIEW_SUMMARY_LOG,
                                                     RoleElement.CREATE_SUMMARY_LOG,
                                                     RoleElement.EDIT_SUMMARY_LOG,
                                                     RoleElement.DELETE_SUMMARY_LOG,
                                                     RoleElement.VIEW_ACTIONITEM,
                                                     RoleElement.RESPOND_ACTIONITEM,
                                                     RoleElement.VIEW_TARGET_ALERTS,
                                                     RoleElement.RESPOND_TO_TARGET_ALERTS,
                                                     RoleElement.CLONE_PERMIT_WITH_NO_RESTRICTION,
                                                     RoleElement.VIEW_SAP_NOTIFICATIONS,
                                                     RoleElement.PROCESS_SAP_NOTIFICATIONS,
                                                     RoleElement.COPY_PERMIT_WITH_NO_RESTRICTION,
                                                     RoleElement.COMMENT_WORK_PERMIT,
                                                     RoleElement.VIEW_LOG_DEFINITION,
                                                     RoleElement.CONFIGURE_AUTO_APPROVE_SAP_AID,
                                                     RoleElement.CONFIGURE_PLANT_HISTORIAN_TAG_LIST,
                                                     RoleElement.CONFIGURE_AUTO_RE_APPROVAL_BY_FIELD,

                                                     //GENERIC TEMPLATE - MANGESH
                                                     //RoleElement.VIEW_ODOURNOISE,
                                                     //RoleElement.APPROVE_ODOURNOISE,
                                                     //RoleElement.CREATE_ODOURNOISE,
                                                     //RoleElement.EDIT_ODOURNOISE,
                                                     //RoleElement.DELETE_ODOURNOISE,

                                                     //RoleElement.VIEW_DEVIATION,
                                                     //RoleElement.APPROVE_DEVIATION,
                                                     //RoleElement.CREATE_DEVIATION,
                                                     //RoleElement.EDIT_DEVIATION,
                                                     //RoleElement.DELETE_DEVIATION,

                                                     //RoleElement.VIEW_GN11GROUNDDISTURBANCE,
                                                     //RoleElement.APPROVE_GN11GROUNDDISTURBANCE,
                                                     //RoleElement.CREATE_GN11GROUNDDISTURBANCE,
                                                     //RoleElement.EDIT_GN11GROUNDDISTURBANCE,
                                                     //RoleElement.DELETE_GN11GROUNDDISTURBANCE,

                                                     //RoleElement.VIEW_GN27FREEZEPLUG,
                                                     //RoleElement.APPROVE_GN27FREEZEPLUG,
                                                     //RoleElement.CREATE_GN27FREEZEPLUG,
                                                     //RoleElement.EDIT_GN27FREEZEPLUG,
                                                     //RoleElement.DELETE_GN27FREEZEPLUG,

                                                     //RoleElement.VIEW_HAZARDASSESSMENT,
                                                     //RoleElement.APPROVE_HAZARDASSESSMENT,
                                                     //RoleElement.CREATE_HAZARDASSESSMENT,
                                                     //RoleElement.EDIT_HAZARDASSESSMENT,
                                                     //RoleElement.DELETE_HAZARDASSESSMENT
                                                 };

            return new UserRoleElements(RoleFixture.CreateSupervisorRole(), roleElements);
        }

        public static UserRoleElements CreateRoleElementsForEngineeringSupport()
        {
            List<RoleElement> roleElements = new List<RoleElement>
                                                 {
                                                     RoleElement.VIEW_ACTIONITEMDEFINITION,
                                                     RoleElement.CREATE_ACTIONITEMDEFINITION,
                                                     RoleElement.EDIT_ACTIONITEMDEFINITION,
                                                     RoleElement.DELETE_ACTIONITEMDEFINITION,
                                                     RoleElement.COMMENT_ACTIONITEMDEFINITION,
                                                     RoleElement.VIEW_TARGETDEFINITION,
                                                     RoleElement.CREATE_TARGETDEFINITION,
                                                     RoleElement.EDIT_TARGETDEFINITION,
                                                     RoleElement.DELETE_TARGETDEFINITION,
                                                     RoleElement.REVIEW_TARGETDEFINITION,
                                                     RoleElement.VIEW_LOG,
                                                     RoleElement.VIEW_PERMIT,
                                                     RoleElement.CREATE_PERMIT,
                                                     RoleElement.VIEW_TARGET_ALERTS,
                                                     RoleElement.VIEW_ACTIONITEM,
                                                     RoleElement.CONFIGURE_PLANT_HISTORIAN_TAG_LIST,
                                                     RoleElement.CONFIGURE_PREAPPROVED_TARGET_RANGES
                                                 };

            return new UserRoleElements(RoleFixture.CreateEngineeringSupportRole(), roleElements);
        }

        public static UserRoleElements CreateRoleElementsForNonOperationsPermitIssuer()
        {
            List<RoleElement> roleElements = new List<RoleElement>
                                                 {
                                                     RoleElement.APPROVE_NON_OPERATIONS_PERMIT,
                                                     RoleElement.CLONE_PERMIT_WITH_NO_RESTRICTION,
                                                     RoleElement.CLOSE_NON_OPERATIONS_PERMIT,
                                                     RoleElement.COPY_PERMIT_WITH_NO_RESTRICTION,
                                                     RoleElement.CREATE_PERMIT,
                                                     RoleElement.DELETE_NON_OPERATIONS_PERMIT,
                                                     RoleElement.PRINT_NON_OPERATIONS_PERMIT,
                                                     RoleElement.REJECT_NON_OPERATIONS_PERMIT,
                                                     RoleElement.EDIT_NON_OPERATIONS_PERMIT,
                                                     RoleElement.VIEW_ACTIONITEM,
                                                     RoleElement.VIEW_ACTIONITEMDEFINITION,
                                                     RoleElement.VIEW_LOG,
                                                     RoleElement.VIEW_PERMIT,
                                                     RoleElement.VIEW_SAP_NOTIFICATIONS,
                                                     RoleElement.VIEW_TARGET_ALERTS,
                                                     RoleElement.VIEW_TARGETDEFINITION
                                                 };

            return new UserRoleElements(RoleFixture.CreateNonOperationsPermitIssuerRole(), roleElements);
        }

        public static UserRoleElements CreateRoleElementsForPermitScreener()
        {
            List<RoleElement> roleElements = new List<RoleElement>
                                                 {
                                                     RoleElement.VIEW_LOG,
                                                     RoleElement.VIEW_PERMIT,
                                                     RoleElement.CREATE_PERMIT,
                                                     RoleElement.UPDATE_PERMIT_WITH_RESTRICTED_PERMIT_UPDATING,
                                                     RoleElement.CLONE_PERMIT_WITH_SOME_RESTRICTIONS,
                                                     RoleElement.COPY_PERMIT_WITH_SOME_RESTRICTIONS
                                                 };

            return new UserRoleElements(RoleFixture.CreatePermitScreenerRole(), roleElements);
        }

        public static UserRoleElements CreateRoleElementsForAdmin()
        {
            List<RoleElement> roleElements = new List<RoleElement>
                                                 {
                                                     RoleElement.CONFIGURE_GAS_TEST_LIMITS,
                                                     RoleElement.CONFIGURE_WORK_PERMIT_ARCHIVAL_PROCESS,
                                                     RoleElement.CONFIGURE_AUTO_APPROVE_SAP_AID,
                                                     RoleElement.CONFIGURE_WORK_PERMIT_CONTRACTOR,
                                                     RoleElement.CONFIGURE_WORK_ASSIGNMENTS,
                                                     RoleElement.CONFIGURE_AUTO_RE_APPROVAL_BY_FIELD
                                                 };

            return new UserRoleElements(RoleFixture.CreateAdministratorRole(), roleElements);
        }

        public static UserRoleElements CreateEmpty()
        {
            return new UserRoleElements(RoleFixture.CreateOperatorRole(), new List<RoleElement>(0));
        }

    }
}
