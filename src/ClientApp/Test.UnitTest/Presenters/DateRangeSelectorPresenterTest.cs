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
    public class DateRangeSelectorPresenterTest
    {
        Mockery mocks;
        IDateRangeSelectorFormView view;
        DateRangeSelectorPresenter presenter;
        Date today;
        
        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            view = mocks.NewMock<IDateRangeSelectorFormView>();
            presenter = new DateRangeSelectorPresenter(view);
            Clock.Freeze();
            Clock.Now = new DateTime(2006, 06, 05, 13, 05, 00);
            today = new Date(Clock.Now);
            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            ClientSession.GetUserContext().User = user;
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }
        
        [Test]
        public void CancellingShouldCloseTheFormAndProvideANullDateRange()
        {
            Expect.Once.On(view).Method("Close");
            presenter.HandleCancelButtonClicked(null, null);
            Assert.IsNull(presenter.DateRange);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void CustomStartAndEndDateEnteredAndSelectClickedShouldCloseFormAndProvideMatchingDateRange()
        {
            Expect.Once.On(view).GetProperty("CustomRangeChecked").Will(Return.Value(true));
            
            Date expectedStartDate = new Date(2006, 06, 21);
            Date expectedEndDate = new Date(2006, 07, 20);
            Expect.Once.On(view).GetProperty("StartDate").Will(Return.Value(expectedStartDate));
            Expect.Once.On(view).GetProperty("EndDate").Will(Return.Value(expectedEndDate));

            Expect.Once.On(view).Method("Close");
            Stub.On(view).SetProperty("DialogResult");
            
            presenter.HandleSelectButtonClicked(null, null);
            
            Assert.AreEqual(expectedStartDate, presenter.DateRange.LowerBound);
            Assert.AreEqual(expectedEndDate, presenter.DateRange.UpperBound);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void OnFormLoadTheFixedRangeDurationsShouldBeInitialized()
        {
            Expect.Once.On(view).Method("AddFixedRangeDuration").With(Duration.OneYear);
            Expect.Once.On(view).Method("AddFixedRangeDuration").With(Duration.OneMonth);
            Expect.Once.On(view).Method("AddFixedRangeDuration").With(Duration.ThreeMonths);
            Expect.Once.On(view).Method("AddFixedRangeDuration").With(Duration.SixMonths);
            Stub.On(view);
            presenter.HandleFormLoad(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnFormLoadTheFixedRangeDurationDefaultShouldBeSetTo3Months()
        {
            Expect.Once.On(view).SetProperty("SelectedFixedRangeDuration").To(Duration.ThreeMonths);
            Stub.On(view);
            presenter.HandleFormLoad(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnFormLoadShouldCheckCustomRangeByDefault()
        {
            Expect.Once.On(view).SetProperty("CustomRangeChecked").To(true);
            Stub.On(view);

            presenter.HandleFormLoad(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void WhenSelectingFixedRangeTheCustomRangeDateSelectorsShouldBeDisabledAndTheFixedRangeInputShouldBeEnabled()
        {
            Expect.Once.On(view).SetProperty("FixedRangeDurationEnabled").To(true);
            Expect.Once.On(view).SetProperty("StartDateEnabled").To(false);
            Expect.Once.On(view).SetProperty("EndDateEnabled").To(false);
            
            presenter.HandleFixedRangeSelected(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void WhenSelectingCustomRangeTheFixedRangeInputShouldBeDisabledAndTheCustomRangeDateSelectorsShouldBeEnabled()
        {
            Expect.Once.On(view).SetProperty("FixedRangeDurationEnabled").To(false);
            Expect.Once.On(view).SetProperty("StartDateEnabled").To(true);
            Expect.Once.On(view).SetProperty("EndDateEnabled").To(true);
            
            presenter.HandleCustomRangeSelected(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
    
        [Test]
        public void Select1YearBackFrormTodayShouldProvideCorrectDateRange()
        {
            Date oneYearAgo = new Date(Clock.Now.Subtract(new TimeSpan(365, 0, 0, 0)));

            Expect.Once.On(view).GetProperty("CustomRangeChecked").Will(Return.Value(false));
            Expect.Once.On(view).Method("Close");
            Stub.On(view).SetProperty("DialogResult");
            Expect.Once.On(view).GetProperty("SelectedFixedRangeDuration").Will(Return.Value(Duration.OneYear));
            Expect.Once.On(view).Method("DisplayWarningDialog").Will(Return.Value(DialogResult.Yes));

            presenter.HandleSelectButtonClicked(null, null);
            Assert.AreEqual(oneYearAgo, presenter.DateRange.LowerBound);
            Assert.AreEqual(today, presenter.DateRange.UpperBound);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void Select6MonthsBackFromTodayShouldProvideCorrectDateRange()
        {
            Date sixMonthsAgo = new Date(Clock.Now.AddMonths(-6));

            Expect.Once.On(view).GetProperty("CustomRangeChecked").Will(Return.Value(false));
            Expect.Once.On(view).Method("Close");
            Stub.On(view).SetProperty("DialogResult");
            Expect.Once.On(view).GetProperty("SelectedFixedRangeDuration").Will(Return.Value(Duration.SixMonths));
            Expect.Once.On(view).Method("DisplayWarningDialog").Will(Return.Value(DialogResult.Yes));

            presenter.HandleSelectButtonClicked(null, null);
            Assert.AreEqual(sixMonthsAgo, presenter.DateRange.LowerBound);
            Assert.AreEqual(today, presenter.DateRange.UpperBound);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void ClickingSelectWhenACustomRangeGreaterThanOneYearIsInputtedShouldRaiseAnErrorAndNotCloseTheForm()
        {
            Expect.Once.On(view).GetProperty("CustomRangeChecked").Will(Return.Value(true));

            Date expectedStartDate = new Date(2005, 06, 05);
            Date expectedEndDate = new Date(2006, 06, 06);
            Expect.Once.On(view).GetProperty("StartDate").Will(Return.Value(expectedStartDate));
            Expect.Once.On(view).GetProperty("EndDate").Will(Return.Value(expectedEndDate));
            
            Expect.Once.On(view).Method("DisplayErrorDialog").With("You can view a maximum of 1 year of data. Please enter a narrower start and end date.");
            Expect.Never.On(view).Method("Close");

            presenter.HandleSelectButtonClicked(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test][Ignore]
        public void EnteringACustomRangeInReverseOrderShouldReturnTheDateRangeInCorrectedOrderWithTheEarlierDateAsTheLowerBound()
        {
            Expect.Once.On(view).GetProperty("CustomRangeChecked").Will(Return.Value(true));

            Date expectedStartDate = new Date(2006, 06, 21);
            Date expectedEndDate = new Date(2006, 07, 20);
            Expect.AtLeastOnce.On(view).GetProperty("StartDate").Will(Return.Value(expectedEndDate));
            Expect.AtLeastOnce.On(view).GetProperty("EndDate").Will(Return.Value(expectedStartDate));

            Expect.Once.On(view).Method("Close");
            Stub.On(view).SetProperty("DialogResult");

            presenter.HandleSelectButtonClicked(null, null);

            Assert.AreEqual(expectedStartDate, presenter.DateRange.LowerBound);
            Assert.AreEqual(expectedEndDate, presenter.DateRange.UpperBound);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
    }
}
