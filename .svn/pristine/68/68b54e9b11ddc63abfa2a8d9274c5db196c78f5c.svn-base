using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    public class FormGN1DaoTest : AbstractDaoTest
    {
        private IFormGN1Dao dao;
        private IFormEdmontonGN1DTODao dtoDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IFormGN1Dao>();
            dtoDao = DaoRegistry.GetDao<IFormEdmontonGN1DTODao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]          
        public void ShouldInsertAndQueryById()
        {
            FormGN1 form = FormGN1Fixture.CreateForInsert();

            dao.Insert(form);

            FormGN1 requeriedForm = dao.QueryById(form.IdValue);

            Assert.AreEqual(form.IdValue, requeriedForm.IdValue);
            Assert.AreEqual(form.FunctionalLocation.IdValue, requeriedForm.FunctionalLocation.IdValue);
            Assert.AreEqual(form.Location, requeriedForm.Location);
            Assert.AreEqual(form.TradeChecklistNames, requeriedForm.TradeChecklistNames);
            Assert.AreEqual(form.CSELevel, requeriedForm.CSELevel);
            Assert.AreEqual(form.JobDescription, requeriedForm.JobDescription);
            Assert.AreEqual(form.DocumentLinks.Count, requeriedForm.DocumentLinks.Count);
            Assert.AreEqual(form.PlanningWorksheetContent, requeriedForm.PlanningWorksheetContent);
            Assert.AreEqual(form.PlanningWorksheetApprovals.Count, requeriedForm.PlanningWorksheetApprovals.Count);
            Assert.AreEqual(form.TradeChecklists.Count, requeriedForm.TradeChecklists.Count);
            Assert.AreEqual(form.RescuePlanContent, requeriedForm.RescuePlanContent);
            Assert.AreEqual(form.RescuePlanApprovals.Count, requeriedForm.RescuePlanApprovals.Count);

            Assert.AreEqual(2, requeriedForm.TradeChecklists.Count);
        }

        [Ignore] [Test]
        public void ShouldRemove()
        {
            FormGN1 form = FormGN1Fixture.CreateForInsert();
            dao.Insert(form);

            List<FormEdmontonGN1DTO> result = dtoDao.QueryDTOs(new ExactFlocSet(form.FunctionalLocation), new DateRange(new Date(form.FromDateTime), new Date(form.ToDateTime)), new List<FormStatus> { FormStatus.Draft }, false);
            Assert.IsTrue(result.Exists(item => item.IdValue == form.IdValue));
            
            dao.Remove(form);

            result = dtoDao.QueryDTOs(new ExactFlocSet(form.FunctionalLocation), new DateRange(new Date(form.FromDateTime), new Date(form.ToDateTime)), new List<FormStatus> { FormStatus.Draft }, false);
            Assert.IsFalse(result.Exists(item => item.IdValue == form.IdValue));           
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            FormGN1 originalFormToInsert = FormGN1Fixture.CreateForInsert();

            dao.Insert(originalFormToInsert);

            FormGN1 formToUpdate = dao.QueryById(originalFormToInsert.IdValue);

            DateTime fromDateTime = new DateTime(2014, 2, 18, 1, 2, 3);
            DateTime toDateTime = new DateTime(2014, 2, 18, 4, 5, 6);

            formToUpdate.FormStatus = FormStatus.Approved;
            formToUpdate.FunctionalLocation = FunctionalLocationFixture.GetReal_ED1_A001_U007_SCC();
            formToUpdate.Location = "This is a new location";
            formToUpdate.CSELevel = "2";            
            formToUpdate.FromDateTime = fromDateTime;            
            formToUpdate.ToDateTime = toDateTime;

            formToUpdate.JobDescription = "Slop the pigs";
            formToUpdate.DocumentLinks = new List<DocumentLink> { DocumentLinkFixture.CreateAnotherNewDocumentLink() };
            formToUpdate.PlanningWorksheetContent = "This is a change to the planning worksheet content";
            formToUpdate.PlanningWorksheetPlainTextContent = "This is a change to the planning worksheet content in plain text";
            formToUpdate.TradeChecklists = new List<TradeChecklist>();
            formToUpdate.RescuePlanContent = "This is a change to the rescue plan content";
            formToUpdate.RescuePlanPlainTextContent = "This is a change to the rescue plan content in plain text";

            formToUpdate.PlanningWorksheetApprovals[0].ApprovedByUser = UserFixture.CreateUserWithGivenId(2);
            formToUpdate.RescuePlanApprovals[0].ApprovedByUser = UserFixture.CreateUserWithGivenId(3);

            dao.Update(formToUpdate);

            FormGN1 updatedForm = dao.QueryById(originalFormToInsert.IdValue);

            {
                Assert.AreNotEqual(originalFormToInsert.FormStatus, updatedForm.FormStatus);
                Assert.AreNotEqual(originalFormToInsert.FunctionalLocation.IdValue, updatedForm.FunctionalLocation.IdValue);
                Assert.AreNotEqual(originalFormToInsert.Location, updatedForm.Location);
                Assert.AreNotEqual(originalFormToInsert.CSELevel, updatedForm.CSELevel);
                Assert.AreNotEqual(originalFormToInsert.FromDateTime, updatedForm.FromDateTime);
                Assert.AreNotEqual(originalFormToInsert.ToDateTime, updatedForm.ToDateTime);
                Assert.AreNotEqual(originalFormToInsert.JobDescription, updatedForm.JobDescription);
                Assert.AreNotEqual(originalFormToInsert.DocumentLinks[0].TitleWithUrl, updatedForm.DocumentLinks[0].TitleWithUrl);
                Assert.AreNotEqual(originalFormToInsert.PlanningWorksheetContent, updatedForm.PlanningWorksheetContent);
                Assert.AreNotEqual(originalFormToInsert.PlanningWorksheetPlainTextContent, updatedForm.PlanningWorksheetPlainTextContent);
                Assert.AreNotEqual(originalFormToInsert.RescuePlanContent, updatedForm.RescuePlanContent);
                Assert.AreNotEqual(originalFormToInsert.RescuePlanPlainTextContent, updatedForm.RescuePlanPlainTextContent);
                Assert.IsNull(originalFormToInsert.PlanningWorksheetApprovals[0].ApprovedByUser);
                Assert.IsNull(originalFormToInsert.RescuePlanApprovals[0].ApprovedByUser);                                
            }

            {
                Assert.AreEqual(formToUpdate.FormStatus, updatedForm.FormStatus);
                Assert.AreEqual(formToUpdate.FunctionalLocation.IdValue, updatedForm.FunctionalLocation.IdValue);
                Assert.AreEqual(formToUpdate.Location, updatedForm.Location);
                Assert.AreEqual(formToUpdate.CSELevel, updatedForm.CSELevel);
                Assert.AreEqual(formToUpdate.FromDateTime, updatedForm.FromDateTime);
                Assert.AreEqual(formToUpdate.ToDateTime, updatedForm.ToDateTime);
                Assert.AreEqual(formToUpdate.JobDescription, updatedForm.JobDescription);
                Assert.AreEqual(formToUpdate.DocumentLinks[0].TitleWithUrl, updatedForm.DocumentLinks[0].TitleWithUrl);
                Assert.AreEqual(formToUpdate.PlanningWorksheetContent, updatedForm.PlanningWorksheetContent);
                Assert.AreEqual(formToUpdate.PlanningWorksheetPlainTextContent, updatedForm.PlanningWorksheetPlainTextContent);
                Assert.AreEqual(formToUpdate.RescuePlanContent, updatedForm.RescuePlanContent);
                Assert.AreEqual(formToUpdate.RescuePlanPlainTextContent, updatedForm.RescuePlanPlainTextContent);
                Assert.AreEqual(formToUpdate.PlanningWorksheetApprovals[0].ApprovedByUser.IdValue, updatedForm.PlanningWorksheetApprovals[0].ApprovedByUser.IdValue);
                Assert.AreEqual(formToUpdate.RescuePlanApprovals[0].ApprovedByUser.IdValue, updatedForm.RescuePlanApprovals[0].ApprovedByUser.IdValue);                
            }
        }
    }
}