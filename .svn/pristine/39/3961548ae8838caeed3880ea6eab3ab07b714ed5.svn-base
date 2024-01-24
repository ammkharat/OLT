using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class DeviationAlertFixture
    {
        public static DeviationAlert Create()
        {
            return Create(RestrictionDefinitionFixture.CreateDefinition());
        }

        public static DeviationAlert Create(RestrictionDefinition definition)
        {
            return new DeviationAlert(
                definition,
                "restriction name",
                "restriction definition name",
                DeviationAlertResponseFixture.CreateResponseWithId1FromDB(),
                null,
                TagInfoFixture.CreateTagInfoWithId2FromDB(),
                100,
                80,
                DateTimeFixture.DateTimeNow.AddHours(-1),
                DateTimeFixture.DateTimeNow,
                definition.FunctionalLocation,
                UserFixture.CreateUserWithGivenId(1),
                DateTimeFixture.DateTimeNow,
                DateTimeFixture.DateTimeNow);
        }

        public static DeviationAlert Create(FunctionalLocation floc, DateTime start, DateTime end, DateTime createTime)
        {
            RestrictionDefinition definition = RestrictionDefinitionFixture.CreateDefinition();
            definition.Id = 1; // exists
            return new DeviationAlert(
                definition,
                "restriction name",
                "restriction definition name",
                DeviationAlertResponseFixture.CreateResponseWithId1FromDB(),
                null,
                TagInfoFixture.CreateTagInfoWithId2FromDB(),
                100,
                80,
                start,
                end,
                floc,
                UserFixture.CreateUserWithGivenId(1),
                createTime,
                createTime);
        }

        public static DeviationAlert Create(FunctionalLocation floc, DateTime start, DateTime end)
        {
            return Create(floc, start, end, DateTimeFixture.DateTimeNow);
        }
    }
}