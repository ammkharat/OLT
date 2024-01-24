using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class EventSinkDaoTest : AbstractDaoTest
    {
        private IEventSinkDao eventSinkDao;

        protected override void TestInitialize()
        {
            eventSinkDao = DaoRegistry.GetDao<IEventSinkDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void InsertEventSinkShouldReturnId()
        {
            EventSink newEventSink = EventSinkFixture.CreateNewEventSinkWithoutId();
            eventSinkDao.Insert(newEventSink);
            Assert.IsNotNull(newEventSink.Id);

            EventSink requeried = eventSinkDao.QueryAll().FindById(newEventSink);
            Assert.AreEqual(newEventSink.ClientUri, requeried.ClientUri);
            Assert.AreEqual(newEventSink.FullHierarchyList, requeried.FullHierarchyList);
            Assert.AreEqual(newEventSink.WorkPermitEdmontonFullHierarchyList, requeried.WorkPermitEdmontonFullHierarchyList);
            Assert.AreEqual(newEventSink.RestrictionFullHierarchyList, requeried.RestrictionFullHierarchyList);
            Assert.AreEqual(newEventSink.ClientReadableVisibilityGroupIdList, requeried.ClientReadableVisibilityGroupIdList);
            Assert.AreEqual(newEventSink.SiteId, requeried.SiteId);
        }

        [Ignore] [Test]
        public void ShouldBeAbleToInsertNullSiteId()
        {
            EventSink newEventSink = EventSinkFixture.CreateNewEventSinkWithSiteIdNullAndWithoutId();
            eventSinkDao.Insert(newEventSink);
            Assert.IsNotNull(newEventSink.Id);

            EventSink requeried = eventSinkDao.QueryAll().FindById(newEventSink);
            Assert.AreEqual(newEventSink.ClientUri, requeried.ClientUri);
            Assert.AreEqual(newEventSink.FullHierarchyList, requeried.FullHierarchyList);
            Assert.AreEqual(newEventSink.WorkPermitEdmontonFullHierarchyList, requeried.WorkPermitEdmontonFullHierarchyList);
            Assert.AreEqual(newEventSink.SiteId, requeried.SiteId);
        }

        [Ignore] [Test]
        public void InsertThenRemoveShouldReturnNothingForASpecificClientUri()
        {
            const string clientUri = "/test/test/test";
            EventSink sink1 = EventSinkFixture.CreateNewEventSink(clientUri);
            eventSinkDao.Insert(sink1);
            Assert.IsNotNull(sink1.Id);

            EventSink sink2 = EventSinkFixture.CreateNewEventSink(clientUri);
            eventSinkDao.Insert(sink2);
            Assert.IsNotNull(sink2.Id);

            EventSink sink3 = EventSinkFixture.CreateNewEventSink("something different");
            eventSinkDao.Insert(sink3);
            Assert.IsNotNull(sink3.Id);

            eventSinkDao.DeleteByClientUri(clientUri);
            List<EventSink> all = eventSinkDao.QueryAll();

            Assert.IsFalse(all.ExistsById(sink1));
            Assert.IsFalse(all.ExistsById(sink2));
            Assert.IsTrue(all.ExistsById(sink3));
        }
    }
}