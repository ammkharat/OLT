using System;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class PermitAssessmentTest
    {
        private const int SectionCount = 4;
        private const decimal SectionWeightPercent = 25;

        private const int QuestionCount = 2;
        private const int QuestionWeight = 10;

        private const int TotalConfiguredQuestionnaireWeight = 400;

        private PermitAssessment assessment1;
        private QuestionnaireConfiguration configuration1;

        [SetUp]
        public void SetUp()
        {
            SetupConfigurations();
            SetupPermits();
        }

        [TearDown]
        public void TearDown()
        {
        }


        [Test]
        public void QuestionnaireConfigurationShouldBeCreated()
        {
            Assert.IsNotNull(configuration1);
            Assert.IsNotNull(configuration1.Id);
            Assert.AreEqual(configuration1.Name, "Configuration 1");
            Assert.AreEqual(configuration1.SiteId, Site.OILSAND_ID);
            Assert.AreEqual(configuration1.Type, QuestionnaireConfigurationType.SafeWorkPermit.GetName());
        }

        [Test]
        public void QuestionnaireSectionsAndQuestionsShouldBeCreated()
        {
            AssertSectionAndQuestionsCreated(configuration1);
        }

        [Test]
        public void PermitAnswersShouldBeSortedBySectionAndQuestionDisplayOrder()
        {
            const int expectedAnswerCount = SectionCount * QuestionCount;

            var sortedAnswers = assessment1.Answers;
            Assert.IsNotNull(sortedAnswers);
            Assert.AreEqual(sortedAnswers.Count, expectedAnswerCount);

            for (var i = 0; i < SectionCount; i++)
            {
                var sectionNum = i + 1;

                for (var j = 0; j < QuestionCount; j++)
                {
                    var questionIndex = i*2 + j;
                    var questionNum = j + 1;

                    Assert.IsNotNull(sortedAnswers[questionIndex].Id);
                    Assert.AreEqual(sortedAnswers[questionIndex].SectionName, "Section " + sectionNum);
                    Assert.AreEqual(sortedAnswers[questionIndex].SectionDisplayOrder, sectionNum);
                    Assert.AreEqual(sortedAnswers[questionIndex].QuestionText, "Question " + questionNum);
                    Assert.AreEqual(sortedAnswers[questionIndex].DisplayOrder, questionNum);
                }
            }
        }

        [Test]
        public void PermitAssessmentShouldBeGeneratedFromConfiguration()
        {
            Assert.IsNotNull(assessment1);
            Assert.AreEqual(configuration1.SiteId, assessment1.SiteId);
            Assert.AreEqual(assessment1.FromDateTime, new DateTime(2014, 12, 12));
            Assert.AreEqual(assessment1.ToDateTime, new DateTime(2015, 12, 31));
            Assert.AreEqual(assessment1.TotalAnswerScore, 0);
            Assert.AreEqual(assessment1.TotalAnswerWeightedScore, 0);
            Assert.AreEqual(assessment1.TotalScoredPercentage, 0);
            Assert.AreEqual(assessment1.TotalQuestionnaireWeight, TotalConfiguredQuestionnaireWeight);
        }

        [Test]
        public void PermitAnswersShouldBeGeneratedFromConfiguration()
        {
            var permitAnswers = assessment1.Answers;
            Assert.IsNotNull(permitAnswers);
            Assert.AreEqual(permitAnswers.Count, 8);

            var sectionIds = assessment1.PermitAssessmentSectionIds;
            Assert.IsNotNull(sectionIds);
            Assert.AreEqual(sectionIds.Count, 4);
            Assert.Contains(1, sectionIds);
            Assert.Contains(2, sectionIds);
            Assert.Contains(3, sectionIds);
            Assert.Contains(4, sectionIds);

            var section1Answers = assessment1.GetAnswersBySectionId(1);
            Assert.AreEqual(section1Answers.Count, 2);
            foreach (var answer in section1Answers)
            {
                Assert.AreEqual(answer.ConfiguredWeight, QuestionWeight);
                Assert.AreEqual(answer.Score, 0);
                Assert.AreEqual(answer.WeightedScore, 0);
                Assert.AreEqual(answer.SectionScoredPercentage, 0);
            }

            var section2Answers = assessment1.GetAnswersBySectionId(2);
            Assert.AreEqual(section2Answers.Count, 2);
            foreach (var answer in section2Answers)
            {
                Assert.AreEqual(answer.ConfiguredWeight, QuestionWeight);
                Assert.AreEqual(answer.Score, 0);
                Assert.AreEqual(answer.WeightedScore, 0);
                Assert.AreEqual(answer.SectionScoredPercentage, 0);
            }

            var section3Answers = assessment1.GetAnswersBySectionId(3);
            Assert.AreEqual(section3Answers.Count, 2);
            foreach (var answer in section3Answers)
            {
                Assert.AreEqual(answer.ConfiguredWeight, QuestionWeight);
                Assert.AreEqual(answer.Score, 0);
                Assert.AreEqual(answer.WeightedScore, 0);
                Assert.AreEqual(answer.SectionScoredPercentage, 0);
            }

            var section4Answers = assessment1.GetAnswersBySectionId(4);
            Assert.AreEqual(section4Answers.Count, 2);
            foreach (var answer in section4Answers)
            {
                Assert.AreEqual(answer.ConfiguredWeight, QuestionWeight);
                Assert.AreEqual(answer.Score, 0);
                Assert.AreEqual(answer.WeightedScore, 0);
                Assert.AreEqual(answer.SectionScoredPercentage, 0);
            }
        }

        [Test]
        public void PermitAssessmentTotalsShouldUpdateCorrectlyAfterCompletingAnswers()
        {
            var section1Answers = assessment1.GetAnswersBySectionId(1);
            section1Answers[0].Score = 4;
            section1Answers[0].Comments = "Blah blah blah";
            
            assessment1.RefreshAnswersAndTotals(section1Answers);

            var updatedSection1Answers = assessment1.GetAnswersBySectionId(1);
            Assert.AreEqual(updatedSection1Answers[0].Score, 4);
            Assert.AreEqual(updatedSection1Answers[0].Comments, "Blah blah blah");

            Assert.AreEqual(updatedSection1Answers[0].WeightedScore, 40);
            Assert.AreEqual(updatedSection1Answers[0].SectionScoredPercentage, 40);

            Assert.AreEqual(assessment1.TotalAnswerScore, 4);
            Assert.AreEqual(assessment1.TotalAnswerWeightedScore, 40);
            Assert.AreEqual(assessment1.TotalScoredPercentage, 10);
        }

        private void AssertSectionAndQuestionsCreated(QuestionnaireConfiguration configuration)
        {
            var sortedSections = configuration.SortedQuestionnaireSections;
            Assert.IsNotNull(sortedSections);
            Assert.AreEqual(sortedSections.Count, SectionCount);

            for (var i = 0; i < SectionCount; i++)
            {
                var sectionNum = i + 1;

                Assert.IsNotNull(sortedSections[i].Id);
                Assert.AreEqual(sortedSections[i].Name, "Section " + sectionNum);
                Assert.AreEqual(sortedSections[i].PercentageWeighting, SectionWeightPercent);

                var sortedQuestions = sortedSections[i].SortedQuestions;
                Assert.IsNotNull(sortedQuestions);
                Assert.AreEqual(sortedQuestions.Count, QuestionCount);

                for (var j = 0; j < QuestionCount; j++)
                {
                    var questionNum = j + 1;

                    Assert.IsNotNull(sortedQuestions[j].Id);
                    Assert.AreEqual(sortedQuestions[j].QuestionText, "Question " + questionNum);
                    Assert.AreEqual(sortedQuestions[j].Weight, QuestionWeight);
                }
            }
        }

        private void SetupConfigurations()
        {
            var type = QuestionnaireConfigurationType.SafeWorkPermit.GetName();
            configuration1 = QuestionnaireConfigurationFixture.Create(Site.OILSAND_ID, type, "Configuration 1");
        }

        private void SetupPermits()
        {
            assessment1 = PermitAssessmentFixture.Create(configuration1, new DateTime(2014, 12, 12), new DateTime(2015, 12, 31));
        }
    }
}