using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class PermitAssessmentFixture
    {
        private static long assessmentId = 1;
        private static long answerId = 1;

        public static PermitAssessment CreateForInsert(List<FunctionalLocation> flocs, DateTime validFromDateTime,
            DateTime validToDateTime, FormStatus status, DateTime lastModifiedDateTime, User lastModifiedBy,
            long questionnaireId = 0, List<PermitAssessmentAnswer> answers = null)
        {
            var createdBy = UserFixture.CreateUserWithGivenId(1);
            var createdDateTime = Clock.Now;

            var form = new PermitAssessment(null, validFromDateTime, validToDateTime, status, createdBy, createdDateTime,
                ShiftPatternFixture.OILSANDS_DAY_ID,
                lastModifiedBy, lastModifiedDateTime, answers)
            {
                ApprovedDateTime = Clock.Now.AddDays(1),
                ClosedDateTime = Clock.Now.AddDays(2),
                FunctionalLocations = flocs,
                LastModifiedBy = lastModifiedBy,
                LastModifiedDateTime = Clock.Now,
                CrewSize = 11,
                SiteId = 3,
                IssuedToSuncor = false,
                IssuedToContractor = true,
                IsIlpRecommended = true,
                PermitNumber = "1239P3",
                OilsandsWorkPermitType = OilsandsWorkPermitType.BlanketHot,
                QuestionnaireId = questionnaireId,
                QuestionnaireVersion = 3,
                QuestionnaireName = "Hot Hot Permit Survey",
                TotalQuestionnaireWeight = 123,
                Contractor = "some contractor",
                TotalAnswerScore = 45,
                TotalScoredPercentage = 90.22m,
                TotalAnswerWeightedScore = 111,
                JobDescription = "this is the job description eh",
                OverallFeedback = "this is the overall feedback",
                LocationEquipmentNumber = "N3290",
                JobCoordinator = "A Job Coordinator"
            };

            form.Contractor = "A Contractor Name";
            form.Trade = CraftOrTradeFixture.CreateCraftOrTradePipeFitter().Name;

            return form;
        }

        public static List<PermitAssessmentAnswer> CreateAnswers(QuestionnaireConfiguration configuration)
        {
            return PermitAssessmentBuilder.BuildAnswers(configuration).ToList();
        }

        public static PermitAssessment Create(QuestionnaireConfiguration configuration, DateTime permitStartDateTime,
            DateTime permitExpiredDateTime)
        {
            var assessmentUser = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();

            var assessment =
                PermitAssessmentBuilder.Build(configuration, assessmentUser, ShiftPatternFixture.OILSANDS_DAY_ID,
                    permitStartDateTime, permitExpiredDateTime, DateTime.Now);

            assessment.Id = assessmentId++;

            SetAnswerIds(assessment);

            return assessment;
        }

        private static void SetAnswerIds(PermitAssessment assessment)
        {
            foreach (var answer in assessment.Answers)
            {
                answer.Id = answerId++;
            }
        }
    }
}