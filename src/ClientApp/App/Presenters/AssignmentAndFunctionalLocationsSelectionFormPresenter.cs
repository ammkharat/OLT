using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Deployment.Application;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class AssignmentAndFunctionalLocationsSelectionFormPresenter : BaseFormPresenter<IAssignmentAndFunctionalLocationsSelectionForm>
    {
        private readonly IWorkAssignmentService assignmentService;
        private readonly IVisibilityGroupService visibilityGroupService;
        private readonly bool changeActiveFlocsMode;

        private List<VisibilityGroup> allVisibilityGroupsForSite = new List<VisibilityGroup>();

        private IList<WorkAssignment> allAssignments;

        public static  IList<WorkAssignment> Cat_allAssignments;
        public static IList<WorkAssignment> Cat_allAssignments_PermitRequest;

        private readonly UserLoginHistory userLoginHistory;

        private readonly Dictionary<long, List<long>> assignmentIdToVisibilityGroupIdListMap = new Dictionary<long, List<long>>();  

        public AssignmentAndFunctionalLocationsSelectionFormPresenter(
            IAssignmentAndFunctionalLocationsSelectionForm assignmentAndFunctionalLocationsSelectionForm,
            bool changeActiveFlocsMode) : this(
            assignmentAndFunctionalLocationsSelectionForm,
            ClientServiceRegistry.Instance.GetService<IWorkAssignmentService>(),
            ClientServiceRegistry.Instance.GetService<IUserLoginHistoryService>(),
            ClientServiceRegistry.Instance.GetService<IVisibilityGroupService>(),
            changeActiveFlocsMode)
        {            
        }

        public AssignmentAndFunctionalLocationsSelectionFormPresenter(
            IAssignmentAndFunctionalLocationsSelectionForm assignmentAndFunctionalLocationsSelectionForm,
            IWorkAssignmentService assignmentService,
            IUserLoginHistoryService loginHistoryService,
            IVisibilityGroupService visibilityGroupService,
            bool changeActiveFlocsMode) : base(assignmentAndFunctionalLocationsSelectionForm)
        {
            this.assignmentService = assignmentService;
            this.visibilityGroupService = visibilityGroupService;
            this.changeActiveFlocsMode = changeActiveFlocsMode;

            userLoginHistory = loginHistoryService.GetLastLogin(ClientSession.GetUserContext().User);

            view.Load += HandleFormLoad;
            view.AcceptClicked += HandleAccept;
            view.CancelClicked += HandleCancel;
            view.LoadPreviousFlocsClicked += HandleLoadPreviousFlocsButtonClick;
            view.NoAssignmentCheckedChanged += HandleNoAssignmentCheckedChanged;
            view.ClearFlocsClicked += HandleClearFlocSelectionButtonClick;
            view.SelectedAssignmentChanged += HandleSelectedAssignmentChanged;
            view.SelectedAssignmentCategoryChanged += HandleSelectedAssignmentCategoryChanged;
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {            
            LoadData(new List<Action> { GetAssignments, GetVisibilityGroupsForSite });
        }

        protected override void AfterDataLoad()
        {
            UserContext userContext = ClientSession.GetUserContext();

            // performance improvement: turn off assignment change event while the form loads, otherwise it gets called repeatedly and if there are a lot of flocs in the assignments it slows things down
            view.SelectedAssignmentChanged -= HandleSelectedAssignmentChanged;

            view.SelectedReadableVisibilityGroupIds = new List<long>();

            view.Assignments = allAssignments;
//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
            //Cat_allAssignments = allAssignments;
            Cat_allAssignments = assignmentService.TemplateCategoriesQueryBySite(ClientSession.GetUserContext().Site);
            Cat_allAssignments_PermitRequest = assignmentService.PermitRequestTemplateCategoriesQueryBySite(ClientSession.GetUserContext().Site);
            
            view.AssignmentCategories = GetCategories(allAssignments);
            BuildMappingFromAssignmentToReadableVisibilityGroups();

            if (allAssignments.Count == 0)
            {
                view.DisableAssignmentSelection();
                view.DisableSelectAssignmentOption();
            }
            else
            {
                if (changeActiveFlocsMode)
                {
                    view.SelectedAssignment = userContext.Assignment;
                }
                else if (PreferenceExistsAndIsApplicableToUsersCurrentSite(userContext, userLoginHistory))
                {
                    if (userLoginHistory.Assignment == null || String.IsNullOrEmpty(userLoginHistory.Assignment.Category))
                    {
                        view.SelectedAssignmentCategory = null;
                    }
                    else
                    {
                        view.SelectedAssignmentCategory = userLoginHistory.Assignment.Category;
                    }

                    view.SelectedAssignment = userLoginHistory.Assignment;
                }
                else
                {
                    view.SelectFirstAssignment();
                }
            }

            view.GroupGridUpdated += HandleGroupGridUpdated;

            view.SelectedAssignmentChanged += HandleSelectedAssignmentChanged;
            HandleSelectedAssignmentChanged();

            if (changeActiveFlocsMode)
            {
                view.UserCheckedFunctionalLocations = userContext.RootFlocSet.FunctionalLocations;
                AddVisibilityGroupIDsToMap(view.SelectedAssignment, userContext.ReadableVisibilityGroupIds);
                UpdateVisibilityGroupsArea();
            }

            if (allVisibilityGroupsForSite.Count <= 1)
            {
                view.HideVisibilityGroupArea();
            }
        }

        private void BuildMappingFromAssignmentToReadableVisibilityGroups()
        {
            foreach (WorkAssignment assignment in allAssignments)
            {
                List<VisibilityGroupLoginDisplayAdapter> visibilityGroupLoginDisplayAdapters = BuildDefaultAdapterList(assignment.WorkAssignmentVisibilityGroups);
                List<VisibilityGroupLoginDisplayAdapter> visibilityGroupReadList = visibilityGroupLoginDisplayAdapters.FindAll(vg => vg.Read);                    
                List<long> readGroupIdResultList = visibilityGroupReadList.ConvertAll(g => g.VisibilityGroupId);
                AddVisibilityGroupIDsToMap(assignment, readGroupIdResultList);
            }
        }

        private void GetAssignments()
        {
            UserContext userContext = ClientSession.GetUserContext();
            List<WorkAssignment> assignments = assignmentService.QueryByUserAndSite(userContext.User, userContext.Site);
            
            List<SiteRolePlant> siteRolePlants = userContext.User.SiteRolePlants;
            List<WorkAssignment> assignmentsForAvailablePlants = new List<WorkAssignment>();

            foreach(SiteRolePlant siteRolePlant in siteRolePlants)
            {
                assignmentsForAvailablePlants.AddRange(assignments.FindAll(assignment => assignment.Role.Id == siteRolePlant.Role.Id && assignment.HasAtLeastOneFunctionalLocationThatIsPartOfPlant(siteRolePlant.PlantId)));
            }

            allAssignments = assignmentsForAvailablePlants.Unique(assignment => assignment.Id);
        }

        private void GetVisibilityGroupsForSite()
        {
            allVisibilityGroupsForSite = visibilityGroupService.QueryAll(ClientSession.GetUserContext().Site);
        }

        private static List<string> GetCategories(IEnumerable<WorkAssignment> assignments)
        {
            List<string> categories = new List<string>();
            foreach (WorkAssignment assignment in assignments)
            {
                if (!String.IsNullOrEmpty(assignment.Category) &&
                    !categories.Contains(assignment.Category))
                {
                    categories.Add(assignment.Category);
                }
            }
            return categories;
        }

        public DialogResultAndOutput<UserLoginSelections> Run(IWin32Window parent)
        {
            DialogResult dialogResult = view.ShowDialog(parent);
            UserLoginSelections userLoginSelections = new UserLoginSelections(view.SelectedAssignment, view.AllCheckedFunctionalLocations, view.SelectedReadableVisibilityGroupIds);
            view.Dispose();

            if (dialogResult == DialogResult.OK && changeActiveFlocsMode)
            {
                ReplaceSavedLoginFlocs(userLoginSelections);
            }

            return new DialogResultAndOutput<UserLoginSelections>(dialogResult, userLoginSelections);
        }

        private void ReplaceSavedLoginFlocs(UserLoginSelections userLoginSelections)
        {
            IUserLoginHistoryService userLoginHistoryService = ClientServiceRegistry.Instance.GetService<IUserLoginHistoryService>();
            UserContext userContext = ClientSession.GetUserContext();

            UserLoginHistory loginHistoryToUpdate = userLoginHistoryService.GetLastLogin(userContext.User);

            if ((loginHistoryToUpdate.Assignment == null && userLoginSelections.WorkAssignment == null) || (loginHistoryToUpdate.Assignment != null && loginHistoryToUpdate.Assignment.IsSame(userLoginSelections.WorkAssignment)))
            {
                loginHistoryToUpdate.SelectedFunctionalLocations = userLoginSelections.SelectedFlocs;
                userLoginHistoryService.ReplaceLoginFlocs(loginHistoryToUpdate);
            }
            else
            {
                UserLoginHistory loginHistoryToAdd = new UserLoginHistory(
                    null,
                    userContext.User,
                    Clock.Now,
                    userContext.UserShift.ShiftPattern,
                    userContext.UserShift.StartDateTime,
                    userContext.UserShift.EndDateTime,
                    userLoginSelections.WorkAssignment,
                    userLoginSelections.SelectedFlocs,
                    ClientServiceRegistry.Instance.ClientServiceHostAddress,
                    ConfigurationManager.AppSettings["FileUpdateSourceDirectory"],
                    OltEnvironment.MachineName,
                    Environment.OSVersion.ToString(),
                    OltEnvironment.DotNetVersion,
                    ApplicationDeployment.IsNetworkDeployed);

                userLoginHistoryService.SaveLoginHistory(loginHistoryToAdd);
            }
        }

        private bool NoMatchingReadAndWriteGroup()
        {
            return !VisibilityGroupLoginDisplayAdapter.ListHasAtLeastOneMatchingReadAndWrite(view.VisibilityGroupList);
        }

        public void HandleAccept()
        {
            IList<FunctionalLocation> userSelectedFlocList = view.AllCheckedFunctionalLocations;
            
            view.ClearErrors();
            bool hasError = false;

            if (NoMatchingReadAndWriteGroup())
            {
                view.SetAtLeastOneMatchingReadAndWriteGroupRequiredError();
                hasError = true;
            }

            List<VisibilityGroupLoginDisplayAdapter> visibilityGroupReadList = view.VisibilityGroupList.FindAll(vg => vg.Read);
            if (visibilityGroupReadList.Count == 0)
            {
                view.SetAtLeastOneReadableVisibilityGroupRequiredMessage();
                hasError = true;
            }

            if (hasError)
            {
                return;
            }
            
            if (userSelectedFlocList.Count == 0)
            {
                view.LaunchFunctionalLocationSelectionRequiredMessage();
            }            
            else
            {
                bool shouldCloseForm = true;
                if (ShouldShowNoAssignmentSelectedWarning())
                {
                    DialogResult dialogResult = view.ShowNoAssignmentSelectedWarning();
                    shouldCloseForm = dialogResult == DialogResult.OK;
                }

                if (shouldCloseForm)
                {
                    // This is because this is the only way to transfer these values back to the calling method.
                    view.SelectedReadableVisibilityGroupIds = GetSelectedReadableVisibilityGroupIds();
                    view.CloseForm(DialogResult.OK);
                }
            }
        }

        private List<long> GetSelectedReadableVisibilityGroupIds()
        {
            WorkAssignment selectedAssignment = view.SelectedAssignment;

            long selectedAssignmentIdValue = selectedAssignment == null ? WorkAssignment.NoneWorkAssignment.IdValue : selectedAssignment.IdValue;

            if (assignmentIdToVisibilityGroupIdListMap.ContainsKey(selectedAssignmentIdValue))
            {
                return assignmentIdToVisibilityGroupIdListMap[selectedAssignmentIdValue];
            }

            if (selectedAssignment == null)
            {
                return allVisibilityGroupsForSite.ConvertAll(g => g.IdValue);
            }

            return selectedAssignment.ReadWorkAssignmentVisibilityGroups.ConvertAll(g => g.VisibilityGroupId);
        }

        public void HandleCancel()
        {
            view.CloseForm(DialogResult.Cancel);
        }

        private void HandleGroupGridUpdated()
        {
            List<VisibilityGroupLoginDisplayAdapter> visibilityGroupReadList = view.VisibilityGroupList.FindAll(vg => vg.Read);
            List<long> readGroupIdResultList = visibilityGroupReadList.ConvertAll(g => g.VisibilityGroupId);
            AddVisibilityGroupIDsToMap(view.SelectedAssignment, readGroupIdResultList);
        }

        private List<long> GetPreviouslySelectedVisibilityGroupIDsForAssignment(WorkAssignment selectedAssignment)
        {
            long assignmentId = selectedAssignment != null ? selectedAssignment.IdValue : WorkAssignment.NoneWorkAssignment.IdValue;

            if (assignmentIdToVisibilityGroupIdListMap.ContainsKey(assignmentId))
            {
                return assignmentIdToVisibilityGroupIdListMap[assignmentId];
            }

            return new List<long>();
        }

        private void AddVisibilityGroupIDsToMap(WorkAssignment selectedAssignment, List<long> readGroupIdResultList)
        {
            long selectedAssignmentId = selectedAssignment != null ? selectedAssignment.IdValue : WorkAssignment.NoneWorkAssignment.IdValue;

            if (assignmentIdToVisibilityGroupIdListMap.ContainsKey(selectedAssignmentId))
            {
                assignmentIdToVisibilityGroupIdListMap.Remove(selectedAssignmentId);
            }

            assignmentIdToVisibilityGroupIdListMap.Add(selectedAssignmentId, new List<long>(readGroupIdResultList));
        }

        public void HandleNoAssignmentCheckedChanged()
        {
            if (view.NoAssignmentSelected)
            {
                view.DisableAssignmentSelection();                
                view.ClearSelectedAssignment();
            }
            else
            {
                view.EnableAssignmentSelection();                
                view.SelectFirstAssignment();
            }
        }

        public void HandleLoadPreviousFlocsButtonClick()
        {
            if (changeActiveFlocsMode)
            {
                view.UserCheckedFunctionalLocations = ClientSession.GetUserContext().RootFlocSet.FunctionalLocations;
            }
            else
            {
                LoadLoginFlocs();
            }
        }

        private void LoadLoginFlocs()
        {
            UserContext userContext = ClientSession.GetUserContext();

            List<FunctionalLocation> previousFunctionalLocations = null;
            if (userLoginHistory != null)
            {
                previousFunctionalLocations = userLoginHistory.SelectedFunctionalLocations;
            }

            if (previousFunctionalLocations != null &&
                previousFunctionalLocations.Count > 0 &&
                previousFunctionalLocations[0].Site.Id == userContext.Site.Id)
            {
                view.UserCheckedFunctionalLocations = previousFunctionalLocations;
            }            
        }

        public void HandleClearFlocSelectionButtonClick()
        {
            view.UserCheckedFunctionalLocations = new List<FunctionalLocation>();
        }

        public void HandleSelectedAssignmentChanged()
        {
            WorkAssignment assignment = view.SelectedAssignment;
            if (assignment != null && assignment.FunctionalLocations.Count > 0)
            {               
                view.UserCheckedFunctionalLocations = assignment.FunctionalLocations;
            }
            else
            {                
                view.UserCheckedFunctionalLocations = new List<FunctionalLocation>();
            }

            UpdateVisibilityGroupsArea();
        }

        private void UpdateVisibilityGroupsArea()
        {
            List<VisibilityGroupLoginDisplayAdapter> groups = BuildVisibilityGroupAdapterList();
            view.VisibilityGroupList = groups;
            view.WriteGroupList = BuildWriteGroupList(groups);
        }

        public void HandleSelectedAssignmentCategoryChanged()
        {
            if (string.IsNullOrEmpty(view.SelectedAssignmentCategory))
            {
                view.Assignments = allAssignments;
            }
            else
            {
                view.Assignments = allAssignments.FindAll(obj => view.SelectedAssignmentCategory.Equals(obj.Category));
            }
        }

        private static bool PreferenceExistsAndIsApplicableToUsersCurrentSite(UserContext userContext, UserLoginHistory userLoginHistory)
        {
            return userLoginHistory != null && (userLoginHistory.Assignment == null || userLoginHistory.Assignment.SiteId == userContext.SiteId);
        }

        private bool ShouldShowNoAssignmentSelectedWarning()
        {
            Site site = ClientSession.GetUserContext().Site;
            List<Role> rolesForUser = ClientSession.GetUserContext().User.GetRoles(site);

            bool userHasRoleThatWarningAppliesTo = rolesForUser.Exists(obj => obj.WarnIfWorkAssignmentNotSelected);

            return view.SelectedAssignment == null && userHasRoleThatWarningAppliesTo;
        }

        private string BuildWriteGroupList(List<VisibilityGroupLoginDisplayAdapter> groups)
        {
            List<VisibilityGroupLoginDisplayAdapter> writeGroups = groups.FindAll(g => g.Write);
            List<string> writeGroupString = writeGroups.ConvertAll(g => g.Name);
            return writeGroupString.ToCommaSeparatedString();
        }

        private List<VisibilityGroupLoginDisplayAdapter> BuildVisibilityGroupAdapterList()
        {
            List<VisibilityGroupLoginDisplayAdapter> adapters;

            WorkAssignment selectedWorkAssignment = view.SelectedAssignment;

            if (selectedWorkAssignment == null)
            {
                adapters = BuildVisibilityGroupAdapterListForNoWorkAssignment();
            }
            else
            {
                ReadOnlyCollection<WorkAssignmentVisibilityGroup> workAssignmentVisibilityGroups = selectedWorkAssignment.WorkAssignmentVisibilityGroups;
                adapters = BuildAdapterListFromPreviouslySelectedGroups(workAssignmentVisibilityGroups);
            }

            return adapters;
        }

        private List<VisibilityGroupLoginDisplayAdapter> BuildDefaultAdapterList(ReadOnlyCollection<WorkAssignmentVisibilityGroup> workAssignmentVisibilityGroups)
        {
            List<VisibilityGroupLoginDisplayAdapter> adapters = new List<VisibilityGroupLoginDisplayAdapter>();

            foreach (VisibilityGroup visibilityGroup in allVisibilityGroupsForSite)
            {
                List<WorkAssignmentVisibilityGroup> assignmentVisibilityGroups =
                    workAssignmentVisibilityGroups.FindAll(wavg => wavg.VisibilityGroupId == visibilityGroup.IdValue);

                bool isRead = false;
                bool isWrite = false;

                foreach (WorkAssignmentVisibilityGroup wavg in assignmentVisibilityGroups)
                {
                    if (wavg.VisibilityType == VisibilityType.Read)
                    {
                        isRead = true;
                    }
                    else if (wavg.VisibilityType == VisibilityType.Write)
                    {
                        isWrite = true;
                    }
                }

                adapters.Add(new VisibilityGroupLoginDisplayAdapter(visibilityGroup.IdValue, visibilityGroup.Name, isRead, isWrite));
            }

            return adapters;
        }

        private List<VisibilityGroupLoginDisplayAdapter> BuildAdapterListFromPreviouslySelectedGroups(ReadOnlyCollection<WorkAssignmentVisibilityGroup> workAssignmentVisibilityGroups)
        {
            List<VisibilityGroupLoginDisplayAdapter> adapters = new List<VisibilityGroupLoginDisplayAdapter>();
            List<long> previouslySelectedGroupsForSelectedAssignment = GetPreviouslySelectedVisibilityGroupIDsForAssignment(view.SelectedAssignment);

            foreach (VisibilityGroup visibilityGroup in allVisibilityGroupsForSite)
            {
                List<WorkAssignmentVisibilityGroup> assignmentVisibilityGroups = workAssignmentVisibilityGroups.FindAll(wavg => wavg.VisibilityGroupId == visibilityGroup.IdValue);

                bool isWrite = false;

                foreach (WorkAssignmentVisibilityGroup wavg in assignmentVisibilityGroups)
                {
                    if (wavg.VisibilityType == VisibilityType.Write)
                    {
                        isWrite = true;
                    }
                }

                bool previouslySelectedRead =
                    previouslySelectedGroupsForSelectedAssignment.Exists(a => a == visibilityGroup.IdValue);

                adapters.Add(new VisibilityGroupLoginDisplayAdapter(visibilityGroup.IdValue, visibilityGroup.Name,
                                                                    previouslySelectedRead, isWrite));
            }

            return adapters;
        }

        private List<VisibilityGroupLoginDisplayAdapter> BuildVisibilityGroupAdapterListForNoWorkAssignment()
        {
            List<VisibilityGroupLoginDisplayAdapter> adapters = new List<VisibilityGroupLoginDisplayAdapter>();
            List<long> previouslySelectedGroupsForSelectedAssignment = GetPreviouslySelectedVisibilityGroupIDsForAssignment(view.SelectedAssignment);

            if (!previouslySelectedGroupsForSelectedAssignment.IsEmpty())
            {
                foreach (VisibilityGroup visibilityGroup in allVisibilityGroupsForSite)
                {
                    bool read = previouslySelectedGroupsForSelectedAssignment.Exists(g => g == visibilityGroup.IdValue);
                    adapters.Add(new VisibilityGroupLoginDisplayAdapter(visibilityGroup.IdValue, visibilityGroup.Name, read, true));
                }
            }
            else
            {
                foreach (VisibilityGroup visibilityGroup in allVisibilityGroupsForSite)
                {
                    adapters.Add(new VisibilityGroupLoginDisplayAdapter(visibilityGroup.IdValue, visibilityGroup.Name, true, true));
                }
            }

            return adapters;
        }
    }
}
