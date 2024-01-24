using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    [TestFixture]
    public class CokerCardRowGroupFillerForNextCardTest : CokerCardRowGroupFillerTest
    {
        [Test]
        public void ShouldNotLeaveGapsOnceStartedFillingNextCokerCardEntries()
        {
            const int drumId = 1234;

            UserShift currentShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateNightShift(), new DateTime(2010, 6, 10));
            UserShift nextShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateDayShift(), new DateTime(2010, 6, 11));

            CycleStepEntryColumnKeyCollection columnKeys = new CycleStepEntryColumnKeyCollection();
            columnKeys.Add(new CycleStepEntryColumnKey(3, true, "3", 3));
            columnKeys.Add(new CycleStepEntryColumnKey(1, false, "1", 1));
            columnKeys.Add(new CycleStepEntryColumnKey(2, false, "2", 2));
            columnKeys.Add(new CycleStepEntryColumnKey(3, false, "3", 3));

            List<CokerCardCycleStepEntry> entries = new List<CokerCardCycleStepEntry>();
            entries.Add(new CokerCardCycleStepEntry(
                99, drumId, columnKeys[2].CycleStepId,
                new TimeEntry(new Time(10), nextShift.ShiftPatternId, nextShift.StartDate),
                new TimeEntry(new Time(11), nextShift.ShiftPatternId, nextShift.StartDate)));
            CycleStepEntryIterator iterator = new CycleStepEntryIterator(entries);

            CokerCardRowGroupFillerForNextCard filler = new CokerCardRowGroupFillerForNextCard(
                nextShift, columnKeys, iterator, -1);

            CokerCardRowGroup rowGroup = new CokerCardRowGroup(drumId, "drum name", columnKeys);
            foreach (CycleStepEntryColumnKey columnKey in columnKeys)
            {
                rowGroup.AddAdapter(columnKey, new TestAdapter());
            }
            filler.Fill(rowGroup);

            int columnKeyIndex = 0;
            AssertTestAdapterEntry(rowGroup, columnKeys[columnKeyIndex]);

            columnKeyIndex++;
            AssertTestAdapterEntry(rowGroup, columnKeys[columnKeyIndex]);

            columnKeyIndex++;
            Assert.AreEqual(new Time(10).ToDateTime(), rowGroup.Rows[0].GetCycleStepEntryDateTime(columnKeys[columnKeyIndex]));
            Assert.AreEqual(new Time(11).ToDateTime(), rowGroup.Rows[1].GetCycleStepEntryDateTime(columnKeys[columnKeyIndex]));
            Assert.IsTrue(rowGroup.Rows[0].IsReadOnlyCycleStepEntry(columnKeys[columnKeyIndex]));
            Assert.IsTrue(rowGroup.Rows[1].IsReadOnlyCycleStepEntry(columnKeys[columnKeyIndex]));

            columnKeyIndex++;
            AssertEmptyReadOnlyEntry(rowGroup, columnKeys[columnKeyIndex]);
        }

        [Test]
        public void ShouldStartFillingAfterEntryThatHasEndTimeForNextShift_NextEntriesExist()
        {
            const int drumId = 1234;

            UserShift currentShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateNightShift(), new DateTime(2010, 6, 10));
            UserShift nextShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateDayShift(), new DateTime(2010, 6, 11));

            CycleStepEntryColumnKeyCollection columnKeys = new CycleStepEntryColumnKeyCollection();
            columnKeys.Add(new CycleStepEntryColumnKey(3, true, "3", 3));
            columnKeys.Add(new CycleStepEntryColumnKey(1, false, "1", 1));
            columnKeys.Add(new CycleStepEntryColumnKey(2, false, "2", 2));
            columnKeys.Add(new CycleStepEntryColumnKey(3, false, "3", 3));

            List<CokerCardCycleStepEntry> entries = new List<CokerCardCycleStepEntry>();
            entries.Add(new CokerCardCycleStepEntry(
                99, drumId, columnKeys[3].CycleStepId,
                new TimeEntry(new Time(12), nextShift.ShiftPatternId, nextShift.StartDate),
                new TimeEntry(new Time(13), nextShift.ShiftPatternId, nextShift.StartDate)));
            CycleStepEntryIterator iterator = new CycleStepEntryIterator(entries);

            CokerCardRowGroupFillerForNextCard filler = new CokerCardRowGroupFillerForNextCard(
                nextShift, columnKeys, iterator, -1);

            CokerCardRowGroup rowGroup = new CokerCardRowGroup(drumId, "drum name", columnKeys);
            foreach (CycleStepEntryColumnKey columnKey in columnKeys)
            {
                rowGroup.AddAdapter(columnKey, new TestAdapter());
            }

            const int indexForEntryThatHasEndForNextShift = 1;
            CokerCardCycleStepEntry entryThatHasEndTimeForNextShift = new CokerCardCycleStepEntry(
                999, drumId, columnKeys[indexForEntryThatHasEndForNextShift].CycleStepId,
                new TimeEntry(new Time(10), currentShift.ShiftPatternId, currentShift.StartDate),
                new TimeEntry(new Time(11), nextShift.ShiftPatternId, nextShift.StartDate));
            rowGroup.AddAdapter(columnKeys[indexForEntryThatHasEndForNextShift], new CycleStepEntryDisplayAdapterForCurrentCardEntry(currentShift, entryThatHasEndTimeForNextShift));

            filler.Fill(rowGroup);

            int columnKeyIndex = 0;
            AssertTestAdapterEntry(rowGroup, columnKeys[columnKeyIndex]);

            columnKeyIndex++;
            Assert.AreEqual(new Time(10).ToDateTime(), rowGroup.Rows[0].GetCycleStepEntryDateTime(columnKeys[columnKeyIndex]));
            Assert.AreEqual(new Time(11).ToDateTime(), rowGroup.Rows[1].GetCycleStepEntryDateTime(columnKeys[columnKeyIndex]));

            columnKeyIndex++;
            AssertEmptyReadOnlyEntry(rowGroup, columnKeys[columnKeyIndex]);

            columnKeyIndex++;
            Assert.AreEqual(new Time(12).ToDateTime(), rowGroup.Rows[0].GetCycleStepEntryDateTime(columnKeys[columnKeyIndex]));
            Assert.AreEqual(new Time(13).ToDateTime(), rowGroup.Rows[1].GetCycleStepEntryDateTime(columnKeys[columnKeyIndex]));
            Assert.IsTrue(rowGroup.Rows[0].IsReadOnlyCycleStepEntry(columnKeys[columnKeyIndex]));
            Assert.IsTrue(rowGroup.Rows[1].IsReadOnlyCycleStepEntry(columnKeys[columnKeyIndex]));
        }

        [Test]
        public void ShouldStartFillingAfterEntryThatHasEndTimeForNextShift_NextEntriesDoNotExist()
        {
            const int drumId = 1234;

            UserShift currentShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateNightShift(), new DateTime(2010, 6, 10));
            UserShift nextShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateDayShift(), new DateTime(2010, 6, 11));

            CycleStepEntryColumnKeyCollection columnKeys = new CycleStepEntryColumnKeyCollection();
            columnKeys.Add(new CycleStepEntryColumnKey(3, true, "3", 3));
            columnKeys.Add(new CycleStepEntryColumnKey(1, false, "1", 1));
            columnKeys.Add(new CycleStepEntryColumnKey(2, false, "2", 2));
            columnKeys.Add(new CycleStepEntryColumnKey(3, false, "3", 3));

            List<CokerCardCycleStepEntry> entries = new List<CokerCardCycleStepEntry>();
            CycleStepEntryIterator iterator = new CycleStepEntryIterator(entries);

            CokerCardRowGroupFillerForNextCard filler = new CokerCardRowGroupFillerForNextCard(
                nextShift, columnKeys, iterator, -1);

            CokerCardRowGroup rowGroup = new CokerCardRowGroup(drumId, "drum name", columnKeys);
            foreach (CycleStepEntryColumnKey columnKey in columnKeys)
            {
                rowGroup.AddAdapter(columnKey, new TestAdapter());                    
            }

            const int indexForEntryThatHasEndForNextShift = 1;
            CokerCardCycleStepEntry entryThatHasEndTimeForNextShift = new CokerCardCycleStepEntry(
                999, drumId, columnKeys[indexForEntryThatHasEndForNextShift].CycleStepId,
                new TimeEntry(new Time(10), currentShift.ShiftPatternId, currentShift.StartDate),
                new TimeEntry(new Time(11), nextShift.ShiftPatternId, nextShift.StartDate));
            rowGroup.AddAdapter(columnKeys[indexForEntryThatHasEndForNextShift], new CycleStepEntryDisplayAdapterForCurrentCardEntry(currentShift, entryThatHasEndTimeForNextShift));
            
            filler.Fill(rowGroup);

            int columnKeyIndex = 0;
            AssertTestAdapterEntry(rowGroup, columnKeys[columnKeyIndex]);

            columnKeyIndex++;
            Assert.AreEqual(new Time(10).ToDateTime(), rowGroup.Rows[0].GetCycleStepEntryDateTime(columnKeys[columnKeyIndex]));
            Assert.AreEqual(new Time(11).ToDateTime(), rowGroup.Rows[1].GetCycleStepEntryDateTime(columnKeys[columnKeyIndex]));

            columnKeyIndex++;
            AssertEmptyReadOnlyEntry(rowGroup, columnKeys[columnKeyIndex]);

            columnKeyIndex++;
            AssertEmptyReadOnlyEntry(rowGroup, columnKeys[columnKeyIndex]);
        }

        [Test]
        public void ShouldStartFillingAfterEntryThatHasEndTimeForNextShift_ExistingIsPreviousEntry()
        {
            const int drumId = 1234;

            UserShift previousShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateDayShift(), new DateTime(2010, 6, 10));
            UserShift currentShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateNightShift(), new DateTime(2010, 6, 10));
            UserShift nextShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateDayShift(), new DateTime(2010, 6, 11));

            CycleStepEntryColumnKeyCollection columnKeys = new CycleStepEntryColumnKeyCollection();
            columnKeys.Add(new CycleStepEntryColumnKey(3, true, "3", 3));
            columnKeys.Add(new CycleStepEntryColumnKey(1, false, "1", 1));
            columnKeys.Add(new CycleStepEntryColumnKey(2, false, "2", 2));
            columnKeys.Add(new CycleStepEntryColumnKey(3, false, "3", 3));

            List<CokerCardCycleStepEntry> entries = new List<CokerCardCycleStepEntry>();
            CycleStepEntryIterator iterator = new CycleStepEntryIterator(entries);

            CokerCardRowGroupFillerForNextCard filler = new CokerCardRowGroupFillerForNextCard(
                nextShift, columnKeys, iterator, -1);

            CokerCardRowGroup rowGroup = new CokerCardRowGroup(drumId, "drum name", columnKeys);
            foreach (CycleStepEntryColumnKey columnKey in columnKeys)
            {
                rowGroup.AddAdapter(columnKey, new TestAdapter());
            }

            const int indexForEntryThatHasEndForNextShift = 1;
            CokerCardCycleStepEntry entryThatHasEndTimeForNextShift = new CokerCardCycleStepEntry(
                999, drumId, columnKeys[indexForEntryThatHasEndForNextShift].CycleStepId,
                new TimeEntry(new Time(10), previousShift.ShiftPatternId, previousShift.StartDate),
                new TimeEntry(new Time(11), nextShift.ShiftPatternId, nextShift.StartDate));
            rowGroup.AddAdapter(columnKeys[indexForEntryThatHasEndForNextShift], new CycleStepEntryDisplayAdapterForPreviousCardEntry(currentShift, entryThatHasEndTimeForNextShift));

            filler.Fill(rowGroup);

            int columnKeyIndex = 0;
            AssertTestAdapterEntry(rowGroup, columnKeys[columnKeyIndex]);

            columnKeyIndex++;
            Assert.AreEqual(new Time(10).ToDateTime(), rowGroup.Rows[0].GetCycleStepEntryDateTime(columnKeys[columnKeyIndex]));
            Assert.AreEqual(new Time(11).ToDateTime(), rowGroup.Rows[1].GetCycleStepEntryDateTime(columnKeys[columnKeyIndex]));

            columnKeyIndex++;
            AssertEmptyReadOnlyEntry(rowGroup, columnKeys[columnKeyIndex]);

            columnKeyIndex++;
            AssertEmptyReadOnlyEntry(rowGroup, columnKeys[columnKeyIndex]);
        }


        [Test]
        public void ShouldNotFillIfOnlyOneCycleStep()
        {
            const int drumId = 1234;

            UserShift currentShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateNightShift(), new DateTime(2010, 6, 10));
            UserShift nextShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateDayShift(), new DateTime(2010, 6, 11));

            CycleStepEntryColumnKeyCollection columnKeys = new CycleStepEntryColumnKeyCollection();
            columnKeys.Add(new CycleStepEntryColumnKey(1, false, "1", 1));

            List<CokerCardCycleStepEntry> entries = new List<CokerCardCycleStepEntry>();
            entries.Add(new CokerCardCycleStepEntry(
                99, drumId, columnKeys[0].CycleStepId,
                new TimeEntry(new Time(10), nextShift.ShiftPatternId, nextShift.StartDate),
                new TimeEntry(new Time(11), nextShift.ShiftPatternId, nextShift.StartDate)));
            CycleStepEntryIterator iterator = new CycleStepEntryIterator(entries);

            CokerCardRowGroupFillerForNextCard filler = new CokerCardRowGroupFillerForNextCard(
                nextShift, columnKeys, iterator, -1);

            CokerCardRowGroup rowGroup = new CokerCardRowGroup(drumId, "drum name", columnKeys);
            foreach (CycleStepEntryColumnKey columnKey in columnKeys)
            {
                rowGroup.AddAdapter(columnKey, new TestAdapter());
            }
            filler.Fill(rowGroup);

            AssertTestAdapterEntry(rowGroup, columnKeys[0]);
        }
    }
}
