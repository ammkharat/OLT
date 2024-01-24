using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Restriction
{
    [Serializable]
    public class DeviationAlertResponse : DomainObject
    {
        private readonly DateTime createdDateTime;

        private readonly List<DeviationAlertResponseReasonCodeAssignment> reasonCodeAssignments =
            new List<DeviationAlertResponseReasonCodeAssignment>();

        private string comments;
        private User lastModifiedBy;
        private DateTime lastModifiedDateTime;

        public DeviationAlertResponse(
            string comments,
            User lastModifiedBy,
            DateTime lastModifiedDateTime,
            DateTime createdDateTime)
        {
            this.comments = comments;
            this.lastModifiedBy = lastModifiedBy;
            this.lastModifiedDateTime = lastModifiedDateTime;
            this.createdDateTime = createdDateTime;
        }

        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public List<DeviationAlertResponseReasonCodeAssignment> ReasonCodeAssignments
        {
            get { return reasonCodeAssignments; }
        }

        public User LastModifiedBy
        {
            get { return lastModifiedBy; }
            set { lastModifiedBy = value; }
        }

        public DateTime LastModifiedDateTime
        {
            get { return lastModifiedDateTime; }
            set { lastModifiedDateTime = value; }
        }

        public DateTime CreatedDateTime
        {
            get { return createdDateTime; }
        }

        public static int GetTotalAssignedAmount(List<DeviationAlertResponseReasonCodeAssignment> assignments)
        {
            var total = 0;
            assignments.ForEach(assignment => total += assignment.AssignedAmount);
            return total;
        }

        public DeviationAlertResponseHistory TakeSnapshot()
        {
            return new DeviationAlertResponseHistory(
                IdValue,
                RenderReasonCodes(),
                comments,
                lastModifiedBy,
                lastModifiedDateTime);
        }

        private string RenderReasonCodes()
        {
            var sb = new StringBuilder();
            if (reasonCodeAssignments != null)
            {
                var sortedList =
                    new List<DeviationAlertResponseReasonCodeAssignment>(reasonCodeAssignments);
                sortedList.Sort(SortAssignments);

                for (var i = 0; i < sortedList.Count; i++)
                {
                    var assignment = sortedList[i];

                    var reasonCodeString = String.Format(
                        StringResources.DeviationAlertReasonCodeRendering,
                        assignment.RestrictionLocationItem != null
                            ? assignment.RestrictionLocationItem.Name
                            : StringResources.NotApplicable,
                        assignment.PlantState,
                        assignment.FunctionalLocation.FullHierarchy,
                        assignment.RestrictionReasonCode.Name,
                        assignment.AssignedAmount,
                        assignment.Comments);

                    if (i > 0)
                    {
                        sb.Append(", ");
                    }
                    sb.Append(reasonCodeString);
                }
            }
            return sb.ToString();
        }

        private static int SortAssignments(DeviationAlertResponseReasonCodeAssignment x,
            DeviationAlertResponseReasonCodeAssignment y)
        {
            {
                var compareResult = String.Compare(x.FunctionalLocation.FullHierarchy,
                    y.FunctionalLocation.FullHierarchy, StringComparison.CurrentCultureIgnoreCase);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }
            {
                var compareResult = String.Compare(x.RestrictionReasonCode.Name, y.RestrictionReasonCode.Name,
                    StringComparison.CurrentCultureIgnoreCase);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }
            {
                var compareResult = x.AssignedAmount.CompareTo(y.AssignedAmount);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }
            return 0;
        }
    }
}