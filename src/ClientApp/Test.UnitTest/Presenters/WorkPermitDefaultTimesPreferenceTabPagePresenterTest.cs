using System;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class WorkPermitDefaultTimesPreferenceTabPagePresenterTest
    {
        Mockery mocks;
        WorkPermitDefaultTimesPreferenceTabPagePresenter presenter;
        IWorkPermitDefaultTimesPreferenceTabPage page;
        UserWorkPermitDefaultTimePreferences preferences;

        [SetUp]
        public void Setup()
        {
            mocks = new Mockery();
            page = mocks.NewMock<IWorkPermitDefaultTimesPreferenceTabPage>();
            presenter = new WorkPermitDefaultTimesPreferenceTabPagePresenter(page);

            ClientSession.GetUserContext().User = UserFixture.CreateUserWithWorkPermitDefaultTimePreferences();
            preferences = ClientSession.GetUserContext().User.WorkPermitDefaultTimePreferences;
        }
        
        [Test]
        public void LoadShouldPopulateViewWithPreAndPostShiftPadding()
        {
            preferences.PreShiftPadding = new TimeSpan(01, 02, 03);
            preferences.PostShiftPadding = new TimeSpan(02, 03, 04);

            Expect.Once.On(page).SetProperty("PreShiftPadding").To(new TimeSpan(01, 02, 03));
            Expect.Once.On(page).SetProperty("PostShiftPadding").To(new TimeSpan(02, 03, 04));
            presenter.Load(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void UpdateShouldUpdatePreferencesInUserContextWitPaddingFromView()
        {
            preferences.PreShiftPadding = TimeSpan.Zero;
            preferences.PostShiftPadding = TimeSpan.Zero;

            Expect.Once.On(page).GetProperty("PreShiftPadding").Will(Return.Value(new TimeSpan(01, 01, 01)));
            Expect.Once.On(page).GetProperty("PostShiftPadding").Will(Return.Value(new TimeSpan(02, 02, 02)));
            
            presenter.Update();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateShouldFirstClearPreviousValidationErrorIndicatorsOnPage()
        {
            Expect.Once.On(page).Method("ClearValidationProviders");
            OltStub.On(page);
            
            presenter.Validate();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateWithPreShiftPaddingOutsideLimitShouldShowError()
        {
            Expect.Once.On(page).GetProperty("PreShiftPadding").
                Will(Return.Value(Common.Utility.Constants.WorkPermitTimePreferenceOffsetLimit.Add(OneMinute())));
            Expect.Once.On(page).GetProperty("PostShiftPadding").Will(Return.Value(new TimeSpan()));
            Expect.Once.On(page).Method("ShowPreShiftPaddingError");
            OltStub.On(page);
            
            Assert.IsFalse(presenter.Validate());
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateWithPostShiftPaddingOutsideLimitShouldShowError()
        {
            Expect.Once.On(page).GetProperty("PreShiftPadding").Will(Return.Value(new TimeSpan()));
            Expect.Once.On(page).GetProperty("PostShiftPadding").
                Will(Return.Value(Common.Utility.Constants.WorkPermitTimePreferenceOffsetLimit.Add(OneMinute())));
            Expect.Once.On(page).Method("ShowPostShiftPaddingError");
            OltStub.On(page);
            
            Assert.IsFalse(presenter.Validate());
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateWithNothingOutsideLimitShouldReturnTrue()
        {
            Expect.Once.On(page).Method("ClearValidationProviders");
            Expect.Once.On(page).GetProperty("PreShiftPadding").Will(Return.Value(new TimeSpan()));
            Expect.Once.On(page).GetProperty("PostShiftPadding").Will(Return.Value(new TimeSpan()));
            Assert.IsTrue(presenter.Validate());
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private TimeSpan OneMinute()
        {
            return new TimeSpan(01, 00, 00);
        }
    }
}
