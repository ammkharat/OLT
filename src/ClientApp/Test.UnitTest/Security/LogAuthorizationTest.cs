using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;
using CommonConstants = Com.Suncor.Olt.Common.Utility.Constants;
using UserFixture = Com.Suncor.Olt.Common.Fixtures.UserFixture;

namespace Com.Suncor.Olt.Client.Security
{
    [TestFixture]
    public class LogAuthorizationTest
    {
        private const long LOG_USER_ID = 123;
        private const long OTHER_USER_ID = 456;

        private ShiftPattern dayShiftPattern;
        private ShiftPattern nightShiftPattern;
        private UserShift userDayShift;
        private UserShift userNightShift;

        private IAuthorized authorized;

        private LogDTO operatorLogDayShift;
        private LogDTO operatorLogNightShift;
        private LogDTO supervisorLogDayShift;
        private LogDTO operatorLogDayShiftFlaggedAsOperatingEngineerLog;
        private LogDTO operatorLogDayShiftHasChildren;
        private LogDTO operatorLogDayShiftRecurring;
        private LogDTO supervisorLogDayShiftRecurring;
        private LogDTO operatorLogDayShiftRecurringDefinitionDeleted;
        private LogDTO operatorLogDayShiftRecurringFlaggedAsOperatingEngineerLog;

        private LogDefinitionDTO operatorLogDefinition;
        private LogDefinitionDTO supervisorLogDefinition;
        private LogDefinitionDTO operatorLogDefinitionFlaggedAsOperatingEngineerLog;

        private SummaryLogDTO operatorSummaryLogDayShift;
        private SummaryLogDTO operatorSummaryLogNightShift;
        private SummaryLogDTO supervisorSummaryLogDayShift;

