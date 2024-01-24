using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")][Ignore]
    public class ActionItemDefinitionServiceClientTest
    {
        private IActionItemService actionItemService;
        private BusinessCategory businessCategory;

        private IFunctionalLocationService flocService;
        private IActionItemDefinitionService service;

        [SetUp]
        public void SetUp()
        {
            service = GenericServiceRegistry.Instance.GetService<IActionItemDefinitionService>();
            flocService = GenericServiceRegistry.Instance.GetService<IFunctionalLocationService>();
            actionItemService = GenericServiceRegistry.Instance.GetService<IActionItemService>();
        }

        [Test]
        public void ShouldClearActionItemsOnUpdate()
        {
            var now = DateTimeFixture.DateTimeNow;

            var actionItemDefinition = GetNewActionItemDefinition();
            actionItemDefinition = (ActionItemDefinition) service.Insert(actionItemDefinition)[0].DomainObject;

            var actionItem = ActionItemFixture.CreateNewActionItemWithCreatedByActionItemDefinition(
                actionItemDefinition, now.AddDays(1));
            actionItem.FunctionalLocations.Clear();
            actionItem.FunctionalLocations.Add(flocService.QueryByFullHierarchy("SR1-OFFS-BDOF", Site.SARNIA_ID));
            actionItem.SetStatus(ActionItemStatus.Current, UserFixture.CreateRemoteAppUser(), now);
            actionItem.ResponseRequired = false;
            actionItem.StartDateTime = now;
            actionItem.EndDateTime = now;
            actionItem = actionItemService.Insert(actionItem);

            {
                Assert.IsTrue(actionItemService.CurrentActionItemsExistForActionItemDefinition(actionItemDefinition, now));
                var results = actionItemService.QueryDTOsByFunctionalLocationsAndDateRange(
                    new RootFlocSet(actionItem.FunctionalLocations),
                    ActionItemStatus.All,
                    new Range<Date>(new Date(now).SubtractDays(1), new Date(now).AddDays(2)),
                    null);
                Assert.IsTrue(results.Exists(obj => obj.Id == actionItem.Id));
            }

            service.UpdateAndClearCurrentActionItems(actionItemDefinition);

            {
                Assert.IsFalse(actionItemService.CurrentActionItemsExistForActionItemDefinition(actionItemDefinition,
                    now));
                var results = actionItemService.QueryDTOsByFunctionalLocationsAndDateRange(
                    new RootFlocSet(actionItem.FunctionalLocations),
                    ActionItemStatus.All,
                    new Range<Date>(new Date(now).SubtractDays(1), new Date(now).AddDays(2)),
                    null);
                Assert.IsFalse(results.Exists(obj => obj.Id == actionItem.Id));
            }
        }

        [Test]
        public void ShouldInsertAndUpdate()
        {
            var actionItemDefinition = GetNewActionItemDefinition();
            actionItemDefinition = (ActionItemDefinition) service.Insert(actionItemDefinition)[0].DomainObject;
            Assert.IsNotNull(actionItemDefinition.Id);

            {
                var requery = service.QueryById(actionItemDefinition.Id.Value);
                Assert.IsNotNull(requery);
                Assert.IsNotNull(requery.Schedule);
                Assert.IsNotNull(requery.FunctionalLocations);
            }

            actionItemDefinition.Description = "New Comments";
            service.Update(actionItemDefinition);

            {
                var requery = service.QueryById(actionItemDefinition.Id.Value);
                Assert.IsNotNull(requery);
                Assert.AreEqual("New Comments", requery.Description);
            }
        }

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            var businessCategoryService = GenericServiceRegistry.Instance.GetService<IBusinessCategoryService>();
            var categories = businessCategoryService.QueryAllBySite(SiteFixture.Sarnia().IdValue);
            businessCategory = categories[0];
        }

        private ActionItemDefinition GetNewActionItemDefinition()
        {
            var actionItemDefinition =
                ActionItemDefinitionFixture.CreateProcessCategoryActionItemDefinitionFortMcMurrayWithNoID();
            actionItemDefinition.FunctionalLocations.Clear();
            actionItemDefinition.FunctionalLocations.Add(flocService.QueryByFullHierarchy("SR1-OFFS-BDOF",
                Site.SARNIA_ID));
            actionItemDefinition.LastModifiedDate = DateTimeFixture.DateTimeNow;
            actionItemDefinition.Name = DateTimeFixture.DateTimeNow.ToString();
            actionItemDefinition.LastModifiedBy = UserFixture.CreateOperatorMickeyInFortMcMurrySite();
            actionItemDefinition.Category = businessCategory;
            return actionItemDefinition;
        }
    }
}