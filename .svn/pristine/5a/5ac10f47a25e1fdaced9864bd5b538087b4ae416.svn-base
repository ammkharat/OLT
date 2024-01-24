using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class CokerCardFixture
    {
        public static CokerCard Create(CokerCardConfiguration configuration)
        {
            return CreateForInsert(
                configuration,
                FunctionalLocationFixture.GetReal_UP1(),
                WorkAssignmentFixture.CreateUnitLeader(),
                ShiftPatternFixture.Create8HourNightShift(), 
                new Date(2001, 2, 3));
        }

        public static CokerCard CreateForInsert(CokerCardConfiguration configuration, WorkAssignment workAssignment, ShiftPattern shift, Date shiftStartDate)
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_UP1();
            return CreateForInsert(configuration, floc, workAssignment, shift, shiftStartDate);          
        }

        public static CokerCard CreateForInsert(CokerCardConfiguration configuration, FunctionalLocation floc, WorkAssignment workAssignment, ShiftPattern shift, Date shiftStartDate)
        {            
            return new CokerCard(
                null,
                configuration.IdValue,
                configuration.Name,
                floc,
                workAssignment,
                shift,
                shiftStartDate,
                UserFixture.CreateOperatorGoofyInFortMcMurrySite(),
                new DateTime(2011, 5, 9),
                UserFixture.CreateEngineeringSupport(),
                new DateTime(2011, 7, 19),
                false);
        }
    }
}
