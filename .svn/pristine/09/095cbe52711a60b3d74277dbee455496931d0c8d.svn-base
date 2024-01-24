using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class DropdownValueDaoTest : AbstractDaoTest
    {
        private IDropdownValueDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IDropdownValueDao>();
        }

        protected override void Cleanup()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void QueryAllShouldOnlyGetUndeletedDropdownValues()
        {
            DropdownValue toInsertOnly = new DropdownValue(Site.MONTREAL_ID, "undeleted_key", "undeleted_value", 0);
            dao.Insert(toInsertOnly);
            DropdownValue toDelete = new DropdownValue(Site.MONTREAL_ID, "deleted_key", "deleted_value", 0);
            dao.Insert(toDelete);
            
            dao.Remove(toDelete);

            List<DropdownValue> DropdownValues = dao.QueryAll(Site.MONTREAL_ID);

            DropdownValue newlyQueriedDeletedValue = DropdownValues.Find(obj => obj.Id == toDelete.Id);
            DropdownValue newlyQueriedUndeletedValue = DropdownValues.Find(obj => obj.Id == toInsertOnly.Id);

            Assert.IsNull(newlyQueriedDeletedValue);
            Assert.AreEqual(toInsertOnly.Id, newlyQueriedUndeletedValue.Id);
        }

        [Ignore] [Test]
        public void QueryByKeyShouldReturnOnlyValuesWithThatKey()
        {
            String keyOne = "some_new_key";
            String keyTwo = "some_other_key";

            DropdownValue insertOnly = new DropdownValue(Site.MONTREAL_ID, keyOne, "undeleted_value", 0);
            dao.Insert(insertOnly);

            DropdownValue deletedValue = new DropdownValue(Site.MONTREAL_ID, keyOne, "deleted_value", 0);
            dao.Insert(deletedValue);
            dao.Remove(deletedValue);

            DropdownValue wrongKeyValue = new DropdownValue(Site.MONTREAL_ID, keyTwo, "deleted_value", 0);
            dao.Insert(wrongKeyValue);

            List<DropdownValue> DropdownValues = dao.QueryByKey(Site.MONTREAL_ID, keyOne);

            Assert.AreEqual(1, DropdownValues.Count);
            Assert.AreEqual(insertOnly.Id, DropdownValues[0].IdValue);
        }

        [Ignore] [Test]
        public void QueryByKeyShouldReturnValuesInOrderOfDisplay()
        {
            const string key = "some_silly_key";

            DropdownValue value1 = new DropdownValue(Site.MONTREAL_ID, key, "a", 1);
            dao.Insert(value1);
            DropdownValue value2 = new DropdownValue(Site.MONTREAL_ID, key, "b", 0);
            dao.Insert(value2);

            List<DropdownValue> dropdownValues = dao.QueryByKey(Site.MONTREAL_ID, key);

            Assert.AreEqual(2, dropdownValues.Count);
            Assert.AreEqual(value2.Id, dropdownValues[0].IdValue);
            Assert.AreEqual(value1.Id, dropdownValues[1].IdValue);
        }
    }
}