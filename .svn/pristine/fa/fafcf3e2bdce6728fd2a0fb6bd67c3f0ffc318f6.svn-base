using System.Collections.Generic;
using System.IO;
using Com.Suncor.Olt.Integration.Handlers.Adapters;
using Com.Suncor.Olt.Integration.Handlers.MessageObjects;
using Com.Suncor.Olt.Integration.Handlers.Validators;
using log4net;

namespace Com.Suncor.Olt.Integration.Handlers
{
    public class NotificationMessageHandler
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof (NotificationMessageHandler));

        /// <summary>
        ///     Processes the XML data (supplied by SAP-IDD0309)
        ///     The noticifications message from SAP may contain either items that require
        ///     the creation of action items, or storing for later selection by operators
        ///     as log items.
        /// </summary>
        /// <param name="stream">Memory stream containing the decoded XML data</param>
        public bool ProcessNotification(Stream stream)
        {
            //todo: make sure that existing records can't come in as an update. If so, what is the unique key            
            var notificationProcessor = new NotificationValidator();
            var notification = notificationProcessor.Parse(stream);

            if (!HasData(notification))
            {
                return false;
            }

            var notificationDetails = notification.NotificationRecord.NotificationDetails;

            LogMessageEntry(notificationDetails);

            var valid = notificationProcessor.DoesPassRequirementsCheck(notificationDetails);

            if (!valid)
                return false;

            var adapter = new NotificationAdapter(notificationDetails);
            adapter.IntegrateNotificationObjectToOperatorLogTool();
            return true;
        }


        private void LogMessageEntry(IEnumerable<NotificationDetails> notificationDetails)
        {
            foreach (var detail in notificationDetails)
            {
                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("Notification {0} for {1} received. ShortText is {2}, LanguageCode is: {3}",
                        detail.NotificationNumber, detail.FunctionalLocation, detail.ShortText, detail.LanguageCode);
                }
                else
                {
                    logger.InfoFormat("Notification {0} for {1} received.", detail.NotificationNumber,
                        detail.FunctionalLocation);
                }
            }
        }

        private bool HasData(Notification notification)
        {
            if (notification == null)
            {
                logger.Error("Did not get a notification object after parsing the message.");
                return false;
            }
            if (notification.NotificationRecord == null)
            {
                logger.Error("No NotificationRecord found in message.");
                return false;
            }
            if (notification.NotificationRecord.NotificationDetails == null)
            {
                logger.Error("No Notification Details found in message.");
                return false;
            }
            if (notification.NotificationRecord.NotificationDetails.Length == 0)
            {
                logger.Info("No details records found in message.");
                return false;
            }
            return true;
        }
    }
}