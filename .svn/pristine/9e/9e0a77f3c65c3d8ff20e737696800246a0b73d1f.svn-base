using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class DailyShiftTargetAlertReportAdapter : AbstractLocalizedReportAdapter, IReportAdapter
    {
        private static readonly string LIMIT_EXCEEDED_NEVER_TO_EXCEED_MAX =
            StringResources.DailyShiftAlertLimitExceededDescription_NeverToExceedMax;

        private static readonly string LIMIT_EXCEEDED_NEVER_TO_EXCEED_MIN =
            StringResources.DailyShiftAlertLimitExceededDescription_NeverToExceedMin;

        private static readonly string LIMIT_EXCEEDED_STANDARD_MAX =
            StringResources.DailyShiftAlertLimitExceededDescription_StandardMax;

        private static readonly string LIMIT_EXCEEDED_STANDARD_MIN =
            StringResources.DailyShiftAlertLimitExceededDescription_StandardMin;

        private static readonly string LIMIT_EXCEEDED_UNKNOWN =
            StringResources.DailyShiftAlertLimitExceededDescription_Unknown;

        public DailyShiftTargetAlertReportAdapter(TargetAlertReportDetailDTO targetAlertDetails)
        {
            Id = targetAlertDetails.IdValue;
            Name = targetAlertDetails.Name;
            FiredDateTime = targetAlertDetails.CreatedDateTime.ToShortDateAndTimeString();
            TagName = targetAlertDetails.TagInfo.Name;
            TagDescription = targetAlertDetails.TagInfo.Description;

            ActualValue = targetAlertDetails.MostRecentActualValue.ToString();

            FunctionalLocationFullHierarchy = targetAlertDetails.FunctionalLocation.FullHierarchy;
            FunctionalLocationDescription = targetAlertDetails.FunctionalLocation.Description;
            ShiftStartDateTime = targetAlertDetails.UserShift.StartDateTime.ToDateString();
            ShiftName = targetAlertDetails.UserShift.ShiftPatternName;

            var thresholdEvaluation = targetAlertDetails.ThresholdEvaluation;
            if (thresholdEvaluation != null)
            {
                OriginalExceedingValue = thresholdEvaluation.ActualValueUsed.HasValue
                    ? thresholdEvaluation.ActualValueUsed.Value.ToString()
                    : string.Empty;

                var thresholdValue = thresholdEvaluation.ThresholdValue;
                LimitExceededDescription = thresholdValue.HasValue
                    ? string.Format("{0}-{1} {2}",
                        CreateLimitExceeded(thresholdEvaluation.ExcessLevel), thresholdValue.Value,
                        targetAlertDetails.TagInfo.Units)
                    : CreateLimitExceeded(thresholdEvaluation.ExcessLevel);
            }
            else
            {
                LimitExceededDescription = CreateLimitExceeded(TargetThresholdExcessLevel.None);
            }

            CreateActionAdapters(targetAlertDetails);
        }

        public List<TargetAlertActionReportAdapter> ActionAdapters { get; private set; }

        public long Id { get; private set; }
        public string Name { get; private set; }

        public string FiredDateTime { get; private set; }

        public string TagName { get; private set; }
        public string TagDescription { get; private set; }

        public string LimitExceededDescription { get; private set; }
        public string ActualValue { get; private set; }
        public string OriginalExceedingValue { get; private set; }

        public string FunctionalLocationFullHierarchy { get; private set; }
        public string FunctionalLocationDescription { get; private set; }

        public string ShiftStartDateTime { get; private set; }
        public string ShiftName { get; private set; }

        private void CreateActionAdapters(TargetAlertReportDetailDTO targetAlertDetails)
        {
            if (targetAlertDetails.AcknowledgedUser == null)
            {
                ActionAdapters = new List<TargetAlertActionReportAdapter>
                {
                    TargetAlertActionReportAdapter.CreateForNoAcknowledgedUser(targetAlertDetails)
                };
            }
            else if (targetAlertDetails.Responses.Count == 0)
            {
                ActionAdapters = new List<TargetAlertActionReportAdapter>
                {
                    TargetAlertActionReportAdapter.CreateForAcknowledgedUser(targetAlertDetails)
                };
            }
            else
            {
                ActionAdapters =
                    targetAlertDetails.Responses.ConvertAll(
                        response => TargetAlertActionReportAdapter.CreateForResponse(targetAlertDetails, response));
            }
        }

        private static string CreateLimitExceeded(TargetThresholdExcessLevel targetThresholdExcessLevel)
        {
            switch (targetThresholdExcessLevel)
            {
                case TargetThresholdExcessLevel.NeverToExceedMax:
                    return LIMIT_EXCEEDED_NEVER_TO_EXCEED_MAX;
                case TargetThresholdExcessLevel.NeverToExceedMin:
                    return LIMIT_EXCEEDED_NEVER_TO_EXCEED_MIN;
                case TargetThresholdExcessLevel.StandardMax:
                    return LIMIT_EXCEEDED_STANDARD_MAX;
                case TargetThresholdExcessLevel.StandardMin:
                    return LIMIT_EXCEEDED_STANDARD_MIN;
                case TargetThresholdExcessLevel.None:
                    return LIMIT_EXCEEDED_UNKNOWN;
                default:
                    throw new ApplicationException("Unrecognized target threshold excess level:" +
                                                   targetThresholdExcessLevel);
            }
        }
    }

    public class TargetAlertActionReportAdapter
    {
        private static readonly string ACTION_TYPE_NONE = StringResources.DailyShiftAlertActionType_None;
        private static readonly string ACTION_TYPE_CLOSED = StringResources.DailyShiftAlertActionType_Closed;
        private static readonly string ACTION_TYPE_ACKNOWLEDGE = StringResources.DailyShiftAlertActionType_Acknowledge;
        private static readonly string ACTION_TYPE_RESPONSE = StringResources.DailyShiftAlertActionType_Response;

        public TargetAlertActionReportAdapter(string actionType, string actionBy, DateTime? actionDateTime)
        {
            ActionType = actionType;
            ActionBy = actionBy;
            ActionDateTime = actionDateTime.HasValue ? actionDateTime.Value.ToShortDateAndTimeString() : string.Empty;
        }

        public string ActionType { get; private set; }
        public string ActionBy { get; private set; }
        public string ActionDateTime { get; private set; }

        public static TargetAlertActionReportAdapter CreateForNoAcknowledgedUser(
            TargetAlertReportDetailDTO targetAlertDetails)
        {
            if (targetAlertDetails.Status == TargetAlertStatus.Closed)
            {
                return new TargetAlertActionReportAdapter(ACTION_TYPE_CLOSED,
                    StringResources.DailyShiftAlertActionBySystem, targetAlertDetails.LastModifiedDateTime);
            }
            return new TargetAlertActionReportAdapter(ACTION_TYPE_NONE, StringResources.DailyShiftAlertActionByNone,
                null);
        }

        public static TargetAlertActionReportAdapter CreateForAcknowledgedUser(
            TargetAlertReportDetailDTO targetAlertDetails)
        {
            return new TargetAlertActionReportAdapter(ACTION_TYPE_ACKNOWLEDGE,
                targetAlertDetails.AcknowledgedUser.FullNameWithUserName, targetAlertDetails.AcknowledgedDateTime);
        }

        public static TargetAlertActionReportAdapter CreateForResponse(TargetAlertReportDetailDTO targetAlertDetails,
            TargetAlertResponseReportDetailDTO response)
        {
            return new TargetAlertActionReportAdapter(ACTION_TYPE_RESPONSE, response.ResponseBy.FullNameWithUserName,
                response.ResponseDateTime);
        }
    }
}