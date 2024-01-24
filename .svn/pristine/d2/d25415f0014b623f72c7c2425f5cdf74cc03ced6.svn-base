using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.ShiftHandover
{
    [Serializable]
    public class ShiftHandoverQuestionnaireHistory : DomainObjectHistorySnapshot
    {
        public ShiftHandoverQuestionnaireHistory(
            long id,
            string functionalLocations,
            List<ShiftHandoverAnswerHistory> answers,
            User lastModifiedBy,
            DateTime lastModifiedDate) : base(id, lastModifiedBy, lastModifiedDate)
        {
            FunctionalLocations = functionalLocations;
            Answers = answers;
        }

        public string FunctionalLocations { get; private set; }

        public List<ShiftHandoverAnswerHistory> Answers { get; private set; }
    }
}