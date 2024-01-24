using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class SafeWorkPermitAssessmentReportDTO : DomainObject
    {
        public List<string> FunctionalLocations = new List<string>();

        public SafeWorkPermitAssessmentReportDTO(long id, string site, long formNumber, int versionNumber,
            string status, string floc, string locationEquipmentNumber, DateTime permitStartDateTime,
            DateTime permitExpireDateTime, string createdBy,
            DateTime createdDateTime, string lastModifiedBy, DateTime lastModifiedDateTime, bool ilpRecommended,
            string permitNumber, string permitType, bool issuedToSuncor, bool issuedToContractor, string contractor,
            string trade, string jobCoordinator, string jobDescription, string section, int questionNumber,
            string question, int score, int weight, int overallScore, int sectionWeightPercentage,
            int sectionScorePercentage, int totalScorePercentage, string feedback, string questionFeedback,
            int crewSize) : base(id)
        {
            Site = site;
            FormNumber = formNumber;
            VersionNumber = versionNumber;
            Status = status;
            AddFunctionalLocation(floc);
            LocationEquipmentNumber = locationEquipmentNumber;
            PermitStartDateTime = permitStartDateTime;
            PermitExpireDateTime = permitExpireDateTime;
            CreatedBy = createdBy;
            CreatedDateTime = createdDateTime;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDateTime = lastModifiedDateTime;
            IlpRecommended = ilpRecommended;
            PermitNumber = permitNumber;
            PermitType = permitType;
            IssuedToSuncor = issuedToSuncor;
            IssuedToContractor = issuedToContractor;
            Contractor = contractor;
            Trade = trade;
            JobCoordinator = jobCoordinator;
            JobDescription = jobDescription;
            Section = section;
            QuestionNumber = questionNumber;
            Question = question;
            Score = score;
            Weight = weight;
            OverallScore = overallScore;
            SectionWeightPercentage = sectionWeightPercentage;
            SectionScorePercentage = sectionScorePercentage;
            TotalScorePercentage = totalScorePercentage;
            Feedback = feedback;
            QuestionFeedback = questionFeedback;
            CrewSize = crewSize;
        }

        public string Site { get; set; }
        public long FormNumber { get; set; }
        public int VersionNumber { get; set; }
        public int CrewSize { get; set; }
        public string Status { get; set; }

        public string Floc
        {
            get { return FunctionalLocations.ToCommaSeparatedString(); }
        }

        public string LocationEquipmentNumber { get; set; }
        public DateTime PermitStartDateTime { get; set; }
        public DateTime PermitExpireDateTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public bool IlpRecommended { get; set; }
        public string PermitNumber { get; set; }
        public string PermitType { get; set; }
        public bool IssuedToSuncor { get; set; }
        public bool IssuedToContractor { get; set; }
        public string Contractor { get; set; }
        public string Trade { get; set; }
        public string JobCoordinator { get; set; }
        public string JobDescription { get; set; }
        public string Section { get; set; }
        public int QuestionNumber { get; set; }
        public string Question { get; set; }
        public int Score { get; set; }
        public int Weight { get; set; }
        public int OverallScore { get; set; }
        public int SectionWeightPercentage { get; set; }
        public int SectionScorePercentage { get; set; }
        public int TotalScorePercentage { get; set; }
        public string Feedback { get; set; }
        public string QuestionFeedback { get; set; }

        public void AddFunctionalLocation(string functionalLocationName)
        {
            FunctionalLocations.AddAndSort(functionalLocationName);
        }
    }
}