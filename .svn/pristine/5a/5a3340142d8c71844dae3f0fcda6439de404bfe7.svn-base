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
    public class FormOP14HistoryDaoTest : AbstractDaoTest
    {
        private IFormOP14HistoryDao dao;
        private IFormOP14Dao formDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IFormOP14HistoryDao>();
            formDao = DaoRegistry.GetDao<IFormOP14Dao>();
        }

        protected override void Cleanup()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            User someUser = UserFixture.CreateUser("uname", "firstname", "lastname");

            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            DateTime validFromDateTime = new DateTime(2012, 10, 1, 1, 0, 0);
            DateTime validToDateTime = new DateTime(2012, 10, 3, 8, 0, 0);

            FormOP14 form = FormOP14Fixture.CreateForInsert(new List<FunctionalLocation> {floc2, floc1},
                validFromDateTime, validToDateTime, FormStatus.Draft);
            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "approver1", someUser, new DateTime(2012, 10, 5), null, 1));
            form.Approvals.Add(new FormApproval(null, null, "approver2", null, null, null, 2));
            form.Approvals.Add(new FormApproval(null, null, "approver3", someUser, new DateTime(2012, 10, 5), null, 3));
            form.CriticalSystemDefeated = "The defeated system";
            form.DocumentLinks.Clear();
            form.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());

            form = formDao.Insert(form);

            FormOP14History history = form.TakeSnapshot();

            dao.Insert(history);

            List<FormOP14History> histories = dao.GetById(form.IdValue);
            Assert.AreEqual(1, histories.Count);
            FormOP14History requeried = histories[0];

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
                Assert.That(requeried.ApprovedDateTime,
                    Is.EqualTo(form.ApprovedDateTime).Within(TimeSpan.FromSeconds(1)));
                Assert.That(requeried.ClosedDateTime, Is.EqualTo(form.ClosedDateTime).Within(TimeSpan.FromSeconds(1)));
                Assert.AreEqual(form.Department, requeried.Department);
                Assert.AreEqual(form.IsTheCSDForAPressureSafetyValve, requeried.IsTheCSDForAPressureSafetyValve);
                Assert.AreEqual(form.CriticalSystemDefeated, requeried.CriticalSystemDefeated);
                Assert.AreEqual(history.DocumentLinks, requeried.DocumentLinks);
            }
        }
    }
}