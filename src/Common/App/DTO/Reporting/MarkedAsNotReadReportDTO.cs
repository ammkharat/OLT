using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
     [Serializable]
    public class MarkedAsNotReadReportDTO
    {

        private readonly List<MarkedAsNotReadReportLogDTO> directiveLogs = new List<MarkedAsNotReadReportLogDTO>();

        private readonly List<MarkedAsNotReadReportDirectiveDTO> directives = new List<MarkedAsNotReadReportDirectiveDTO>();
        private readonly List<MarkedAsNotReadReportLogDTO> logs = new List<MarkedAsNotReadReportLogDTO>();

        private readonly List<MarkedAsNotReadReportLogDTO> summaryLogs = new List<MarkedAsNotReadReportLogDTO>();
        private readonly List<MarkedAsNotReadReportShiftHandoverQuestionnaireDTO> shiftHandoverQuestionnaires =
          new List<MarkedAsNotReadReportShiftHandoverQuestionnaireDTO>();
        public List<MarkedAsNotReadReportLogDTO> Logs
        {
            get { return logs; }
        }

        public List<MarkedAsNotReadReportLogDTO> DirectiveLogs
        {
            get { return directiveLogs; }
        }

        public List<MarkedAsNotReadReportLogDTO> SummaryLogs
        {
            get { return summaryLogs; }
        }

        public List<MarkedAsNotReadReportShiftHandoverQuestionnaireDTO> ShiftHandoverQuestionnaires
        {
            get { return shiftHandoverQuestionnaires; }
        }

        public List<MarkedAsNotReadReportDirectiveDTO> Directives
        {
            get { return directives; }
        }
         
    }
}
