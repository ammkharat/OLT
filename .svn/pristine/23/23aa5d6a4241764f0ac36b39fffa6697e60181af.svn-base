using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class FormGN75BHistoryDaoTest : AbstractDaoTest
    {
        private IFormGN75BHistoryDao historyDao;
        private IFormGN75BDao formDao;

        protected override void TestInitialize()
        {
            historyDao = DaoRegistry.GetDao<IFormGN75BHistoryDao>();
            formDao = DaoRegistry.GetDao<IFormGN75BDao>();
        }

        protected override void Cleanup()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            User someUser = UserFixture.CreateRemoteAppUser();

            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            List<IsolationItem> isolationItems = new List<IsolationItem> {new IsolationItem(null, null, 1, "IsolationType", "location of isolation","",0)};   //ayman Sarnia eip DMND0008992

            FormGN75B form = new FormGN75B(floc1, floc1.Description, isolationItems, someUser, DateTimeFixture.DateTimeNow, someUser, DateTimeFixture.DateTimeNow, false,false,false, "Compressor", "123", "lock box location",8,null,0,null,null);  //ayman Sarnia eip DMND0008992
            form.AddSchematic(@"\\someuncpath\file.jpg", new byte[] {1, 2, 3});
            formDao.Insert(form);

            historyDao.Insert(form.TakeSnapshot(),form.SiteID);

            List<FormGN75BHistory> histories = historyDao.GetById(form.IdValue,form.SiteID);
            Assert.AreEqual(1, histories.Count);
            FormGN75BHistory requeried = histories[0];

            Assert.That(requeried.BlindsRequired, Is.EqualTo(form.BlindsRequired));
            Assert.That(requeried.ClosedDateTime, Is.EqualTo(form.ClosedDateTime));
            Assert.That(requeried.DocumentLinks, Is.Null.Or.Empty.Or.Length.EqualTo(0));
            Assert.That(requeried.FormStatus, Is.EqualTo(form.FormStatus));
            Assert.That(requeried.FunctionalLocation, Is.EqualTo(form.FunctionalLocation.FullHierarchy));
            Assert.That(requeried.Isolations, Has.Length.GreaterThan(0));
            Assert.That(requeried.LockBoxLocation, Is.EqualTo(form.LockBoxLocation));
            Assert.That(requeried.LockBoxNumber, Is.EqualTo(form.LockBoxNumber));
            Assert.That(requeried.SchematicImage, Is.EqualTo(form.SchematicImage));
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            
        }
    }
}
