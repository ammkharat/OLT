using System;
using System.Text;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.LabAlert
{
    [Serializable]
    public class LabAlertResponse : DomainObject
    {
        public LabAlertResponse(long? id, long labAlertId, LabAlertStatus status, string comments, User createdByUser,
            DateTime createdDateTime)
        {
            this.id = id;
            LabAlertId = labAlertId;
            Status = status;
            Comments = comments;
            CreatedByUser = createdByUser;
            CreatedDateTime = createdDateTime;
        }

        public long LabAlertId { get; private set; }

        public LabAlertStatus Status { get; private set; }

        public string Comments { get; private set; }

        public User CreatedByUser { get; private set; }

        public DateTime CreatedDateTime { get; private set; }

        public string StatusName
        {
            get { return Status.Name; }
        }

        public string CreatedByUserFullNameWithUserName
        {
            get { return CreatedByUser.FullNameWithUserName; }
        }

        //public static List<LogComment> BuildLogComments( // CCTODO
        //    LabAlert alert, string responseComments, LabAlertStatus originalStatus, 
        //        LabAlertStatus newStatus, CommentCategory defaultLogCategory)
        //{
        //    string text = BuildLogComments(alert, responseComments, originalStatus, newStatus);
        //    return new List<LogComment> { new LogComment(null, defaultLogCategory.IdValue, defaultLogCategory.Name, text) };
        //}

        public static string BuildLogComments(LabAlert alert, string responseComments,
            LabAlertStatus originalStatus, LabAlertStatus newStatus)
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format(StringResources.LabAlertResponseLogComments_Name, alert.Name));
            sb.AppendLine(string.Format(StringResources.LabAlertResponseLogComments_Description, alert.Description));
            sb.AppendLine(string.Format(StringResources.LabAlertResponseLogComments_ActualNumberOfSamples,
                alert.ActualNumberOfSamples));
            sb.AppendLine(string.Format(StringResources.LabAlertResponseLogComments_FunctionalLocation,
                alert.FunctionalLocation.FullHierarchyWithDescription));
            sb.AppendLine(string.Format(StringResources.LabAlertResponseLogComments_ResponseComments, responseComments));
            sb.AppendLine(string.Format(StringResources.LabAlertResponseLogComments_Tag,
                alert.TagInfo.NameAndDescription));
            sb.AppendLine(string.Format(StringResources.LabAlertResponseLogComments_Schedule, alert.ScheduleDescription));
            sb.AppendLine(string.Format(StringResources.LabAlertResponseLogComments_WhenToCheck,
                alert.WhenToCheckDescription));
            sb.AppendLine(string.Format(StringResources.LabAlertResponseLogComments_PreviousStatus, originalStatus));
            sb.AppendLine(string.Format(StringResources.LabAlertResponseLogComments_NewStatus, newStatus));

            return sb.ToString();
        }
    }
}