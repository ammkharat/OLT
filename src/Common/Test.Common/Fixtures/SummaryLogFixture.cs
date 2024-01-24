using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public static class SummaryLogFixture
    {
        public static SummaryLog CreateSummaryLog(DateTime loggedDateTime, ShiftPattern shift, Role role)
        {
            User user = UserFixture.CreateOperatorOltUser1InFortMcMurrySite();
            FunctionalLocation floc = FunctionalLocationFixture.GetAny_Unit1();
            return new SummaryLog(
                new List<FunctionalLocation> { floc },
                "Comments",
                "Comments",                
                null,
                DataSource.MANUAL,
                false,
                false,
                false,
                false,
                false,
                false,
                loggedDateTime,
                loggedDateTime,
                shift,
                user,
                role,
                user,
                loggedDateTime,
                new List<DocumentLink>(),
                null, null, null,
                null, null, false);
        }

        public static SummaryLog CreateSummaryLog()
        {
            return CreateSummaryLog(FunctionalLocationFixture.GetAny_Unit1());
        }
        
        public static SummaryLog CreateSummaryLog(FunctionalLocation floc)
        {
            Log log = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp();
            
            return new SummaryLog(                
                new List<FunctionalLocation>{floc}, 
                log.RtfComments,
                log.PlainTextComments,
                null,
                DataSource.MANUAL,
                log.InspectionFollowUp,
                log.ProcessControlFollowUp,
                log.OperationsFollowUp,
                log.SupervisionFollowUp,
                log.EnvironmentalHealthSafetyFollowUp,
                log.OtherFollowUp,
                log.LogDateTime,
                log.CreatedDateTime,
                log.CreatedShiftPattern,
                log.CreationUser,
                RoleFixture.GetRealRoleA(floc.Site.IdValue),
                log.LastModifiedBy,
                log.LastModifiedDate,
                log.DocumentLinks,
                log.WorkAssignment, null,
                null, null, null, false);
        }

        public static SummaryLog CreateSummaryLogNotInDatabase()
        {
            SummaryLog log = CreateSummaryLogItemGoofySarnia();
            log.Id = null;
            return log;
        }

        public static SummaryLog CreateSummaryLogItemCreatedByUser(User createdByUser)
        {
            SummaryLog newLog = CreateSummaryLogItemGoofySarnia(createdByUser);
            newLog.LastModifiedDate = new DateTime(DateTimeFixture.DateTimeNow.Year, DateTimeFixture.DateTimeNow.Month, DateTimeFixture.DateTimeNow.Day);
            newLog.LastModifiedBy = createdByUser;

            return newLog;
        }

        public static SummaryLog CreateSummaryLogItemGoofySarnia()
        {
            return CreateSummaryLogItemGoofySarnia(UserFixture.CreateOperatorGoofyInFortMcMurrySite());
        }

        public static SummaryLog CreateSummaryLogItemGoofySarnia(User createdByUser)
        {
            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            return CreateSummaryLogItemGoofySarnia(createdByUser, shift);
        }

        public static SummaryLog CreateSummaryLogItemGoofySarnia(ShiftPattern createShift)
        {
            return CreateSummaryLogItemGoofySarnia(UserFixture.CreateOperatorGoofyInFortMcMurrySite(), createShift);            
        }

        public static SummaryLog CreateSummaryLogItemGoofySarnia(User createdByUser, ShiftPattern createShift)
        {
            Time loggedTime = createShift.StartTime;
            User currentUser = UserFixture.CreateOperatorGoofyInFortMcMurrySite();

            FunctionalLocation floc = FunctionalLocationFixture.GetAny_Section();
            SummaryLog newLog = new SummaryLog(
               new List<FunctionalLocation> { floc },
               "", 
               "", 
               "", 
               DataSource.MANUAL,
               false, false, false, false, false, false,
               new DateTime(2005, 12, 1, loggedTime.Hour, loggedTime.Minute + 1,
                            loggedTime.Second),
               new DateTime(2005, 12, 1, loggedTime.Hour, loggedTime.Minute + 1,
                            loggedTime.Second),
               createShift,
               createdByUser,
               RoleFixture.GetRealRoleA(floc.Site.IdValue),
               currentUser,
               new DateTime(2005, 12, 1, loggedTime.Hour, loggedTime.Minute + 1,
                            loggedTime.Second),
               new List<DocumentLink>(),
               null, null,
               null, null, null, false) { Id = 1 };

            return newLog;
        }

        public static SummaryLog CreateSummaryLog(DateTime loggedDateTime, ShiftPattern shiftPattern, string comments, params FunctionalLocation[] flocs)
        {
            return CreateSummaryLog(loggedDateTime, shiftPattern, UserFixture.CreateOperatorGoofyInFortMcMurrySite(), comments, new List<FunctionalLocation>(flocs));
        }

        public static SummaryLog CreateSummaryLog(ShiftPattern shiftPattern, FunctionalLocation floc, DateTime loggedDateTime, string comments)
        {
            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            return CreateSummaryLog(shiftPattern, floc, loggedDateTime, user, comments);
        }

        public static SummaryLog CreateSummaryLog(ShiftPattern shiftPattern, FunctionalLocation floc, DateTime loggedDateTime, User user, string comments)
        {
            return CreateSummaryLog(loggedDateTime, shiftPattern, user, comments, new List<FunctionalLocation> { floc });
        }

        public static SummaryLog CreateSummaryLog(DateTime loggedDateTime, ShiftPattern shiftPattern, User user, string comments, List<FunctionalLocation> flocs)
        {
            return new SummaryLog(flocs,
                                  comments,
                                  comments,
                                  "DOR Comment",
                                  DataSource.MANUAL,
                                  false, false, false, false, false, false,
                                  loggedDateTime,
                                  loggedDateTime,
                                  shiftPattern,
                                  user,
                                  RoleFixture.GetRealRoleA(flocs[0].Site.IdValue),
                                  user,
                                  loggedDateTime,
                                  new List<DocumentLink>(),
                                  null, null,
                                  null, null, null, false);
        }
    }
}
