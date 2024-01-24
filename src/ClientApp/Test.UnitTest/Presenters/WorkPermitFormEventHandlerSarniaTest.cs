using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NMock2;
using NUnit.Framework;
using Expect=NMock2.Expect;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class WorkPermitFormEventHandlerSarniaTest
    {
        private IWorkPermitFormViewSarnia sarniaView;
        private Mockery mockery;

        private WorkPermitFormSiteSpecificEventHandler handler;

        [SetUp]
        public void SetUp()
        {
            mockery = new Mockery();
            sarniaView = mockery.NewMock<IWorkPermitFormViewSarnia>();
            handler = WorkPermitFormSiteSpecificEventHandler.Create(sarniaView);
        }

        [Test]
        public void ShouldCheckDependentFieldsWhenHotTypeIsSelected()
        {
            Stub.On(sarniaView).GetProperty("WorkPermitType").Will(Return.Value(WorkPermitType.HOT));
            Expect.Once.On(sarniaView).SetProperty("FireIsTwentyABCorDryChemicalExtinguisher").To(true);
            Expect.Once.On(sarniaView).SetProperty("FireIsNotApplicable").To(false);
            Expect.Once.On(sarniaView).SetProperty("JobWorksiteIsSewerIsolationMethodNotApplicable").To(false);
            Expect.Once.On(sarniaView).SetProperty("JobWorksiteIsSewerIsolationMethodSealedOrCovered").To(true);

            handler.HandlePermitTypeHotCheckChanged();

            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDoNothingWhenColdTypeIsSelected()
        {
            Stub.On(sarniaView).GetProperty("WorkPermitType").Will(Return.Value(WorkPermitType.COLD));
            Expect.Never.On(sarniaView);

            handler.HandlePermitTypeHotCheckChanged();

            mockery.VerifyAllExpectationsHaveBeenMet();
        }


        [Test]
        public void ShouldCheckDependentFieldsWhenVehicleEntryIsSelected()
        {
            Stub.On(sarniaView).GetProperty("IsVehicleEntry").Will(Return.Value(true));

            Expect.Once.On(sarniaView).SetProperty("WorkPermitType").To(WorkPermitType.HOT);

            Expect.Once.On(sarniaView).SetProperty("JobWorksiteIsSewerIsolationMethodNotApplicable").To(false);
            Expect.Once.On(sarniaView).SetProperty("JobWorksiteIsSewerIsolationMethodSealedOrCovered").To(true);

            Expect.Once.On(sarniaView).SetProperty("FireIsTwentyABCorDryChemicalExtinguisher").To(true);
            Expect.Once.On(sarniaView).SetProperty("FireIsNotApplicable").To(false);

            Expect.Once.On(sarniaView).SetProperty("FireIsWatchmen").To(true);

            handler.HandleVehicleEntryCheckChanged();
        }

        [Test]
        public void ShouldCheckDependentFieldsWhenOpenFlameWeldIsSelected()
        {
            Stub.On(sarniaView).GetProperty("IsBurnOrOpenFlame").Will(Return.Value(true));

            Expect.Once.On(sarniaView).SetProperty("AdditionalIsBurnOrOpenFlameAssessment").To(true);
            Expect.Once.On(sarniaView).SetProperty("WorkPermitType").To(WorkPermitType.HOT);

            Expect.Once.On(sarniaView).SetProperty("JobWorksiteIsSewerIsolationMethodNotApplicable").To(false);
            Expect.Once.On(sarniaView).SetProperty("JobWorksiteIsSewerIsolationMethodSealedOrCovered").To(true);

            Expect.Once.On(sarniaView).SetProperty("FireIsTwentyABCorDryChemicalExtinguisher").To(true);
            Expect.Once.On(sarniaView).SetProperty("FireIsNotApplicable").To(false);

            Expect.Once.On(sarniaView).SetProperty("FireIsFireResistantTarpOrFireIsSparkContainment").To(true);
            Expect.Once.On(sarniaView).SetProperty("FireIsWatchmen").To(true);

            Expect.Once.On(sarniaView).SetProperty("JobWorksiteIsWeldingGroundWireInTestAreaNotApplicable").To(false);
            Expect.Once.On(sarniaView).SetProperty("JobWorksiteIsWeldingGroundWireInTestArea").To(true);

            handler.HandleBurnOpenFlameCheckChanged();
        }

        [Test]
        public void ShouldCheckDependentFieldsWhenBurnOpenFlameWeldIsUnSelected()
        {
            Stub.On(sarniaView).GetProperty("IsBurnOrOpenFlame").Will(Return.Value(false));
            Expect.Once.On(sarniaView).SetProperty("JobWorksiteIsWeldingGroundWireInTestAreaNotApplicable").To(true);

            handler.HandleBurnOpenFlameCheckChanged();
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldCheckAdditionalExcavationIfExcavationSelected()
        {
            Stub.On(sarniaView).GetProperty("IsExcavation").Will(Return.Value(true));
            Expect.Once.On(sarniaView).SetProperty("AdditionalIsExcavation").To(true);

            handler.HandleExcavationCheckChanged();
            mockery.VerifyAllExpectationsHaveBeenMet();                
        }

        [Test]
        public void ShouldCheckAdditionalCSEAsssmentAttributesIfConfinedSpaceEntrySelected()
        {
            Stub.On(sarniaView).GetProperty("IsConfinedSpaceEntry").Will(Return.Value(true));
            Expect.Once.On(sarniaView).SetProperty("FireIsNotApplicable").To(false);
            Expect.Once.On(sarniaView).SetProperty("FireIsWatchmen").To(true);
            Expect.Once.On(sarniaView).SetProperty("AdditionalIsCSEAssessmentOrAuthorization").To(true);

            handler.HandleConfinedSpaceEntryCheckChanged();
            mockery.VerifyAllExpectationsHaveBeenMet();            
        }
    }
}
