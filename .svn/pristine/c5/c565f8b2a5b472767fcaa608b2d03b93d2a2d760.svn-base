using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    public class CokerCardRowGroupFillerTest
    {
        protected static void AssertEmptyReadOnlyEntry(CokerCardRowGroup rowGroup, CycleStepEntryColumnKey key)
        {
            Assert.AreEqual(null, rowGroup.Rows[0].GetCycleStepEntryDateTime(key));
            Assert.AreEqual(null, rowGroup.Rows[1].GetCycleStepEntryDateTime(key));
            Assert.IsTrue(rowGroup.Rows[0].IsReadOnlyCycleStepEntry(key));
            Assert.IsTrue(rowGroup.Rows[1].IsReadOnlyCycleStepEntry(key));
        }

        protected static void AssertTestAdapterEntry(CokerCardRowGroup rowGroup, CycleStepEntryColumnKey columnKey)
        {
            Assert.AreEqual(new Time(7).ToDateTime(), rowGroup.Rows[0].GetCycleStepEntryDateTime(columnKey));
            Assert.AreEqual(new Time(8).ToDateTime(), rowGroup.Rows[1].GetCycleStepEntryDateTime(columnKey));
            Assert.IsFalse(rowGroup.Rows[0].IsReadOnlyCycleStepEntry(columnKey));
            Assert.IsFalse(rowGroup.Rows[1].IsReadOnlyCycleStepEntry(columnKey));
        }

        protected class TestAdapter : CycleStepEntryDisplayAdapter
        {
            public TestAdapter() : this(100, null)
            {
            }

            public TestAdapter(long endEntryShift, Date endEntryShiftStartDate) :
                base(1000, 1000, 1000, new TimeEntry(new Time(7), 1000, null), new TimeEntry(new Time(8), endEntryShift, endEntryShiftStartDate))
            {
                
            }

            public override bool IsStartDateTimeReadOnly
            {
                get { return false; }
            }

            public override bool IsEndDateTimeReadOnly
            {
                get { return false; }
            }

            public override CokerCardCycleStepEntry GetCycleStepEntry()
            {
                return null;
            }
        }
    }
}
