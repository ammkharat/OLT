using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class UserServiceTest
    {
        private Mockery mocks;
        private UserService userService;
        private IUserDao mockDao;
        private IUserDTODao mockDTODao;
        private IUserPrintPreferenceDao mockPrintPreferenceDao;
        private IRoleElementDao mockRoleElementDao;
        private IUserWorkPermitDefaultTimePreferencesDao mockWorkPermitDefaultTimePreferencesDao;
        private ISiteDao mockSiteDao;
        private IUserGridLayoutDao mockUserGridLayoutDao;
        private IUserPreferencesDao mockUserPreferencesDao;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockDao = mocks.NewMock<IUserDao>();
            mockDTODao = mocks.NewMock<IUserDTODao>();
            mockPrintPreferenceDao = mocks.NewMock<IUserPrintPreferenceDao>();
            mockUserPreferencesDao = mocks.NewMock<IUserPreferencesDao>();
            mockRoleElementDao = mocks.NewMock<IRoleElementDao>();
            mockWorkPermitDefaultTimePreferencesDao = mocks.NewMock<IUserWorkPermitDefaultTimePreferencesDao>();
            mockSiteDao = mocks.NewMock<ISiteDao>();
            mockUserGridLayoutDao = mocks.NewMock<IUserGridLayoutDao>();

            DaoRegistry.Clear();

            DaoRegistry.RegisterDaoFor(mockPrintPreferenceDao); 
            DaoRegistry.RegisterDaoFor(mockUserPreferencesDao); 
            DaoRegistry.RegisterDaoFor(mockDao);
            DaoRegistry.RegisterDaoFor(mockDTODao);
            DaoRegistry.RegisterDaoFor(mockRoleElementDao);
            DaoRegistry.RegisterDaoFor(mockWorkPermitDefaultTimePreferencesDao);
            DaoRegistry.RegisterDaoFor(mockSiteDao);
            DaoRegistry.RegisterDaoFor(mockUserGridLayoutDao);

            userService = new UserService();
        }

        [TearDown]
        public void TearDown()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldReturnSAPUser()
        {
            User expectedUser = UserFixture.CreateUser();
            Expect.Once.On(mockDao).Method("QueryById")
                .With(UserService.SAP_USER_ID)
                .Will(Return.Value(expectedUser));

            User sapUser = userService.GetSAPUser();

            Assert.AreSame(expectedUser, sapUser);
            Assert.AreEqual(expectedUser.AvailableSites.Count, sapUser.AvailableSites.Count);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldReturnRemoteAppUser()
        {
            User expectedUser = UserFixture.CreateUser();
            Expect.Once.On(mockDao).Method("QueryById")
                .With(UserService.REMOTER_APP_USER_ID)
                .Will(Return.Value(expectedUser));

            // Execute:
            User remoteAppUser = userService.GetRemoteAppUser();

            Assert.AreSame(expectedUser, remoteAppUser);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        [ExpectedException(typeof (ApplicationException))]
        public void ShouldFailIfCannotFindSAPUser()
        {
            Expect.Once.On(mockDao).Method("QueryById")
                .With(UserService.SAP_USER_ID)
                .Will(Return.Value(null));

            // We should ALWAYS be able to get the SAP import user!
            userService.GetSAPUser();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldCreateNewUserPrintPreferenceWhenOneDoesnotExist()
        {
            User user = UserFixture.CreateOilSandsUserWithUserPrintPreference(); 
            UserPrintPreference preference = UserPrintPreferenceFixture.CreateWorkPermitPrintPreference(user);
            
            Expect.Once.On(mockPrintPreferenceDao).Method("QueryByUserId").With(user.Id).Will(Return.Value(null));
            Expect.Once.On(mockPrintPreferenceDao).Method("Insert").With(user.WorkPermitPrintPreference).Will(Return.Value(user.WorkPermitPrintPreference));
            
            userService.UpdatePrintPreferences(user);
            
            Assert.AreEqual(preference, user.WorkPermitPrintPreference);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Ignore] [Test]
        public void ShouldUpdateUserPrintPreferenceWhenOneExists()
        {
            const string printerName = "newPrinter";
            const int numCopies = 5;
            const bool showDialog = true;
            const bool showShiftHandoverAlertdialog = true;
            const bool showSoundAlertforActionItemDirectiveTargets = true;

            User user = UserFixture.CreateOilSandsUserWithUserPrintPreference(printerName, numCopies, showDialog, showShiftHandoverAlertdialog, showSoundAlertforActionItemDirectiveTargets);
            UserPrintPreference prefInDb = UserPrintPreferenceFixture.CreateWorkPermitPrintPreference(user);

            Expect.Once.On(mockPrintPreferenceDao).Method("QueryByUserId").With(user.Id).Will(Return.Value(prefInDb));
            Expect.Once.On(mockPrintPreferenceDao).Method("Update").With(user.WorkPermitPrintPreference);
            
            userService.UpdatePrintPreferences(user);

            Assert.AreEqual(printerName, user.WorkPermitPrintPreference.PrinterName);
            Assert.AreEqual(numCopies, user.WorkPermitPrintPreference.NumberOfCopies);
            Assert.AreEqual(showDialog, user.WorkPermitPrintPreference.ShowPrintDialog);
            Assert.AreEqual(showShiftHandoverAlertdialog,user.WorkPermitPrintPreference.ShowShiftHandoverAlertDialog);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }
    }
}