
using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class WorkPermitMontrealFixture
    {
        public static WorkPermitMontreal CreateForInsert()
        {
            return CreateForInsert(DateTime.Now, DateTime.Now);
        }

        public static WorkPermitMontreal CreateForInsert(DateTime startDateTime, DateTime endDateTime)
        {
            return CreateForInsert(startDateTime, endDateTime, FunctionalLocationFixture.GetReal_MT1_A003_U120());
        }

        public static WorkPermitMontreal CreateForInsert(DateTime startDateTime, DateTime endDateTime, FunctionalLocation functionalLocation)
        {
            User user = UserFixture.CreateUserWithGivenId(1);
            DateTime createdDateTime = DateTime.Now;

            return new WorkPermitMontreal(DataSource.MANUAL, PermitRequestBasedWorkPermitStatus.Pending, WorkPermitMontrealType.MODERATE_HOT, null,
                  startDateTime, endDateTime,
                  new List<FunctionalLocation> { functionalLocation }, "12345",
                  "troy's electric trade", "work permit description", createdDateTime, user, createdDateTime, user,
                  WorkPermitMontrealGroupFixture.CreateWithExistingId(), null);
        }

        public static WorkPermitMontreal CreateWorkPermitWithGivenId(long id)
        {
            WorkPermitMontreal workPermit = CreateForInsert();
            workPermit.Id = id;
            return workPermit;
        }
    }
}
