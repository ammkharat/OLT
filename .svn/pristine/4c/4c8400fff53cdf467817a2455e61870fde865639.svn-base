using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    [TestFixture]
    public class CycleStepEntryDisplayAdapterForCurrentCardEntryTest
    {
        [Test]
        public void ShouldCreateWithNullEntry()
        {
            UserShift currentShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateNightShift(), new DateTime(2010, 6, 10));

            CycleStepEntryDisplayAdapterForCurrentCardEntry adapter =
                new CycleStepEntryDisplayAdapterForCurrentCardEntry(currentShift, 1, 2);

            Assert.IsFalse(adapter.IsStartDateTimeReadOnly);
            Assert.IsFalse(adapter.IsEndDateTimeReadOnly);

            {
                Assert.IsNull(adapter.StartDateTime);
                Assert.IsNull(adapter.EndDateTime);
                Assert.IsNull(adapter.GetCycleStepEntry());
            }

            AssertWritableAdapter(currentShift, adapter);
        }

        [Test]
        public void ShouldCreateWithEntry()
        {
            UserShift currentShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateNightShift(), new DateTime(2010, 6, 10));

            CokerCardCycleStepEntry entry = new CokerCardCycleStepEntry(
                1001, 1, 2,
                new TimeEntry(new Time(10), currentShift.ShiftPatternId, currentShift.StartDate),
                new TimeEntry(new Time(11), currentShift.ShiftPatternId, currentShift.StartDate));
            CycleStepEntryDisplayAdapterForCurrentCardEntry adapter =
                new CycleStepEntryDisplayAdapterForCurrentCardEntry(currentShift, entry);

            Assert.IsFalse(adapter.IsStartDateTimeReadOnly);
            Assert.IsFalse(adapter.IsEndDateTimeReadOnly);

            {
                Assert.AreEqual(new Time(10), new Time(adapter.StartDateTime.Value));
                Assert.AreEqual(new Time(11), new Time(adapter.EndDateTime.Value));

                CokerCardCycleStepEntry newEntry = adapter.GetCycleStepEntry();
                Assert.IsNotNull(newEntry);
                Assert.AreEqual(new Time(10), newEntry.StartEntry.Time);
                Assert.AreEqual(currentShift.ShiftPatternId, newEntry.StartEntry.ShiftId);
                Assert.AreEqual(currentShift.StartDate, newEntry.StartEntry.ShiftStartDate);
                Assert.AreEqual(new Time(11), newEntry.EndEntry.Time);
                Assert.AreEqual(currentShift.ShiftPatternId, newEntry.EndEntry.ShiftId);
                Assert.AreEqual(currentShift.StartDate, newEntry.EndEntry.ShiftStartDate);
            }

            AssertWritableAdapter(currentShift, adapter);
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
            CycleStepEntryDisplayAdapterForCurrentCardEntry adapter =
                new CycleStepEntryDisplayAdapterForCurrentCardEntry(currentShift, entry);

            Assert.IsFalse(adapter.IsStartDateTimeReadOnly);
            Assert.IsFalse(adapter.IsEndDateTimeReadOnly);

            {
                Assert.AreEqual(new Time(10), new Time(adapter.StartDateTime.Value));
                Assert.AreEqual(null, adapter.EndDateTime);

                CokerCardCycleStepEntry newEntry = adapter.GetCycleStepEntry();
                Assert.IsNotNull(newEntry);
                Assert.AreEqual(new Time(10), newEntry.StartEntry.Time);
                Assert.AreEqual(currentShift.ShiftPatternId, newEntry.StartEntry.ShiftId);
                Assert.AreEqual(currentShift.StartDate, newEntry.StartEntry.ShiftStartDate);
                Assert.IsNull(newEntry.EndEntry);
            }

            AssertWritableAdapter(currentShift, adapter);
        }

        private static void AssertWritableAdapter(UserShift currentShift, CycleStepEntryDisplayAdapterForCurrentCardEntry adapter)
        {
            adapter.StartDateTime = new DateTime(2001, 1, 1, 2, 0, 0);
            adapter.EndDateTime = new DateTime(2001, 1, 1, 3, 0, 0);

            {
                Assert.AreEqual(new Time(2), new Time(adapter.StartDateTime.Value));
                Assert.AreEqual(new Time(3), new Time(adapter.EndDateTime.Value));

                CokerCardCycleStepEntry newEntry = adapter.GetCycleStepEntry();
                Assert.IsNotNull(newEntry);
                Assert.AreEqual(new Time(2), newEntry.StartEntry.Time);
                Assert.AreEqual(currentShift.ShiftPatternId, newEntry.StartEntry.ShiftId);
                Assert.AreEqual(currentShift.StartDate, newEntry.StartEntry.ShiftStartDate);
                Assert.AreEqual(new Time(3), newEntry.EndEntry.Time);
                Assert.AreEqual(currentShift.ShiftPatternId, newEntry.EndEntry.ShiftId);
                Assert.AreEqual(currentShift.StartDate, newEntry.EndEntry.ShiftStartDate);
            }

            adapter.StartDateTime = null;
            adapter.EndDateTime = new DateTime(2001, 1, 1, 3, 0, 0);

            {
                Assert.IsNull(adapter.StartDateTime);
                Assert.AreEqual(new Time(3), new Time(adapter.EndDateTime.Value));
                Assert.IsNull(adapter.GetCycleStepEntry());
            }

            adapter.StartDateTime = new DateTime(2001, 1, 1, 2, 0, 0);
            adapter.EndDateTime = null;

            {
                Assert.AreEqual(new Time(2), new Time(adapter.StartDateTime.Value));
                Assert.IsNull(adapter.EndDateTime);

                CokerCardCycleStepEntry newEntry = adapter.GetCycleStepEntry();
                Assert.IsNotNull(newEntry);
                Assert.AreEqual(new Time(2), newEntry.StartEntry.Time);
                Assert.AreEqual(currentShift.ShiftPatternId, newEntry.StartEntry.ShiftId);
                Assert.AreEqual(currentShift.StartDate, newEntry.StartEntry.ShiftStartDate);
                Assert.AreEqual(null, newEntry.EndEntry);
            }

            adapter.StartDateTime = null;
            adapter.EndDateTime = null;

            {
                Assert.IsNull(adapter.StartDateTime);
                Assert.IsNull(adapter.EndDateTime);
                Assert.IsNull(adapter.GetCycleStepEntry());
            }
        }

        [Test]
        public void ShouldCreateWithEntryWithEndTimeForNextShift()
        {
            UserShift currentShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateNightShift(), new DateTime(2010, 6, 10));
            UserShift nextShift = UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateDayShift(), new DateTime(2010, 6, 11));

            CokerCardCycleStepEntry entry = new CokerCardCycleStepEntry(
                1001, 1, 2,
                new TimeEntry(new Time(10), currentShift.ShiftPatternId, currentShift.StartDate),
                new TimeEntry(new Time(11), nextShift.ShiftPatternId, nextShift.StartDate));
            CycleStepEntryDisplayAdapterForCurrentCardEntry adapter =
                new CycleStepEntryDisplayAdapterForCurrentCardEntry(currentShift, entry);

            Assert.IsFalse(adapter.IsStartDateTimeReadOnly);
            Assert.IsTrue(adapter.IsEndDateTimeReadOnly);

            {
                Assert.AreEqual(new Time(10), new Time(adapter.StartDateTime.Value));
                Assert.AreEqual(new Time(11), new Time(adapter.EndDateTime.Value));

                CokerCardCycleStepEntry newEntry = adapter.GetCycleStepEntry();
                Assert.IsNotNull(newEntry);
                Assert.AreEqual(new Time(10), newEntry.StartEntry.Time);
                Assert.AreEqual(currentShift.ShiftPatternId, newEntry.StartEntry.ShiftId);
                Assert.AreEqual(currentShift.StartDate, newEntry.StartEntry.ShiftStartDate);
                Assert.AreEqual(new Time(11), newEntry.EndEntry.Time);
                Assert.AreEqual(nextShift.ShiftPatternId, newEntry.EndEntry.ShiftId);
                Assert.AreEqual(nextShift.StartDate, newEntry.EndEntry.ShiftStartDate);
            }

            adapter.StartDateTime = new DateTime(2001, 1, 1, 2, 0, 0);
            adapter.EndDateTime = new DateTime(2001, 1, 1, 3, 0, 0);

            {
                Assert.AreEqual(new Time(2), new Time(adapter.StartDateTime.Value));
                Assert.AreEqual(new Time(11), new Time(adapter.EndDateTime.Value));

                CokerCardCycleStepEntry newEntry = adapter.GetCycleStepEntry();
                Assert.IsNotNull(newEntry);
                Assert.AreEqual(new Time(2), newEntry.StartEntry.Time);
                Assert.AreEqual(currentShift.ShiftPatternId, newEntry.StartEntry.ShiftId);
                Assert.AreEqual(currentShift.StartDate, newEntry.StartEntry.ShiftStartDate);
                Assert.AreEqual(new Time(11), newEntry.EndEntry.Time);
                Assert.AreEqual(nextShift.ShiftPatternId, newEntry.EndEntry.ShiftId);
                Assert.AreEqual(nextShift.StartDate, newEntry.EndEntry.ShiftStartDate);
            }

            adapter.StartDateTime = null;
            adapter.EndDateTime = new DateTime(2001, 1, 1, 3, 0, 0);

            {
                Assert.IsNull(adapter.StartDateTime);
                Assert.AreEqual(new Time(11), new Time(adapter.EndDateTime.Value));
                Assert.IsNull(adapter.GetCycleStepEntry());
            }

            adapter.StartDateTime = new DateTime(2001, 1, 1, 2, 0, 0);
            adapter.EndDateTime = null;

            {
                Assert.AreEqual(new Time(2), new Time(adapter.StartDateTime.Value));
                Assert.AreEqual(new Time(11), new Time(adapter.EndDateTime.Value));

                CokerCardCycleStepEntry newEntry = adapter.GetCycleStepEntry();
                Assert.IsNotNull(newEntry);
                Assert.AreEqual(new Time(2), newEntry.StartEntry.Time);
                Assert.AreEqual(currentShift.ShiftPatternId, newEntry.StartEntry.ShiftId);
                Assert.AreEqual(currentShift.StartDate, newEntry.StartEntry.ShiftStartDate);
                Assert.AreEqual(new Time(11), newEntry.EndEntry.Time);
                Assert.AreEqual(nextShift.ShiftPatternId, newEntry.EndEntry.ShiftId);
                Assert.AreEqual(nextShift.StartDate, newEntry.EndEntry.ShiftStartDate);
            }

            adapter.StartDateTime = null;
            adapter.EndDateTime = null;

            {
                Assert.IsNull(adapter.StartDateTime);
                Assert.AreEqual(new Time(11), new Time(adapter.EndDateTime.Value));
                Assert.IsNull(adapter.GetCycleStepEntry());
            }
        }
    }
}
