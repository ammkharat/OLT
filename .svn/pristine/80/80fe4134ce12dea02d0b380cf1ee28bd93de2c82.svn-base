using Com.Suncor.Olt.Common.Domain.CokerCard;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    [TestFixture]
    public class CycleStepEntryColumnKeyCollectionTest
    {
        [Test]
        public void ShouldNotFindIndexInEmptyList()
        {
            CokerCardCycleStepEntry entry = new CokerCardCycleStepEntry(null, 1, 1, null, null);
            CycleStepEntryColumnKeyCollection keys = new CycleStepEntryColumnKeyCollection();

            Assert.AreEqual(-1, keys.FindIndex(true, entry));
            Assert.AreEqual(-1, keys.FindIndex(false, entry));
        }

        [Test]
        public void ShouldNotFindIndexForNullEntryInEmptyList()
        {
            CycleStepEntryColumnKeyCollection keys = new CycleStepEntryColumnKeyCollection();

            Assert.AreEqual(-1, keys.FindIndex(true, null));
            Assert.AreEqual(-1, keys.FindIndex(false, null));
        }

        [Test]
        public void ShouldNotFindIndexForNullEntryInPopulatedList()
        {
            CokerCardCycleStepEntry entry = new CokerCardCycleStepEntry(null, 1, 1, null, null);
            CycleStepEntryColumnKeyCollection keys = new CycleStepEntryColumnKeyCollection();
            keys.Add(new CycleStepEntryColumnKey(entry.CycleStepId, false, null, 0));

            Assert.AreEqual(-1, keys.FindIndex(true, null));
            Assert.AreEqual(-1, keys.FindIndex(false, null));
        }

        [Test]
        public void ShouldFindEntry()
        {
            CokerCardCycleStepEntry entry1 = new CokerCardCycleStepEntry(null, 99, 100, null, null);
            CokerCardCycleStepEntry entry2 = new CokerCardCycleStepEntry(null, 99, 200, null, null);
            CycleStepEntryColumnKeyCollection keys = new CycleStepEntryColumnKeyCollection();
            keys.Add(new CycleStepEntryColumnKey(entry1.CycleStepId, false, null, 0));
            keys.Add(new CycleStepEntryColumnKey(entry2.CycleStepId, false, null, 0));
            
            Assert.AreEqual(0, keys.FindIndex(false, entry1));
            Assert.AreEqual(0, keys.FindIndex(true, entry1));
            Assert.AreEqual(1, keys.FindIndex(false, entry2));
            Assert.AreEqual(1, keys.FindIndex(true, entry2));
        }

        [Test]
        public void ShouldFindEntryInKeyForPreviousCardEntry()
        {
            CokerCardCycleStepEntry entry1 = new CokerCardCycleStepEntry(null, 99, 100, null, null);
            CokerCardCycleStepEntry entry2 = new CokerCardCycleStepEntry(null, 99, 200, null, null);
            CycleStepEntryColumnKeyCollection keys = new CycleStepEntryColumnKeyCollection();
            keys.Add(new CycleStepEntryColumnKey(entry1.CycleStepId, true, null, 0));
            keys.Add(new CycleStepEntryColumnKey(entry2.CycleStepId, true, null, 0));

            Assert.AreEqual(-1, keys.FindIndex(false, entry1));
            Assert.AreEqual(0, keys.FindIndex(true, entry1));
            Assert.AreEqual(-1, keys.FindIndex(false, entry2));
            Assert.AreEqual(1, keys.FindIndex(true, entry2));
        }

        [Test]
        public void ShouldNotGetNextInEmptyList()
        {
            CycleStepEntryColumnKeyCollection keys = new CycleStepEntryColumnKeyCollection();
            CycleStepEntryColumnKey next = keys.GetNext(new CycleStepEntryColumnKey(1, false, null, 0));
            Assert.IsNull(next);
        }

        [Test]
        public void ShouldGetNext()
        {
            CycleStepEntryColumnKeyCollection keys = new CycleStepEntryColumnKeyCollection();
            keys.Add(new CycleStepEntryColumnKey(1, true, null, 0));
            keys.Add(new CycleStepEntryColumnKey(2, true, null, 0));
            keys.Add(new CycleStepEntryColumnKey(3, false, null, 0));
            keys.Add(new CycleStepEntryColumnKey(4, true, null, 0));
            keys.Add(new CycleStepEntryColumnKey(1, false, null, 0));
            keys.Add(new CycleStepEntryColumnKey(2, false, null, 0));

            Assert.AreEqual(keys[1], keys.GetNext(keys[0]));
            Assert.AreEqual(keys[2], keys.GetNext(keys[1]));
            Assert.AreEqual(keys[3], keys.GetNext(keys[2]));
            Assert.AreEqual(keys[4], keys.GetNext(keys[3]));
            Assert.AreEqual(keys[5], keys.GetNext(keys[4]));
            Assert.AreEqual(null, keys.GetNext(keys[5]));

            Assert.IsNull(keys.GetNext(null));
            Assert.IsNull(keys.GetNext(new CycleStepEntryColumnKey(3, true, null, 0)));
            Assert.IsNull(keys.GetNext(new CycleStepEntryColumnKey(4, false, null, 0)));
            Assert.IsNull(keys.GetNext(new CycleStepEntryColumnKey(99, true, null, 0)));
            Assert.IsNull(keys.GetNext(new CycleStepEntryColumnKey(99, false, null, 0)));
        }
    }
}
