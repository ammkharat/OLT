using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class LogFixture
    {
        public static Log CreateLogFromActionItem(ActionItem actionItem, string logComments, Role createdUserRole, 
            ShiftPattern shift, DateTime createAndModifiedDateTime)
        {
            Log log = new Log(null,
                              null,
                              null,
                              DataSource.ACTION_ITEM,
                              actionItem.FunctionalLocations,
                              false,
                              false,
                              false,
                              false,
                              false,
                              false,                              
                              logComments,
                              logComments,
                              createAndModifiedDateTime,
                              shift,
                              actionItem.LastModifiedBy,
                              actionItem.LastModifiedBy,
                              createAndModifiedDateTime,
                              createAndModifiedDateTime,
                              false,
                              false,
                              createdUserRole,
                              LogType.Standard,
                              null);
            return log;
        }

        public static Log CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp()
        {
            return CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp(DateTimeFixture.DateTimeNow);
        }

        public static Log CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp(DateTime now)
        {
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift(now);
            Time loggedTime = shiftPattern.StartTime;
            DateTime loggedDateTime = new Date(2005, 11, 15).CreateDateTime(loggedTime);
            return CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp(shiftPattern, loggedDateTime);
        }

        public static Log CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp(ShiftPattern shiftPattern, DateTime loggedDateTime)
        {
            User user = UserFixture.CreateOperatorOltUser1InFortMcMurrySite();
            Role role = RoleFixture.GetRealRoleA(Site.OILSAND_ID);
            Log newLog = new Log(null,
                                 null,
                                 null,
                                 DataSource.MANUAL,
                                 new List<FunctionalLocation> { FunctionalLocationFixture.GetAny_Unit1() },
                                 true,
                                 false, false, false, false, false,                                 
                                 "Test Comments",                                
                                 "Test Comments",                                
                                 loggedDateTime,
                                 shiftPattern,
                                 user,
                                 user,
                                 loggedDateTime,
                                 loggedDateTime,
                                 false,
                                 false,
                                 role,
                                 LogType.Standard,
                                 null);

            return newLog;
        }

        public static Log CreateIncompleteLogItemMickeySarniaRequiresSupervisionFollowUp()
        {
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();
            Time loggedTime = shiftPattern.StartTime;
            User user = UserFixture.CreateOperatorMickeyInFortMcMurrySite();
            Role role = RoleFixture.CreateOperatorRole();

            Log newLog = new Log(null,
                                 null,
                                 null,
                                 DataSource.MANUAL,
                                 new List<FunctionalLocation> { FunctionalLocationFixture.GetAny_Unit1() },
                                 false,
                                 false,
                                 false,
                                 true,
                                 false,
                                 false,
                                 null,
                                 "",
                                 new DateTime(2005, 12, 1, loggedTime.Hour, loggedTime.Minute + 1, loggedTime.Second),
                                 ShiftPatternFixture.CreateDayShift(),
                                 user,
                                 user,
                                 new DateTime(2005, 12, 1, loggedTime.Hour, loggedTime.Minute + 1, loggedTime.Second),
                                 new DateTime(2005, 12, 1, loggedTime.Hour, loggedTime.Minute + 1, loggedTime.Second),
                                 false,
                                 false,
                                 role,
                                 LogType.Standard,
                                 null);

            //comments not set so object is invalid
            return newLog;
        }

        public static Log CreateLogItemGoofySarnia()
        {
            User currentUser = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            return CreateLogItemGoofySarnia(currentUser);
        }

        public static Log CreateLogItemGoofySarnia(User currentUser)
        {
            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            Time loggedTime = shift.StartTime;
            DateTime loggedDateTime = new DateTime(2005, 12, 1, loggedTime.Hour, loggedTime.Minute + 1, loggedTime.Second);
            return CreateLogItemGoofySarnia(shift, loggedDateTime, currentUser);
        }

        private static Log CreateLogItemGoofySarnia(ShiftPattern shift, DateTime loggedDateTime, User currentUser)
        {
            Log newLog = new Log(null,
                                 null,
                                 null,
                                 DataSource.MANUAL,
                                 new List<FunctionalLocation> { FunctionalLocationFixture.GetAny_Unit1() },
                                 false, false, false, false, false, false,                                 
                                 "Other Test Comments 2",                          
                                 "Other Test Comments 2",                          
                                 loggedDateTime,
                                 shift,
                                 currentUser,
                                 currentUser,
                                 loggedDateTime,
                                 loggedDateTime,
                                 false,
                                 false,
                                 RoleFixture.GetRealRoleA(Site.OILSAND_ID),
                                 LogType.Standard,
                                 null) { Id = 5 };

            return newLog;
        }


        public static Log CreateLogItemCreatedByUser(User createdByUser, ShiftPattern shift, DateTime loggedDateTime)
        {
            Log newLog = CreateLogItemGoofySarnia(shift, loggedDateTime, createdByUser);
            DateTime now = DateTimeFixture.DateTimeNow;
            newLog.LastModifiedDate = new DateTime(now.Year, now.Month, now.Day);
            newLog.LastModifiedBy = createdByUser;
            return newLog;
        }  
        
        public static Log CreateLogItemCreatedByUser(User createdByUser)
        {
            Log newLog = CreateLogItemGoofySarnia(createdByUser);
            DateTime now = DateTimeFixture.DateTimeNow;
            newLog.LastModifiedDate = new DateTime(now.Year, now.Month, now.Day);
            newLog.LastModifiedBy = createdByUser;
            return newLog;
        }

        public static Log CreateReplyLogItem()
        {
            Log replyLog = CreateLogItemGoofySarnia();
            replyLog.Id = 5;
            replyLog.RootLogId = 1;
            return replyLog;
        }

        public static Log CreateLogNotInDatabase(FunctionalLocation floc)
        {
            Log log = CreateLogItemGoofySarnia();
            log.Id = null;
            log.FunctionalLocations = new List<FunctionalLocation> { floc };
            return log;
        }

        public static Log CreateLogItemCreatedByUserWithSpecificId(long logId, User createdByUser)
        {
            Log newLog = CreateLogItemCreatedByUser(createdByUser);
            newLog.Id = logId;

            return newLog;
        }

        public static Log CreateLogItem(DateTime loggedDateTime, DateTime lastModifiedDate)
        {
            ShiftPattern shiftPattern;
            if (ShiftPatternFixture.CreateDayShift().IsTimeInShiftIncludingPadding(new Time(loggedDateTime)))
            {
                 shiftPattern = ShiftPatternFixture.CreateDayShift();
            }
            else
            {
                shiftPattern = ShiftPatternFixture.CreateNightShift();
            }
            Log log = CreateLogItemGoofySarnia(shiftPattern, loggedDateTime, UserFixture.CreateOperatorGoofyInFortMcMurrySite());
            log.LastModifiedDate = lastModifiedDate;
            return log;
        }

        public static Log CreateLogItemWithLogDefinition()
        {
            Log log = CreateLogItem(DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow);
            log.LogDefinition = LogDefinitionFixture.CreateLogDefintionWithRecurringWeeklySchedule();
            return log;
        }

        public static Log CreateLog(bool isRecurring)
        {
            Log log = CreateLogItemWithLogDefinition();
            if (isRecurring == false)
            {
                log.LogDefinition.Schedule = null;
            }
            return log;
        }

        public static Log CreateLog(DateTime loggedDate, List<FunctionalLocation> flocs, WorkAssignment assignment)
        {
            return CreateLog(loggedDate, flocs, assignment, ShiftPatternFixture.CreateDayShift(), null, LogType.Standard, null);
        }

        public static Log CreateLog(DateTime loggedDate, List<FunctionalLocation> flocs, WorkAssignment assignment, LogType logType)
        {
            return CreateLog(loggedDate, flocs, assignment, ShiftPatternFixture.CreateDayShift(), null, logType, null);
        }


        public static Log CreateLogItemWithSpecificRole(Role role)
        {
            ShiftPattern dayShiftPattern = ShiftPatternFixture.CreateDayShift();
            Time loggedTime = dayShiftPattern.StartTime;
            User user = UserFixture.CreateOperatorOltUser1InFortMcMurrySite();

            return new Log(null,
                     null,
                     null,
                     DataSource.MANUAL,
                     new List<FunctionalLocation> { FunctionalLocationFixture.GetAny_Unit1() },
                     false,
                     false,
                     false,
                     true,
                     false,
                     false,                     
                     "Test Comments",                    
                     "Test Comments",                    
                     new DateTime(2005, 12, 1, loggedTime.Hour, loggedTime.Minute + 1, loggedTime.Second),
                     ShiftPatternFixture.CreateDayShift(),
                     user,
                     user,
                     new DateTime(2005, 12, 1, loggedTime.Hour, loggedTime.Minute + 1, loggedTime.Second),
                     new DateTime(2005, 12, 1, loggedTime.Hour, loggedTime.Minute + 1, loggedTime.Second),
                     false,
                     false,
                     role,
                     LogType.Standard,
                     null);

        }

        public static Log CreateLog(
            DateTime loggedDate,
            List<FunctionalLocation> flocs,
            WorkAssignment assignment,
            ShiftPattern shift,
            User createUser,
            Role createdByRole)
        {
            return CreateLog(loggedDate, flocs, assignment, shift, createUser, LogType.Standard, createdByRole);
        }

        public static Log CreateLog(
            DateTime loggedDate,
            List<FunctionalLocation> flocs,
            WorkAssignment assignment,
            ShiftPattern shift,
            User createUser,
            LogType logType, Role createdByRole)
        {
            return new Log(null,
                           null,
                           null,
                           DataSource.TARGET,
                           flocs,
                           false,
                           false,
                           false,
                           false,
                           false,
                           false,
                           null,
                           "",                          
                           loggedDate,
                           shift,
                           createUser,
                           createUser,
                           loggedDate,
                           loggedDate,
                           false,
                           false,
                           createdByRole,
                           logType,
                           assignment);
        }
    }
}
