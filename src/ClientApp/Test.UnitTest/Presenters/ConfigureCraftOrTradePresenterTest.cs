using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class ConfigureCraftOrTradePresenterTest
    {
        private Mockery mocks;
        private IConfigureCraftOrTradeView viewMock;
        private ICraftOrTradeService serviceMock;
        private Site site;
        private ConfigureCraftOrTradePresenter presenter;
        private List<CraftOrTrade> craftOrTrades;
        private UserContext userContext;
        private CraftOrTrade craftOrTradeToEdit;
        
        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            viewMock = mocks.NewMock<IConfigureCraftOrTradeView>();
            serviceMock = mocks.NewMock<ICraftOrTradeService>();
            presenter = new ConfigureCraftOrTradePresenter(viewMock, serviceMock);
            site = SiteFixture.Sarnia();
            ClientSession.GetNewInstance();
            userContext = ClientSession.GetUserContext();
            userContext.User = UserFixture.CreateUser(site);
            craftOrTradeToEdit = CraftOrTradeFixture.CreateNewCraftOrTrade(site);
            craftOrTrades = new List<CraftOrTrade>();         
        }

        [TearDown]
        public void TearDown()
        {
        }
        
        [Test]
        public void OnLoadShouldPopulateCraftOrTrades()
        {
            Expect.Once.On(serviceMock).Method("QueryBySiteNoCache").With(site).Will(Return.Value(craftOrTrades));
            Expect.Once.On(viewMock).SetProperty("CraftOrTradeSite").To(site.Name);
            Expect.Once.On(viewMock).SetProperty("CraftOrTrades").To(craftOrTrades);

            presenter.HandleLoad(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void OnNewShouldCreateCraftOrTradesAndRefreshViewIfUserSaves()
        {
            SetupExpectationsForLoadingCraftsOrTrades();
            Expect.Once.On(viewMock).Method("CreateNewCraftOrTrade").Will(Return.Value(DialogResult.OK));
            presenter.New();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void OnNewShouldSetSelectedCraftOrTradeToCraftOrTradeWithHighestId()
        {            
            Expect.Once.On(viewMock).Method("CreateNewCraftOrTrade").Will(Return.Value(DialogResult.OK));
            
            CraftOrTrade craftOrTradeWithIdOne = CraftOrTradeFixture.CreateCraftOrTradeThatMapsToDB();
            CraftOrTrade craftOrTradeWithIdTwo = CraftOrTradeFixture.CreateCraftOrTradePipeFitter();
            List<CraftOrTrade> list  = new List<CraftOrTrade> {craftOrTradeWithIdOne, craftOrTradeWithIdTwo};

            Expect.Once.On(serviceMock).Method("QueryBySiteNoCache").With(userContext.Site).Will(Return.Value(list));
            Expect.Once.On(viewMock).SetProperty("CraftOrTrades").To(list);
            Expect.Once.On(viewMock).SetProperty("SelectedCraftOrTrade").To(craftOrTradeWithIdTwo);
            presenter.New();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void OnNewShouldDisplayCreateCraftOrTradesAndNotRefreshViewIfUserCancels()
        {            
            Expect.Once.On(viewMock).Method("CreateNewCraftOrTrade").Will(Return.Value(DialogResult.Cancel));
            SetupExpectationsForNotLoadingCraftOrTrades();
            presenter.New();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnEditShouldDisplayEditCraftOrTradesAndNotRefreshViewIfUserCancels()
        {
            Expect.Once.On(viewMock).Method("EditCraftOrTrade").Will(Return.Value(DialogResult.Cancel));
            SetupExpectationsForNotLoadingCraftOrTrades();
            presenter.Edit(craftOrTradeToEdit);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void OnEditShouldDisplayEditCraftOrTradeAndRefreshViewIfUserSaves()
        {
            Expect.Once.On(viewMock).GetProperty("SelectedCraftOrTrade").Will(Return.Value(craftOrTradeToEdit));
            Expect.Once.On(viewMock).Method("EditCraftOrTrade").With(craftOrTradeToEdit).Will(Return.Value(DialogResult.OK));
            SetupExpectationsForLoadingCraftsOrTrades();
            SetupExpectationForReSelectingCraftOrTradeAfterEdit(craftOrTradeToEdit);
            presenter.HandleEdit(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
                        
        [Test]
        public void OnEditShouldNotDisplayEditCraftOrTradeIfNoCraftOrTradeIsSelected()
        {
            Expect.Once.On(viewMock).GetProperty("SelectedCraftOrTrade").Will(Return.Value(null));
            Expect.Never.On(viewMock).Method("EditCraftOrTrade");
            SetupExpectationsForNotLoadingCraftOrTrades();
            presenter.HandleEdit(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnDeleteShouldRemoveCraftOrTradeAndRefreshView()
        {            
            Expect.Once.On(viewMock).GetProperty("SelectedCraftOrTrade").Will(Return.Value(craftOrTradeToEdit));
            Expect.Once.On(serviceMock).Method("Remove").With(craftOrTradeToEdit);            
            SetupExpectationsForLoadingCraftsOrTrades();
            presenter.Delete();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnDeleteShouldNotRemoveSelectedItemfromCraftOrTradesListIfCraftOrTradeNotSelected()
        {
            Expect.Once.On(viewMock).GetProperty("SelectedCraftOrTrade").Will(Return.Value(null));
            Expect.Never.On(serviceMock).Method("Remove");
            SetupExpectationsForNotLoadingCraftOrTrades();
            presenter.Delete();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        private void SetupExpectationsForLoadingCraftsOrTrades()
        {
            Expect.Once.On(serviceMock).Method("QueryBySiteNoCache").With(userContext.Site).Will(
                Return.Value(craftOrTrades));
            Expect.Once.On(viewMock).SetProperty("CraftOrTrades").To(craftOrTrades);
        }

        private void SetupExpectationsForNotLoadingCraftOrTrades()
        {
            Expect.Never.On(viewMock).GetProperty("CraftOrTrades").Will(Return.Value(craftOrTrades));
            Expect.Never.On(viewMock).SetProperty("CraftOrTrades").To(craftOrTrades);
        }
        
        private void SetupExpectationForReSelectingCraftOrTradeAfterEdit(CraftOrTrade craftOrTradeToSelect)
        {
            Expect.Once.On(viewMock).SetProperty("SelectedCraftOrTrade").To(craftOrTradeToSelect);
        }
    }
}
