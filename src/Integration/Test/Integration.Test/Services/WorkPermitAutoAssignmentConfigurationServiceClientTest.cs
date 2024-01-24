using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class WorkPermitAutoAssignmentConfigurationServiceClientTest
    {
        private IFunctionalLocationService functionalLocationService;
        private IWorkPermitAutoAssignmentConfigurationService service;
        private IWorkAssignmentService workAssignmentService;

        [SetUp]
        public void SetUp()
        {
            service = GenericServiceRegistry.Instance.GetService<IWorkPermitAutoAssignmentConfigurationService>();
            workAssignmentService = GenericServiceRegistry.Instance.GetService<IWorkAssignmentService>();
            functionalLocationService = GenericServiceRegistry.Instance.GetService<IFunctionalLocationService>();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test][Ignore]
        public void ShouldInsertAndReturnWorkPermitAutoAssignmentConfigurations()
        {
            var workAssignment = workAssignmentService.QueryBySite(SiteFixture.Oilsands())[0];

            var site = Site.OILSAND_ID;
            var floc1 = functionalLocationService.QueryByFullHierarchy("EX1-OPLT-BLDI-SAB", site);
            var floc2 = functionalLocationService.QueryByFullHierarchy("EX1-OPLT-BLDI-SCH", site);
            var floc3 = functionalLocationService.QueryByFullHierarchy("EX1-OPLT-COMS-SMP", site);
            var flocs = new List<FunctionalLocation> {floc1, floc2, floc3};

            var wpaac =
                new AssignmentFlocConfiguration(
                    workAssignment.IdValue, workAssignment.Name, workAssignment.Role.Name,
                    workAssignment.Description, workAssignment.Category, flocs);

            var listToSave =
                new List<AssignmentFlocConfiguration> {wpaac};

            // put the flocs in
            {
                service.UpdateFunctionalLocations(listToSave);

                var returnedConfigurations =
                    service.QueryBySite(SiteFixture.Oilsands());

                var returnedConfiguration =
                    returnedConfigurations.Find(c => c.WorkAssignmentId == workAssignment.IdValue);

                Assert.IsNotNull(returnedConfiguration);
                Assert.AreEqual(3, returnedConfiguration.FunctionalLocations.Count);

                foreach (var originalFloc in flocs)
                {
                    Assert.IsNotNull(
                        returnedConfiguration.FunctionalLocations.Find(f => f.IdValue == originalFloc.IdValue));
                }
            }

            // another update
            {
                wpaac.FunctionalLocations.Remove(floc1);
                Assert.AreEqual(2, wpaac.FunctionalLocations.Count);

                service.UpdateFunctionalLocations(listToSave);

                var returnedConfigurations =
                    service.QueryBySite(SiteFixture.Oilsands());

                var returnedConfiguration =
                    returnedConfigurations.Find(c => c.WorkAssignmentId == workAssignment.IdValue);

                Assert.IsNotNull(returnedConfiguration);
                Assert.AreEqual(2, returnedConfiguration.FunctionalLocations.Count);

                Assert.IsNotNull(returnedConfiguration.FunctionalLocations.Find(f => f.IdValue == floc2.IdValue));
                Assert.IsNotNull(returnedConfiguration.FunctionalLocations.Find(f => f.IdValue == floc3.IdValue));
            }
        }
    }
}