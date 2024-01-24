using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    [TestFixture]
    public class CycleStepEntryIteratorTest
    {

        private static List<CokerCardCycleStepEntry> CreateEntries(int numItems)
        {
            List<CokerCardCycleStepEntry> entries = new List<CokerCardCycleStepEntry>();
            for (int i = 0; i < numItems; i++)
            {
                CokerCardCycleStepEntry entry = new CokerCardCycleStepEntry(null, i + 1, i + 1, null, null);
                entries.Add(entry);
            }
            return entries;
        }

        [Test]
        public void ShouldHandleEmptyList()
        {
            List<CokerCardCycleStepEntry> entries = CreateEntries(0);
            CycleStepEntryIterator iterator = new CycleStepEntryIterator(entries);

            Assert.IsFalse(iterator.HasEntries);
            Assert.IsNull(iterator.Current);
            Assert.IsNull(iterator.PeekFirst);
            Assert.IsNull(iterator.PeekLast);

            iterator.MoveNext();
            Assert.IsNull(iterator.Current);

            iterator.MoveLast();
            Assert.IsNull(iterator.Current);

            iterator.MoveNext();
            Assert.IsNull(iterator.Current);
        }

        [Test]
        public void ShouldHandleListWithOneItem()
        {
            List<CokerCardCycleStepEntry> entries = CreateEntries(1);
            CycleStepEntryIterator iterator = new CycleStepEntryIterator(entries);

            Assert.IsTrue(iterator.HasEntries);
            Assert.AreEqual(entries[0], iterator.Current);
            Assert.AreEqual(entries[0], iterator.PeekFirst);
            Assert.AreEqual(entries[0], iterator.PeekLast);

            iterator.MoveNext();
            Assert.IsNull(iterator.Current);

            iterator.MoveLast();
            Assert.AreEqual(entries[0], iterator.Current);

            iterator.MoveNext();
            Assert.IsNull(iterator.Current);
        }

        [Test]
        public void ShouldHandleListWithTwoEntries()
        {
            List<CokerCardCycleStepEntry> entries = CreateEntries(2);
            CycleStepEntryIterator iterator = new CycleStepEntryIterator(entries);

            Assert.IsTrue(iterator.HasEntries);
            Assert.AreEqual(entries[0], iterator.Current);
            Assert.AreEqual(entries[0], iterator.PeekFirst);
            Assert.AreEqual(entries[1], iterator.PeekLast);

            iterator.MoveNext();
            Assert.AreEqual(entries[1], iterator.Current);

            iterator.MoveNext();
            Assert.IsNull(iterator.Current);

            iterator.MoveLast();
            Assert.AreEqual(entries[1], iterator.Current);

            iterator.MoveNext();
            Assert.IsNull(iterator.Current);
        }

        [Test]
        public void ShouldHandleListWithThreeEntries()
        {
            List<CokerCardCycleStepEntry> entries = CreateEntries(3);
            CycleStepEntryIterator iterator = new CycleStepEntryIterator(entries);

            Assert.IsTrue(iterator.HasEntries);
            Assert.AreEqual(entries[0], iterator.Current);
            Assert.AreEqual(entries[0], iterator.PeekFirst);
            Assert.AreEqual(entries[2], iterator.PeekLast);

            iterator.MoveNext();
            Assert.AreEqual(entries[1], iterator.Current);

            iterator.MoveNext();
            Assert.AreEqual(entries[2], iterator.Current);

            iterator.MoveNext();
            Assert.IsNull(iterator.Current);

            iterator.MoveLast();
            Assert.AreEqual(entries[2], iterator.Current);

            iterator.MoveNext();
            Assert.IsNull(iterator.Current);
        }

        [Test]
        public void ShouldMoveLastWithOneEntry()
        {
            List<CokerCardCycleStepEntry> entries = CreateEntries(1);
            CycleStepEntryIterator iterator = new CycleStepEntryIterator(entries);

            iterator.MoveLast();
            Assert.AreEqual(entries[0], iterator.Current);

            iterator.MoveNext();
            Assert.IsNull(iterator.Current);
        }

        [Test]
        public void ShouldMoveLastWithTwoEntries()
        {
            List<CokerCardCycleStepEntry> entries = CreateEntries(2);
            CycleStepEntryIterator iterator = new CycleStepEntryIterator(entries);

            iterator.MoveLast();
            Assert.AreEqual(entries[1], iterator.Current);

            iterator.MoveNext();
            Assert.IsNull(iterator.Current);
        }

        [Test]
        public void ShouldMovelastWithThreeEntries()
        {
            List<CokerCardCycleStepEntry> entries = CreateEntries(3);
            CycleStepEntryIterator iterator = new CycleStepEntryIterator(entries);

            iterator.MoveLast();
            Assert.AreEqual(entries[2], iterator.Current);

            iterator.MoveNext();
            Assert.IsNull(iterator.Current);
        }
    }
}
