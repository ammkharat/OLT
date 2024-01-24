using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class WorkPermitPrintPreferenceTabPagePresenterTest
    {
        private List<string> printers;
        private User user;
        private SiteConfiguration siteConfiguration;

        private Mockery mocks;
        private IWorkPermitPrintPreferenceTabPage mockTabPage;

        private ExtendedWorkPermitPrintPreferencePagePresenter presenter;

        [SetUp]
        public void Setup()
        {
            printers = CreatePrinterList();
            user = UserFixture.CreateOilSandsUserWithUserPrintPreference();
            ClientSession.GetUserContext().User = user;
            siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia(), false);
            ClientSession.GetUserContext().SetSite(SiteFixture.Sarnia(), siteConfiguration);

            mocks = new Mockery();
            mockTabPage = mocks.NewMock<IWorkPermitPrintPreferenceTabPage>();

            presenter = new ExtendedWorkPermitPrintPreferencePagePresenter(mockTabPage);
            presenter.printers = printers;
        }

        [TearDown]
        public void TearDown()
        {
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test][Ignore]
        public void ShouldLoadForUserWithNoPrintPreference()
        {
            
            Stub.On(mockTabPage).SetProperty("NumberOfCopiesValueList");
            Stub.On(mockTabPage).SetProperty("NumberOfTurnaroundCopiesValueList");

            Expect.Once.On(mockTabPage).GetProperty("IsDesignMode").Will(Return.Value(false));
            Expect.Once.On(mockTabPage).SetProperty("ShowAlternativeNumberOfCopiesLabel").To(false);
            Expect.Once.On(mockTabPage).SetProperty("AvailablePrinters").To(printers);
            Expect.Once.On(mockTabPage).SetProperty("PrinterName").To(user.WorkPermitPrintPreference.PrinterName);
            Expect.Once.On(mockTabPage).SetProperty("NumberOfCopies").To(user.WorkPermitPrintPreference.NumberOfCopies);
            Expect.Once.On(mockTabPage).SetProperty("NumberOfTurnaroundCopies").To(user.WorkPermitPrintPreference.NumberOfTurnaroundCopies);
            Expect.Once.On(mockTabPage).SetProperty("ShowPrintDialog").To(user.WorkPermitPrintPreference.ShowPrintDialog);
            Expect.Once.On(mockTabPage).SetProperty("NumberOfCopiesVisible").To(siteConfiguration.ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab);
            Expect.Once.On(mockTabPage).SetProperty("NumberOfTACopiesVisible").To(siteConfiguration.ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab);

            presenter.HandleFormLoad();
        }

        [Test]
        public void ShouldUpdateUserPrintPreference()
        {
            string selectedPrinter = "Printer1";
            int copies = 2;
            int turnaroundCopies = 3;
            bool showDialog = true;

            Expect.AtLeastOnce.On(mockTabPage).GetProperty("PrinterName").Will(Return.Value(selectedPrinter));
            Expect.Once.On(mockTabPage).GetProperty("NumberOfCopies").Will(Return.Value(copies));
            Expect.Once.On(mockTabPage).GetProperty("NumberOfTurnaroundCopies").Will(Return.Value(3));
            Expect.Once.On(mockTabPage).GetProperty("ShowPrintDialog").Will(Return.Value(showDialog));
            

            presenter.Update();

            Assert.AreEqual(selectedPrinter, user.WorkPermitPrintPreference.PrinterName);
            Assert.AreEqual(copies, user.WorkPermitPrintPreference.NumberOfCopies);
            Assert.AreEqual(showDialog, user.WorkPermitPrintPreference.ShowPrintDialog);
        }

        public List<string> CreatePrinterList()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                list.Add("Printer" + i);
            }
            return list;
        }

        private class ExtendedWorkPermitPrintPreferencePagePresenter : WorkPermitPrintPreferenceTabPagePresenter
        {
            public List<string> printers;

            public ExtendedWorkPermitPrintPreferencePagePresenter(IWorkPermitPrintPreferenceTabPage tabPage) : base(tabPage)
            {
            }

            protected override List<string> GetInstalledPrinters()
            {
                return printers;
            }
        }
    }
}