using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class LabAlertDefinitionFixture
    {
        public static LabAlertDefinition CreateDefinition()
        {
            return CreateDefinition(FunctionalLocationFixture.GetAny_Equip1());
        }

        public static LabAlertDefinition CreateDefinition(LabAlertDefinitionStatus status, Site site)
        {
            LabAlertDefinition definition = CreateDefinition(FunctionalLocationFixture.GetAny_Equip1());
            definition.Status = status;
            definition.FunctionalLocation.Site = site;
            return definition;
        }

        public static LabAlertDefinition CreateDefinition(LabAlertDefinitionStatus status, TagInfo tag)
        {
            LabAlertDefinition definition = CreateDefinition(FunctionalLocationFixture.GetAny_Equip1());
            definition.Status = status;
            definition.TagInfo = tag;
            return definition;
        }

        public static LabAlertDefinition CreateDefinition(FunctionalLocation floc)
        {
            return CreateDefinition("test definition", floc);
        }

        public static LabAlertDefinition CreateDefinition(string name, FunctionalLocation floc)
        {
            return CreateDefinition(name, floc, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow);
        }

        public static LabAlertDefinition CreateDefinition(User createdByUser, DateTime createdDateTime)
        {
            return CreateDefinition("test definition", FunctionalLocationFixture.GetAny_Equip1(), DateTimeFixture.DateTimeNow, createdDateTime, createdByUser);
        }

        public static LabAlertDefinition CreateDefinition(string name, FunctionalLocation floc, DateTime lastModifiedDateTime, DateTime createdDateTime)
        {
            return CreateDefinition(name, floc, lastModifiedDateTime, createdDateTime, UserFixture.CreateUserWithGivenId(1));
        }

        public static LabAlertDefinition CreateDefinition(
            string name, 
            FunctionalLocation floc,
            DateTime lastModifiedDateTime,
            DateTime createdDateTime,
            User createdByUser)
        {
            LabAlertDefinition definition = new LabAlertDefinition(
                1,
                name,
                "some sort of description",
                floc,
                TagInfoFixture.CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC(),
                5,
                new LabAlertTagQueryDailyRange(new Time(17), new Time(18)),
                RecurringDailyScheduleFixture.CreateEvery1DaysFrom5PMTo6PMWithyNoEndDateStarting2006June15(),
                true,
                UserFixture.CreateUserWithGivenId(1),
                lastModifiedDateTime,
                createdByUser,
                createdDateTime,
                LabAlertDefinitionStatus.Valid,                 
                false);

            return definition;
        }
    }
}
