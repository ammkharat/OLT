using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class FunctionalLocationFormSelectionPresenterTest
    {
        private Mockery mocks;
        private SingleSelectFunctionalLocationSelectionFormPresenter presenter;
        private ISingleSelectFunctionalLocationSelectionForm mockView;

        private readonly FunctionalLocation functionalLocation = FunctionalLocationFixture.GetAny_Equip1();

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockView = mocks.NewMock<ISingleSelectFunctionalLocationSelectionForm>();
            presenter = new SingleSelectFunctionalLocationSelectionFormPresenter(mockView);
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void ClickingTheAcceptButtonWithNoFunctionalLocationsSelectedShouldRaiseAMessageAndNotCloseTheWindow()
        {
            Expect.Once.On(mockView).Method("LaunchFunctionalLocationSelectionRequiredMessage");
            Expect.Once.On(mockView).GetProperty("SelectedFunctionalLocation").Will(
                Return.Value(null));
            presenter.HandleAccept(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ClickingTheAcceptButtonWithRequiredFunctionalLocationsSelectedShouldCloseTheWindow()
        {
            Expect.Once.On(mockView).GetProperty("SelectedFunctionalLocation").Will(Return.Value(functionalLocation));
            Stub.On(mockView).GetProperty("AreSelectedFunctionalLocationsValid").Will(Return.Value(true));
            Expect.Once.On(mockView).Method("CloseForm").With(DialogResult.OK);
            presenter.HandleAccept(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ClickingTheAcceptButtonWithNonSelectableFunctionalLocationShouldReturnError()
        {
            Stub.On(mockView).GetProperty("SelectedFunctionalLocation").Will(Return.Value(FunctionalLocationFixture.CreateNew("EX1-PLT1-LEVEL3")));
            Expect.Once.On(mockView).GetProperty("AreSelectedFunctionalLocationsValid").Will(Return.Value(false));
            Expect.Once.On(mockView).Method("SetFunctionalLocationErrorMessage");
            presenter.HandleAccept(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
    }
}