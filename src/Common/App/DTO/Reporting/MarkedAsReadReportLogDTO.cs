using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    [Serializable]
    public class MarkedAsReadReportLogDTO
    {
        public const string STANDARD_LOG_TYPE_TEXT = "Log";
        public const string DAILY_DIRECTIVE_LOG_TYPE_TEXT = "Daily Directive";
        public const string SUMMARY_LOG_TYPE_TEXT = "Shift Summary";

        private readonly string comments;

        private readonly string functionalLocations;
        private readonly string lastModifiedByFullNameWithUserName;
        private readonly string logType;
        private readonly DateTime loggedDateTime;
        private readonly List<ItemReadBy> readByUsers = new List<ItemReadBy>();
        private readonly string shift;

        public MarkedAsReadReportLogDTO(
            string logType,
            DateTime loggedDateTime,
            string shift,
            string functionalLocations,
            string lastModifiedByFullNameWithUserName,
            string comments,
            List<ItemReadBy> readByUsers)
        {
            this.logType = logType;
            this.loggedDateTime = loggedDateTime;
            this.shift = shift;
            this.lastModifiedByFullNameWithUserName = lastModifiedByFullNameWithUserName;
            this.comments = comments;

            this.functionalLocations = functionalLocations;
            this.readByUsers = readByUsers ?? new List<ItemReadBy>();
        }

        public string LogType
        {
            get { return logType; }
        }

        public string LogTypeDisplay
        {
            get
            {
                string logTypeDisplay = null;

                if (LogType == STANDARD_LOG_TYPE_TEXT)
                {
                    logTypeDisplay = StringResources.ReportLogTypeDisplay_Log;
                }
                else if (LogType == DAILY_DIRECTIVE_LOG_TYPE_TEXT)
                {
                    logTypeDisplay = StringResources.ReportLogTypeDisplay_DailyDirective;
                }
                else if (LogType == SUMMARY_LOG_TYPE_TEXT)
                {
                    logTypeDisplay = StringResources.ReportLogTypeDisplay_ShiftSummary;
                }

                return logTypeDisplay;
            }
        }

        public DateTime LoggedDateTime
        {
            get { return loggedDateTime; }
        }

        public string Shift
        {
            get { return shift; }
        }

        public string FunctionalLocation
        {
            get { return functionalLocations; }
        }

        public string LastModifiedByFullNameWithUserName
        {
            get { return lastModifiedByFullNameWithUserName; }
        }

        public string Comments
        {
            get { return comments; }
        }

        public List<ItemReadBy> ReadByUsers
        {
            get { return readByUsers; }
        }

        public void AddReadByUser(ItemReadBy readByUser)
        {
            if (!readByUsers.Contains(readByUser))
            {
                readByUsers.Add(readByUser);
            }
        }
    }
}