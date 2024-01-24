using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class TagServiceTest
    {
        private ILabAlertDefinitionService mockLabAlertDefinitionService;
        private IRestrictionDefinitionService mockRestrictionDefinitionService;
        private ITagDao mockTagDao;
        private ITargetDefinitionService mockTargetDefinitionService;
        private TagService tagService;

        [SetUp]
        public void SetUp()
        {
            DaoRegistry.Clear();
            mockTagDao = MockRepository.GenerateMock<ITagDao>();
            DaoRegistry.RegisterDaoFor(mockTagDao);
            mockTargetDefinitionService = MockRepository.GenerateStub<ITargetDefinitionService>();
            mockRestrictionDefinitionService = MockRepository.GenerateStub<IRestrictionDefinitionService>();
            mockLabAlertDefinitionService = MockRepository.GenerateStub<ILabAlertDefinitionService>();
            tagService = new TagService(mockTargetDefinitionService, mockRestrictionDefinitionService,
                mockLabAlertDefinitionService);
        }

        [Ignore] [Test]
        public void ShouldIgnoreAlreadyRemovedTags_NoNmock()
        {
            const string prefix = "ABC";
            var site = SiteFixture.Sarnia();

            var tagDao = new TestTagDao();
            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor((ITagDao) tagDao);

            tagDao.QueryBySiteIdAndPrefixCharacterResult.Add(new TagInfo(site.Id, "existing 1", "d1", "u1", true, null));
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Add(new TagInfo(site.Id, "existing 2", "d2", "u2", true, null));
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Add(new TagInfo(site.Id, "existing 3", "d3", "u3", true, null));

            var tagInfoList = new List<TagInfo>();

/*
            Stub.On(mockTargetDefinitionService);
            Stub.On(mockRestrictionDefinitionService);
            Stub.On(mockLabAlertDefinitionService);
*/

            var service = new TagService(mockTargetDefinitionService, mockRestrictionDefinitionService,
                mockLabAlertDefinitionService);
            service.UpdatePlantHistorianTagInfoList(site, prefix, tagInfoList);

            Assert.AreEqual(0, tagDao.InsertedTags.Count);
            Assert.AreEqual(0, tagDao.UpdatedTags.Count);
            Assert.AreEqual(0, tagDao.RemovedTags.Count);
        }

        [Ignore] [Test]
        public void ShouldInsertNewPlantHistorianTagsIntoLocalDatabase()
        {
            var site = SiteFixture.Sarnia();
            const string tagPrefix = "s";
            var phdTagInfoList = TagInfoFixture.CreatePHDTagInfoList(site, 10,3);
            var newTagInfo = new TagInfo(site.Id, "SomeTagName", "Some Description", "MyUnits", false, null);
            phdTagInfoList.Add(newTagInfo);

            mockTagDao.Expect(m => m.Insert(null)).IgnoreArguments().Repeat.Any();
            mockTagDao.Stub(m => m.QueryBySiteIdAndPrefixCharacterIncludeDeleted(site.IdValue, tagPrefix))
                .Return(new List<TagInfo>());
            tagService.UpdatePlantHistorianTagInfoList(site, tagPrefix, phdTagInfoList);
            mockTagDao.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldInsert_NoNmock()
        {
            const string prefix = "ABC";
            var site = SiteFixture.Sarnia();

            var tagDao = new TestTagDao();
            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor<ITagDao>(tagDao);

            var tag1 = new TagInfo(site.Id, "existing 1", "d1", "u1", false, null);
            var tag2 = new TagInfo(site.Id, "existing 2", "d2", "u2", false, null);
            var tag3 = new TagInfo(site.Id, "existing 3", "d3", "u3", false, null);
            var tags = tagDao.QueryBySiteIdAndPrefixCharacterResult;
            tags.Clear();
            tags.Add(tag1);
            tags.Add(tag2);
            tags.Add(tag3);

            var tagInfoList = new List<TagInfo>
            {
                tags[0],
                tags[1],
                tags[2],
                new TagInfo(site.Id, "tag name", "tag description", "some units", false, null)
            };

            var service = new TagService(mockTargetDefinitionService, mockRestrictionDefinitionService,
                mockLabAlertDefinitionService);
            service.UpdatePlantHistorianTagInfoList(site, prefix, tagInfoList);

            Assert.AreEqual(1, tagDao.InsertedTags.Count);
            Assert.AreEqual("tag name", tagDao.InsertedTags[0].Name);
            Assert.AreEqual("tag description", tagDao.InsertedTags[0].Description);
            Assert.AreEqual("some units", tagDao.InsertedTags[0].Units);
            Assert.AreEqual(0, tagDao.UpdatedTags.Count);
            Assert.AreEqual(0, tagDao.RemovedTags.Count);
        }

        [Ignore] [Test]
        public void ShouldMarkDeletedPlantHistorianTagsAsDeletedInLocalDatabase()
        {
            var site = SiteFixture.Sarnia();
            const string tagPrefix = "s";
            var localTagInfoList = TagInfoFixture.CreatePHDTagInfoList(site, 1,3);
            var tagDeletedInPHD = localTagInfoList[0];

            mockTagDao.Expect(m => m.QueryBySiteIdAndPrefixCharacterIncludeDeleted(site.IdValue, tagPrefix))
                .Return(localTagInfoList);
            mockTagDao.Expect(m => m.Remove(tagDeletedInPHD));

            mockTargetDefinitionService.Expect(m => m.UpdateStatusForInvalidTag(tagDeletedInPHD, site));
            mockRestrictionDefinitionService.Expect(m => m.UpdateStatusForInvalidTag(tagDeletedInPHD, site));
            mockLabAlertDefinitionService.Expect(m => m.UpdateStatusForInvalidTag(tagDeletedInPHD, site));

            tagService.UpdatePlantHistorianTagInfoList(site, tagPrefix, new List<TagInfo>(0));

            mockTagDao.VerifyAllExpectations();
            mockTargetDefinitionService.VerifyAllExpectations();
            mockRestrictionDefinitionService.VerifyAllExpectations();
            mockLabAlertDefinitionService.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldRemove_NoNmock()
        {
            const string prefix = "ABC";
            var site = SiteFixture.Sarnia();

            var tagDao = new TestTagDao();
            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor((ITagDao) tagDao);

            var matchingExistingTag = new TagInfo(site.Id, "tag name", "tag description", "old units", false, null);
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Clear();
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Add(new TagInfo(site.Id, "existing 1", "d1", "u1", false, null));
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Add(new TagInfo(site.Id, "existing 2", "d2", "u2", false, null));
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Add(new TagInfo(site.Id, "existing 3", "d3", "u3", false, null));
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Add(matchingExistingTag);

            var tagInfoList = new List<TagInfo>
            {
                tagDao.QueryBySiteIdAndPrefixCharacterResult[0],
                tagDao.QueryBySiteIdAndPrefixCharacterResult[1],
                tagDao.QueryBySiteIdAndPrefixCharacterResult[2]
            };

/*
            Stub.On(mockTargetDefinitionService);
            Stub.On(mockRestrictionDefinitionService);
            Stub.On(mockLabAlertDefinitionService);
*/

            var service = new TagService(mockTargetDefinitionService, mockRestrictionDefinitionService,
                mockLabAlertDefinitionService);
            service.UpdatePlantHistorianTagInfoList(site, prefix, tagInfoList);

            Assert.AreEqual(0, tagDao.InsertedTags.Count);
            Assert.AreEqual(0, tagDao.UpdatedTags.Count);
            Assert.AreEqual(1, tagDao.RemovedTags.Count);
            Assert.AreEqual("tag name", tagDao.RemovedTags[0].Name);
        }

        [Ignore] [Test]
        [ExpectedException(typeof (TagSchedulerException))]
        public void ShouldThrowExceptionIfSiteDoesNotMatchSiteAssociatedWithTag()
        {
            var site = SiteFixture.Denver();
            var mismatchedSite = SiteFixture.SiteWideServices();
            const string tagPrefix = "s";
            var phdTagInfoList = TagInfoFixture.CreatePHDTagInfoList(mismatchedSite, 1,2);
            tagService.UpdatePlantHistorianTagInfoList(site, tagPrefix, phdTagInfoList);

            mockTagDao.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldUnMarkRestoredPlantHistorianTagsThatWereOnceDeletedInLocalDatabase()
        {
            const string tagPrefix = "s";
            // delete:
            var site = SiteFixture.Sarnia();
            var localTagInfoList = TagInfoFixture.CreatePHDTagInfoList(site, 1,3);
            var tagDeletedInPHD = localTagInfoList[0];

            mockTagDao.Expect(m => m.QueryBySiteIdAndPrefixCharacterIncludeDeleted(site.IdValue, tagPrefix))
                .Return(localTagInfoList);
            mockTagDao.Expect(m => m.Remove(tagDeletedInPHD));

            mockTargetDefinitionService.Expect(m => m.UpdateStatusForInvalidTag(tagDeletedInPHD, site));
            mockRestrictionDefinitionService.Expect(m => m.UpdateStatusForInvalidTag(tagDeletedInPHD, site));
            mockLabAlertDefinitionService.Expect(m => m.UpdateStatusForInvalidTag(tagDeletedInPHD, site));

            tagService.UpdatePlantHistorianTagInfoList(site, tagPrefix, new List<TagInfo>(0));

            // restore:
            var phdTagInfoListWithRestoredTag = new List<TagInfo> {tagDeletedInPHD};
            var restoredTag = phdTagInfoListWithRestoredTag[0];
            mockTagDao.Stub(m => m.QueryBySiteIdAndPrefixCharacterIncludeDeleted(-99, null))
                .IgnoreArguments()
                .Return(phdTagInfoListWithRestoredTag);
            tagService.UpdatePlantHistorianTagInfoList(site, tagPrefix, phdTagInfoListWithRestoredTag);

            mockTagDao.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldUnremove_NoNmock()
        {
            const string prefix = "ABC";
            var site = SiteFixture.Sarnia();

            var tagDao = new TestTagDao();
            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor((ITagDao) tagDao);

            tagDao.QueryBySiteIdAndPrefixCharacterResult.Clear();
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Add(new TagInfo(site.Id, "existing 1", "d1", "u1", true, null));
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Add(new TagInfo(site.Id, "existing 2", "d2", "u2", true, null));
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Add(new TagInfo(site.Id, "existing 3", "d3", "u3", true, null));

            var tagInfoList = new List<TagInfo>
            {
                tagDao.QueryBySiteIdAndPrefixCharacterResult[0],
                tagDao.QueryBySiteIdAndPrefixCharacterResult[1],
                tagDao.QueryBySiteIdAndPrefixCharacterResult[2]
            };

/*
            Stub.On(mockTargetDefinitionService);
            Stub.On(mockRestrictionDefinitionService);
            Stub.On(mockLabAlertDefinitionService);
*/

            var service = new TagService(mockTargetDefinitionService, mockRestrictionDefinitionService,
                mockLabAlertDefinitionService);
            service.UpdatePlantHistorianTagInfoList(site, prefix, tagInfoList);

            Assert.AreEqual(0, tagDao.InsertedTags.Count);
            Assert.AreEqual(3, tagDao.UpdatedTags.Count);
            Assert.AreEqual("existing 1", tagDao.UpdatedTags[0].Name);
            Assert.AreEqual("existing 2", tagDao.UpdatedTags[1].Name);
            Assert.AreEqual("existing 3", tagDao.UpdatedTags[2].Name);
            Assert.AreEqual(0, tagDao.RemovedTags.Count);
        }

        [Ignore] [Test]
        public void ShouldUpdateChangedPlantHistorianTagInfoWhenDescriptionChanges()
        {
            var site = SiteFixture.Sarnia();
            const string tagPrefix = "s";
            var phdTagInfoList = TagInfoFixture.CreatePHDTagInfoList(site, 10,3);
            var tagInfo = phdTagInfoList[0];
            var changedTagInfo = new TagInfo(tagInfo.IdValue, tagInfo.SiteId, tagInfo.Name, "New Description",
                tagInfo.Units, false, 3);

            phdTagInfoList.Remove(tagInfo);
            phdTagInfoList.Add(changedTagInfo);

            mockTagDao.Expect(m => m.Update(changedTagInfo));
            mockTagDao.Expect(m => m.Insert(null)).IgnoreArguments();
            mockTagDao.Stub(m => m.QueryBySiteIdAndPrefixCharacterIncludeDeleted(site.IdValue, tagPrefix))
                .Return(new List<TagInfo> {tagInfo});

            tagService.UpdatePlantHistorianTagInfoList(site, tagPrefix, phdTagInfoList);

            mockTagDao.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldUpdateChangedPlantHistorianTagInfoWhenUnitsChanges()
        {
            var site = SiteFixture.Sarnia();
            const string tagPrefix = "s";
            var phdTagInfoList = TagInfoFixture.CreatePHDTagInfoList(site, 10,3);
            var tagInfo = phdTagInfoList[0];
            var changedTagInfo = new TagInfo(tagInfo.Id, tagInfo.SiteId, tagInfo.Name, tagInfo.Description, "NEWUNITS",
                false, 3);
            phdTagInfoList.Remove(tagInfo);
            phdTagInfoList.Add(changedTagInfo);

            mockTagDao.Expect(m => m.Update(changedTagInfo));
            mockTagDao.Expect(m => m.Insert(null)).IgnoreArguments();

            mockTagDao.Stub(m => m.QueryBySiteIdAndPrefixCharacterIncludeDeleted(site.IdValue, tagPrefix))
                .Return(new List<TagInfo> {tagInfo});
            tagService.UpdatePlantHistorianTagInfoList(site, tagPrefix, phdTagInfoList);

            mockTagDao.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldUpdateDescriptionChanged_NoNmock()
        {
            const string prefix = "ABC";
            var site = SiteFixture.Sarnia();

            var tagDao = new TestTagDao();
            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor((ITagDao) tagDao);

            var matchingExistingTag = new TagInfo(site.Id, "tag name", "old description", "some units", false, null);
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Clear();
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Add(new TagInfo(site.Id, "existing 1", "d1", "u1", false, null));
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Add(new TagInfo(site.Id, "existing 2", "d2", "u2", false, null));
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Add(new TagInfo(site.Id, "existing 3", "d3", "u3", false, null));
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Add(matchingExistingTag);

            var tagInfoList = new List<TagInfo>
            {
                tagDao.QueryBySiteIdAndPrefixCharacterResult[0],
                tagDao.QueryBySiteIdAndPrefixCharacterResult[1],
                tagDao.QueryBySiteIdAndPrefixCharacterResult[2],
                new TagInfo(site.Id, "tag name", "tag description", "some units", false, null)
            };

/*
            Stub.On(mockTargetDefinitionService);
            Stub.On(mockRestrictionDefinitionService);
            Stub.On(mockLabAlertDefinitionService);
*/

            var service = new TagService(mockTargetDefinitionService, mockRestrictionDefinitionService,
                mockLabAlertDefinitionService);
            service.UpdatePlantHistorianTagInfoList(site, prefix, tagInfoList);

            Assert.AreEqual(0, tagDao.InsertedTags.Count);
            Assert.AreEqual(1, tagDao.UpdatedTags.Count);
            Assert.AreEqual("tag name", tagDao.UpdatedTags[0].Name);
            Assert.AreEqual(0, tagDao.RemovedTags.Count);
        }

        [Ignore] [Test]
        public void ShouldUpdateModifiedPlantHistorianTagsAlreadyExistingButDeletedInLocalDatabase()
        {
            var site = SiteFixture.Sarnia();
            const string tagPrefix = "s";
            var originalTagInfo = new TagInfo(site.IdValue, "sABC", "existing description", "existing units", true, null);
            var changedTagInfo = new TagInfo(originalTagInfo.SiteId, originalTagInfo.Name, "New Description",
                originalTagInfo.Units, false, null);

            var phdTagInfoList = new List<TagInfo>();
            phdTagInfoList.Remove(originalTagInfo);
            phdTagInfoList.Add(changedTagInfo);

            mockTagDao.Expect(m => m.Update(changedTagInfo));
            mockTagDao.Stub(m => m.QueryBySiteIdAndPrefixCharacterIncludeDeleted(site.IdValue, tagPrefix))
                .Return(new List<TagInfo> {originalTagInfo});
            mockTargetDefinitionService.Expect(m => m.UpdateStatusForValidTag(null, null)).IgnoreArguments();
            mockRestrictionDefinitionService.Expect(m => m.UpdateStatusForValidTag(null, null)).IgnoreArguments();
            mockLabAlertDefinitionService.Expect(m => m.UpdateStatusForValidTag(null, null)).IgnoreArguments();

            tagService.UpdatePlantHistorianTagInfoList(site, tagPrefix, phdTagInfoList);

            mockTagDao.VerifyAllExpectations();
            mockTargetDefinitionService.VerifyAllExpectations();
            mockRestrictionDefinitionService.VerifyAllExpectations();
            mockLabAlertDefinitionService.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldUpdateModifiedPlantHistorianTagsAlreadyExistingInLocalDatabase()
        {
            var site = SiteFixture.Sarnia();
            const string tagPrefix = "s";
            var phdTagInfoList = TagInfoFixture.CreatePHDTagInfoList(site, 1,3);
            var originalTagInfo = phdTagInfoList[0];
            var changedTagInfo = new TagInfo(originalTagInfo.Id, originalTagInfo.SiteId, originalTagInfo.Name,
                "New Description", originalTagInfo.Units, false, originalTagInfo.ScadaConnectionInfoId);
            phdTagInfoList.Remove(originalTagInfo);
            phdTagInfoList.Add(changedTagInfo);

            mockTagDao.Expect(m => m.Update(changedTagInfo));
            mockTagDao.Stub(m => m.QueryBySiteIdAndPrefixCharacterIncludeDeleted(site.IdValue, tagPrefix))
                .Return(new List<TagInfo> {originalTagInfo});

            tagService.UpdatePlantHistorianTagInfoList(site, tagPrefix, phdTagInfoList);
            mockTagDao.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldUpdateUnitsChanged_NoNmock()
        {
            const string prefix = "ABC";
            var site = SiteFixture.Sarnia();

            var tagDao = new TestTagDao();
            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor((ITagDao) tagDao);

            var matchingExistingTag = new TagInfo(site.Id, "tag name", "tag description", "old units", false, null);
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Clear();
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Add(new TagInfo(site.Id, "existing 1", "d1", "u1", false, null));
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Add(new TagInfo(site.Id, "existing 2", "d2", "u2", false, null));
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Add(new TagInfo(site.Id, "existing 3", "d3", "u3", false, null));
            tagDao.QueryBySiteIdAndPrefixCharacterResult.Add(matchingExistingTag);

            var tagInfoList = new List<TagInfo>
            {
                tagDao.QueryBySiteIdAndPrefixCharacterResult[0],
                tagDao.QueryBySiteIdAndPrefixCharacterResult[1],
                tagDao.QueryBySiteIdAndPrefixCharacterResult[2],
                new TagInfo(site.Id, "tag name", "tag description", "some units", false, null)
            };

/*
            Stub.On(mockTargetDefinitionService);
            Stub.On(mockRestrictionDefinitionService);
            Stub.On(mockLabAlertDefinitionService);
*/

            var service = new TagService(mockTargetDefinitionService, mockRestrictionDefinitionService,
                mockLabAlertDefinitionService);
            service.UpdatePlantHistorianTagInfoList(site, prefix, tagInfoList);

            Assert.AreEqual(0, tagDao.InsertedTags.Count);
            Assert.AreEqual(1, tagDao.UpdatedTags.Count);
            Assert.AreEqual("tag name", tagDao.UpdatedTags[0].Name);
            Assert.AreEqual(0, tagDao.RemovedTags.Count);
        }

        private class TestTagDao : ITagDao
        {
            public readonly List<TagInfo> InsertedTags = new List<TagInfo>();
            public readonly List<TagInfo> QueryBySiteIdAndPrefixCharacterResult = new List<TagInfo>();
            public readonly List<TagInfo> RemovedTags = new List<TagInfo>();
            public readonly List<TagInfo> UpdatedTags = new List<TagInfo>();

            public void Insert(TagInfo tagInfo)
            {
                InsertedTags.Add(tagInfo);
            }

            public void Remove(TagInfo tagInfo)
            {
                RemovedTags.Add(tagInfo);
            }

            public void Update(TagInfo tag)
            {
                UpdatedTags.Add(tag);
            }

            public List<TagInfo> QueryTagInfoByFilter(Site site, SearchCriteria criteria)
            {
                return new List<TagInfo>();
            }

            public TagInfo QueryById(long id)
            {
                return null;
            }

            public List<TagInfo> QueryBySiteIdAndPrefixCharacterIncludeDeleted(long siteId, string prefixCharacter)
            {
                return QueryBySiteIdAndPrefixCharacterResult;
            }

            public List<TagInfo> QueryByTagGroupId(long tagGroupId)
            {
                return new List<TagInfo>();
            }
        }
    }
}