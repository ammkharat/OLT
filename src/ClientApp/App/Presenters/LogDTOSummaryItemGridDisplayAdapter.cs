using System;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class LogDTOSummaryItemGridDisplayAdapter : IShiftSummaryItemGridDisplayAdapter
    {
        private readonly LogDTO logDTO;

        public LogDTOSummaryItemGridDisplayAdapter(LogDTO logDTO)
        {
            this.logDTO = logDTO;
        }

        public ShiftSummaryItemType ItemType { get { return ShiftSummaryItemType.Log; } }

        public ShiftSummaryItemSource Source
        {
            get
            {
                if (logDTO.DataSource == DataSource.ACTION_ITEM)
                {
                    return ShiftSummaryItemSource.ActionItemResponse;
                }

                if (logDTO.DataSource == DataSource.HANDOVER)
                {
                    return ShiftSummaryItemSource.HandoverLog;
                }

                if (logDTO.DataSource == DataSource.LAB_ALERT)
                {
                    return ShiftSummaryItemSource.LabAlertResponse;
                }

                if (logDTO.DataSource == DataSource.PERMIT)
                {
                    return ShiftSummaryItemSource.SafeWorkPermit;
                }

                if (logDTO.DataSource == DataSource.SAP)
                {
                    return ShiftSummaryItemSource.SapNotificationLog;
                }

                if (logDTO.DataSource == DataSource.TARGET)
                {
                    return ShiftSummaryItemSource.TargetAlertResponse;
                }

                return ShiftSummaryItemSource.ShiftLog;
            }
        }

        public string FunctionalLocationNames
        {
            get { return logDTO.FunctionalLocationNames; }
        }

        public DateTime LoggedDateTime
        {
            get { return logDTO.LogDateTime; }
        }

        public string CreatedBy
        {
            get { return logDTO.CreatedByFullnameWithUserName; }
        }

        public string WorkAssignmentName
        {
            get { return logDTO.WorkAssignmentName; }
        }

        public string RecommendedForSummary
        {
            get { return logDTO.RecommendForShiftSummary ? StringResources.Yes : StringResources.No; }
        }

        public string AllComments
        {
            get { return logDTO.Comments; }
        }

        public bool IncludeInSummary { get; set; }

        public LogDTO GetLogDTO()
        {
            return logDTO;
        }

        public static int CompareByLoggedDateTime(LogDTOSummaryItemGridDisplayAdapter a1, LogDTOSummaryItemGridDisplayAdapter a2)
        {
            return a1.LoggedDateTime.CompareTo(a2.LoggedDateTime);
        }
    }
}
