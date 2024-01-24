using System.Collections.Generic;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class CustomFieldEntryHistoryTest
    {
        [Test]
        public void ShouldParseFlattenedEntryHistoriesIntoRealCustomFieldEntryHistories()
        {
            FlattenedCustomFieldEntryHistory flattenedCustomFieldEntryHistory = new FlattenedCustomFieldEntryHistory(9, "^ID:23^CUSTOMFIELDNAME:Jimmy^FIELDENTRY:Fentry/-^%/^ID:24^CUSTOMFIELDNAME:Johnny^FIELDENTRY:Boo");
            List<CustomFieldEntryHistory> customFieldEntryHistories = flattenedCustomFieldEntryHistory.EntryHistories;

            Assert.AreEqual(2, customFieldEntryHistories.Count);

            CustomFieldEntryHistory customFieldEntryHistory1 = customFieldEntryHistories[0];
            Assert.AreEqual(9, customFieldEntryHistory1.HistoryId);
            Assert.AreEqual(23, customFieldEntryHistory1.Id);
            Assert.AreEqual("Jimmy", customFieldEntryHistory1.CustomFieldName);
            Assert.AreEqual("Fentry", customFieldEntryHistory1.FieldEntry);

            CustomFieldEntryHistory customFieldEntryHistory2 = customFieldEntryHistories[1];
            Assert.AreEqual(9, customFieldEntryHistory2.HistoryId);
            Assert.AreEqual(24, customFieldEntryHistory2.Id);
            Assert.AreEqual("Johnny", customFieldEntryHistory2.CustomFieldName);
            Assert.AreEqual("Boo", customFieldEntryHistory2.FieldEntry);
        }

        [Test]
        public void ShouldConvertRealCustomFieldEntryHistoriesIntoAFlattenedOne()
        {
            CustomFieldEntryHistory customFieldEntryHistory1 = new CustomFieldEntryHistory(10, 23, "Jimmy", "Fentry");
            CustomFieldEntryHistory customFieldEntryHistory2 = new CustomFieldEntryHistory(10, 24, "Johnny", "Boo");

            FlattenedCustomFieldEntryHistory flattenedCustomFieldEntryHistory = new FlattenedCustomFieldEntryHistory(10, new List<CustomFieldEntryHistory> {customFieldEntryHistory1, customFieldEntryHistory2});
            Assert.AreEqual(10, flattenedCustomFieldEntryHistory.HistoryId);
            Assert.AreEqual("^ID:23^CUSTOMFIELDNAME:Jimmy^FIELDENTRY:Fentry/-^%/^ID:24^CUSTOMFIELDNAME:Johnny^FIELDENTRY:Boo", flattenedCustomFieldEntryHistory.FlattenedEntryHistories);
        }

        [Test]
        public void ShouldConvertAndParseEntryHistoriesHavingANullId()
        {
            string flattenedEntryHistoriesString;

            {
                CustomFieldEntryHistory customFieldEntryHistory1 = new CustomFieldEntryHistory(9, null, "Jimmy", "Fentry");
                CustomFieldEntryHistory customFieldEntryHistory2 = new CustomFieldEntryHistory(9, 24, "Johnny", "Boo");

                FlattenedCustomFieldEntryHistory flattenedCustomFieldEntryHistory = new FlattenedCustomFieldEntryHistory(9, new List<CustomFieldEntryHistory> { customFieldEntryHistory1, customFieldEntryHistory2 });
                Assert.AreEqual(9, flattenedCustomFieldEntryHistory.HistoryId);
                Assert.AreEqual("^ID:^CUSTOMFIELDNAME:Jimmy^FIELDENTRY:Fentry/-^%/^ID:24^CUSTOMFIELDNAME:Johnny^FIELDENTRY:Boo", flattenedCustomFieldEntryHistory.FlattenedEntryHistories);

                flattenedEntryHistoriesString = flattenedCustomFieldEntryHistory.FlattenedEntryHistories;
            }

            {
                FlattenedCustomFieldEntryHistory freshFlattenedCustomFieldEntryHistory = new FlattenedCustomFieldEntryHistory(9, flattenedEntryHistoriesString);
                List<CustomFieldEntryHistory> customFieldEntryHistories = freshFlattenedCustomFieldEntryHistory.EntryHistories;

                Assert.AreEqual(2, customFieldEntryHistories.Count);

                CustomFieldEntryHistory customFieldEntryHistory1 = customFieldEntryHistories[0];
                Assert.AreEqual(9, customFieldEntryHistory1.HistoryId);
                Assert.AreEqual(null, customFieldEntryHistory1.Id);
                Assert.AreEqual("Jimmy", customFieldEntryHistory1.CustomFieldName);
                Assert.AreEqual("Fentry", customFieldEntryHistory1.FieldEntry);

                CustomFieldEntryHistory customFieldEntryHistory2 = customFieldEntryHistories[1];
                Assert.AreEqual(9, customFieldEntryHistory2.HistoryId);
                Assert.AreEqual(24, customFieldEntryHistory2.Id);
                Assert.AreEqual("Johnny", customFieldEntryHistory2.CustomFieldName);
                Assert.AreEqual("Boo", customFieldEntryHistory2.FieldEntry);
            }
        }
    }
}
