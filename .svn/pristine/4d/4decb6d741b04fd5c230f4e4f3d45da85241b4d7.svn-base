using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class LogHistoryFixture
    {
        public static LogHistory CreateLogHistory()
        {
            return CreateLogHistory("comments");
        }

        public static LogHistory CreateLogHistory(string comments)
        {
            LogHistory logHistory =
                new LogHistory(5, FunctionalLocationFixture.GetAny_Unit1().FullHierarchy, false, false, false, false,
                               false, false, UserFixture.CreateOperator(),
                               new DateTime(2006, 05, 16, 13, 42, 00), false, "livelink links", false,
                               comments, null, null);
            return logHistory;
        }

        public static LogHistory CreateLogHistory(FunctionalLocation floc, User user, string comments)
        {
            return CreateLogHistory(floc, user, comments, false);
        }

        public static LogHistory CreateLogHistory(FunctionalLocation floc, User user, string comments, bool isOperatingEngineerLog)
        {
            LogHistory logHistory =
                new LogHistory(5, floc.FullHierarchy, false, false, false, false,
                               false, false, user,
                               new DateTime(2006, 05, 16, 13, 42, 00), isOperatingEngineerLog, "livelink links", false,
                               comments, null, null);
            return logHistory;
        }
    }
}