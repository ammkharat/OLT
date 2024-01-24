using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class UserLoginHistoryFixture
    {
        public static UserLoginHistory Create(long userId, long assignmentId)
        {
            WorkAssignment assignment = WorkAssignmentFixture.CreateUnitLeader();
            assignment.Id = assignmentId;

            return Create(userId, assignment);
        }

        public static UserLoginHistory Create(long userId, WorkAssignment assignment)
        {
            User user = UserFixture.CreateUserWithGivenId(userId);
            return Create(user, assignment);
        }

        public static UserLoginHistory Create(User user, WorkAssignment assignment)
        {
            DateTime loginDateTime = new DateTime(2010, 1, 2, 10, 0, 0);
            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            UserShift userShift = new UserShift(shift, loginDateTime);

            return new UserLoginHistory(
                1, 
                user, 
                loginDateTime,
                shift, 
                userShift.StartDateTime, 
                userShift.EndDateTime,
                assignment,
                new List<FunctionalLocation>(),
                @"net.tcp://abc",
                @"\\someUNCServer\Folder",
                "D12345",
                "WinXp",
                ".NET 1.1",
                true);
        }

        public static UserLoginHistory CreateWithNoAssignment(long userId)
        {
            return Create(userId, null);
        }

        public static UserLoginHistory CreateWithSelectedFuctionalLocations(User user, List<FunctionalLocation> flocList)
        {
            DateTime loginDateTime = new DateTime(2010, 1, 2, 10, 0, 0);
            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            UserShift userShift = new UserShift(shift, loginDateTime);

            return new UserLoginHistory(
                1,
                user,
                loginDateTime,
                shift,
                userShift.StartDateTime,
                userShift.EndDateTime,
                null,
                flocList,
                string.Empty,
                string.Empty,
                string.Empty,
                "WinXp",
                ".NET 1.1",
                true);
        }

        public static UserLoginHistory Create(long userId, DateTime loginDateTime)
        {
            User user = UserFixture.CreateUserWithGivenId(1);

            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            Time loginTime = new Time(loginDateTime);
            if (!shift.IsTimeInShiftIncludingPadding(loginTime))
            {
                shift = ShiftPatternFixture.CreateNightShift();
            }
            UserShift userShift = new UserShift(shift, loginDateTime);

            return new UserLoginHistory(
                userId,
                user,
                loginDateTime,
                shift,
                userShift.StartDateTime,
                userShift.EndDateTime,
                null,
                new List<FunctionalLocation>(),
                string.Empty,
                string.Empty,
                string.Empty, 
                "WinXp",
                ".NET 1.1",
                true);
        }
    }
}
