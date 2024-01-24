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
    public class FormGN75AHistoryDaoTest : AbstractDaoTest
    {
        private IFormGN75AHistoryDao historyDao;
        private IFormGN75ADao formDao;

        protected override void TestInitialize()
        {
            historyDao = DaoRegistry.GetDao<IFormGN75AHistoryDao>();
            formDao = DaoRegistry.GetDao<IFormGN75ADao>();
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
            
            DateTime validFromDateTime = new DateTime(2012, 10, 1, 1, 0, 0);
            DateTime validToDateTime = new DateTime(2012, 10, 3, 8, 0, 0);

            FormGN75A form = FormGN75AFixture.CreateForInsert(floc1, validFromDateTime, validToDateTime, FormStatus.Draft);

            form.Approvals.Clear();
            form.Approvals.Add(new FormApproval(null, null, "approver1", someUser, new DateTime(2012, 10, 5), null, 1));
            form.Approvals.Add(new FormApproval(null, null, "approver2", null, null, null, 2));
            form.Approvals.Add(new FormApproval(null, null, "approver3", someUser, new DateTime(2012, 10, 5), null, 3));
            formDao.Insert(form);

            form.DocumentLinks.Clear();
            form.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());

            FormGN75AHistory history = form.TakeSnapshot();
            historyDao.Insert(history);

            List<FormGN75AHistory> histories = historyDao.GetById(form.IdValue);
            Assert.AreEqual(1, histories.Count);
            FormGN75AHistory requeried = histories[0];
            
            Assert.AreEqual(history.FormStatus, requeried.FormStatus);
            Assert.AreEqual(history.FunctionalLocation, requeried.FunctionalLocation);
            Assert.AreEqual(history.Approvals, requeried.Approvals);
            Assert.That(history.ValidFromDateTime, Is.EqualTo(requeried.ValidFromDateTime).Within(TimeSpan.FromSeconds(1)));
            Assert.That(history.ValidToDateTime, Is.EqualTo(requeried.ValidToDateTime).Within(TimeSpan.FromSeconds(1)));
            Assert.AreEqual(history.PlainTextContent, requeried.PlainTextContent);            
            Assert.That(history.ApprovedDateTime, Is.EqualTo(requeried.ApprovedDateTime).Within(TimeSpan.FromSeconds(1)));            
            Assert.That(history.ClosedDateTime, Is.EqualTo(requeried.ClosedDateTime).Within(TimeSpan.FromSeconds(1)));
            Assert.AreEqual(history.AssociatedFormGN75BNumber, requeried.AssociatedFormGN75BNumber);
            Assert.AreEqual(history.DocumentLinks, requeried.DocumentLinks);
            Assert.AreEqual(history.LastModifiedBy.IdValue, requeried.LastModifiedBy.IdValue);            
            Assert.That(history.LastModifiedDate, Is.EqualTo(requeried.LastModifiedDate).Within(TimeSpan.FromSeconds(1)));
        }
    }
}
