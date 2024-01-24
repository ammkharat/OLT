using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class EdmontonPersonDaoTest : AbstractDaoTest
    {
        private IEdmontonPersonDao dao;


        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IEdmontonPersonDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsertEdmontonPerson()
        {
            DateTime lastScan = Clock.Now;
            EdmontonPerson edmontonPerson = new EdmontonPerson(null, "John", "Doe", "1234321", lastScan, BadgeScanStatus.In);

            List<EdmontonPerson> beforeInsert = dao.QueryAll();

            EdmontonPerson exists = Find(beforeInsert, edmontonPerson);
            Assert.That(exists, Is.Null);

            dao.Insert(edmontonPerson);
            long? id = edmontonPerson.Id;
            Assert.That(id, Is.Not.Null);

            List<EdmontonPerson> afterInsert = dao.QueryAll();

            Assert.That(afterInsert.Count - beforeInsert.Count, Is.EqualTo(1));
            EdmontonPerson person = Find(afterInsert, edmontonPerson);
            Assert.That(person, Is.Not.Null);

            // update
            DateTime newScanTime = person.LastScan.AddHours(-50);
            person.UpdateScanData(newScanTime, BadgeScanStatus.Out);
            dao.Update(person);

            List<EdmontonPerson> afterUpdate = dao.QueryAll();
            EdmontonPerson personAfterUpdate = Find(afterUpdate, person);
            Assert.That(personAfterUpdate, Is.Not.Null);
            Assert.That(personAfterUpdate.IdValue, Is.EqualTo(id.Value));

            // remove
            dao.Remove(personAfterUpdate);

            List<EdmontonPerson> afterRemove = dao.QueryAll();
            EdmontonPerson find = Find(afterRemove, personAfterUpdate);
            Assert.That(find, Is.Null);

            List<EdmontonPerson> deletedPersons = dao.QueryAllDeleted();
            EdmontonPerson found = Find(deletedPersons, personAfterUpdate);
            Assert.That(found, Is.Not.Null);
            Assert.That(found.IdValue, Is.EqualTo(id.Value));
            
            // unremove
            dao.UndoRemove(personAfterUpdate);

            List<EdmontonPerson> afterUnRemove = dao.QueryAll();
            find = Find(afterUnRemove, personAfterUpdate);
            Assert.That(find, Is.Not.Null);
            Assert.That(find.IdValue, Is.EqualTo(id.Value));
            
            deletedPersons = dao.QueryAllDeleted();
            found = Find(deletedPersons, personAfterUpdate);
            Assert.That(found, Is.Null);
        }

        private static EdmontonPerson Find(List<EdmontonPerson> list, EdmontonPerson edmontonPerson)
        {
            return list.Find(p => p.FirstName.Equals(edmontonPerson.FirstName) && p.LastName.Equals(edmontonPerson.LastName) && p.BadgeId.Equals(edmontonPerson.BadgeId) &&
                                         DateTimeEquals(p.LastScan, edmontonPerson.LastScan) && p.ScanStatus == edmontonPerson.ScanStatus);
        }

        private static bool DateTimeEquals(DateTime dateTime1, DateTime dateTime2)
        {
            return dateTime1.Year == dateTime2.Year && dateTime1.Month == dateTime2.Month && dateTime1.Day == dateTime2.Day &&
                   dateTime1.Hour == dateTime2.Hour && dateTime1.Minute == dateTime2.Minute && dateTime1.Second == dateTime2.Second;
        }
    }
}