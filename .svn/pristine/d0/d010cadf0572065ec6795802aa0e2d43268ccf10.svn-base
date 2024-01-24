using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Domain.ShiftHandover
{
    [Serializable]
    public class ShiftHandoverQuestionnaireAssocations
    {
        private readonly CokerCardInfoForShiftHandoverDTO cokerCard;
        private readonly List<HasCommentsDTO> logs;
        private readonly List<HasCommentsDTO> summaryLogs;

        public ShiftHandoverQuestionnaireAssocations(List<HasCommentsDTO> logs, List<HasCommentsDTO> summaryLogs,
            CokerCardInfoForShiftHandoverDTO cokerCard)
        {
            this.logs = logs;
            this.summaryLogs = summaryLogs;
            this.cokerCard = cokerCard;
        }

        public List<HasCommentsDTO> Logs
        {
            get { return logs; }
        }

        public List<HasCommentsDTO> SummaryLogs
        {
            get { return summaryLogs; }
        }

        public CokerCardInfoForShiftHandoverDTO CokerCard
        {
            get { return cokerCard; }
        }


    }
}