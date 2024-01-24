using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    [TestFixture]
    public class CokerCardDisplayAdapterTest
    {
        private CokerCardConfiguration configuration;

        [SetUp]
        public void SetUp()
        {
            configuration = new CokerCardConfiguration(1, "config", FunctionalLocationFixture.GetReal_UP1());
            configuration.Drums.Add(new CokerCardConfigurationDrum(1, "drum1", 1));
            configuration.Drums.Add(new CokerCardConfigurationDrum(2, "drum2", 2));
            configuration.Drums.Add(new CokerCardConfigurationDrum(3, "drum3", 3));
            configuration.Steps.Add(new CokerCardConfigurationCycleStep(1, "step1", 1));
            configuration.Steps.Add(new CokerCardConfigurationCycleStep(2, "step2", 2));
            configuration.Steps.Add(new CokerCardConfigurationCycleStep(3, "step3", 3));
            configuration.Steps.Add(new CokerCardConfigurationCycleStep(4, "step4", 4));
        }

        [Test]
        public void ShouldLoadColumnsUsingDisplayOrder()
        {
            configuration.Steps.Reverse();

            Common.Domain.CokerCard.CokerCard card = CokerCardFixture.Create(configuration);

            CokerCardDisplayAdapter adapter = new CokerCardDisplayAdapter(UserShiftFixture.CreateUserShift(), configuration, card, null, null, null);

            Assert.AreEqual(5, adapter.ColumnKeys.Count);
            Assert.AreEqual(4, adapter.ColumnKeys[0].CycleStepId);
            Assert.AreEqual(1, adapter.ColumnKeys[1].CycleStepId);
            Assert.AreEqual(2, adapter.ColumnKeys[2].CycleStepId);
            Assert.AreEqual(3, adapter.ColumnKeys[3].CycleStepId);
            Assert.AreEqual(4, adapter.ColumnKeys[4].CycleStepId);

            Assert.IsTrue(adapter.ColumnKeys[0].IsLastStepInPreviousCokerCard);
            Assert.IsFalse(adapter.ColumnKeys[1].IsLastStepInPreviousCokerCard);
            Assert.IsFalse(adapter.ColumnKeys[2].IsLastStepInPreviousCokerCard);
            Assert.IsFalse(adapter.ColumnKeys[3].IsLastStepInPreviousCokerCard);
        }

        [Test]
        public void ShouldLoadRowsUsingDisplayOrder()
        {
            configuration.Drums.Reverse();

            Common.Domain.CokerCard.CokerCard card = CokerCardFixture.CreateForInsert(
                configuration, WorkAssignmentFixture.CreateUnitLeader(), ShiftPatternFixture.CreateDayShift(), new Date(2001, 5, 6));

            CokerCardDisplayAdapter adapter = new CokerCardDisplayAdapter(UserShiftFixture.CreateUserShift(), configuration, card, null, null, null);

            Assert.AreEqual(6, adapter.Rows.Count);
            Assert.AreEqual(1, adapter.Rows[0].DrumId);
            Assert.AreEqual(1, adapter.Rows[1].DrumId);
            Assert.AreEqual(2, adapter.Rows[2].DrumId);
            Assert.AreEqual(2, adapter.Rows[3].DrumId);
            Assert.AreEqual(3, adapter.Rows[4].DrumId);
            Assert.AreEqual(3, adapter.Rows[5].DrumId);
        }

        [Test]
        public void ShouldGetDrumEntries()
        {
            long drumId1 = configuration.Drums[0].IdValue;
            long drumId2 = configuration.Drums[1].IdValue;
            long drumId3 = configuration.Drums[2].IdValue;

            Common.Domain.CokerCard.CokerCard card = CokerCardFixture.CreateForInsert(
                configuration, WorkAssignmentFixture.CreateUnitLeader(), ShiftPatternFixture.CreateDayShift(), new Date(2001, 5, 6));
            card.DrumEntries.Add(new CokerCardDrumEntry(101, drumId1, null, null, "comments 1"));
            card.DrumEntries.Add(new CokerCardDrumEntry(102, drumId2, null, null, null));

            CokerCardDisplayAdapter adapter = new CokerCardDisplayAdapter(UserShiftFixture.CreateUserShift(), configuration, card, null, null, null);

            List<CokerCardDrumEntry> entries = adapter.DrumEntries;
            Assert.AreEqual(3, entries.Count);
            Assert.AreEqual(drumId1, entries[0].DrumId);
            Assert.AreEqual("comments 1", entries[0].Comments);
            Assert.AreEqual(drumId2, entries[1].DrumId);
            Assert.AreEqual(null, entries[1].Comments);
            Assert.AreEqual(drumId3, entries[2].DrumId);
            Assert.AreEqual(null, entries[2].Comments);
        }

        [Test]
        public void ShouldNotUseDrumEntryIfDrumIsNotInConfiguration()
        {
            const int drumIdThatDoesNotExist = 1234;

            Common.Domain.CokerCard.CokerCard card = CokerCardFixture.CreateForInsert(
                configuration, WorkAssignmentFixture.CreateUnitLeader(), ShiftPatternFixture.CreateDayShift(), new Date(2001, 5, 6));
            card.DrumEntries.Add(new CokerCardDrumEntry(101, drumIdThatDoesNotExist, null, null, "not add"));

            CokerCardDisplayAdapter adapter = new CokerCardDisplayAdapter(UserShiftFixture.CreateUserShift(), configuration, card, null, null, null);

            List<CokerCardDrumEntry> entries = adapter.DrumEntries;
            Assert.IsFalse(entries.Exists(obj => obj.DrumId == drumIdThatDoesNotExist));
        }

        [Test]
        public void ShouldGetCurrentCycleStepEntry()
        {
            long drumId = configuration.Drums[1].IdValue;
            long cycleStepId = configuration.Steps[1].IdValue;
            AssertGetCurrentCycleStepEntry(true, drumId, cycleStepId);            
        }

        [Test]
        public void ShouldNotUseCurrentCycleStepEntryIfDrumIsNotInConfiguration()
        {
            long drumId = 1234;
            long cycleStepId = configuration.Steps[1].IdValue;
            AssertGetCurrentCycleStepEntry(false, drumId, cycleStepId);
        }

        [Test]
        public void ShouldNotUseCurrentCycleStepEntryIfStepIsNotInConfiguration()
        {
            long drumId = configuration.Drums[1].IdValue;
            long cycleStepId = 1234;
            AssertGetCurrentCycleStepEntry(false, drumId, cycleStepId);    
        }

        private void AssertGetCurrentCycleStepEntry(
            bool expectInEntries, long drumId, long cycleStepId)
        {
            Common.Domain.CokerCard.CokerCard card = CokerCardFixture.CreateForInsert(
                configuration, WorkAssignmentFixture.CreateUnitLeader(), ShiftPatternFixture.CreateDayShift(), new Date(2001, 5, 6));
            CokerCardCycleStepEntry cycleStepEntry = new CokerCardCycleStepEntry(
                101, drumId, cycleStepId, new TimeEntry(new Time(10), card.Shift.IdValue, card.ShiftStartDate), null);
            card.CycleStepEntries.Add(cycleStepEntry);

            CokerCardDisplayAdapter adapter = new CokerCardDisplayAdapter(
                new UserShift(ShiftPatternFixture.CreateNightShift(), card.ShiftStartDate), 
                configuration, card, null, null, null);

            if (expectInEntries)
            {
                CycleStepEntryColumnKey columnKey = adapter.ColumnKeys.Find(obj => !obj.IsLastStepInPreviousCokerCard && obj.CycleStepId == cycleStepId);
                Assert.NotNull(columnKey);

                List<CokerCardRow> rows = adapter.Rows.FindAll(obj => obj.DrumId == drumId);
                Assert.AreEqual(2, rows.Count);
                Assert.IsTrue(rows.Exists(obj => obj.GetCycleStepEntryDateTime(columnKey) == new Time(10).ToDateTime()));
                Assert.IsTrue(rows.Exists(obj => obj.GetCycleStepEntryDateTime(columnKey) == null));
            }

            Assert.AreEqual(expectInEntries, adapter.CycleStepEntriesForCurrentCokerCard.Exists(
                obj => obj.DrumId == drumId && obj.CycleStepId == cycleStepId));
            Assert.AreEqual(false, adapter.CycleStepEntriesForOtherCokerCard.Exists(
                obj => obj.DrumId == drumId && obj.CycleStepId == cycleStepId));
        }

        [Test]
        public void ShouldGetPreviousCycleStepEntry()
        {
            long drumId = configuration.Drums[1].IdValue;
            long cycleStepId = configuration.Steps[1].IdValue;
            AssertGetPreviousCycleStepEntry(true, drumId, cycleStepId);
        }

        [Test]
        public void ShouldNotUsePreviousCycleStepEntryIfDrumIsNotInConfiguration()
        {
            long drumId = 1234;
            long cycleStepId = configuration.Steps[1].IdValue;
            AssertGetPreviousCycleStepEntry(false, drumId, cycleStepId);
        }

        [Test]
        public void ShouldNotUsePreviousCycleStepEntryIfStepIsNotInConfiguration()
        {
            long drumId = configuration.Drums[1].IdValue;
            long cycleStepId = 1234;
            AssertGetPreviousCycleStepEntry(false, drumId, cycleStepId);  
        }

        private void AssertGetPreviousCycleStepEntry(
            bool expectInEntries, long drumId, long cycleStepId)
        {
            WorkAssignment workAssignment = WorkAssignmentFixture.CreateUnitLeader();

            Common.Domain.CokerCard.CokerCard previousCard = CokerCardFixture.CreateForInsert(
                configuration, workAssignment, ShiftPatternFixture.CreateDayShift(), new Date(2001, 5, 6));
            CokerCardCycleStepEntry cycleStepEntry = new CokerCardCycleStepEntry(
                101, drumId, cycleStepId, new TimeEntry(new Time(10), previousCard.Shift.IdValue, previousCard.ShiftStartDate), null);
            previousCard.CycleStepEntries.Add(cycleStepEntry);

            Common.Domain.CokerCard.CokerCard card = CokerCardFixture.CreateForInsert(
                configuration, workAssignment, ShiftPatternFixture.CreateNightShift(), new Date(2001, 5, 6));

            CokerCardDisplayAdapter adapter = new CokerCardDisplayAdapter(
                new UserShift(ShiftPatternFixture.CreateDayShift(), new Date(2001, 5, 7)),
                configuration, card, previousCard, null, null);

            if (expectInEntries)
            {
                CycleStepEntryColumnKey columnKey = adapter.ColumnKeys.Find(obj => 
                    !obj.IsLastStepInPreviousCokerCard && 
                    obj.CycleStepId == cycleStepId);
                Assert.NotNull(columnKey);

                List<CokerCardRow> rows = adapter.Rows.FindAll(obj => obj.DrumId == drumId);
                Assert.AreEqual(2, rows.Count);
                Assert.IsTrue(rows.Exists(obj => obj.GetCycleStepEntryDateTime(columnKey) == new Time(10).ToDateTime()));
                Assert.IsTrue(rows.Exists(obj => obj.GetCycleStepEntryDateTime(columnKey) == null));
            }

            Assert.AreEqual(expectInEntries, adapter.CycleStepEntriesForOtherCokerCard.Exists(
                obj => obj.DrumId == drumId && obj.CycleStepId == cycleStepId));
        }

        [Test]
        public void ShouldUseNextCycleStepEntry()
        {
            long drumId = configuration.Drums[1].IdValue;
            long cycleStepId = configuration.Steps[1].IdValue;
            AssertUseNextCycleStepEntry(false, drumId, cycleStepId);
        }

        [Test]
        public void ShouldNotUseNextCycleStepEntryIfDrumIsNotInConfiguration()
        {
            long drumId = 1234;
            long cycleStepId = configuration.Steps[1].IdValue;
            AssertUseNextCycleStepEntry(false, drumId, cycleStepId);
        }

        [Test]
        public void ShouldNotUseNextCycleStepEntryIfStepIsNotInConfiguration()
        {
            long drumId = configuration.Drums[1].IdValue;
            long cycleStepId = 1234;
            AssertUseNextCycleStepEntry(false, drumId, cycleStepId);
        }

        private void AssertUseNextCycleStepEntry(
            bool expectInEntries, long drumId, long cycleStepId)
        {
            WorkAssignment workAssignment = WorkAssignmentFixture.CreateUnitLeader();

            Common.Domain.CokerCard.CokerCard nextCard = CokerCardFixture.CreateForInsert(
                configuration, workAssignment, ShiftPatternFixture.CreateDayShift(), new Date(2001, 5, 7));
            CokerCardCycleStepEntry cycleStepEntry = new CokerCardCycleStepEntry(
                101, drumId, cycleStepId, new TimeEntry(new Time(10), nextCard.Shift.IdValue, nextCard.ShiftStartDate), null);
            nextCard.CycleStepEntries.Add(cycleStepEntry);

            Common.Domain.CokerCard.CokerCard card = CokerCardFixture.CreateForInsert(
                configuration, workAssignment, ShiftPatternFixture.CreateNightShift(), new Date(2001, 5, 6));

            CokerCardDisplayAdapter adapter = new CokerCardDisplayAdapter(
                new UserShift(nextCard.Shift, nextCard.ShiftStartDate), 
                configuration, card, null, nextCard, null);

            if (expectInEntries)
            {
                CycleStepEntryColumnKey columnKey = adapter.ColumnKeys.Find(obj => 
                    !obj.IsLastStepInPreviousCokerCard && 
                    obj.CycleStepId == cycleStepId);
                Assert.NotNull(columnKey);

                List<CokerCardRow> rows = adapter.Rows.FindAll(obj => obj.DrumId == drumId);
                Assert.AreEqual(2, rows.Count);
                Assert.IsTrue(rows.Exists(obj => obj.GetCycleStepEntryDateTime(columnKey) == new Time(10).ToDateTime()));
                Assert.IsTrue(rows.Exists(obj => obj.GetCycleStepEntryDateTime(columnKey) == null));
            }
        }

        [Test]
        public void ShouldPutCurrentCokerCardEntryIntoLastColumn()
        {
            TimePair[] current = new[] { null, null, null, new TimePair(1, 2)};
            TimePair[] previous = null;
            TimePair[] next = null;

            TimePair[] expected = new[] { null, null, null, null, new TimePair(1, 2) };

            AssertFillEntries(expected, current, previous, next);
        }

        [Test]
        public void ShouldPutPreviousCardEntryIntoFirstColumn()
        {
            TimePair[] current = new TimePair[] { null, null, null, null };
            TimePair[] previous = new[] { null, null, null, new TimePair(1, 2) };
            TimePair[] next = null;

            TimePair[] expected = new[] { new TimePair(1, 2), null, null, null, null };

            AssertFillEntries(expected, current, previous, next);
        }

        [Test]
        public void ShouldPutNextCardEntryIntoLastColumn()
        {
            TimePair[] current = new TimePair[] { null, null, null, null };
            TimePair[] previous = null;
            TimePair[] next = new[] { null, null, null, new TimePair(1, 2) };

            TimePair[] expected = new[] { null, null, null, null, new TimePair(1, 2) };

            AssertFillEntries(expected, current, previous, next);            
        }

        [Test]
        public void ShouldFillCurrentCardWithGaps()
        {
            {
                TimePair[] current = new[] { new TimePair(1, 2), null, new TimePair(3, 4), null };
                TimePair[] previous = null;
                TimePair[] next = null;

                TimePair[] expected = new[] { null, new TimePair(1, 2), null, new TimePair(3, 4), null };

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new[] {null, new TimePair(1, 2), null, new TimePair(3, 4)};
                TimePair[] previous = null;
                TimePair[] next = null;

                TimePair[] expected = new[] {null, null, new TimePair(1, 2), null, new TimePair(3, 4)};

                AssertFillEntries(expected, current, previous, next);
            }
        }

        [Test]
        public void ShouldFillPreviousCardWithGaps()
        {
            {
                TimePair[] current = new TimePair[] {null, null, null, null};
                TimePair[] previous = new[] {new TimePair(1, 2), null, new TimePair(3, 4), null};
                TimePair[] next = null;

                TimePair[] expected = new[] {null, new TimePair(1, 2), null, new TimePair(3, 4), null};

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new TimePair[] { null, null, null, null };
                TimePair[] previous = new[] { null, new TimePair(1, 2), null, new TimePair(3, 4) };
                TimePair[] next = null;

                TimePair[] expected = new[] { new TimePair(3, 4), null, null, null, null };

                AssertFillEntries(expected, current, previous, next);
            }
        }

        [Test]
        public void ShouldFillNextCardWithGaps()
        {
            {
                TimePair[] current = new TimePair[] {null, null, null, null};
                TimePair[] previous = null;
                TimePair[] next = new[] {new TimePair(1, 2), null, new TimePair(3, 4), null};

                TimePair[] expected = new[] {null, new TimePair(1, 2), null, new TimePair(3, 4), null};

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new TimePair[] { null, null, null, null };
                TimePair[] previous = null;
                TimePair[] next = new[] { null, new TimePair(1, 2), null, new TimePair(3, 4) };

                TimePair[] expected = new[] { null, null, new TimePair(1, 2), null, new TimePair(3, 4) };

                AssertFillEntries(expected, current, previous, next);
            }
        }

        [Test]
        public void ShouldFillEntriesExceptFirstAndLast()
        {
            TimePair[] current = new[] { null, new TimePair(3, 4), null, null };
            TimePair[] previous = new[] { new TimePair(1, 2), null, null, null };
            TimePair[] next = new[] { null, null, new TimePair(5, 6), null };

            TimePair[] expected = new[] { null, new TimePair(1, 2), new TimePair(3, 4), new TimePair(5, 6), null };

            AssertFillEntries(expected, current, previous, next);
        }

        [Test]
        public void ShouldFillPreviousEntriesOnlyUpToCurrent_PreviousHasEntryInLastStep()
        {
            {
                TimePair[] current = new[] { new TimePair(9, 10), null, null, null };
                TimePair[] previous = new[] { new TimePair(1, 2), new TimePair(3, 4), new TimePair(5, 6), new TimePair(7, 8) };
                TimePair[] next = null;

                TimePair[] expected = new[] { new TimePair(7, 8), new TimePair(9, 10), null, null, null };

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new[] { null, new TimePair(9, 10), null, null };
                TimePair[] previous = new[] { new TimePair(1, 2), new TimePair(3, 4), new TimePair(5, 6), new TimePair(7, 8) };
                TimePair[] next = null;

                TimePair[] expected = new[] { new TimePair(7, 8), null, new TimePair(9, 10), null, null };

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new[] { null, null, new TimePair(9, 10), null };
                TimePair[] previous = new[] { new TimePair(1, 2), new TimePair(3, 4), new TimePair(5, 6), new TimePair(7, 8) };
                TimePair[] next = null;

                TimePair[] expected = new[] { new TimePair(7, 8), null, null, new TimePair(9, 10), null };

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new[] { null, null, null, new TimePair(9, 10) };
                TimePair[] previous = new[] { new TimePair(1, 2), new TimePair(3, 4), new TimePair(5, 6), new TimePair(7, 8) };
                TimePair[] next = null;

                TimePair[] expected = new[] { new TimePair(7, 8), null, null, null, new TimePair(9, 10) };

                AssertFillEntries(expected, current, previous, next);
            }
        }

        [Test]
        public void ShouldFillPreviousEntriesOnlyUpToCurrent_PreviousDoesNotHaveEntryInLastStep()
        {
            {
                TimePair[] current = new[] { new TimePair(9, 10), null, null, null };
                TimePair[] previous = new[] { new TimePair(1, 2), new TimePair(3, 4), new TimePair(5, 6), null };
                TimePair[] next = null;

                TimePair[] expected = new[] { null, new TimePair(9, 10), null, null, null };

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new[] { null, new TimePair(9, 10), null, null };
                TimePair[] previous = new[] { new TimePair(1, 2), new TimePair(3, 4), new TimePair(5, 6), null };
                TimePair[] next = null;

                TimePair[] expected = new[] { null, new TimePair(1, 2), new TimePair(9, 10), null, null };

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new[] { null, null, new TimePair(9, 10), null };
                TimePair[] previous = new[] { new TimePair(1, 2), new TimePair(3, 4), new TimePair(5, 6), null };
                TimePair[] next = null;

                TimePair[] expected = new[] { null, new TimePair(1, 2), new TimePair(3, 4), new TimePair(9, 10), null };

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new[] { null, null, null, new TimePair(9, 10) };
                TimePair[] previous = new[] { new TimePair(1, 2), new TimePair(3, 4), new TimePair(5, 6), null };
                TimePair[] next = null;

                TimePair[] expected = new[] { null, new TimePair(1, 2), new TimePair(3, 4), new TimePair(5, 6), new TimePair(9, 10) };

                AssertFillEntries(expected, current, previous, next);
            }
        }

        [Test]
        public void ShouldFillNextEntriesOnlyIfTheyStartAfterCurrent()
        {
            {
                TimePair[] current = new[] { new TimePair(9, 10), null, null, null };
                TimePair[] previous = null;
                TimePair[] next = new[] { new TimePair(1, 2), new TimePair(3, 4), new TimePair(5, 6), new TimePair(7, 8) };

                TimePair[] expected = new[] { null, new TimePair(9, 10), null, null, null };

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new[] { null, new TimePair(9, 10), null, null };
                TimePair[] previous = null;
                TimePair[] next = new[] { new TimePair(1, 2), new TimePair(3, 4), new TimePair(5, 6), new TimePair(7, 8) };

                TimePair[] expected = new[] { null, null, new TimePair(9, 10), null, null };

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new[] { null, new TimePair(9, 10), null, null };
                TimePair[] previous = null;
                TimePair[] next = new[] { null, new TimePair(3, 4), new TimePair(5, 6), new TimePair(7, 8) };

                TimePair[] expected = new[] { null, null, new TimePair(9, 10), null, null };

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new[] { null, new TimePair(9, 10), null, null };
                TimePair[] previous = null;
                TimePair[] next = new[] { null, null, new TimePair(5, 6), new TimePair(7, 8) };

                TimePair[] expected = new[] { null, null, new TimePair(9, 10), new TimePair(5, 6), new TimePair(7, 8) };

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new[] { null, null, new TimePair(9, 10), null };
                TimePair[] previous = null;
                TimePair[] next = new[] { new TimePair(1, 2), new TimePair(3, 4), new TimePair(5, 6), new TimePair(7, 8) };

                TimePair[] expected = new[] { null, null, null, new TimePair(9, 10), null };

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new[] { null, null, new TimePair(9, 10), null };
                TimePair[] previous = null;
                TimePair[] next = new[] { null, new TimePair(3, 4), new TimePair(5, 6), new TimePair(7, 8) };

                TimePair[] expected = new[] { null, null, null, new TimePair(9, 10), null };

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new[] { null, null, new TimePair(9, 10), null };
                TimePair[] previous = null;
                TimePair[] next = new[] { null, null, new TimePair(5, 6), new TimePair(7, 8) };

                TimePair[] expected = new[] { null, null, null, new TimePair(9, 10), null };

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new[] { null, null, new TimePair(9, 10), null };
                TimePair[] previous = null;
                TimePair[] next = new[] { null, null, null, new TimePair(7, 8) };

                TimePair[] expected = new[] { null, null, null, new TimePair(9, 10), new TimePair(7, 8) };

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new[] { null, null, null, new TimePair(9, 10) };
                TimePair[] previous = null;
                TimePair[] next = new[] { new TimePair(1, 2), new TimePair(3, 4), new TimePair(5, 6), new TimePair(7, 8) };

                TimePair[] expected = new[] { null, null, null, null, new TimePair(9, 10) };

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new[] { null, null, null, new TimePair(9, 10) };
                TimePair[] previous = null;
                TimePair[] next = new[] { null, new TimePair(3, 4), new TimePair(5, 6), new TimePair(7, 8) };

                TimePair[] expected = new[] { null, null, null, null, new TimePair(9, 10) };

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new[] { null, null, null, new TimePair(9, 10) };
                TimePair[] previous = null;
                TimePair[] next = new[] { null, null, new TimePair(5, 6), new TimePair(7, 8) };

                TimePair[] expected = new[] { null, null, null, null, new TimePair(9, 10) };

                AssertFillEntries(expected, current, previous, next);
            }
            {
                TimePair[] current = new[] { null, null, null, new TimePair(9, 10) };
                TimePair[] previous = null;
                TimePair[] next = new[] { null, null, null, new TimePair(7, 8) };

                TimePair[] expected = new[] { null, null, null, null, new TimePair(9, 10) };

                AssertFillEntries(expected, current, previous, next);
            }
        }

        [Test]
        public void ShouldUseLastEntryFromPreviousPreviousCard()
        {
            {
                TimePair[] current = new[] { null, null, null, new TimePair(9, 10)};
                TimePair[] previous = new TimePair[] { null, null, null, null };
                TimePair[] next = null;
                TimePair[] previousPrevious = new[] { null, null, null, new TimePair(7, 8) };

                TimePair[] expected = new[] { new TimePair(7, 8), null, null, null, new TimePair(9, 10) };

                AssertFillEntries(expected, current, previous, next, previousPrevious);
            }
            {
                TimePair[] current = new[] { null, null, null, new TimePair(9, 10) };
                TimePair[] previous = null;
                TimePair[] next = null;
                TimePair[] previousPrevious = new[] { null, null, null, new TimePair(7, 8) };

                TimePair[] expected = new[] { new TimePair(7, 8), null, null, null, new TimePair(9, 10) };

                AssertFillEntries(expected, current, previous, next, previousPrevious);
            }
            {
                TimePair[] current = new[] { null, null, null, new TimePair(9, 10) };
                TimePair[] previous = new[] { null, null, null, new TimePair(7, 8) };
                TimePair[] next = null;
                TimePair[] previousPrevious = new[] { null, null, null, new TimePair(11, 12) };

                TimePair[] expected = new[] { new TimePair(7, 8), null, null, null, new TimePair(9, 10) };

                AssertFillEntries(expected, current, previous, next, previousPrevious);
            }
            {
                TimePair[] current = new[] { null, null, null, new TimePair(9, 10) };
                TimePair[] previous = new[] { null, null, new TimePair(7, 8), null };
                TimePair[] next = null;
                TimePair[] previousPrevious = new[] { null, null, null, new TimePair(11, 12) };

                TimePair[] expected = new[] { null, null, null, new TimePair(7, 8), new TimePair(9, 10) };

                AssertFillEntries(expected, current, previous, next, previousPrevious);
            }
            {
                TimePair[] current = new[] { null, null, null, new TimePair(9, 10) };
                TimePair[] previous = new[] { null, new TimePair(7, 8), null, null };
                TimePair[] next = null;
                TimePair[] previousPrevious = new[] { null, null, null, new TimePair(11, 12) };

                TimePair[] expected = new[] { null, null, new TimePair(7, 8), null, new TimePair(9, 10) };

                AssertFillEntries(expected, current, previous, next, previousPrevious);
            }
            {
                TimePair[] current = new[] { null, null, null, new TimePair(9, 10) };
                TimePair[] previous = new[] { new TimePair(7, 8), null, null, null };
                TimePair[] next = null;
                TimePair[] previousPrevious = new[] { null, null, null, new TimePair(11, 12) };

                TimePair[] expected = new[] { null, new TimePair(7, 8), null, null, new TimePair(9, 10) };

                AssertFillEntries(expected, current, previous, next, previousPrevious);
            }
            {
                TimePair[] current = new[] { null, null, null, new TimePair(9, 10) };
                TimePair[] previous = new TimePair[] { null, null, null, null };
                TimePair[] next = null;
                TimePair[] previousPrevious = new[] { null, null, new TimePair(7, 8), null };

                TimePair[] expected = new[] { null, null, null, null, new TimePair(9, 10) };

                AssertFillEntries(expected, current, previous, next, previousPrevious);
            }
            {
                TimePair[] current = new[] { null, null, null, new TimePair(9, 10) };
                TimePair[] previous = new TimePair[] { null, null, null, null };
                TimePair[] next = null;
                TimePair[] previousPrevious = new[] { null, new TimePair(7, 8), null, null };

                TimePair[] expected = new[] { null, null, null, null, new TimePair(9, 10) };

                AssertFillEntries(expected, current, previous, next, previousPrevious);
            }
            {
                TimePair[] current = new[] { null, null, null, new TimePair(9, 10) };
                TimePair[] previous = new TimePair[] { null, null, null, null };
                TimePair[] next = null;
                TimePair[] previousPrevious = new[] { new TimePair(7, 8), null, null, null };

                TimePair[] expected = new[] { null, null, null, null, new TimePair(9, 10) };

                AssertFillEntries(expected, current, previous, next, previousPrevious);
            }
        }

        private void AssertFillEntries(TimePair[] expected, TimePair[] current, TimePair[] previous, TimePair[] next)
        {
            AssertFillEntries(expected, current, previous, next, null);
        }

        private void AssertFillEntries(TimePair[] expected, TimePair[] current, TimePair[] previous, TimePair[] next, TimePair[] previousPrevious)
        {
            long drumId = configuration.Drums[0].IdValue;

            Common.Domain.CokerCard.CokerCard previousPreviousCard = CreateCard(previousPrevious, drumId, ShiftPatternFixture.CreateDayShift(), new Date(2001, 5, 6));
            Common.Domain.CokerCard.CokerCard previousCard = CreateCard(previous, drumId, ShiftPatternFixture.CreateNightShift(), new Date(2001, 5, 6));
            Common.Domain.CokerCard.CokerCard currentCard = CreateCard(current, drumId, ShiftPatternFixture.CreateDayShift(), new Date(2001, 5, 7));
            Common.Domain.CokerCard.CokerCard nextCard = CreateCard(next, drumId, ShiftPatternFixture.CreateNightShift(), new Date(2001, 5, 7));

            CokerCardDisplayAdapter adapter = new CokerCardDisplayAdapter(
                new UserShift(ShiftPatternFixture.CreateNightShift(), new Date(2001, 5, 7)), 
                configuration, currentCard, previousCard, nextCard, previousPreviousCard);

            List<CokerCardRow> rows = adapter.Rows.FindAll(obj => obj.DrumId == drumId);

            StringBuilder sb = new StringBuilder();
            foreach (CycleStepEntryColumnKey columnKey in adapter.ColumnKeys)
            {
                DateTime? dateTime = rows[0].GetCycleStepEntryDateTime(columnKey);
                sb.Append(dateTime.HasValue ? dateTime.ToString() : "<null>");
                sb.Append(",");
            }
            sb.AppendLine("");
            foreach (CycleStepEntryColumnKey columnKey in adapter.ColumnKeys)
            {
                DateTime? dateTime = rows[1].GetCycleStepEntryDateTime(columnKey);
                sb.Append(dateTime.HasValue ? dateTime.ToString() : "<null>");
                sb.Append(",");
            }
            string matrix = sb.ToString();

            for (int i = 0; i < expected.Length; i++)
            {
                string errorString = "For position " + i + Environment.NewLine + matrix;

                TimePair timePair = expected[i];
                CycleStepEntryColumnKey columnKey = adapter.ColumnKeys[i];

                if (timePair == null)
                {
                    Assert.AreEqual(null, rows[0].GetCycleStepEntryDateTime(columnKey), errorString);
                    Assert.AreEqual(null, rows[1].GetCycleStepEntryDateTime(columnKey), errorString);
                }
                else
                {
                    Assert.IsNotNull(rows[0].GetCycleStepEntryDateTime(columnKey), errorString);
                    Assert.AreEqual(timePair.Start, rows[0].GetCycleStepEntryDateTime(columnKey).Value.Hour, errorString);
                    if (timePair.End == null)
                    {
                        Assert.AreEqual(null, rows[1].GetCycleStepEntryDateTime(columnKey), errorString);
                    }
                    else
                    {
                        Assert.IsNotNull(rows[1].GetCycleStepEntryDateTime(columnKey), errorString);
                        Assert.AreEqual(timePair.End, rows[1].GetCycleStepEntryDateTime(columnKey).Value.Hour, errorString);
                    }
                }
            }
        }

        private Common.Domain.CokerCard.CokerCard CreateCard(TimePair[] times, long drumId, ShiftPattern shift, Date shiftDate)
        {
            if (times == null)
            {
                return null;
            }

            Common.Domain.CokerCard.CokerCard card = CokerCardFixture.CreateForInsert(
                configuration, WorkAssignmentFixture.CreateUnitLeader(), shift, shiftDate);

            for (int i = 0; i < times.Length; i++)
            {
                TimePair timePair = times[i];
                if (timePair != null)
                {
                    TimeEntry startEntry = new TimeEntry(new Time(timePair.Start.Value), card.Shift.IdValue, card.ShiftStartDate);

                    TimeEntry endEntry = null;
                    if (timePair.End.HasValue)
                    {
                        endEntry = new TimeEntry(new Time(timePair.End.Value), card.Shift.IdValue, card.ShiftStartDate);
                    }

                    CokerCardCycleStepEntry cycleStepEntry = new CokerCardCycleStepEntry(
                        101, drumId, configuration.Steps[i].IdValue,
                        startEntry,
                        endEntry);
                    card.CycleStepEntries.Add(cycleStepEntry);
                }
            }

            return card;
        }
    }
}
