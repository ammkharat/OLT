using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    [Category("Database")]
    public class PermitAssessmentDaoTest : AbstractDaoTest
    {
        private QuestionnaireConfiguration configuration;
        private IPermitAssessmentDao permitAssessmentDao;
        private IQuestionnaireConfigurationDao questionnaireConfigurationDao;

        [Ignore] [Test]
        public void QueryByIdShouldBringBackAnInsertedPermitAssessment()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var flocs = new List<FunctionalLocation> {floc1, floc2};

            Clock.Freeze();
            Clock.Now = new DateTime(2012, 9, 1);
            var now = Clock.Now;
            var validFromDateTime = new DateTime(2012, 9, 1);
            var validToDateTime = new DateTime(2012, 9, 2);

            var permitAssessmentAnswers = PermitAssessmentFixture.CreateAnswers(configuration);

            var permitAssessment = PermitAssessmentFixture.CreateForInsert(flocs, validFromDateTime, validToDateTime,
                FormStatus.Approved, validFromDateTime, UserFixture.CreateOilSandsUserWithUserPrintPreference(),
                configuration.IdValue, permitAssessmentAnswers);
            var insertedPermitAssessment = permitAssessmentDao.Insert(permitAssessment);
            var retrievedPermitAssessment = permitAssessmentDao.QueryById(insertedPermitAssessment.IdValue);

            Assert.AreEqual(insertedPermitAssessment.CreationUserShiftPatternId, retrievedPermitAssessment.CreationUserShiftPatternId);
            Assert.AreEqual(insertedPermitAssessment.JobDescription, retrievedPermitAssessment.JobDescription);
            Assert.AreEqual(insertedPermitAssessment.JobCoordinator, retrievedPermitAssessment.JobCoordinator);
            Assert.AreEqual(insertedPermitAssessment.IssuedToContractor, retrievedPermitAssessment.IssuedToContractor);
            Assert.AreEqual(insertedPermitAssessment.IssuedToSuncor, retrievedPermitAssessment.IssuedToSuncor);
            Assert.AreEqual(insertedPermitAssessment.LastModifiedBy.IdValue,
                retrievedPermitAssessment.LastModifiedBy.IdValue);
            Assert.AreEqual(insertedPermitAssessment.LastModifiedDateTime,
                retrievedPermitAssessment.LastModifiedDateTime);
            Assert.AreEqual(insertedPermitAssessment.LocationEquipmentNumber,
                retrievedPermitAssessment.LocationEquipmentNumber);
            Assert.AreEqual(insertedPermitAssessment.OilsandsWorkPermitType,
                retrievedPermitAssessment.OilsandsWorkPermitType);
            Assert.AreEqual(insertedPermitAssessment.OverallFeedback, retrievedPermitAssessment.OverallFeedback);
            Assert.AreEqual(insertedPermitAssessment.PermitNumber, retrievedPermitAssessment.PermitNumber);
            Assert.AreEqual(insertedPermitAssessment.QuestionnaireId, retrievedPermitAssessment.QuestionnaireId);
            Assert.AreEqual(insertedPermitAssessment.QuestionnaireName, retrievedPermitAssessment.QuestionnaireName);
            Assert.AreEqual(insertedPermitAssessment.TotalAnswerScore, retrievedPermitAssessment.TotalAnswerScore);
            Assert.AreEqual(insertedPermitAssessment.TotalAnswerWeightedScore,
                retrievedPermitAssessment.TotalAnswerWeightedScore);
            Assert.AreEqual(insertedPermitAssessment.TotalQuestionnaireWeight,
                retrievedPermitAssessment.TotalQuestionnaireWeight);
            Assert.AreEqual(insertedPermitAssessment.Contractor, retrievedPermitAssessment.Contractor);
            Assert.AreEqual(insertedPermitAssessment.TotalScoredPercentage,
                retrievedPermitAssessment.TotalScoredPercentage);
            Assert.AreEqual(insertedPermitAssessment.Trade, retrievedPermitAssessment.Trade);
            Assert.AreEqual(insertedPermitAssessment.SiteId, retrievedPermitAssessment.SiteId);
            Assert.AreEqual(insertedPermitAssessment.CrewSize, retrievedPermitAssessment.CrewSize);
            Assert.AreEqual(insertedPermitAssessment.FormStatus, retrievedPermitAssessment.FormStatus);
            Assert.AreEqual(insertedPermitAssessment.FormType, retrievedPermitAssessment.FormType);
            Assert.AreEqual(insertedPermitAssessment.QuestionnaireVersion,
                retrievedPermitAssessment.QuestionnaireVersion);
            Assert.AreEqual(insertedPermitAssessment.ToDateTime, retrievedPermitAssessment.ToDateTime);
            Assert.AreEqual(insertedPermitAssessment.IsIlpRecommended, retrievedPermitAssessment.IsIlpRecommended);
            Assert.AreEqual(insertedPermitAssessment.FromDateTime, retrievedPermitAssessment.FromDateTime);
            Assert.AreEqual(insertedPermitAssessment.CreatedDateTime, retrievedPermitAssessment.CreatedDateTime);
            Assert.AreEqual(insertedPermitAssessment.FunctionalLocations.Count,
                retrievedPermitAssessment.FunctionalLocations.Count);
            Assert.AreEqual(insertedPermitAssessment.DocumentLinks.Count, retrievedPermitAssessment.DocumentLinks.Count);

            AssertAnswersAreTheSame(insertedPermitAssessment.Answers, retrievedPermitAssessment.Answers);

            Clock.UnFreeze();
        }

        [Ignore] [Test]
        public void ShouldUpdateAPermitAssessment()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var flocs = new List<FunctionalLocation> {floc1};

            Clock.Freeze();
            Clock.Now = new DateTime(2012, 9, 1);
            var now = Clock.Now;
            var validFromDateTime = new DateTime(2012, 9, 1);
            var validToDateTime = new DateTime(2012, 9, 2);

            var permitAssessmentAnswers = PermitAssessmentFixture.CreateAnswers(configuration);

            var permitAssessment = PermitAssessmentFixture.CreateForInsert(flocs, validFromDateTime, validToDateTime,
                FormStatus.Approved, validFromDateTime, UserFixture.CreateOilSandsUserWithUserPrintPreference(),
                configuration.IdValue, permitAssessmentAnswers);
            var assessmentToUpdate = permitAssessmentDao.Insert(permitAssessment);

            assessmentToUpdate.FunctionalLocations.Add(floc2);
            assessmentToUpdate.FromDateTime = assessmentToUpdate.FromDateTime.AddDays(1);
            assessmentToUpdate.ToDateTime = assessmentToUpdate.ToDateTime.AddDays(1);
            assessmentToUpdate.JobDescription = "new job desc";
            assessmentToUpdate.JobCoordinator = "new job cooord";
            assessmentToUpdate.IssuedToContractor = !assessmentToUpdate.IssuedToContractor;
            assessmentToUpdate.IssuedToSuncor = !assessmentToUpdate.IssuedToSuncor;
            assessmentToUpdate.LastModifiedBy.Id = assessmentToUpdate.LastModifiedBy.Id + 1;
            assessmentToUpdate.LastModifiedDateTime = assessmentToUpdate.LastModifiedDateTime.AddDays(1);
            assessmentToUpdate.LocationEquipmentNumber = "23459";
            assessmentToUpdate.OilsandsWorkPermitType = OilsandsWorkPermitType.SpecificCold;
            assessmentToUpdate.OverallFeedback = "new feedback";
            assessmentToUpdate.PermitNumber = "new num";
            assessmentToUpdate.TotalAnswerScore = 99;
            assessmentToUpdate.Contractor = "New contractor";
            assessmentToUpdate.TotalScoredPercentage = 87;
            assessmentToUpdate.Trade = "New trade";
            assessmentToUpdate.SiteId = 2;
            assessmentToUpdate.CrewSize = 12;
            assessmentToUpdate.FormStatus = FormStatus.Cancelled;
            assessmentToUpdate.QuestionnaireVersion = 32;
            assessmentToUpdate.IsIlpRecommended = !assessmentToUpdate.IsIlpRecommended;

            permitAssessmentDao.Update(assessmentToUpdate);
            var retrievedPermitAssessment = permitAssessmentDao.QueryById(assessmentToUpdate.IdValue);

            Assert.AreEqual(assessmentToUpdate.JobDescription, retrievedPermitAssessment.JobDescription);
            Assert.AreEqual(assessmentToUpdate.JobCoordinator, retrievedPermitAssessment.JobCoordinator);
            Assert.AreEqual(assessmentToUpdate.IssuedToContractor, retrievedPermitAssessment.IssuedToContractor);
            Assert.AreEqual(assessmentToUpdate.IssuedToSuncor, retrievedPermitAssessment.IssuedToSuncor);
            Assert.AreEqual(assessmentToUpdate.LastModifiedBy.IdValue, retrievedPermitAssessment.LastModifiedBy.IdValue);
            Assert.AreEqual(assessmentToUpdate.LastModifiedDateTime, retrievedPermitAssessment.LastModifiedDateTime);
            Assert.AreEqual(assessmentToUpdate.LocationEquipmentNumber,
                retrievedPermitAssessment.LocationEquipmentNumber);
            Assert.AreEqual(assessmentToUpdate.OilsandsWorkPermitType, retrievedPermitAssessment.OilsandsWorkPermitType);
            Assert.AreEqual(assessmentToUpdate.OverallFeedback, retrievedPermitAssessment.OverallFeedback);
            Assert.AreEqual(assessmentToUpdate.PermitNumber, retrievedPermitAssessment.PermitNumber);
            Assert.AreEqual(assessmentToUpdate.TotalAnswerScore, retrievedPermitAssessment.TotalAnswerScore);
            Assert.AreEqual(assessmentToUpdate.TotalQuestionnaireWeight,
                retrievedPermitAssessment.TotalQuestionnaireWeight);
            Assert.AreEqual(assessmentToUpdate.Contractor, retrievedPermitAssessment.Contractor);
            Assert.AreEqual(assessmentToUpdate.TotalScoredPercentage, retrievedPermitAssessment.TotalScoredPercentage);
            Assert.AreEqual(assessmentToUpdate.Trade, retrievedPermitAssessment.Trade);
            Assert.AreEqual(assessmentToUpdate.SiteId, retrievedPermitAssessment.SiteId);
            Assert.AreEqual(assessmentToUpdate.CrewSize, retrievedPermitAssessment.CrewSize);
            Assert.AreEqual(assessmentToUpdate.FormStatus, retrievedPermitAssessment.FormStatus);
            Assert.AreEqual(assessmentToUpdate.FormType, retrievedPermitAssessment.FormType);
            Assert.AreEqual(assessmentToUpdate.ToDateTime, retrievedPermitAssessment.ToDateTime);
            Assert.AreEqual(assessmentToUpdate.IsIlpRecommended, retrievedPermitAssessment.IsIlpRecommended);
            Assert.AreEqual(assessmentToUpdate.FromDateTime, retrievedPermitAssessment.FromDateTime);
            Assert.AreEqual(assessmentToUpdate.FunctionalLocations.Count,
                retrievedPermitAssessment.FunctionalLocations.Count);
            Assert.AreEqual(assessmentToUpdate.DocumentLinks.Count, retrievedPermitAssessment.DocumentLinks.Count);

            AssertAnswersAreTheSame(assessmentToUpdate.Answers, retrievedPermitAssessment.Answers);
        }

        private void AssertAnswersAreTheSame(List<PermitAssessmentAnswer> answers,
            List<PermitAssessmentAnswer> updatedAnswers)
        {
            Assert.AreEqual(answers.Count, updatedAnswers.Count);

            foreach (var permitAssessmentAnswer in updatedAnswers)
            {
                var foundAnswer = answers.Find(answer => answer.IdValue == permitAssessmentAnswer.IdValue);
                Assert.IsNotNull(foundAnswer);
                Assert.AreEqual(foundAnswer.PermitAssessmentId, permitAssessmentAnswer.PermitAssessmentId);
                Assert.AreEqual(foundAnswer.SectionId, permitAssessmentAnswer.SectionId);
                Assert.AreEqual(foundAnswer.SectionName, permitAssessmentAnswer.SectionName);
                Assert.AreEqual(foundAnswer.SectionConfiguredPercentageWeighting,
                    permitAssessmentAnswer.SectionConfiguredPercentageWeighting);
                Assert.AreEqual(foundAnswer.SectionScoredPercentage, permitAssessmentAnswer.SectionScoredPercentage);
                Assert.AreEqual(foundAnswer.QuestionId, permitAssessmentAnswer.QuestionId);
                Assert.AreEqual(foundAnswer.QuestionText, permitAssessmentAnswer.QuestionText);
                Assert.AreEqual(foundAnswer.ConfiguredWeight, permitAssessmentAnswer.ConfiguredWeight);
                Assert.AreEqual(foundAnswer.SectionDisplayOrder, permitAssessmentAnswer.SectionDisplayOrder);
                Assert.AreEqual(foundAnswer.DisplayOrder, permitAssessmentAnswer.DisplayOrder);
                Assert.AreEqual(foundAnswer.Score, permitAssessmentAnswer.Score);
                Assert.AreEqual(foundAnswer.Comments, permitAssessmentAnswer.Comments);
                Assert.AreEqual(foundAnswer.WeightedScore, permitAssessmentAnswer.WeightedScore);
            }
        }

        protected override void TestInitialize()
        {
            permitAssessmentDao = DaoRegistry.GetDao<IPermitAssessmentDao>();
            questionnaireConfigurationDao = DaoRegistry.GetDao<IQuestionnaireConfigurationDao>();

            var type = QuestionnaireConfigurationType.SafeWorkPermit.GetName();
            configuration = QuestionnaireConfigurationFixture.Create(Site.OILSAND_ID, type, "Configuration 1");
            questionnaireConfigurationDao.Insert(configuration);
        }

        protected override void Cleanup()
        {
        }
    }
}