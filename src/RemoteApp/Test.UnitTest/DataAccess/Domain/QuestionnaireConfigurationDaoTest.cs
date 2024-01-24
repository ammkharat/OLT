using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class QuestionnaireConfigurationDaoTest : AbstractDaoTest
    {
        private IQuestionnaireConfigurationDao configDao;
        private IQuestionnaireSectionDao configSectionDao;
        private IQuestionnaireSectionQuestionDao questionDao;

        [Ignore] [Test]
        public void ShouldDeleteAQuestionnaireConfiguration()
        {
            configDao.Insert(
                new QuestionnaireConfiguration(null, 1, 8, "SafeWorkPermit", "Hot Permit Assessment",
                    new List<QuestionnaireSection>
                    {
                        new QuestionnaireSection(null, 9, 1, 33.3m, "Section Name",
                            new List<Question>
                            {
                                new Question(null, 1, 9, 1, 33, "How safe are you eh?"),
                                new Question(null, 2, 9, 2, 12, "How safe are you really eh?")
                            })
                    }));
            configDao.Insert(
                new QuestionnaireConfiguration(null, 8, 1, "SafeWorkPermit", "Cold Permit Assessment",
                    new List<QuestionnaireSection>
                    {
                        new QuestionnaireSection(null, 9, 1, 33.3m, "Section Name",
                            new List<Question>
                            {
                                new Question(null, 1, 9, 1, 33, "How safe are you eh?"),
                                new Question(null, 2, 9, 2, 12, "How safe are you really eh?")
                            })
                    }));
            configDao.Insert(
                new QuestionnaireConfiguration(null, 1, 8, "SafeWorkPermit", "Luke Warm Assessment",
                    new List<QuestionnaireSection>
                    {
                        new QuestionnaireSection(null, 9, 1, 33.3m, "Section Name",
                            new List<Question>
                            {
                                new Question(null, 1, 9, 1, 33, "How safe are you eh?"),
                                new Question(null, 2, 9, 2, 12, "How safe are you really eh?")
                            })
                    }));

            var questionnaireConfigurationDtos = configDao.GetQuestionnaireConfigurationDtosBySiteId(8);
            var configIdOfDeleted = questionnaireConfigurationDtos[0].IdValue;
            var site8Dtos = configDao.GetQuestionnaireConfigurationDtosBySiteId(8);
            Assert.AreEqual(site8Dtos.Count, 1);
            var questions = questionDao.QueryByQuestionnaireConfigurationId(configIdOfDeleted);
            Assert.AreEqual(questions.Count, 2);
            var sections = configSectionDao.QuerySectionsByQuestionnaireConfigurationId(configIdOfDeleted);
            Assert.AreEqual(sections.Count, 1);

            configDao.DeleteQuestionnaireConfiguration(questionnaireConfigurationDtos[0].IdValue);

            configIdOfDeleted = questionnaireConfigurationDtos[0].IdValue;
            site8Dtos = configDao.GetQuestionnaireConfigurationDtosBySiteId(8);
            Assert.AreEqual(site8Dtos.Count, 0);
            questions = questionDao.QueryByQuestionnaireConfigurationId(configIdOfDeleted);
            Assert.AreEqual(questions.Count, 0);
            sections = configSectionDao.QuerySectionsByQuestionnaireConfigurationId(configIdOfDeleted);
            Assert.AreEqual(sections.Count, 0);
        }

        [Ignore] [Test]
        public void ShouldGetQuestionnaireConfigurationDtos()
        {
            configDao.Insert(
                new QuestionnaireConfiguration(null, 1, 8, "SafeWorkPermit", "Hot Permit Assessment",
                    new List<QuestionnaireSection>
                    {
                        new QuestionnaireSection(null, 9, 1, 33.3m, "Section Name",
                            new List<Question>
                            {
                                new Question(null, 1, 9, 1, 33, "How safe are you eh?"),
                                new Question(null, 2, 9, 2, 12, "How safe are you really eh?")
                            })
                    }));
            configDao.Insert(
                new QuestionnaireConfiguration(null, 8, 1, "SafeWorkPermit", "Cold Permit Assessment",
                    new List<QuestionnaireSection>
                    {
                        new QuestionnaireSection(null, 9, 1, 33.3m, "Section Name",
                            new List<Question>
                            {
                                new Question(null, 1, 9, 1, 33, "How safe are you eh?"),
                                new Question(null, 2, 9, 2, 12, "How safe are you really eh?")
                            })
                    }));
            configDao.Insert(
                new QuestionnaireConfiguration(null, 1, 8, "SafeWorkPermit", "Luke Warm Assessment",
                    new List<QuestionnaireSection>
                    {
                        new QuestionnaireSection(null, 9, 1, 33.3m, "Section Name",
                            new List<Question>
                            {
                                new Question(null, 1, 9, 1, 33, "How safe are you eh?"),
                                new Question(null, 2, 9, 2, 12, "How safe are you really eh?")
                            })
                    }));

            var questionnaireConfigurationDtos = configDao.GetQuestionnaireConfigurationDtosBySiteId(8);
            Assert.IsTrue(questionnaireConfigurationDtos.Count == 1);
            Assert.AreEqual(questionnaireConfigurationDtos[0].Name, "Cold Permit Assessment");
            Assert.AreEqual(questionnaireConfigurationDtos[0].Version, 1);
            Assert.AreEqual(questionnaireConfigurationDtos[0].Type, "SafeWorkPermit");
        }

        [Ignore] [Test]
        public void ShouldInsertAndGetByIdANewConfiguration()
        {
            var configuration =
                configDao.Insert(new QuestionnaireConfiguration(null, 1, 8, "SafeWorkPermit", "Hot Permit Assessment",
                    new List<QuestionnaireSection>
                    {
                        new QuestionnaireSection(null, 9, 1, 33.3m, "Section Name",
                            new List<Question>
                            {
                                new Question(null, 1, 9, 1, 33, "How safe are you eh?"),
                                new Question(null, 2, 9, 2, 12, "How safe are you really eh?")
                            })
                    }));

            var retrievedConfiguration = configDao.GetQuestionnaireConfigurationById(configuration.IdValue);
            Assert.AreEqual(retrievedConfiguration.Name, "Hot Permit Assessment");
            Assert.AreEqual(retrievedConfiguration.Version, 8);
            Assert.AreEqual(retrievedConfiguration.Type, "SafeWorkPermit");
            Assert.IsTrue(retrievedConfiguration.QuestionnaireSections.Count == 1);
            Assert.AreEqual(retrievedConfiguration.QuestionnaireSections[0].QuestionnaireConfigurationId,
                retrievedConfiguration.IdValue);
            Assert.AreEqual(retrievedConfiguration.QuestionnaireSections[0].DisplayOrder, 1);
            Assert.AreEqual(retrievedConfiguration.QuestionnaireSections[0].PercentageWeighting, 33.3m);
            Assert.AreEqual(retrievedConfiguration.QuestionnaireSections[0].Name, "Section Name");
            Assert.IsTrue(retrievedConfiguration.QuestionnaireSections[0].Questions.Count == 2);
            Assert.AreEqual(retrievedConfiguration.QuestionnaireSections[0].Questions[1].QuestionText,
                "How safe are you really eh?");
            Assert.AreEqual(retrievedConfiguration.QuestionnaireSections[0].Questions[1].DisplayOrder, 2);
            Assert.AreEqual(retrievedConfiguration.QuestionnaireSections[0].Questions[1].Weight, 12);
            Assert.AreEqual(retrievedConfiguration.QuestionnaireSections[0].Questions[1].QuestionnaireConfigurationId,
                retrievedConfiguration.IdValue);
            Assert.AreNotEqual(retrievedConfiguration.QuestionnaireSections[0].Questions[1].QuestionnaireSectionId, 2);
        }


        [Ignore] [Test]
        public void ShouldUpdateAConfiguration()
        {
            var configuration =
                configDao.Insert(new QuestionnaireConfiguration(null, 1, 1, "SafeWorkPermit", "Hot Permit Assessment",
                    new List<QuestionnaireSection>
                    {
                        new QuestionnaireSection(null, 9, 1, 33.3m, "Section Name",
                            new List<Question>
                            {
                                new Question(null, 1, 9, 1, 33, "How safe are you eh?"),
                                new Question(null, 2, 9, 2, 12, "How safe are you really eh?")
                            })
                    }));

            var retrievedConfiguration = configDao.GetQuestionnaireConfigurationById(configuration.IdValue);

            retrievedConfiguration.QuestionnaireSections = new List<QuestionnaireSection>
            {
                new QuestionnaireSection(null, 9, 1, 42.3m, "New Section Name",
                    new List<Question>
                    {
                        new Question(null, 1, 9, 2, 87, "A new Question"),
                        new Question(null, 2, 9, 1, 13, "Why you not safe?")
                    })
            };

            configDao.Update(retrievedConfiguration);

            var updatedConfiguration = configDao.GetQuestionnaireConfigurationById(configuration.IdValue);

            Assert.AreEqual(updatedConfiguration.Name, "Hot Permit Assessment");
            Assert.AreEqual(updatedConfiguration.Version, 2);
            Assert.AreEqual(updatedConfiguration.Type, "SafeWorkPermit");
            Assert.IsTrue(updatedConfiguration.QuestionnaireSections.Count == 1);
            Assert.AreEqual(updatedConfiguration.QuestionnaireSections[0].QuestionnaireConfigurationId,
                updatedConfiguration.IdValue);
            Assert.AreEqual(updatedConfiguration.QuestionnaireSections[0].DisplayOrder, 1);
            Assert.AreEqual(updatedConfiguration.QuestionnaireSections[0].PercentageWeighting, 42.3m);
            Assert.AreEqual(updatedConfiguration.QuestionnaireSections[0].Name, "New Section Name");
            Assert.IsTrue(updatedConfiguration.QuestionnaireSections[0].Questions.Count == 2);
            Assert.AreEqual(updatedConfiguration.QuestionnaireSections[0].Questions[1].QuestionText,
                "Why you not safe?");
            Assert.AreEqual(updatedConfiguration.QuestionnaireSections[0].Questions[1].DisplayOrder, 1);
            Assert.AreEqual(updatedConfiguration.QuestionnaireSections[0].Questions[1].Weight, 13);
            Assert.AreEqual(updatedConfiguration.QuestionnaireSections[0].Questions[1].QuestionnaireConfigurationId,
                updatedConfiguration.IdValue);
            Assert.AreNotEqual(updatedConfiguration.QuestionnaireSections[0].Questions[1].QuestionnaireSectionId, 2);
        }

        protected override void TestInitialize()
        {
            questionDao = DaoRegistry.GetDao<IQuestionnaireSectionQuestionDao>();
            configDao = DaoRegistry.GetDao<IQuestionnaireConfigurationDao>();
            configSectionDao = DaoRegistry.GetDao<IQuestionnaireSectionDao>();
        }

        protected override void Cleanup()
        {
        }
    }
}