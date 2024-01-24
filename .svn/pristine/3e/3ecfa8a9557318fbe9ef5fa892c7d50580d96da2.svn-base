using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class AuthorizationMatrixTest
    {
        private IAuthorized authorized;
        private ShiftPattern dayShiftPattern;
        private IRolePermissionService rolePermissionService;
        private UserContext userContext;
        private UserShift userDayShift;


        [SetUp]
        public void Setup()
        {
            Clock.Freeze();

            authorized = new Authorized();

            dayShiftPattern = ShiftPatternFixture.CreateDayShift();

            userDayShift = new UserShift(dayShiftPattern, ShiftPatternFixture.CreateDateTimeDuringDayShift());

            rolePermissionService = GenericServiceRegistry.Instance.GetService<IRolePermissionService>();

            userContext = new UserContext(null);

            Clock.Now = userDayShift.StartDateTime;
        }

        [TearDown]
        public void Teardown()
        {
            Clock.UnFreeze();
        }

        // Begin Matrix Tests

        [Test][Ignore]
        public void VerifyDenverPermissionsForLogsAndDirectivesBasedOnRoleElements()
        {
            var roleElementService = GenericServiceRegistry.Instance.GetService<IRoleElementService>();
            var roleService = GenericServiceRegistry.Instance.GetService<IRoleService>();

            var denverRoles = roleService.QueryRolesBySite(SiteFixture.Denver());

            var administrator = denverRoles.Find(role => role.Name == "Administrator");
            var engineeringSupport = denverRoles.Find(role => role.Name == "Engineering Support");
            var engineeringSupportPlus = denverRoles.Find(role => role.Name == "Engineering Support Plus");
            var nonOperationsPermitIssuer = denverRoles.Find(role => role.Name == "Non-Operations Permit Issuer");
            var operatorz = denverRoles.Find(role => role.Name == "Operator");
            var permitScreener = denverRoles.Find(role => role.Name == "Permit Screener");
            var permitScreenerCommentor = denverRoles.Find(role => role.Name == "Permit Screener Commentor");
            var readUser = denverRoles.Find(role => role.Name == "Read User");
            var supervisor = denverRoles.Find(role => role.Name == "Supervisor");
            var supervisorPlus = denverRoles.Find(role => role.Name == "Supervisor Plus");

            var roles = new List<Role>
            {
                administrator,
                engineeringSupport,
                engineeringSupportPlus,
                nonOperationsPermitIssuer,
                operatorz,
                permitScreener,
                permitScreenerCommentor,
                readUser,
                supervisor,
                supervisorPlus
            };

            var administratorRoleElements = roleElementService.QueryTemplateForRole(administrator);
            var engineeringSupportRoleElements = roleElementService.QueryTemplateForRole(engineeringSupport);
            var engineeringSupportPlusRoleElements = roleElementService.QueryTemplateForRole(engineeringSupportPlus);
            var nonOperationsPermitIssuerRoleElements =
                roleElementService.QueryTemplateForRole(nonOperationsPermitIssuer);
            var operatorRoleElements = roleElementService.QueryTemplateForRole(operatorz);
            var permitScreenerRoleElements = roleElementService.QueryTemplateForRole(permitScreener);
            var permitScreenerCommentorRoleElements = roleElementService.QueryTemplateForRole(permitScreenerCommentor);
            var readUserRoleElements = roleElementService.QueryTemplateForRole(readUser);
            var supervisorRoleElements = roleElementService.QueryTemplateForRole(supervisor);
            var supervisorPlusRoleElements = roleElementService.QueryTemplateForRole(supervisorPlus);

            var administratorUserRoleElements = new UserRoleElements(administrator, administratorRoleElements);
            var engineeringSupportUserRoleElements = new UserRoleElements(engineeringSupport,
                engineeringSupportRoleElements);
            var engineeringSupportPlusUserRoleElements = new UserRoleElements(engineeringSupportPlus,
                engineeringSupportPlusRoleElements);
            var nonOperationsPermitIssuerUserRoleElements = new UserRoleElements(nonOperationsPermitIssuer,
                nonOperationsPermitIssuerRoleElements);
            var operatorUserRoleElements = new UserRoleElements(operatorz, operatorRoleElements);
            var permitScreenerUserRoleElements = new UserRoleElements(permitScreener, permitScreenerRoleElements);
            var permitScreenerCommentorUserRoleElements = new UserRoleElements(permitScreener,
                permitScreenerCommentorRoleElements);
            var readUserUserRoleElements = new UserRoleElements(readUser, readUserRoleElements);
            var supervisorUserRoleElements = new UserRoleElements(supervisor, supervisorRoleElements);
            var supervisorPlusUserRoleElements = new UserRoleElements(supervisorPlus, supervisorPlusRoleElements);

            // ****************************** LOGS *******************************************
            // Administrator
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                administratorUserRoleElements, administrator);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                administratorUserRoleElements, administrator);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                administratorUserRoleElements, administrator);
            // Engineering Support 
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, true, false, false, false, false, false, false, false, false},
                engineeringSupportUserRoleElements, engineeringSupport);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, true, false, false, false, false, false, false, false, false},
                engineeringSupportUserRoleElements, engineeringSupport);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, true, false, false, false, false, false, false, false, false},
                engineeringSupportUserRoleElements, engineeringSupport);
            // Engineering Support Plus
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                engineeringSupportPlusUserRoleElements, engineeringSupportPlus);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                engineeringSupportPlusUserRoleElements, engineeringSupportPlus);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                engineeringSupportPlusUserRoleElements, engineeringSupportPlus);
            // Non Operations Permit Issuer
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                nonOperationsPermitIssuerUserRoleElements, nonOperationsPermitIssuer);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                nonOperationsPermitIssuerUserRoleElements, nonOperationsPermitIssuer);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                nonOperationsPermitIssuerUserRoleElements, nonOperationsPermitIssuer);
            // Operator
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, false, false, false, true, false, false, false, false, false},
                operatorUserRoleElements, operatorz);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, false, false, false, true, false, false, false, false, false},
                operatorUserRoleElements, operatorz);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, true, false, false, false, false, false},
                operatorUserRoleElements, operatorz);
            // Permit Screener
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                permitScreenerUserRoleElements, permitScreener);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                permitScreenerUserRoleElements, permitScreener);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                permitScreenerUserRoleElements, permitScreener);
            // Permit Screener Commentor
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                permitScreenerCommentorUserRoleElements, permitScreenerCommentor);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                permitScreenerCommentorUserRoleElements, permitScreenerCommentor);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                permitScreenerCommentorUserRoleElements, permitScreenerCommentor);
            // Read User
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                readUserUserRoleElements, readUser);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                readUserUserRoleElements, readUser);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                readUserUserRoleElements, readUser);
            // Supervisor
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, true, true},
                supervisorUserRoleElements, supervisor);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, true, true},
                supervisorUserRoleElements, supervisor);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, true, true},
                supervisorUserRoleElements, supervisor);
            // Supervisor Plus
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, true, true},
                supervisorPlusUserRoleElements, supervisorPlus);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, true, true},
                supervisorPlusUserRoleElements, supervisorPlus);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, true, true},
                supervisorPlusUserRoleElements, supervisorPlus);

            // ****************************** LOGS - DIRECTIVES ******************************
            var rolesForDirectives = new List<Role> {supervisor, supervisorPlus};

            // Supervisor
            AssertAuthorizedToEditDirectives(rolesForDirectives, new List<bool> {true, true}, supervisorUserRoleElements,
                supervisor);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives, new List<bool> {true, true},
                supervisorUserRoleElements, supervisor);
            // Supervisor Plus
            AssertAuthorizedToEditDirectives(rolesForDirectives, new List<bool> {true, true},
                supervisorPlusUserRoleElements, supervisorPlus);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives, new List<bool> {true, true},
                supervisorPlusUserRoleElements, supervisorPlus);
        }

        [Test][Ignore]
        public void VerifyEdmontonPermissionsForLogsAndDirectivesBasedOnRoleElements()
        {
            var roleElementService = GenericServiceRegistry.Instance.GetService<IRoleElementService>();
            var roleService = GenericServiceRegistry.Instance.GetService<IRoleService>();

            var edmontonRoles = roleService.QueryRolesBySite(SiteFixture.Edmonton());

            var administrator = edmontonRoles.Find(role => role.Name == "Administrator");
            var areaManager = edmontonRoles.Find(role => role.Name == "Coordinator / Manager");
            var operatingChiefEngineer = edmontonRoles.Find(role => role.Name == "Operating / Chief Engineer");
            var operatorz = edmontonRoles.Find(role => role.Name == "Operator");
            var readUser = edmontonRoles.Find(role => role.Name == "Read User");
            var restrictionReportingAdmin = edmontonRoles.Find(role => role.Name == "Restriction Reporting Admin");
            var supervisor = edmontonRoles.Find(role => role.Name == "Supervisor");
            var unitLeader = edmontonRoles.Find(role => role.Name == "Unit Leader");

            var roles = new List<Role>
            {
                administrator,
                areaManager,
                operatingChiefEngineer,
                operatorz,
                readUser,
                restrictionReportingAdmin,
                supervisor,
                unitLeader
            };

            var administratorRoleElements = roleElementService.QueryTemplateForRole(administrator);
            var areaManagerRoleElements = roleElementService.QueryTemplateForRole(areaManager);
            var operatingEngineerRoleElements = roleElementService.QueryTemplateForRole(operatingChiefEngineer);
            var operatorRoleElements = roleElementService.QueryTemplateForRole(operatorz);
            var readUserRoleElements = roleElementService.QueryTemplateForRole(readUser);
            var restrictionReportingAdminRoleElements =
                roleElementService.QueryTemplateForRole(restrictionReportingAdmin);
            var supervisorRoleElements = roleElementService.QueryTemplateForRole(supervisor);
            var unitLeaderRoleElements = roleElementService.QueryTemplateForRole(unitLeader);

            var administratorUserRoleElements = new UserRoleElements(administrator, administratorRoleElements);
            var areaManagerUserRoleElements = new UserRoleElements(areaManager, areaManagerRoleElements);
            var operatingEngineerUserRoleElements = new UserRoleElements(operatingChiefEngineer,
                operatingEngineerRoleElements);
            var operatorUserRoleElements = new UserRoleElements(operatorz, operatorRoleElements);
            var readUserUserRoleElements = new UserRoleElements(readUser, readUserRoleElements);
            var restrictionReportingAdminUserRoleElements = new UserRoleElements(restrictionReportingAdmin,
                restrictionReportingAdminRoleElements);
            var supervisorUserRoleElements = new UserRoleElements(supervisor, supervisorRoleElements);
            var unitLeaderUserRoleElements = new UserRoleElements(unitLeader, unitLeaderRoleElements);

            // ****************************** LOGS *******************************************
            // Administrator
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                administratorUserRoleElements, administrator);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                administratorUserRoleElements, administrator);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false}, administratorUserRoleElements,
                administrator);
            // Area Manager
            AssertAuthorizedToEditLog(roles, new List<bool> {false, true, false, false, false, false, false, false},
                areaManagerUserRoleElements, areaManager);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                areaManagerUserRoleElements, areaManager);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, true, false, false, false, false, false, false}, areaManagerUserRoleElements,
                areaManager);
            // Operating Engineer
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, true, true, false, false, false, true},
                operatingEngineerUserRoleElements, operatingChiefEngineer);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                operatingEngineerUserRoleElements, operatingChiefEngineer);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, true, true, false, false, false, true}, operatingEngineerUserRoleElements,
                operatingChiefEngineer);
            // Operator
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, true, true, false, false, false, true},
                operatorUserRoleElements, operatorz);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                operatorUserRoleElements, operatorz);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, true, true, false, false, false, true}, operatorUserRoleElements,
                operatorz);
            // Read User
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                readUserUserRoleElements, readUser);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                readUserUserRoleElements, readUser);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false}, readUserUserRoleElements,
                readUser);
            // Restriction Reporting Admin
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                restrictionReportingAdminUserRoleElements, restrictionReportingAdmin);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                restrictionReportingAdminUserRoleElements, restrictionReportingAdmin);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false},
                restrictionReportingAdminUserRoleElements, restrictionReportingAdmin);
            // Supervisor
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, false, false, false, false, true, false},
                supervisorUserRoleElements, supervisor);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                supervisorUserRoleElements, supervisor);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, true, false}, supervisorUserRoleElements,
                supervisor);
            // Unit Leader
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, true, true, false, false, false, true},
                unitLeaderUserRoleElements, unitLeader);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                unitLeaderUserRoleElements, unitLeader);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, true, true, false, false, false, true}, unitLeaderUserRoleElements,
                unitLeader);

            // ****************************** LOGS - DIRECTIVES ******************************
            var rolesForDirectives = new List<Role> {areaManager, operatingChiefEngineer, supervisor};

            // Area Manager
            AssertAuthorizedToEditDirectives(rolesForDirectives, new List<bool> {true, false, true},
                areaManagerUserRoleElements, areaManager);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives, new List<bool> {true, false, true},
                areaManagerUserRoleElements, areaManager);
            // Operating Engineer
            AssertAuthorizedToEditDirectives(rolesForDirectives, new List<bool> {false, true, false},
                operatingEngineerUserRoleElements, operatingChiefEngineer);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives, new List<bool> {false, false, false},
                operatingEngineerUserRoleElements, operatingChiefEngineer);
            // Supervisor
            AssertAuthorizedToEditDirectives(rolesForDirectives, new List<bool> {true, false, true},
                supervisorUserRoleElements, supervisor);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives, new List<bool> {true, false, true},
                supervisorUserRoleElements, supervisor);
        }

        [Test][Ignore]
        public void VerifyFirebagPermissionsForLogsAndDirectivesBasedOnRoleElements()
        {
            var roleElementService = GenericServiceRegistry.Instance.GetService<IRoleElementService>();
            var roleService = GenericServiceRegistry.Instance.GetService<IRoleService>();

            var firebagRoles = roleService.QueryRolesBySite(SiteFixture.Firebag());

            var administrator = firebagRoles.Find(role => role.Name == "Administrator");
            var areaManager = firebagRoles.Find(role => role.Name == "Area Manager");
            var operatingChiefEngineer = firebagRoles.Find(role => role.Name == "Operating / Chief Engineer");
            var operatorz = firebagRoles.Find(role => role.Name == "Operator");
            var productionEngineer = firebagRoles.Find(role => role.Name == "Production Engineer");
            var readUser = firebagRoles.Find(role => role.Name == "Read User");
            var supervisor = firebagRoles.Find(role => role.Name == "Supervisor");

            var roles = new List<Role>
            {
                administrator,
                areaManager,
                operatingChiefEngineer,
                operatorz,
                productionEngineer,
                readUser,
                supervisor
            };

            var administratorRoleElements = roleElementService.QueryTemplateForRole(administrator);
            var areaManagerRoleElements = roleElementService.QueryTemplateForRole(areaManager);
            var operatingEngineerRoleElements = roleElementService.QueryTemplateForRole(operatingChiefEngineer);
            var operatorRoleElements = roleElementService.QueryTemplateForRole(operatorz);
            var productionEngineerRoleElements = roleElementService.QueryTemplateForRole(productionEngineer);
            var readUserRoleElements = roleElementService.QueryTemplateForRole(readUser);
            var supervisorRoleElements = roleElementService.QueryTemplateForRole(supervisor);

            var administratorUserRoleElements = new UserRoleElements(administrator, administratorRoleElements);
            var areaManagerUserRoleElements = new UserRoleElements(areaManager, areaManagerRoleElements);
            var operatingEngineerUserRoleElements = new UserRoleElements(operatingChiefEngineer,
                operatingEngineerRoleElements);
            var operatorUserRoleElements = new UserRoleElements(operatorz, operatorRoleElements);
            var productionEngineerUserRoleElements = new UserRoleElements(operatorz, productionEngineerRoleElements);
            var readUserUserRoleElements = new UserRoleElements(readUser, readUserRoleElements);
            var supervisorUserRoleElements = new UserRoleElements(supervisor, supervisorRoleElements);

            // ****************************** LOGS *******************************************
            // Administrator
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, false, false, false, false, false},
                administratorUserRoleElements, administrator);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false, false, false},
                administratorUserRoleElements, administrator);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false}, administratorUserRoleElements,
                administrator);
            // Area Manager
            AssertAuthorizedToEditLog(roles, new List<bool> {false, true, false, false, false, false, false},
                areaManagerUserRoleElements, areaManager);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, true, false, false, false, false, false},
                areaManagerUserRoleElements, areaManager);
            AssertAuthorizedToCancelReoccuringLog(roles, new List<bool> {false, true, false, false, false, false, false},
                areaManagerUserRoleElements, areaManager);
            // Operating Engineer
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, true, true, false, false, false},
                operatingEngineerUserRoleElements, operatingChiefEngineer);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, true, true, false, false, false},
                operatingEngineerUserRoleElements, operatingChiefEngineer);
            AssertAuthorizedToCancelReoccuringLog(roles, new List<bool> {false, false, true, true, false, false, false},
                operatingEngineerUserRoleElements, operatingChiefEngineer);
            // Operator
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, true, true, false, false, false},
                operatorUserRoleElements, operatorz);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, true, true, false, false, false},
                operatorUserRoleElements, operatorz);
            AssertAuthorizedToCancelReoccuringLog(roles, new List<bool> {false, false, true, true, false, false, false},
                operatorUserRoleElements, operatorz);
            // Production Engineer
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, false, false, true, false, false},
                productionEngineerUserRoleElements, productionEngineer);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, true, false, false},
                productionEngineerUserRoleElements, productionEngineer);
            AssertAuthorizedToCancelReoccuringLog(roles, new List<bool> {false, false, false, false, true, false, false},
                productionEngineerUserRoleElements, productionEngineer);
            // Read User
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, false, false, false, false, false},
                readUserUserRoleElements, readUser);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false, false, false},
                readUserUserRoleElements, readUser);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false}, readUserUserRoleElements, readUser);
            // Supervisor
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, false, false, false, false, true},
                supervisorUserRoleElements, supervisor);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false, false, true},
                supervisorUserRoleElements, supervisor);
            AssertAuthorizedToCancelReoccuringLog(roles, new List<bool> {false, false, false, false, false, false, true},
                supervisorUserRoleElements, supervisor);

            // ****************************** LOGS - DIRECTIVES ******************************
            var rolesForDirectives = new List<Role>
            {
                areaManager,
                operatingChiefEngineer,
                productionEngineer,
                supervisor
            };

            // Area Manager
            AssertAuthorizedToEditDirectives(rolesForDirectives, new List<bool> {true, false, false, true},
                areaManagerUserRoleElements, areaManager);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives, new List<bool> {true, false, false, true},
                areaManagerUserRoleElements, areaManager);
            // Operating Engineer
            AssertAuthorizedToEditDirectives(rolesForDirectives, new List<bool> {false, true, false, false},
                operatingEngineerUserRoleElements, operatingChiefEngineer);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives, new List<bool> {false, true, false, false},
                operatingEngineerUserRoleElements, operatingChiefEngineer);
            // Production Engineer
            AssertAuthorizedToEditDirectives(rolesForDirectives, new List<bool> {false, false, true, false},
                productionEngineerUserRoleElements, productionEngineer);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives, new List<bool> {false, false, true, false},
                productionEngineerUserRoleElements, productionEngineer);
            // Supervisor
            AssertAuthorizedToEditDirectives(rolesForDirectives, new List<bool> {true, false, false, true},
                supervisorUserRoleElements, supervisor);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives, new List<bool> {true, false, false, true},
                supervisorUserRoleElements, supervisor);
        }

        [Test][Ignore]
        public void VerifyMacKayPermissionsForLogsAndDirectivesBasedOnRoleElements()
        {
            var roleElementService = GenericServiceRegistry.Instance.GetService<IRoleElementService>();
            var roleService = GenericServiceRegistry.Instance.GetService<IRoleService>();

            var macKayRoles = roleService.QueryRolesBySite(SiteFixture.MacKayRiver());

            var administrator = macKayRoles.Find(role => role.Name == "Administrator");
            var operatingEngineer = macKayRoles.Find(role => role.Name == "Operating Engineer");
            var operatorz = macKayRoles.Find(role => role.Name == "Operator");
            var readUser = macKayRoles.Find(role => role.Name == "Read User");
            var supervisor = macKayRoles.Find(role => role.Name == "Supervisor");

            var roles = new List<Role> {administrator, operatingEngineer, operatorz, readUser, supervisor};

            var administratorRoleElements = roleElementService.QueryTemplateForRole(administrator);
            var operatingEngineerRoleElements = roleElementService.QueryTemplateForRole(operatingEngineer);
            var operatorRoleElements = roleElementService.QueryTemplateForRole(operatorz);
            var readUserRoleElements = roleElementService.QueryTemplateForRole(readUser);
            var supervisorRoleElements = roleElementService.QueryTemplateForRole(supervisor);

            var administratorUserRoleElements = new UserRoleElements(administrator, administratorRoleElements);
            var operatingEngineerUserRoleElements = new UserRoleElements(operatingEngineer,
                operatingEngineerRoleElements);
            var operatorUserRoleElements = new UserRoleElements(operatorz, operatorRoleElements);
            var readUserUserRoleElements = new UserRoleElements(readUser, readUserRoleElements);
            var supervisorUserRoleElements = new UserRoleElements(supervisor, supervisorRoleElements);

            // ****************************** LOGS *******************************************
            // Administrator
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, false, false, false},
                administratorUserRoleElements, administrator);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false},
                administratorUserRoleElements, administrator);
            AssertAuthorizedToCancelReoccuringLog(roles, new List<bool> {false, false, false, false, false},
                administratorUserRoleElements, administrator);
            // Operating Engineer
            AssertAuthorizedToEditLog(roles, new List<bool> {false, true, true, false, false},
                operatingEngineerUserRoleElements, operatingEngineer);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, true, true, false, false},
                operatingEngineerUserRoleElements, operatingEngineer);
            AssertAuthorizedToCancelReoccuringLog(roles, new List<bool> {false, true, true, false, false},
                operatingEngineerUserRoleElements, operatingEngineer);
            // Operator
            AssertAuthorizedToEditLog(roles, new List<bool> {false, true, true, false, false}, operatorUserRoleElements,
                operatorz);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, true, true, false, false},
                operatorUserRoleElements, operatorz);
            AssertAuthorizedToCancelReoccuringLog(roles, new List<bool> {false, true, true, false, false},
                operatorUserRoleElements, operatorz);
            // Read User
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, false, false, false},
                readUserUserRoleElements, readUser);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false},
                readUserUserRoleElements, readUser);
            AssertAuthorizedToCancelReoccuringLog(roles, new List<bool> {false, false, false, false, false},
                readUserUserRoleElements, readUser);
            // Supervisor
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, false, false, true},
                supervisorUserRoleElements, supervisor);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, true},
                supervisorUserRoleElements, supervisor);
            AssertAuthorizedToCancelReoccuringLog(roles, new List<bool> {false, false, false, false, true},
                supervisorUserRoleElements, supervisor);

            // ****************************** LOGS - DIRECTIVES ******************************
            var rolesForDirectives = new List<Role> {operatingEngineer, supervisor};

            // Operating Engineer
            AssertAuthorizedToEditDirectives(rolesForDirectives, new List<bool> {false, false},
                operatingEngineerUserRoleElements, operatingEngineer);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives, new List<bool> {false, false},
                operatingEngineerUserRoleElements, operatingEngineer);
            // Supervisor
            AssertAuthorizedToEditDirectives(rolesForDirectives, new List<bool> {false, true},
                supervisorUserRoleElements, supervisor);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives, new List<bool> {false, true},
                supervisorUserRoleElements, supervisor);
        }

        [Test][Ignore]
        public void VerifyMontrealPermissionsForLogsAndDirectivesBasedOnRoleElements()
        {
            var roleElementService = GenericServiceRegistry.Instance.GetService<IRoleElementService>();
            var roleService = GenericServiceRegistry.Instance.GetService<IRoleService>();

            var montrealRoles = roleService.QueryRolesBySite(SiteFixture.Montreal());

            var administrateur = montrealRoles.Find(role => role.Name == "Administrateur des Opérations");
            var operateur = montrealRoles.Find(role => role.Name == "Opérateur");
            var readUser = montrealRoles.Find(role => role.Name == "Lecture Seule");
            var superviseur = montrealRoles.Find(role => role.Name == "Superviseur");
            var teamLeader = montrealRoles.Find(role => role.Name == "Leader de  Secteur");
            var coordinator = montrealRoles.Find(role => role.Name == "Coordonnateur des Opérations");
            var engineer = montrealRoles.Find(role => role.Name == "Ingénieur");

            Assert.IsNull(montrealRoles.Find(role => role.Name == "Formateur"));
                // This has been removed as per story #1575

            var roles = new List<Role>
            {
                administrateur,
                operateur,
                readUser,
                superviseur,
                teamLeader,
                coordinator,
                engineer
            };

            var administrateurRoleElements = roleElementService.QueryTemplateForRole(administrateur);
            var operateurRoleElements = roleElementService.QueryTemplateForRole(operateur);
            var readUserRoleElements = roleElementService.QueryTemplateForRole(readUser);
            var superviseurRoleElements = roleElementService.QueryTemplateForRole(superviseur);
            var teamLeaderRoleElements = roleElementService.QueryTemplateForRole(teamLeader);
            var coordinatorRoleElements = roleElementService.QueryTemplateForRole(coordinator);
            var engineerRoleElements = roleElementService.QueryTemplateForRole(engineer);

            var administrateurUserRoleElements = new UserRoleElements(administrateur, administrateurRoleElements);
            var operateurUserRoleElements = new UserRoleElements(operateur, operateurRoleElements);
            var readUserUserRoleElements = new UserRoleElements(readUser, readUserRoleElements);
            var superviseurUserRoleElements = new UserRoleElements(superviseur, superviseurRoleElements);
            var teamLeaderUserRoleElements = new UserRoleElements(superviseur, teamLeaderRoleElements);
            var coordinatorUserRoleElements = new UserRoleElements(superviseur, coordinatorRoleElements);
            var engineerUserRoleElements = new UserRoleElements(superviseur, engineerRoleElements);

            // ****************************** LOGS *******************************************
            // Administrateur
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                administrateurUserRoleElements, administrateur);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                administrateurUserRoleElements, administrateur);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false}, administrateurUserRoleElements,
                administrateur);
            // Opérateur
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                operateurUserRoleElements, operateur);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                operateurUserRoleElements, operateur);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false}, operateurUserRoleElements,
                operateur);
            // Read User [Lecture Seule]
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                readUserUserRoleElements, readUser);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                readUserUserRoleElements, readUser);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false}, readUserUserRoleElements,
                readUser);
            // Superviseur
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                superviseurUserRoleElements, superviseur);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                superviseurUserRoleElements, superviseur);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false}, superviseurUserRoleElements,
                superviseur);
            // Team Leader
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                teamLeaderUserRoleElements, teamLeader);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                teamLeaderUserRoleElements, teamLeader);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false}, teamLeaderUserRoleElements,
                teamLeader);
            // Coordinator
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                coordinatorUserRoleElements, coordinator);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                coordinatorUserRoleElements, coordinator);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false}, coordinatorUserRoleElements,
                coordinator);
            // Engineer
            AssertAuthorizedToEditLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                engineerUserRoleElements, engineer);
            AssertAuthorizedToDeleteLog(roles, new List<bool> {false, false, false, false, false, false, false, false},
                engineerUserRoleElements, engineer);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false}, engineerUserRoleElements,
                engineer);

            // ****************************** LOGS - DIRECTIVES ******************************
            var rolesForDirectives = new List<Role> {superviseur, coordinator, engineer, teamLeader};

            // Superviseur
            AssertAuthorizedToEditNewDirectives(rolesForDirectives, new List<bool> { false, false, false, false },
                superviseurUserRoleElements, superviseur);
            AssertAuthorizedToDeleteNewDirectives(rolesForDirectives, new List<bool> { false, false, false, false },
                superviseurUserRoleElements, superviseur);
            // Coordinator
            AssertAuthorizedToEditNewDirectives(rolesForDirectives, new List<bool> { false, false, false, false },
                coordinatorUserRoleElements, coordinator);
            AssertAuthorizedToDeleteNewDirectives(rolesForDirectives, new List<bool> { false, false, false, false },
                coordinatorUserRoleElements, coordinator);
            // Engineer
            AssertAuthorizedToEditNewDirectives(rolesForDirectives, new List<bool> { false, false, false, false },
                engineerUserRoleElements, engineer);
            AssertAuthorizedToDeleteNewDirectives(rolesForDirectives, new List<bool> { false, false, false, false },
                engineerUserRoleElements, engineer);
            // Team Leader
            AssertAuthorizedToEditNewDirectives(rolesForDirectives, new List<bool> { false, false, false, false },
                teamLeaderUserRoleElements, teamLeader);
            AssertAuthorizedToDeleteNewDirectives(rolesForDirectives, new List<bool> { false, false, false, false },
                teamLeaderUserRoleElements, teamLeader);
        }

        [Test][Ignore]
        public void VerifyOilSandsPermissionsForLogsAndDirectivesBasedOnRoleElements()
        {
            var roleElementService = GenericServiceRegistry.Instance.GetService<IRoleElementService>();
            var roleService = GenericServiceRegistry.Instance.GetService<IRoleService>();

            var oilSandsRoles = roleService.QueryRolesBySite(SiteFixture.Oilsands());

            var administrator = oilSandsRoles.Find(role => role.Name == "Administrator");
            var areaManager = oilSandsRoles.Find(role => role.Name == "Area Manager");
            var operatingChiefEngineer = oilSandsRoles.Find(role => role.Name == "Operating / Chief Engineer");
            var operatorz = oilSandsRoles.Find(role => role.Name == "Operator");
            var processEngineer = oilSandsRoles.Find(role => role.Name == "Process Engineer");
            var processEngineerTargetAdmin = oilSandsRoles.Find(role => role.Name == "Process Engineer Target Admin");
            var readUser = oilSandsRoles.Find(role => role.Name == "Read User");
            var restrictionReportingAdmin = oilSandsRoles.Find(role => role.Name == "Restriction Reporting Admin");
            var supervisor = oilSandsRoles.Find(role => role.Name == "Supervisor");
            var taCoordinator = oilSandsRoles.Find(role => role.Name == "TA Coordinator");
            var taDirector = oilSandsRoles.Find(role => role.Name == "TA Director");
            var taEngineer = oilSandsRoles.Find(role => role.Name == "TA Engineer");
            var taExecutionManager = oilSandsRoles.Find(role => role.Name == "TA Execution Manager");
            var taManager = oilSandsRoles.Find(role => role.Name == "TA Manager");
            var unitLeader = oilSandsRoles.Find(role => role.Name == "Unit Leader");
            var maintenanceSupervisor = oilSandsRoles.Find(role => role.Name == "Maintenance Supervisor");

            var roles = new List<Role>
            {
                administrator,
                areaManager,
                operatingChiefEngineer,
                operatorz,
                processEngineer,
                processEngineerTargetAdmin,
                readUser,
                restrictionReportingAdmin,
                supervisor,
                taCoordinator,
                taDirector,
                taEngineer,
                taExecutionManager,
                taManager,
                unitLeader,
                maintenanceSupervisor
            };

            var administratorRoleElements = roleElementService.QueryTemplateForRole(administrator);
            var areaManagerRoleElements = roleElementService.QueryTemplateForRole(areaManager);
            var operatingChiefEngineerRoleElements = roleElementService.QueryTemplateForRole(operatingChiefEngineer);
            var operatorzRoleElements = roleElementService.QueryTemplateForRole(operatorz);
            var processEngineerRoleElements = roleElementService.QueryTemplateForRole(processEngineer);
            var processEngineerTargetAdminRoleElements =
                roleElementService.QueryTemplateForRole(processEngineerTargetAdmin);
            var readUserRoleElements = roleElementService.QueryTemplateForRole(readUser);
            var restrictionReportingAdminRoleElements =
                roleElementService.QueryTemplateForRole(restrictionReportingAdmin);
            var supervisorRoleElements = roleElementService.QueryTemplateForRole(supervisor);
            var taCoordinatorRoleElements = roleElementService.QueryTemplateForRole(taCoordinator);
            var taDirectorRoleElements = roleElementService.QueryTemplateForRole(taDirector);
            var taEngineerRoleElements = roleElementService.QueryTemplateForRole(taEngineer);
            var taExecutionManagerRoleElements = roleElementService.QueryTemplateForRole(taExecutionManager);
            var taManagerRoleElements = roleElementService.QueryTemplateForRole(taManager);
            var unitLeaderRoleElements = roleElementService.QueryTemplateForRole(unitLeader);
            var maintenanceSupervisorRoleElements = roleElementService.QueryTemplateForRole(maintenanceSupervisor);

            var administratorUserRoleElements = new UserRoleElements(administrator, administratorRoleElements);
            var areaManagerUserRoleElements = new UserRoleElements(areaManager, areaManagerRoleElements);
            var operatingChiefEngineerUserRoleElements = new UserRoleElements(operatingChiefEngineer,
                operatingChiefEngineerRoleElements);
            var operatorUserRoleElements = new UserRoleElements(operatorz, operatorzRoleElements);
            var processEngineerUserRoleElements = new UserRoleElements(processEngineer, processEngineerRoleElements);
            var processEngineerTargetAdminUserRoleElements = new UserRoleElements(processEngineerTargetAdmin,
                processEngineerTargetAdminRoleElements);
            var readUserUserRoleElements = new UserRoleElements(readUser, readUserRoleElements);
            var restrictionReportingAdminUserRoleElements = new UserRoleElements(restrictionReportingAdmin,
                restrictionReportingAdminRoleElements);
            var supervisorUserRoleElements = new UserRoleElements(supervisor, supervisorRoleElements);
            var taCoordinatorUserRoleElements = new UserRoleElements(taCoordinator, taCoordinatorRoleElements);
            var taDirectorUserRoleElements = new UserRoleElements(taDirector, taDirectorRoleElements);
            var taEngineerUserRoleElements = new UserRoleElements(taEngineer, taEngineerRoleElements);
            var taExecutionManagerUserRoleElements = new UserRoleElements(taExecutionManager,
                taExecutionManagerRoleElements);
            var taManagerUserRoleElements = new UserRoleElements(taManager, taManagerRoleElements);
            var unitLeaderUserRoleElements = new UserRoleElements(unitLeader, unitLeaderRoleElements);
            var maintenanceSupervisorUserRoleElements = new UserRoleElements(maintenanceSupervisor,
                maintenanceSupervisorRoleElements);

            // ****************************** LOGS *******************************************
            // Administrator
            AssertAuthorizedToEditLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, administratorUserRoleElements, administrator);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, administratorUserRoleElements, administrator);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, administratorUserRoleElements, administrator);
            // Area Manager 
            AssertAuthorizedToEditLog(roles,
                new List<bool>
                {
                    false,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, areaManagerUserRoleElements, areaManager);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool>
                {
                    false,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, areaManagerUserRoleElements, areaManager);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool>
                {
                    false,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, areaManagerUserRoleElements, areaManager);
            // Operating / Chief Engineer
            AssertAuthorizedToEditLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    true,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    true,
                    false
                }, operatingChiefEngineerUserRoleElements, operatingChiefEngineer);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    true,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    true,
                    false
                }, operatingChiefEngineerUserRoleElements, operatingChiefEngineer);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    true,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    true,
                    false
                }, operatingChiefEngineerUserRoleElements, operatingChiefEngineer);
            // Operator
            AssertAuthorizedToEditLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    true,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    true,
                    false
                }, operatorUserRoleElements, operatorz);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    true,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    true,
                    false
                }, operatorUserRoleElements, operatorz);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    true,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    true,
                    false
                }, operatorUserRoleElements, operatorz);
            // Process Engineer
            AssertAuthorizedToEditLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    true,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, processEngineerUserRoleElements, processEngineer);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    true,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, processEngineerUserRoleElements, processEngineer);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    true,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, processEngineerUserRoleElements, processEngineer);
            // Process Engineer Target Admin
            AssertAuthorizedToEditLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    true,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, processEngineerTargetAdminUserRoleElements, processEngineerTargetAdmin);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    true,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, processEngineerTargetAdminUserRoleElements, processEngineerTargetAdmin);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    true,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, processEngineerTargetAdminUserRoleElements, processEngineerTargetAdmin);
            // Read User
            AssertAuthorizedToEditLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, readUserUserRoleElements, readUser);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, readUserUserRoleElements, readUser);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, readUserUserRoleElements, readUser);
            // Restriction Reporting Admin
            AssertAuthorizedToEditLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, restrictionReportingAdminUserRoleElements, restrictionReportingAdmin);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, restrictionReportingAdminUserRoleElements, restrictionReportingAdmin);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, restrictionReportingAdminUserRoleElements, restrictionReportingAdmin);
            // Supervisor
            AssertAuthorizedToEditLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, supervisorUserRoleElements, supervisor);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, supervisorUserRoleElements, supervisor);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, supervisorUserRoleElements, supervisor);
            // TA Coordinator
            AssertAuthorizedToEditLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, taCoordinatorUserRoleElements, taCoordinator);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, taCoordinatorUserRoleElements, taCoordinator);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, taCoordinatorUserRoleElements, taCoordinator);
            // TA Director
            AssertAuthorizedToEditLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, taDirectorUserRoleElements, taDirector);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, taDirectorUserRoleElements, taDirector);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, taDirectorUserRoleElements, taDirector);
            // TA Engineer
            AssertAuthorizedToEditLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, taEngineerUserRoleElements, taEngineer);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, taEngineerUserRoleElements, taEngineer);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, taEngineerUserRoleElements, taEngineer);
            // TA ExecutionManager
            AssertAuthorizedToEditLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, taExecutionManagerUserRoleElements, taExecutionManager);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, taExecutionManagerUserRoleElements, taExecutionManager);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, taExecutionManagerUserRoleElements, taExecutionManager);
            // TA Manager
            AssertAuthorizedToEditLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, taManagerUserRoleElements, taManager);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, taManagerUserRoleElements, taManager);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false
                }, taManagerUserRoleElements, taManager);
            // Unit Leader
            AssertAuthorizedToEditLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    true,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    true,
                    false
                }, unitLeaderUserRoleElements, unitLeader);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    true,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    true,
                    false
                }, unitLeaderUserRoleElements, unitLeader);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    true,
                    true,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    true,
                    false
                }, unitLeaderUserRoleElements, unitLeader);
            // MaintenanceSupervisor
            AssertAuthorizedToEditLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    true
                }, maintenanceSupervisorUserRoleElements, maintenanceSupervisor);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    true
                }, maintenanceSupervisorUserRoleElements, maintenanceSupervisor);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool>
                {
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    false,
                    true
                }, maintenanceSupervisorUserRoleElements, maintenanceSupervisor);

            // ****************************** LOGS - DIRECTIVES ******************************
            var rolesForDirectives = new List<Role>
            {
                areaManager,
                operatingChiefEngineer,
                supervisor,
                taDirector,
                taExecutionManager,
                taManager
            };

            // Area Manager
            AssertAuthorizedToEditDirectives(rolesForDirectives, new List<bool> {true, false, true, false, false, false},
                areaManagerUserRoleElements, areaManager);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives,
                new List<bool> {true, false, true, false, false, false}, areaManagerUserRoleElements, areaManager);
            // Operating Engineer
            AssertAuthorizedToEditDirectives(rolesForDirectives,
                new List<bool> {false, true, false, false, false, false}, operatingChiefEngineerUserRoleElements,
                operatingChiefEngineer);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives,
                new List<bool> {false, true, false, false, false, false}, operatingChiefEngineerUserRoleElements,
                operatingChiefEngineer);
            // Supervisor
            AssertAuthorizedToEditDirectives(rolesForDirectives, new List<bool> {true, false, true, false, false, false},
                supervisorUserRoleElements, supervisor);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives,
                new List<bool> {true, false, true, false, false, false}, supervisorUserRoleElements, supervisor);
            // TA Director
            AssertAuthorizedToEditDirectives(rolesForDirectives,
                new List<bool> {false, false, false, false, false, false}, taDirectorUserRoleElements, taDirector);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives,
                new List<bool> {false, false, false, false, false, false}, taDirectorUserRoleElements, taDirector);
            // TA Execution Manager
            AssertAuthorizedToEditDirectives(rolesForDirectives,
                new List<bool> {false, false, false, false, false, false}, taExecutionManagerUserRoleElements,
                taExecutionManager);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives,
                new List<bool> {false, false, false, false, false, false}, taExecutionManagerUserRoleElements,
                taExecutionManager);
            // TA Manager
            AssertAuthorizedToEditDirectives(rolesForDirectives,
                new List<bool> {false, false, false, false, false, false}, taManagerUserRoleElements, taManager);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives,
                new List<bool> {false, false, false, false, false, false}, taManagerUserRoleElements, taManager);
        }

        [Test][Ignore]
        public void VerifySarniaPermissionsForLogsAndDirectivesBasedOnRoleElements()
        {
            var roleElementService = GenericServiceRegistry.Instance.GetService<IRoleElementService>();
            var roleService = GenericServiceRegistry.Instance.GetService<IRoleService>();

            var sarniaRoles = roleService.QueryRolesBySite(SiteFixture.Sarnia());

            var administrator = sarniaRoles.Find(role => role.Name == "Administrator");
            var operationsSupport = sarniaRoles.Find(role => role.Name == "Operations Support");
            var engineeringSupportPlus = sarniaRoles.Find(role => role.Name == "Engineering Support Plus");
            var nonOperationsPermitIssuer = sarniaRoles.Find(role => role.Name == "Non-Operations Permit Issuer");
            var operatingEngineer = sarniaRoles.Find(role => role.Name == "Operating Engineer");
            var operatorz = sarniaRoles.Find(role => role.Name == "Operator");
            var permitScreener = sarniaRoles.Find(role => role.Name == "Permit Requester");
            var readUser = sarniaRoles.Find(role => role.Name == "Read User");
            var supervisor = sarniaRoles.Find(role => role.Name == "Supervisor");
            var supervisorPlus = sarniaRoles.Find(role => role.Name == "Supervisor Plus");


            var roles = new List<Role>
            {
                administrator,
                operationsSupport,
                engineeringSupportPlus,
                nonOperationsPermitIssuer,
                operatingEngineer,
                operatorz,
                permitScreener,
                readUser,
                supervisor,
                supervisorPlus
            };

            var administratorRoleElements = roleElementService.QueryTemplateForRole(administrator);
            var engineeringSupportRoleElements = roleElementService.QueryTemplateForRole(operationsSupport);
            var engineeringSupportPlusRoleElements = roleElementService.QueryTemplateForRole(engineeringSupportPlus);
            var nonOperationsPermitIssuerRoleElements =
                roleElementService.QueryTemplateForRole(nonOperationsPermitIssuer);
            var operatingEngineerRoleElements = roleElementService.QueryTemplateForRole(operatingEngineer);
            var operatorRoleElements = roleElementService.QueryTemplateForRole(operatorz);
            var permitScreenerRoleElements = roleElementService.QueryTemplateForRole(permitScreener);
            var readUserRoleElements = roleElementService.QueryTemplateForRole(readUser);
            var supervisorRoleElements = roleElementService.QueryTemplateForRole(supervisor);
            var supervisorPlusRoleElements = roleElementService.QueryTemplateForRole(supervisorPlus);

            var administratorUserRoleElements = new UserRoleElements(administrator, administratorRoleElements);
            var engineeringSupportUserRoleElements = new UserRoleElements(operationsSupport,
                engineeringSupportRoleElements);
            var engineeringSupportPlusUserRoleElements = new UserRoleElements(engineeringSupportPlus,
                engineeringSupportPlusRoleElements);
            var nonOperationsPermitIssuerUserRoleElements = new UserRoleElements(nonOperationsPermitIssuer,
                nonOperationsPermitIssuerRoleElements);
            var operatingEngineerUserRoleElements = new UserRoleElements(operatingEngineer,
                operatingEngineerRoleElements);
            var operatorUserRoleElements = new UserRoleElements(operatorz, operatorRoleElements);
            var permitScreenerUserRoleElements = new UserRoleElements(permitScreener, permitScreenerRoleElements);
            var readUserUserRoleElements = new UserRoleElements(readUser, readUserRoleElements);
            var supervisorUserRoleElements = new UserRoleElements(supervisor, supervisorRoleElements);
            var supervisorPlusUserRoleElements = new UserRoleElements(supervisorPlus, supervisorPlusRoleElements);

            // ****************************** LOGS *******************************************
            // Administrator
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                administratorUserRoleElements, administrator);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                administratorUserRoleElements, administrator);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                administratorUserRoleElements, administrator);
            // Engineering Support 
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                engineeringSupportUserRoleElements, operationsSupport);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                engineeringSupportUserRoleElements, operationsSupport);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                engineeringSupportUserRoleElements, operationsSupport);
            // Engineering Support Plus
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                engineeringSupportPlusUserRoleElements, engineeringSupportPlus);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                engineeringSupportPlusUserRoleElements, engineeringSupportPlus);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                engineeringSupportPlusUserRoleElements, engineeringSupportPlus);
            // Non Operations Permit Issuer
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                nonOperationsPermitIssuerUserRoleElements, nonOperationsPermitIssuer);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                nonOperationsPermitIssuerUserRoleElements, nonOperationsPermitIssuer);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                nonOperationsPermitIssuerUserRoleElements, nonOperationsPermitIssuer);
            // Operating Engineer
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, false, false, false, true, true, false, false, false, false},
                operatingEngineerUserRoleElements, operatingEngineer);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, false, false, false, true, true, false, false, false, false},
                operatingEngineerUserRoleElements, operatingEngineer);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, true, true, false, false, false, false},
                operatingEngineerUserRoleElements, operatingEngineer);
            // Operator
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, false, false, false, true, true, false, false, false, false},
                operatorUserRoleElements, operatorz);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, false, false, false, true, true, false, false, false, false},
                operatorUserRoleElements, operatorz);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, true, true, false, false, false, false},
                operatorUserRoleElements, operatorz);
            // Permit Screener
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                permitScreenerUserRoleElements, permitScreener);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                permitScreenerUserRoleElements, permitScreener);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                permitScreenerUserRoleElements, permitScreener);
            // Read User
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                readUserUserRoleElements, readUser);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                readUserUserRoleElements, readUser);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, false, false},
                readUserUserRoleElements, readUser);
            // Supervisor
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, true, true},
                supervisorUserRoleElements, supervisor);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, true, true},
                supervisorUserRoleElements, supervisor);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, true, true},
                supervisorUserRoleElements, supervisor);
            // Supervisor Plus
            AssertAuthorizedToEditLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, true, true},
                supervisorPlusUserRoleElements, supervisorPlus);
            AssertAuthorizedToDeleteLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, true, true},
                supervisorPlusUserRoleElements, supervisorPlus);
            AssertAuthorizedToCancelReoccuringLog(roles,
                new List<bool> {false, false, false, false, false, false, false, false, true, true},
                supervisorPlusUserRoleElements, supervisorPlus);

            // ****************************** LOGS - DIRECTIVES ******************************
            var rolesForDirectives = new List<Role> {operatingEngineer, supervisor, supervisorPlus};

            // Operating Engineer
            AssertAuthorizedToEditDirectives(rolesForDirectives, new List<bool> {false, false, false},
                operatingEngineerUserRoleElements, operatingEngineer);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives, new List<bool> {false, false, false},
                operatingEngineerUserRoleElements, operatingEngineer);
            // Supervisor
            AssertAuthorizedToEditDirectives(rolesForDirectives, new List<bool> {false, true, true},
                supervisorUserRoleElements, supervisor);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives, new List<bool> {false, true, true},
                supervisorUserRoleElements, supervisor);
            // Supervisor Plus
            AssertAuthorizedToEditDirectives(rolesForDirectives, new List<bool> {false, true, true},
                supervisorPlusUserRoleElements, supervisorPlus);
            AssertAuthorizedToDeleteDirectives(rolesForDirectives, new List<bool> {false, true, true},
                supervisorPlusUserRoleElements, supervisorPlus);
        }

        private void AssertAuthorizedToEditLog(List<Role> roles, List<bool> expected, UserRoleElements roleElements,
            Role loggedInUsersRole)
        {
            userContext.SetRole(loggedInUsersRole, roleElements, null,
                rolePermissionService.QueryByRoleId(loggedInUsersRole.IdValue));
            userContext.UserShift = userDayShift;
            userContext.User = UserFixture.CreateUserWithGivenId(-1234);

            for (var i = 0; i < roles.Count; i++)
            {
                var role = roles[i];
                var ex = expected[i];
//                Console.Out.WriteLine("[Role]: " + role.ToString() + " [Expected]: " + ex.ToString());
                Assert.AreEqual(ex, authorized.ToEditLog(CreateLogDTOFor(role, userDayShift, false), userContext));
            }
        }

        private void AssertAuthorizedToDeleteLog(List<Role> roles, List<bool> expected, UserRoleElements roleElements,
            Role loggedInUsersRole)
        {
            userContext.SetRole(loggedInUsersRole, roleElements, null,
                rolePermissionService.QueryByRoleId(loggedInUsersRole.IdValue));
            userContext.UserShift = userDayShift;
            userContext.User = UserFixture.CreateUserWithGivenId(-1234);

//            Console.Out.WriteLine("*********************************");
            for (var i = 0; i < roles.Count; i++)
            {
                var role = roles[i];
                var ex = expected[i];
//                Console.Out.WriteLine("[Role]: " + role.ToString() + " [Expected]: " + ex.ToString());
                Assert.AreEqual(ex, authorized.ToDeleteLog(CreateLogDTOFor(role, userDayShift, false), userContext));
            }
        }

        private void AssertAuthorizedToCancelReoccuringLog(List<Role> roles, List<bool> expected,
            UserRoleElements roleElements, Role loggedInUsersRole)
        {
            userContext.SetRole(loggedInUsersRole, roleElements, null,
                rolePermissionService.QueryByRoleId(loggedInUsersRole.IdValue));
            userContext.User = UserFixture.CreateUserWithGivenId(-1234);

//            Console.Out.WriteLine("*********************************");
            for (var i = 0; i < roles.Count; i++)
            {
                var role = roles[i];
                var ex = expected[i];
//                Console.Out.WriteLine("[Role]: " + role.ToString() + " [Expected]: " + ex.ToString());
                Assert.AreEqual(ex,
                    authorized.ToCancelReoccuringLog(CreateLogDTOFor(role, userDayShift, true), userContext));
            }
        }

        private void AssertAuthorizedToEditDirectives(List<Role> roles, List<bool> expected,
            UserRoleElements roleElements, Role loggedInUsersRole)
        {
            userContext.SetRole(loggedInUsersRole, roleElements, null,
                rolePermissionService.QueryByRoleId(loggedInUsersRole.IdValue));
            userContext.UserShift = userDayShift;
            userContext.User = UserFixture.CreateUserWithGivenId(-1234);

//            Console.Out.WriteLine("*********************************");
            for (var i = 0; i < roles.Count; i++)
            {
                var role = roles[i];
                var ex = expected[i];
//                Console.Out.WriteLine("[Role]: " + role.ToString() + " [Expected]: " + ex.ToString());
                Assert.AreEqual(ex,
                    authorized.ToEditDirectiveLogs(CreateLogDTOFor(role, userDayShift, false), userContext));
            }
        }

        private void AssertAuthorizedToEditNewDirectives(List<Role> roles, List<bool> expected,
            UserRoleElements roleElements, Role loggedInUsersRole)
        {
            userContext.SetRole(loggedInUsersRole, roleElements, null,
                rolePermissionService.QueryByRoleId(loggedInUsersRole.IdValue));
            userContext.UserShift = userDayShift;
            userContext.User = UserFixture.CreateUserWithGivenId(-1234);

            //            Console.Out.WriteLine("*********************************");
            for (var i = 0; i < roles.Count; i++)
            {
                var role = roles[i];
                var ex = expected[i];
                //                Console.Out.WriteLine("[Role]: " + role.ToString() + " [Expected]: " + ex.ToString());
                Assert.AreEqual(ex,
                    authorized.ToEditDirective(CreateDirectiveDTOFor(role, userDayShift), userContext, DateTime.Now));
            }
        }

        private void AssertAuthorizedToDeleteDirectives(List<Role> roles, List<bool> expected,
            UserRoleElements roleElements, Role loggedInUsersRole)
        {
            userContext.SetRole(loggedInUsersRole, roleElements, null,
                rolePermissionService.QueryByRoleId(loggedInUsersRole.IdValue));
            userContext.UserShift = userDayShift;
            userContext.User = UserFixture.CreateUserWithGivenId(-1234);

            for (var i = 0; i < roles.Count; i++)
            {
                var role = roles[i];
                var ex = expected[i];
                //                Console.Out.WriteLine("[Role]: " + role.ToString() + " [Expected]: " + ex.ToString());
                Assert.AreEqual(ex,
                    authorized.ToDeleteDirectiveLogs(new List<LogDTO> {CreateLogDTOFor(role, userDayShift, false)},
                        userContext));
            }
        }

        private void AssertAuthorizedToDeleteNewDirectives(List<Role> roles, List<bool> expected,
            UserRoleElements roleElements, Role loggedInUsersRole)
        {
            userContext.SetRole(loggedInUsersRole, roleElements, null,
                rolePermissionService.QueryByRoleId(loggedInUsersRole.IdValue));
            userContext.UserShift = userDayShift;
            userContext.User = UserFixture.CreateUserWithGivenId(-1234);

            for (var i = 0; i < roles.Count; i++)
            {
                var role = roles[i];
                var ex = expected[i];
                //                Console.Out.WriteLine("[Role]: " + role.ToString() + " [Expected]: " + ex.ToString());
                Assert.AreEqual(ex,
                    authorized.ToDeleteDirectives(new List<DirectiveDTO> { CreateDirectiveDTOFor(role, userDayShift) }, userContext, userDayShift.StartDateTime));
            }
        }

        private LogDTO CreateLogDTOFor(Role role, UserShift userShift, bool isRecurring)
        {
            return new LogDTO(1, null, null, "ABC-DEF-GHI",
                false, false, false, false, false, false, userShift.StartDateTime.AddMinutes(5), -10, "a", "b", "c",
                "Fred",
                userShift.StartDateTime.AddMinutes(5), userShift.StartDateTime.AddMinutes(5),
                1, userShift.StartDate, new Time(userShift.StartDateTime), userShift.EndDate,
                new Time(userShift.EndDateTime), "12D",
                false, isRecurring, DataSource.MANUAL.IdValue,
                false, role.IdValue, null, false, false, null, "all comments", null, null);
        }

        private DirectiveDTO CreateDirectiveDTOFor(Role role, UserShift userShift)
        {
            return new DirectiveDTO(1, null, null, userShift.StartDateTime.AddMinutes(5),               
                userShift.StartDateTime.AddDays(1), -99, -99, DateTime.Now, -99, "Foo", "Fred", "Fred", "Fred","Created By WA Name");
        }

    }
}