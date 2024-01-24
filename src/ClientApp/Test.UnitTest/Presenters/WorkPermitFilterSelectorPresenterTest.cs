using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class WorkPermitFilterSelectorPresenterTest
    {
        private WorkPermitFilterSelectorPresenter presenter;
        private IWorkPermitFilterSelectorFormView view;

        private Mockery mockery;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2006, 06, 05, 13, 05, 00);
            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            ClientSession.GetUserContext().User = user;

            mockery = new Mockery();
            view = mockery.NewMock<IWorkPermitFilterSelectorFormView>();
            Stub.On(view).SetProperty("Presenter");
            presenter = new WorkPermitFilterSelectorPresenter(view);
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldInitializeCheckBoxesWithEverythingCheckedExceptArchive()
        {
            Expect.Once.On(view).SetProperty("ApprovedChecked").To(true);
            Expect.Once.On(view).SetProperty("ArchiveChecked").To(false);
            Expect.Once.On(view).SetProperty("CompletedChecked").To(true);
            Expect.Once.On(view).SetProperty("IssuedChecked").To(true);
            Expect.Once.On(view).SetProperty("PendingChecked").To(true);
            Expect.Once.On(view).SetProperty("RejectedCheck").To(true);

            Stub.On(view);

            presenter.HandleFormLoad(null, null);

            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void CancellingShouldCloseTheFormAndProvideANullDateRange()
        {
            Expect.Once.On(view).Method("CloseForm");
            presenter.HandleCancelButtonClick(null, null);
            Assert.IsNull(presenter.DateRange);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnFormLoadTheFixedRangeDurationDefaultShouldBeSetTo3Months()
        {
            Expect.Once.On(view).SetProperty("SelectedFixedRangeDuration").To(Duration.OneMonth);
            Stub.On(view);
            presenter.HandleFormLoad(null, null);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void CustomStartAndEndDateEnteredAndSelectClickedShouldCloseFormAndProvideMatchingDateRange()
        {
            Expect.AtLeastOnce.On(view).GetProperty("CustomRangeChecked").Will(Return.Value(true));

            Date expectedStartDate = new Date(2006, 06, 21);
            Date expectedEndDate = new Date(2006, 07, 20);
            Expect.Once.On(view).GetProperty("StartDate").Will(Return.Value(expectedStartDate));
            Expect.Once.On(view).GetProperty("EndDate").Will(Return.Value(expectedEndDate));

            Expect.Once.On(view).Method("CloseForm");

            StubGetStatusCheckBoxValues();
            Stub.On(view);

            presenter.HandleSelectButtonClick(null, null);

            Assert.AreEqual(expectedStartDate, presenter.DateRange.LowerBound);
            Assert.AreEqual(expectedEndDate, presenter.DateRange.UpperBound);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        private void StubGetStatusCheckBoxValues()
        {
            Stub.On(view).GetProperty("ApprovedChecked").Will(Return.Value(true));
            Stub.On(view).GetProperty("ArchiveChecked").Will(Return.Value(false));
            Stub.On(view).GetProperty("CompletedChecked").Will(Return.Value(true));
            Stub.On(view).GetProperty("IssuedChecked").Will(Return.Value(true));
            Stub.On(view).GetProperty("PendingChecked").Will(Return.Value(true));
            Stub.On(view).GetProperty("RejectedCheck").Will(Return.Value(true));
        }

        [Test]
        public void OnFormLoadShouldCheckCustomRangeByDefault()
        {
            Expect.Once.On(view).SetProperty("CustomRangeChecked").To(true);
            Stub.On(view);

            presenter.HandleFormLoad(null, null);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void WhenSelectingFixedRangeTheCustomRangeDateSelectorsShouldBeDisabledAndTheFixedRangeInputShouldBeEnabled()
        {
            Expect.Once.On(view).SetProperty("FixedRangeDurationEnabled").To(true);
            Expect.Once.On(view).SetProperty("StartDateEnabled").To(false);
            Expect.Once.On(view).SetProperty("EndDateEnabled").To(false);

            presenter.HandleFixedRangeSelected(null, null);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void WhenSelectingCustomRangeTheFixedRangeInputShouldBeDisabledAndTheCustomRangeDateSelectorsShouldBeEnabled()
        {
            Expect.Once.On(view).SetProperty("FixedRangeDurationEnabled").To(false);
            Expect.Once.On(view).SetProperty("StartDateEnabled").To(true);
            Expect.Once.On(view).SetProperty("EndDateEnabled").To(true);

            presenter.HandleCustomRangeSelected(null, null);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void Select1YearBackFromTodayShouldProvideCorrectDateRange()
        {
            Date oneYearAgo = new Date(Clock.Now.Subtract(new TimeSpan(365, 0, 0, 0)));

            Expect.AtLeastOnce.On(view).GetProperty("CustomRangeChecked").Will(Return.Value(false));
            Expect.Once.On(view).Method("CloseForm");
            Expect.Once.On(view).GetProperty("SelectedFixedRangeDuration").Will(Return.Value(Duration.OneYear));
            Expect.Once.On(view).Method("DisplayWarningDialog").Will(Return.Value(DialogResult.Yes));

            StubGetStatusCheckBoxValues();
            Stub.On(view);

            presenter.HandleSelectButtonClick(null, null);
            Assert.AreEqual(oneYearAgo, presenter.DateRange.LowerBound);
            Assert.AreEqual(null, presenter.DateRange.UpperBound);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void Select6MonthsBackFromTodayShouldProvideCorrectDateRange()
        {
            Date sixMonthsAgo = new Date(Clock.Now.AddMonths(-6));

            Expect.AtLeastOnce.On(view).GetProperty("CustomRangeChecked").Will(Return.Value(false));
            Expect.Once.On(view).Method("CloseForm");
            Expect.Once.On(view).GetProperty("SelectedFixedRangeDuration").Will(Return.Value(Duration.SixMonths));
            Expect.Once.On(view).Method("DisplayWarningDialog").Will(Return.Value(DialogResult.Yes));

            StubGetStatusCheckBoxValues();
            Stub.On(view);

            presenter.HandleSelectButtonClick(null, null);
            Assert.AreEqual(sixMonthsAgo, presenter.DateRange.LowerBound);
            Assert.AreEqual(null, presenter.DateRange.UpperBound);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ClickingSelectWhenACustomRangeGreaterThanOneYearIsInputtedShouldRaiseAnErrorAndNotCloseTheForm()
        {
            Expect.AtLeastOnce.On(view).GetProperty("CustomRangeChecked").Will(Return.Value(true));

            Date expectedStartDate = new Date(2005, 06, 05);
            Date expectedEndDate = new Date(2006, 06, 06);
            Expect.Once.On(view).GetProperty("StartDate").Will(Return.Value(expectedStartDate));
            Expect.Once.On(view).GetProperty("EndDate").Will(Return.Value(expectedEndDate));

            Expect.Once.On(view).Method("DisplayErrorDialog").With("You can view a maximum of 1 year of data. Please enter a narrower start and end date.");
            Expect.Never.On(view).Method("CloseForm");

            presenter.HandleSelectButtonClick(null, null);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void EnteringACustomRangeInReverseOrderShouldReturnTheDateRangeInCorrectedOrderWithTheEarlierDateAsTheLowerBound()
        {
            Expect.AtLeastOnce.On(view).GetProperty("CustomRangeChecked").Will(Return.Value(true));

            Date expectedStartDate = new Date(2006, 06, 21);
            Date expectedEndDate = new Date(2006, 07, 20);
            Expect.AtLeastOnce.On(view).GetProperty("StartDate").Will(Return.Value(expectedEndDate));
            Expect.AtLeastOnce.On(view).GetProperty("EndDate").Will(Return.Value(expectedStartDate));

            Expect.Once.On(view).Method("CloseForm");

            StubGetStatusCheckBoxValues();
            Stub.On(view);

            presenter.HandleSelectButtonClick(null, null);

            Assert.AreEqual(expectedStartDate, presenter.DateRange.LowerBound);
            Assert.AreEqual(expectedEndDate, presenter.DateRange.UpperBound);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

    }
}
