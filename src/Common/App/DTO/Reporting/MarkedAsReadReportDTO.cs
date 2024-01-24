using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    [Serializable]
    public class MarkedAsReadReportDTO
    {
        private readonly List<MarkedAsReadReportLogDTO> directiveLogs = new List<MarkedAsReadReportLogDTO>();

        private readonly List<MarkedAsReadReportDirectiveDTO> directives = new List<MarkedAsReadReportDirectiveDTO>();
        private readonly List<MarkedAsReadReportLogDTO> logs = new List<MarkedAsReadReportLogDTO>();

        private readonly List<MarkedAsReadReportShiftHandoverQuestionnaireDTO> shiftHandoverQuestionnaires =
            new List<MarkedAsReadReportShiftHandoverQuestionnaireDTO>();

        private readonly List<MarkedAsReadReportLogDTO> summaryLogs = new List<MarkedAsReadReportLogDTO>();

        public List<MarkedAsReadReportLogDTO> Logs
        {
            get { return logs; }
        }

        public List<MarkedAsReadReportLogDTO> DirectiveLogs
        {
            get { return directiveLogs; }
        }

        public List<MarkedAsReadReportLogDTO> SummaryLogs
        {
            get { return summaryLogs; }
        }

        public List<MarkedAsReadReportShiftHandoverQuestionnaireDTO> ShiftHandoverQuestionnaires
        {
            get { return shiftHandoverQuestionnaires; }
        }

        public List<MarkedAsReadReportDirectiveDTO> Directives
        {
            get { return directives; }
        }
    }
}