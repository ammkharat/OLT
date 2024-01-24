using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    [TestFixture]
    public class CycleStepEntryDisplayAdapterForPreviousCardEntryTest
    {
        [Test]
        public void ShouldCreateWithNullEntry()
        {
            UserShift currentShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateNightShift(), new DateTime(2010, 6, 10));

            CycleStepEntryDisplayAdapterForPreviousCardEntry adapter =
                new CycleStepEntryDisplayAdapterForPreviousCardEntry(currentShift, 1, 2);

            Assert.IsTrue(adapter.IsStartDateTimeReadOnly);
            Assert.IsTrue(adapter.IsEndDateTimeReadOnly);

            {
                Assert.IsNull(adapter.StartDateTime);
                Assert.IsNull(adapter.EndDateTime);
                Assert.IsNull(adapter.GetCycleStepEntry());
            }

            AssertReadOnlyAdapter(adapter, null, null);
        }

        [Test]
        public void ShouldCreateWithEntry()
        {
            UserShift previousShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateDayShift(), new DateTime(2010, 6, 10));
            UserShift currentShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateNightShift(), new DateTime(2010, 6, 10));

            CokerCardCycleStepEntry entry = new CokerCardCycleStepEntry(
                1001, 1, 2,
                new TimeEntry(new Time(10), previousShift.ShiftPatternId, previousShift.StartDate),
                new TimeEntry(new Time(11), previousShift.ShiftPatternId, previousShift.StartDate));
            CycleStepEntryDisplayAdapterForPreviousCardEntry adapter =
                new CycleStepEntryDisplayAdapterForPreviousCardEntry(currentShift, entry);

            Assert.IsTrue(adapter.IsStartDateTimeReadOnly);
            Assert.IsTrue(adapter.IsEndDateTimeReadOnly);

            {
                Assert.AreEqual(new Time(10), new Time(adapter.StartDateTime.Value));
                Assert.AreEqual(new Time(11), new Time(adapter.EndDateTime.Value));
                Assert.IsNull(adapter.GetCycleStepEntry());
            }

            AssertReadOnlyAdapter(adapter, new Time(10).ToDateTime(), new Time(11).ToDateTime());
        }

        private static void AssertReadOnlyAdapter(
            CycleStepEntryDisplayAdapterForPreviousCardEntry adapter, 
            DateTime? originalStartTime,
            DateTime? originalEndTime)
        {
            adapter.StartDateTime = new DateTime(2001, 1, 1, 2, 0, 0);
            adapter.EndDateTime = new DateTime(2001, 1, 1, 3, 0, 0);

            {
                Assert.AreEqual(originalStartTime, adapter.StartDateTime);
                Assert.AreEqual(originalEndTime, adapter.EndDateTime);
                Assert.IsNull(adapter.GetCycleStepEntry());
            }

            adapter.StartDateTime = null;
            adapter.EndDateTime = null;

            {
                Assert.AreEqual(originalStartTime, adapter.StartDateTime);
                Assert.AreEqual(originalEndTime, adapter.EndDateTime);
                Assert.IsNull(adapter.GetCycleStepEntry());
            }
        }

        [Test]
        public void ShouldCreateWithEntryWithNullEndTime()
        {
            UserShift previousShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateDayShift(), new DateTime(2010, 6, 10));
            UserShift currentShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateNightShift(), new DateTime(2010, 6, 10));

            CokerCardCycleStepEntry entry = new CokerCardCycleStepEntry(
                1001, 1, 2,
                new TimeEntry(new Time(10), previousShift.ShiftPatternId, previousShift.StartDate),
                null);
            CycleStepEntryDisplayAdapterForPreviousCardEntry adapter = 
                new CycleStepEntryDisplayAdapterForPreviousCardEntry(currentShift, entry);

            Assert.IsTrue(adapter.IsStartDateTimeReadOnly);
            Assert.IsFalse(adapter.IsEndDateTimeReadOnly);

            {
                Assert.AreEqual(new Time(10), new Time(adapter.StartDateTime.Value));
                Assert.AreEqual(null, adapter.EndDateTime);

                CokerCardCycleStepEntry newEntry = adapter.GetCycleStepEntry();
                Assert.IsNotNull(newEntry);
                Assert.AreEqual(new Time(10), newEntry.StartEntry.Time);
                Assert.AreEqual(previousShift.ShiftPatternId, newEntry.StartEntry.ShiftId);
                Assert.AreEqual(previousShift.StartDate, newEntry.StartEntry.ShiftStartDate);
                Assert.AreEqual(null, newEntry.EndEntry);
            }

            AssertWritableEndEntry(previousShift, currentShift, adapter);
        }

        [Test]
        public void ShouldCreateWithEntryWithEndTimeForCurrentShift()
        {
            UserShift previousShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateDayShift(), new DateTime(2010, 6, 10));
            UserShift currentShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateNightShift(), new DateTime(2010, 6, 10));

            CokerCardCycleStepEntry entry = new CokerCardCycleStepEntry(
                1001, 1, 2,
                new TimeEntry(new Time(10), previousShift.ShiftPatternId, previousShift.StartDate),
                new TimeEntry(new Time(11), currentShift.ShiftPatternId, currentShift.StartDate));
            CycleStepEntryDisplayAdapterForPreviousCardEntry adapter =
                new CycleStepEntryDisplayAdapterForPreviousCardEntry(currentShift, entry);

            Assert.IsTrue(adapter.IsStartDateTimeReadOnly);
            Assert.IsFalse(adapter.IsEndDateTimeReadOnly);

            {
                Assert.AreEqual(new Time(10), new Time(adapter.StartDateTime.Value));
                Assert.AreEqual(new Time(11), new Time(adapter.EndDateTime.Value));

                CokerCardCycleStepEntry newEntry = adapter.GetCycleStepEntry();
                Assert.IsNotNull(newEntry);
                Assert.AreEqual(new Time(10), newEntry.StartEntry.Time);
                Assert.AreEqual(previousShift.ShiftPatternId, newEntry.StartEntry.ShiftId);
                Assert.AreEqual(previousShift.StartDate, newEntry.StartEntry.ShiftStartDate);
                Assert.AreEqual(new Time(11), newEntry.EndEntry.Time);
                Assert.AreEqual(currentShift.ShiftPatternId, newEntry.EndEntry.ShiftId);
                Assert.AreEqual(currentShift.StartDate, newEntry.EndEntry.ShiftStartDate);
            }

            AssertWritableEndEntry(previousShift, currentShift, adapter);
        }

        private static void AssertWritableEndEntry(
            UserShift previousShift, UserShift currentShift, CycleStepEntryDisplayAdapterForPreviousCardEntry adapter)
        {
            adapter.StartDateTime = new DateTime(2001, 1, 1, 2, 0, 0);
            adapter.EndDateTime = new DateTime(2001, 1, 1, 3, 0, 0);

            {
                Assert.AreEqual(new Time(10), new Time(adapter.StartDateTime.Value));
                Assert.AreEqual(new Time(3), new Time(adapter.EndDateTime.Value));

                CokerCardCycleStepEntry newEntry = adapter.GetCycleStepEntry();
                Assert.IsNotNull(newEntry);
                Assert.AreEqual(new Time(10), newEntry.StartEntry.Time);
                Assert.AreEqual(previousShift.ShiftPatternId, newEntry.StartEntry.ShiftId);
                Assert.AreEqual(previousShift.StartDate, newEntry.StartEntry.ShiftStartDate);
                Assert.AreEqual(new Time(3), newEntry.EndEntry.Time);
                Assert.AreEqual(currentShift.ShiftPatternId, newEntry.EndEntry.ShiftId);
                Assert.AreEqual(currentShift.StartDate, newEntry.EndEntry.ShiftStartDate);
            }

            adapter.StartDateTime = new DateTime(2001, 1, 1, 2, 0, 0);
            adapter.EndDateTime = null;

            {
                Assert.AreEqual(new Time(10), new Time(adapter.StartDateTime.Value));
                Assert.AreEqual(null, adapter.EndDateTime);

                CokerCardCycleStepEntry newEntry = adapter.GetCycleStepEntry();
                Assert.IsNotNull(newEntry);
                Assert.AreEqual(new Time(10), newEntry.StartEntry.Time);
                Assert.AreEqual(previousShift.ShiftPatternId, newEntry.StartEntry.ShiftId);
                Assert.AreEqual(previousShift.StartDate, newEntry.StartEntry.ShiftStartDate);
                Assert.AreEqual(null, newEntry.EndEntry);
            }

            adapter.StartDateTime = null;
            adapter.EndDateTime = null;

            {
                Assert.AreEqual(new Time(10), new Time(adapter.StartDateTime.Value));
                Assert.AreEqual(null, adapter.EndDateTime);

                CokerCardCycleStepEntry newEntry = adapter.GetCycleStepEntry();
                Assert.IsNotNull(newEntry);
                Assert.AreEqual(new Time(10), newEntry.StartEntry.Time);
                Assert.AreEqual(previousShift.ShiftPatternId, newEntry.StartEntry.ShiftId);
                Assert.AreEqual(previousShift.StartDate, newEntry.StartEntry.ShiftStartDate);
                Assert.AreEqual(null, newEntry.EndEntry);
            }
        }
    }
}
