using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class LogDefinitionFixture
    {
        public static LogDefinition CreateLogDefinition()
        {
            return CreateLogDefinition(1);
        }

        public static LogDefinition CreateLogDefinition(long? id)
        {
            return CreateLogDefinition(id, LogType.Standard);
        }

        public static LogDefinition CreateLogDefinition(long? id, LogType logType)
        {
            return CreateLogDefinition(id, logType, null);
        }

        public static LogDefinition CreateLogDefinition(long? id, LogType logType, WorkAssignment workAssignment)
        {
            return CreateLogDefinition(id, logType, workAssignment, false);
        }

        public static LogDefinition CreateLogDefinition(long? id, LogType logType, WorkAssignment workAssignment, bool isOperatingEngineerLog)
        {
            User createdBy = UserFixture.CreateOperatorOltUser1InFortMcMurrySite();
           
            LogDefinition logDefinition
                = new LogDefinition(RecurringDailyScheduleFixture.CreateEvery1DaysFrom5PMTo6PMWithyNoEndDateStarting2006June15(),
                                    new List<FunctionalLocation> { FunctionalLocationFixture.GetAny_Unit1() },
                                    true,
                                    false,
                                    false,
                                    false,
                                    false,
                                    true,
                                    isOperatingEngineerLog,
                                    RoleFixture.GetRealRoleA(Site.OILSAND_ID),
                                    new DateTime(2005, 11, 15),
                                    createdBy,
                                    createdBy,
                                    DateTimeFixture.DateTimeNow,
                                    new List<DocumentLink>(),                                    
                                    "Test Comments",                                   
                                    "Test Comments as Plain Text",                                   
                                    logType,
                                    workAssignment,
                                    true,
                                    null,
                                    null,
                                    true);

            if (id.HasValue)
            {
                logDefinition.Id = id;
            }

            return logDefinition;
        }

        public static LogDefinition CreateLogDefinitionWithRecurringWeeklySchedule(WorkAssignment workAssignment)
        {
            LogDefinition logDefintion = CreateLogDefinition(null, LogType.Standard, workAssignment);
            logDefintion.Schedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            logDefintion.Schedule.Id = 1;
            return logDefintion;
        }

        public static LogDefinition CreateLogDefintionWithRecurringWeeklySchedule()
        {
            LogDefinition logDefintion = CreateLogDefinition(null);
            logDefintion.Schedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            logDefintion.Schedule.Id = 1;
            return logDefintion;
        }

        public static LogDefinition CreateOperatingEngineerLogDefintionWithRecurringWeeklySchedule()
        {
            LogDefinition logDefintion = CreateLogDefinition(null, LogType.Standard, null, true);
            return logDefintion;
        }
    
        public static LogDefinition CreateLogDefinition(List<FunctionalLocation> flocs, bool createALogForEachFunctionalLocation)
        {
            User createdBy = UserFixture.CreateOperatorOltUser1InFortMcMurrySite();

            DocumentLink link = new DocumentLink("http://www.cnn.com", "News Website");

            return new LogDefinition(RecurringDailyScheduleFixture.CreateEvery1DaysFrom5PMTo6PMWithyNoEndDateStarting2006June15(),
                                    flocs,
                                    true,
                                    false,
                                    false,
                                    false,
                                    false,
                                    true,
                                    false,
                                    RoleFixture.CreateOperatorRole(),
                                    new DateTime(2005, 11, 15),
                                    createdBy,
                                    createdBy,
                                    DateTimeFixture.DateTimeNow,
                                    new List<DocumentLink> { link },                                    
                                    "Test Comments",                                    
                                    "Test Comments",                                    
                                    LogType.Standard, 
                                    null,
                                    createALogForEachFunctionalLocation,
                                    null,
                                    null,
                                    true);
        }
    }
}
