using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class SAPNotificationDTO : DomainObject
    {
        private readonly DateTime creationDateTime;
        private readonly string description;
        private readonly string functionalLocationName;
        private readonly string incidentID;
        private readonly bool isProcessed;
        private readonly string notificationNumber;
        private readonly string notificationType;
        private readonly string shortText;

        public SAPNotificationDTO(long id,
            string description,
            string functionalLocationName,
            string notificationType,
            string notificationNumber,
            DateTime creationDateTime,
            bool isProcessed,
            string shortText,
            string incidentID)
        {
            this.id = id;
            this.description = description;
            this.functionalLocationName = functionalLocationName;
            this.notificationType = notificationType;
            this.notificationNumber = notificationNumber;
            this.creationDateTime = creationDateTime;
            this.isProcessed = isProcessed;
            this.shortText = shortText;
            this.incidentID = incidentID;
        }

        public SAPNotificationDTO(SAPNotification sapNotification) : this(
            sapNotification.Id.Value,
            sapNotification.Description,
            sapNotification.FunctionalLocation.FullHierarchy,
            sapNotification.NotificationType,
            sapNotification.NotificationNumber,
            sapNotification.CreationDateTime,
            sapNotification.IsProcessed,
            sapNotification.ShortText,
            sapNotification.IncidentId)
        {
        }

        [IncludeInSearch]
        public string FunctionalLocationName
        {
            get { return functionalLocationName; }
        }

        public string ShortText
        {
            get { return shortText; }
        }

        [IncludeInSearch]
        public string IncidentID
        {
            get { return incidentID; }
        }

        [IncludeInSearch]
        public string Description
        {
            get { return description; }
        }

        [IncludeInSearch]
        public string NotificationType
        {
            get { return notificationType; }
        }

        [IncludeInSearch]
        public DateTime CreationDateTime
        {
            get { return creationDateTime; }
        }

        [IncludeInSearch]
        public string NotificationNumber
        {
            get { return notificationNumber; }
        }

        public bool IsProcessed
        {
            get { return isProcessed; }
        }

        [IncludeInSearch]
        public string IsProcessedDisplay
        {
            get { return isProcessed ? "Yes" : "No"; }
        }
    }
}