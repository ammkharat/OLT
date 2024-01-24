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
    public class FormGN6DaoTest : AbstractDaoTest
    {
        private IFormGN6Dao dao;
        private IFormEdmontonGN6DTODao dtoDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IFormGN6Dao>();
            dtoDao = DaoRegistry.GetDao<IFormEdmontonGN6DTODao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_ED1_A001_U007(), FunctionalLocationFixture.GetReal_ED1_A001_U008() };

            DateTime validFromDateTime = Clock.Now;
            DateTime validToDateTime = Clock.Now.AddHours(5);

            FormGN6 form = FormGN6Fixture.CreateForInsert(functionalLocations, validFromDateTime, validToDateTime, FormStatus.Draft);

            dao.Insert(form);

            Assert.That(form.Id, Is.GreaterThan(0));
            Assert.That(form.FormNumber, Is.GreaterThan(0));

            RequeryAndAssertFieldsAreEqual(form);
        }

        [Ignore] [Test]
        public void ShouldUpdateForm()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();

            DateTime validFrom = new DateTime(2012, 10, 1, 13, 0, 0);
            DateTime validTo = new DateTime(2012, 10, 2, 16, 0, 0);

            FormGN6 form = FormGN6Fixture.CreateForInsert(new List<FunctionalLocation> {floc1, floc2}, validFrom, validTo, FormStatus.Draft);
            dao.Insert(form);

            form.FormStatus = FormStatus.Approved;
            form.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_ED1_A001_U007_SCC());
            form.FromDateTime = form.FromDateTime.AddHours(3);
            form.ToDateTime = form.ToDateTime.AddHours(3);
            form.ApprovedDateTime = new DateTime(2016, 1, 2);
            form.ClosedDateTime = new DateTime(2015, 1, 1);
            form.JobDescription = form.JobDescription + "chged";
            form.ReasonForCriticalLift = form.ReasonForCriticalLift + "chged";
            form.Section1Content = form.Section1Content + "chged";
            form.Section1PlainTextContent = form.Section1PlainTextContent + "chged";
            form.Section1NotApplicableToJob = !form.Section1NotApplicableToJob;

            form.Section1Content = form.Section1Content + "chged";
            form.Section1PlainTextContent = form.Section1PlainTextContent + "chged";
            form.Section1NotApplicableToJob = !form.Section1NotApplicableToJob;

            form.Section2Content = form.Section2Content + "chged";
            form.Section2PlainTextContent = form.Section2PlainTextContent + "chged";
            form.Section2NotApplicableToJob = !form.Section2NotApplicableToJob;

            form.Section3Content = form.Section3Content + "chged";
            form.Section3PlainTextContent = form.Section3PlainTextContent + "chged";
            form.Section3NotApplicableToJob = !form.Section3NotApplicableToJob;

            form.Section4Content = form.Section4Content + "chged";
            form.Section4PlainTextContent = form.Section4PlainTextContent + "chged";
            form.Section4NotApplicableToJob = !form.Section4NotApplicableToJob;

            form.Section5Content = form.Section5Content + "chged";
            form.Section5PlainTextContent = form.Section5PlainTextContent + "chged";
            form.Section5NotApplicableToJob = !form.Section5NotApplicableToJob;

            form.Section6Content = form.Section6Content + "chged";
            form.Section6PlainTextContent = form.Section6PlainTextContent + "chged";
            form.Section6NotApplicableToJob = !form.Section6NotApplicableToJob;

            form.PreJobMeetingSignatures = form.PreJobMeetingSignatures + "changed";
            form.PlainTextPreJobMeetingSignatures = form.PlainTextPreJobMeetingSignatures + "changed";

            User modifyUser = UserFixture.CreateUserWithGivenId(2);

            foreach (FormApproval approval in form.Approvals)
            {
                approval.ApprovedByUser = modifyUser;
                approval.ApprovalDateTime = approval.ApprovalDateTime == null
                                                ? new DateTime(2012, 11, 1)
                                                : approval.ApprovalDateTime.Value.AddHours(5);
            }

            dao.Update(form);

            RequeryAndAssertFieldsAreEqual(form);
        }

        [Ignore] [Test]
        public void InsertShouldInsertDocumentLinks()
        {
            List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_ED1_A001_U007(), FunctionalLocationFixture.GetReal_ED1_A001_U008() };

            FormGN6 form = FormGN6Fixture.CreateForInsert(functionalLocations, Clock.Now, Clock.Now.AddHours(5), FormStatus.Draft);
            form.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            form.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());
            dao.Insert(form);

            FormGN6 requeried = dao.QueryById(form.IdValue);

            Assert.AreEqual(form.DocumentLinks.Count, requeried.DocumentLinks.Count);
            Assert.That(requeried.DocumentLinks, Has.Some.EqualTo(form.DocumentLinks[0]));
            Assert.That(requeried.DocumentLinks, Has.Some.EqualTo(form.DocumentLinks[1]));
        }

        [Ignore] [Test]
        public void UpdateShouldRemoveDeletedDocumentLinks()
        {
            List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_ED1_A001_U007(), FunctionalLocationFixture.GetReal_ED1_A001_U008() };

            FormGN6 form = FormGN6Fixture.CreateForInsert(functionalLocations, Clock.Now, Clock.Now.AddHours(5), FormStatus.Draft);
            form.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            form.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());
            dao.Insert(form);

            long removedLinkId = form.DocumentLinks[0].IdValue;
            long retainedLinkId = form.DocumentLinks[1].IdValue;

            form.DocumentLinks.Remove(form.DocumentLinks[0]);
            dao.Update(form);

            FormGN6 requeried = dao.QueryById(form.IdValue);
            Assert.AreEqual(form.DocumentLinks.Count, requeried.DocumentLinks.Count);
            Assert.That(requeried.DocumentLinks, Has.None.Property("Id").EqualTo(removedLinkId));
            Assert.That(requeried.DocumentLinks, Has.Some.Property("Id").EqualTo(retainedLinkId));
        }

        [Ignore] [Test]
        public void UpdateShouldAddNewDocumentLink()
        {
            List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_ED1_A001_U007(), FunctionalLocationFixture.GetReal_ED1_A001_U008() };

            FormGN6 form = FormGN6Fixture.CreateForInsert(functionalLocations, Clock.Now, Clock.Now.AddHours(5), FormStatus.Draft);
            form.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            dao.Insert(form);

            form.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());
            dao.Update(form);

            FormGN6 requeried = dao.QueryById(form.IdValue);
            Assert.AreEqual(form.DocumentLinks.Count, requeried.DocumentLinks.Count);
            Assert.That(requeried.DocumentLinks, Has.Some.Property("Id").EqualTo(form.DocumentLinks[0].Id));
            Assert.That(requeried.DocumentLinks, Has.Some.Property("Id").EqualTo(form.DocumentLinks[1].Id));
        }

        [Ignore] [Test] 
        public void ShouldRemove()
        {
            List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_ED1_A001_U007(), FunctionalLocationFixture.GetReal_ED1_A001_U008() };
            FormGN6 form = FormGN6Fixture.CreateForInsert(functionalLocations, Clock.Now, Clock.Now.AddHours(5), FormStatus.Draft);
            form.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            dao.Insert(form);

            {
                List<FormEdmontonGN6DTO> listThatIncludesThisOne = dtoDao.QueryDTOs(new RootFlocSet(functionalLocations), new DateRange(new Date(Clock.Now), new Date(Clock.Now)), FormStatus.All, false);
                Assert.IsTrue(listThatIncludesThisOne.Exists(i => i.IdValue == form.IdValue));                
            }

            dao.Remove(form);

            {
                List<FormEdmontonGN6DTO> listThatIncludesThisOne = dtoDao.QueryDTOs(new RootFlocSet(functionalLocations), new DateRange(new Date(Clock.Now), new Date(Clock.Now)), FormStatus.All, false);
                Assert.IsFalse(listThatIncludesThisOne.Exists(i => i.IdValue == form.IdValue));
            }
        }

        private void RequeryAndAssertFieldsAreEqual(FormGN6 form)
        {
            FormGN6 requeried = dao.QueryById(form.IdValue);

            Assert.IsNotNull(requeried);

            Assert.AreEqual(form.FormStatus, requeried.FormStatus);
            Assert.AreEqual(form.FormNumber, requeried.FormNumber);

            Assert.That(form.FromDateTime, Is.EqualTo(requeried.FromDateTime).Within(TimeSpan.FromSeconds(1)));
            Assert.That(form.ToDateTime, Is.EqualTo(requeried.ToDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.That(form.ApprovedDateTime, Is.EqualTo(requeried.ApprovedDateTime).Within(TimeSpan.FromSeconds(1)));
            Assert.That(form.ClosedDateTime, Is.EqualTo(requeried.ClosedDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(form.JobDescription, requeried.JobDescription);
            Assert.AreEqual(form.ReasonForCriticalLift, requeried.ReasonForCriticalLift);

            Assert.AreEqual(form.Section1Content, requeried.Section1Content);
            Assert.AreEqual(form.Section1PlainTextContent, requeried.Section1PlainTextContent);
            Assert.AreEqual(form.Section1NotApplicableToJob, requeried.Section1NotApplicableToJob);

            Assert.AreEqual(form.Section2Content, requeried.Section2Content);
            Assert.AreEqual(form.Section2PlainTextContent, requeried.Section2PlainTextContent);
            Assert.AreEqual(form.Section2NotApplicableToJob, requeried.Section2NotApplicableToJob);

            Assert.AreEqual(form.Section3Content, requeried.Section3Content);
            Assert.AreEqual(form.Section3PlainTextContent, requeried.Section3PlainTextContent);
            Assert.AreEqual(form.Section3NotApplicableToJob, requeried.Section3NotApplicableToJob);

            Assert.AreEqual(form.Section4Content, requeried.Section4Content);
            Assert.AreEqual(form.Section4PlainTextContent, requeried.Section4PlainTextContent);
            Assert.AreEqual(form.Section4NotApplicableToJob, requeried.Section4NotApplicableToJob);

            Assert.AreEqual(form.Section5Content, requeried.Section5Content);
            Assert.AreEqual(form.Section5PlainTextContent, requeried.Section5PlainTextContent);
            Assert.AreEqual(form.Section5NotApplicableToJob, requeried.Section5NotApplicableToJob);

            Assert.AreEqual(form.Section6Content, requeried.Section6Content);
            Assert.AreEqual(form.Section6PlainTextContent, requeried.Section6PlainTextContent);
            Assert.AreEqual(form.Section6NotApplicableToJob, requeried.Section6NotApplicableToJob);

            Assert.AreEqual(form.PreJobMeetingSignatures, requeried.PreJobMeetingSignatures);
            Assert.AreEqual(form.PlainTextPreJobMeetingSignatures, requeried.PlainTextPreJobMeetingSignatures);

            Assert.AreEqual(form.CreatedBy.IdValue, requeried.CreatedBy.IdValue);
            Assert.That(form.CreatedDateTime, Is.EqualTo(requeried.CreatedDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(form.LastModifiedBy.IdValue, requeried.LastModifiedBy.IdValue);
            Assert.That(form.LastModifiedDateTime, Is.EqualTo(requeried.LastModifiedDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(form.FunctionalLocations.Count, requeried.FunctionalLocations.Count);
            foreach (FunctionalLocation floc in form.FunctionalLocations)
            {
                Assert.IsTrue(requeried.FunctionalLocations.Contains(floc));
            }

            Assert.AreEqual(form.Approvals.Count, requeried.Approvals.Count);
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
