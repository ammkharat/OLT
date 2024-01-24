using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Integration.Handlers.MessageObjects;
using log4net;

namespace Com.Suncor.Olt.Integration.Handlers.Validators
{
    /// <summary>
    ///     The class processes a memory stream containing an XML based Notofication
    ///     message and deserialises it into a object before validating its
    ///     content.
    /// </summary>
    public class NotificationValidator : Validator
    {
        private readonly ILog logger;

        public NotificationValidator()
            : this(LogManager.GetLogger(typeof (NotificationValidator)))
        {
        }

        public NotificationValidator(ILog logger)
        {
            this.logger = logger;
        }

        /// <summary>
        ///     Called by the message handler layer.
        /// </summary>
        /// <param name="stream">A memory stream containing decoded XML</param>
        /// <returns>A validated Notification data object contained in a memory stream</returns>
        public Notification Parse(Stream stream)
        {
            // The XML document to deserialize into the XmlSerializer object.
            using (var reader = new StreamReader(stream, Encoding.Default, true))
            {
                // Use the XmlSerializer object to convert the XML
                var serializer = new XmlSerializer(typeof (Notification));
                return (Notification) serializer.Deserialize(reader);
            }
        }

        public bool DoesPassRequirementsCheck(IEnumerable<NotificationDetails> notificationDetails)
        {
            var result = true;
            var logMessage = new StringBuilder();

            foreach (var notificationDetail in notificationDetails)
            {
                logMessage.AppendFormat("Requirements Check for Notification Number: {0}{1}",
                    notificationDetail.NotificationNumber, Environment.NewLine);
                var valid = true;

                if (FailsIsRequiredAndSizeCheck(notificationDetail.NotificationNumber,
                    Constants.NOTIFICATION_NUMBER_MAX_LENGTH))
                {
                    valid = false;
                    logMessage.AppendFormat(" Notification number is invalid.{0}", Environment.NewLine);
                }
                if (FailsIsRequiredAndSizeCheck(notificationDetail.NotificationType,
                    Constants.NOTIFICATION_TYPE_MAX_LENGTH))
                {
                    valid = false;
                    logMessage.AppendFormat(" Notification Type is invalid. Was: {0}{1}",
                        notificationDetail.NotificationType, Environment.NewLine);
                }
                if (FailsIsRequiredAndSizeCheck(notificationDetail.ShortText, Constants.SHORT_TEXT_MAX_LENGTH))
                {
                    valid = false;
                    logMessage.AppendFormat(" ShortText is invalid. Was: {0}{1}", notificationDetail.ShortText,
                        Environment.NewLine);
                }
/*
                if (FailsIsRequiredAndSizeCheck(notificationDetail.PlantID, Constants.PLANT_ID_MAX_LENGTH))
                {
                    valid = false;
                    logMessage.AppendFormat(" PlantID is invalid. Was: {0}{1}", notificationDetail.PlantID, Environment.NewLine);
                }
*/
/*
                if (FailsIsRequiredAndSizeCheck(notificationDetail.FunctionalLocation, Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH))
                {
                    valid = false;
                    logMessage.AppendFormat(" FunctionalLocation is invalid. Was: {0}{1}", notificationDetail.FunctionalLocation, Environment.NewLine);
                }
*/
/*
                if (FailsNotRequiredAndSizeCheck(notificationDetail.EquipmentNumber, Constants.EQUIPMENT_NUMBER_MAX_LENGTH))
                {
                    valid = false;
                    logMessage.AppendFormat(" EquipmentNumber is invalid. Was: {0}{1}", notificationDetail.EquipmentNumber, Environment.NewLine);
                }
*/
                if (FailsIsRequiredAndSizeCheck(notificationDetail.CreateDate, Constants.DATE_MAX_LENGTH))
                {
                    valid = false;
                    logMessage.AppendFormat(" CreateDate is invalid. Was: {0}{1}", notificationDetail.CreateDate,
                        Environment.NewLine);
                }
                if (FailsIsRequiredAndSizeCheck(notificationDetail.CreateTime, Constants.TIME_MAX_LENGTH))
                {
                    valid = false;
                    logMessage.AppendFormat(" CreateTime is invalid. Was: {0}{1}", notificationDetail.CreateTime,
                        Environment.NewLine);
                }
                if (FailsNotRequiredAndSizeCheck(notificationDetail.IncidentID, Constants.INCIDENT_ID_MAX_LENGTH))
                {
                    valid = false;
                    logMessage.AppendFormat(" IncidentID is invalid. Was: {0}{1}", notificationDetail.IncidentID,
                        Environment.NewLine);
                }
                if (FailsNotRequiredAndSizeCheck(notificationDetail.LongText, Constants.LONG_TEXT_MAX_LENGTH))
                {
                    valid = false;
                    logMessage.AppendFormat(" LongText is invalid. Was: {0}{1}", notificationDetail.LongText,
                        Environment.NewLine);
                }

                if (notificationDetail.Tasks != null)
                {
                    foreach (var notificationTasks in notificationDetail.Tasks)
                    {
                        if (FailsIsRequiredAndSizeCheck(notificationTasks.TaskCode, Constants.TASK_CODE_MAX_LENGTH))
                        {
                            valid = false;
                            logMessage.AppendFormat(" TaskCode is invalid. Was: {0}{1}", notificationTasks.TaskCode,
                                Environment.NewLine);
                        }
                        if (FailsIsRequiredAndSizeCheck(notificationTasks.TaskCodeText,
                            Constants.TASK_CODE_TEXT_MAX_LENGTH))
                        {
                            valid = false;
                            logMessage.AppendFormat(" TaskCodeText is invalid. Was: {0}{1}",
                                notificationTasks.TaskCodeText, Environment.NewLine);
                        }
                        if (FailsIsRequiredAndSizeCheck(notificationTasks.TaskText, Constants.TASK_TEXT_MAX_LENGTH))
                        {
                            valid = false;
                            logMessage.AppendFormat(" TaskText is invalid. Was: {0}{1}", notificationTasks.TaskText,
                                Environment.NewLine);
                        }
                        if (FailsIsRequiredAndSizeCheck(notificationTasks.Creator, Constants.CREATOR_MAX_LENGTH))
                        {
                            valid = false;
                            logMessage.AppendFormat(" Creator is invalid. Was: {0}{1}", notificationTasks.Creator,
                                Environment.NewLine);
                        }
                        if (FailsIsRequiredAndSizeCheck(notificationTasks.CreationDate, Constants.DATE_MAX_LENGTH))
                        {
                            valid = false;
                            logMessage.AppendFormat(" CreationDate is invalid. Was: {0}{1}",
                                notificationTasks.CreationDate, Environment.NewLine);
                        }
                        if (FailsIsRequiredAndSizeCheck(notificationTasks.PlannedStartDate, Constants.DATE_MAX_LENGTH))
                        {
                            valid = false;
                            logMessage.AppendFormat(" PlannedStartDate is invalid. Was: {0}{1}",
                                notificationTasks.PlannedStartDate, Environment.NewLine);
                        }
                        if (FailsIsRequiredAndSizeCheck(notificationTasks.PlannedStartTime, Constants.TIME_MAX_LENGTH))
                        {
                            valid = false;
                            logMessage.AppendFormat(" PlannedStartTime is invalid. Was: {0}{1}",
                                notificationTasks.PlannedStartTime, Environment.NewLine);
                        }
                        if (FailsIsRequiredAndSizeCheck(notificationTasks.PlannedFinishDate, Constants.DATE_MAX_LENGTH))
                        {
                            valid = false;
                            logMessage.AppendFormat(" PlannedFinishDate is invalid. Was: {0}{1}",
                                notificationTasks.PlannedFinishDate, Environment.NewLine);
                        }
                        if (FailsIsRequiredAndSizeCheck(notificationTasks.PlannedFinishTime, Constants.TIME_MAX_LENGTH))
                        {
                            valid = false;
                            logMessage.AppendFormat(" PlannedFinishTime is invalid. Was: {0}{1}",
                                notificationTasks.PlannedFinishDate, Environment.NewLine);
                        }
                        if (FailsNotRequiredAndSizeCheck(notificationTasks.ExceptionText,
                            Constants.EXCEPTION_TEXT_MAX_LENGTH))
                        {
                            valid = false;
                            logMessage.AppendFormat(" ExceptionText is invalid. Was: {0}{1}",
                                notificationTasks.ExceptionText, Environment.NewLine);
                        }
                        if (FailsNotRequiredAndSizeCheck(notificationTasks.ContactPerson,
                            Constants.CONTACT_PERSON_MAX_LENGTH))
                        {
                            valid = false;
                            logMessage.AppendFormat(" ContactPerson is invalid. Was: {0}{1}",
                                notificationTasks.ContactPerson, Environment.NewLine);
                        }
                    }
                }
                if (!valid)
                {
                    logger.Error(logMessage.ToString());
                    result = false;
                }
            }

            return result;
        }
    }
}