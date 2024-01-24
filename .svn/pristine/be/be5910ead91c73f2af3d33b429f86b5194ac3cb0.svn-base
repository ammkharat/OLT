using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    [TestFixture]
    public class CycleStepEntryDisplayAdapterForReadOnlyTest
    {
        [Test]
        public void ShouldCreateWithNullEntry()
        {
            CycleStepEntryDisplayAdapterForReadOnly adapter = new CycleStepEntryDisplayAdapterForReadOnly(1, 2);
            
            Assert.IsTrue(adapter.IsStartDateTimeReadOnly);
            Assert.IsTrue(adapter.IsEndDateTimeReadOnly);
            Assert.IsNull(adapter.GetCycleStepEntry());

            Assert.IsNull(adapter.StartDateTime);
            Assert.IsNull(adapter.EndDateTime);

            adapter.StartDateTime = new DateTime(2001, 1, 1, 2, 0, 0);
            adapter.EndDateTime = new DateTime(2001, 1, 1, 3, 0, 0);
            Assert.IsNull(adapter.StartDateTime);
            Assert.IsNull(adapter.EndDateTime);

            adapter.StartDateTime = null;
            adapter.EndDateTime = null;
            Assert.IsNull(adapter.StartDateTime);
            Assert.IsNull(adapter.EndDateTime);
        }

        [Test]
        public void ShouldCreateWithEntry()
        {
            CokerCardCycleStepEntry entry = new CokerCardCycleStepEntry(
                1001, 1, 2, 
                new TimeEntry(new Time(10), 1, null), 
                new TimeEntry(new Time(11), 2, null));
            CycleStepEntryDisplayAdapterForReadOnly adapter = new CycleStepEntryDisplayAdapterForReadOnly(entry);

            Assert.IsTrue(adapter.IsStartDateTimeReadOnly);
            Assert.IsTrue(adapter.IsEndDateTimeReadOnly);
            Assert.IsNull(adapter.GetCycleStepEntry());

            Assert.AreEqual(new Time(10).ToDateTime(), adapter.StartDateTime);
            Assert.AreEqual(new Time(11).ToDateTime(), adapter.EndDateTime);

            adapter.StartDateTime = new DateTime(2001, 1, 1, 2, 0, 0);
            adapter.EndDateTime = new DateTime(2001, 1, 1, 3, 0, 0);
            Assert.AreEqual(new Time(10).ToDateTime(), adapter.StartDateTime);
            Assert.AreEqual(new Time(11).ToDateTime(), adapter.EndDateTime);

            adapter.StartDateTime = null;
            adapter.EndDateTime = null;
            Assert.AreEqual(new Time(10).ToDateTime(), adapter.StartDateTime);
            Assert.AreEqual(new Time(11).ToDateTime(), adapter.EndDateTime);
        }

        [Test]
        public void ShouldCreateWithEntryWithNullEndTime()
        {
            CokerCardCycleStepEntry entry = new CokerCardCycleStepEntry(
                1001, 1, 2,
                new TimeEntry(new Time(10), 1, null),
                null);
            CycleStepEntryDisplayAdapterForReadOnly adapter = new CycleStepEntryDisplayAdapterForReadOnly(entry);

            Assert.IsTrue(adapter.IsStartDateTimeReadOnly);
            Assert.IsTrue(adapter.IsEndDateTimeReadOnly);
            Assert.IsNull(adapter.GetCycleStepEntry());

            Assert.AreEqual(new Time(10).ToDateTime(), adapter.StartDateTime);
            Assert.AreEqual(null, adapter.EndDateTime);

            adapter.StartDateTime = new DateTime(2001, 1, 1, 2, 0, 0);
            adapter.EndDateTime = new DateTime(2001, 1, 1, 3, 0, 0);
            Assert.AreEqual(new Time(10).ToDateTime(), adapter.StartDateTime);
            Assert.AreEqual(null, adapter.EndDateTime);

            adapter.StartDateTime = null;
            adapter.EndDateTime = null;
            Assert.AreEqual(new Time(10).ToDateTime(), adapter.StartDateTime);
            Assert.AreEqual(null, adapter.EndDateTime);
        }

    }
}
