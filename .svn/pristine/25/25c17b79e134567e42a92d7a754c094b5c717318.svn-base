using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class FormGN24HistoryDaoTest : AbstractDaoTest
    {
        private IFormGN24HistoryDao dao;
        private IFormGN24Dao formDao;

        [Ignore] [Test]
        public void ShouldInsert()
        {
            var someUser = UserFixture.CreateUser("uname", "firstname", "lastname");

            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            var validFromDateTime = new DateTime(2012, 10, 1, 1, 0, 0);
            var validToDateTime = new DateTime(2012, 10, 3, 8, 0, 0);

            var form = FormGN24Fixture.CreateForInsert(new List<FunctionalLocation> {floc2, floc1},
                validFromDateTime,
                validToDateTime,
                FormStatus.Draft);
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "approver1", someUser, new DateTime(2012, 10, 5), null, 1));
            form.Approvals.Add(new FormApproval(null, null, "approver2", null, null, null, 2));
            form.Approvals.Add(new FormApproval(null, null, "approver3", someUser, new DateTime(2012, 10, 5), null, 3));
            formDao.Insert(form);

            form.DocumentLinks.Clear();
            form.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());

            var history = form.TakeSnapshot();
            dao.Insert(history);

            var histories = dao.GetById(form.IdValue);
            Assert.AreEqual(1, histories.Count);
            var requeried = histories[0];

            {
                Assert.IsNotNull(requeried);

                Assert.AreEqual(form.IdValue, requeried.IdValue);

                Assert.AreEqual(form.PlainTextContent, requeried.PlainTextContent);
                Assert.AreEqual("approver1 (uname), approver3 (uname)", requeried.Approvals);
                Assert.AreEqual(form.FormStatus, requeried.FormStatus);
                Assert.AreEqual("ED1-A001-U007, ED1-A001-U008", requeried.FunctionalLocations);
                Assert.That(requeried.ValidFromDateTime,
                    Is.EqualTo(form.FromDateTime).Within(TimeSpan.FromSeconds(1)));
                Assert.That(requeried.ValidToDateTime, Is.EqualTo(form.ToDateTime).Within(TimeSpan.FromSeconds(1)));

                Assert.That(requeried.ApprovedDateTime, Is.EqualTo(form.ApprovedDateTime).Within(TimeSpan.FromSeconds(1)));
                Assert.That(requeried.ClosedDateTime, Is.EqualTo(form.ClosedDateTime).Within(TimeSpan.FromSeconds(1)));

                Assert.AreEqual(form.IsTheSafeWorkPlanForPSVRemovalOrInstallation, requeried.IsTheSafeWorkPlanForPSVRemovalOrInstallation);
                Assert.AreEqual(form.IsTheSafeWorkPlanForWorkInTheAlkylationUnit, requeried.IsTheSafeWorkPlanForWorkInTheAlkylationUnit);
                Assert.AreEqual(form.AlkylationClass, requeried.AlkylationClass);
                Assert.AreEqual(form.PlainTextPreJobMeetingSignatures, requeried.PlainTextPreJobMeetingSignatures);
                Assert.AreEqual(history.DocumentLinks, requeried.DocumentLinks);
            }
        }

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IFormGN24HistoryDao>();
            formDao = DaoRegistry.GetDao<IFormGN24Dao>();
        }

        protected override void Cleanup()
        {
            DaoRegistry.Clear();
        }
    }
}