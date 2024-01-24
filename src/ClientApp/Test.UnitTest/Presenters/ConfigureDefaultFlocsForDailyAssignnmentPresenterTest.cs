using System;
using System.Collections.Generic;
using System.IO;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class ConfigureDefaultFlocsForDailyAssignnmentPresenterTest
    {
        private readonly Mockery mockery = new Mockery();
        private IWorkAssignmentService mockWorkAssignmentService;
        private IConfigureDefaultFlocsForDailyAssignmentView mockView;
        private ConfigureDefaultFlocsForDailyAssignnmentPresenter presenter;

        private List<WorkAssignment> currentWorkAssignmentList;
        private WorkAssignment newSelectedAssignment;
        private WorkAssignment nextSelectedAssignment;

        private readonly Site testSite = SiteFixture.Sarnia();
        private User currentUser;

        [SetUp]
        public void SetUp()
        {
            currentUser = UserFixture.CreateSupervisor(testSite);
            ClientSession.GetUserContext().User = currentUser;

            currentWorkAssignmentList = WorkAssignmentFixture.CreateWorkAssignmentList(10);
            newSelectedAssignment = currentWorkAssignmentList[0];
            nextSelectedAssignment = currentWorkAssignmentList[1];

            mockWorkAssignmentService = mockery.NewMock<IWorkAssignmentService>();

            mockView = mockery.NewMock<IConfigureDefaultFlocsForDailyAssignmentView>();
            presenter = new ConfigureDefaultFlocsForDailyAssignnmentPresenter(mockView, mockWorkAssignmentService);
        }

        [Test]
        public void ShouldInitializeViewWithAssignmentListAndAvailableFLOCOnHandlingLoad()
        {
            SetUpHandleLoadExpectation();
            Expect.Once.On(mockView).Method("SelectFirstWorkAssignment");
            //SelectFirstWorkAssignment
            presenter.HandleLoad(null, EventArgs.Empty);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDisabledFLOCSelectionWhenNoWorkAssignmentAvailableForSite()
        {
            List<WorkAssignment> emptyWorkAssignmentList = new List<WorkAssignment>();
            Expect.Once.On(mockWorkAssignmentService).Method("QueryBySite").Will(Return.Value(emptyWorkAssignmentList));
            Expect.Once.On(mockView).SetProperty("FunctionalLocationSelectionEnabled").To(false);
            presenter.HandleLoad(null, EventArgs.Empty);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldSetFlocsForNewlySelectedWorkAssignmentOnView()
        {
            Expect.Once.On(mockView).SetProperty("SelectedAssignmentDefaultFunctionalLocations").
                To(newSelectedAssignment.FunctionalLocations);
            DomainEventArgs<WorkAssignment> selectedItemArgs = new DomainEventArgs<WorkAssignment>(newSelectedAssignment);
            presenter.HandleWorkAssignmentAreaSelected(null, selectedItemArgs);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldGetTheCurrentlySelectedFlocsAndAddToTheModifiedWorkAssignmentList()
        {
            //
            // SetUp for first time selection (nothing will be saved yet)
            //
            Expect.Once.On(mockView).SetProperty("SelectedAssignmentDefaultFunctionalLocations").
                To(newSelectedAssignment.FunctionalLocations);
            DomainEventArgs<WorkAssignment> selectedItemArgs = new DomainEventArgs<WorkAssignment>(newSelectedAssignment);
            presenter.HandleWorkAssignmentAreaSelected(null, selectedItemArgs);
            mockery.VerifyAllExpectationsHaveBeenMet();

            //
            // Second time selection (save the previous selection)
            //
            Expect.Once.On(mockView).GetProperty("SelectedAssignmentDefaultFunctionalLocations").Will(Return.Value(newSelectedAssignment.FunctionalLocations));
            Expect.Once.On(mockView).SetProperty("SelectedAssignmentDefaultFunctionalLocations").To(nextSelectedAssignment.FunctionalLocations);
            selectedItemArgs = new DomainEventArgs<WorkAssignment>(nextSelectedAssignment);
            presenter.HandleWorkAssignmentAreaSelected(null, selectedItemArgs);
            
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldSaveSelectedFlocsAndClose()
        {
            Stub.On(mockView).GetProperty("SelectedAssignmentDefaultFunctionalLocations");
            Expect.Once.On(mockWorkAssignmentService).Method("UpdateFunctionalLocations")
                .With(new TypeMatcher(typeof(List<WorkAssignment>)));

            Expect.Once.On(mockView).Method("SaveSucceededMessage");
            Expect.Once.On(mockView).Method("Close");

            presenter.HandleSaveButtonClicked(null, EventArgs.Empty);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldCancelWhenUserClicksCancel()
        {
            Expect.Once.On(mockView).Method("ConfirmCancelDialog").Will(Return.Value(true));
            Expect.Once.On(mockView).Method("Close");
            presenter.HandleCancelButtonClicked(new object(), EventArgs.Empty);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldNotCancelWhenUserClicksCancelAndAborts()
        {
            Expect.Once.On(mockView).Method("ConfirmCancelDialog").Will(Return.Value(false));
            presenter.HandleCancelButtonClicked(new object(), EventArgs.Empty);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldClearTreeWhenUserClicksClear()
        {
            Expect.Once.On(mockView).Method("ClearFunctionalLocations");
            presenter.HandleClearButtonClicked(new object(), EventArgs.Empty);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        /// <summary>
        /// Sets up a presenter as if the user did these things:
        /// 1. Opened the form (so Load gets fired)
        /// 2. Selected an work Assignment
        /// 3. checked a floc
        /// </summary>        
        private void SetUpHandleLoadExpectation()
        {
            Expect.Once.On(mockWorkAssignmentService).Method("QueryBySite")
                .With(testSite).Will(Return.Value(currentWorkAssignmentList));

            Expect.Once.On(mockView).SetProperty("FunctionalLocationSelectionEnabled").To(true);

            using (mockery.Ordered)
            {
                Expect.Once.On(mockView).SetProperty("WorkAssignmentList").To(currentWorkAssignmentList);
            }
        }
    }
    
    public class WorkAssignmentListShouldBeEmptyMatcher : Matcher
    {
        List<WorkAssignment> list;
        
        public override bool Matches(object o)
        {
            list = (List<WorkAssignment>) o;
            return list.Count == 0;            
        }

        public override void DescribeTo(TextWriter writer)
        {
            writer.Write("There was a count of: " + list.Count);
        }
    }

    public class DirtyListShouldHaveSomeValuesMatcher : Matcher
    {
        List<WorkAssignment> list;
        private readonly int count;

        public DirtyListShouldHaveSomeValuesMatcher(int count)
        {
            this.count = count;
        }

        public override bool Matches(object o)
        {
            list = (List<WorkAssignment>)o;
            return list.Count == count;
        }

        public override void DescribeTo(TextWriter writer)
        {
            writer.Write("There was a count of: " + list.Count + " when a count of " + count + " was expected.");
        }
    }
    
}
