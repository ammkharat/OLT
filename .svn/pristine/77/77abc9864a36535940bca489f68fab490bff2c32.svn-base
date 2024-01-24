using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class TagDaoTest : AbstractDaoTest
    {
        private ITagDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ITagDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void GetTagByIdShouldReturnAtLeastOneRecordIfIdEqualsThree()
        {
            const long tagId = 3;
            TagInfo results = dao.QueryById(tagId);
            Assert.IsTrue(results.Name == "C3");
        }

        [Ignore] [Test]
        public void InsertedAndRetrieveShouldBeTheSame()
        {
            TagInfo tagToBeInserted = TagInfoFixture.CreateTagInfoWithoutId();
           

            dao.Insert(tagToBeInserted);
            TagInfo retrievedTag = dao.QueryById(tagToBeInserted.IdValue);

            Assert.AreEqual(tagToBeInserted, retrievedTag);
        }

        [Ignore] [Test]
        public void InsertWithDescriptionOverMaxLengthShouldTruncateToMaxLength()
        {
            string description = RandomStringOfLength(101);
            TagInfo tag = new TagInfo(SiteFixture.Sarnia().Id, "name", description, "units", false,1);
            dao.Insert(tag);

            Assert.AreEqual(description.Substring(0, 100), tag.Description);
            Assert.AreEqual(description.Substring(0, 100), dao.QueryById(tag.IdValue).Description);
        }

        [Ignore] [Test]
        public void ShouldBeAbleToQuerySoftDeletedTagInfo()
        {
            TagInfo tag = TagInfoFixture.CreateTagInfoWithoutId();
            dao.Insert(tag);
            dao.Remove(tag);

            TagInfo removedTag = dao.QueryById(tag.IdValue);

            Assert.AreEqual(tag.SiteId, removedTag.SiteId);
            Assert.AreEqual(tag.Name, removedTag.Name);
            Assert.AreEqual(tag.Description, removedTag.Description);
            Assert.AreEqual(tag.Units, removedTag.Units);
            Assert.AreEqual(true, removedTag.Deleted);
        }

        [Ignore] [Test]
        public void QueryBySiteIdAndPrefixCharacterIncludeDeletedShouldReturnDeleted()
        {
            long siteid = SiteFixture.Sarnia().IdValue;
            TagInfo tag = new TagInfo(siteid, "should come back name", "description", "units", false,1);
            dao.Insert(tag);
            dao.Remove(tag);

            List<TagInfo> results = dao.QueryBySiteIdAndPrefixCharacterIncludeDeleted(siteid, "should come back");
            TagInfo result = results.FindById(tag);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Deleted);
        }

        [Ignore] [Test]
        public void QueryTagInfoBySiteIdAndPrefixCharacterShouldReturnResultsPrefixedBy3()
        {
            List<TagInfo> actualTagInfoList = dao.QueryBySiteIdAndPrefixCharacterIncludeDeleted(SiteFixture.Sarnia().IdValue, "3");
            Assert.IsTrue(actualTagInfoList.Count > 0);
            foreach (TagInfo tagInfo in actualTagInfoList)
            {
                Assert.AreEqual(SiteFixture.Sarnia().Id, tagInfo.SiteId);
                Assert.IsTrue(tagInfo.Name.StartsWith("3"));
            }
        }

        [Ignore] [Test]
        public void QueryTagInfoBySiteIdAndPrefixCharacterShouldActuallyTakeTheSiteIdIntoAccountIMeanCallMeCrazyButThatJustMakesSense()
        {

            {
                TagInfo tag = new TagInfo(Site.SARNIA_ID, "TT1SARNIA", "Test Tag 1, Sarnia", "units", false,1);
                dao.Insert(tag);                
            }

            {
                TagInfo tag = new TagInfo(Site.SARNIA_ID, "TT2SARNIA", "Test Tag 2, Sarnia", "units", false,1);
                dao.Insert(tag);                
            }

            {
                TagInfo tag = new TagInfo(Site.OILSAND_ID, "TT1OILSANDS", "Test Tag 1, Oilsands", "units", false,1);
                dao.Insert(tag);                
            }

            {
                TagInfo tag = new TagInfo(Site.OILSAND_ID, "TT2OILSANDS", "Test Tag 2, Oilsands", "units", false,1);
                dao.Insert(tag);                
            }

            SearchField field = new SearchField("Name", "Name", FieldType.Text);
            SearchCriteria criteria = new SearchCriteria {Field = field, Value = "TT"};

            List<TagInfo> actualTagInfoList = dao.QueryTagInfoByFilter(SiteFixture.Sarnia(), criteria);
            
            Assert.IsTrue(actualTagInfoList.Count > 0);

            List<TagInfo> testTagInfos = actualTagInfoList.FindAll(
                t => t.Name.Equals("TT1SARNIA") || t.Name.Equals("TT2SARNIA") || t.Name.Equals("TT1OILSANDS") || t.Name.Equals("TT2OILSANDS"));

            foreach (TagInfo tagInfo in testTagInfos)
            {
                Assert.AreEqual(Site.SARNIA_ID, tagInfo.SiteId);                
            }
        }

        [Ignore] [Test]
        public void QueryTagInfoBySiteIdAndPrefixCharacterShouldEscapeUnderscores()
        {
            TagInfo tagUnderscores = new TagInfo(SiteFixture.Sarnia().Id, "1_2_3", "Underscores", "phat", false,1);
            TagInfo tagNoUnderscores = new TagInfo(SiteFixture.Sarnia().Id, "123", "Underscores", "phat", false,1);
            dao.Insert(tagUnderscores);
            dao.Insert(tagNoUnderscores);

            List<TagInfo> actualTagInfoList = dao.QueryBySiteIdAndPrefixCharacterIncludeDeleted(SiteFixture.Sarnia().IdValue, "1_");
            Assert.AreEqual(1, actualTagInfoList.Count);
            Assert.AreEqual(tagUnderscores, actualTagInfoList[0]);
            
            actualTagInfoList = dao.QueryBySiteIdAndPrefixCharacterIncludeDeleted(SiteFixture.Sarnia().IdValue, "1_2");
            Assert.AreEqual(1, actualTagInfoList.Count);
            Assert.AreEqual(tagUnderscores, actualTagInfoList[0]);
        }

        [Ignore] [Test]
        public void Replace()
        {
            const string prefixCharacter = "1_2_3";
            string searchPrefix = prefixCharacter.Replace("_", "[_]");
            Assert.AreEqual("1[_]2[_]3", searchPrefix);
        }

       

        [Ignore] [Test]
        public void QueryTagInfoBySiteIdAndPrefixCharacterShouldReturnCaseInsensitiveResults()
        {
            List<TagInfo> actualTagInfoList = dao.QueryBySiteIdAndPrefixCharacterIncludeDeleted(SiteFixture.Sarnia().IdValue, "a");
            Assert.IsTrue(actualTagInfoList.Count > 0);
            foreach (TagInfo tagInfo in actualTagInfoList)
            {
                Assert.AreEqual(SiteFixture.Sarnia().Id, tagInfo.SiteId);
                Assert.IsTrue(tagInfo.Name.StartsWith("a", true, CultureInfo.CurrentCulture));
            }
        }

         [Test]
        public void UpdateTagInfoFromPHDShouldUpdateDescriptionAndUnits()
        {
            TagInfo oltTagInfo = TagInfoFixture.CreateTagInfoWithoutId();         
            dao.Insert(oltTagInfo);
            TagInfo phd = new TagInfo(oltTagInfo.Id, oltTagInfo.SiteId, oltTagInfo.Name, "Description", "New Unit", false,oltTagInfo.ScadaConnectionInfoId);

            dao.Update(phd);

            TagInfo actual = dao.QueryById(oltTagInfo.IdValue);
            phd.Id = actual.Id;
            Assert.AreEqual(phd, actual);
        }

        [Ignore] [Test]
        public void UpdateTagInfoFromPHDWithDescriptionOverMaxLengthShouldTruncateToMaxLength()
        {
            TagInfo oltTagInfo = TagInfoFixture.CreateTagInfoWithoutId();
            dao.Insert(oltTagInfo);

            string description = RandomStringOfLength(100) + "?";
            TagInfo phdTagInfo = new TagInfo(oltTagInfo.Id, oltTagInfo.SiteId, oltTagInfo.Name, description, oltTagInfo.Units, false,oltTagInfo.ScadaConnectionInfoId);
            dao.Update(phdTagInfo);

            Assert.AreEqual(description.Substring(0, 100), phdTagInfo.Description);
            Assert.AreEqual(description.Substring(0, 100), dao.QueryById(phdTagInfo.IdValue).Description);
        }


        #region BuildQueryList Test

        private static SearchCriteria CreateSearchCriteria(SearchField field, string value)
        {
            SearchCriteria ret = new SearchCriteria {Field = field, Value = value};
            return ret;
        }


        [Ignore] [Test]
        public void ShouldBuildWhereStringForTextEqual()
        {
            SearchField field = new SearchField("Name", "Name", FieldType.Text);
            SearchCriteria testCriteria = CreateSearchCriteria(field, "A");

            const string expected = "Name LIKE '%A%'";
            string actual = TagDao.BuildQueryList(testCriteria);
            Assert.AreEqual(expected, actual);
        }

        [Ignore] [Test]
        public void ShouldBuildWhereStringForNumericEqual()
        {
            SearchField field = new SearchField("ID", "ID", FieldType.Numeric);
            SearchCriteria testCriteria = CreateSearchCriteria(field, "1");

            const string expected = "ID = 1";
            string actual = TagDao.BuildQueryList(testCriteria);
            Assert.AreEqual(expected, actual);
        }

        [Ignore] [Test]
        public void ShouldBuildWhereStringForDateTimeEqual()
        {
            SearchField field = new SearchField("EndDate", "EndDate", FieldType.DateTime);
            SearchCriteria testCriteria = CreateSearchCriteria(field, "1/1/2005");

            const string expected = "EndDate BETWEEN CONVERT(DATETIME, '1/1/2005 00:00:00) AND CONVERT(DATETIME, '1/1/2005 23:59:59',102)";
            string actual = TagDao.BuildQueryList(testCriteria);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        private static string RandomStringOfLength(int length)
        {
            StringBuilder stringBuilder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append("X");
            }
            return stringBuilder.ToString();
        }
    }
}