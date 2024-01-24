using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class AssignmentConfigurationPresenterTest
    {
        private Mockery mocks;
        private AssignmentConfigurationPresenter presenter;
        private IAssignmentConfigurationView mockView;
        private IWorkAssignmentService mockAssignmentService;

        private List<WorkAssignment> assignments;
        private UserContext userContext;
        private ClientSession clientSession;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockView = mocks.NewMock<IAssignmentConfigurationView>();
            mockAssignmentService = mocks.NewMock<IWorkAssignmentService>();

            presenter = new AssignmentConfigurationPresenter(mockView, mockAssignmentService);

            clientSession = ClientSession.GetNewInstance();
            userContext = ClientSession.GetUserContext();
            userContext.SetSite(SiteFixture.Sarnia(), null);
            Fixtures.UserFixture.CreateOperator(userContext);
            InitializeTestData();
        }

        private void InitializeTestData()
        {
            assignments = new List<WorkAssignment>
                              {
                                  WorkAssignmentFixture.CreateConsoleOperator(),
                                  WorkAssignmentFixture.CreateUnitLeader()
                              };
        }

        [TearDown]
        public void TearDown()
        {
            clientSession.CleanUpOldInstance();
        }

        [Test]
        public void ShouldPopulateViewWithAssignmentsForCurrentSite()
        {
            Stub.On(mockView).SetProperty("SiteName");
            SetupExpectationsForLoadingAssignments();            
            presenter.HandleFormLoad(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldSetCurrentSiteNameOnView()
        {
            Stub.On(mockAssignmentService).Method("QueryBySite").Will(Return.Value(assignments));
            Stub.On(mockView).SetProperty("Assignments");
            Expect.Once.On(mockView).SetProperty("SiteName").To(userContext.Site.Name);
            presenter.HandleFormLoad(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisplayUpdateFormWhenUserSelectsAnAssignmentToEdit()
        {
            WorkAssignment assignmentToEdit = WorkAssignmentFixture.CreateShiftEngineer();
            Expect.Once.On(mockView).GetProperty("SelectedAssignment").Will(Return.Value(assignmentToEdit));
            Expect.Once.On(mockView).Method("ShowEditAssignmentForm").With(assignmentToEdit, null).Will(Return.Value(DialogResult.OK));

            SetupExpectationsForLoadingAssignments();
            SetupExpectationsForSettingSelectedAssignmentAfterEdit();
            presenter.HandleEditAssignment(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisplayUpdateFormWhenUserDoubleClicksAnAssignment()
        {
            WorkAssignment assignmentToEdit = WorkAssignmentFixture.CreateShiftEngineer();
            DomainEventArgs<WorkAssignment> selectedItem = new DomainEventArgs<WorkAssignment>(assignmentToEdit);
            Expect.Once.On(mockView).GetProperty("SelectedAssignment").Will(Return.Value(assignmentToEdit));
            Expect.Once.On(mockView).Method("ShowEditAssignmentForm").With(assignmentToEdit, null).Will(Return.Value(DialogResult.OK));
            SetupExpectationsForLoadingAssignments();
            SetupExpectationsForSettingSelectedAssignmentAfterEdit();
            presenter.HandleDoubleClickAssignment(null, selectedItem);
        }
                
        [Test]
        public void ShouldNotRefreshAssignmentsIfUserSelectsUpdateAndThenCancels()
        {
            WorkAssignment assignmentToEdit = WorkAssignmentFixture.CreateShiftEngineer();
            Expect.Once.On(mockView).GetProperty("SelectedAssignment").Will(Return.Value(assignmentToEdit));
            Expect.Once.On(mockView).Method("ShowEditAssignmentForm").With(assignmentToEdit, null).Will(Return.Value(DialogResult.None));

            SetupExpectationsForNotRefreshingAssignments();

            presenter.HandleEditAssignment(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisplayCreateNewAssignmentFormAndNotRefreshAssignmentsWhenUserCancels()
        {
            Expect.Once.On(mockView).Method("ShowCreateAssignmentForm").WithAnyArguments().Will(Return.Value(DialogResult.None));
            SetupExpectationsForNotRefreshingAssignments();
            presenter.HandleCreateAssignment(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Test]
        public void ShouldNotDisplayUpdateFormWhenNoAssignmentIsSelected()
        {
            Expect.Once.On(mockView).GetProperty("SelectedAssignment");
            Expect.Never.On(mockView).Method("ShowEditAssignmentForm");

            presenter.HandleEditAssignment(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldNotDisplayUpdateFormWhenDoubleClickHasNoSelectedItem()
        {
            presenter.HandleDoubleClickAssignment(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldRemoveSelectedAssignmentAndRefreshView()
        {
            WorkAssignment assignmentToRemove = WorkAssignmentFixture.CreateShiftEngineer();
            Expect.Once.On(mockView).GetProperty("SelectedAssignment").Will(Return.Value(assignmentToRemove));
            Expect.Once.On(mockAssignmentService).Method("Remove").With(assignmentToRemove);
            SetupExpectationsForLoadingAssignments();

            presenter.HandleRemoveAssignment(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldNotRemoveAssignmentWhenNoneAreSelected()
        {
            Expect.Once.On(mockView).GetProperty("SelectedAssignment").Will(Return.Value(null));
            SetupExpectationsForNotRefreshingAssignments();

            presenter.HandleRemoveAssignment(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisplayCreateNewAssignmentFormWhenUserDesiresToCreateOne()
        {
            Expect.Once.On(mockView).Method("ShowCreateAssignmentForm").WithAnyArguments().Will(Return.Value(DialogResult.OK));
            SetupExpectationsForLoadingAssignments();
            SetupExpectationsForSettingSelectedAssignmentAfterAdd();
            presenter.HandleCreateAssignment(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldNotSelectNewlyCreatedAssignmentIfRefreshForAssignmentsReturnsNoRows()
        {
            Expect.Once.On(mockView).Method("ShowCreateAssignmentForm").WithAnyArguments().Will(Return.Value(DialogResult.OK));
            List<WorkAssignment> noAssignments = new List<WorkAssignment>();
            Expect.Once.On(mockAssignmentService).Method("QueryBySite").With(userContext.Site).Will(Return.Value(noAssignments));
            Expect.Once.On(mockView).SetProperty("Assignments").To(noAssignments);

            Expect.Once.On(mockView).GetProperty("Assignments").Will(Return.Value(noAssignments));
            Expect.Never.On(mockView).SetProperty("SelectedAssignment");
           
            presenter.HandleCreateAssignment(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }        
        
        private void SetupExpectationsForSettingSelectedAssignmentAfterEdit()
        {
            Expect.Once.On(mockView).SetProperty("SelectedAssignment"); 
        }

        private void SetupExpectationsForSettingSelectedAssignmentAfterAdd()
        {
            Expect.Once.On(mockView).GetProperty("Assignments").Will(Return.Value(assignments));
            Expect.Once.On(mockView).SetProperty("SelectedAssignment");
        }
        
        [Test]
        public void ShouldCloseFormWhenUserCloses()
        {
            Expect.Once.On(mockView).Method("CloseForm");
            presenter.HandleCloseForm(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        private void SetupExpectationsForNotRefreshingAssignments()
        {
            Expect.Never.On(mockAssignmentService).Method("QueryBySite").With(userContext.Site).Will(
                Return.Value(assignments));
            Expect.Never.On(mockView).SetProperty("Assignments").To(assignments);
        }

        private void SetupExpectationsForLoadingAssignments()
        {
            Expect.Once.On(mockAssignmentService).Method("QueryBySite").With(userContext.Site).Will(
                Return.Value(assignments));
            Expect.Once.On(mockView).SetProperty("Assignments").To(assignments);
        }
    }
}