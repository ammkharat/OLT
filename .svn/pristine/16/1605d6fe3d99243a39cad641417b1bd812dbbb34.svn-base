using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Integration.Handlers.MessageObjects;

namespace Com.Suncor.Olt.Integration.Handlers.Fixtures
{
    public class NotificationDetailFixture
    {
        public static NotificationDetails[] GetArrayFromItems(NotificationDetails notificationDetail1)
        {
            var notificationArray = new NotificationDetails[1];
            notificationArray[0] = notificationDetail1;
            return notificationArray;
        }

        public static NotificationDetails[] GetArrayFromItems(NotificationDetails notificationDetail1,
            NotificationDetails notificationDetail2)
        {
            var notificationArray = new NotificationDetails[2];
            notificationArray[0] = notificationDetail1;
            notificationArray[1] = notificationDetail2;
            return notificationArray;
        }

        public static NotificationDetails GetNotificationDetailBase()
        {
            var notificationDetails = new NotificationDetails();

            notificationDetails.NotificationNumber = "1111";
            notificationDetails.PlantID = "4000";
            notificationDetails.ShortText = "Short Text";
            notificationDetails.CreateDate = "2006-01-01";
            notificationDetails.CreateTime = "12:00";
            notificationDetails.EquipmentNumber = "1111";
            notificationDetails.FunctionalLocation = "SR1-PL3-HYDU-SMP";
            notificationDetails.IncidentID = "11111";
            notificationDetails.LongText = "This is the long text";
            notificationDetails.Tasks = new Tasks[0];

            return notificationDetails;
        }

        public static NotificationDetails GetMinimumNotificationWorkRequest()
        {
            var notificationDetails = new NotificationDetails();

            notificationDetails.NotificationNumber = "1111";
            notificationDetails.PlantID = "4000";
            notificationDetails.ShortText = "Short Text";
            notificationDetails.CreateDate = "2006-01-01";
            notificationDetails.CreateTime = "12:00";
            notificationDetails.EquipmentNumber = "";
            notificationDetails.FunctionalLocation = "SR1-PL3-HYDU-SMP";
            notificationDetails.IncidentID = "11111";
            notificationDetails.LongText = "This is the long text";
            notificationDetails.Tasks = new Tasks[0];

            return notificationDetails;
        }

        public static NotificationDetails GetWorkRequest()
        {
            var notificationDetails = GetNotificationDetailBase();

            notificationDetails.NotificationType = SAPNotificationType.WorkRequest;

            return notificationDetails;
        }

        public static NotificationDetails GetEmergencyIncident()
        {
            var notificationDetails = GetNotificationDetailBase();

            notificationDetails.NotificationType = SAPNotificationType.EmergencyIncident;

            return notificationDetails;
        }

        public static NotificationDetails GetActionManagementWithNoTask()
        {
            var notificationDetails = GetNotificationDetailBase();

            notificationDetails.NotificationType = SAPNotificationType.ActionManagement;

            return notificationDetails;
        }

        public static NotificationDetails GetActionManagementWithOneTask()
        {
            var notificationDetails = GetNotificationDetailBase();

            notificationDetails.NotificationType = SAPNotificationType.ActionManagement;
            notificationDetails.Tasks = new Tasks[1];
            notificationDetails.Tasks[0] = GetTask();


            return notificationDetails;
        }


        public static NotificationDetails GetActionManagementWithTwoTasks()
        {
            var notificationDetails = GetNotificationDetailBase();

            notificationDetails.NotificationType = SAPNotificationType.ActionManagement;
            notificationDetails.Tasks = new Tasks[2];
            notificationDetails.Tasks[0] = GetTask();
            notificationDetails.Tasks[1] = GetTask2();

            return notificationDetails;
        }

        public static NotificationDetails GetManagementChangeWithOneTask()
        {
            var notificationDetails = GetNotificationDetailBase();

            notificationDetails.NotificationType = SAPNotificationType.ManagementChange;
            notificationDetails.Tasks = new Tasks[1];
            notificationDetails.Tasks[0] = GetTask();
            return notificationDetails;
        }

        public static NotificationDetails GetManagementChangeWithOneTask2006_3_6_09_91456To2006_3_9_091500()
        {
            var notificationDetails = GetNotificationDetailBase();

            notificationDetails.NotificationType = SAPNotificationType.ManagementChange;
            notificationDetails.Tasks = new Tasks[1];
            var task = GetTask();
            task.PlannedStartDate = "2006-3-6";
            task.PlannedFinishDate = "2006-3-9";
            task.PlannedStartTime = "09:14:56";
            task.PlannedFinishTime = "09:15:00";
            notificationDetails.Tasks[0] = task;
            return notificationDetails;
        }

        public static NotificationDetails GetInvalidManagementChangeWith0Tasks()
        {
            var notificationDetails = GetNotificationDetailBase();

            notificationDetails.NotificationType = SAPNotificationType.ManagementChange;
            notificationDetails.Tasks = new Tasks[0];
            return notificationDetails;
        }

        public static NotificationDetails GetInvalidManagementChangeWithNullTasks()
        {
            var notificationDetails = GetNotificationDetailBase();

            notificationDetails.NotificationType = SAPNotificationType.ManagementChange;
            notificationDetails.Tasks = null;
            return notificationDetails;
        }

        public static NotificationDetails GetActivityReport()
        {
            var notificationDetails = GetNotificationDetailBase();

            notificationDetails.NotificationType = SAPNotificationType.ActivityReport;

            return notificationDetails;
        }


        public static NotificationDetails GetActivityReportWithDate2005Feb4_60345PM()
        {
            var notificationDetails = GetNotificationDetailBase();
            notificationDetails.CreateDate = "2005-2-4";
            notificationDetails.CreateTime = "18:03:45";
            notificationDetails.NotificationType = SAPNotificationType.ActivityReport;

            return notificationDetails;
        }

        public static Tasks GetTask()
        {
            var task = new Tasks();
            task.ContactPerson = "Contact Person";
            task.CreationDate = "2006-02-01";
            task.Creator = "Creator ";
            task.ExceptionText = "Exception Text ";
            task.PlannedFinishDate = "2006-02-05";
            task.PlannedStartDate = "2006-02-04";
            task.PlannedFinishTime = "11:00";
            task.PlannedStartTime = "11:00";
            task.TaskCode = "Task ID";
            task.TaskCodeText = "Task Description";
            task.TaskText = "Task text";

            return task;
        }

        public static Tasks GetTask2()
        {
            var task = new Tasks();
            task.ContactPerson = "Contact Person2";
            task.CreationDate = "2006-03-01";
            task.Creator = "Creator2 ";
            task.ExceptionText = "Exception Text2 ";
            task.PlannedFinishDate = "2006-03-05";
            task.PlannedStartDate = "2006-03-04";
            task.PlannedFinishTime = "15:00";
            task.PlannedStartTime = "15:00";
            task.TaskCode = "Task ID2";
            task.TaskCodeText = "Task Description2";
            task.TaskText = "Task text2";

            return task;
        }
    }
}