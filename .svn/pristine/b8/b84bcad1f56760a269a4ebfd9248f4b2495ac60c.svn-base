using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using System.Collections.Generic;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class SummaryLogCustomFieldEntryDaoTest : AbstractDaoTest
    {
        private ISummaryLogCustomFieldEntryDao dao;
        private ISummaryLogDao summaryLogDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ISummaryLogCustomFieldEntryDao>();
            summaryLogDao = DaoRegistry.GetDao<ISummaryLogDao>();
        }

        protected override void Cleanup()
        {            
        }

        [Ignore] [Test]
        public void ShouldInsertAndQueryBySummaryLogId()
        {
            SummaryLog summaryLog = SummaryLogFixture.CreateSummaryLogItemGoofySarnia();
            summaryLog = summaryLogDao.Insert(summaryLog);

            CustomFieldEntry fieldEntry = new CustomFieldEntry(
                null,
                CustomFieldFixture.CustomFieldExistingInDatabase1().IdValue,
                "field name",
                "user's entry",
                null,null,
                1,
                CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null);

            CustomFieldEntry inserted = dao.Insert(fieldEntry, summaryLog.IdValue);

            List<CustomFieldEntry> entries = dao.QueryBySummaryLogId(summaryLog.IdValue);
            CustomFieldEntry retrievedEntry = entries.FindById(inserted);

            Assert.AreEqual(inserted.CustomFieldName, retrievedEntry.CustomFieldName);
            Assert.AreEqual(inserted.FieldEntry, retrievedEntry.FieldEntry);
            Assert.AreEqual(inserted.DisplayOrder, retrievedEntry.DisplayOrder);
        }
    }
}
