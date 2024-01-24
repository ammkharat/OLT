using Com.Suncor.Olt.Integration.Handlers.MessageObjects;
using log4net;
using System.Text;

namespace Com.Suncor.Olt.Integration.Handlers
{
    public class IntegrationLogger
    {

        /// <summary>
        /// Build and log an error message (logger) for a notification details object
        /// </summary>
        public static void LogNotificationDataErrorMessage(ILog logger, string errorMessage, NotificationDetails notificationDetail)
        {
            //log an error and get out
            var sb = new StringBuilder();
            sb.Append(errorMessage);
            sb.AppendLine();

            sb.AppendFormat("This notification will be ignored. Notification Number: {0}. Short Text: {1}. Equipment Number {2}. Create Date: {3}:{4}. Incident Report {5}. Long text {6}. Functional Location {7}.",
               notificationDetail.NotificationNumber, notificationDetail.ShortText, notificationDetail.EquipmentNumber, notificationDetail.CreateDate, notificationDetail.CreateTime, notificationDetail.IncidentID, notificationDetail.LongText, notificationDetail.FunctionalLocation);
            sb.AppendLine();
            if (notificationDetail.Tasks != null && notificationDetail.Tasks.Length > 0)
                foreach (Tasks task in notificationDetail.Tasks)
                {
                    sb.AppendFormat("Task details:Task Code: {0}, Description {1}, Task Text {2}, Task Creator ID: {3}, Task Creation Date: {4}, Planned Start Date: {5},{6}, Planned Finish Date: {7}, {8}, Exception Code: {9}, Contact Person: {10}",
                        task.TaskCode, task.TaskCodeText, task.TaskText, task.Creator, task.CreationDate, task.PlannedStartDate, task.PlannedStartTime, task.PlannedFinishDate, task.PlannedFinishTime,
                        task.ExceptionText, task.ContactPerson);
                    sb.AppendLine();
                }

            logger.Error(sb.ToString());

        }
    }
}
