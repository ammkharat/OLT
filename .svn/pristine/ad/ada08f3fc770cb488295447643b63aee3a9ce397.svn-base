using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class SAPNotificationFixture
    {
        public static SAPNotification GetAWorkRequestFortMcMurrayNotification()
        {
            SAPNotification sAPNotification = new SAPNotification(FunctionalLocationFixture.GetAny_Equip1(),
                "This is the description for WR",
                SAPNotificationType.WorkRequest,
                null, null, null, new DateTime(2006, 2, 2, 1, 0, 0), "000001", false);

            return sAPNotification;
        }

        public static SAPNotification GetAEmergencyIncidentFortMcMurrayNotification()
        {
            SAPNotification sapNotification = new SAPNotification(FunctionalLocationFixture.GetAny_Unit1(),
                "This is the description for EI",
                SAPNotificationType.EmergencyIncident,
                null, null, null, new DateTime(2006, 2, 2, 1, 0, 0), "000002", false);

            return sapNotification;
        }

        public static SAPNotification CreateSAPNotification(FunctionalLocation functionalLocation, string notificationNumber)
        {
            return CreateSAPNotification(functionalLocation, notificationNumber, DateTimeFixture.DateTimeNow);
        }

        public static SAPNotification CreateSAPNotification(FunctionalLocation functionalLocation, string notificationNumber, DateTime now)
        {
            SAPNotification sapNotification = new SAPNotification(functionalLocation,
                "This is the description for AM",
                SAPNotificationType.ActionManagement,
                null, null, null, now, notificationNumber, false);

            return sapNotification;
        }

    }
}