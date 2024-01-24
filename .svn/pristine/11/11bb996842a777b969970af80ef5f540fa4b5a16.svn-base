using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Validation;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class MultiSelectFunctionalLocationSelectionFormPresenterTest
    {
        private Mockery mocks;
        private MultiSelectFunctionalLocationSelectionFormPresenter presenter;
        private IMultiSelectFunctionalLocationSelectionForm mockView;
        private IFunctionalLocationInfoService mockFlocInfoService;
        private List<FunctionalLocation> flocList, emptyFlocList;
        private User user;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockView = mocks.NewMock<IMultiSelectFunctionalLocationSelectionForm>();
            mockFlocInfoService = mocks.NewMock<IFunctionalLocationInfoService>();

            flocList = FunctionalLocationFixture.CreateNewListOfNewItems(3);
            emptyFlocList = new List<FunctionalLocation>();
            user = UserFixture.CreateUserWithGivenId(1);
            ClientSession.GetUserContext().User = user;
        }

        [TearDown]
        public void TearDown()
        {            
        }

        [Test]
        public void AcceptButtonWithNoSelectedFlocsShouldShowSelectionRequiredMessage()
        {
            CreatePresenter();
            Expect.Once.On(mockView).GetProperty("UserSelectedFunctionalLocations").Will(Return.Value(emptyFlocList));
            Expect.Once.On(mockView).Method("LaunchFunctionalLocationSelectionRequiredMessage");
            presenter.AcceptButton_Click(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldSaveUserSelectedFLOCListOnLoadSoThatWeCanReStoreWhenTheUserCancels()
        {
            CreatePresenter();
            Expect.Once.On(mockView).GetProperty("UserSelectedFunctionalLocations").Will(Return.Value(new List<FunctionalLocation>()));
            presenter.Form_Load(this, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void AcceptButtonWithSelectedFlocNotSelectableShouldThrowErrorMessage()
        {
            CreatePresenter();
            Stub.On(mockView).GetProperty("UserSelectedFunctionalLocations").Will(Return.Value(flocList));
            Expect.Once.On(mockView).GetProperty("AreSelectedFunctionalLocationsValid").Will(Return.Value(false));
            Expect.Once.On(mockView).Method("SetFunctionalLocationErrorMessage");
            presenter.AcceptButton_Click(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ClearButtonShouldSetTreeViewPresenterWithEmptyFlocList()
        {
            CreatePresenter();
            Expect.Once.On(mockView).SetProperty("UserSelectedFunctionalLocations").To(IsList.Equal(emptyFlocList));
            presenter.ClearSelectionButton_Click(null, EventArgs.Empty);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldRetainOldFLOCSelectionOnHandlingCancel()
        {
            CreatePresenter();
            Expect.Once.On(mockView).SetProperty("UserSelectedFunctionalLocations");
            Expect.Once.On(mockView).Method("CloseForm");
            presenter.CancelButton_Click(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShowDialogWithFlocListShouldShowFlocDialogAndAskTreeViewPresenterToInitializeUserSelectedFlocs()
        {
            CreatePresenter();
            Expect.Once.On(mockView).Method("ShowDialog").WithAnyArguments().Will(Return.Value(DialogResult.OK));
            presenter.ShowDialog(null, flocList);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void CreatePresenter()
        {
            presenter = new MultiSelectFunctionalLocationSelectionFormPresenter(mockView, mockFlocInfoService);
        }

        [Test]
        public void ShouldCheckFlocsFromSetOfActiveFloc()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation>();
            flocs.Add(FunctionalLocationFixture.CreateNew(1, "A-B-C1"));
            flocs.Add(FunctionalLocationFixture.CreateNew(2, "A-B-C2"));
            flocs.Add(FunctionalLocationFixture.CreateNew(3, "A-B-C3"));
            ClientSession.GetUserContext().SetSelectedFunctionalLocations(
                flocs,
                new List<FunctionalLocation>(), 
                new List<FunctionalLocation>());

            TestView testView = new TestView();
            testView.UserSelectedFunctionalLocations = new List<FunctionalLocation>();
            testView.CanCheckMap[1] = true;
            testView.CanCheckMap[2] = true;
            testView.CanCheckMap[3] = true;

            MultiSelectFunctionalLocationSelectionFormPresenter testPresenter =
                new MultiSelectFunctionalLocationSelectionFormPresenter(testView, mockFlocInfoService);
            testPresenter.SelectActiveFlocsButton_Click(null, null);

            Assert.AreEqual(3, testView.UserSelectedFunctionalLocations.Count);
            Assert.IsTrue(testView.UserSelectedFunctionalLocations.Exists(obj => obj.Id == 1));
            Assert.IsTrue(testView.UserSelectedFunctionalLocations.Exists(obj => obj.Id == 2));
            Assert.IsTrue(testView.UserSelectedFunctionalLocations.Exists(obj => obj.Id == 3));
        }

        [Test]
        public void ShouldTryToCheckChildrenOfActiveFlocIfTheParentCannotBeChecked()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation>();
            flocs.Add(FunctionalLocationFixture.CreateNew(1, "B-C1"));
            flocs.Add(FunctionalLocationFixture.CreateNew(2, "A"));
            flocs.Add(FunctionalLocationFixture.CreateNew(3, "B-C2"));
            ClientSession.GetUserContext().SetSelectedFunctionalLocations(
               flocs,
               new List<FunctionalLocation>(),
               new List<FunctionalLocation>());

            List<FunctionalLocationInfo> sections = new List<FunctionalLocationInfo> {
                new FunctionalLocationInfo(FunctionalLocationFixture.CreateNew(21, "A-1"), false), 
                new FunctionalLocationInfo(FunctionalLocationFixture.CreateNew(22, "A-2"), false)};
            List<FunctionalLocationInfo> units = new List<FunctionalLocationInfo> {
                new FunctionalLocationInfo(FunctionalLocationFixture.CreateNew(210, "A-1-1"), false), 
                new FunctionalLocationInfo(FunctionalLocationFixture.CreateNew(220, "A-2-2"), false)};

            Stub.On(mockFlocInfoService).Method("QueryByParentFunctionalLocation")
                .With(flocs[1])
                .Will(Return.Value(sections));
            Stub.On(mockFlocInfoService).Method("QueryByParentFunctionalLocation")
                .With(sections[0].Floc)
                .Will(Return.Value(units));

            TestView testView = new TestView();
            testView.UserSelectedFunctionalLocations = new List<FunctionalLocation>();
            testView.CanCheckMap[1] = true;
            testView.CanCheckMap[2] = false;
            testView.CanCheckMap[3] = true;
            testView.CanCheckMap[21] = false;
            testView.CanCheckMap[22] = true;
            testView.CanCheckMap[210] = true;
            testView.CanCheckMap[220] = false;

            MultiSelectFunctionalLocationSelectionFormPresenter testPresenter =
                new MultiSelectFunctionalLocationSelectionFormPresenter(testView, mockFlocInfoService);
            testPresenter.SelectActiveFlocsButton_Click(null, null);

            Assert.AreEqual(4, testView.UserSelectedFunctionalLocations.Count);
            Assert.IsTrue(testView.UserSelectedFunctionalLocations.Exists(obj => obj.Id == 1));
            Assert.IsFalse(testView.UserSelectedFunctionalLocations.Exists(obj => obj.Id == 2));
            Assert.IsTrue(testView.UserSelectedFunctionalLocations.Exists(obj => obj.Id == 3));
            Assert.IsFalse(testView.UserSelectedFunctionalLocations.Exists(obj => obj.Id == 21));
            Assert.IsTrue(testView.UserSelectedFunctionalLocations.Exists(obj => obj.Id == 22));
            Assert.IsTrue(testView.UserSelectedFunctionalLocations.Exists(obj => obj.Id == 210));
            Assert.IsFalse(testView.UserSelectedFunctionalLocations.Exists(obj => obj.Id == 220));
        }

        private class TestView : IMultiSelectFunctionalLocationSelectionForm
        {
            private IList<FunctionalLocation> userSelectedFunctionalLocations;
            public Dictionary<long, bool> CanCheckMap = new Dictionary<long, bool>();

            public DialogResult ShowDialog(IWin32Window owner)
            {
                return DialogResult.None;
            }

            public bool AreSelectedFunctionalLocationsValid
            {
                get { return false; }
            }

            public void SetFunctionalLocationErrorMessage()
            {
            }

            public void SetFunctionalLocationErrorMessage(string message)
            {
            }

            public void LaunchFunctionalLocationSelectionRequiredMessage()
            {
            }

            public void CloseForm(DialogResult result)
            {
            }

            public IList<FunctionalLocation> UserSelectedFunctionalLocations
            {
                get { return userSelectedFunctionalLocations; }
                set { userSelectedFunctionalLocations = value; }
            }

            public DialogResult ShowDialog(IWin32Window owner, List<FunctionalLocation> initialSelection)
            {
                return DialogResult.None;
            }

            public bool CanCheckFunctionalLocation(FunctionalLocation floc)
            {
                return CanCheckMap[floc.IdValue];
            }

            public IFunctionalLocationValidator FlocValidator
            {
                set {  }
            }
        }
    }
}