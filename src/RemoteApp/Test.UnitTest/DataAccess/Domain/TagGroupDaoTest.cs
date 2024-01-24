using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class TagGroupDaoTest : AbstractDaoTest
    {
        private ITagGroupDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ITagGroupDao>();
        }

        protected override void Cleanup()
        {
        }

        #region IsNameUniqueToSiteTest

        private void IsNameUniqueToSiteTest(TagInfoGroup tagInfoGroup, bool expected)
        {
            string name = tagInfoGroup.Name;
            Site site = tagInfoGroup.Site;
            bool actual = dao.IsNameUniqueToSite(name, site);
            Assert.AreEqual(expected, actual);
        }

        [Ignore] [Test]
        public void ShouldReturnTrueWhenNameIsUniqueToSite()
        {
            TagInfoGroup nextTagInfoGroup = TagInfoGroupFixture.CreateNewSarniaTagInfoGroup();
            const bool expectedReturn = true;
            IsNameUniqueToSiteTest(nextTagInfoGroup, expectedReturn);
        }

        [Ignore] [Test]
        public void ShouldReturnFalseWhenNameIsNotUnique()
        {
            TagInfoGroup existingTagInfoGroup = TagInfoGroupFixture.GetExistingSarniaTagInfoGroup();
            const bool expectedReturn = false;
            IsNameUniqueToSiteTest(existingTagInfoGroup, expectedReturn);
        }

        #endregion

        [Ignore] [Test]
        public void ShouldInsertAndRetrieveData()
        {
            TagInfoGroup newTagInfoGroup = TagInfoGroupFixture.CreateNewSarniaTagInfoGroup();
            dao.Insert(newTagInfoGroup);
            TagInfoGroup queriedTagInfoGroup = dao.QueryById(newTagInfoGroup.IdValue);
            Assert.AreEqual(newTagInfoGroup, queriedTagInfoGroup);
        }

        #region Update Tests

        [Ignore] [Test]
        public void ShouldUpdateField()
        {
            const string newName = "New Name";
            TagInfoGroup expected = TagInfoGroupFixture.GetExistingSarniaTagInfoGroup();
            expected.Name = newName;
            dao.Update(expected);
            TagInfoGroup actual = dao.QueryById(expected.IdValue);
            Assert.AreEqual(expected, actual);
        }

        [Ignore] [Test]
        public void ShouldUpdateTagInfoList()
        {
            List<TagInfo> newTagInfoList = new List<TagInfo>();
            TagInfoGroup existingTagInfoGroup = TagInfoGroupFixture.GetExistingSarniaTagInfoGroup();
            existingTagInfoGroup.TagInfoList = newTagInfoList;
            dao.Update(existingTagInfoGroup);
            TagInfoGroup tagInfoGroupAfterUpdate = dao.QueryById(existingTagInfoGroup.IdValue);
            Assert.AreEqual(newTagInfoList, tagInfoGroupAfterUpdate.TagInfoList);
        }

        #endregion

        [Ignore] [Test]
        public void ShouldReturnTagInfoGroupBySite()
        {
            Site sarnia = SiteFixture.Sarnia();
            TagInfoGroup existingTagInfoGroup = TagInfoGroupFixture.GetExistingSarniaTagInfoGroup();
            List<TagInfoGroup> expectedList = new List<TagInfoGroup>{existingTagInfoGroup};
            List<TagInfoGroup> actualList = dao.QueryTagInfoGroupListBySite(sarnia);
            Assert.AreEqual(expectedList, actualList);
        }

        [Ignore] [Test]
        public void ShouldRemoveTagInfoListWhenRemovingTagInfoGroup()
        {
            TagInfoGroup existingTagInfoGroup = TagInfoGroupFixture.GetExistingSarniaTagInfoGroup();
            dao.Remove(existingTagInfoGroup);
            const string countSqlStatement = "SELECT COUNT(*) FROM [{0}] WHERE {1} = {2}";
            int actualTagInfoGroupCount = TestDataAccessUtil.ExecuteScalarExpression<int>(countSqlStatement, "TagGroup", "Id", existingTagInfoGroup.IdValue);
            int actualTagInfoListCount = TestDataAccessUtil.ExecuteScalarExpression<int>(countSqlStatement, "TagGroupAssociation", "TagGroupId", existingTagInfoGroup.IdValue);
            Assert.IsTrue(actualTagInfoGroupCount == 0);
            Assert.IsTrue(actualTagInfoListCount == 0);
        }
    }
}