        [SetUp]
        public void Setup()
        {
            Clock.Freeze();

            authorized = new Authorized();

            Date today = new Date(2011, 5, 13);
            dayShiftPattern = ShiftPatternFixture.CreateDayShift();
            nightShiftPattern = ShiftPatternFixture.CreateNightShift();

            userDayShift = new UserShift(dayShiftPattern, today);
            userNightShift = new UserShift(nightShiftPattern, today);

            DateTime dayShiftLogDateTime = userDayShift.StartDateTimeWithPadding.AddMinutes(5);
            DateTime nightShiftNextDayLogDateTime = userNightShift.EndDateTimeWithPadding.AddMinutes(-5);

            operatorLogDayShift = CreateLogDTO(RoleFixture.CreateOperatorRole(), userDayShift, dayShiftLogDateTime, false, false, false, null);
            operatorLogNightShift = CreateLogDTO(RoleFixture.CreateOperatorRole(), userNightShift, nightShiftNextDayLogDateTime, false, false, false, null);
            supervisorLogDayShift = CreateLogDTO(RoleFixture.CreateSupervisorRole(), userDayShift, dayShiftLogDateTime, false, false, false, null);
            operatorLogDayShiftFlaggedAsOperatingEngineerLog = CreateLogDTO(RoleFixture.CreateOperatorRole(), userDayShift, dayShiftLogDateTime, true, false, false, null);
            operatorLogDayShiftHasChildren = CreateLogDTO(RoleFixture.CreateOperatorRole(), userDayShift, dayShiftLogDateTime, false, true, false, null);

            operatorLogDayShiftRecurring = CreateLogDTO(RoleFixture.CreateOperatorRole(), userDayShift, dayShiftLogDateTime, false, false, true, null);
            supervisorLogDayShiftRecurring = CreateLogDTO(RoleFixture.CreateSupervisorRole(), userDayShift, dayShiftLogDateTime, false, false, true, null);
            operatorLogDayShiftRecurringDefinitionDeleted = CreateLogDTO(RoleFixture.CreateOperatorRole(), userDayShift, dayShiftLogDateTime, false, false, true, true);
            operatorLogDayShiftRecurringFlaggedAsOperatingEngineerLog = CreateLogDTO(RoleFixture.CreateOperatorRole(), userDayShift, dayShiftLogDateTime, true, false, true, null);

            operatorLogDefinition = CreateLogDefinitionDTO(RoleFixture.CreateOperatorRole(), false);
            supervisorLogDefinition = CreateLogDefinitionDTO(RoleFixture.CreateSupervisorRole(), false);
            operatorLogDefinitionFlaggedAsOperatingEngineerLog = CreateLogDefinitionDTO(RoleFixture.CreateOperatorRole(), true);

            operatorSummaryLogDayShift = CreateSummaryLogDTO(dayShiftLogDateTime, dayShiftPattern, RoleFixture.CreateOperatorRole());
            operatorSummaryLogNightShift = CreateSummaryLogDTO(nightShiftNextDayLogDateTime, nightShiftPattern, RoleFixture.CreateOperatorRole());
            supervisorSummaryLogDayShift = CreateSummaryLogDTO(dayShiftLogDateTime, dayShiftPattern, RoleFixture.CreateSupervisorRole());
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        private static LogDTO CreateLogDTO(
            Role role, UserShift shift, DateTime loggedDateTime, bool isOperatingEngineerLog, bool hasChildren, bool isRecurring, bool? definitionDeleted)
        {
            return new LogDTO(1, null, null, "A-B-C", false, false, false, false, false, false,
                loggedDateTime, LOG_USER_ID, null, null, null, null, loggedDateTime, loggedDateTime,
                shift.ShiftPatternId, shift.StartDate, new Time(shift.StartDateTime), shift.EndDate, new Time(shift.EndDateTime), shift.ShiftPatternName,
                hasChildren, isRecurring, 0, isOperatingEngineerLog, role.IdValue, null, definitionDeleted, false, null, null, null, null);
        }

        private static LogDefinitionDTO CreateLogDefinitionDTO(Role role, bool isOperatingEngineerLog)
        {
            return new LogDefinitionDTO(1, null, null, null, 
                RecurringDailyScheduleFixture.CreateEvery1DaysFrom5PMTo6PMWithyNoEndDateStarting2006June15(),
                new List<string>(), new DateTime(2001, 2, 3), 
                isOperatingEngineerLog, role.IdValue, LOG_USER_ID, LogType.Standard, true, null);
        }

        private static SummaryLogDTO CreateSummaryLogDTO(DateTime loggedDateTime, ShiftPattern shift)
        {
            return CreateSummaryLogDTO(loggedDateTime, shift, RoleFixture.CreateOperatorRole());
        }

        private static SummaryLogDTO CreateSummaryLogDTO(DateTime loggedDateTime, ShiftPattern shift, Role role)
        {
            return new SummaryLogDTO(
                100, DataSource.MANUAL, null,
                false, false, false, false, false, false,
                loggedDateTime, loggedDateTime, LOG_USER_ID, role.IdValue, null, null,
                shift.IdValue, new Date(loggedDateTime), new Time(loggedDateTime), null, null,
                null, null, "comment", null, null, false, null);
        }

        private static UserContext GetUserContext(RoleElement rolePermissionRoleElement, Role role, UserShift shift, bool hasRolePermission, long userid, RoleElement[] roleElements)
        {
            List<RolePermission> rolePermissions = new List<RolePermission>();
            if (hasRolePermission)
            {
                rolePermissions.Add(new RolePermission(role.IdValue, rolePermissionRoleElement.IdValue, role.IdValue));
            }

            UserRoleElements userRoleElements = new UserRoleElements(role, new List<RoleElement>(roleElements));

            UserContext userContext = new UserContext(null);
            userContext.SetRole(role, userRoleElements, null, rolePermissions);
            userContext.UserShift = shift;
            userContext.User = UserFixture.CreateUserWithGivenId(userid);
            return userContext;
        }

        [Test][Ignore]
        public void Log_ShouldAuthorizeToEdit()
        {
            RoleElement roleElement = RoleElement.EDIT_LOG;

            AssertToEditLog(false, operatorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID);

            AssertToEditLog(true, operatorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditLog(false, supervisorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditLog(true, supervisorLogDayShift, userDayShift, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditLog(false, operatorLogDayShift, userDayShift, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);

            AssertToEditLog(false, operatorLogDayShift, userNightShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditLog(false, operatorLogNightShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);

            AssertToEditLog(true, operatorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement);
            AssertToEditLog(false, operatorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement);

            AssertToEditLog(false, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditLog(false, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateOperatorRole(), true, LOG_USER_ID, roleElement);
            AssertToEditLog(false, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement);
            AssertToEditLog(false, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement);
            AssertToEditLog(true, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement, RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToEditLog(true, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateOperatorRole(), true, LOG_USER_ID, roleElement, RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToEditLog(true, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement, RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToEditLog(true, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement, RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);

            AssertToEditLog(false, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditLog(false, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateSupervisorRole(), true, LOG_USER_ID, roleElement);
            AssertToEditLog(false, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateSupervisorRole(), false, OTHER_USER_ID, roleElement);
            AssertToEditLog(false, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateSupervisorRole(), false, LOG_USER_ID, roleElement);
            AssertToEditLog(true, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement, RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToEditLog(true, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateSupervisorRole(), true, LOG_USER_ID, roleElement, RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToEditLog(true, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateSupervisorRole(), false, OTHER_USER_ID, roleElement, RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToEditLog(true, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateSupervisorRole(), false, LOG_USER_ID, roleElement, RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);

            AssertToEditLog(false, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userNightShift, RoleFixture.CreateSupervisorRole(), false, OTHER_USER_ID, roleElement, RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
        }

        private void AssertToEditLog(bool expected, LogDTO dto, UserShift shift, Role role, bool hasRolePermission, long userid, params RoleElement[] roleElements)
        {
            UserContext userContext = GetUserContext(RoleElement.EDIT_LOG, role, shift, hasRolePermission, userid, roleElements);
            bool actual = authorized.ToEditLog(dto, userContext);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Log_ShouldAuthorizeToDelete()
        {
            RoleElement roleElement = RoleElement.DELETE_LOG;

            AssertToDeleteLog(false, operatorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID);

            AssertToDeleteLog(true, operatorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToDeleteLog(false, supervisorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToDeleteLog(true, supervisorLogDayShift, userDayShift, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);
            AssertToDeleteLog(false, operatorLogDayShift, userDayShift, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);

            AssertToDeleteLog(false, operatorLogDayShift, userNightShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToDeleteLog(false, operatorLogNightShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);

            AssertToDeleteLog(false, operatorLogDayShiftHasChildren, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);

            AssertToDeleteLog(true, operatorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement);
            AssertToDeleteLog(false, operatorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement);

            AssertToDeleteLog(false, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToDeleteLog(false, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateOperatorRole(), true, LOG_USER_ID, roleElement);
            AssertToDeleteLog(false, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement);
            AssertToDeleteLog(false, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement);
            AssertToDeleteLog(true, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement, RoleElement.DELETE_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToDeleteLog(true, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateOperatorRole(), true, LOG_USER_ID, roleElement, RoleElement.DELETE_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToDeleteLog(true, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement, RoleElement.DELETE_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToDeleteLog(true, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement, RoleElement.DELETE_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);

            AssertToDeleteLog(false, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);
            AssertToDeleteLog(false, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateSupervisorRole(), true, LOG_USER_ID, roleElement);
            AssertToDeleteLog(false, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateSupervisorRole(), false, OTHER_USER_ID, roleElement);
            AssertToDeleteLog(false, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateSupervisorRole(), false, LOG_USER_ID, roleElement);
            AssertToDeleteLog(true, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement, RoleElement.DELETE_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToDeleteLog(true, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateSupervisorRole(), true, LOG_USER_ID, roleElement, RoleElement.DELETE_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToDeleteLog(true, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateSupervisorRole(), false, OTHER_USER_ID, roleElement, RoleElement.DELETE_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToDeleteLog(true, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userDayShift, RoleFixture.CreateSupervisorRole(), false, LOG_USER_ID, roleElement, RoleElement.DELETE_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);

            AssertToDeleteLog(false, operatorLogDayShiftFlaggedAsOperatingEngineerLog, userNightShift, RoleFixture.CreateSupervisorRole(), false, OTHER_USER_ID, roleElement, RoleElement.DELETE_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
        }

        private void AssertToDeleteLog(bool expected, LogDTO dto, UserShift shift, Role role, bool hasRolePermission, long userid, params RoleElement[] roleElements)
        {
            UserContext userContext = GetUserContext(RoleElement.DELETE_LOG, role, shift, hasRolePermission, userid, roleElements);
            bool actual = authorized.ToDeleteLog(dto, userContext);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Log_ShouldAuthorizeToCancel()
        {
            RoleElement roleElement = RoleElement.CANCEL_LOG;

            AssertToCancelLog(false, operatorLogDayShiftRecurring, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID);
            AssertToCancelLog(false, operatorLogDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);

            AssertToCancelLog(true, operatorLogDayShiftRecurring, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToCancelLog(false, supervisorLogDayShiftRecurring, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToCancelLog(true, supervisorLogDayShiftRecurring, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);
            AssertToCancelLog(false, operatorLogDayShiftRecurring, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);

            AssertToCancelLog(false, operatorLogDayShiftRecurringDefinitionDeleted, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);

            AssertToCancelLog(true, operatorLogDayShiftRecurring, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement);
            AssertToCancelLog(false, operatorLogDayShiftRecurring, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement);

            AssertToCancelLog(false, operatorLogDayShiftRecurringFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToCancelLog(false, operatorLogDayShiftRecurringFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), true, LOG_USER_ID, roleElement);
            AssertToCancelLog(false, operatorLogDayShiftRecurringFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement);
            AssertToCancelLog(false, operatorLogDayShiftRecurringFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement);
            AssertToCancelLog(true, operatorLogDayShiftRecurringFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement, RoleElement.CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToCancelLog(true, operatorLogDayShiftRecurringFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), true, LOG_USER_ID, roleElement, RoleElement.CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToCancelLog(true, operatorLogDayShiftRecurringFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement, RoleElement.CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToCancelLog(true, operatorLogDayShiftRecurringFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement, RoleElement.CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);

            AssertToCancelLog(false, operatorLogDayShiftRecurringFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);
            AssertToCancelLog(false, operatorLogDayShiftRecurringFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), true, LOG_USER_ID, roleElement);
            AssertToCancelLog(false, operatorLogDayShiftRecurringFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), false, OTHER_USER_ID, roleElement);
            AssertToCancelLog(false, operatorLogDayShiftRecurringFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), false, LOG_USER_ID, roleElement);
            AssertToCancelLog(true, operatorLogDayShiftRecurringFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement, RoleElement.CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToCancelLog(true, operatorLogDayShiftRecurringFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), true, LOG_USER_ID, roleElement, RoleElement.CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToCancelLog(true, operatorLogDayShiftRecurringFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), false, OTHER_USER_ID, roleElement, RoleElement.CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToCancelLog(true, operatorLogDayShiftRecurringFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), false, LOG_USER_ID, roleElement, RoleElement.CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
        }

        private void AssertToCancelLog(bool expected, LogDTO dto, Role role, bool hasRolePermission, long userid, params RoleElement[] roleElements)
        {
            UserContext userContext = GetUserContext(RoleElement.CANCEL_LOG, role, null, hasRolePermission, userid, roleElements);
            bool actual = authorized.ToCancelReoccuringLog(dto, userContext);
            Assert.AreEqual(expected, actual);
        }

        [Test][Ignore]
        public void Directive_ShouldAuthorizeToEdit()
        {
            RoleElement roleElement = RoleElement.EDIT_LOG_BASED_DIRECTIVES;

            AssertToEditDirective(false, operatorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID);

            AssertToEditDirective(true, operatorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditDirective(false, supervisorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditDirective(true, supervisorLogDayShift, userDayShift, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditDirective(false, operatorLogDayShift, userDayShift, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);

            AssertToEditDirective(false, operatorLogDayShift, userNightShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditDirective(false, operatorLogNightShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);

            AssertToEditDirective(true, operatorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement);
            AssertToEditDirective(false, operatorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement);
        }

        private void AssertToEditDirective(bool expected, LogDTO dto, UserShift shift, Role role, bool hasRolePermission, long userid, params RoleElement[] roleElements)
        {
            UserContext userContext = GetUserContext(RoleElement.EDIT_LOG_BASED_DIRECTIVES, role, shift, hasRolePermission, userid, roleElements);
            bool actual = authorized.ToEditDirectiveLogs(dto, userContext);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Directive_ShouldAuthorizeToDelete()
        {
            RoleElement roleElement = RoleElement.DELETE_LOG_BASED_DIRECTIVES;

            AssertToDeleteDirective(false, operatorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID);

            AssertToDeleteDirective(true, operatorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToDeleteDirective(false, supervisorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToDeleteDirective(true, supervisorLogDayShift, userDayShift, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);
            AssertToDeleteDirective(false, operatorLogDayShift, userDayShift, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);

            AssertToDeleteDirective(false, operatorLogDayShift, userNightShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToDeleteDirective(false, operatorLogNightShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);

            AssertToDeleteDirective(false, operatorLogDayShiftHasChildren, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);

            AssertToDeleteDirective(true, operatorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement);
            AssertToDeleteDirective(false, operatorLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement);
        }

        private void AssertToDeleteDirective(bool expected, LogDTO dto, UserShift shift, Role role, bool hasRolePermission, long userid, params RoleElement[] roleElements)
        {
            UserContext userContext = GetUserContext(RoleElement.DELETE_LOG_BASED_DIRECTIVES, role, shift, hasRolePermission, userid, roleElements);
            bool actual = authorized.ToDeleteDirectiveLogs(new List<LogDTO>{dto}, userContext);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LogDefinition_ShouldAuthorizeToEdit()
        {
            RoleElement roleElement = RoleElement.EDIT_LOG_DEFINITION;

            AssertToEditLogDefinition(false, operatorLogDefinition, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID);

            AssertToEditLogDefinition(true, operatorLogDefinition, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditLogDefinition(false, supervisorLogDefinition, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditLogDefinition(true, supervisorLogDefinition, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditLogDefinition(false, operatorLogDefinition, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);

            AssertToEditLogDefinition(true, operatorLogDefinition, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement);
            AssertToEditLogDefinition(false, operatorLogDefinition, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement);

            AssertToEditLogDefinition(false, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditLogDefinition(false, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), true, LOG_USER_ID, roleElement);
            AssertToEditLogDefinition(false, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement);
            AssertToEditLogDefinition(false, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement);
            AssertToEditLogDefinition(true, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement, RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToEditLogDefinition(true, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), true, LOG_USER_ID, roleElement, RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToEditLogDefinition(true, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement, RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToEditLogDefinition(true, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement, RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);

            AssertToEditLogDefinition(false, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditLogDefinition(false, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), true, LOG_USER_ID, roleElement);
            AssertToEditLogDefinition(false, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), false, OTHER_USER_ID, roleElement);
            AssertToEditLogDefinition(false, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), false, LOG_USER_ID, roleElement);
            AssertToEditLogDefinition(true, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement, RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToEditLogDefinition(true, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), true, LOG_USER_ID, roleElement, RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToEditLogDefinition(true, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), false, OTHER_USER_ID, roleElement, RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToEditLogDefinition(true, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), false, LOG_USER_ID, roleElement, RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
        }

        private void AssertToEditLogDefinition(bool expected, LogDefinitionDTO dto, Role role, bool hasRolePermission, long userid, params RoleElement[] roleElements)
        {
            UserContext userContext = GetUserContext(RoleElement.EDIT_LOG_DEFINITION, role, null, hasRolePermission, userid, roleElements);
            bool actual = authorized.ToEditLogDefinition(dto, userContext);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LogDefinition_ShouldAuthorizeToCancel()
        {
            RoleElement roleElement = RoleElement.CANCEL_LOG;

            AssertToCancelLogDefinition(false, operatorLogDefinition, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID);

            AssertToCancelLogDefinition(true, operatorLogDefinition, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToCancelLogDefinition(false, supervisorLogDefinition, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToCancelLogDefinition(true, supervisorLogDefinition, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);
            AssertToCancelLogDefinition(false, operatorLogDefinition, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);

            AssertToCancelLogDefinition(true, operatorLogDefinition, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement);
            AssertToCancelLogDefinition(false, operatorLogDefinition, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement);

            AssertToCancelLogDefinition(false, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToCancelLogDefinition(false, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), true, LOG_USER_ID, roleElement);
            AssertToCancelLogDefinition(false, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement);
            AssertToCancelLogDefinition(false, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement);
            AssertToCancelLogDefinition(true, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement, RoleElement.CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToCancelLogDefinition(true, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), true, LOG_USER_ID, roleElement, RoleElement.CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToCancelLogDefinition(true, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement, RoleElement.CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToCancelLogDefinition(true, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement, RoleElement.CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);

            AssertToCancelLogDefinition(false, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);
            AssertToCancelLogDefinition(false, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), true, LOG_USER_ID, roleElement);
            AssertToCancelLogDefinition(false, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), false, OTHER_USER_ID, roleElement);
            AssertToCancelLogDefinition(false, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), false, LOG_USER_ID, roleElement);
            AssertToCancelLogDefinition(true, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement, RoleElement.CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToCancelLogDefinition(true, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), true, LOG_USER_ID, roleElement, RoleElement.CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToCancelLogDefinition(true, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), false, OTHER_USER_ID, roleElement, RoleElement.CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
            AssertToCancelLogDefinition(true, operatorLogDefinitionFlaggedAsOperatingEngineerLog, RoleFixture.CreateSupervisorRole(), false, LOG_USER_ID, roleElement, RoleElement.CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
        }

        private void AssertToCancelLogDefinition(bool expected, LogDefinitionDTO dto, Role role, bool hasRolePermission, long userid, params RoleElement[] roleElements)
        {
            UserContext userContext = GetUserContext(RoleElement.CANCEL_LOG, role, null, hasRolePermission, userid, roleElements);
            bool actual = authorized.ToCancelLogDefinitions(new List<LogDefinitionDTO>{dto}, userContext);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void StandingOrder_ShouldAuthorizeToEdit()
        {
            RoleElement roleElement = RoleElement.EDIT_LOG_BASED_DIRECTIVES;

            AssertToEditStandingOrder(false, operatorLogDefinition, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID);

            AssertToEditStandingOrder(true, operatorLogDefinition, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditStandingOrder(false, supervisorLogDefinition, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditStandingOrder(true, supervisorLogDefinition, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditStandingOrder(false, operatorLogDefinition, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);

            AssertToEditStandingOrder(true, operatorLogDefinition, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement);
            AssertToEditStandingOrder(false, operatorLogDefinition, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement);
        }

        private void AssertToEditStandingOrder(bool expected, LogDefinitionDTO dto, Role role, bool hasRolePermission, long userid, params RoleElement[] roleElements)
        {
            UserContext userContext = GetUserContext(RoleElement.EDIT_LOG_BASED_DIRECTIVES, role, null, hasRolePermission, userid, roleElements);
            bool actual = authorized.ToEditStandingOrders(dto, userContext);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void StandingOrder_ShouldAuthorizeToCancel()
        {
            RoleElement roleElement = RoleElement.CANCEL_STANDING_ORDERS;

            AssertToCancelStandingOrder(false, operatorLogDefinition, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID);

            AssertToCancelStandingOrder(true, operatorLogDefinition, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToCancelStandingOrder(false, supervisorLogDefinition, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToCancelStandingOrder(true, supervisorLogDefinition, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);
            AssertToCancelStandingOrder(false, operatorLogDefinition, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);

            AssertToCancelStandingOrder(true, operatorLogDefinition, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement);
            AssertToCancelStandingOrder(false, operatorLogDefinition, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement);
        }

        private void AssertToCancelStandingOrder(bool expected, LogDefinitionDTO dto, Role role, bool hasRolePermission, long userid, params RoleElement[] roleElements)
        {
            UserContext userContext = GetUserContext(RoleElement.CANCEL_STANDING_ORDERS, role, null, hasRolePermission, userid, roleElements);
            bool actual = authorized.ToCancelStandingOrders(new List<LogDefinitionDTO> { dto }, userContext);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldAuthorizeToMarkAsRead()
        {
            const int someOtherUserId = 1000000;

            AssertToMarkAsRead(true, operatorLogDayShift, UserFixture.CreateUserWithGivenId(someOtherUserId), operatorLogDayShift.LogDateTime.AddDays(2));
            AssertToMarkAsRead(false, operatorLogDayShift, UserFixture.CreateUserWithGivenId(operatorLogDayShift.CreatedByUserId), operatorLogDayShift.LogDateTime.AddDays(2));
            AssertToMarkAsRead(true, operatorLogDayShift, UserFixture.CreateUserWithGivenId(someOtherUserId), userDayShift.StartDateTime.AddMinutes(5));
            AssertToMarkAsRead(false, operatorLogDayShift, UserFixture.CreateUserWithGivenId(operatorLogDayShift.CreatedByUserId), userDayShift.StartDateTime.AddMinutes(5));            
        }

        private void AssertToMarkAsRead(bool expected, LogDTO dto, User user, DateTime now)
        {
            Clock.Now = now;
            bool actual = authorized.ToMarkLogsAsRead(user, dto);
            Assert.AreEqual(expected, actual);
        }

        [Test][Ignore]
        public void SummaryLog_ShouldAuthorizeToEdit()
        {
            RoleElement roleElement = RoleElement.EDIT_SUMMARY_LOG;

            AssertToEditSummaryLog(false, operatorSummaryLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID);

            AssertToEditSummaryLog(true, operatorSummaryLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditSummaryLog(false, supervisorSummaryLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditSummaryLog(true, supervisorSummaryLogDayShift, userDayShift, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditSummaryLog(false, operatorSummaryLogDayShift, userDayShift, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);

            AssertToEditSummaryLog(false, operatorSummaryLogDayShift, userNightShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToEditSummaryLog(false, operatorSummaryLogNightShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);

            AssertToEditSummaryLog(true, operatorSummaryLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement);
            AssertToEditSummaryLog(false, operatorSummaryLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement);
        }

        private void AssertToEditSummaryLog(bool expected, SummaryLogDTO dto, UserShift shift, Role role, bool hasRolePermission, long userid, params RoleElement[] roleElements)
        {
            UserContext userContext = GetUserContext(RoleElement.EDIT_SUMMARY_LOG, role, shift, hasRolePermission, userid, roleElements);
            bool actual = authorized.ToEditSummaryLog(dto, userContext);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SummaryLog_ShouldAuthorizeToDelete()
        {
            RoleElement roleElement = RoleElement.DELETE_SUMMARY_LOG;

            AssertToDeleteSummaryLog(false, operatorSummaryLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID);

            AssertToDeleteSummaryLog(true, operatorSummaryLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToDeleteSummaryLog(false, supervisorSummaryLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToDeleteSummaryLog(true, supervisorSummaryLogDayShift, userDayShift, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);
            AssertToDeleteSummaryLog(false, operatorSummaryLogDayShift, userDayShift, RoleFixture.CreateSupervisorRole(), true, OTHER_USER_ID, roleElement);

            AssertToDeleteSummaryLog(false, operatorSummaryLogDayShift, userNightShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);
            AssertToDeleteSummaryLog(false, operatorSummaryLogNightShift, userDayShift, RoleFixture.CreateOperatorRole(), true, OTHER_USER_ID, roleElement);

            AssertToDeleteSummaryLog(true, operatorSummaryLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), false, LOG_USER_ID, roleElement);
            AssertToDeleteSummaryLog(false, operatorSummaryLogDayShift, userDayShift, RoleFixture.CreateOperatorRole(), false, OTHER_USER_ID, roleElement);
        }

        private void AssertToDeleteSummaryLog(bool expected, SummaryLogDTO dto, UserShift shift, Role role, bool hasRolePermission, long userid, params RoleElement[] roleElements)
        {
            UserContext userContext = GetUserContext(RoleElement.DELETE_SUMMARY_LOG, role, shift, hasRolePermission, userid, roleElements);
            bool actual = authorized.ToDeleteSummaryLogs(new List<SummaryLogDTO>{dto}, userContext);
            Assert.AreEqual(expected, actual);
        }

        [Test][Ignore]
        public void SummaryLog_ShouldAuthorizeToEditDORComment()
        {
            ShiftPattern dayShift = ShiftPatternFixture.CreateShiftPattern(new Time(8), new Time(20), 1);
            ShiftPattern nightShift = ShiftPatternFixture.CreateShiftPattern(new Time(20), new Time(8), 2);

            List<SummaryLogDTO> logs = new List<SummaryLogDTO>
                                           {
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 19, 7, 30, 0), dayShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 19, 7, 30, 1), dayShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 19, 8, 0, 0), dayShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 19, 12, 0, 0), dayShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 19, 20, 0, 0), dayShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 19, 20, 29, 59), dayShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 19, 19, 30, 0), nightShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 19, 19, 30, 1), nightShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 19, 20, 0, 0), nightShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 19, 23, 0, 0), nightShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 20, 8, 0, 0), nightShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 20, 8, 29, 59), nightShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 20, 7, 30, 0), dayShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 20, 7, 30, 1), dayShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 20, 8, 0, 0), dayShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 20, 12, 0, 0), dayShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 20, 20, 0, 0), dayShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 20, 20, 29, 59), dayShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 20, 19, 30, 0), nightShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 20, 19, 30, 1), nightShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 20, 20, 0, 0), nightShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 20, 23, 0, 0), nightShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 21, 8, 0, 0), nightShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 21, 8, 29, 59), nightShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 21, 7, 30, 0), dayShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 21, 7, 30, 1), dayShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 21, 8, 0, 0), dayShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 21, 12, 0, 0), dayShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 21, 20, 0, 0), dayShift),
                                               CreateSummaryLogDTO(new DateTime(2001, 3, 21, 20, 29, 59), dayShift)
                                           };

            AssertAllowedToEditDORComments(new DateTime(2001, 3, 19, 7, 30, 0), dayShift, logs, 0, 5);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 19, 7, 30, 1), dayShift, logs, 0, 5);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 19, 8, 0, 0), dayShift, logs, 0, 5);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 19, 9, 59, 59), dayShift, logs, 0, 5);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 19, 10, 0, 0), dayShift, logs, 1, 5);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 19, 10, 0, 1), dayShift, logs, 1, 5);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 19, 12, 0, 0), dayShift, logs, 1, 5);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 19, 20, 0, 0), dayShift, logs, 1, 5);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 19, 20, 29, 59), dayShift, logs, 1, 5);

            AssertAllowedToEditDORComments(new DateTime(2001, 3, 19, 19, 30, 0), nightShift, logs, 0, 11);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 19, 19, 30, 1), nightShift, logs, 0, 11);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 19, 20, 0, 0), nightShift, logs, 0, 11);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 19, 23, 0, 0), nightShift, logs, 0, 11);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 20, 8, 0, 0), nightShift, logs, 0, 11);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 20, 8, 29, 59), nightShift, logs, 0, 11);

            AssertAllowedToEditDORComments(new DateTime(2001, 3, 20, 7, 30, 0), dayShift, logs, 0, 17);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 20, 7, 30, 1), dayShift, logs, 0, 17);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 20, 8, 0, 0), dayShift, logs, 0, 17);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 20, 9, 59, 59), dayShift, logs, 0, 17);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 20, 10, 0, 0), dayShift, logs, 13, 17);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 20, 10, 0, 1), dayShift, logs, 13, 17);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 20, 12, 0, 0), dayShift, logs, 13, 17);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 20, 20, 0, 0), dayShift, logs, 13, 17);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 20, 20, 29, 59), dayShift, logs, 13, 17);

            AssertAllowedToEditDORComments(new DateTime(2001, 3, 20, 19, 30, 0), nightShift, logs, 4, 23);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 20, 19, 30, 1), nightShift, logs, 4, 23);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 20, 20, 0, 0), nightShift, logs, 4, 23);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 20, 23, 0, 0), nightShift, logs, 4, 23);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 21, 8, 0, 0), nightShift, logs, 4, 23);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 21, 8, 29, 59), nightShift, logs, 4, 23);

            AssertAllowedToEditDORComments(new DateTime(2001, 3, 21, 7, 30, 0), dayShift, logs, 10, 29);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 21, 7, 30, 1), dayShift, logs, 10, 29);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 21, 8, 0, 0), dayShift, logs, 10, 29);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 21, 9, 59, 59), dayShift, logs, 10, 29);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 21, 10, 0, 0), dayShift, logs, 25, 29);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 21, 10, 0, 1), dayShift, logs, 25, 29);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 21, 12, 0, 0), dayShift, logs, 25, 29);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 21, 20, 0, 0), dayShift, logs, 25, 29);
            AssertAllowedToEditDORComments(new DateTime(2001, 3, 21, 20, 29, 59), dayShift, logs, 25, 29);
        }

        private static void AssertAllowedToEditDORComments(
            DateTime now, ShiftPattern shift, List<SummaryLogDTO> logs, int authorizedFromIndex, int authorizedToIndex)
        {
            Clock.Freeze();
            Clock.Now = now;
            Time cutoffHour = new Time(10);

            Authorized authorized = new Authorized();
            for (int i = 0; i < logs.Count; i++)
            {
                SummaryLogDTO log = logs[i];
                string message = "For log " + i + " at " + log.LogDateTime + " on " + log.Shift;

                bool expectIsAuthorized = i >= authorizedFromIndex && i <= authorizedToIndex;
                Assert.AreEqual(
                    expectIsAuthorized,
                    authorized.ToEditDORComments(
                        new UserRoleElements(null, new List<RoleElement> { RoleElement.EDIT_DOR_COMMENTS }),
                        new UserShift(shift, now), 
                        log, 
                        cutoffHour),
                    message);
            }
        }

    }

}
