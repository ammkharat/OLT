using System;
using Com.Suncor.Olt.Common.Domain.LabAlert;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class LabAlertFixture
    {
        public static LabAlert CreateAlert()
        {
            return CreateAlert(new DateTime(2010, 1, 1), new DateTime(2010, 1, 1), new DateTime(2010, 1, 1), new DateTime(2010, 1, 1));
        }

        public static LabAlert CreateAlert(
            DateTime rangeFrom, DateTime rangeTo, DateTime lastModifiedDate, DateTime createdDateTime)
        {
            LabAlert alert = new LabAlert();

            alert.Name = "Lab Alert Name";
            alert.Description = "Lab Alert Description";
            alert.FunctionalLocation = FunctionalLocationFixture.GetAny_Equip1();
            alert.TagInfo = TagInfoFixture.CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC();
            alert.MinimumNumberOfSamples = 3;
            alert.ActualNumberOfSamples = 3;
            alert.LabAlertTagQueryRangeFromDateTime = rangeFrom;
            alert.LabAlertTagQueryRangeToDateTime = rangeTo;
            alert.ScheduleDescription = "Every day at 3pm";
            alert.LastModifiedBy = UserFixture.CreateUserWithGivenId(1);
            alert.LastModifiedDate = lastModifiedDate;
            alert.CreatedDateTime = createdDateTime;

            return alert;
        }
    }
}
