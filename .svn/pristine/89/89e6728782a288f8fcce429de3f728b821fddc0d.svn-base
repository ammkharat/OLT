using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class LogTemplateDaoTest : AbstractDaoTest
    {
        private ILogTemplateDao dao;
        private ILogTemplateDTODao dtoDao;
        private ILogTemplateWorkAssignmentDao logTemplateWorkAssignmentDao;
        private IWorkAssignmentDao workAssignmentDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ILogTemplateDao>();
            dtoDao = DaoRegistry.GetDao<ILogTemplateDTODao>();
            logTemplateWorkAssignmentDao = DaoRegistry.GetDao<ILogTemplateWorkAssignmentDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]        
        public void ShouldInsertAndFindById()
        {
            WorkAssignment wa1 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA 1"));
            WorkAssignment wa2 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA 2"));
            WorkAssignment wa3 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA 3"));

            List<WorkAssignment> assignments = new List<WorkAssignment> { wa1, wa2, wa3 };

            User createUser = UserFixture.CreateUserWithGivenId(1);
            User modifyUser = UserFixture.CreateUserWithGivenId(2);
            DateTime createDateTime = new DateTime(2010, 11, 20);
            DateTime modifiedDateTime = new DateTime(2010, 11, 26);

            LogTemplate logTemplate =
                new LogTemplate("Template Name", "This is the template", assignments, true, true, true, modifyUser, modifiedDateTime,
                        createUser, createDateTime);

            LogTemplate templateFromInsert = dao.Insert(logTemplate);

            LogTemplate logTemplateFromQuery = dao.QueryById(templateFromInsert.IdValue);
            Assert.IsNotNull(logTemplateFromQuery);

            Assert.AreEqual(logTemplate.Name, logTemplateFromQuery.Name);
            Assert.AreEqual(logTemplate.Text, logTemplateFromQuery.Text);

            Assert.IsTrue(logTemplateFromQuery.AppliesToLogs);
            Assert.IsTrue(logTemplateFromQuery.AppliesToSummaryLogs);
            Assert.IsTrue(logTemplateFromQuery.AppliesToDirectives);

            Assert.AreEqual(assignments.Count, logTemplateFromQuery.WorkAssignments.Count);

            foreach (WorkAssignment assignment in assignments)
            {
                Assert.IsNotNull(logTemplateFromQuery.WorkAssignments.FindById(assignment));
            }

            Assert.AreEqual(logTemplate.CreatedBy.Id, logTemplateFromQuery.CreatedBy.Id);
            Assert.AreEqual(logTemplate.CreatedDateTime, logTemplateFromQuery.CreatedDateTime);

            Assert.AreEqual(logTemplate.LastModifiedBy.Id, logTemplateFromQuery.LastModifiedBy.Id);
            Assert.AreEqual(logTemplate.CreatedDateTime, logTemplateFromQuery.CreatedDateTime);
        }

        [Ignore] [Test]       
        public void ShouldFindBySiteId()
        {
            WorkAssignment wa1 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateOilsandsWorkAssignmentToBeInsertedInDatabase("WA 1"));
            WorkAssignment wa2 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateOilsandsWorkAssignmentToBeInsertedInDatabase("WA 2"));
            WorkAssignment wa3 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateOilsandsWorkAssignmentToBeInsertedInDatabase("WA 3"));

            List<WorkAssignment> oilsandsAssignments = new List<WorkAssignment> { wa1, wa2, wa3 };

            User createUser = UserFixture.CreateUserWithGivenId(1);
            User modifyUser = UserFixture.CreateUserWithGivenId(2);
            DateTime createDateTime = new DateTime(2010, 11, 20);
            DateTime modifiedDateTime = new DateTime(2010, 11, 26);

            int counter = 0;

            // Template1
            {
                LogTemplate logTemplate =
                    new LogTemplate("Template" + ++counter, "This is the template", oilsandsAssignments, true, true, true, modifyUser,
                                    modifiedDateTime,
                                    createUser, createDateTime);

                dao.Insert(logTemplate);
            }

            // Template2
            {
                LogTemplate logTemplate =
                    new LogTemplate("Template" + ++counter, "This is the template", oilsandsAssignments, true, true, true, modifyUser,
                                    modifiedDateTime,
                                    createUser, createDateTime);

                dao.Insert(logTemplate);
            }

            // Template3
            {
                LogTemplate logTemplate =
                    new LogTemplate("Template" + ++counter, "This is the template", oilsandsAssignments, true, true, true, modifyUser,
                                    modifiedDateTime,
                                    createUser, createDateTime);

                dao.Insert(logTemplate);
            }

            WorkAssignment swa1 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA 1"));
            WorkAssignment swa2 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA 2"));
            WorkAssignment swa3 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA 3"));

            List<WorkAssignment> sarniaAssignments = new List<WorkAssignment> { swa1, swa2, swa3 };


            // Template4
            {
                LogTemplate logTemplate =
                    new LogTemplate("Template" + ++counter, "This is the template", sarniaAssignments, true, true, true, modifyUser,
                                    modifiedDateTime,
                                    createUser, createDateTime);

                dao.Insert(logTemplate);
            }

            {
                List<LogTemplate> oilsandsResult = dao.QueryBySiteId(Site.OILSAND_ID);
                Assert.IsTrue(oilsandsResult.Count >= 3);

                Assert.IsNotNull(oilsandsResult.Find(template => template.Name == "Template1"));
                Assert.IsNotNull(oilsandsResult.Find(template => template.Name == "Template2"));
                Assert.IsNotNull(oilsandsResult.Find(template => template.Name == "Template3"));
            }

            {
                List<LogTemplate> sarniaResult = dao.QueryBySiteId(Site.SARNIA_ID);
                Assert.IsTrue(sarniaResult.Count >= 1);

                Assert.IsNotNull(sarniaResult.Find(template => template.Name == "Template4"));
            }
        }
        [Ignore] [Test]
        public void ShouldUpdate()
        {
            WorkAssignment wa1 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateOilsandsWorkAssignmentToBeInsertedInDatabase("WA 1"));
            WorkAssignment wa2 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateOilsandsWorkAssignmentToBeInsertedInDatabase("WA 2"));
            WorkAssignment wa3 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateOilsandsWorkAssignmentToBeInsertedInDatabase("WA 3"));
            WorkAssignment wa4 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateOilsandsWorkAssignmentToBeInsertedInDatabase("WA 4"));

            List<WorkAssignment> oilsandsAssignments = new List<WorkAssignment> { wa1, wa2, wa3 };

            LogTemplate logTemplateFromQuery;

            User originalUser = UserFixture.CreateUserWithGivenId(1);
            DateTime createDateTime = new DateTime(2010, 11, 20);
            DateTime modifiedDateTime = new DateTime(2010, 11, 26);

            // Insert one
            {
                LogTemplate logTemplate =
                    new LogTemplate("Template Name", "This is the template", oilsandsAssignments, true, true, true, originalUser, modifiedDateTime,
                            originalUser, createDateTime);

                LogTemplate templateFromInsert = dao.Insert(logTemplate);
                logTemplateFromQuery = dao.QueryById(templateFromInsert.IdValue);   
            }

            DateTime lastModifiedDate = new DateTime(2010, 11, 28);
            User modifyUser = UserFixture.CreateUserWithGivenId(2);
            const string newName = "Some new name";
            const string newText = "Some new text";

            List<WorkAssignment> updatedAssignments = new List<WorkAssignment> { wa1, wa4 };

            // Update it
            {
                
                logTemplateFromQuery.WorkAssignments.Clear();
                logTemplateFromQuery.WorkAssignments.AddRange(updatedAssignments);

                logTemplateFromQuery.LastModifiedBy = modifyUser;
                logTemplateFromQuery.LastModifiedDateTime = lastModifiedDate;
                logTemplateFromQuery.Name = newName;
                logTemplateFromQuery.Text = newText;
                logTemplateFromQuery.AppliesToDirectives = false;

                dao.Update(logTemplateFromQuery);                
            }

            // Check it
            {
                LogTemplate updatedTemplate = dao.QueryById(logTemplateFromQuery.IdValue);

                Assert.AreEqual(newName, updatedTemplate.Name);
                Assert.AreEqual(newText, updatedTemplate.Text);
                Assert.AreEqual(modifyUser.Id, updatedTemplate.LastModifiedBy.Id);
                Assert.AreEqual(lastModifiedDate, updatedTemplate.LastModifiedDateTime);
                Assert.IsFalse(updatedTemplate.AppliesToDirectives);

                Assert.AreEqual(2, updatedTemplate.WorkAssignments.Count);

                foreach (WorkAssignment workAssignment in updatedAssignments)
                {
                    Assert.IsNotNull(updatedTemplate.WorkAssignments.FindById(workAssignment));
                }

                Assert.AreEqual(originalUser.Id, updatedTemplate.CreatedBy.Id);
                Assert.AreEqual(createDateTime, updatedTemplate.CreatedDateTime);
            }
        }

        [Ignore] [Test]
        public void ShouldDelete()
        {
            WorkAssignment wa1 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateOilsandsWorkAssignmentToBeInsertedInDatabase("WA 1"));
            WorkAssignment wa2 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateOilsandsWorkAssignmentToBeInsertedInDatabase("WA 2"));
            WorkAssignment wa3 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateOilsandsWorkAssignmentToBeInsertedInDatabase("WA 3"));

            List<WorkAssignment> oilsandsAssignments = new List<WorkAssignment> { wa1, wa2, wa3 };

            User createUser = UserFixture.CreateUserWithGivenId(1);
            User modifyUser = UserFixture.CreateUserWithGivenId(2);
            DateTime createDateTime = new DateTime(2010, 11, 20);
            DateTime modifiedDateTime = new DateTime(2010, 11, 26);

            LogTemplate logTemplate =
                new LogTemplate("Template Name", "This is the template", oilsandsAssignments, true, true, true, modifyUser, modifiedDateTime,
                        createUser, createDateTime);

            LogTemplate templateFromInsert = dao.Insert(logTemplate);

            LogTemplate logTemplateFromQuery = dao.QueryById(templateFromInsert.IdValue);
            Assert.IsNotNull(logTemplateFromQuery);
            Assert.IsNotEmpty(logTemplateFromQuery.WorkAssignments);

            dao.Delete(logTemplateFromQuery);

            LogTemplate deleted = dao.QueryById(templateFromInsert.IdValue);
            Assert.IsNull(deleted);

            List<LogTemplateWorkAssignment> logTemplateWorkAssignments = logTemplateWorkAssignmentDao.QueryByLogTemplateId(templateFromInsert.IdValue);
            Assert.IsEmpty(logTemplateWorkAssignments);
        }

        [Ignore] [Test]
        public void ShouldDeleteEvenWhenTemplateIsReferencedByAWorkAssignment()
        {
            User createUser = UserFixture.CreateUserWithGivenId(1);
            User modifyUser = UserFixture.CreateUserWithGivenId(2);
            DateTime createDateTime = new DateTime(2010, 11, 20);
            DateTime modifiedDateTime = new DateTime(2010, 11, 26);

            LogTemplate logTemplate = new LogTemplate("Template Name", "This is the template", new List<WorkAssignment>(), true, true, true, modifyUser, modifiedDateTime, createUser, createDateTime);                
            dao.Insert(logTemplate);

            WorkAssignment wa1 = WorkAssignmentFixture.CreateOilsandsWorkAssignmentToBeInsertedInDatabase("WA 1");
            wa1.AutoInsertLogTemplateId = logTemplate.IdValue;
            workAssignmentDao.Insert(wa1);

            LogTemplate logTemplateFromQuery = dao.QueryById(logTemplate.IdValue);
            Assert.IsNotNull(logTemplateFromQuery);

            dao.Delete(logTemplateFromQuery);

            WorkAssignment requeriedWorkAssignment = workAssignmentDao.QueryById(wa1.IdValue);
            Assert.IsNull(requeriedWorkAssignment.AutoInsertLogTemplateId);
        }

        [Ignore] [Test]
        public void DisconnectingATemplateFromAWorkAssignmentShouldRemoveThatTemplateAsAnAutoInsertOne()
        {
            User createUser = UserFixture.CreateUserWithGivenId(1);
            User modifyUser = UserFixture.CreateUserWithGivenId(2);
            DateTime createDateTime = new DateTime(2010, 11, 20);
            DateTime modifiedDateTime = new DateTime(2010, 11, 26);

            LogTemplate logTemplate = new LogTemplate("Template Name", "This is the template", new List<WorkAssignment>(), true, true, true, modifyUser, modifiedDateTime, createUser, createDateTime);
            dao.Insert(logTemplate);

            WorkAssignment wa1 = WorkAssignmentFixture.CreateOilsandsWorkAssignmentToBeInsertedInDatabase("WA 1");
            wa1.AutoInsertLogTemplateId = logTemplate.IdValue;
            workAssignmentDao.Insert(wa1);

            logTemplate.WorkAssignments.Clear();
            logTemplate.WorkAssignments.Add(wa1);
            dao.Update(logTemplate);

            // remove wa1 from the log template
            LogTemplate logTemplateFromQuery = dao.QueryById(logTemplate.IdValue);
            Assert.IsNotNull(logTemplateFromQuery);
            logTemplateFromQuery.WorkAssignments.Clear();
            dao.Update(logTemplateFromQuery);

            // verify that wa1 no longer has that log template as the auto insert choice
            WorkAssignment requeriedWorkAssignment = workAssignmentDao.QueryById(wa1.IdValue);
            Assert.IsNull(requeriedWorkAssignment.AutoInsertLogTemplateId);
        }

        [Ignore] [Test]
        public void ShouldQueryTemplatesThatAreAutoInsertedForTheGivenAssignments()
        {
            User createUser = UserFixture.CreateUserWithGivenId(1);
            User modifyUser = UserFixture.CreateUserWithGivenId(2);
            DateTime createDateTime = new DateTime(2010, 11, 20);
            DateTime modifiedDateTime = new DateTime(2010, 11, 26);

            LogTemplate logTemplate1 = new LogTemplate("Template Name 1", "This is the template", new List<WorkAssignment>(), true, true, true, modifyUser, modifiedDateTime, createUser, createDateTime);
            LogTemplate logTemplate2 = new LogTemplate("Template Name 2", "This is the template", new List<WorkAssignment>(), true, true, true, modifyUser, modifiedDateTime, createUser, createDateTime);
            dao.Insert(logTemplate1);
            dao.Insert(logTemplate2);

            WorkAssignment wa1 = WorkAssignmentFixture.CreateOilsandsWorkAssignmentToBeInsertedInDatabase("WA 1");
            wa1.AutoInsertLogTemplateId = logTemplate1.IdValue;
            workAssignmentDao.Insert(wa1);

            WorkAssignment wa2 = WorkAssignmentFixture.CreateOilsandsWorkAssignmentToBeInsertedInDatabase("WA 2");
            wa2.AutoInsertLogTemplateId = logTemplate2.IdValue;
            workAssignmentDao.Insert(wa2);

            WorkAssignment wa3 = WorkAssignmentFixture.CreateOilsandsWorkAssignmentToBeInsertedInDatabase("WA 3");
            workAssignmentDao.Insert(wa3);

            logTemplate1.WorkAssignments.Clear();
            logTemplate1.WorkAssignments.Add(wa1);
            logTemplate1.WorkAssignments.Add(wa2);
            logTemplate1.WorkAssignments.Add(wa3);
            dao.Update(logTemplate1);

            logTemplate2.WorkAssignments.Clear();
            logTemplate2.WorkAssignments.Add(wa1);
            logTemplate2.WorkAssignments.Add(wa2);
            logTemplate2.WorkAssignments.Add(wa3);
            dao.Update(logTemplate2);

            List<LogTemplate> templates = dao.QueryLogTemplatesSetAsAutoInsertForTheseAssignments(new List<WorkAssignment> { wa1, wa2, wa3 });
            Assert.AreEqual(2, templates.Count);
            Assert.IsTrue(templates.ExistsById(logTemplate1));
            Assert.IsTrue(templates.ExistsById(logTemplate2));

            templates = dao.QueryLogTemplatesSetAsAutoInsertForTheseAssignments(new List<WorkAssignment> { wa1, wa3 });
            Assert.AreEqual(1, templates.Count);
            Assert.IsTrue(templates.ExistsById(logTemplate1));

            templates = dao.QueryLogTemplatesSetAsAutoInsertForTheseAssignments(new List<WorkAssignment> { wa3 });
            Assert.AreEqual(0, templates.Count);
        }

        [Ignore] [Test]
        public void ShouldQueryByWorkAssignment()
        {
            User createUser = UserFixture.CreateUserWithGivenId(1);
            User modifyUser = UserFixture.CreateUserWithGivenId(2);
            DateTime createDateTime = new DateTime(2010, 11, 20);
            DateTime modifiedDateTime = new DateTime(2010, 11, 26);

            WorkAssignment assignment1 =
                workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Test WA 1"));
            WorkAssignment assignment2 =
                workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Test WA 2"));
            WorkAssignment assignment3 =
                workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Test WA 3"));

            assignment1 = workAssignmentDao.Insert(assignment1); 
            assignment2 = workAssignmentDao.Insert(assignment2); 
            assignment3 = workAssignmentDao.Insert(assignment3);

            List<WorkAssignment> assignmentList1 = new List<WorkAssignment> { assignment1 };
            List<WorkAssignment> assignmentList2 = new List<WorkAssignment> { assignment2 };
            List<WorkAssignment> assignmentList3 = new List<WorkAssignment> { assignment3 };
            List<WorkAssignment> assignmentList4 = new List<WorkAssignment> { assignment1, assignment2 };

            LogTemplate logTemplate1 = new LogTemplate("Template 1", "This is template 1", assignmentList1, true, false, false, modifyUser,
                    modifiedDateTime, createUser, createDateTime);
            LogTemplate logTemplate2 = new LogTemplate("Template 2", "This is template 2", assignmentList2, true, false, false, modifyUser,
                    modifiedDateTime, createUser, createDateTime);
            LogTemplate logTemplate3 = new LogTemplate("Template 3", "This is template 3", assignmentList3, true, false, false, modifyUser,
                    modifiedDateTime, createUser, createDateTime);
            LogTemplate logTemplate4 = new LogTemplate("Template 4", "This is template 4", assignmentList4, true, false, false, modifyUser,
                    modifiedDateTime, createUser, createDateTime);


            logTemplate1 = dao.Insert(logTemplate1);
            logTemplate2 = dao.Insert(logTemplate2);
            logTemplate3 = dao.Insert(logTemplate3);
            logTemplate4 = dao.Insert(logTemplate4);

            {
                List<LogTemplateDTO> results = dtoDao.QueryByWorkAssignmentId(assignment1.IdValue, LogTemplate.LogType.Standard);
                Assert.IsNotNull(results.FindById(logTemplate1.Id));
                Assert.IsNotNull(results.FindById(logTemplate4.Id));

                Assert.IsNull(results.FindById(logTemplate2.Id));
                Assert.IsNull(results.FindById(logTemplate3.Id));
            }
            {
                List<LogTemplateDTO> results = dtoDao.QueryByWorkAssignmentId(assignment2.IdValue, LogTemplate.LogType.Standard);
                Assert.IsNotNull(results.FindById(logTemplate2.Id));
                Assert.IsNotNull(results.FindById(logTemplate4.Id));

                Assert.IsNull(results.FindById(logTemplate1.Id));
                Assert.IsNull(results.FindById(logTemplate3.Id));
            }
            {
                List<LogTemplateDTO> results = dtoDao.QueryByWorkAssignmentId(assignment3.IdValue, LogTemplate.LogType.Standard);
                Assert.IsNotNull(results.FindById(logTemplate3.Id));

                Assert.IsNull(results.FindById(logTemplate4.Id));
                Assert.IsNull(results.FindById(logTemplate2.Id));
                Assert.IsNull(results.FindById(logTemplate1.Id));
            }
            {
                dao.Delete(logTemplate1);
                List<LogTemplateDTO> results = dtoDao.QueryByWorkAssignmentId(assignment1.IdValue, LogTemplate.LogType.Standard);
                Assert.IsNotNull(results.FindById(logTemplate4.Id));

                Assert.IsNull(results.FindById(logTemplate1.Id));
                Assert.IsNull(results.FindById(logTemplate2.Id));
                Assert.IsNull(results.FindById(logTemplate3.Id));
            }

        }

        [Ignore] [Test]
        public void ShouldQueryByWorkAssignment_VaryLogType()
        {
            User createUser = UserFixture.CreateUserWithGivenId(1);
            User modifyUser = UserFixture.CreateUserWithGivenId(2);
            DateTime createDateTime = new DateTime(2010, 11, 20);
            DateTime modifiedDateTime = new DateTime(2010, 11, 26);

            WorkAssignment assignment1 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("Test WA 1"));
            assignment1 = workAssignmentDao.Insert(assignment1); 
            List<WorkAssignment> assignmentList1 = new List<WorkAssignment> { assignment1 };

            // Summary log
            LogTemplate logTemplate1 = new LogTemplate("Template 1", "This is template 1", assignmentList1, false, true, false, modifyUser,
                    modifiedDateTime, createUser, createDateTime);
            // Summary Log
            LogTemplate logTemplate2 = new LogTemplate("Template 2", "This is template 2", assignmentList1, false, true, false, modifyUser,
                    modifiedDateTime, createUser, createDateTime);
            // Regular Log
            LogTemplate logTemplate3 = new LogTemplate("Template 3", "This is template 3", assignmentList1, true, false, false, modifyUser,
                    modifiedDateTime, createUser, createDateTime);
            // Regular Log and Summary Log
            LogTemplate logTemplate4 = new LogTemplate("Template 4", "This is template 4", assignmentList1, true, true, false, modifyUser,
                    modifiedDateTime, createUser, createDateTime);
            // Directive
            LogTemplate logTemplate5 = new LogTemplate("Template 5", "This is template 5", assignmentList1, false, false, true, modifyUser,
                    modifiedDateTime, createUser, createDateTime);

            logTemplate1 = dao.Insert(logTemplate1);
            logTemplate2 = dao.Insert(logTemplate2);
            logTemplate3 = dao.Insert(logTemplate3);
            logTemplate4 = dao.Insert(logTemplate4);
            logTemplate5 = dao.Insert(logTemplate5);

            {
                List<LogTemplateDTO> results = dtoDao.QueryByWorkAssignmentId(assignment1.IdValue, LogTemplate.LogType.Standard);

                Assert.IsNull(results.FindById(logTemplate1.Id));
                Assert.IsNull(results.FindById(logTemplate2.Id));
                Assert.IsNotNull(results.FindById(logTemplate3.Id));
                Assert.IsNotNull(results.FindById(logTemplate4.Id));
                Assert.IsNull(results.FindById(logTemplate5.Id));
            }
            {
                List<LogTemplateDTO> results = dtoDao.QueryByWorkAssignmentId(assignment1.IdValue, LogTemplate.LogType.SummaryLog);

                Assert.IsNotNull(results.FindById(logTemplate1.Id));
                Assert.IsNotNull(results.FindById(logTemplate2.Id));
                Assert.IsNull(results.FindById(logTemplate3.Id));
                Assert.IsNotNull(results.FindById(logTemplate4.Id));
                Assert.IsNull(results.FindById(logTemplate5.Id));
            }
            {
                List<LogTemplateDTO> results = dtoDao.QueryByWorkAssignmentId(assignment1.IdValue, LogTemplate.LogType.DailyDirective);

                Assert.IsNull(results.FindById(logTemplate1.Id));
                Assert.IsNull(results.FindById(logTemplate2.Id));
                Assert.IsNull(results.FindById(logTemplate3.Id));
                Assert.IsNull(results.FindById(logTemplate4.Id));
                Assert.IsNotNull(results.FindById(logTemplate5.Id));
            }
        }

    }
}