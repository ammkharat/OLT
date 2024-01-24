using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class PermitAssessmentHistory : BaseFormHistory
    {
        public PermitAssessmentHistory(long? id,
            DateTime permitStartDateTime,
            DateTime permitExpiredDateTime,
            FormStatus formStatus,
            User lastModifiedBy,
            DateTime lastModifiedDateTime,
            bool issuedToSuncor,
            bool issuedToContractor,
            string contractor,
            string trade,
            int crewSize,
            OilsandsWorkPermitType oilsandsWorkPermitType,
            string permitNumber,
            string locationEquipmentNumber,
            decimal totalScoredPercentage,
            int totalAnswerScore,
            int totalAnswerWeightedScore,
            int totalQuestionnaireWeight,
            string jobDescription,
            string overallFeedback,
            string jobCoordinator,
            bool? isIlpRecommended,
            string functionalLocations,
            string documentLinks,
            List<PermitAssessmentAnswerHistory> answers)
            : base(
                id.Value, formStatus, permitStartDateTime, permitExpiredDateTime, lastModifiedBy, lastModifiedDateTime)
        {
            FunctionalLocations = functionalLocations;
            DocumentLinks = documentLinks;
            Answers = answers;
            CrewSize = crewSize;
            IssuedToSuncor = issuedToSuncor;
            IssuedToContractor = issuedToContractor;
            Contractor = contractor;
            Trade = trade;
            OilsandsWorkPermitType = oilsandsWorkPermitType;
            PermitNumber = permitNumber;
            LocationEquipmentNumber = locationEquipmentNumber;
            TotalScoredPercentage = totalScoredPercentage;
            TotalAnswerScore = totalAnswerScore;
            TotalAnswerWeightedScore = totalAnswerWeightedScore;
            TotalQuestionnaireWeight = totalQuestionnaireWeight;
            JobDescription = jobDescription;
            OverallFeedback = overallFeedback;
            JobCoordinator = jobCoordinator;
            IsIlpRecommended = isIlpRecommended;
        }

        public string FunctionalLocations { get; private set; }

        public string DocumentLinks { get; private set; }

        public List<PermitAssessmentAnswerHistory> Answers { get; private set; }

        public int CrewSize { get; set; }

        public bool IssuedToSuncor { get; set; }

        public bool? IsIlpRecommended { get; set; }

        public bool IssuedToContractor { get; set; }

        public string Contractor { get; set; }

        public string Trade { get; set; }

        public OilsandsWorkPermitType OilsandsWorkPermitType { get; set; }

        public string PermitNumber { get; set; }

        public decimal TotalScoredPercentage { get; set; }

        public int TotalQuestionnaireWeight { get; set; }

        public int TotalAnswerScore { get; set; }

        public int TotalAnswerWeightedScore { get; set; }

        public string JobDescription { get; set; }

        public string OverallFeedback { get; set; }

        public string LocationEquipmentNumber { get; set; }

        public string JobCoordinator { get; set; }
    }
}