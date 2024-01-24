using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class PermitAssessment : BaseEdmontonForm, IDocumentLinksObject
    {
        private const int MaxPossibleScore = 5;

        public PermitAssessment(long? id,
            DateTime permitStartDateTime,
            DateTime permitExpiredDateTime,
            FormStatus formStatus,
            User createdBy,
            DateTime createdDateTime,
            long creationUserShiftPatternId,
            User lastModifiedBy,
            DateTime lastModifiedDateTime,
            IEnumerable<PermitAssessmentAnswer> answers = null)
            : base(id, formStatus, permitStartDateTime, permitExpiredDateTime, createdBy, createdDateTime)
        {
            DocumentLinks = new List<DocumentLink>();
            FunctionalLocations = new List<FunctionalLocation>();
            LastModifiedBy = lastModifiedBy;
            LastModifiedDateTime = lastModifiedDateTime;
            CreationUserShiftPatternId = creationUserShiftPatternId;
            Answers = new List<PermitAssessmentAnswer>();
            Answers.Clear();
            if (answers != null)
            {
                Answers.AddRange(answers);
            }

            Answers.Sort(CompareAnswersBySectionAndQuestionDisplayOrder);
        }

        public PermitAssessment(long? id,
            DateTime permitStartDateTime,
            DateTime permitExpiredDateTime,
            FormStatus formStatus,
            User createdBy,
            DateTime createdDateTime,
            long creationUserShiftPatternId,
            User lastModifiedBy,
            DateTime lastModifiedDateTime,
            QuestionnaireConfiguration configuration,
            IEnumerable<PermitAssessmentAnswer> answers)
            : this(
                id, permitStartDateTime, permitExpiredDateTime, formStatus, createdBy, createdDateTime,
                creationUserShiftPatternId, lastModifiedBy,
                lastModifiedDateTime, answers)
        {
            SiteId = configuration.SiteId;
            CreationUserShiftPatternId = creationUserShiftPatternId;
            QuestionnaireId = configuration.IdValue;
            QuestionnaireName = configuration.Name;
            QuestionnaireVersion = configuration.Version;
        }

        public long SiteId { get; set; }

        public List<PermitAssessmentAnswer> Answers { get; private set; }

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

        public long QuestionnaireId { get; set; }

        public string QuestionnaireName { get; set; }

        public int QuestionnaireVersion { get; set; }

        public List<FunctionalLocation> FunctionalLocations { get; set; }

        public override EdmontonFormType FormType
        {
            get { return EdmontonFormType.OilsandsPermitAssessment; }
        }

        public List<long> PermitAssessmentSectionIds
        {
            get
            {
                var ids = new List<long>();

                foreach (var answer in Answers)
                {
                    if (!ids.Contains(answer.SectionId))
                    {
                        ids.Add(answer.SectionId);
                    }
                }

                ids.Sort();

                return ids;
            }
        }

        public bool WasCanceledByOEMSAdmin
        {
            get { return FormStatus == FormStatus.Cancelled && LastModifiedBy.Id != CreatedBy.Id; }
        }


        public long CreationUserShiftPatternId { get; set; }
        public List<DocumentLink> DocumentLinks { get; set; }

        private static int CompareAnswersBySectionAndQuestionDisplayOrder(PermitAssessmentAnswer leftAnswer,
            PermitAssessmentAnswer rightAnswer)
        {
            if (leftAnswer == null)
            {
                if (rightAnswer == null)
                {
                    return 0;
                }

                return -1;
            }

            if (rightAnswer == null)
            {
                return 1;
            }

            var sectionDisplayVal = rightAnswer.SectionDisplayOrder.CompareTo(rightAnswer.SectionDisplayOrder);

            if (sectionDisplayVal != 0)
            {
                return sectionDisplayVal;
            }

            var questionDisplayVal = rightAnswer.DisplayOrder.CompareTo(rightAnswer.DisplayOrder);

            return questionDisplayVal;
        }

        public override void MarkAsClosed(DateTime closedDateTime, User user)
        {
            ClosedDateTime = closedDateTime;
            FormStatus = FormStatus.Cancelled;
            LastModifiedDateTime = closedDateTime;
            LastModifiedBy = user;
        }

        public override IFormEdmontonDTO CreateDTO()
        {
            return new PermitAssessmentDTO(IdValue,
                FunctionalLocations.ConvertAll(floc => floc.FullHierarchy),
                CreatedBy.IdValue,
                CreatedBy.FullNameWithUserName,
                CreatedDateTime,
                LastModifiedBy.IdValue,
                FromDateTime,
                ToDateTime,
                FormStatus,
                LastModifiedBy.FullNameWithUserName,
                OilsandsWorkPermitType,
                PermitNumber,
                TotalScoredPercentage,
                JobDescription,
                OverallFeedback,
                LastModifiedDateTime,
                IsIlpRecommended,
                CreationUserShiftPatternId);
        }

        public PermitAssessmentHistory TakeSnapshot()
        {
            var flocListString = FunctionalLocations.FullHierarchyListToString(true, false);
            var answerHistories = Answers.ConvertAll(answer => answer.TakeSnapshot());

            return new PermitAssessmentHistory(IdValue,
                FromDateTime,
                ToDateTime,
                FormStatus,
                LastModifiedBy,
                LastModifiedDateTime,
                IssuedToSuncor,
                IssuedToContractor,
                Contractor,
                Trade,
                CrewSize,
                OilsandsWorkPermitType,
                PermitNumber,
                LocationEquipmentNumber,
                TotalScoredPercentage,
                TotalAnswerScore,
                TotalAnswerWeightedScore,
                TotalQuestionnaireWeight,
                JobDescription,
                OverallFeedback,
                JobCoordinator,
                IsIlpRecommended,
                flocListString,
                DocumentLinks.AsString(link => link.TitleWithUrl),
                answerHistories);
        }

        protected override bool CheckFlocRelevancy(long siteIdOfClient, List<string> fullHierarchies)
        {
            return CheckFlocRelevancyForMultipleFlocs(siteIdOfClient, fullHierarchies, FunctionalLocations);
        }

        public List<PermitAssessmentAnswer> GetAnswersBySectionId(long sectionId)
        {
            List<PermitAssessmentAnswer> unsortedAnswers = Answers.Where(answer => answer.SectionId == sectionId).ToList();

            List<PermitAssessmentAnswer> sortedAnswers =
                unsortedAnswers.OrderBy(answer => answer.SectionDisplayOrder)
                    .ThenBy(answer => answer.DisplayOrder)
                    .ToList();

            return sortedAnswers;
        }

        private int GetTotalConfiguredWeightBySectionId(long sectionId)
        {
            return GetAnswersBySectionId(sectionId).Sum(answer => answer.ConfiguredWeight)*MaxPossibleScore;
        }

        private int GetTotalWeightedScoreBySectionId(long sectionId)
        {
            return GetAnswersBySectionId(sectionId).Sum(answer => answer.WeightedScore);
        }

        public void RefreshAnswersAndTotals(List<PermitAssessmentAnswer> updatedAnswers)
        {
            if (updatedAnswers != null)
            {
                foreach (var updatedAnswer in updatedAnswers)
                {
                    var foundAnswer = Answers.FirstOrDefault(answer => answer.IdValue == updatedAnswer.IdValue);

                    if (foundAnswer != null)
                    {
                        Answers.Remove(foundAnswer);
                    }
                }

                Answers.AddRange(updatedAnswers);
            }

            RefreshAnswersAndTotals();
        }

        /// <summary>
        ///     After making changes to the answers in the permit assessment, update all the rolled-up totals.
        /// </summary>
        public void RefreshAnswersAndTotals()
        {
            var totalConfiguredWeight = 0;
            var totalAnswerScore = 0;
            var totalAnswerWeightedScore = 0;

            // Add up all answer stats
            foreach (var answer in Answers)
            {
                totalConfiguredWeight += answer.ConfiguredWeight*MaxPossibleScore;
                totalAnswerScore += answer.Score;
                totalAnswerWeightedScore += answer.WeightedScore;
            }

            // Go through all answers, grouped by section and update section stats in each

            var updatedAnswers = new List<PermitAssessmentAnswer>();

            var sectionIds = PermitAssessmentSectionIds;

            foreach (var sectionId in sectionIds)
            {
                var totalSectionConfiguredWeight = GetTotalConfiguredWeightBySectionId(sectionId);
                var totalSectionAnswerWeightedScore = GetTotalWeightedScoreBySectionId(sectionId);

                var totalSectionScoredPercentage = (totalSectionAnswerWeightedScore/
                                                    (decimal) (totalSectionConfiguredWeight))*100;

                var answersBySectionId = GetAnswersBySectionId(sectionId);
                foreach (var answer in answersBySectionId)
                {
                    answer.SectionScoredPercentage = totalSectionScoredPercentage;
                    updatedAnswers.Add(answer);
                }
            }

            var sortedList =
                updatedAnswers.OrderBy(answer => answer.SectionDisplayOrder)
                    .ThenBy(answer => answer.DisplayOrder)
                    .ToList();

            Answers.Clear();
            Answers.AddRange(sortedList);

            TotalQuestionnaireWeight = totalConfiguredWeight;
            TotalAnswerScore = totalAnswerScore;
            TotalAnswerWeightedScore = totalAnswerWeightedScore;
            TotalScoredPercentage = (totalAnswerWeightedScore/(decimal) (totalConfiguredWeight))*100;
        }
    }
}