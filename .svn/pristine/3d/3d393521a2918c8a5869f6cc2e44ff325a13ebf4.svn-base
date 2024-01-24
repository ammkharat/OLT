using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class TargetAlertResponseFormPresenterTest
    {
        private TargetAlertResponseFormPresenter presenter;
        private MockTargetAlertResponseFormView view;
        private MockFunctionalLocationSelectionFormView flocSelectionView;
        private ITargetAlertService targetAlertService;
        private List<TargetAlert> targetAlerts;
        private User currentUser;
        private ShiftPattern currentShiftPattern;
        private Mockery mocks;
        private Role currentRole;

        [SetUp]
        public void SetUp()
        {
            ClientServiceRegistry.InitializeMockedInstance(new TestRemoteEventRepeater());
            Clock.Freeze();

var            targetAlert = TargetAlertFixture.CreateATargetAlert(TargetAlertStatus.StandardAlert);
            targetAlert.ExceedingBoundaries = true;
            targetAlert.Id = -23478;
            targetAlert.TargetName = "ta";
            targetAlert.TargetDefinition = CreateTargetDefinition(UserFixture.CreateUser());
            targetAlert.Category = TargetCategory.PRODUCTION;
            targetAlert.FunctionalLocation = FunctionalLocationFixture.GetAny_Unit1();
            targetAlert.Tag = TagInfoFixture.CreateTagInfoWithId2FromDB();
            targetAlert.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            targetAlert.Description = "description";
            targetAlert.RequiresResponse = false;
          
            targetAlert.FunctionalLocation.FullHierarchy = "fh";

            targetAlerts = new List<TargetAlert> {targetAlert};

            currentShiftPattern = ShiftPatternFixture.CreateShiftPattern(Clock.TimeNow.Add(-5), Clock.TimeNow.Add(5));
            
            ClientSession.GetNewInstance();
            UserContext userContext = ClientSession.GetUserContext();
            Fixtures.UserFixture.CreateSupervisor(userContext);
            currentUser = userContext.User;
            currentRole = userContext.Role;
            userContext.UserShift = UserShiftFixture.CreateUserShift(currentShiftPattern);
            WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator();
            workAssignment.CopyTargetAlertResponseToLog = false;
            userContext.Assignment = workAssignment;
                
            mocks = new Mockery();

            targetAlertService = mocks.NewMock<ITargetAlertService>();

            view = new MockTargetAlertResponseFormView();
            flocSelectionView = new MockFunctionalLocationSelectionFormView();

        }

        [TearDown]
        public void TearDown()
        {
            mocks.VerifyAllExpectationsHaveBeenMet();
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldLoadView()
        {
            Site site = SiteFixture.Sarnia();
            ClientSession.GetUserContext().SetSite(site, SiteConfigurationFixture.CreateDefaultSiteConfiguration(site));
            presenter = new TargetAlertResponseFormPresenter(view, flocSelectionView, targetAlerts, targetAlertService);

            // Execute:
            view.FireLoadViewEvent();

            Assert.AreEqual(TargetAlertResponseFormPresenter.FORM_TITLE, view.Title);
            CollectionAssert.AreEqual(TargetGapReason.AllWithEmpty, view.GapReasonChoices);
            Assert.AreEqual(string.Empty, view.Comment);
            Assert.AreEqual(false, view.CreateLogChecked);

            // Contextual information about the target alert we're responding to:
            Assert.AreEqual(Clock.Now, view.CreateDateTime);
            Assert.AreEqual(currentShiftPattern.Name, view.ShiftPatternName);
            Assert.AreEqual(currentUser, view.Author);
            Assert.AreEqual(targetAlerts[0].TargetName, view.TargetName);
            Assert.AreEqual(targetAlerts[0].Category.Name, view.CategoryName);
            Assert.AreEqual(targetAlerts[0].TargetDefinition.LastModifiedBy.FullNameWithUserName,
                            view.TargetDefinitionAuthor);
            Assert.AreEqual(targetAlerts[0].FunctionalLocation.FullHierarchy, view.FunctionalLocationName);
            Assert.AreEqual(targetAlerts[0].FunctionalLocation.Description, view.FunctionalLocationDescription);
            Assert.AreEqual(targetAlerts[0].Tag.Name, view.MeasurementTagName);
            AssertDescription(targetAlerts[0], view.Description);
            Assert.AreEqual(targetAlerts[0].LastModifiedBy, targetAlerts[0].LastModifiedBy);


            // Threshold values:
            Assert.AreEqual(targetAlerts[0].Tag.Units, view.MeasurementTagUnit);
            Assert.AreEqual(targetAlerts[0].NeverToExceedMaximum, view.NeverToExceedMaximum);
            Assert.AreEqual(targetAlerts[0].MaxValue, view.MaxValue);
            Assert.AreEqual(targetAlerts[0].MinValue, view.MinValue);
            Assert.AreEqual(targetAlerts[0].NeverToExceedMinimum, view.NeverToExceedMinimum);
            Assert.AreEqual(targetAlerts[0].TargetValue.Title, view.TargetValue);
        }

        [Test]
        public void ShouldLoadViewAndDisableOperatingEngineerLogs()
        {
            ITargetAlertResponseFormView viewMock = mocks.NewMock<ITargetAlertResponseFormView>();

            Stub.On(viewMock).GetProperty("CreateLogChecked").Will(Return.Value(false));
            StubOnFormEventHandlers(viewMock);
            Site denver = SiteFixture.Denver();
            ClientSession.GetUserContext().SetSite(denver, SiteConfigurationFixture.CreateDefaultSiteConfiguration(denver));

            presenter = new TargetAlertResponseFormPresenter(viewMock, flocSelectionView, targetAlerts, targetAlertService);

            ClientSession.GetUserContext().User = UserFixture.CreateSupervisor(denver);
            ClientSession.GetUserContext().UserShift = UserShiftFixture.CreateUserShift();
            // Execute:
            Expect.Once.On(viewMock).Method("EnableMakingAnOperatingEngineerLog").With(false);
            Stub.On(viewMock);

            presenter.LoadView(null, null);
        }

        [Test]
        public void CancelShouldDisplayConfirmationDialogAndClose()
        {
            ITargetAlertResponseFormView viewMock = mocks.NewMock<ITargetAlertResponseFormView>();
            StubOnFormEventHandlers(viewMock);
            presenter = new TargetAlertResponseFormPresenter(viewMock, flocSelectionView, targetAlerts, targetAlertService);

            Expect.Once.On(viewMock).Method("ShowConfirmationDialog").Will(Return.Value(true));
            Expect.Once.On(viewMock).Method("Close");
            presenter.CancelResponse(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void CancelShouldDisplayConfirmationDialogAndNotClose()
        {
            ITargetAlertResponseFormView viewMock = mocks.NewMock<ITargetAlertResponseFormView>();
            StubOnFormEventHandlers(viewMock);
            presenter = new TargetAlertResponseFormPresenter(viewMock, flocSelectionView, targetAlerts, targetAlertService);

            Expect.Once.On(viewMock).Method("ShowConfirmationDialog").Will(Return.Value(false));
            presenter.CancelResponse(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private static void StubOnFormEventHandlers(ITargetAlertResponseFormView viewMock)
        {
            Stub.On(viewMock).EventAdd("LoadView", Is.Anything);
            Stub.On(viewMock).EventAdd("SearchFunctionalLocation", Is.Anything);
            Stub.On(viewMock).EventAdd("CreateResponse", Is.Anything);
            Stub.On(viewMock).EventAdd("ClearFunctionalLocation", Is.Anything);
            Stub.On(viewMock).EventAdd("OnCreateLogCheckChanged", Is.Anything);
            Stub.On(viewMock).EventAdd("CancelResponse", Is.Anything);
        }

        private static void AssertDescription(TargetAlert targetAlert, string description)
        {
            StringAssert.Contains(targetAlert.TargetName, description);
            StringAssert.Contains(targetAlert.Category.Name, description);
            StringAssert.Contains(targetAlert.LastModifiedBy.FullNameWithUserName, description);
            StringAssert.Contains(targetAlert.FunctionalLocation.FullHierarchy, description);
            StringAssert.Contains(targetAlert.Tag.Name, description);
            StringAssert.Contains(targetAlert.MaxValue.ToString(), description);
            StringAssert.Contains(targetAlert.MinValue.ToString(), description);
            StringAssert.Contains(targetAlert.NeverToExceedMaximum.ToString(), description);
            StringAssert.Contains(targetAlert.NeverToExceedMinimum.ToString(), description);
            StringAssert.Contains(targetAlert.TargetValue.Title, description);
            StringAssert.Contains(targetAlert.ActualValue.ToString(), description);
            StringAssert.Contains(targetAlert.Tag.Units, description);
            StringAssert.Contains(targetAlert.Description, description);
        }

        [Test]
        public void ShouldOpenFunctionalLocationSelectionViewOnSearchEvent()
        {

            FunctionalLocation floc = FunctionalLocationFixture.GetAny_Unit1();
            floc.FullHierarchy = "AAA-BBB-CCC";
            flocSelectionView.selectedFunctionalLocation = floc;

            presenter = new TargetAlertResponseFormPresenter(view, flocSelectionView, targetAlerts, targetAlertService);

            // Execute:
            view.FireSearchFunctionalLocationEvent();

            Assert.IsTrue(flocSelectionView.showDialogCalled);
            Assert.IsTrue(flocSelectionView.selectedFunctionalLocationCalled);
            Assert.AreEqual(floc.FullHierarchy, view.ResponsibleFunctionalLocationText);
        }

        /// <summary>
        /// Once the user has picked a functional location, they need to a way to clear it
        /// (since it's optional).
        /// </summary>
        [Test]
        public void ShouldClearResponsibleFunctionalLocation()
        {
            view.Comment = string.Empty;
            view.CreateDateTime = Clock.Now;

            // Simulate user picking a functional location:
            FunctionalLocation floc = FunctionalLocationFixture.CreateNew("AAA-BBB-CCC");
            flocSelectionView.selectedFunctionalLocation = floc;

            presenter = new TargetAlertResponseFormPresenter(view, flocSelectionView, targetAlerts, targetAlertService);

            view.FireSearchFunctionalLocationEvent();

            // Execute:
            view.FireClearFunctionalLocationEvent();

            // We'll simulate the user creating the response to make sure we get an empty
            // functional location:
            Expect.Once.On(targetAlertService).Method("CreateTargetAlertResponse")
                .With(
                      new TargetAlertResponseMatcher(null, null, new string[0], Clock.Now),
                      Is.Anything,
                      Is.Anything,
                      Is.EqualTo(currentUser),
                      Is.EqualTo(currentShiftPattern),
                      Is.EqualTo(currentRole),
                      Is.Anything)
                .Will(Return.Value(new List<NotifiedEvent>()));

            view.FireCreateResponseEvent();

            Assert.AreEqual(string.Empty, view.ResponsibleFunctionalLocationText);
        }

        [Test]
        public void ShouldCreateResponse()
        {
            TargetGapReason gapReason = TargetGapReason.EquipmentFailure;
            FunctionalLocation responsibleFloc = FunctionalLocationFixture.CreateNew("AAA-BBB-CCC");

            presenter = new TargetAlertResponseFormPresenter(view, flocSelectionView, targetAlerts, targetAlertService);

            const bool createLog = true;
            DateTime createdDateTime = new DateTime(2011, 12, 13);

            view.CreateDateTime = createdDateTime;
            view.GapReason = gapReason;
            flocSelectionView.selectedFunctionalLocation = responsibleFloc;
            view.Description = "Description";
            view.Comment = "Comment";
            view.CreateLogChecked = createLog;
            view.IsLogAnOperatingEngineeringLog = false;

            // Should call the target alert service to handle creation of response:
            string[] expectedCommentFragments = {view.Description, view.Comment};
            Expect.Once.On(targetAlertService).Method("CreateTargetAlertResponse")
                .With(
                new TargetAlertResponseMatcher(gapReason, responsibleFloc, expectedCommentFragments, createdDateTime),
                Is.EqualTo(createLog),
                Is.Anything,
                Is.EqualTo(currentUser),
                Is.EqualTo(currentShiftPattern),
                Is.EqualTo(currentRole),
                Is.Anything)
                .Will(Return.Value(new List<NotifiedEvent>()));

            // Execute:
            view.FireSearchFunctionalLocationEvent(); // This will force a FLOC selection.
            view.FireCreateResponseEvent();
        }

        private static TargetDefinition CreateTargetDefinition(User createdBy)
        {
            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(-99);
            targetDefinition.LastModifiedBy = createdBy;
            return targetDefinition;
        }

        private class TargetAlertResponseMatcher : Matcher
        {
            private readonly TargetGapReason expectedGapReason;
            private readonly FunctionalLocation expectedResponsibleFloc;
            private readonly string[] expectedCommentFragments;
            private readonly DateTime expectedCreatedDateTime;

            public TargetAlertResponseMatcher(TargetGapReason expectedGapReason,
                                              FunctionalLocation expectedResponsibleFloc,
                                              string[] expectedCommentFragments,
                                              DateTime expectedCreatedDateTime)
            {
                this.expectedGapReason = expectedGapReason;
                this.expectedResponsibleFloc = expectedResponsibleFloc;
                this.expectedCommentFragments = expectedCommentFragments;
                this.expectedCreatedDateTime = expectedCreatedDateTime;
            }

            public override void DescribeTo(TextWriter writer)
            {
                writer.Write("a TargetAlertResponse with gap reason:<" + expectedGapReason + "> ");
                writer.Write("responsible FLOC:<" + expectedResponsibleFloc + "> ");
                writer.Write("comment containing:<" + expectedCommentFragments.BuildCommaSeparatedList(f=> f) + "> ");
                writer.Write("and create timestamp:<" + expectedCreatedDateTime + ">");
            }

            public override bool Matches(object o)
            {
                TargetAlertResponse response = (TargetAlertResponse) o;
                if (expectedGapReason != response.GapReason)
                {
                    return false;
                }
                if (expectedResponsibleFloc != response.ResponsibleForGap)
                {
                    return false;
                }
                if (expectedCreatedDateTime != response.ResponseComment.CreatedDate)
                {
                    return false;
                }

                foreach (string fragment in expectedCommentFragments)
                {
                    if (response.ResponseComment.Text.Contains(fragment) == false)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private class MockTargetAlertResponseFormView : ITargetAlertResponseFormView
        {
            private string title;
            private TargetGapReason[] gapReasons;
            private TargetGapReason gapReason;
            private string responsibleFunctionalLocationText;
            private string comment;
            private bool createLogChecked;

            public event EventHandler LoadView;
            public event EventHandler SearchFunctionalLocation;
            public event EventHandler CreateResponse;
            public event EventHandler CancelResponse { add { } remove { } }
            public event EventHandler OnCreateLogCheckChanged { add { } remove { } }
            public event EventHandler ClearFunctionalLocation;

            private DateTime createDateTime;
            private string shiftPatternName;
            private User author;
            private string targetName;
            private string categoryName;
            private string targetDefinitionAuthor;
            private string functionalLocationName;
            private string functionalLocationDescription;
            private string description;
            private string measurementTagName;
            private string measurementTagUnit;
            private decimal? neverToExceedMaximum;
            private decimal? maxValue;
            private decimal? minValue;
            private decimal? neverToExceedMinimum;
            private string targetValue;
            private bool isLogAnOperatingEngineeringLog;

            public int Width { get; set; }
            public Point Location { get; set; }

            public void ShowWaitScreenAndDisableForm()
            {            
            }

            public void CloseWaitScreenAndEnableForm()
            {            
            }

            public void SetFormVisibleState(bool visible)
            {                
            }

            public void FireLoadViewEvent()
            {
                if (LoadView != null)
                {
                    LoadView(this, EventArgs.Empty);
                }
            }


            public void FireSearchFunctionalLocationEvent()
            {
                if (SearchFunctionalLocation != null)
                {
                    SearchFunctionalLocation(this, EventArgs.Empty);
                }
            }

            public void FireCreateResponseEvent()
            {
                if (CreateResponse != null)
                {
                    CreateResponse(this, EventArgs.Empty);
                }
            }

            public void FireClearFunctionalLocationEvent()
            {
                if (ClearFunctionalLocation != null)
                {
                    ClearFunctionalLocation(this, EventArgs.Empty);
                }
            }

            public string Title
            {
                get { return title; }
                set { title = value; }
            }

            public TargetGapReason[] GapReasonChoices
            {
                get { return gapReasons; }
                set { gapReasons = value; }
            }

            public TargetGapReason GapReason
            {
                get { return gapReason; }
                set { gapReason = value; }
            }

            public string ResponsibleFunctionalLocationText
            {
                get { return responsibleFunctionalLocationText; }
                set { responsibleFunctionalLocationText = value; }
            }

            public string Comment
            {
                get { return comment; }
                set { comment = value; }
            }

            public bool CreateLogChecked
            {
                get { return createLogChecked; }
                set { createLogChecked = value; }
            }

            public event FormClosingEventHandler FormClosing { add { } remove { } }

            public int Height
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }

            public DialogResult DialogResult
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }

            public DialogResult ShowDialog(IWin32Window form)
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public event EventHandler Load { add { } remove { } }
            public event EventHandler Disposed { add { } remove { } }

            public void Close()
            {
            }

            public bool ConfirmCancelDialog()
            {
                throw new NotImplementedException();
            }

            public void SaveFailedMessage()
            {
                throw new NotImplementedException();
            }

            public void SaveSucceededMessage()
            {
                throw new NotImplementedException();
            }

            public void ShowMessageBox(string title, string error)
            {
            }

            public void UpdateTitleAsCreateOrEdit(bool isEdit, string titleText)
            {
            }

            public DateTime CreateDateTime
            {
                get { return createDateTime; }
                set { createDateTime = value; }
            }

            public string ShiftPatternName
            {
                get { return shiftPatternName; }
                set { shiftPatternName = value; }
            }

            public User Author
            {
                get { return author; }
                set { author = value; }
            }

            public string TargetName
            {
                get { return targetName; }
                set { targetName = value; }
            }

            public string CategoryName
            {
                get { return categoryName; }
                set { categoryName = value; }
            }

            public string TargetDefinitionAuthor
            {
                get { return targetDefinitionAuthor; }
                set { targetDefinitionAuthor = value; }
            }

            public string FunctionalLocationName
            {
                get { return functionalLocationName; }
                set { functionalLocationName = value; }
            }

            public string FunctionalLocationDescription
            {
                get { return functionalLocationDescription; }
                set { functionalLocationDescription = value; }
            }

            public string Description
            {
                get { return description; }
                set { description = value; }
            }

            public string MeasurementTagName
            {
                get { return measurementTagName; }
                set { measurementTagName = value; }
            }

            public string MeasurementTagUnit
            {
                get { return measurementTagUnit; }
                set { measurementTagUnit = value; }
            }

            public decimal? NeverToExceedMaximum
            {
                get { return neverToExceedMaximum; }
                set { neverToExceedMaximum = value; }
            }

            public decimal? MaxValue
            {
                get { return maxValue; }
                set { maxValue = value; }
            }

            public decimal? MinValue
            {
                get { return minValue; }
                set { minValue = value; }
            }

            public decimal? NeverToExceedMinimum
            {
                get { return neverToExceedMinimum; }
                set { neverToExceedMinimum = value; }
            }

            public string TargetValue
            {
                get { return targetValue; }
                set { targetValue = value; }
            }

            public void ShowGapReasonRequiredError()
            {
            }

            public void ClearErrorProviders()
            {
            }

            public void EnableMakingAnOperatingEngineerLog(bool operatingEngineerLogsEnabledForSite)
            {
            }

            public bool IsLogAnOperatingEngineeringLog
            {
                get { return isLogAnOperatingEngineeringLog; }
                set { isLogAnOperatingEngineeringLog = value; }
            }

            public string OperatingEngineerLogDisplayText
            {
                set { }
            }

            public string TargetNameLabel
            {
                set { }
            }

            public string TargetSummaryLabel
            {
                set { }
            }

            public bool ShowConfirmationDialog()
            {
                return true;
            }

            public void HideDetails()
            {
                throw new NotImplementedException();
            }

            public IntPtr Handle
            {
                get { throw new NotImplementedException(); }
            }

        }

        private class MockFunctionalLocationSelectionFormView : ISingleSelectFunctionalLocationSelectionForm
        {
            public FunctionalLocation selectedFunctionalLocation;
            public bool selectedFunctionalLocationCalled;

            public FunctionalLocation SelectedFunctionalLocation
            {
                get
                {
                    selectedFunctionalLocationCalled = true;
                    return selectedFunctionalLocation;
                }
            }

            public bool showDialogCalled;

            public DialogResult ShowDialog(IWin32Window owner)
            {
                showDialogCalled = true;
                return DialogResult.OK;
            }

            public bool AreSelectedFunctionalLocationsValid
            {
                get { return true;}
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

        }
    }
}