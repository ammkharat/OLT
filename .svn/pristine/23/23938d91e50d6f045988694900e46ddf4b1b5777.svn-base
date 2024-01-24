using System.Collections.Generic;
using Com.Suncor.Olt.Common.Localization;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class CustomFieldEntryTest
    {
        [TearDown]
        public void TearDown()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();
        }

        [Test]
        public void ShouldSortOnDisplayOrder()
        {
            CustomFieldEntry entryWithDisplayOrderTwo = new CustomFieldEntry(1, null, "a", "a", null,null, 2, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null);
            CustomFieldEntry entryWithDisplayOrderOne = new CustomFieldEntry(2, null, "b", "b", null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null);

            List<CustomFieldEntry> entries = new List<CustomFieldEntry>
                                                           {
                                                               entryWithDisplayOrderTwo,
                                                               entryWithDisplayOrderOne
                                                           };

            entries.Sort();
            Assert.AreEqual(entryWithDisplayOrderOne, entries[0]);
            Assert.AreEqual(entryWithDisplayOrderTwo, entries[1]);
        }

        [Test]
        public void ShouldSetValueCorrectlyBasedOnType()
        {
            {
                CustomFieldEntry customFieldEntry = new CustomFieldEntry(1, null, "a", null, null,null, 1, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null);   //ayman action item reading
                customFieldEntry.SetValue("10,000.23");
                Assert.AreEqual(new decimal(10000.23), customFieldEntry.NumericFieldEntry);
            }

            {
                CustomFieldEntry customFieldEntry = new CustomFieldEntry(1, null, "a", null, null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null);
                customFieldEntry.SetValue("10,000.23");
                Assert.AreEqual(null, customFieldEntry.NumericFieldEntry);
                Assert.AreEqual("10,000.23", customFieldEntry.FieldEntry);
            }

            {
                CustomFieldEntry customFieldEntry = new CustomFieldEntry(1, null, "a", null, null,null, 1, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null);
                customFieldEntry.SetValue("");
                Assert.AreEqual(null, customFieldEntry.NumericFieldEntry);
            }

            CultureInfoTestHelper.SetFormatsForFrenchFromResourceFile();

            {
                CustomFieldEntry customFieldEntry = new CustomFieldEntry(1, null, "a", null, null,null, 1, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null);
                customFieldEntry.SetValue("1001,23");
                Assert.AreEqual(new decimal(1001.23), customFieldEntry.NumericFieldEntry);
            }
        }

        [Test]
        public void ShouldShowNumericValuesCorrectlyForCulture()
        {

            {
                CustomFieldEntry customFieldEntry = new CustomFieldEntry(1, null, "a", null,null, new decimal(1001.23), 1, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null);
                Assert.AreEqual("1001.23", customFieldEntry.FieldEntryForDisplay);
            }

            CultureInfoTestHelper.SetFormatsForFrenchFromResourceFile();

            {
                CustomFieldEntry customFieldEntry = new CustomFieldEntry(1, null, "a", null,null, new decimal(1001.23), 1, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null);
                Assert.AreEqual("1001,23", customFieldEntry.FieldEntryForDisplay);
            }
        }

        [Test]
        public void HistorySnapshotShouldUseTheDisplayValue()
        {
            CustomFieldEntry customFieldEntry = new CustomFieldEntry(1, null, "a", null,null, new decimal(1001.23), 1, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null);
            CustomFieldEntryHistory customFieldEntryHistory = customFieldEntry.TakeSnapshot();
            Assert.AreEqual("1001.23", customFieldEntryHistory.FieldEntry);
        }

        [Test]
        public void HistorySnapshotShouldCreateHistoryEvenForMissingCustomFieldEntries()
        {
            const long customFieldGroupId = 1;
            CustomField fieldA = new CustomField(1, "A", 0, customFieldGroupId, customFieldGroupId, null, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField fieldB = new CustomField(2, "B", 1, customFieldGroupId, customFieldGroupId, null, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField fieldC = new CustomField(3, "C", 2, customFieldGroupId, customFieldGroupId, null, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);

            CustomFieldEntry fieldEntryA = new CustomFieldEntry(fieldA) {FieldEntry = "A-value"};

            CustomFieldEntry fieldEntryC = new CustomFieldEntry(fieldC) {FieldEntry = "C-value"};

            List<CustomFieldEntryHistory> customFieldEntryHistories = CustomFieldEntry.TakeSnapshots(new List<CustomFieldEntry> {fieldEntryA, fieldEntryC}, new List<CustomField> {fieldA, fieldB, fieldC});

            Assert.AreEqual(3, customFieldEntryHistories.Count);
            Assert.IsTrue(customFieldEntryHistories.Exists(history => history.CustomFieldName == "A" && history.FieldEntry == "A-value"));
            Assert.IsTrue(customFieldEntryHistories.Exists(history => history.CustomFieldName == "B" && history.FieldEntry == null));
            Assert.IsTrue(customFieldEntryHistories.Exists(history => history.CustomFieldName == "C" && history.FieldEntry == "C-value"));
        }

        [Test]
        public void PadEntriesWithBlanksShouldAlsoSortAccordingToCustomFieldOrderAndIgnoreTheEntryOrder()
        {
            CustomField customField1 = new CustomField(1, "group1-field1", 0, 100, 100, 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField customField2 = new CustomField(2, "group1-field2", 1, 100, 100, 2, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);

            CustomField customField3 = new CustomField(3, "group2-field1", 0, 101, 101, 3, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField customField4 = new CustomField(4, "group2-field2", 1, 101, 101, 4, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);

            CustomFieldEntry entry1 = new CustomFieldEntry(customField1) {DisplayOrder = 4};

            CustomFieldEntry entry2 = new CustomFieldEntry(customField2) {DisplayOrder = 3};

            CustomFieldEntry entry4 = new CustomFieldEntry(customField4) {DisplayOrder = 2};

            List<CustomFieldEntry> paddedEntries = CustomFieldEntry.PadEntriesWithBlanks(new List<CustomField> {customField1, customField2, customField3, customField4}, new List<CustomFieldEntry> {entry1, entry2, entry4});
            Assert.AreEqual(4, paddedEntries.Count);

            Assert.AreEqual("group1-field1", paddedEntries[0].CustomFieldName);
            Assert.AreEqual(0, paddedEntries[0].DisplayOrder);

            Assert.AreEqual("group1-field2", paddedEntries[1].CustomFieldName);
            Assert.AreEqual(1, paddedEntries[1].DisplayOrder);

            Assert.AreEqual("group2-field1", paddedEntries[2].CustomFieldName);
            Assert.AreEqual(2, paddedEntries[2].DisplayOrder);

            Assert.AreEqual("group2-field2", paddedEntries[3].CustomFieldName);
            Assert.AreEqual(3, paddedEntries[3].DisplayOrder);
        }
    }
}
