using System;
using System.Collections.Generic;
using System.ComponentModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    [TestFixture]
    public class CokerCardRowGroupTest
    {
        private readonly CycleStepEntryColumnKeyCollection columnKeys = new CycleStepEntryColumnKeyCollection();

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            columnKeys.Add(new CycleStepEntryColumnKey(1, false, "col1", 1));
            columnKeys.Add(new CycleStepEntryColumnKey(2, false, "col2", 2));
            columnKeys.Add(new CycleStepEntryColumnKey(3, false, "col2", 3));
        }

        [Test]
        public void ShouldValidateThatEndTimeHasCorrespondingStartTime()
        {
            {
                CokerCardRowGroup rowGroup = GetRowGroupForValidationTests();
                rowGroup.Rows[0].SetCycleStepEntryDateTime(columnKeys[1], new DateTime(2001, 1, 10, 12, 0, 0));
                rowGroup.Rows[1].SetCycleStepEntryDateTime(columnKeys[1], new DateTime(2001, 1, 10, 13, 0, 0));
                Assert.IsTrue(rowGroup.Validate());
            }
            {
                CokerCardRowGroup rowGroup = GetRowGroupForValidationTests();
                rowGroup.Rows[0].SetCycleStepEntryDateTime(columnKeys[1], null);
                rowGroup.Rows[1].SetCycleStepEntryDateTime(columnKeys[1], new DateTime(2001, 1, 10, 13, 0, 0));
                Assert.IsFalse(rowGroup.Validate());
            }
        }

        [Test]
        public void ShouldPermitStartTimeWithNoEndTimeInValidation()
        {
            {
                CokerCardRowGroup rowGroup = GetRowGroupForValidationTests();
                rowGroup.Rows[0].SetCycleStepEntryDateTime(columnKeys[1], new DateTime(2001, 1, 10, 12, 0, 0));
                rowGroup.Rows[1].SetCycleStepEntryDateTime(columnKeys[1], null);
                Assert.IsTrue(rowGroup.Validate());
            }
        }

        [Test]
        public void ShouldSetStartTimeOnNextCycleStepWhenSettingEndTimeOnACycleStep()
        {
            {
                CokerCardRowGroup rowGroup = GetRowGroupForValidationTests(null);
                PropertyChangeEventSubscriber eventSubscriber = new PropertyChangeEventSubscriber(rowGroup);

                DateTime newDateTime = new DateTime(2999, 3, 15, 6, 0, 0);
                rowGroup.Rows[1].SetCycleStepEntryDateTime(columnKeys[0], newDateTime);
                List<TimePair> expected = new List<TimePair> { new TimePair(null, 6), new TimePair(6, null), new TimePair(null, null) };
                AssertCycleStepEntries(expected, rowGroup);

                Assert.AreEqual(columnKeys[1].Key, eventSubscriber.StartRowChangedProperty);
                Assert.IsNull(eventSubscriber.EndRowChangedProperty);
            }
            {
                CokerCardRowGroup rowGroup = GetRowGroupForValidationTests(null);
                PropertyChangeEventSubscriber eventSubscriber = new PropertyChangeEventSubscriber(rowGroup);

                DateTime newDateTime = new DateTime(2999, 3, 15, 6, 0, 0);
                rowGroup.Rows[1].SetCycleStepEntryDateTime(columnKeys[1], newDateTime);
                List<TimePair> expected = new List<TimePair> { new TimePair(null, null), new TimePair(null, 6), new TimePair(6, null) };
                AssertCycleStepEntries(expected, rowGroup);

                Assert.AreEqual(columnKeys[2].Key, eventSubscriber.StartRowChangedProperty);
                Assert.IsNull(eventSubscriber.EndRowChangedProperty);
            }
        }

        [Test]
        public void ShouldNotSetStartTimeOnNextCycleStepIfItIsAlreadyFilledInWhenSettingEndTimeOnACycleStep()
        {
            {
                CokerCardRowGroup rowGroup = GetRowGroupForValidationTests(null);
                rowGroup.Rows[0].SetCycleStepEntryDateTime(columnKeys[1], new DateTime(2999, 3, 15, 7, 0, 0));
                PropertyChangeEventSubscriber eventSubscriber = new PropertyChangeEventSubscriber(rowGroup);

                DateTime newDateTime = new DateTime(2999, 3, 15, 6, 0, 0);
                rowGroup.Rows[1].SetCycleStepEntryDateTime(columnKeys[0], newDateTime);
                List<TimePair> expected = new List<TimePair> { new TimePair(null, 6), new TimePair(7, null), new TimePair(null, null) };
                AssertCycleStepEntries(expected, rowGroup);

                Assert.IsNull(eventSubscriber.StartRowChangedProperty);
                Assert.IsNull(eventSubscriber.EndRowChangedProperty);
            }
            {
                CokerCardRowGroup rowGroup = GetRowGroupForValidationTests(null);
                rowGroup.Rows[0].SetCycleStepEntryDateTime(columnKeys[2], new DateTime(2999, 3, 15, 7, 0, 0));
                PropertyChangeEventSubscriber eventSubscriber = new PropertyChangeEventSubscriber(rowGroup);

                DateTime newDateTime = new DateTime(2999, 3, 15, 6, 0, 0);
                rowGroup.Rows[1].SetCycleStepEntryDateTime(columnKeys[1], newDateTime);
                List<TimePair> expected = new List<TimePair> { new TimePair(null, null), new TimePair(null, 6), new TimePair(7, null) };
                AssertCycleStepEntries(expected, rowGroup);

                Assert.IsNull(eventSubscriber.StartRowChangedProperty);
                Assert.IsNull(eventSubscriber.EndRowChangedProperty);
            }
        }

        [Test]
        public void ShouldNotSetStartTimeOnNextCycleStepToNullWhenSettingEndTimeOnACycleStep()
        {
            {
                CokerCardRowGroup rowGroup = GetRowGroupForValidationTests(null);
                rowGroup.Rows[1].SetCycleStepEntryDateTime(columnKeys[0], new DateTime(2999, 3, 15, 6, 0, 0));
                rowGroup.Rows[0].SetCycleStepEntryDateTime(columnKeys[1], null);
                PropertyChangeEventSubscriber eventSubscriber = new PropertyChangeEventSubscriber(rowGroup);

                rowGroup.Rows[1].SetCycleStepEntryDateTime(columnKeys[0], null);
                List<TimePair> expected = new List<TimePair> { new TimePair(null, null), new TimePair(null, null), new TimePair(null, null) };
                AssertCycleStepEntries(expected, rowGroup);

                Assert.IsNull(eventSubscriber.StartRowChangedProperty);
                Assert.IsNull(eventSubscriber.EndRowChangedProperty);
            }
            {
                CokerCardRowGroup rowGroup = GetRowGroupForValidationTests(null);
                rowGroup.Rows[1].SetCycleStepEntryDateTime(columnKeys[0], new DateTime(2999, 3, 15, 6, 0, 0));
                rowGroup.Rows[0].SetCycleStepEntryDateTime(columnKeys[1], new DateTime(2999, 3, 15, 7, 0, 0));
                PropertyChangeEventSubscriber eventSubscriber = new PropertyChangeEventSubscriber(rowGroup);

                rowGroup.Rows[1].SetCycleStepEntryDateTime(columnKeys[0], null);
                List<TimePair> expected = new List<TimePair> { new TimePair(null, null), new TimePair(7, null), new TimePair(null, null) };
                AssertCycleStepEntries(expected, rowGroup);

                Assert.IsNull(eventSubscriber.StartRowChangedProperty);
                Assert.IsNull(eventSubscriber.EndRowChangedProperty);
            }
        }

        [Test]
        public void ShouldDoNothingWhenSettingEndTimeOnLastCycleStep()
        {
            {
                CokerCardRowGroup rowGroup = GetRowGroupForValidationTests(null);
                PropertyChangeEventSubscriber eventSubscriber = new PropertyChangeEventSubscriber(rowGroup);

                DateTime newDateTime = new DateTime(2999, 3, 15, 6, 0, 0);
                rowGroup.Rows[1].SetCycleStepEntryDateTime(columnKeys[2], newDateTime);
                List<TimePair> expected = new List<TimePair> { new TimePair(null, null), new TimePair(null, null), new TimePair(null, 6) };
                AssertCycleStepEntries(expected, rowGroup);

                Assert.IsNull(eventSubscriber.StartRowChangedProperty);
                Assert.IsNull(eventSubscriber.EndRowChangedProperty);
            }
        }

        private void AssertCycleStepEntries(List<TimePair> expected, CokerCardRowGroup rowGroup)
        {
            AssertAreEqual(expected[0].Start, rowGroup.Rows[0].GetCycleStepEntryDateTime(columnKeys[0]));
            AssertAreEqual(expected[0].End, rowGroup.Rows[1].GetCycleStepEntryDateTime(columnKeys[0]));
            AssertAreEqual(expected[1].Start, rowGroup.Rows[0].GetCycleStepEntryDateTime(columnKeys[1]));
            AssertAreEqual(expected[1].End, rowGroup.Rows[1].GetCycleStepEntryDateTime(columnKeys[1]));
            AssertAreEqual(expected[2].Start, rowGroup.Rows[0].GetCycleStepEntryDateTime(columnKeys[2]));
            AssertAreEqual(expected[2].End, rowGroup.Rows[1].GetCycleStepEntryDateTime(columnKeys[2]));
        }

        private static void AssertAreEqual(int? entry, DateTime? cycleStepEntryDateTime)
        {
            if (!entry.HasValue)
            {
                Assert.IsNull(cycleStepEntryDateTime);
            }
            else
            {
                Assert.IsNotNull(cycleStepEntryDateTime);
                Assert.AreEqual(entry.Value, cycleStepEntryDateTime.Value.Hour);
            }
        }

        private class PropertyChangeEventSubscriber
        {
            private string startRowChangedProperty;
            private string endRowChangedProperty;

            public PropertyChangeEventSubscriber(CokerCardRowGroup group)
            {
                group.Rows[0].PropertyChanged += StartRow_PropertyChanged;
                group.Rows[1].PropertyChanged += EndRow_PropertyChanged;
            }

            private void StartRow_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                startRowChangedProperty = e.PropertyName;
            }

            private void EndRow_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                endRowChangedProperty = e.PropertyName;
            }

            public string StartRowChangedProperty
            {
                get { return startRowChangedProperty; }
            }

            public string EndRowChangedProperty
            {
                get { return endRowChangedProperty; }
            }
        }

        private CokerCardRowGroup GetRowGroupForValidationTests()
        {
            TimeEntry startEntry = new TimeEntry(new Time(10), 1, new Date(2001, 1, 1));
            return GetRowGroupForValidationTests(startEntry);
        }

        private CokerCardRowGroup GetRowGroupForValidationTests(TimeEntry startEntry)
        {
            CokerCardRowGroup rowGroup = new CokerCardRowGroup(1, "test", columnKeys);
            foreach (CycleStepEntryColumnKey key in columnKeys)
            {
                rowGroup.AddAdapter(
                    key, 
                    new CycleStepEntryDisplayAdapterForCurrentCardEntry(
                        UserShiftFixture.CreateUserShift(), 
                        new CokerCardCycleStepEntry(
                            null, 1, key.CycleStepId,
                            startEntry, 
                            null)));
            }

            return rowGroup;
        }
    }
}
