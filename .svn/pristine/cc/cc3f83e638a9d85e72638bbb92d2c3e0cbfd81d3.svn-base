using System;
using System.Collections.Generic;
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
    public class FormGN59DaoTest : AbstractDaoTest
    {
        private IFormEdmontonDTODao dtoDao;
        private IFormGN59Dao formDao;

        [Ignore] [Test]
        public void PlainTextCommentsShouldSupportUnicodeCharacters()
        {
            var functionalLocations = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                FunctionalLocationFixture.GetReal_ED1_A001_U008()
            };
            var validToDateTime = Clock.Now.AddDays(-5);
            var form = FormGN59Fixture.CreateForInsert(functionalLocations, Clock.Now.AddDays(-11), validToDateTime, FormStatus.Approved);

            const string contentWithFunnyCharacters = "hello˚ thereӸ"; // fun fact: that first funny character is a 'ring above', not a degree symbol
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
        public void ShouldGenerateFormNumberUsingOneSweetSequence()
        {
            var formGN7Dao = DaoRegistry.GetDao<IFormGN7Dao>();
            var formOP14Dao = DaoRegistry.GetDao<IFormOP14Dao>();

            var functionalLocations = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                FunctionalLocationFixture.GetReal_ED1_A001_U008()
            };
            var validFromDateTime = Clock.Now;
            var validToDateTime = Clock.Now.AddHours(5);

            var firstForm = FormGN59Fixture.CreateForInsert(functionalLocations, validFromDateTime, validToDateTime, FormStatus.Draft);
            formDao.Insert(firstForm);

            var secondForm = FormGN7Fixture.CreateForInsert(functionalLocations, validFromDateTime, validToDateTime, FormStatus.Draft);
            formGN7Dao.Insert(secondForm);

            var thirdForm = FormGN59Fixture.CreateForInsert(functionalLocations, validFromDateTime, validToDateTime, FormStatus.Draft);
            formDao.Insert(thirdForm);

            var fourthForm = FormOP14Fixture.CreateForInsert(functionalLocations, validFromDateTime, validToDateTime, FormStatus.Draft);
            formOP14Dao.Insert(fourthForm);

            Assert.AreEqual(firstForm.FormNumber + 1, secondForm.FormNumber);
            Assert.AreEqual(secondForm.FormNumber + 1, thirdForm.FormNumber);
            Assert.AreEqual(thirdForm.FormNumber + 1, fourthForm.FormNumber);
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            var functionalLocations = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                FunctionalLocationFixture.GetReal_ED1_A001_U008()
            };

            var validFromDateTime = Clock.Now;
            var validToDateTime = Clock.Now.AddHours(5);

            var form = FormGN59Fixture.CreateForInsert(functionalLocations, validFromDateTime, validToDateTime, FormStatus.Draft);

            formDao.Insert(form);

            Assert.That(form.Id, Is.GreaterThan(0));
            Assert.That(form.FormNumber, Is.GreaterThan(0));

            RequeryAndAssertFieldsAreEqual(form);
        }

        [Ignore] [Test]
        public void ShouldRemove()
        {
            var functionalLocations = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                FunctionalLocationFixture.GetReal_ED1_A001_U008()
            };

            var validFromDateTime = Clock.Now;
            var validToDateTime = Clock.Now.AddHours(5);

            var form = FormGN59Fixture.CreateForInsert(functionalLocations, validFromDateTime, validToDateTime, FormStatus.Draft);

            formDao.Insert(form);

            var requeried = formDao.QueryById(form.IdValue);
            Assert.IsNotNull(requeried.Id);

            IFlocSet flocSet = new ExactFlocSet(functionalLocations);
            var dtos = dtoDao.QueryFormGN59(flocSet, new DateRange(new Date(validFromDateTime), new Date(validToDateTime)), FormStatus.All, false);
            Assert.IsTrue(dtos.Exists(d => d.IdValue == requeried.IdValue));

            formDao.Remove(form);

            var listWithoutNewForm = dtoDao.QueryFormGN59(flocSet, new DateRange(new Date(validFromDateTime), new Date(validToDateTime)), FormStatus.All, false);
            Assert.IsFalse(listWithoutNewForm.Exists(d => d.IdValue == requeried.IdValue));
        }

        [Ignore] [Test]
        public void ShouldSortApprovalsByDisplayOrder()
        {
            var functionalLocations = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.GetReal_ED1_A001_U007(),
                FunctionalLocationFixture.GetReal_ED1_A001_U008()
            };

            var validFromDateTime = Clock.Now;
            var validToDateTime = Clock.Now.AddHours(5);

            var form = FormGN59Fixture.CreateForInsert(functionalLocations, validFromDateTime, validToDateTime, FormStatus.Draft);
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
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();

            var validFrom = new DateTime(2012, 10, 1, 13, 0, 0);
            var validTo = new DateTime(2012, 10, 2, 16, 0, 0);

            var form = FormGN59Fixture.CreateForInsert(new List<FunctionalLocation> {floc1, floc2}, validFrom, validTo, FormStatus.Draft);
            form = formDao.Insert(form);

            form.FormStatus = FormStatus.Approved;
            form.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_ED1_A001_U007_SCC());
            form.Content = form.Content + "changed";
            form.PlainTextContent = form.PlainTextContent + "chged";
            form.FromDateTime = form.FromDateTime.AddHours(3);
            form.ToDateTime = form.ToDateTime.AddHours(3);
            form.ApprovedDateTime = new DateTime(2016, 1, 2);
            form.ClosedDateTime = new DateTime(2015, 1, 1);

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
        }

        protected override void TestInitialize()
        {
            formDao = DaoRegistry.GetDao<IFormGN59Dao>();
            dtoDao = DaoRegistry.GetDao<IFormEdmontonDTODao>();
        }

        protected override void Cleanup()
        {
        }

        private void RequeryAndAssertFieldsAreEqual(FormGN59 form)
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

            Assert.AreEqual(form.CreatedBy.IdValue, requeried.CreatedBy.IdValue);
            Assert.That(form.CreatedDateTime, Is.EqualTo(requeried.CreatedDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(form.LastModifiedBy.IdValue, requeried.LastModifiedBy.IdValue);
            Assert.That(form.LastModifiedDateTime, Is.EqualTo(requeried.LastModifiedDateTime).Within(TimeSpan.FromSeconds(1)));

            Assert.AreEqual(form.FunctionalLocations.Count, requeried.FunctionalLocations.Count);
            foreach (var floc in form.FunctionalLocations)
            {
                Assert.IsTrue(requeried.FunctionalLocations.Contains(floc));
            }

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