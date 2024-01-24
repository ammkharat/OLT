using System;
using System.Collections.Generic;
using System.IO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    ///     The temporary notification associated with an imported SAP notification
    /// </summary>
    [Serializable]
    public class SAPNotification : DomainObject, IFunctionalLocationRelevant
    {
        private const string formatString = "{0}: {1}";
        private readonly string description;
        private readonly FunctionalLocation functionalLocation;
        private readonly string incidentId;
        private readonly string longText;
        private readonly string notificationNumber;
        private readonly string notificationType;
        private readonly string shortText;
        private string comments;
        private DateTime creationDateTime;
        private bool isProcessed;

        public SAPNotification(FunctionalLocation functionalLocation, string description, string notificationType,
            string shortText, string longText,
            string incidentId, DateTime creationDateTime, string notificationNumber, bool isProcessed)
        {
            this.functionalLocation = functionalLocation;
            this.description = description;
            this.notificationType = notificationType;
            this.shortText = shortText;
            this.longText = longText;
            this.incidentId = incidentId;
            this.creationDateTime = creationDateTime;
            this.notificationNumber = notificationNumber;
            this.isProcessed = isProcessed;
        }

        public SAPNotification(long? id, FunctionalLocation functionalLocation, string description,
            string notificationType, string shortText, string longText,
            string incidentId, DateTime creationDateTime, string notificationNumber, bool isProcessed, string comments)
            : this(
                functionalLocation, description, notificationType, shortText, longText, incidentId, creationDateTime,
                notificationNumber, isProcessed)
        {
            this.id = id;
            this.comments = comments;
        }

        /// <summary>
        ///     Notification Description
        /// </summary>
        public string ShortText
        {
            get { return shortText; }
        }

        /// <summary>
        ///     Notification Details
        /// </summary>
        public string LongText
        {
            get { return longText; }
        }

        /// <summary>
        ///     Incident ID
        /// </summary>
        public string IncidentId
        {
            get { return incidentId; }
        }

        /// <summary>
        ///     Has this notification been processed?
        /// </summary>
        public bool IsProcessed
        {
            get { return isProcessed; }
        }

        /// <summary>
        ///     Functional Location associated with the Notification
        /// </summary>
        public FunctionalLocation FunctionalLocation
        {
            get { return functionalLocation; }
        }

        /// <summary>
        ///     Description of the Notification
        /// </summary>
        public string Description
        {
            get { return description; }
        }

        /// <summary>
        ///     User comments on the Notification
        /// </summary>
        public string Comments
        {
            get { return comments; }
        }

        /// <summary>
        ///     Type of Notification
        /// </summary>
        public string NotificationType
        {
            get { return notificationType; }
        }

        /// <summary>
        ///     Creation Date and Time of the Notification
        /// </summary>
        public DateTime CreationDateTime
        {
            get { return creationDateTime; }
        }

        /// <summary>
        ///     Notification Number
        /// </summary>
        public string NotificationNumber
        {
            get { return notificationNumber; }
        }

        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies,SiteConfiguration siteConfiguration)
        {
            return new ExactMatchRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                   new WalkDownRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies);
        }

        /// <summary>
        ///     Create a new log from an existing SAP notification object
        /// </summary>
        public Log CreateLogFromNotification(
            User currentUser,
            ShiftPattern creationUserShiftPattern,
            bool isOperatingEngineerLog,
            DateTime loggedDateTime,
            Role userCurrentRole,
            WorkAssignment workAssignment)
        {
            if (userCurrentRole == null)
            {
                throw new ArgumentException(string.Format("Unexpected user with no position:<{0}>", currentUser),
                    "currentUser");
            }

            long? rootLogId = null;
            long? replyToLogId = null;
            const LogDefinition logDefinition = null;
            var source = DataSource.SAP;
            const bool inspectionFollowUp = false;
            const bool processControlFollowUp = false;
            const bool operationsFollowUp = false;
            const bool supervisionFollowUp = false;
            const bool environmentalHealthSafetyFollowUp = false;
            const bool otherFollowUp = false;
            var logDescription = BuildAndFormatLogDescription();
            var createdBy = currentUser;
            var lastModifiedBy = currentUser;
            var lastModifiedDate = loggedDateTime;
            var createdDateTime = loggedDateTime;
            const bool hasChildren = false;

            return new Log(rootLogId,
                replyToLogId,
                logDefinition,
                source,
                new List<FunctionalLocation> {functionalLocation},
                inspectionFollowUp,
                processControlFollowUp,
                operationsFollowUp,
                supervisionFollowUp,
                environmentalHealthSafetyFollowUp,
                otherFollowUp,
                logDescription,
                logDescription,
                loggedDateTime,
                creationUserShiftPattern,
                createdBy,
                lastModifiedBy,
                lastModifiedDate,
                createdDateTime,
                hasChildren,
                isOperatingEngineerLog,
                userCurrentRole,
                LogType.Standard,
                workAssignment);
        }

        public string BuildAndFormatLogDescription()
        {
            using (var sb = new StringWriter())
            {
                if (comments != null)
                {
                    sb.WriteLine(comments.Trim());
                    sb.WriteLine();
                }
                sb.WriteLine(formatString, StringResources.SAPNotificationLogDescriptionPrefix_SAPNotificationNumber,
                    notificationNumber);
                sb.WriteLine(formatString, StringResources.SAPNotificationLogDescriptionPrefix_NotificationType,
                    notificationType);
                sb.WriteLine(formatString, StringResources.SAPNotificationLogDescriptionPrefix_IncidentId, incidentId);
                sb.WriteLine(formatString, StringResources.SAPNotificationLogDescriptionPrefix_CreateDateTime,
                    creationDateTime.ToLongDateAndTimeString());
                sb.WriteLine(formatString, StringResources.SAPNotificationLogDescriptionPrefix_Description, string.Empty);
                sb.Write(description);

                return sb.ToString();
            }
        }

        public void Processed()
        {
            isProcessed = true;
        }

        public void PrependNewComments(string newComments, DateTime updatedDateTime)
        {
            creationDateTime = updatedDateTime;
            comments = newComments + Environment.NewLine + comments;
        }
    }
}