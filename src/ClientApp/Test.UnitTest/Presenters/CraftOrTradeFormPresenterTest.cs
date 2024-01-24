using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class CraftOrTradeFormPresenterTest
    {
        private Mockery mocks;
        private ICraftOrTradeView viewMock;
        private ICraftOrTradeService serviceMock;
        private CraftOrTrade existingCraftOrTrade;
        private Site site;

        private CraftOrTradeFormPresenter formPresenterForEdit;
        private CraftOrTradeFormPresenter formPresenterForCreate;

        [SetUp]
        public void SetUp()
        {
            ClientServiceRegistry.InitializeMockedInstance(new TestRemoteEventRepeater());

            mocks = new Mockery();
            viewMock = mocks.NewMock<ICraftOrTradeView>();
            serviceMock = mocks.NewMock<ICraftOrTradeService>();

            User user = UserFixture.CreateOperatorMickeyInFortMcMurrySite();
            ClientSession.GetUserContext().User = user;
            site = ClientSession.GetUserContext().Site;

            existingCraftOrTrade = CraftOrTradeFixture.CreateCraftOrTradePipeFitter();

            formPresenterForEdit = new CraftOrTradeFormPresenter(viewMock, existingCraftOrTrade, serviceMock);
            formPresenterForCreate = new CraftOrTradeFormPresenter(viewMock, null, serviceMock);
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void OnLoadInEditModeShouldPopulateViewWithCraftOrTrade()
        {
            Expect.Once.On(viewMock).SetProperty("CraftOrTradeName").To(existingCraftOrTrade.Name);
            Expect.Once.On(viewMock).SetProperty("WorkCentre").To(existingCraftOrTrade.WorkCenterCode);
            Expect.Once.On(viewMock).SetProperty("CraftOrTradeSite").To(site.Name);
            Expect.Once.On(viewMock).SetProperty("ViewTitle").To("Edit Craft / Trade");

            formPresenterForEdit.HandleFormLoad(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnLoadInCreateModeShouldOnlySetDefaultFields()
        {
            Expect.Once.On(viewMock).SetProperty("CraftOrTradeSite").To(site.Name);
            Expect.Once.On(viewMock).SetProperty("ViewTitle").To("Create Craft / Trade");

            formPresenterForCreate.HandleFormLoad(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateThatFieldsAreNotEmptyAndSetErrorsOnView()
        {
            Expect.Once.On(viewMock).Method("ClearErrorProviders");
            Expect.Once.On(viewMock).GetProperty("CraftOrTradeName").Will(Return.Value(string.Empty));

            Expect.Once.On(viewMock).Method("ShowNameIsEmptyError");

            Stub.On(serviceMock).Method("QueryByWorkCentreAndNameAndSiteId").Will(Return.Value(null));
            Expect.Never.On(viewMock).Method("ShowDuplicateCraftOrTradeError");

            Assert.IsTrue(formPresenterForCreate.ValidateViewHasError());
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateForCreateShouldShowErrorIfNameAndWorkCentreExistsInDatabaseForGivenSite()
        {
            Expect.Once.On(viewMock).Method("ClearErrorProviders");
            Expect.Once.On(viewMock).GetProperty("CraftOrTradeName").Will(Return.Value(existingCraftOrTrade.Name));
            Expect.Once.On(viewMock).GetProperty("WorkCentre").Will(Return.Value(existingCraftOrTrade.WorkCenterCode));

            Expect.Once.On(serviceMock).Method("QueryByWorkCentreAndNameAndSiteId").With(
                existingCraftOrTrade.WorkCenterCode, existingCraftOrTrade.Name, site.Id.Value).Will(
                    Return.Value(existingCraftOrTrade));

            Expect.Once.On(viewMock).Method("ShowDuplicateCraftOrTradeError");

            Assert.IsTrue(formPresenterForCreate.ValidateViewHasError());
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateForEditShouldNotShowErrorIfCheckForDuplicateReturnsTheCraftOrTradeCurrentlyBeingUpdated()
        {
            Expect.Once.On(viewMock).Method("ClearErrorProviders");
            Expect.Once.On(viewMock).GetProperty("CraftOrTradeName").Will(Return.Value(existingCraftOrTrade.Name));
            Expect.Once.On(viewMock).GetProperty("WorkCentre").Will(Return.Value(existingCraftOrTrade.WorkCenterCode));

            Expect.Once.On(serviceMock).Method(
                "QueryByWorkCentreAndNameAndSiteId").With(
                    existingCraftOrTrade.WorkCenterCode, existingCraftOrTrade.Name, site.Id.Value).Will(
                        Return.Value(existingCraftOrTrade));

            Expect.Never.On(viewMock).Method("ShowDuplicateCraftOrTradeError");
            Assert.IsFalse(formPresenterForEdit.ValidateViewHasError());

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidateForEditShouldShowErrorIfCheckForDuplicateReturnsACraftOrTradeNotEqualToTheOneCurrentlyBeingUpdated()
        {
            Expect.Once.On(viewMock).Method("ClearErrorProviders");
            Expect.Once.On(viewMock).GetProperty("CraftOrTradeName").Will(Return.Value(existingCraftOrTrade.Name));
            Expect.Once.On(viewMock).GetProperty("WorkCentre").Will(Return.Value(existingCraftOrTrade.WorkCenterCode));

            CraftOrTrade duplicateCraftOrTrade =
                new CraftOrTrade(existingCraftOrTrade.Id + 1, existingCraftOrTrade.Name, existingCraftOrTrade.WorkCenterCode,
                                 existingCraftOrTrade.SiteId);

            Expect.Once.On(serviceMock).Method("QueryByWorkCentreAndNameAndSiteId").With(existingCraftOrTrade.WorkCenterCode, existingCraftOrTrade.Name,
                                                                                       site.Id.Value).Will(
                Return.Value(duplicateCraftOrTrade));

            Expect.Once.On(viewMock).Method("ShowDuplicateCraftOrTradeError");
            Assert.IsTrue(formPresenterForEdit.ValidateViewHasError());

            mocks.VerifyAllExpectationsHaveBeenMet();
        }        
        
        private void SetupExpectionsForValidate(CraftOrTrade craftOrTradeToValidate)
        {
            Expect.Once.On(viewMock).Method("ClearErrorProviders");
            Expect.Once.On(viewMock).GetProperty("CraftOrTradeName").Will(Return.Value(craftOrTradeToValidate.Name));
            Expect.Once.On(viewMock).GetProperty("WorkCentre").Will(Return.Value(craftOrTradeToValidate.WorkCenterCode));
            Stub.On(serviceMock).Method("QueryByWorkCentreAndNameAndSiteId").Will(Return.Value(null));
            Expect.Never.On(viewMock).Method("ShowDuplicateCraftOrTradeError");
        }
    }
}