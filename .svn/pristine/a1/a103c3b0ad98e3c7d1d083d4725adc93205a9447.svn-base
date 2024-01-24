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
    public class WorkPermitServiceClientTest
    {
        private IFunctionalLocationService flocService;
        private IWorkPermitService service;

        [SetUp]
        public void SetUp()
        {
            service = GenericServiceRegistry.Instance.GetService<IWorkPermitService>();
            flocService = GenericServiceRegistry.Instance.GetService<IFunctionalLocationService>();
        }

        [Test][Ignore]
        public void AddNewShouldReturnTheWorkPermitWithNewID()
        {
            var workPermit = WorkPermitFixture.CreateWorkPermitWithRadiationInformationSetWithNoID();
            workPermit.Specifics.FunctionalLocation = flocService.QueryByFullHierarchy("SR1-OFFS-BDOF", Site.SARNIA_ID);
            workPermit = (WorkPermit) service.Insert(workPermit)[0].DomainObject;
            Assert.IsNotNull(workPermit.Id);
        }

        [Test][Ignore]
        public void AddNewWithBigWorkPermitShouldReturnTheWorkPermitWithNewID()
        {
            const string sewerString = "Test";

            var workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
            workPermit.Specifics.FunctionalLocation = flocService.QueryByFullHierarchy("SR1-OFFS-BDOF", Site.SARNIA_ID);
            workPermit.JobWorksitePreparation.SewerIsolationMethodOtherDescription = sewerString;
            workPermit = (WorkPermit) service.Insert(workPermit)[0].DomainObject;
            Assert.IsNotNull(workPermit.Id);
            Assert.IsNotNull(workPermit.EquipmentPreparationCondition);
            Assert.AreEqual(workPermit.JobWorksitePreparation.SewerIsolationMethodOtherDescription, sewerString);
        }

        [Test]
        [Ignore] //using this for visual checks of remote event repeaters..don't need for regular test run
        public void CreateABunchOfWorkPermits()
        {
            var workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
            workPermit.Specifics.FunctionalLocation = flocService.QueryByFullHierarchy("SR1-OFFS-BDOF", Site.SARNIA_ID);
            for (var i = 0; i < 10; i++)
            {
                service.Insert(workPermit);
            }
        }
    }
}