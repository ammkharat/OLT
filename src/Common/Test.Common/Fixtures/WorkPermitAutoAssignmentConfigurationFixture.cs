using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class WorkPermitAutoAssignmentConfigurationFixture
    {

        public static AssignmentFlocConfiguration GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(
            List<FunctionalLocation> flocs)
        {
            return new AssignmentFlocConfiguration(WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData().IdValue, "TEST1",
                                                         RoleFixture.CreateOperatorRole().Name,
                                                         "Test One", "General", flocs);
        }

        public static AssignmentFlocConfiguration GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData(
            List<FunctionalLocation> flocs)
        {
            return new AssignmentFlocConfiguration(WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData().IdValue, "TEST2",
                                                         RoleFixture.CreateOperatorRole().Name,
                                                         "Test Two", "General", flocs);
        }

    }
}
