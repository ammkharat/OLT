using System;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class LogCustomFieldEntryDaoTest : AbstractDaoTest
    {
        private ILogCustomFieldEntryDao dao;
        private ILogDao logDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ILogCustomFieldEntryDao>();
            logDao = DaoRegistry.GetDao<ILogDao>();
            Clock.Freeze();
        }

        protected override void Cleanup()
        {
            Clock.UnFreeze();
        }

        [Ignore] [Test]
        public void ShouldInsertAndQueryByLogId()
        {
            Log log = logDao.Insert(LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp());

            CustomFieldEntry fieldEntry = new CustomFieldEntry(
                null,
                CustomFieldFixture.CustomFieldExistingInDatabase1().IdValue,
                "field name",
                "user's entry",
                null,null,
                1,
                CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null);

            CustomFieldEntry inserted = dao.Insert(fieldEntry, log.IdValue);

            List<CustomFieldEntry> entries = dao.QueryByLogId(log.IdValue);
            CustomFieldEntry retrievedEntry = entries.FindById(inserted);

            Assert.AreEqual(inserted.CustomFieldName, retrievedEntry.CustomFieldName);
            Assert.AreEqual(inserted.FieldEntry, retrievedEntry.FieldEntry);
            Assert.AreEqual(inserted.DisplayOrder, retrievedEntry.DisplayOrder);
        }

        [Ignore] [Test]
        public void ShouldInsertAndUpdateNumericFieldValue()
        {
            Log log = logDao.Insert(LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp());

            CustomFieldEntry fieldEntry = new CustomFieldEntry(
                null,
                CustomFieldFixture.CustomFieldExistingInDatabase1().IdValue,
                "field name",
                null,null,
                new decimal(123.456),
                1,
                CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null);

            CustomFieldEntry inserted = dao.Insert(fieldEntry, log.IdValue);

            {
                List<CustomFieldEntry> entries = dao.QueryByLogId(log.IdValue);
                CustomFieldEntry retrievedEntry = entries.FindById(inserted);

                Assert.AreEqual(inserted.CustomFieldName, retrievedEntry.CustomFieldName);
                Assert.AreEqual(inserted.NumericFieldEntry, retrievedEntry.NumericFieldEntry);
                Assert.AreEqual(inserted.DisplayOrder, retrievedEntry.DisplayOrder);
            }

            {
                inserted.NumericFieldEntry = new decimal(456.7891);
                dao.Update(inserted);

                List<CustomFieldEntry> entries = dao.QueryByLogId(log.IdValue);
                CustomFieldEntry retrievedEntry = entries.FindById(inserted);
                Assert.AreEqual(inserted.NumericFieldEntry, retrievedEntry.NumericFieldEntry);
            }
        }

        // This next test would normally be in CustomFieldEntryTest, but there's something about the way that the decimal value is being
        // created when pulled out of the db that I can't replicate with the decimal constructors. 
        [Ignore] [Test] 
        public void FieldEntryForDisplayShouldShowNumericValuesWithoutTrailingZeros()
        {
            Log log = logDao.Insert(LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp());

            CustomFieldEntry fieldEntry = new CustomFieldEntry(
                null,
                CustomFieldFixture.CustomFieldExistingInDatabase1().IdValue,
                "field name",
                null,null,
                new decimal(123456.7891),
                1,
                CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null);

            CustomFieldEntry inserted = dao.Insert(fieldEntry, log.IdValue);
            List<CustomFieldEntry> entries = dao.QueryByLogId(log.IdValue);
            CustomFieldEntry retrievedEntry = entries.FindById(inserted);

            Assert.AreEqual("123456.7891", retrievedEntry.FieldEntryForDisplay);
        }

        [Ignore] [Test]
        public void ShouldQueryNonnumericCustomFieldEntries()
        {
            Clock.Now = new DateTime(2013, 2, 1, 15, 0, 0);

            ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift(Clock.Now);
            Log log = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp(shiftPattern, Clock.Now);
            log.WorkAssignment = WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData();
            logDao.Insert(log);

            CustomField customField1 = CustomFieldFixture.CustomFieldExistingInDatabase1();
            CustomField customField2 = CustomFieldFixture.CustomFieldExistingInDatabase2();
            const long nonexistentCustomFieldId = -3;

            CustomFieldEntry fieldEntry1 = new CustomFieldEntry(
                null,
                customField1.IdValue,
                "field name",
                "user's entry",
                null,null,
                1,
                CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null);

            CustomFieldEntry fieldEntry2 = new CustomFieldEntry(
                null,
                customField2.IdValue,
                "field name",
                null,null,
                3,
                1,
                CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null);

            CustomFieldEntry inserted1 = dao.Insert(fieldEntry1, log.IdValue);
            CustomFieldEntry inserted2 = dao.Insert(fieldEntry2, log.IdValue);

            {
                List<NonnumericCustomFieldEntryDTO> results = dao.QueryNonnumericCustomFieldEntriesForLogs(customField1.IdValue, log.WorkAssignment.IdValue, SiteFixture.Sarnia(), new DateRange(Clock.Now.AddDays(-1).ToDate(), Clock.Now.AddDays(1).ToDate()));
                Assert.AreEqual(1, results.Count);
                Assert.AreEqual(inserted1.IdValue, results[0].GetId());
            }

            {
                List<NonnumericCustomFieldEntryDTO> results = dao.QueryNonnumericCustomFieldEntriesForLogs(nonexistentCustomFieldId, log.WorkAssignment.IdValue, SiteFixture.Sarnia(), new DateRange(Clock.Now.AddDays(-1).ToDate(), Clock.Now.AddDays(1).ToDate()));
                Assert.AreEqual(0, results.Count);
            }

            {
                const long nonexistentWorkAssignmentId = -30;
                List<NonnumericCustomFieldEntryDTO> results = dao.QueryNonnumericCustomFieldEntriesForLogs(customField1.IdValue, nonexistentWorkAssignmentId, SiteFixture.Sarnia(), new DateRange(Clock.Now.AddDays(-1).ToDate(), Clock.Now.AddDays(1).ToDate()));
                Assert.AreEqual(0, results.Count);
            }

            {
                Date wrongStartDate = new Date(2001, 1, 1);
                Date wrongEndDate = new Date(2002, 1, 1);
                List<NonnumericCustomFieldEntryDTO> results = dao.QueryNonnumericCustomFieldEntriesForLogs(customField1.IdValue, log.WorkAssignment.IdValue, SiteFixture.Sarnia(), new DateRange(wrongStartDate, wrongEndDate));
                Assert.AreEqual(0, results.Count);
            }
        }


    }
}
