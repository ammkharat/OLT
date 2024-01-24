using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class FormLubesCsdDaoTest : AbstractDaoTest
    {
        private ILubesCsdFormDTODao dtoDao;
        private IFormLubesCsdDao formDao;

       
        [Ignore] [Test]
        public void PlainTextCommentsShouldSupportUnicodeCharacters()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            var validToDateTime = Clock.Now.AddDays(-5);
            var form = FormLubesCsdFixture.CreateForInsert(floc1, Clock.Now.AddDays(-11), validToDateTime,
                FormStatus.Approved);

            const string contentWithFunnyCharacters = "hello˚ thereӸ";
            // fun fact: that first funny character is a 'ring above', not a degree symbol
            const string otherContentWithFunnyCharacters = "hey˚ ohӸ";
            form.PlainTextContent = contentWithFunnyCharacters;

            formDao.Insert(form);
            var requeriedForm = formDao.QueryById(form.IdValue);
            Assert.AreEqual(contentWithFunnyCharacters, requeriedForm.PlainTextContent);

            // check update
            {
                form.PlainTextContent = otherContentWithFunnyCharacters;
                formDao.Update(form);
                requeriedForm = formDao.QueryById(form.IdValue);
                Assert.AreEqual(otherContentWithFunnyCharacters, requeriedForm.PlainTextContent);
            }
        }
        
        [Ignore] [Test]
        public void
            QueryAllThatAreApprovedAndAreMoreThan10DaysOutOfServiceShouldOnlyReturnFormsThatAreMoreThan7DaysOutOfService
            ()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();

            var functionalLocations = new List<FunctionalLocation>
            {
                floc1,
                floc2
            };

            var validToDateTime = Clock.Now.AddDays(-5);

            var formOne = FormLubesCsdFixture.CreateForInsert(floc1, Clock.Now.AddDays(-8),
                validToDateTime,
                FormStatus.Approved);
            var formTwo = FormLubesCsdFixture.CreateForInsert(floc2, Clock.Now.AddDays(-7),
                validToDateTime,
                FormStatus.Approved);
            var formThree = FormLubesCsdFixture.CreateForInsert(floc1, Clock.Now.AddDays(-6),
                validToDateTime,
                FormStatus.Approved);

            formOne = formDao.Insert(formOne);
            formDao.Insert(formTwo);
            formDao.Insert(formThree);

            var results = formDao.QueryAllThatAreApprovedAndAreMoreThan7DaysOutOfService(Clock.Now);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(formOne.Id, results[0].Id);
        }
        
        [Ignore] [Test]
        public void QueryAllThatAreApprovedAndAreMoreThan7DaysOutOfServiceShouldOnlyReturnApprovedForms()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();

            var validFromDateTime = Clock.Now.AddDays(-8);
            var validToDateTime = Clock.Now.AddDays(-3);

            var formDraft = FormLubesCsdFixture.CreateForInsert(floc1, validFromDateTime, validToDateTime,
                FormStatus.Draft);
            var formApproved = FormLubesCsdFixture.CreateForInsert(floc1, validFromDateTime,
                validToDateTime,
                FormStatus.Approved);
            var formClosed = FormLubesCsdFixture.CreateForInsert(floc2, validFromDateTime, validToDateTime,
                FormStatus.Closed);

            formDao.Insert(formDraft);
            formApproved = formDao.Insert(formApproved);
            formDao.Insert(formClosed);

            var results = formDao.QueryAllThatAreApprovedAndAreMoreThan7DaysOutOfService(Clock.Now);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(formApproved.Id, results[0].Id);
        }
       
        [Ignore] [Test]
        public void ShouldInsert()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            var validFromDateTime = Clock.Now;
            var validToDateTime = Clock.Now.AddHours(5);

            var form = FormLubesCsdFixture.CreateForInsert(floc1, validFromDateTime, validToDateTime,
                FormStatus.Draft);

            formDao.Insert(form);

            Assert.That(form.Id, Is.GreaterThan(0));
            Assert.That(form.FormNumber, Is.GreaterThan(0));

            RequeryAndAssertFieldsAreEqual(form);
        }
        
        [Ignore] [Test]
        public void ShouldRemove()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();

            var functionalLocations = new List<FunctionalLocation>
            {
                floc1,
                floc2
            };

            var validFromDateTime = Clock.Now;
            var validToDateTime = Clock.Now.AddHours(5);

            var form = FormLubesCsdFixture.CreateForInsert(floc1, validFromDateTime, validToDateTime,
                FormStatus.Draft);

            formDao.Insert(form);

            var requeried = formDao.QueryById(form.IdValue);
            Assert.IsNotNull(requeried.Id);

            IFlocSet flocSet = new ExactFlocSet(functionalLocations);
            var dtos = dtoDao.QueryFormCsd(flocSet,
                new DateRange(new Date(validFromDateTime), new Date(validToDateTime)), FormStatus.All, false);
            Assert.IsTrue(dtos.Exists(d => d.IdValue == requeried.IdValue));

            formDao.Remove(form);

            var listWithoutNewForm = dtoDao.QueryFormCsd(flocSet,
                new DateRange(new Date(validFromDateTime), new Date(validToDateTime)), FormStatus.All, false);
            Assert.IsFalse(listWithoutNewForm.Exists(d => d.IdValue == requeried.IdValue));
        }
       
        [Ignore] [Test]
        public void ShouldSortApprovalsByDisplayOrder()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            var validFromDateTime = Clock.Now;
            var validToDateTime = Clock.Now.AddHours(5);

            var form = FormLubesCsdFixture.CreateForInsert(floc1, validFromDateTime, validToDateTime,
                FormStatus.Draft);
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "b", null, null, null, 2));
            form.Approvals.Add(new FormApproval(null, null, "z", null, null, null, 1));
            form.Approvals.Add(new FormApproval(null, null, "r", null, null, null, 3));

            formDao.Insert(form);

            var requeried = formDao.QueryById(form.IdValue);
            Assert.AreEqual(3, requeried.Approvals.Count);
            Assert.AreEqual("z", requeried.Approvals[0].Approver);
            Assert.AreEqual("b", requeried.Approvals[1].Approver);
            Assert.AreEqual("r", requeried.Approvals[2].Approver);
        }
     
        [Ignore] [Test]
        public void ShouldUpdateForm()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            var validFrom = new DateTime(2012, 10, 1, 13, 0, 0);
            var validTo = new DateTime(2012, 10, 2, 16, 0, 0);

            var form = FormLubesCsdFixture.CreateForInsert(floc1, validFrom,
                validTo,
                FormStatus.Draft);
            form = formDao.Insert(form);
            form.MarkAsApproved(new DateTime(2016, 1, 2));
            form.FormStatus = FormStatus.Approved;
            form.Content = form.Content + "changed";
            form.PlainTextContent = form.PlainTextContent + "chged";
            form.FromDateTime = form.FromDateTime.AddHours(3);
            form.ToDateTime = form.ToDateTime.AddHours(3);
            form.ClosedDateTime = new DateTime(2015, 1, 1);
            form.IsTheCSDForAPressureSafetyValve = !form.IsTheCSDForAPressureSafetyValve;
            form.CriticalSystemDefeated = "This is a new value";
            form.DocumentLinks.Clear();
            form.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            var modifyUser = UserFixture.CreateUserWithGivenId(2);

            foreach (var approval in form.Approvals)
            {
                approval.ApprovedByUser = modifyUser;
                approval.ApprovalDateTime = approval.ApprovalDateTime == null
                    ? new DateTime(2012, 11, 1)
                    : approval.ApprovalDateTime.Value.AddHours(5);
            }
            formDao.Update(form);

            RequeryAndAssertFieldsAreEqual(form);
            Assert.That(form.HasBeenApproved, Is.True);
        }

        protected override void TestInitialize()
        {
            formDao = DaoRegistry.GetDao<IFormLubesCsdDao>();
            dtoDao = DaoRegistry.GetDao<ILubesCsdFormDTODao>();

            Clock.Freeze();
        }

        protected override void Cleanup()
        {
            Clock.UnFreeze();
        }

        private void RequeryAndAssertFieldsAreEqual(LubesCsdForm form)
        {
            var requeried = formDao.QueryById(form.IdValue);

            Assert.IsNotNull(requeried);

            Assert.AreEqual(form.FormStatus, requeried.FormStatus);
            Assert.AreEqual(form.FormNumber, requeried.FormNumber);

            Assert.That(form.FromDateTime, Is.EqualTo(requeried.FromDateTime).Within(TimeSpan.FromSeconds(1)));
            Assert.That(form.ToDateTime, Is.EqualTo(requeried.ToDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(form.Content, requeried.Content);
            Assert.AreEqual(form.PlainTextContent, requeried.PlainTextContent);
            Assert.That(form.ApprovedDateTime, Is.EqualTo(requeried.ApprovedDateTime).Within(TimeSpan.FromSeconds(1)));
            Assert.That(form.ClosedDateTime, Is.EqualTo(requeried.ClosedDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(form.IsTheCSDForAPressureSafetyValve, requeried.IsTheCSDForAPressureSafetyValve);
            Assert.AreEqual(form.CriticalSystemDefeated, requeried.CriticalSystemDefeated);

            Assert.AreEqual(form.CreatedBy.IdValue, requeried.CreatedBy.IdValue);
            Assert.That(form.CreatedDateTime, Is.EqualTo(requeried.CreatedDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(form.LastModifiedBy.IdValue, requeried.LastModifiedBy.IdValue);
            Assert.That(form.LastModifiedDateTime,
                Is.EqualTo(requeried.LastModifiedDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(form.FunctionalLocation.FullHierarchy, requeried.FunctionalLocation.FullHierarchy);

            Assert.AreEqual(form.Approvals.Count, requeried.Approvals.Count);
            foreach (var approval in form.Approvals)
            {
                var requeriedApproval = requeried.Approvals.Find(a => a.Approver == approval.Approver);
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