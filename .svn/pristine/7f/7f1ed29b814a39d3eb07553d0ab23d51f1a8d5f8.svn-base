using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class RestrictionDefinitionHistoryDaoTest : AbstractDaoTest
    {
        private IRestrictionDefinitionHistoryDao dao;
        private TagInfo tag;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IRestrictionDefinitionHistoryDao>();

            ITagDao tagDao = DaoRegistry.GetDao<ITagDao>();
            List<TagInfo> tags = tagDao.QueryBySiteIdAndPrefixCharacterIncludeDeleted(SiteFixture.Oilsands().IdValue, "P86_REST_MASS_TARGET");
            tag = tags[0];
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            RestrictionDefinition definition = RestrictionDefinitionFixture.CreateDefinition(tag);
            definition.Id = 1234;
            definition.ProductionTargetTagInfo = TagInfoFixture.CreateTagInfoWithId2FromDB();
            definition.ProductionTargetValue = 123;
            RestrictionDefinitionHistory history = definition.TakeSnapshot();
            dao.Insert(history);

            List<RestrictionDefinitionHistory> histories = dao.GetById(history.IdValue);
            Assert.AreEqual(1, histories.Count);

            RestrictionDefinitionHistory requeried = histories[0];
            Assert.AreEqual(definition.Id, requeried.Id);
            Assert.AreEqual(definition.Name, requeried.Name);
            Assert.AreEqual(definition.FunctionalLocation.Id, requeried.FunctionalLocation.Id);
            Assert.AreEqual(definition.Description, requeried.Description);
            Assert.AreEqual(definition.MeasurementTagInfo.Id, requeried.MeasurementTagInfo.Id);
            Assert.AreEqual(definition.ProductionTargetValue, requeried.ProductionTargetValue);
            Assert.AreEqual(definition.ProductionTargetTagInfo.Id, requeried.ProductionTargetTagInfo.Id);
            Assert.AreEqual(definition.IsActive, requeried.IsActive);
            Assert.AreEqual(definition.IsOnlyVisibleOnReports, requeried.IsOnlyVisibleOnReports);
            Assert.AreEqual(definition.LastModifiedBy.Id, requeried.LastModifiedBy.Id);
            Assert.That(definition.LastModifiedDateTime, Is.EqualTo(requeried.LastModifiedDate).Within(TimeSpan.FromSeconds(10)));
        }

        [Ignore] [Test]
        public void ShouldInsertNullTarget()
        {
            RestrictionDefinition definition = RestrictionDefinitionFixture.CreateDefinition(tag);
            definition.Id = 1234;
            definition.ProductionTargetTagInfo = null;
            definition.ProductionTargetValue = null;
            RestrictionDefinitionHistory history = definition.TakeSnapshot();
            dao.Insert(history);

            List<RestrictionDefinitionHistory> histories = dao.GetById(history.IdValue);
            Assert.AreEqual(1, histories.Count);

            RestrictionDefinitionHistory requeried = histories[0];
            Assert.AreEqual(definition.ProductionTargetValue, requeried.ProductionTargetValue);
            Assert.AreEqual(definition.ProductionTargetTagInfo, requeried.ProductionTargetTagInfo);
        }
    }
}
