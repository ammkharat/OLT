using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    [TestFixture]
    public class CycleStepEntryIteratorsByDrumTest
    {
        private CokerCardConfiguration configuration;

        [SetUp]
        public void SetUp()
        {
            configuration = new CokerCardConfiguration(1, "config", FunctionalLocationFixture.GetReal_UP1());
            configuration.Drums.Add(new CokerCardConfigurationDrum(1, "drum1", 1));
            configuration.Drums.Add(new CokerCardConfigurationDrum(2, "drum2", 2));
            configuration.Steps.Add(new CokerCardConfigurationCycleStep(1, "step1", 1));
            configuration.Steps.Add(new CokerCardConfigurationCycleStep(2, "step2", 2));
            configuration.Steps.Add(new CokerCardConfigurationCycleStep(3, "step3", 3));
        }

        private CycleStepEntryIteratorsByDrum GetIteratorsByDrum(Common.Domain.CokerCard.CokerCard card)
        {
            List<CycleStepEntryColumnKey> keys = new List<CycleStepEntryColumnKey>();
            keys.Add(new CycleStepEntryColumnKey(configuration.Steps[0].IdValue, false, "a", 0));
            keys.Add(new CycleStepEntryColumnKey(configuration.Steps[1].IdValue, false, "b", 1));
            keys.Add(new CycleStepEntryColumnKey(configuration.Steps[2].IdValue, false, "c", 2));

            return new CycleStepEntryIteratorsByDrum(keys, card);
        }

        [Test]
        public void ShouldCreateWithNullCard()
        {
            CycleStepEntryIteratorsByDrum iteratorsByDrum = new CycleStepEntryIteratorsByDrum(new List<CycleStepEntryColumnKey>(), null);
            CycleStepEntryIterator iterator = iteratorsByDrum.GetIteratorForDrum(1234);
            Assert.IsFalse(iterator.HasEntries);
        }

        [Test]
        public void ShouldGetEmptyIteratorIfDrumDoesNotExist()
        {
            Common.Domain.CokerCard.CokerCard card = CokerCardFixture.Create(configuration);
            CycleStepEntryIteratorsByDrum iteratorsByDrum = GetIteratorsByDrum(card);

            CycleStepEntryIterator iterator = iteratorsByDrum.GetIteratorForDrum(1234);
            Assert.IsFalse(iterator.HasEntries);
        }

        [Test]
        public void ShouldGetEmptyIteratorsForEmptyCokerCard()
        {
            Common.Domain.CokerCard.CokerCard card = CokerCardFixture.Create(configuration);
            CycleStepEntryIteratorsByDrum iteratorsByDrum = GetIteratorsByDrum(card);

            foreach (CokerCardConfigurationDrum drum in configuration.Drums)
            {
                CycleStepEntryIterator iterator = iteratorsByDrum.GetIteratorForDrum(drum.IdValue);
                Assert.IsFalse(iterator.HasEntries);
            }
        }

        [Test]
        public void ShouldGetEntriesSortedByStepDisplayOrder()
        {
            CokerCardConfigurationDrum drum1 = configuration.Drums[0];
            CokerCardConfigurationDrum drum2 = configuration.Drums[1];
            CokerCardConfigurationCycleStep step1 = configuration.Steps[0];
            CokerCardConfigurationCycleStep step2 = configuration.Steps[1];
            CokerCardConfigurationCycleStep step3 = configuration.Steps[2];

            CokerCardCycleStepEntry entry1 = new CokerCardCycleStepEntry(null, drum1.IdValue, step1.IdValue, null, null);
            CokerCardCycleStepEntry entry2 = new CokerCardCycleStepEntry(null, drum1.IdValue, step2.IdValue, null, null);
            CokerCardCycleStepEntry entry3 = new CokerCardCycleStepEntry(null, drum2.IdValue, step1.IdValue, null, null);
            CokerCardCycleStepEntry entry4 = new CokerCardCycleStepEntry(null, drum2.IdValue, step3.IdValue, null, null);

            Common.Domain.CokerCard.CokerCard card = CokerCardFixture.Create(configuration);
            card.CycleStepEntries.Add(entry2);
            card.CycleStepEntries.Add(entry1);
            card.CycleStepEntries.Add(entry4);
            card.CycleStepEntries.Add(entry3);
            CycleStepEntryIteratorsByDrum iteratorsByDrum = GetIteratorsByDrum(card);

            {
                CycleStepEntryIterator iterator = iteratorsByDrum.GetIteratorForDrum(drum1.IdValue);
                Assert.AreEqual(entry1, iterator.Current);
                iterator.MoveNext();
                Assert.AreEqual(entry2, iterator.Current);
                iterator.MoveNext();
                Assert.IsNull(iterator.Current);
            }
            {
                CycleStepEntryIterator iterator = iteratorsByDrum.GetIteratorForDrum(drum2.IdValue);
                Assert.AreEqual(entry3, iterator.Current);
                iterator.MoveNext();
                Assert.AreEqual(entry4, iterator.Current);
                iterator.MoveNext();
                Assert.IsNull(iterator.Current);
            }
        }

        [Test]
        public void ShouldGetNewIteratorEachTime()
        {
            CokerCardConfigurationDrum drum1 = configuration.Drums[0];
            CokerCardConfigurationCycleStep step1 = configuration.Steps[0];

            CokerCardCycleStepEntry entry1 = new CokerCardCycleStepEntry(null, drum1.IdValue, step1.IdValue, null, null);

            Common.Domain.CokerCard.CokerCard card = CokerCardFixture.Create(configuration);
            card.CycleStepEntries.Add(entry1);
            CycleStepEntryIteratorsByDrum iteratorsByDrum = GetIteratorsByDrum(card);

            {
                CycleStepEntryIterator iterator = iteratorsByDrum.GetIteratorForDrum(drum1.IdValue);
                Assert.AreEqual(entry1, iterator.Current);
                iterator.MoveNext();
                Assert.IsNull(iterator.Current);
            }
            {
                CycleStepEntryIterator iterator = iteratorsByDrum.GetIteratorForDrum(drum1.IdValue);
                Assert.AreEqual(entry1, iterator.Current);
                iterator.MoveNext();
                Assert.IsNull(iterator.Current);
            }
        }

        [Test]
        public void ShouldNotSortByColumnKeyForPreviousCokerCard()
        {
            List<CycleStepEntryColumnKey> keys = new List<CycleStepEntryColumnKey>();
            keys.Add(new CycleStepEntryColumnKey(configuration.Steps[2].IdValue, true, "c", 0));
            keys.Add(new CycleStepEntryColumnKey(configuration.Steps[0].IdValue, false, "a", 1));
            keys.Add(new CycleStepEntryColumnKey(configuration.Steps[1].IdValue, false, "b", 2));
            keys.Add(new CycleStepEntryColumnKey(configuration.Steps[2].IdValue, false, "c", 3));

            CokerCardConfigurationDrum drum1 = configuration.Drums[0];
            CokerCardConfigurationCycleStep step1 = configuration.Steps[0];
            CokerCardConfigurationCycleStep step2 = configuration.Steps[2];

            CokerCardCycleStepEntry entry1 = new CokerCardCycleStepEntry(null, drum1.IdValue, step1.IdValue, null, null);
            CokerCardCycleStepEntry entry2 = new CokerCardCycleStepEntry(null, drum1.IdValue, step2.IdValue, null, null);

            Common.Domain.CokerCard.CokerCard card = CokerCardFixture.Create(configuration);
            card.CycleStepEntries.Add(entry2);
            card.CycleStepEntries.Add(entry1);

            CycleStepEntryIteratorsByDrum iteratorsByDrum = new CycleStepEntryIteratorsByDrum(keys, card);

            {
                CycleStepEntryIterator iterator = iteratorsByDrum.GetIteratorForDrum(drum1.IdValue);
                Assert.AreEqual(entry1, iterator.Current);
                iterator.MoveNext();
                Assert.AreEqual(entry2, iterator.Current);
                iterator.MoveNext();
                Assert.IsNull(iterator.Current);
            }
        }

        [Test]
        public void ShouldSortByFirstOccurrenceOfACycleStep()
        {
            List<CycleStepEntryColumnKey> keys = new List<CycleStepEntryColumnKey>();
            keys.Add(new CycleStepEntryColumnKey(configuration.Steps[0].IdValue, false, "a", 1));
            keys.Add(new CycleStepEntryColumnKey(configuration.Steps[1].IdValue, false, "b", 2));
            keys.Add(new CycleStepEntryColumnKey(configuration.Steps[0].IdValue, false, "a", 3));
            keys.Add(new CycleStepEntryColumnKey(configuration.Steps[2].IdValue, false, "c", 4));

            CokerCardConfigurationDrum drum1 = configuration.Drums[0];
            CokerCardConfigurationCycleStep step1 = configuration.Steps[0];
            CokerCardConfigurationCycleStep step2 = configuration.Steps[2];

            CokerCardCycleStepEntry entry1 = new CokerCardCycleStepEntry(null, drum1.IdValue, step1.IdValue, null, null);
            CokerCardCycleStepEntry entry2 = new CokerCardCycleStepEntry(null, drum1.IdValue, step2.IdValue, null, null);

            Common.Domain.CokerCard.CokerCard card = CokerCardFixture.Create(configuration);
            card.CycleStepEntries.Add(entry2);
            card.CycleStepEntries.Add(entry1);

            CycleStepEntryIteratorsByDrum iteratorsByDrum = new CycleStepEntryIteratorsByDrum(keys, card);

            {
                CycleStepEntryIterator iterator = iteratorsByDrum.GetIteratorForDrum(drum1.IdValue);
                Assert.AreEqual(entry1, iterator.Current);
                iterator.MoveNext();
                Assert.AreEqual(entry2, iterator.Current);
                iterator.MoveNext();
                Assert.IsNull(iterator.Current);
            }
        }
    }
}
