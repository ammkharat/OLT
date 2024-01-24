using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Restriction
{
    [TestFixture]
    public class RestrictionDefinitionTest
    {
        [Test]
        public void ShouldStoreLastInvokedDateTimeUpToHourLevel()
        {
            RestrictionDefinition definition = RestrictionDefinitionFixture.CreateDefinition();
            definition.LastInvokedDateTime = new DateTime(2010, 11, 22, 3, 4, 55);
            Assert.AreEqual(new DateTime(2010, 11, 22, 3, 0, 0), definition.LastInvokedDateTime);
        }

        [Test]
        public void ShouldGetAlertRangesWhenLastInvokedDateTimeIsNull()
        {
            RestrictionDefinition definition = RestrictionDefinitionFixture.CreateDefinition();
            definition.LastInvokedDateTime = null;

            {
                definition.CreatedDate = new DateTime(2010, 1, 2, 12, 4, 5);
                List<Range<DateTime>> alertHours = definition.GetAlertHours(new DateTime(2010, 1, 2, 13, 4, 5));
                Assert.AreEqual(1, alertHours.Count);
                Assert.AreEqual(new DateTime(2010, 1, 2, 12, 0, 0), alertHours[0].LowerBound);
                Assert.AreEqual(new DateTime(2010, 1, 2, 13, 0, 0), alertHours[0].UpperBound);
            }
            {
                definition.CreatedDate = new DateTime(2010, 1, 2, 0, 4, 5);
                List<Range<DateTime>> alertHours = definition.GetAlertHours(new DateTime(2010, 1, 2, 1, 4, 5));
                Assert.AreEqual(1, alertHours.Count);
                Assert.AreEqual(new DateTime(2010, 1, 2, 0, 0, 0), alertHours[0].LowerBound);
                Assert.AreEqual(new DateTime(2010, 1, 2, 1, 0, 0), alertHours[0].UpperBound);
            }
            {
                definition.CreatedDate = new DateTime(2010, 1, 1, 23, 4, 5);
                List<Range<DateTime>> alertHours = definition.GetAlertHours(new DateTime(2010, 1, 2, 0, 4, 5));
                Assert.AreEqual(1, alertHours.Count);
                Assert.AreEqual(new DateTime(2010, 1, 1, 23, 0, 0), alertHours[0].LowerBound);
                Assert.AreEqual(new DateTime(2010, 1, 2, 0, 0, 0), alertHours[0].UpperBound);
            }
        }

        [Test]
        public void ShouldNotGetAlertRangesWhenLastInvokedDateTimeIsThePreviousInvocation()
        {
            RestrictionDefinition definition = RestrictionDefinitionFixture.CreateDefinition();

            DateTime dateTime = new DateTime(2010, 1, 2, 14, 4, 5);
            definition.LastInvokedDateTime = dateTime;

            List<Range<DateTime>> alertHours = definition.GetAlertHours(dateTime);
            Assert.AreEqual(0, alertHours.Count);
        }

        [Test]
        public void ShouldNotGetAlertRangesWhenInvocationDateTimeIsBeforeLastInvocationDateTime()
        {
            RestrictionDefinition definition = RestrictionDefinitionFixture.CreateDefinition();

            DateTime dateTime = new DateTime(2010, 1, 2, 14, 4, 5);
            definition.LastInvokedDateTime = dateTime;

            List<Range<DateTime>> alertHours = definition.GetAlertHours(dateTime.AddHours(-1));
            Assert.AreEqual(0, alertHours.Count);
        }

        [Test]
        public void ShouldGetMissedAlertRangesWhenLastInvokedDateTimeIsNotNull()
        {
            RestrictionDefinition definition = RestrictionDefinitionFixture.CreateDefinition();

            definition.LastInvokedDateTime = new DateTime(2010, 1, 2, 12, 4, 5);

            List<Range<DateTime>> alertHours = definition.GetAlertHours(new DateTime(2010, 1, 2, 15, 4, 5));
            Assert.AreEqual(3, alertHours.Count);
            Assert.AreEqual(new DateTime(2010, 1, 2, 12, 0, 0), alertHours[0].LowerBound);
            Assert.AreEqual(new DateTime(2010, 1, 2, 13, 0, 0), alertHours[0].UpperBound);
            Assert.AreEqual(new DateTime(2010, 1, 2, 13, 0, 0), alertHours[1].LowerBound);
            Assert.AreEqual(new DateTime(2010, 1, 2, 14, 0, 0), alertHours[1].UpperBound);
            Assert.AreEqual(new DateTime(2010, 1, 2, 14, 0, 0), alertHours[2].LowerBound);
            Assert.AreEqual(new DateTime(2010, 1, 2, 15, 0, 0), alertHours[2].UpperBound);
        }

        [Test]
        public void ShouldGetMissedAlertRangesWhenLastInvokedDateTimeIsNull()
        {
            RestrictionDefinition definition = RestrictionDefinitionFixture.CreateDefinition();

            definition.LastInvokedDateTime = null;

            DateTime createdDate = new DateTime(2010, 1, 2, 12, 4, 5);
            definition.CreatedDate = createdDate;

            {
                List<Range<DateTime>> alertHours = definition.GetAlertHours(createdDate.TruncateToHour().AddSeconds(-1));
                Assert.AreEqual(0, alertHours.Count);
            }
            {
                List<Range<DateTime>> alertHours = definition.GetAlertHours(createdDate.TruncateToHour());
                Assert.AreEqual(0, alertHours.Count);
            }
            {
                List<Range<DateTime>> alertHours = definition.GetAlertHours(createdDate.TruncateToHour().AddSeconds(1));
                Assert.AreEqual(0, alertHours.Count);
            }
            {
                List<Range<DateTime>> alertHours = definition.GetAlertHours(createdDate.AddSeconds(-1));
                Assert.AreEqual(0, alertHours.Count);
            }
            {
                List<Range<DateTime>> alertHours = definition.GetAlertHours(createdDate);
                Assert.AreEqual(0, alertHours.Count);
            }
            {
                List<Range<DateTime>> alertHours = definition.GetAlertHours(createdDate.AddSeconds(1));
                Assert.AreEqual(0, alertHours.Count);
            }
            {
                List<Range<DateTime>> alertHours = definition.GetAlertHours(createdDate.TruncateToHour().AddHours(1).AddSeconds(-1));
                Assert.AreEqual(0, alertHours.Count);
            }
            {
                List<Range<DateTime>> alertHours = definition.GetAlertHours(createdDate.TruncateToHour().AddHours(1));
                Assert.AreEqual(1, alertHours.Count);
                Assert.AreEqual(new DateTime(2010, 1, 2, 12, 0, 0), alertHours[0].LowerBound);
                Assert.AreEqual(new DateTime(2010, 1, 2, 13, 0, 0), alertHours[0].UpperBound);
            }
            {
                List<Range<DateTime>> alertHours = definition.GetAlertHours(createdDate.TruncateToHour().AddHours(1).AddSeconds(1));
                Assert.AreEqual(1, alertHours.Count);
                Assert.AreEqual(new DateTime(2010, 1, 2, 12, 0, 0), alertHours[0].LowerBound);
                Assert.AreEqual(new DateTime(2010, 1, 2, 13, 0, 0), alertHours[0].UpperBound);
            }
            {
                List<Range<DateTime>> alertHours = definition.GetAlertHours(createdDate.AddHours(3));
                Assert.AreEqual(3, alertHours.Count);
                Assert.AreEqual(new DateTime(2010, 1, 2, 12, 0, 0), alertHours[0].LowerBound);
                Assert.AreEqual(new DateTime(2010, 1, 2, 13, 0, 0), alertHours[0].UpperBound);
                Assert.AreEqual(new DateTime(2010, 1, 2, 13, 0, 0), alertHours[1].LowerBound);
                Assert.AreEqual(new DateTime(2010, 1, 2, 14, 0, 0), alertHours[1].UpperBound);
                Assert.AreEqual(new DateTime(2010, 1, 2, 14, 0, 0), alertHours[2].LowerBound);
                Assert.AreEqual(new DateTime(2010, 1, 2, 15, 0, 0), alertHours[2].UpperBound);
            }
        }
    }
}
