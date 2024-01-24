using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class ManageOpModeForUnitLevelFLOCFormPresenterTest
    {
        private Mockery mockery;
        private IManageOpModeForUnitLevelFLOCView mockView;
        private IFunctionalLocationOperationalModeService opModeService;

        private ManageOpModeForUnitLevelFLOCFormPresenter presenter;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();          
            mockery = new Mockery();
            mockView = mockery.NewMock<IManageOpModeForUnitLevelFLOCView>();

            opModeService = mockery.NewMock<IFunctionalLocationOperationalModeService>();

            ClientSession.GetUserContext().User = UserFixture.CreateUser(SiteFixture.Sarnia());
            
            presenter = new ManageOpModeForUnitLevelFLOCFormPresenter(mockView, opModeService);
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldQueryOpModeDTOsOnLoad()
        {
            SetExpectationsForLoadPageFunction();
            presenter.LoadPage(null, EventArgs.Empty);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldAddTheModifiedDtoToTheList()
        {
            DateTime now = Clock.Now;
            DateTime yesterday = now.SubtractDays(1);
            FunctionalLocationOperationalModeDTO selectedDto = new FunctionalLocationOperationalModeDTO(42, "DUS-TIN-RULEZ",
                                                                                                        "Fake Description",
                                                                                                        OperationalMode.Constrained,
                                                                                                        AvailabilityReason.RoutineMaintenance,
                                                                                                        yesterday);

            FunctionalLocationOperationalModeDTO modifiedDto = new FunctionalLocationOperationalModeDTO(42, "DUS-TIN-RULEZ",
                                                                                                        "Fake Description",
                                                                                                        OperationalMode.Normal,
                                                                                                        AvailabilityReason.None,
                                                                                                        Clock.Now);

            Expect.Once.On(mockView).GetProperty("SelectedItem").Will(Return.Value(selectedDto));
            Expect.Once.On(mockView).Method("OpenEditOperationalModeDialog").With(selectedDto).Will(Return.Value(modifiedDto));

            // edit the selected row
            presenter.HandleEditButtonClicked(null, EventArgs.Empty);

            List<FunctionalLocationOperationalModeDTO> modifiedOpModes = presenter.ModifiedOperationalModeList;

            Assert.IsNotNull(modifiedOpModes);
            Assert.AreEqual(1, modifiedOpModes.Count);

            Assert.AreEqual(modifiedDto.FunctionalLocationId, modifiedOpModes[0].FunctionalLocationId);
            Assert.AreEqual(modifiedDto.FullHierarchy, modifiedOpModes[0].FullHierarchy);
            Assert.AreEqual(modifiedDto.OperationalMode, modifiedOpModes[0].OperationalMode);
            Assert.AreEqual(modifiedDto.AvailabilityReason, modifiedOpModes[0].AvailabilityReason);

            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldNotifyTheUserIfThereIsNoRowSelected()
        {
            Expect.Once.On(mockView).GetProperty("SelectedItem").Will(Return.Value(null));
            Expect.Once.On(mockView).Method("DisplayOKDialog");

            presenter.HandleEditButtonClicked(null, EventArgs.Empty);

            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldNotTryToAddAOpModeToTheListIfItComesBackNullFromTheEditDialog()
        {
            FunctionalLocationOperationalModeDTO selectedDto = new FunctionalLocationOperationalModeDTO(42, "DUS-TIN-RULEZ",
                                                                                                        "Fake Description",
                                                                                                        OperationalMode.Constrained,
                                                                                                        AvailabilityReason.RoutineMaintenance,
                                                                                                        Clock.Now);

            Expect.Once.On(mockView).GetProperty("SelectedItem").Will(Return.Value(selectedDto));
            Expect.Once.On(mockView).Method("OpenEditOperationalModeDialog").With(selectedDto).Will(Return.Value(null));

            // edit the selected row
            presenter.HandleEditButtonClicked(null, EventArgs.Empty);

            List<FunctionalLocationOperationalModeDTO> modifiedOpModes = presenter.ModifiedOperationalModeList;

            Assert.AreEqual(0, modifiedOpModes.Count);
        }

        private void SetExpectationsForLoadPageFunction()
        {
            Expect.Once.On(mockView).SetProperty("Site").To(ClientSession.GetUserContext().Site.Name);
            Expect.Once.On(opModeService).Method("GetBySiteId").With(ClientSession.GetUserContext().SiteId);
            Expect.Once.On(mockView).SetProperty("Items");
        }
    }
}