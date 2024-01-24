using System.Collections.Generic;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class CreateOrEditAssignmentFormPresenterTest
    {
        private ICreateOrEditAssignmentView view;
        private IWorkAssignmentService workAssignmentService;
        private IVisibilityGroupService visibilityGroupService;
        private ISiteConfigurationService siteConfigurationService;
        private IRoleService roleService;

        private WorkAssignment assignment;        

        [SetUp]
        public void SetUp()
        {
            ClientServiceRegistry.InitializeMockedInstance(new TestRemoteEventRepeater());

            view = MockRepository.GenerateStub<ICreateOrEditAssignmentView>();
          
            workAssignmentService = MockRepository.GenerateStub<IWorkAssignmentService>();
            visibilityGroupService = MockRepository.GenerateStub<IVisibilityGroupService>();
            siteConfigurationService = MockRepository.GenerateStub<ISiteConfigurationService>();

            roleService = MockRepository.GenerateStub<IRoleService>();

            ClientSession.GetNewInstance();
            Fixtures.UserFixture.CreateOperator(ClientSession.GetUserContext());

            assignment = WorkAssignmentFixture.CreateUnitLeader(new List<FunctionalLocation>());
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void OnLoadToCreateShouldPopulateViewWithDefaults()
        {
            List<Role> roles = new List<Role> { RoleFixture.CreateOperatorRole(), RoleFixture.CreateSupervisorRole() };
            List<Role> rolesWithEmpty = new List<Role> { RoleFixture.CreateOperatorRole(), RoleFixture.CreateSupervisorRole() };

            SiteConfigurationDefaults defaults = new SiteConfigurationDefaults(ClientSession.GetUserContext().SiteId, true);

            CreateOrEditAssignmentFormPresenter presenter = new CreateOrEditAssignmentFormPresenter(
                view, 
                null,
                new List<WorkAssignment>(),
                roleService, 
                workAssignmentService, visibilityGroupService, siteConfigurationService);

            visibilityGroupService.Stub(mock => mock.QueryAll(ClientSession.GetUserContext().Site)).Return(new List<VisibilityGroup>(0));
            roleService.Stub(mock => mock.QueryRolesBySite(ClientSession.GetUserContext().Site)).Return(roles);
            // defaults = siteConfigurationService.QuerySiteConfigurationDefaultsBySiteId(ClientSession.GetUserContext().SiteId);
            siteConfigurationService.Stub(mock => mock.QuerySiteConfigurationDefaultsBySiteId(ClientSession.GetUserContext().SiteId)).Return(defaults);

            view.AssignmentSite = ClientSession.GetUserContext().Site.Name;
            view.ViewTitle = "Create Assignment";
            //view.ShowActionItemsOnHandoverBasedOnWorkAssignmentAndFlocs = true;
            view.Roles = roles;

            view.SelectedRole = RoleFixture.CreateOperatorRole();

            presenter.HandleFormLoad(null, null);
        }

        [Test]
        public void OnLoadToEditShouldPopulateViewWithAssignment()
        {
            List<Role> roles = new List<Role> { RoleFixture.CreateOperatorRole(), RoleFixture.CreateSupervisorRole() };
            List<Role> rolesWithEmpty = new List<Role> { RoleFixture.CreateOperatorRole(), RoleFixture.CreateSupervisorRole() };

            CreateOrEditAssignmentFormPresenter presenter = new CreateOrEditAssignmentFormPresenter(
                view,
                assignment,
                new List<WorkAssignment>(),
                roleService,
                workAssignmentService,
                visibilityGroupService, 
                siteConfigurationService);            

            view.AssignmentSite = ClientSession.GetUserContext().Site.Name;
            view.ViewTitle = "Edit Assignment";
            view.AssignmentName = assignment.Name;
            view.AssignmentDescription = assignment.Description;
            view.Category = assignment.Category;
            //view.ShowActionItemsOnHandoverBasedOnWorkAssignmentAndFlocs = assignment.UseWorkAssignmentForActionItemHandoverDisplay;
            visibilityGroupService.Stub(mock => mock.QueryAll(ClientSession.GetUserContext().Site)).Return(new List<VisibilityGroup>(0));
            roleService.Expect(mock => mock.QueryRolesBySite(ClientSession.GetUserContext().Site)).Return(roles);

            view.SelectedRole = RoleFixture.CreateOperatorRole();            

            presenter.HandleFormLoad(null, null);
        }

        [Test]
        public void SaveInEditModeShouldUpdateExistingAssignment()
        {
            CreateOrEditAssignmentFormPresenter presenter = new CreateOrEditAssignmentFormPresenter(
                view, 
                assignment, 
                new List<WorkAssignment>(),
                roleService,
                workAssignmentService,
                visibilityGroupService, 
                siteConfigurationService);

            const string newAssignmentName = "New Name";
            const string newDescription = "New Description";
            const string newCategory = "New Category";
            Role newRole = RoleFixture.CreateSupervisorRole();            

            WorkAssignment updatedAssignment =
                new WorkAssignment(assignment.Id, newAssignmentName, newDescription, newCategory,
                    assignment.SiteId, newRole, true, true, assignment.FunctionalLocations, null, null,true,true);

            visibilityGroupService.Stub(mock => mock.QueryAll(ClientSession.GetUserContext().Site)).Return(new List<VisibilityGroup>(0));
            SetupExpectionsForValidate(updatedAssignment);

            view.AssignmentName = newAssignmentName;
            view.AssignmentDescription = newDescription;
            view.Category = newCategory;
            view.SelectedRole = newRole;

           // view.ShowActionItemsOnHandoverBasedOnWorkAssignmentAndFlocs = true;

            workAssignmentService.Stub(m => m.Update(updatedAssignment));
            view.Expect(mock => mock.SaveSucceededMessage());
            view.Expect(mock => mock.SetDialogResultOK());
            view.Expect(mock => mock.Close());

            presenter.HandleSaveAndCloseButtonClick(null, null);
        }

        [Test]
        public void SaveInCreateModeShouldCreateAssignment()
        {
            CreateOrEditAssignmentFormPresenter presenter = new CreateOrEditAssignmentFormPresenter(
                view, 
                null,
                new List<WorkAssignment>(),
                roleService,
                workAssignmentService,
                visibilityGroupService, 
                siteConfigurationService);

            WorkAssignment newAssignment =
                new WorkAssignment("New Name", "New Description", "New Category",
                                                 ClientSession.GetUserContext().SiteId, RoleFixture.CreateRole());

            visibilityGroupService.Stub(mock => mock.QueryAll(ClientSession.GetUserContext().Site)).Return(new List<VisibilityGroup>(0));
            SetupExpectionsForValidate(newAssignment);

            view.AssignmentName = newAssignment.Name;
            view.AssignmentDescription = newAssignment.Description;
            view.Category = newAssignment.Category;
            view.SelectedRole = newAssignment.Role;

            //view.ShowActionItemsOnHandoverBasedOnWorkAssignmentAndFlocs = newAssignment.UseWorkAssignmentForActionItemHandoverDisplay;

            workAssignmentService.Stub(m => m.Insert(newAssignment));
            view.Expect(mock => mock.SaveSucceededMessage());
            view.Expect(mock => mock.SetDialogResultOK());
            view.Expect(mock => mock.Close());
            
            presenter.HandleSaveAndCloseButtonClick(null, null);
        }

        [Test]
        public void OnSaveShouldValidateThatFieldsAreNotEmptyAndSetErrorsOnView()
        {
            CreateOrEditAssignmentFormPresenter presenter = new CreateOrEditAssignmentFormPresenter(
                view, 
                null,
                new List<WorkAssignment>(),
                roleService,
                workAssignmentService,
                visibilityGroupService, 
                siteConfigurationService);

            visibilityGroupService.Stub(mock => mock.QueryAll(ClientSession.GetUserContext().Site)).Return(new List<VisibilityGroup>(0));
            view.Expect(mock => mock.ClearErrorProviders());
            
            view.AssignmentName = string.Empty;
            view.AssignmentDescription = string.Empty;
            view.SelectedRole = null;

            view.Expect(mock => mock.ShowNameIsEmptyError());
            view.Expect(mock => mock.ShowDescriptionIsEmptyError());
            view.Expect(mock => mock.ShowRoleIsNullError());
                                              
            presenter.HandleSaveAndCloseButtonClick(null, null);
        }

        [Test]
        public void OnSaveForUpdateAssignmentIfAMatchingAssignmentWithSameIdAlreadyExistsShouldNotDisplayErrorMessageBecauseUserIsEditingTheAssignmentThatTheQueryReturned()
        {
            CreateOrEditAssignmentFormPresenter presenter = new CreateOrEditAssignmentFormPresenter(
                view, 
                assignment, 
                new List<WorkAssignment>(),
                roleService,
                workAssignmentService,
                visibilityGroupService, 
                siteConfigurationService);


            VisibilityGroup visibilityGroup = new VisibilityGroup(1, "vg", SiteFixture.Sarnia().IdValue, true);
            WorkAssignmentVisibilityGroupGridDisplayAdapter adapter = new WorkAssignmentVisibilityGroupGridDisplayAdapter(visibilityGroup, true, true);

            visibilityGroupService.Stub(mock => mock.QueryAll(ClientSession.GetUserContext().Site)).Return(new List<VisibilityGroup>
                                                                                                               {visibilityGroup});
            view.Expect(mock => mock.ClearErrorProviders());
            
            view.AssignmentName = assignment.Name;
            view.AssignmentDescription = assignment.Description;
            view.SelectedRole = assignment.Role;
            
            view.VisibilityGroupAdapters = new List<WorkAssignmentVisibilityGroupGridDisplayAdapter>{adapter};

            Assert.IsFalse(presenter.ValidateViewHasError());
        }

        [Test]
        public void OnSaveShouldNotBeValidateIfBothReadAndWriteVisibilityGroupsNotChecked()
        {
            CreateOrEditAssignmentFormPresenter presenter = new CreateOrEditAssignmentFormPresenter(
                view,
                assignment,
                new List<WorkAssignment>(),
                roleService,
                workAssignmentService,
                visibilityGroupService, 
                siteConfigurationService);

            VisibilityGroup visibilityGroup = new VisibilityGroup(1, "vg", SiteFixture.Sarnia().IdValue, true);
            
            // the only visibility group doesn't havea  write
            WorkAssignmentVisibilityGroupGridDisplayAdapter adapter = new WorkAssignmentVisibilityGroupGridDisplayAdapter(visibilityGroup, true, false);  

            visibilityGroupService.Stub(mock => mock.QueryAll(ClientSession.GetUserContext().Site)).Return(new List<VisibilityGroup> { visibilityGroup });
            view.Expect(mock => mock.ClearErrorProviders());

            view.AssignmentName = assignment.Name;
            view.AssignmentDescription = assignment.Description;
            view.SelectedRole = assignment.Role;

            view.VisibilityGroupAdapters = new List<WorkAssignmentVisibilityGroupGridDisplayAdapter> { adapter };

            view.Expect(v => v.ShowNoGroupWithBothReadAndWriteError());
            Assert.IsTrue(presenter.ValidateViewHasError());
        }
        
        private void SetupExpectionsForValidate(WorkAssignment assignmentToValidate)
        {
            view.Expect(mock => mock.ClearErrorProviders());
            view.AssignmentName = assignmentToValidate.Name;
            view.AssignmentDescription =  assignmentToValidate.Description;
            view.SelectedRole = assignmentToValidate.Role;
        }
    }
}