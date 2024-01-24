using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public static class TargetDefinitionHistoryFixture
    {
        public static List<TargetDefinitionHistory> CreateTargetDefinitionHistories()
        {
            var history1 = CreateTargetDefinitionHistory();
            history1.LastModifiedDate = new DateTime(2006, 05, 16, 12, 00, 00);
            history1.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            history1.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            history1.LastModifiedBy = UserFixture.CreateOperatorMickeyInFortMcMurrySite();

            var history2 = CreateTargetDefinitionHistory();
            history2.Description = history2.Description + "Changed";
            history2.LastModifiedDate = new DateTime(2006, 05, 16, 14, 00, 00);

            var history3 = CreateTargetDefinitionHistory();
            history3.Description = history2.Description;
            history3.MaxValue = 120;
            history3.LastModifiedDate = new DateTime(2006, 05, 17, 08, 00, 00);

            var histories = new List<TargetDefinitionHistory> {history1, history2, history3};

            return histories;
        }

        public static TargetDefinitionHistory CreateTargetDefinitionHistory()
        {
            var targetDefinitionHistory = new TargetDefinitionHistory(
                1,
                "target def history name",
                10.00m,
                100.00m,
                null,
                null,
                1,
                1,
                70.00m,
                40.00m,
                null,
                null,
                1,
                1,
                "Maximum",
                23.00m,
                "description",
                TargetCategory.ENV_SAFTEY,
                TagInfoFixture.CreateTagInfoWithId2FromDB(),
                false,
                false,
                false,
                false,
                true,
                FunctionalLocationFixture.GetAny_Unit1(),
                TargetDefinitionStatus.Pending,
                UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(),
                new DateTime(2006, 06, 22, 09, 22, 00),
                OperationalMode.Normal,
                Priority.High,
                "schedule",
                null,
                null,
                string.Empty,
                string.Empty);
            return targetDefinitionHistory;
        }
    }
}