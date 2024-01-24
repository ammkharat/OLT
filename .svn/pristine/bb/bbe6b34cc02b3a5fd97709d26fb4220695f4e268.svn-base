using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Analytics;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class EventDaoTest : AbstractDaoTest
    {
        private IEventDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IEventDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            const long userId = 1;
            const long siteId = Site.SARNIA_ID;

            Property property = new Property("property key", 5);
            Event @event = new Event(null, userId, siteId, "event name", new DateTime(2013, 11, 20, 8, 0, 0), new List<Property> { property });

            dao.Insert(@event);

            List<Event> results = dao.QueryByDateRangeAndEventNames(new DateTime(2013, 11, 19), new DateTime(2013, 11, 21), new List<string> { "event name" });
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(@event.Id, results[0].IdValue);
        }

        [Ignore] [Test]
        public void ShouldDelete()
        {
            const long userId = 1;
            const long siteId = Site.SARNIA_ID;

            Property property = new Property("property key", 5);
            Event event1 = new Event(null, userId, siteId, "event1", new DateTime(2013, 11, 20, 8, 0, 0), new List<Property> { property });
            Event event2 = new Event(null, userId, siteId, "event2", new DateTime(2013, 11, 21, 8, 0, 0), new List<Property> { property });

            dao.Insert(event1);
            dao.Insert(event2);

            {
                List<Event> results = dao.QueryByDateRangeAndEventNames(new DateTime(2013, 11, 19), new DateTime(2013, 11, 22), new List<string> { "event1", "event2" });
                Assert.AreEqual(2, results.Count);
            }

            dao.DeleteAnalyticsCreatedBeforeGivenDateTime(new DateTime(2013, 11, 20, 13, 0, 0));

            {
                List<Event> results = dao.QueryByDateRangeAndEventNames(new DateTime(2013, 11, 19), new DateTime(2013, 11, 22), new List<string> { "event1", "event2" });
                Assert.AreEqual(1, results.Count);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryUniqueEventNames()
        {
            const long userId = 1;
            const long siteId = Site.SARNIA_ID;

            dao.Insert(new Event(null, userId, siteId, "a", new DateTime(2013, 11, 20, 8, 0, 0), new List<Property>()));
            dao.Insert(new Event(null, userId, siteId, "b", new DateTime(2013, 11, 21, 8, 0, 0), new List<Property>()));
            dao.Insert(new Event(null, userId, siteId, "a", new DateTime(2013, 11, 21, 8, 0, 1), new List<Property>()));

            List<string> uniqueEventNames = dao.QueryUniqueEventNames();
            uniqueEventNames.Sort();

            Assert.AreEqual(2, uniqueEventNames.Count);
            Assert.AreEqual("a", uniqueEventNames[0]);
            Assert.AreEqual("b", uniqueEventNames[1]);
        }

    }
}

