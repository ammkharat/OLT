using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class PreferencesPresenterTest
    {
        private PreferencesPresenter presenter;
        
        private Mockery mocks;
        
        private IUserService mockUserService; 
        private IPreferencesView mockView;
        private IPreferenceTabPage mockTabPage;

        private List<IPreferenceTabPage> preferenceList;

        [SetUp]
        public void SetUp()
        {
            ClientSession.GetUserContext().User = UserFixture.CreateOilSandsUserWithUserPrintPreference();

            mocks = new Mockery();
            mockUserService = mocks.NewMock<IUserService>();
            mockView = mocks.NewMock<IPreferencesView>();
            mockTabPage = mocks.NewMock<IPreferenceTabPage>();
                        
            preferenceList = new List<IPreferenceTabPage>();
            preferenceList.Add(mockTabPage);

            presenter = new PreferencesPresenter(mockView, mockUserService);
        }

        [TearDown]
        public void TearDown()
        {
            mocks.VerifyAllExpectationsHaveBeenMet();           
        }

        [Test]
        public void ShouldChangeTitleBarWhenPreferencesFormIsLoaded()
        {
            Expect.Once.On(mockView).SetProperty("Title");

            presenter.Load(this, EventArgs.Empty);
        }

        [Test]
        public void IfValidUpdateEachUserPreferenceAndSaveWhenButtonIsClicked()
        {
            Expect.Once.On(mockView).GetProperty("Tabs").Will(Return.Value(preferenceList));

            foreach (IPreferenceTabPage page in preferenceList)
            {
                Expect.Once.On(page).GetProperty("IsTabValid").Will(Return.Value(true));
                Expect.Once.On(page).Method("UpdatePreference");
            }

            Expect.Once.On(mockUserService).Method("UpdatePrintPreferences")
                .With(ClientSession.GetUserContext().User)
                .Will(Return.Value(ClientSession.GetUserContext().User.WorkPermitPrintPreference));
            Expect.Once.On(mockUserService).Method("UpdateWorkPermitDefaultTimesPreferences").With(ClientSession.GetUserContext().User);
            Expect.Once.On(mockView).Method("SaveSucceededMessage");
            Expect.Once.On(mockView).Method("Close");
            
            Expect.Never.On(mockView).Method("SaveFailedMessage");
            
            presenter.Save(this, EventArgs.Empty);
        }

        [Test]
        public void IfValidationFailsDoNotUpdateOrSaveWhenButtonIsClicked()
        {
            Expect.Once.On(mockView).GetProperty("Tabs").Will(Return.Value(preferenceList));

            foreach (IPreferenceTabPage page in preferenceList)
            {
                Expect.Once.On(page).GetProperty("IsTabValid").Will(Return.Value(false));
                Expect.Never.On(page).Method("UpdatePreference");
            }

            Expect.Never.On(mockUserService).Method("UpdatePrintPreferences").With(ClientSession.GetUserContext().User);
            Expect.Never.On(mockView).Method("SaveSucceededMessage");
            Expect.Never.On(mockView).Method("Close");

            presenter.Save(this, EventArgs.Empty);
        }

        [Test]
        public void IfValidationFailsOnOneTabShouldNotUpdateOrSaveWhenButtonIsClicked()
        {
            IPreferenceTabPage mockTabPage2 = mocks.NewMock<IPreferenceTabPage>();
            preferenceList.Add(mockTabPage2);

            Expect.AtLeastOnce.On(mockView).GetProperty("Tabs").Will(Return.Value(preferenceList));
            Expect.Once.On(mockTabPage).GetProperty("IsTabValid").Will(Return.Value(false));
            Expect.AtMost(1).On(mockTabPage2).GetProperty("IsTabValid").Will(Return.Value(true));

            presenter.Save(null, null);
        }

        [Test]
        public void ShouldShowFailedSaveMessageWhenExceptionOccursOnPreferenceSave()
        {
            Expect.Once.On(mockView).GetProperty("Tabs").Will(Return.Value(preferenceList));

            foreach (IPreferenceTabPage page in preferenceList)
            {
                Expect.Once.On(page).GetProperty("IsTabValid").Will(Return.Value(true));
                Expect.Once.On(page).Method("UpdatePreference");
            }

            Expect.Once.On(mockUserService).Method("UpdatePrintPreferences")
                .With(ClientSession.GetUserContext().User)
                .Will(Throw.Exception(new ApplicationException()));

            Expect.Never.On(mockView).Method("SaveSucceededMessage");
            Expect.Never.On(mockView).Method("Close");

            Expect.Once.On(mockView).Method("SaveFailedMessage"); 
            
            presenter.Save(this, EventArgs.Empty);
        }
    }
}