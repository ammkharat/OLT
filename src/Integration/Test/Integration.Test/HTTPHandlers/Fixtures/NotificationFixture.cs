using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;

namespace Com.Suncor.Olt.Integration.HTTPHandlers.Fixtures
{
    public class NotificationFixture : SAPFixture
    {
        private const string AM = "AM";
        private const string EI = "EI";
        private const string MC = "MC";

        public string failureReason = string.Empty;

        public static NotificationSAPData CreateNotificationSAPData(FunctionalLocation floc, string plantId)
        {
//            DateTime creationDateTime = DateTimeFixture.DateTimeNow;

            var notificationNumber = CreateNotificationNumber();
            const string notificationType = AM;
            const string shortText = "OLT Timezone Test";
            var functionalLocation = floc.FullHierarchy;
            const string equipmentNumber = "";

            const string createDate = "2006-04-11";
//            string createDate = new Date(creationDateTime).ToString();
//            string createTime = new Time(creationDateTime).ToStringWithSeconds();
            const string createTime = "06:02:31";
            const string incidentID = "";
            var plantID = plantId;
            const string longText = "* 2006/04/13 06:58:42 SEPI Test (STEST)* Set timezone to EST";
            const string manum = "0001";
            const string taskCode = "AM01";
            const string taskCodeText = "OLT Code Test";
            const string taskText = "OLT Task Test";
            const string creator = "STEST";
//            string creationDate = createDate;
            const string creationDate = "2006-04-11";
            const string plannedStartDate = "2006-04-11";
            const string plannedStartTime = "08:15:00";
            const string plannedFinishDate = "2006-04-11";
            const string plannedFinishTime = "09:30:00";
            const string exceptionText = "RIII";
            const string contactPerson = "0012007549";

            var ret = new NotificationSAPData(notificationNumber,
                notificationType,
                shortText,
                functionalLocation,
                equipmentNumber,
                createDate,
                createTime,
                incidentID,
                plantID,
                longText,
                manum,
                taskCode,
                taskCodeText,
                taskText,
                creator,
                creationDate,
                plannedStartDate,
                plannedStartTime,
                plannedFinishDate,
                plannedFinishTime,
                exceptionText,
                contactPerson);
            return ret;
        }

        public static NotificationSAPData CreateEINotification()
        {
            return CreateEINotification("SR1-PLT1-GEN1");
        }

        public static NotificationSAPData CreateEINotification(string fullHierarchy)
        {
            var ret =
                CreateNotificationSAPData(FunctionalLocationFixture.CreateNew(fullHierarchy), "4000");
            ret.NotificationType = EI;
            return ret;
        }

        public static NotificationSAPData CreateAMNotification()
        {
            var ret =
                CreateNotificationSAPData(FunctionalLocationFixture.CreateNew("SR1-PLT1-GEN1"), "4000");
            ret.NotificationType = AM;
            return ret;
        }

        public static NotificationSAPData CreateEINotification(FunctionalLocation functionalLocation, string plantId)
        {
            var ret = CreateNotificationSAPData(functionalLocation, plantId);
            ret.NotificationType = EI;
            return ret;
        }

        public static NotificationSAPData CreateNotificationThatBecomesAnActionItem()
        {
            return CreateNotificationThatBecomesAnActionItem("SR1-PLT1-GEN1");
        }

        public static NotificationSAPData CreateNotificationThatBecomesAnActionItem(string hierarchySegments)
        {
            var ret =
                CreateNotificationSAPData(FunctionalLocationFixture.CreateNew(hierarchySegments), "4000");
            ret.NotificationType = MC;
            return ret;
        }
    }
}