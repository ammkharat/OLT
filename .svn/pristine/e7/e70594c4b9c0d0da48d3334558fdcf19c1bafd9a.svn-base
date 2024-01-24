using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    [TestFixture]
    public class CokerCardRowGroupFillerForPreviousCardTest : CokerCardRowGroupFillerTest
    {
        [Test]
        public void ShouldNotLeaveGapsOnceStartedFillingPreviousCokerCardEntries()
        {
            const int drumId = 1234;

            UserShift previousShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateDayShift(), new DateTime(2010, 6, 10));
            UserShift currentShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateNightShift(), new DateTime(2010, 6, 10));

            CycleStepEntryColumnKeyCollection columnKeys = new CycleStepEntryColumnKeyCollection();
            columnKeys.Add(new CycleStepEntryColumnKey(3, true, "3", 3));
            columnKeys.Add(new CycleStepEntryColumnKey(1, false, "1", 1));
            columnKeys.Add(new CycleStepEntryColumnKey(2, false, "2", 2));
            columnKeys.Add(new CycleStepEntryColumnKey(3, false, "3", 3));

            List<CokerCardCycleStepEntry> entries = new List<CokerCardCycleStepEntry>();
            entries.Add(new CokerCardCycleStepEntry(
                99, drumId, columnKeys[2].CycleStepId, 
                new TimeEntry(new Time(10), previousShift.ShiftPatternId, previousShift.StartDate), 
                new TimeEntry(new Time(11), previousShift.ShiftPatternId, previousShift.StartDate)));
            CycleStepEntryIterator iterator = new CycleStepEntryIterator(entries);

            CokerCardRowGroupFillerForPreviousCard filler = new CokerCardRowGroupFillerForPreviousCard(
                currentShift, columnKeys, iterator, -1);

            CokerCardRowGroup rowGroup = new CokerCardRowGroup(drumId, "drum name", columnKeys);
            foreach (CycleStepEntryColumnKey columnKey in columnKeys)
            {
                rowGroup.AddAdapter(columnKey, new TestAdapter());
            }
            filler.Fill(rowGroup);

            int columnKeyIndex = 0;
            AssertEmptyReadOnlyEntry(rowGroup, columnKeys[columnKeyIndex]);

            columnKeyIndex++;
            AssertEmptyReadOnlyEntry(rowGroup, columnKeys[columnKeyIndex]);

            columnKeyIndex++;
            Assert.AreEqual(new Time(10).ToDateTime(), rowGroup.Rows[0].GetCycleStepEntryDateTime(columnKeys[columnKeyIndex]));
            Assert.AreEqual(new Time(11).ToDateTime(), rowGroup.Rows[1].GetCycleStepEntryDateTime(columnKeys[columnKeyIndex]));
            Assert.IsTrue(rowGroup.Rows[0].IsReadOnlyCycleStepEntry(columnKeys[columnKeyIndex]));
            Assert.IsTrue(rowGroup.Rows[1].IsReadOnlyCycleStepEntry(columnKeys[columnKeyIndex]));

            columnKeyIndex++;
            AssertTestAdapterEntry(rowGroup, columnKeys[columnKeyIndex]);
        }

        [Test]
        public void ShouldNotFillIfOnlyOneCycleStep()
        {
            const int drumId = 1234;

            UserShift previousShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateDayShift(), new DateTime(2010, 6, 10));
            UserShift currentShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateNightShift(), new DateTime(2010, 6, 10));

            CycleStepEntryColumnKeyCollection columnKeys = new CycleStepEntryColumnKeyCollection();
            columnKeys.Add(new CycleStepEntryColumnKey(1, false, "1", 1));

            List<CokerCardCycleStepEntry> entries = new List<CokerCardCycleStepEntry>();
            entries.Add(new CokerCardCycleStepEntry(
                99, drumId, columnKeys[0].CycleStepId,
                new TimeEntry(new Time(10), previousShift.ShiftPatternId, previousShift.StartDate),
                new TimeEntry(new Time(11), previousShift.ShiftPatternId, previousShift.StartDate)));
            CycleStepEntryIterator iterator = new CycleStepEntryIterator(entries);

            CokerCardRowGroupFillerForPreviousCard filler = new CokerCardRowGroupFillerForPreviousCard(
                currentShift, columnKeys, iterator, -1);

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
