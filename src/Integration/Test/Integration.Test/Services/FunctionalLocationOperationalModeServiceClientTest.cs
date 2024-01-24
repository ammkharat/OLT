using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class FunctionalLocationOperationalModeServiceClientTest
    {
        private IActionItemService actionItemService;
        private IFunctionalLocationService flocService;
        private IFunctionalLocationOperationalModeService service;

        [SetUp]
        public void SetUp()
        {
            service = GenericServiceRegistry.Instance.GetService<IFunctionalLocationOperationalModeService>();
            actionItemService = GenericServiceRegistry.Instance.GetService<IActionItemService>();
            flocService = GenericServiceRegistry.Instance.GetService<IFunctionalLocationService>();
        }

        [Test][Ignore] //ayman remove ignore
        public void UpdateShouldChangeActionItemStatusToCleared()
        {
            var floc = flocService.QueryByFullHierarchy("SR1-PLT3-BDP3", Site.SARNIA_ID);

            var functionalLocationOperationalModeDto =
                FunctionalLocationOperationalModeDTOFixture.MakeConstrainedOpModeDto(floc.IdValue, floc.FullHierarchy);

            var actionItem = ActionItemFixture.Create();
            actionItem.FunctionalLocations.Clear();
            actionItem.FunctionalLocations.Add(floc);
            actionItem = actionItemService.Insert(actionItem);

            service.Update(new List<FunctionalLocationOperationalModeDTO> {functionalLocationOperationalModeDto},
                UserFixture.CreateOperatorOltUser1InFortMcMurrySite());

            var updatedActionItem = actionItemService.QueryById(actionItem.IdValue);
            Assert.AreEqual(ActionItemStatus.Cleared, updatedActionItem.Status);
        }
    }
}