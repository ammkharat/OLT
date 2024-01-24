using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class RestrictionDefinitionDaoTest : AbstractDaoTest
    {
        private IRestrictionDefinitionDao dao;
        private TagInfo tag;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IRestrictionDefinitionDao>();

            ITagDao tagDao = DaoRegistry.GetDao<ITagDao>();
            List<TagInfo> tags = tagDao.QueryBySiteIdAndPrefixCharacterIncludeDeleted(SiteFixture.Oilsands().IdValue, "P86_REST_MASS_TARGET");
            tag = tags[0];
        }

        protected override void Cleanup()
        {
        }

        private static void PopulateFields(RestrictionDefinition requeried)
        {
            requeried.Name = "this is a new name";
            requeried.FunctionalLocation = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM();
            requeried.Description = "this is a new desription";
            requeried.MeasurementTagInfo = TagInfoFixture.CreateTagInfoWithId2FromDB();
            requeried.ProductionTargetValue = null;
            requeried.ProductionTargetTagInfo = TagInfoFixture.CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC();
            requeried.IsActive = false;
            requeried.IsOnlyVisibleOnReports = false;
            requeried.LastInvokedDateTime = new DateTime(2010, 11, 22, 3, 4, 55);
            requeried.LastModifiedBy = UserFixture.CreateSupervisor();
            requeried.LastModifiedDateTime = new DateTime(2010, 1, 2, 3, 4, 5);
            requeried.CreatedDate = new DateTime(2011, 11, 21, 3, 41, 51);
        }

        private static void AssertPopulatedFieldsAreEqual(RestrictionDefinition requeried)
        {
            Assert.AreEqual("this is a new name", requeried.Name);
            Assert.AreEqual(FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM().Id, requeried.FunctionalLocation.Id);
            Assert.AreEqual("this is a new desription", requeried.Description);
            Assert.AreEqual(TagInfoFixture.CreateTagInfoWithId2FromDB(), requeried.MeasurementTagInfo);
            Assert.IsNull(requeried.ProductionTargetValue);
            Assert.AreEqual(TagInfoFixture.CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC().Id, requeried.ProductionTargetTagInfo.Id);
            Assert.AreEqual(false, requeried.IsActive);
            Assert.AreEqual(false, requeried.IsOnlyVisibleOnReports);
            Assert.AreEqual(UserFixture.CreateSupervisor().Id, requeried.LastModifiedBy.Id);
            Assert.AreEqual(new DateTime(2010, 1, 2, 3, 4, 5), requeried.LastModifiedDateTime);
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            RestrictionDefinition definition = RestrictionDefinitionFixture.CreateDefinition(tag);
            PopulateFields(definition);
            RestrictionDefinition saved = dao.Insert(definition);

            RestrictionDefinition requeried = dao.QueryById(saved.IdValue);
            Assert.IsNotNull(requeried);
            
            AssertPopulatedFieldsAreEqual(requeried);
            Assert.AreEqual(new DateTime(2011, 11, 21, 3, 41, 51), requeried.CreatedDate);
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            RestrictionDefinition definition = RestrictionDefinitionFixture.CreateDefinition(tag);
            definition = dao.Insert(definition);
            long id = definition.IdValue;

            {
                RestrictionDefinition requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);

                PopulateFields(requeried);

                dao.Update(requeried);
            }
            {
                RestrictionDefinition requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);

                AssertPopulatedFieldsAreEqual(requeried);
                Assert.That(definition.CreatedDate, Is.EqualTo(requeried.CreatedDate).Within(TimeSpan.FromSeconds(10)));
            }
        }

        [Ignore] [Test]
        public void ShouldSaveNullTarget()
        {
            RestrictionDefinition definition = RestrictionDefinitionFixture.CreateDefinition(tag);
            definition.ProductionTargetValue = null;
            definition.ProductionTargetTagInfo = null;
            long id = dao.Insert(definition).IdValue;

            RestrictionDefinition requeried = dao.QueryById(id);
            Assert.IsNotNull(requeried);
            Assert.IsNull(requeried.ProductionTargetValue);
            Assert.IsNull(requeried.ProductionTargetTagInfo);
        }

        [Ignore] [Test]
        public void InsertAndUpdateshouldNotSaveLastInvokedDateTime()
        {
            RestrictionDefinition definition = RestrictionDefinitionFixture.CreateDefinition(tag);
            PopulateFields(definition);
            definition.LastInvokedDateTime = new DateTime(2010, 1, 2, 3, 4, 5);
            RestrictionDefinition saved = dao.Insert(definition);

            {
                RestrictionDefinition requeried = dao.QueryById(saved.IdValue);
                Assert.IsNull(requeried.LastInvokedDateTime);
            }

            saved.LastInvokedDateTime = new DateTime(2010, 10, 22, 3, 40, 55);
            dao.Update(saved);

            {
                RestrictionDefinition requeried = dao.QueryById(saved.IdValue);
                Assert.IsNull(requeried.LastInvokedDateTime);
            }
        }

        [Ignore] [Test]
        public void ShouldSaveAndUpdateNullLastInvokedDateTime()
        {
            RestrictionDefinition definition = RestrictionDefinitionFixture.CreateDefinition(tag);
            definition = dao.Insert(definition);
            definition.LastInvokedDateTime = null;
            dao.UpdateLastInvokedDateTime(definition);

            {
                RestrictionDefinition requeried = dao.QueryById(definition.IdValue);
                Assert.IsNotNull(requeried);
                Assert.IsNull(requeried.LastInvokedDateTime);
            }

            definition.LastInvokedDateTime = new DateTime(2010, 5, 4, 3, 2, 1);
            dao.UpdateLastInvokedDateTime(definition);

            {
                RestrictionDefinition requeried = dao.QueryById(definition.IdValue);
                Assert.IsNotNull(requeried);
                Assert.IsNotNull(requeried.LastInvokedDateTime);
                Assert.AreEqual(new DateTime(2010, 5, 4, 3, 0, 0), requeried.LastInvokedDateTime);
            }

            definition.LastInvokedDateTime = null;
            dao.UpdateLastInvokedDateTime(definition);

            {
                RestrictionDefinition requeried = dao.QueryById(definition.IdValue);
                Assert.IsNotNull(requeried);
                Assert.IsNull(requeried.LastInvokedDateTime);
            }
        }

        [Ignore] [Test]
        public void ShouldDelete()
        {
            RestrictionDefinition definition = RestrictionDefinitionFixture.CreateDefinition(tag);
            RestrictionDefinition saved = dao.Insert(definition);
            long id = saved.IdValue;

            {
                RestrictionDefinition requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);
                Assert.IsFalse(requeried.Deleted);
            }

            dao.Remove(saved);
            {
                RestrictionDefinition requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);
                Assert.IsTrue(requeried.Deleted);
            }
        }

        [Ignore] [Test]
        public void ShouldGetCountByNameAndSite()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SMF();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_DN1_3003_0000();

            RestrictionDefinition definition1 = dao.Insert(RestrictionDefinitionFixture.CreateDefinition("same name", floc1, tag));
            RestrictionDefinition definition2 = dao.Insert(RestrictionDefinitionFixture.CreateDefinition("same name", floc1, tag));
            RestrictionDefinition definition3 = dao.Insert(RestrictionDefinitionFixture.CreateDefinition("same name", floc1, tag));
            RestrictionDefinition definition4 = dao.Insert(RestrictionDefinitionFixture.CreateDefinition("same name", floc2, tag));

            {
                List<RestrictionDefinition> results = dao.QueryByName(SiteFixture.Sarnia().IdValue, "same name");
                Assert.IsTrue(results.ExistsById(definition1));
                Assert.IsTrue(results.ExistsById(definition2));
                Assert.IsTrue(results.ExistsById(definition3));
                Assert.IsFalse(results.ExistsById(definition4));
            }
            {
                List<RestrictionDefinition> results = dao.QueryByName(SiteFixture.Denver().IdValue, "same name");
                Assert.IsFalse(results.ExistsById(definition1));
                Assert.IsFalse(results.ExistsById(definition2));
                Assert.IsFalse(results.ExistsById(definition3));
                Assert.IsTrue(results.ExistsById(definition4));
            }

            dao.Remove(definition1);

            {
                List<RestrictionDefinition> results = dao.QueryByName(SiteFixture.Sarnia().IdValue, "same name");
                Assert.IsFalse(results.ExistsById(definition1));
                Assert.IsTrue(results.ExistsById(definition2));
                Assert.IsTrue(results.ExistsById(definition3));
                Assert.IsFalse(results.ExistsById(definition4));
            }
            {
                List<RestrictionDefinition> results = dao.QueryByName(SiteFixture.Denver().IdValue, "same name");
                Assert.IsFalse(results.ExistsById(definition1));
                Assert.IsFalse(results.ExistsById(definition2));
                Assert.IsFalse(results.ExistsById(definition3));
                Assert.IsTrue(results.ExistsById(definition4));
            }
        }

        [Ignore] [Test]
        public void ShouldReturnDefinitionsWithApprovedStatusMatchingMeasurementTag()
        {
            TagInfo tag1 = TagInfoFixture.CreateTagInfoWithId2FromDB();
            TagInfo tag2 = TagInfoFixture.CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC();
            AssertReturnDefinitionsWithApprovedStatusMatchingTag(tag1, tag2, tag1, tag2, null, null);
        }

        [Ignore] [Test]
        public void ShouldReturnDefinitionsWithApprovedStatusMatchingTargetTag()
        {
            TagInfo tag1 = TagInfoFixture.CreateTagInfoWithId2FromDB();
            TagInfo tag2 = TagInfoFixture.CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC();
            TagInfo otherUnsearchedTag = TagInfoFixture.GetExistingSarniaTagInfoList()[0];
            AssertReturnDefinitionsWithApprovedStatusMatchingTag(tag1, tag2, otherUnsearchedTag, otherUnsearchedTag, tag1, tag2);
        }

        private void AssertReturnDefinitionsWithApprovedStatusMatchingTag(
            TagInfo searchTag1, TagInfo searchTag2,
            TagInfo measurementTag1, TagInfo measurementTag2, TagInfo targetTag1, TagInfo targetTag2)
        {

            RestrictionDefinition definition1 = dao.Insert(RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.Valid, measurementTag1, targetTag1));
            RestrictionDefinition definition2 = dao.Insert(RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.Valid, measurementTag1, targetTag1));
            RestrictionDefinition definition3 = dao.Insert(RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.Valid, measurementTag2, targetTag2));
            RestrictionDefinition definition4 = dao.Insert(RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.InvalidTag, measurementTag1, targetTag1));
            RestrictionDefinition definition5 = dao.Insert(RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.InvalidTag, measurementTag1, targetTag1));
            RestrictionDefinition definition6 = dao.Insert(RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.InvalidTag, measurementTag2, targetTag2));

            dao.Remove(definition2);
            dao.Remove(definition5);

            {
                List<RestrictionDefinition> results = dao.QueryRestrictionDefinitionsWithValidTag(searchTag1);
                Assert.IsTrue(results.ExistsById(definition1));
                Assert.IsFalse(results.ExistsById(definition2));
                Assert.IsFalse(results.ExistsById(definition3));
                Assert.IsFalse(results.ExistsById(definition4));
                Assert.IsFalse(results.ExistsById(definition5));
                Assert.IsFalse(results.ExistsById(definition6));
            }
            {
                List<RestrictionDefinition> results = dao.QueryRestrictionDefinitionsWithValidTag(searchTag2);
                Assert.IsFalse(results.ExistsById(definition1));
                Assert.IsFalse(results.ExistsById(definition2));
                Assert.IsTrue(results.ExistsById(definition3));
                Assert.IsFalse(results.ExistsById(definition4));
                Assert.IsFalse(results.ExistsById(definition5));
                Assert.IsFalse(results.ExistsById(definition6));
            }
        }

        [Ignore] [Test]
        public void ShouldReturnDefinitionsWithInvalidTagStatusMatchingMeasurementTag()
        {
            TagInfo tag1 = TagInfoFixture.CreateTagInfoWithId2FromDB();
            TagInfo tag2 = TagInfoFixture.CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC();
            AssertReturnDefinitionsWithInvalidTagStatusMatchingTag(tag1, tag2, tag1, tag2, null, null);
        }


        [Ignore] [Test]
        public void ShouldReturnDefinitionsWithInvalidTagStatusMatchingTargetTag()
        {
            TagInfo tag1 = TagInfoFixture.CreateTagInfoWithId2FromDB();
            TagInfo tag2 = TagInfoFixture.CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC();
            TagInfo otherUnsearchedTag = TagInfoFixture.GetExistingSarniaTagInfoList()[0];
            AssertReturnDefinitionsWithInvalidTagStatusMatchingTag(tag1, tag2, otherUnsearchedTag, otherUnsearchedTag, tag1, tag2);
        }

        private void AssertReturnDefinitionsWithInvalidTagStatusMatchingTag(
            TagInfo searchTag1, TagInfo searchTag2,
            TagInfo measurementTag1, TagInfo measurementTag2, TagInfo targetTag1, TagInfo targetTag2)
        {
            RestrictionDefinition definition1 = dao.Insert(RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.Valid, measurementTag1, targetTag1));
            RestrictionDefinition definition2 = dao.Insert(RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.Valid, measurementTag1, targetTag1));
            RestrictionDefinition definition3 = dao.Insert(RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.Valid, measurementTag2, targetTag2));
            RestrictionDefinition definition4 = dao.Insert(RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.InvalidTag, measurementTag1, targetTag1));
            RestrictionDefinition definition5 = dao.Insert(RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.InvalidTag, measurementTag1, targetTag1));
            RestrictionDefinition definition6 = dao.Insert(RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.InvalidTag, measurementTag2, targetTag2));

            dao.Remove(definition2);
            dao.Remove(definition5);

            {
                List<RestrictionDefinition> results = dao.QueryRestrictionDefinitionsWithInvalidTag(searchTag1);
                Assert.IsFalse(results.ExistsById(definition1));
                Assert.IsFalse(results.ExistsById(definition2));
                Assert.IsFalse(results.ExistsById(definition3));
                Assert.IsTrue(results.ExistsById(definition4));
                Assert.IsFalse(results.ExistsById(definition5));
                Assert.IsFalse(results.ExistsById(definition6));
            }
            {
                List<RestrictionDefinition> results = dao.QueryRestrictionDefinitionsWithInvalidTag(searchTag2);
                Assert.IsFalse(results.ExistsById(definition1));
                Assert.IsFalse(results.ExistsById(definition2));
                Assert.IsFalse(results.ExistsById(definition3));
                Assert.IsFalse(results.ExistsById(definition4));
                Assert.IsFalse(results.ExistsById(definition5));
                Assert.IsTrue(results.ExistsById(definition6));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryForScheduling()
        {
            RestrictionDefinition definition1 = dao.Insert(RestrictionDefinitionFixture.CreateDefinition(tag));
            RestrictionDefinition definition2 = dao.Insert(RestrictionDefinitionFixture.CreateDefinition(tag));

            {
                SchedulingList<RestrictionDefinition, OLTException> results = dao.QueryAllAvailableForScheduling();
                Assert.IsTrue(results.DomainObjectList.ExistsById(definition1));
                Assert.IsTrue(results.DomainObjectList.ExistsById(definition2));
            }

            dao.Remove(definition1);

            {
                SchedulingList<RestrictionDefinition, OLTException> results = dao.QueryAllAvailableForScheduling();
                Assert.IsFalse(results.DomainObjectList.ExistsById(definition1));
                Assert.IsTrue(results.DomainObjectList.ExistsById(definition2));
            }
        }             
    }
}
