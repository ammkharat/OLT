using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class RestrictionDefinitionServiceClientTest
    {
        private IFunctionalLocationService flocService;
        private IEditHistoryService historyService;
        private IRestrictionDefinitionService service;

        [SetUp]
        public void SetUp()
        {
            service = GenericServiceRegistry.Instance.GetService<IRestrictionDefinitionService>();
            historyService = GenericServiceRegistry.Instance.GetService<IEditHistoryService>();
            flocService = GenericServiceRegistry.Instance.GetService<IFunctionalLocationService>();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test][Ignore]
        public void ShouldReturnErrorIfNameIsAlreadyInUseForSite()
        {
            var name = "name " + DateTimeFixture.DateTimeNow.Ticks;
            var definition = RestrictionDefinitionFixture.CreateDefinition(
                name, flocService.QueryByFullHierarchy("EX1-OPLT-BLDI", Site.OILSAND_ID),
                TagInfoFixture.CreateTagInfoWithId2FromDB());
            definition.Id = null;
            definition = (RestrictionDefinition) service.Insert(definition)[0].DomainObject;
            Assert.IsNotNull(definition.Id);

            var duplicate = RestrictionDefinitionFixture.CreateDefinition(
                name, flocService.QueryByFullHierarchy("EX1-OPLT-BLDI", Site.OILSAND_ID),
                TagInfoFixture.CreateTagInfoWithId2FromDB());
            duplicate.Id = -1234;

            Assert.IsTrue(service.IsValidName(name, SiteFixture.Oilsands(), duplicate).HasError);
            Assert.IsFalse(service.IsValidName(name, SiteFixture.Oilsands(), definition).HasError);
            Assert.IsFalse(service.IsValidName("should not exist already", SiteFixture.Oilsands(), definition).HasError);
            Assert.IsFalse(service.IsValidName(name, SiteFixture.Oilsands(), definition).HasError);
        }

        [Test][Ignore]
        public void ShouldTakeSnapshotWhenInserting()
        {
            var definition = RestrictionDefinitionFixture.CreateDefinition(
                flocService.QueryByFullHierarchy("EX1", Site.OILSAND_ID), TagInfoFixture.CreateTagInfoWithId2FromDB());
            definition.Id = null;
            definition = (RestrictionDefinition) service.Insert(definition)[0].DomainObject;

            var history = historyService.GetEditHistoryForRestrictionDefinition(definition.IdValue);
            Assert.AreEqual(1, history.Count);
        }

        [Test][Ignore]
        public void ShouldTakeSnapshotWhenUpdating()
        {
            var definition = RestrictionDefinitionFixture.CreateDefinition(
                flocService.QueryByFullHierarchy("EX1", Site.OILSAND_ID), TagInfoFixture.CreateTagInfoWithId2FromDB());
            definition.Id = null;
            definition = (RestrictionDefinition) service.Insert(definition)[0].DomainObject;

            definition.Name = "try to make this a new name";
            service.Update(definition);

            var history = historyService.GetEditHistoryForRestrictionDefinition(definition.IdValue);
            Assert.AreEqual(2, history.Count);
        }

        [Test][Ignore]
        public void ShouldUpdateStatusForInvalidTag()
        {
            var tag = TagInfoFixture.CreateTagInfoWithId2FromDB();
            var definition = RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.Valid, tag, null);
            definition.FunctionalLocation = flocService.QueryByFullHierarchy("EX1", Site.OILSAND_ID);
            definition = (RestrictionDefinition) service.Insert(definition)[0].DomainObject;
            Assert.AreEqual(RestrictionDefinitionStatus.Valid, definition.Status);

            service.UpdateStatusForInvalidTag(tag, SiteFixture.Sarnia());

            var requeried = service.QueryById(definition.IdValue);
            Assert.AreEqual(RestrictionDefinitionStatus.InvalidTag, requeried.Status);
        }

        [Test][Ignore]
        public void ShouldUpdateStatusForValidTag()
        {
            var tag = TagInfoFixture.CreateTagInfoWithId2FromDB();
            var definition = RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.InvalidTag, tag, null);
            definition.FunctionalLocation = flocService.QueryByFullHierarchy("EX1", Site.OILSAND_ID);
            definition = (RestrictionDefinition) service.Insert(definition)[0].DomainObject;
            Assert.AreEqual(RestrictionDefinitionStatus.InvalidTag, definition.Status);

            service.UpdateStatusForValidTag(tag, SiteFixture.Sarnia());

            var requeried = service.QueryById(definition.IdValue);
            Assert.AreEqual(RestrictionDefinitionStatus.Valid, requeried.Status);
        }
    }
}