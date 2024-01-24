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
    [Category("Database")]
    public class FormGN75ADaoTest : AbstractDaoTest
    {
        private IFormGN75ADao dao;
        private IFormEdmontonGN75ADTODao dtoDao; 
        private IFormGN75BDao gn75BDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IFormGN75ADao>();
            dtoDao = DaoRegistry.GetDao<IFormEdmontonGN75ADTODao>();
            gn75BDao = DaoRegistry.GetDao<IFormGN75BDao>();
        }

        protected override void Cleanup()
        {        
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            DateTime validFromDateTime = Clock.Now;
            DateTime validToDateTime = Clock.Now.AddHours(5);

            FormGN75B formGn75B = InsertGN75BFormToAssociate();

            FormGN75A form = FormGN75AFixture.CreateForInsert(functionalLocation, validFromDateTime, validToDateTime, FormStatus.Draft);

            if (formGn75B != null)
            {
                form.AssociatedFormGN75BNumber = formGn75B.Id;
            }

            dao.Insert(form);

            Assert.That(form.Id, Is.GreaterThan(0));
            Assert.That(form.FormNumber, Is.GreaterThan(0));            

            Assert.IsNotNull(form.AssociatedFormGN75BNumber);

            RequeryAndAssertFieldsAreEqual(form);            
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            DateTime validFromDateTime = Clock.Now;
            DateTime validToDateTime = Clock.Now.AddHours(5);

            FormGN75B formGn75B = InsertGN75BFormToAssociate();

            FormGN75A form = FormGN75AFixture.CreateForInsert(functionalLocation, validFromDateTime, validToDateTime, FormStatus.Draft);

            form.AssociatedFormGN75BNumber = formGn75B.Id;

            dao.Insert(form);

            // now change the form
            FormGN75A formToUpdate = dao.QueryById(form.IdValue);

            FormGN75B anotherformGn75B = InsertGN75BFormToAssociate();

            formToUpdate.AssociatedFormGN75BNumber = anotherformGn75B.Id;

            ChangeValuesOnForm(formToUpdate);

            dao.Update(formToUpdate);

            RequeryAndAssertFieldsAreEqual(formToUpdate);
        }

        [Ignore] [Test]
        public void ShouldRemove()
        {
            FormGN75A insertedForm;

            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            DateTime validFromDateTime = Clock.Now;
            DateTime validToDateTime = Clock.Now.AddHours(5);


            {
                FormGN75A form = FormGN75AFixture.CreateForInsert(functionalLocation, validFromDateTime, validToDateTime, FormStatus.Draft);

                dao.Insert(form);
                insertedForm = form;

                List<FormEdmontonGN75ADTO> dtos = dtoDao.QueryDTOs(new ExactFlocSet(functionalLocation), new DateRange(new Date(validFromDateTime), new Date(validToDateTime)), new List<FormStatus> { FormStatus.Draft }, false);

                Assert.IsTrue(dtos.Exists(dto => dto.IdValue == insertedForm.IdValue));
            }

            {
                dao.Remove(insertedForm);
                List<FormEdmontonGN75ADTO> dtos = dtoDao.QueryDTOs(new ExactFlocSet(functionalLocation), new DateRange(new Date(validFromDateTime), new Date(validToDateTime)), new List<FormStatus> { FormStatus.Draft }, false);
                Assert.IsFalse(dtos.Exists(dto => dto.IdValue == insertedForm.IdValue));
            }           
        }

        private void ChangeValuesOnForm(FormGN75A formToUpdate)
        {
            formToUpdate.FromDateTime = Clock.Now.AddHours(1);
            formToUpdate.ToDateTime = Clock.Now.AddHours(6);

            formToUpdate.FunctionalLocation = FunctionalLocationFixture.GetReal_ED1_A001_U008();

            formToUpdate.FormStatus = FormStatus.Closed;

            formToUpdate.Content = "content! (Revised)";
            formToUpdate.PlainTextContent = "content! (Revised plain text)";
            formToUpdate.ApprovedDateTime = Clock.Now.AddDays(2);
            formToUpdate.ClosedDateTime = Clock.Now.AddDays(3);
            

            formToUpdate.LastModifiedBy = UserFixture.CreateUserWithGivenId(2);
            formToUpdate.LastModifiedDateTime = Clock.Now.AddMinutes(2);

            formToUpdate.Approvals[0].ApprovedByUser = UserFixture.CreateUserWithGivenId(1);
            formToUpdate.Approvals[1].ApprovedByUser = UserFixture.CreateUserWithGivenId(2);
            
            formToUpdate.DocumentLinks = new List<DocumentLink> { DocumentLinkFixture.CreateNewDocumentLink()};
        }

        private FormGN75B InsertGN75BFormToAssociate()
        {
            FunctionalLocation functionalLocation = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            FormGN75B form = new FormGN75B(functionalLocation, functionalLocation.Description, new List<IsolationItem>(0), UserFixture.CreateUserWithGivenId(1), Clock.Now, UserFixture.CreateUserWithGivenId(1),
                                     Clock.Now, false,false,false, string.Empty, string.Empty, string.Empty,8, new List<DevicePosition>(0),0,null,null);   //ayman Sarnia eip DMND0008992

            gn75BDao.Insert(form);

            return form;
        }

        private void RequeryAndAssertFieldsAreEqual(FormGN75A form)
        {
            FormGN75A requeried = dao.QueryById(form.IdValue);

            Assert.IsNotNull(requeried);
            
            Assert.AreEqual(form.FormStatus, requeried.FormStatus);
            Assert.AreEqual(form.FormNumber, requeried.FormNumber);

            Assert.That(form.FromDateTime, Is.EqualTo(requeried.FromDateTime).Within(TimeSpan.FromSeconds(1)));
            Assert.That(form.ToDateTime, Is.EqualTo(requeried.ToDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(form.Content, requeried.Content);
            Assert.AreEqual(form.PlainTextContent, requeried.PlainTextContent);
            Assert.That(form.ApprovedDateTime, Is.EqualTo(requeried.ApprovedDateTime).Within(TimeSpan.FromSeconds(1)));
            Assert.That(form.ClosedDateTime, Is.EqualTo(requeried.ClosedDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(form.CreatedBy.IdValue, requeried.CreatedBy.IdValue);
            Assert.That(form.CreatedDateTime, Is.EqualTo(requeried.CreatedDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(form.LastModifiedBy.IdValue, requeried.LastModifiedBy.IdValue);
            Assert.That(form.LastModifiedDateTime, Is.EqualTo(requeried.LastModifiedDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(form.FunctionalLocation, requeried.FunctionalLocation);
          
            Assert.AreEqual(form.Approvals.Count, requeried.Approvals.Count);

            if (!form.AssociatedFormGN75BNumber.HasValue)
            {
                Assert.IsNull(requeried.AssociatedFormGN75BNumber);
            }
            else
            {
                if (requeried.AssociatedFormGN75BNumber == null)
                {
                    Assert.Fail("AssociatedFormGN75B should not be null");
                }

                Assert.AreEqual(form.AssociatedFormGN75BNumber, requeried.AssociatedFormGN75BNumber);
            }

            foreach (FormApproval approval in form.Approvals)
            {
                FormApproval requeriedApproval = requeried.Approvals.Find(a => a.Approver == approval.Approver);
                Assert.AreEqual(form.IdValue, requeriedApproval.FormId);

                if (approval.ApprovedByUser == null)
                {
                    Assert.IsNull(requeriedApproval.ApprovedByUser);
                }
                else
                {
                    Assert.AreEqual(approval.ApprovedByUser.IdValue, requeriedApproval.ApprovedByUser.IdValue);
                }

                Assert.That(approval.ApprovalDateTime,
                            Is.EqualTo(requeriedApproval.ApprovalDateTime).Within(TimeSpan.FromSeconds(1)));
            }
        }
    }
}