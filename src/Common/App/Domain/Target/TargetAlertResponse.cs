using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    /// <summary>
    ///     For responding to a target alert.
    /// </summary>
    [Serializable]
    public class TargetAlertResponse : DomainObject
    {
        public TargetAlertResponse(TargetAlert targetAlert, string responseText, User currentUser,
            DateTime createdDateTime, ShiftPattern createdShiftPattern)
            : this(
                targetAlert, new Comment(currentUser, createdDateTime, responseText), TargetGapReason.Null, null,
                createdShiftPattern)
        {
        }

        public TargetAlertResponse(TargetAlert targetAlert, Comment comment, TargetGapReason gapReason,
            FunctionalLocation functionalLocationResponsibleForGap,
            ShiftPattern createdShiftPattern)
        {
            Alert = targetAlert;
            ResponseComment = comment;
            GapReason = gapReason;
            ResponsibleForGap = functionalLocationResponsibleForGap;
            CreatedInShiftPattern = createdShiftPattern;
        }

        [CachedRelationship]
        public TargetAlert Alert { get; private set; }

        public TargetGapReason GapReason { get; set; }

        public FunctionalLocation ResponsibleForGap { get; set; }

        public ShiftPattern CreatedInShiftPattern { get; set; }

        public Comment ResponseComment { get; set; }

        public Log CreateLog(
            User currentUser,
            bool isOperationalEngineerLog,
            ShiftPattern shiftPattern,
            DateTime timeAtSite,
            Role userCurrentRole,
            WorkAssignment workAssignment)
        {
            long? rootLogId = null;
            long? replyToLogId = null;
            const LogDefinition logDefinition = null;
            var source = DataSource.TARGET;
            var functionalLocation = Alert.FunctionalLocation;
            const bool inspectionFollowUp = false;
            const bool processControlFollowUp = false;
            const bool operationsFollowUp = false;
            const bool supervisionFollowUp = false;
            const bool environmentalHealthSafetyFollowUp = false;
            const bool otherFollowUp = false;
            var comments = CreateLogText();
            var loggedDateTime = timeAtSite;
            var createdBy = currentUser;
            var lastModifiedBy = currentUser;
            var lastModifiedDate = timeAtSite;
            var createdDateTime = timeAtSite;
            const bool hasChildren = false;

            var log = new Log(rootLogId,
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
                comments,
                comments,
                loggedDateTime,
                shiftPattern,
                createdBy,
                lastModifiedBy,
                lastModifiedDate,
                createdDateTime,
                hasChildren,
                isOperationalEngineerLog,
                userCurrentRole,
                LogType.Standard,
                workAssignment);
            return log;
        }

        private string CreateLogText()
        {
            var result = GapReason == null
                ? string.Format(StringResources.TargetAlertResponseLogWithNoReasonTemplate, Alert.Id,
                    ResponseComment.Text)
                : string.Format(StringResources.TargetAlertResponseLogWithReasonTemplate, Alert.Id, GapReason.Name,
                    ResponseComment.Text);

            if (ResponsibleForGap != null)
            {
                result = result + Environment.NewLine + StringResources.TargetAlertResponseLogText_FLOCThatCausedGap +
                         ResponsibleForGap.FullHierarchyWithDescription;
            }

            return result;
        }
    }
}