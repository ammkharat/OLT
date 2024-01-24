using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    [Serializable]
    public class TargetAlertResponseReportDetailDTO : ComparableObject
    {
        private readonly string commentText;
        private readonly User responseBy;
        private readonly DateTime responseDateTime;
        private readonly TargetGapReason targetGapReason;

        public TargetAlertResponseReportDetailDTO(User responseBy, DateTime responseDateTime, string commentText,
            TargetGapReason targetGapReason)
        {
            this.responseBy = responseBy;
            this.responseDateTime = responseDateTime;
            this.commentText = commentText;
            this.targetGapReason = targetGapReason;
        }

        public User ResponseBy
        {
            get { return responseBy; }
        }

        public DateTime ResponseDateTime
        {
            get { return responseDateTime; }
        }

        public string CommentText
        {
            get { return commentText; }
        }

        public TargetGapReason TargetGapReason
        {
            get { return targetGapReason; }
        }
    }
}