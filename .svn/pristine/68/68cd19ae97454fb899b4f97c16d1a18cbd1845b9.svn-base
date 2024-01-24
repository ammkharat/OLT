using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class TargetDefinitionServiceClientTest
    {
        private IFunctionalLocationService flocService;
        private ITargetDefinitionService service;

        [SetUp]
        public void SetUp()
        {
            service = GenericServiceRegistry.Instance.GetService<ITargetDefinitionService>();
            flocService = GenericServiceRegistry.Instance.GetService<IFunctionalLocationService>();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test][Ignore]
        public void AddNewShouldReturnTheTargeDefinitionWithNewID()
        {
            var targetDefinition =
                TargetDefinitionFixture.
                    CreateATargetWithRecurringDailyScheduleAndPendingTargetFixtureWithTestDescription();
            targetDefinition.Assignment = null;
            targetDefinition.FunctionalLocation = flocService.QueryByFullHierarchy("SR1-OFFS-BDOF", Site.SARNIA_ID);
            targetDefinition = (TargetDefinition) service.Insert(targetDefinition)[0].DomainObject;
            Assert.IsNotNull(targetDefinition.Id);
        }

        [Test][Ignore]
        public void ShouldApprove()
        {
            var targetDefinition =
                TargetDefinitionFixture
                    .CreateATargetWithRecurringDailyScheduleAndPendingTargetFixtureWithTestDescription();
            targetDefinition.Assignment = null;
            targetDefinition.Name = DateTimeFixture.DateTimeNow + "Approval";
            targetDefinition.FunctionalLocation = flocService.QueryByFullHierarchy("SR1-OFFS-BDOF", Site.SARNIA_ID);
            targetDefinition = (TargetDefinition) service.Insert(targetDefinition)[0].DomainObject;

            {
                var requieried = service.QueryById(targetDefinition.IdValue);
                Assert.AreEqual(requieried.Status, TargetDefinitionStatus.Pending);
            }

            service.Approve(targetDefinition, UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(),
                DateTimeFixture.DateTimeNow);

            {
                var requieried = service.QueryById(targetDefinition.IdValue);
                Assert.AreEqual(requieried.Status, TargetDefinitionStatus.Approved);
            }
        }

        [Test][Ignore]
        public void ShouldBeAbleToAddQueryUpdateAndRemoveTargeDefinition()
        {
            var toAddTargetDefinition =
                TargetDefinitionFixture.
                    CreateATargetWithRecurringDailyScheduleAndPendingTargetFixtureWithTestDescription();
            toAddTargetDefinition.Assignment = null;
            toAddTargetDefinition.Name = DateTimeFixture.DateTimeNow + "Rmv";
            toAddTargetDefinition.FunctionalLocation = flocService.QueryByFullHierarchy("SR1-OFFS-BDOF", Site.SARNIA_ID);
            var addedTargetDefinition = (TargetDefinition) service.Insert(toAddTargetDefinition)[0].DomainObject;

            Assert.IsNotNull(addedTargetDefinition.Id);

            var queryForAddTargetDefinition = service.QueryById(addedTargetDefinition.Id.Value);

            queryForAddTargetDefinition.Description = "Test Description";

            service.Update(queryForAddTargetDefinition, new TagChangedState());

            var requeryForModifiedTargetDefinition = service.QueryById(addedTargetDefinition.Id.Value);

            //can't do this since schedule is different ID
            //Assert.AreEqual(queryForAddTargetDefinition, requeryForModifiedTargetDefinition);

            service.Remove(requeryForModifiedTargetDefinition);

            var queryForRemovedTargetDefinition = service.QueryById(requeryForModifiedTargetDefinition.IdValue);

            Assert.IsTrue(queryForRemovedTargetDefinition.Deleted);
        }

        [Test][Ignore]
        public void ShouldReject()
        {
            var targetDefinition =
                TargetDefinitionFixture
                    .CreateATargetWithRecurringDailyScheduleAndPendingTargetFixtureWithTestDescription();
            targetDefinition.Assignment = null;
            targetDefinition.Name = DateTimeFixture.DateTimeNow + "Reject";
            targetDefinition.FunctionalLocation = flocService.QueryByFullHierarchy("SR1-OFFS-BDOF", Site.SARNIA_ID);
            targetDefinition = (TargetDefinition) service.Insert(targetDefinition)[0].DomainObject;

            {
                var requieried = service.QueryById(targetDefinition.IdValue);
                Assert.AreEqual(requieried.Status, TargetDefinitionStatus.Pending);
            }

            service.Reject(targetDefinition, UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(),
                DateTimeFixture.DateTimeNow);

            {
                var requieried = service.QueryById(targetDefinition.IdValue);
                Assert.AreEqual(requieried.Status, TargetDefinitionStatus.Rejected);
            }
        }
    }
}