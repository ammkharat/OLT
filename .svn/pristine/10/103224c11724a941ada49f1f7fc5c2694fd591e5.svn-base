using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Client.Presenters
{

    [TestFixture]
    public class ConfigureSiteContractorPresenterTest
    {
        private Mockery mocks;
        private IConfigureSiteContractorView viewMock;
        private IContractorService serviceMock;
        private Site site;
        private ConfigureSiteContractorPresenter presenter;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            viewMock = mocks.NewMock<IConfigureSiteContractorView>();
            serviceMock = mocks.NewMock<IContractorService>();
            presenter = new ConfigureSiteContractorPresenter(viewMock, serviceMock);
            site = SiteFixture.Sarnia();
        }

        [TearDown]
        public void TearDown()
        {            
        }
        
        [Test]
        public void OnLoadShouldPopulateSiteContractors()
        {
            List<Contractor> contractorList = new List<Contractor>();
            Expect.Once.On(serviceMock).Method("QueryBySite").With(site).Will(Return.Value(contractorList));

            Expect.Once.On(viewMock).SetProperty("ContractorSite").To(site);
            Expect.Once.On(viewMock).SetProperty("Contractors").To(contractorList);

            Stub.On(viewMock).SetProperty("AddOrUpdateEnabled");
            Stub.On(viewMock).SetProperty("DeleteEnabled");
            Stub.On(viewMock).SetProperty("ClearEnabled");

            Stub.On(viewMock).SetProperty("AddUpdateText");

            ClientSession.GetUserContext().User = UserFixture.CreateUser(site);
            presenter.LoadView();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnLoadShouldDisableActionButtonsAndSetAddUpdateButtonToAdd()
        {
            Stub.On(serviceMock).Method("QueryBySite");
            Stub.On(viewMock).SetProperty("ContractorSite");
            Stub.On(viewMock).SetProperty("Contractors");
            
            Expect.Once.On(viewMock).SetProperty("AddOrUpdateEnabled").To(false);
            Expect.Once.On(viewMock).SetProperty("DeleteEnabled").To(false);
            Expect.Once.On(viewMock).SetProperty("ClearEnabled").To(false);

            Expect.Once.On(viewMock).SetProperty("AddUpdateText").To(StringResources.AddButtonLabel);
            
            presenter.LoadView();
            
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void WhenNameIsFilledInAddUpdateAndClearButtonsAreEnabledAndDeleteIsDisabled()
        {
            Expect.Once.On(viewMock).GetProperty("ContractorName").Will(Return.Value("Eric's Plumbing"));

            Expect.Once.On(viewMock).SetProperty("AddOrUpdateEnabled").To(true);
            Expect.Once.On(viewMock).SetProperty("DeleteEnabled").To(false);
            Expect.Once.On(viewMock).SetProperty("ClearEnabled").To(true);
            
            presenter.ContractorInformationChanged();
            
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void WhenNameIsEmptyShouldDisableAllActionButtons()
        {
            Expect.Once.On(viewMock).GetProperty("ContractorName").Will(Return.Value(string.Empty));

            Expect.Once.On(viewMock).SetProperty("AddOrUpdateEnabled").To(false);
            Expect.Once.On(viewMock).SetProperty("DeleteEnabled").To(false);
            Expect.Once.On(viewMock).SetProperty("ClearEnabled").To(false);
            
            presenter.ContractorInformationChanged();
            
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnAddShouldAddNewContractorToContractorListAndClearNameTextBoxAndDisableButtons()
        {
            Expect.Once.On(viewMock).GetProperty("SelectedContractor").Will(Return.Value(null));
            
            Expect.Once.On(viewMock).GetProperty("ContractorName").Will(Return.Value("Zeppelin Air"));

            List<Contractor> contractors = new List<Contractor>();
            Expect.Once.On(viewMock).GetProperty("Contractors").Will(Return.Value(contractors));
            Expect.Once.On(viewMock).SetProperty("Contractors").
                To(new FirstListElementMatcher<Contractor>(HasProperty("CompanyName", "Zeppelin Air") &
                                                           HasProperty("Site", site)));

            SetExpectationsForHandlingClear();

            ClientSession.GetUserContext().User = UserFixture.CreateUser(site);
            presenter.AddOrUpdate();
            
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnAddContractorWithSameNameAsExistingContractorInSiteShouldShowExistingContractorMessage()
        {
            Expect.Once.On(viewMock).GetProperty("SelectedContractor").Will(Return.Value(null));

            Expect.Once.On(viewMock).GetProperty("ContractorName").Will(Return.Value("ABC Company"));

            Contractor existingContractor = ContractorFixture.CreateContractor("ABC Company", site);
            Expect.Once.On(viewMock).GetProperty("Contractors").Will(Return.Value(new List<Contractor> { existingContractor }));

            SetExpectationForShowingDuplicateContractorMessage();

            ClientSession.GetUserContext().User = UserFixture.CreateUser(site);
            presenter.AddOrUpdate();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnAddContractorWithSameNamePlusSpaceAsExistingContractorInSiteShouldShowExistingContractorMessage()
        {
            Expect.Once.On(viewMock).GetProperty("SelectedContractor").Will(Return.Value(null));

            Expect.Once.On(viewMock).GetProperty("ContractorName").Will(Return.Value("ABC Company "));

            Contractor existingContractor = ContractorFixture.CreateContractor("ABC Company", site);
            Expect.Once.On(viewMock).GetProperty("Contractors").Will(Return.Value(new List<Contractor> { existingContractor }));

            SetExpectationForShowingDuplicateContractorMessage();

            ClientSession.GetUserContext().User = UserFixture.CreateUser(site);
            presenter.AddOrUpdate();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnClearShouldClearNameTextBoxAndDisableActionsAndClearSelectedContractor()
        {
            SetExpectationsForHandlingClear();

            presenter.Clear();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void WhenContractorIsSelectedContractorInfoIsSetAndButtonsAreEnabled()
        {
            Contractor contractor = ContractorFixture.CreateContractor(1, "Zeppelin Air");
            
            Expect.Once.On(viewMock).GetProperty("SelectedContractor").Will(Return.Value(contractor));
            
            Expect.Once.On(viewMock).SetProperty("ContractorName").To(contractor.CompanyName);
            
            Expect.Once.On(viewMock).SetProperty("AddOrUpdateEnabled").To(true);
            Expect.Once.On(viewMock).SetProperty("DeleteEnabled").To(true);
            Expect.Once.On(viewMock).SetProperty("ClearEnabled").To(true);

            Expect.Once.On(viewMock).SetProperty("AddUpdateText").To(StringResources.UpdateButtonLabel);
            
            presenter.ContractorSelected();
            
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnDeleteRemoveContractorFromContractorListAndHandleClear()
        {
            Contractor contractor = ContractorFixture.CreateContractor(1, "Zeppelin Air");
            Expect.Once.On(viewMock).GetProperty("SelectedContractor").Will(Return.Value(contractor));
            
            List<Contractor> contractorList = new List<Contractor>(new[] { contractor });
            Expect.Once.On(viewMock).GetProperty("Contractors").Will(Return.Value(contractorList));

            Expect.Once.On(viewMock).SetProperty("Contractors").To(new ListCountMatcher(0));
            
            SetExpectationsForHandlingClear();
            
            presenter.Delete();
            
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnUpdateShouldUpdateTheContractorInTheListAndHandleClear()
        {
            Contractor contractor = ContractorFixture.CreateContractor(1, "Zeppelin Air");
            Expect.Once.On(viewMock).GetProperty("SelectedContractor").Will(Return.Value(contractor));

            Expect.Once.On(viewMock).GetProperty("ContractorName").Will(Return.Value("New name"));

            List<Contractor> contractorList = new List<Contractor>(new[] { contractor });
            Expect.Once.On(viewMock).GetProperty("Contractors").Will(Return.Value(contractorList));

            Expect.Once.On(viewMock).SetProperty("Contractors").To(new FirstListElementMatcher<Contractor>(HasProperty("CompanyName", "New name")));

            SetExpectationsForHandlingClear();

            presenter.AddOrUpdate();
            
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnUpdateWithSameNameAsOtherContractorShouldShowExistingContractorMessage()
        {
            Contractor contractor1 = ContractorFixture.CreateContractor(1, "Zeppelin Air");
            Expect.Once.On(viewMock).GetProperty("SelectedContractor").Will(Return.Value(contractor1));

            Expect.Once.On(viewMock).GetProperty("ContractorName").Will(Return.Value("ABC Company"));

            Contractor contractor2 = ContractorFixture.CreateContractor(2, "ABC Company");
            List<Contractor> contractorList = new List<Contractor>(new 
                Contractor[] { contractor1, contractor2 });
            Expect.Once.On(viewMock).GetProperty("Contractors").Will(Return.Value(contractorList));

            SetExpectationForShowingDuplicateContractorMessage();

            presenter.AddOrUpdate();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnSaveShouldUpdateSiteContractorsAndCloseView()
        {
            List<Contractor> contractorList = new List<Contractor>();
            Expect.Once.On(viewMock).GetProperty("Contractors").Will(Return.Value(contractorList));

            Expect.Once.On(serviceMock).Method("UpdateContractors").With(Is.EqualTo(site), Is.Same(contractorList));

            Expect.Once.On(viewMock).Method("Close");

            ClientSession.GetUserContext().User = UserFixture.CreateUser(site);
            presenter.Save();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnCloseViewAfterSaveShouldNotAskUserToConfirmCloseView()
        {
            StubExpectationsForSave();
            presenter.Save();
            
            FormClosingEventArgs e = new FormClosingEventArgs(CloseReason.UserClosing, false);
            presenter.ViewClosing(e);

            Assert.IsFalse(e.Cancel);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldRegisterToViewEvents()
        {
            Expect.Once.On(viewMock).EventAdd("Load", new EventHandler(presenter.HandleLoad));
            Expect.Once.On(viewMock).EventAdd("ContractorInformationChanged", new EventHandler(presenter.HandleContractorInformationChanged));
            Expect.Once.On(viewMock).EventAdd("AddOrUpdate", new EventHandler(presenter.HandleAddOrUpdate));
            Expect.Once.On(viewMock).EventAdd("Delete", new EventHandler(presenter.HandleDelete));
            Expect.Once.On(viewMock).EventAdd("Clear", new EventHandler(presenter.HandleClear));
            Expect.Once.On(viewMock).EventAdd("ContractorSelected", new EventHandler(presenter.HandleContractorSelected));
            Expect.Once.On(viewMock).EventAdd("Save", new EventHandler(presenter.HandleSave));
            Expect.Once.On(viewMock).EventAdd("ViewClosing", new FormClosingEventHandler(presenter.HandleViewClosing));

            presenter.RegisterToViewEvents();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void SetExpectationsForHandlingClear()
        {
            Expect.Once.On(viewMock).SetProperty("ContractorName").To(string.Empty);

            Expect.Once.On(viewMock).SetProperty("AddOrUpdateEnabled").To(false);
            Expect.Once.On(viewMock).SetProperty("DeleteEnabled").To(false);
            Expect.Once.On(viewMock).SetProperty("ClearEnabled").To(false);

            Expect.Once.On(viewMock).SetProperty("AddUpdateText").To(StringResources.AddButtonLabel);
            
            Expect.Once.On(viewMock).Method("ClearSelectedContractor");
        }

        private void SetExpectationForShowingDuplicateContractorMessage()
        {
            Expect.Once.On(viewMock).Method("ShowWarningMessage").With(StringResources.DuplicateContractorMessage, StringResources.DuplicateContractorTitle);
        }

        private void StubExpectationsForSave()
        {
            Stub.On(viewMock).GetProperty("Contractors").Will(Return.Value(new List<Contractor>()));
            Stub.On(serviceMock).Method("UpdateContractors");
            Stub.On(viewMock).Method("Close");
        }

        private Matcher HasProperty(string propertyName, object expectedValue)
        {
            return new OltPropertyMatcher<Contractor>(propertyName, expectedValue);
        }
    }
}
