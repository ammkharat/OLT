using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Fixtures;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class ConfigurePreApprovedTargetRangesFormPresenterTest
    {
        Mockery mocks;
        IConfigurePreApprovedTargetRangesView mockView;
        IAuthorized mockAuthorized;
        TargetDefinition targetDefinition;
        ConfigurePreApprovedTargetRangesFormPresenter presenter;
        
        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockView = mocks.NewMock<IConfigurePreApprovedTargetRangesView>();
            mockAuthorized = mocks.NewMock<IAuthorized>();
            ExpectEventHooks();

            CreateTargetDefinitionAndPresenter(true);

            ClientSession.GetUserContext().User = UserFixture.CreateUser();
        }

        private void CreateTargetDefinitionAndPresenter(bool requiresApproval)
        {
            targetDefinition = TargetDefinitionFixture.CreateTargetDefinition(requiresApproval);
            presenter = new ConfigurePreApprovedTargetRangesFormPresenter(mockView, mockAuthorized, targetDefinition);
        }

        private void ExpectEventHooks()
        {
            Expect.Once.On(mockView).EventAdd("FormLoad", new TypeMatcher(typeof(EventHandler)));
            Expect.Once.On(mockView).EventAdd("Save", new TypeMatcher(typeof(EventHandler)));
            Expect.Once.On(mockView).EventAdd("Cancel", new TypeMatcher(typeof(EventHandler)));
        }

        [Test]
        public void OnLoadShouldSetFieldsOnView()
        {
            Expect.Once.On(mockView).SetProperty("TargetDefinitionName").To(targetDefinition.Name);
            Expect.Once.On(mockView).SetProperty("PreApprovedNeverToExceedMin").To(
                targetDefinition.PreApprovedNeverToExceedMinimum);
            Expect.Once.On(mockView).SetProperty("PreApprovedNeverToExceedMax").To(
                targetDefinition.PreApprovedNeverToExceedMaximum);
            Expect.Once.On(mockView).SetProperty("PreApprovedMin").To(
                targetDefinition.PreApprovedMinValue);
            Expect.Once.On(mockView).SetProperty("PreApprovedMax").To(
                targetDefinition.PreApprovedMaxValue);

            Expect.Once.On(mockView).SetProperty("TagUnit").To(targetDefinition.TagInfo.Units);
            Expect.Once.On(mockView).SetProperty("NeverToExceedMinEnabled").To(false);
            Expect.Once.On(mockView).SetProperty("NeverToExceedMaxEnabled").To(true);
            Expect.Once.On(mockView).SetProperty("MinEnabled").To(true);
            Expect.Once.On(mockView).SetProperty("MaxEnabled").To(true);

            Stub.On(mockView);
            Stub.On(mockAuthorized).Method(Is.Anything).Will(Return.Value(true));

            presenter.HandleFormLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldSetEmptyStringForTagUnitWhenTagInfoIsNotSetYetDuringLoad()
        {
            targetDefinition.TagInfo = null;
            Expect.Once.On(mockView).SetProperty("TagUnit").To(string.Empty);
            Stub.On(mockView);
            Stub.On(mockAuthorized).Method(Is.Anything).Will(Return.Value(true));

            presenter.HandleFormLoad(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void BuildTargetDefinitionShouldCreateTargetDefinitionFromFieldsOnView()
        {
            decimal? newPreApprovedNeverToExceedMin = 0.6m;
            decimal? newPreApprovedNeverToExceedMax = 100.6m;
            decimal? newPreApprovedMin = 0.5m;
            decimal? newPreApprovedMax = 100.5m;

            Expect.Once.On(mockView).GetProperty("PreApprovedNeverToExceedMin")
                    .Will(Return.Value(newPreApprovedNeverToExceedMin));
            Expect.Once.On(mockView).GetProperty("PreApprovedNeverToExceedMax")
                    .Will(Return.Value(newPreApprovedNeverToExceedMax));
            Expect.Once.On(mockView).GetProperty("PreApprovedMin")
                    .Will(Return.Value(newPreApprovedMin));
            Expect.Once.On(mockView).GetProperty("PreApprovedMax")
                    .Will(Return.Value(newPreApprovedMax));
            
            TargetDefinition newTargetDefinition = presenter.BuildTargetDefinition();
            Assert.AreEqual(newPreApprovedNeverToExceedMin, newTargetDefinition.PreApprovedNeverToExceedMinimum);
            Assert.AreEqual(newPreApprovedNeverToExceedMax, newTargetDefinition.PreApprovedNeverToExceedMaximum);
            Assert.AreEqual(newPreApprovedMin, newTargetDefinition.PreApprovedMinValue);
            Assert.AreEqual(newPreApprovedMax, newTargetDefinition.PreApprovedMaxValue);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void LoadShouldSetViewToBeNotWritableIfUserNotAuthorizedToConfigure()
        {
            Expect.Once.On(mockAuthorized).Method("ToConfigurePreApprovedTargetRanges").
                With(ClientSession.GetUserContext().UserRoleElements).
                Will(Return.Value(false));
            Expect.Once.On(mockView).SetProperty("WritableMode").To(false);

            Stub.On(mockView);

            presenter.HandleFormLoad(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void LoadShouldSetViewToBeWritableIfUserAuthorizedToConfigure()
        {
            Expect.Once.On(mockAuthorized).Method("ToConfigurePreApprovedTargetRanges").
                With(ClientSession.GetUserContext().UserRoleElements).
                Will(Return.Value(true));
            Expect.Once.On(mockView).SetProperty("WritableMode").To(true);

            Stub.On(mockView);

            presenter.HandleFormLoad(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void CancelEventShouldCloseView()
        {
            Expect.Once.On(mockView).Method("Close");

            presenter.HandleCancel(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
    }
}