using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class LabAlertDefinitionServiceClientTest
    {
        private IFunctionalLocationService flocService;
        private IEditHistoryService historyService;
        private ILabAlertDefinitionService service;

        [SetUp]
        public void SetUp()
        {
            service = GenericServiceRegistry.Instance.GetService<ILabAlertDefinitionService>();
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
            var definition = LabAlertDefinitionFixture.CreateDefinition(
                name, flocService.QueryByFullHierarchy("SR1-OFFS-BDOF-SAB", Site.SARNIA_ID));
            definition.Id = null;
            definition = (LabAlertDefinition) service.Insert(definition)[0].DomainObject;
            Assert.IsNotNull(definition.Id);

            var duplicate = LabAlertDefinitionFixture.CreateDefinition(
                name, flocService.QueryByFullHierarchy("SR1-OFFS-BDOF-SAB", Site.SARNIA_ID));
            duplicate.Id = -1234;

            Assert.IsTrue(service.IsValidName(name, SiteFixture.Sarnia(), duplicate).HasError);
            Assert.IsFalse(service.IsValidName(name, SiteFixture.Sarnia(), definition).HasError);
            Assert.IsFalse(service.IsValidName("should not exist already", SiteFixture.Sarnia(), definition).HasError);
            Assert.IsFalse(service.IsValidName(name, SiteFixture.Denver(), definition).HasError);
        }

        [Test][Ignore]
        public void ShouldTakeSnapshotWhenInserting()
        {
            var definition =
                LabAlertDefinitionFixture.CreateDefinition(flocService.QueryByFullHierarchy("EX1", Site.OILSAND_ID));
            definition.Id = null;
            definition = (LabAlertDefinition) service.Insert(definition)[0].DomainObject;

            var history = historyService.GetEditHistoryForLabAlertDefinition(definition.IdValue);
            Assert.AreEqual(1, history.Count);
        }

        [Test][Ignore]
        public void ShouldTakeSnapshotWhenUpdating()
        {
            var definition =
                LabAlertDefinitionFixture.CreateDefinition(flocService.QueryByFullHierarchy("EX1", Site.OILSAND_ID));
            definition.Id = null;
            definition = (LabAlertDefinition) service.Insert(definition)[0].DomainObject;

            definition.Name = "try to make this a new name";
            service.Update(definition);

            var history = historyService.GetEditHistoryForLabAlertDefinition(definition.IdValue);
            Assert.AreEqual(2, history.Count);
        }

        [Test][Ignore]
        public void ShouldUpdateStatusForInvalidTag()
        {
            var tag = TagInfoFixture.CreateTagInfoWithId2FromDB();
            var definition = LabAlertDefinitionFixture.CreateDefinition(
                LabAlertDefinitionStatus.Valid, tag);
            definition.FunctionalLocation = flocService.QueryByFullHierarchy("EX1", Site.OILSAND_ID);
            definition = (LabAlertDefinition) service.Insert(definition)[0].DomainObject;
            Assert.AreEqual(LabAlertDefinitionStatus.Valid, definition.Status);

            service.UpdateStatusForInvalidTag(tag, SiteFixture.Sarnia());

            var requeried = service.QueryById(definition.IdValue);
            Assert.AreEqual(LabAlertDefinitionStatus.InvalidTag, requeried.Status);
        }

        [Test][Ignore]
        public void ShouldUpdateStatusForValidTag()
        {
            var tag = TagInfoFixture.CreateTagInfoWithId2FromDB();
            var definition = LabAlertDefinitionFixture.CreateDefinition(
                LabAlertDefinitionStatus.InvalidTag, tag);
            definition.FunctionalLocation = flocService.QueryByFullHierarchy("EX1", Site.OILSAND_ID);
            definition = (LabAlertDefinition) service.Insert(definition)[0].DomainObject;
            Assert.AreEqual(LabAlertDefinitionStatus.InvalidTag, definition.Status);

            service.UpdateStatusForValidTag(tag, SiteFixture.Sarnia());

            var requeried = service.QueryById(definition.IdValue);
            Assert.AreEqual(LabAlertDefinitionStatus.Valid, requeried.Status);
        }
    }
}