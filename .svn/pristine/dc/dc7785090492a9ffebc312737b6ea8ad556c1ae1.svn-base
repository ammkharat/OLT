using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class ShiftHandoverConfigurationDaoTest : AbstractDaoTest
    {
        private IShiftHandoverConfigurationDao dao;
        private IShiftHandoverQuestionDao questionDao;
        private IWorkAssignmentDao workAssignmentDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IShiftHandoverConfigurationDao>();
            questionDao = DaoRegistry.GetDao<IShiftHandoverQuestionDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldQueryById()
        {
            ShiftHandoverConfiguration shiftHandoverConfiguration = dao.QueryById(1);
            Assert.IsNotNull(shiftHandoverConfiguration);
            Assert.AreEqual("Daily Shift Handover", shiftHandoverConfiguration.Name);
        }

        [Ignore] [Test]
        public void ShouldQueryByWorkAssignment()
        {
            WorkAssignment assignment1 = 
                workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Test WA 1"));
            WorkAssignment assignment2 = 
                workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Test WA 2"));
            WorkAssignment assignment3 = 
                workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Test WA 3"));

            assignment1 = workAssignmentDao.Insert(assignment1); // floc1
            assignment2 = workAssignmentDao.Insert(assignment2); // floc2
            assignment3 = workAssignmentDao.Insert(assignment3);

           
            List<WorkAssignment> assignmentList1 = new List<WorkAssignment> { assignment1 };
            List<WorkAssignment> assignmentList2 = new List<WorkAssignment> { assignment2 };
            List<WorkAssignment> assignmentList3 = new List<WorkAssignment> { assignment3 };
            List<WorkAssignment> assignmentList4 = new List<WorkAssignment> { assignment1, assignment2 };

            ShiftHandoverConfiguration configuration1 = dao.Insert(new ShiftHandoverConfiguration(
                0, assignmentList1, "abc", new List<ShiftHandoverQuestion>()));
            ShiftHandoverConfiguration configuration2 = dao.Insert(new ShiftHandoverConfiguration(
                0, assignmentList2, "abc", new List<ShiftHandoverQuestion>()));
            ShiftHandoverConfiguration configuration3 = dao.Insert(new ShiftHandoverConfiguration(
                0, assignmentList3, "abc", new List<ShiftHandoverQuestion>()));
            ShiftHandoverConfiguration configuration4 = dao.Insert(new ShiftHandoverConfiguration(
                0, assignmentList4, "abc", new List<ShiftHandoverQuestion>()));

            {
                List<ShiftHandoverConfiguration> results = dao.QueryByWorkAssignment(assignment1.IdValue);
                Assert.IsTrue(results.ExistsById(configuration1));
                Assert.IsTrue(results.ExistsById(configuration4));

                Assert.IsFalse(results.ExistsById(configuration2));
                Assert.IsFalse(results.ExistsById(configuration3));
            }
            {
                List<ShiftHandoverConfiguration> results = dao.QueryByWorkAssignment(assignment2.IdValue);
                Assert.IsTrue(results.ExistsById(configuration2));
                Assert.IsTrue(results.ExistsById(configuration4));

                Assert.IsFalse(results.ExistsById(configuration1));
                Assert.IsFalse(results.ExistsById(configuration3));
            }
            {
                List<ShiftHandoverConfiguration> results = dao.QueryByWorkAssignment(assignment3.IdValue);
                Assert.IsTrue(results.ExistsById(configuration3));
                
                Assert.IsFalse(results.ExistsById(configuration4));
                Assert.IsFalse(results.ExistsById(configuration2));
                Assert.IsFalse(results.ExistsById(configuration1));
            }
            {
                dao.Delete(configuration1.IdValue);
                List<ShiftHandoverConfiguration> results = dao.QueryByWorkAssignment(assignment1.IdValue);
                Assert.IsTrue(results.ExistsById(configuration4));

                Assert.IsFalse(results.ExistsById(configuration1));
                Assert.IsFalse(results.ExistsById(configuration2));
                Assert.IsFalse(results.ExistsById(configuration3));
            }

        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            WorkAssignment assignment = WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Test WA");
            WorkAssignment workAssignment = workAssignmentDao.Insert(assignment);

            List<ShiftHandoverQuestion> questions = new List<ShiftHandoverQuestion>
                                                        {
                                                            new ShiftHandoverQuestion(0, 0, 101, "q1", "h1"),
                                                            new ShiftHandoverQuestion(0, 0, 102, "q2", "h2"),
                                                            new ShiftHandoverQuestion(0, 0, 103, "q3", "h3")
                                                        };

            ShiftHandoverConfiguration configuration = new ShiftHandoverConfiguration(
                0,
                new List<WorkAssignment> { workAssignment },
                "abc",
                questions);

            configuration = dao.Insert(configuration);

            List<ShiftHandoverConfiguration> configurations = dao.QueryByWorkAssignment(assignment.IdValue);

            ShiftHandoverConfiguration requeried = configurations.FindById(configuration);
            Assert.IsNotNull(requeried);

            Assert.IsTrue(requeried.WorkAssignments.Exists(wa => wa.IdValue == assignment.IdValue));

            Assert.AreEqual(3, requeried.Questions.Count);
            Assert.IsTrue(requeried.Questions.Exists(obj => obj.DisplayOrder == 101 && obj.Text == "q1" && obj.HelpText == "h1"));
            Assert.IsTrue(requeried.Questions.Exists(obj => obj.DisplayOrder == 102 && obj.Text == "q2" && obj.HelpText == "h2"));
            Assert.IsTrue(requeried.Questions.Exists(obj => obj.DisplayOrder == 103 && obj.Text == "q3" && obj.HelpText == "h3"));
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            WorkAssignment assignment = WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Test WA");
            WorkAssignment workAssignment = workAssignmentDao.Insert(assignment);

            ShiftHandoverConfiguration originalItem = dao.QueryById(1);
                        
            Assert.IsNotEmpty(originalItem.WorkAssignments);
            Assert.AreEqual(4, originalItem.Questions.Count);

            // Work Assignments
            originalItem.WorkAssignments.Clear();
            originalItem.WorkAssignments.Add(workAssignment);
            
            //Questions
            ShiftHandoverQuestion popeQuestion = originalItem.Questions.Find(question => question.Text.Equals("Is the Pope Catholic?"));
            const string newQuestionText = "How do you say 'hello' in Chinese?";
            popeQuestion.Text = newQuestionText;

            originalItem.Name = "New Name";

            dao.Update(originalItem, new List<ShiftHandoverQuestion>());

            ShiftHandoverConfiguration changedItem = dao.QueryById(1);

            Assert.AreEqual("New Name", changedItem.Name);

            Assert.AreEqual(workAssignment.IdValue, changedItem.WorkAssignments[0].IdValue);

            Assert.AreEqual(4, changedItem.Questions.Count);
            Assert.IsTrue(changedItem.Questions.Exists(obj => obj.Text.Equals(newQuestionText)));
        }

        [Ignore] [Test]
        public void ShouldUpdateQuestions()
        {
            WorkAssignment assignment = WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Test WA");
            WorkAssignment workAssignment = workAssignmentDao.Insert(assignment);

            List<ShiftHandoverQuestion> questions = new List<ShiftHandoverQuestion>
                                                        {
                                                            new ShiftHandoverQuestion(null, 0, 1, "text1", "help1"),
                                                            new ShiftHandoverQuestion(null, 0, 2, "text2", "help2"),
                                                            new ShiftHandoverQuestion(null, 0, 3, "text3", "help3")
                                                        };

            ShiftHandoverConfiguration configuration = new ShiftHandoverConfiguration(
                null,
                new List<WorkAssignment> { workAssignment },
                "test config",
                questions);
            configuration = dao.Insert(configuration);

            {
                ShiftHandoverQuestion question = configuration.Questions.Find(obj => obj.Text == "text1");
                question.DisplayOrder = 1111;
                question.Text = "text1 - modified";
                question.HelpText = "help1 - modified";
            }

            configuration.Questions.Add(new ShiftHandoverQuestion(null, 0, 4, "text4", "help4"));

            List<ShiftHandoverQuestion> deletedQuestions = new List<ShiftHandoverQuestion>();
            {
                ShiftHandoverQuestion toBeDeleted = configuration.Questions.Find(obj => obj.Text == "text2");
                deletedQuestions.Add(toBeDeleted);
                configuration.Questions.Remove(toBeDeleted);
            }

            dao.Update(configuration, deletedQuestions);

            ShiftHandoverConfiguration updatedConfiguration = dao.QueryById(configuration.IdValue);
            Assert.AreEqual(3, updatedConfiguration.Questions.Count);
            Assert.IsTrue(updatedConfiguration.Questions.Exists(obj => obj.DisplayOrder == 1111 && obj.Text == "text1 - modified" && obj.HelpText == "help1 - modified"));
            Assert.IsTrue(updatedConfiguration.Questions.Exists(obj => obj.DisplayOrder == 3 && obj.Text == "text3" && obj.HelpText == "help3"));
            Assert.IsTrue(updatedConfiguration.Questions.Exists(obj => obj.DisplayOrder == 4 && obj.Text == "text4" && obj.HelpText == "help4"));
        }

        [Ignore] [Test]
        public void DeleteShouldOnlySetFlagOnQuestion()
        {
            WorkAssignment assignment = WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Test WA");
            WorkAssignment workAssignment = workAssignmentDao.Insert(assignment);

            List<ShiftHandoverQuestion> questions = new List<ShiftHandoverQuestion>
                                                        {new ShiftHandoverQuestion(null, 0, 1, "text1", "help1")};

            ShiftHandoverConfiguration configuration = new ShiftHandoverConfiguration(
                null,
                new List<WorkAssignment> { workAssignment },
                "test config",
                questions);
            configuration = dao.Insert(configuration);

            long configurationId = configuration.IdValue;
            long questionId = configuration.Questions[0].IdValue;

            {
                List<ShiftHandoverConfiguration> requeriedByAssignment = dao.QueryByWorkAssignment(workAssignment.IdValue);
                Assert.IsTrue(requeriedByAssignment.Exists(obj => obj.Id == configurationId));
            }
            {
                ShiftHandoverConfiguration requeriedById = dao.QueryById(configurationId);
                Assert.IsNotNull(requeriedById);
            }
            {
                ShiftHandoverQuestion question = questionDao.QueryById(questionId);
                Assert.IsNotNull(question);
            }

            dao.Delete(configurationId);

            {
                List<ShiftHandoverConfiguration> requeriedByAssignment = dao.QueryByWorkAssignment(workAssignment.IdValue);
                Assert.IsFalse(requeriedByAssignment.Exists(obj => obj.Id == configurationId));
            }
            {
                ShiftHandoverConfiguration requeriedById = dao.QueryById(configurationId);
                Assert.IsNull(requeriedById);
            }
            {
                ShiftHandoverQuestion question = questionDao.QueryById(questionId);
                Assert.IsNotNull(question);
            }
        }
    }
}