using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class CreateOrEditAssignmentFormPresenter : AbstractFormPresenter<ICreateOrEditAssignmentView, WorkAssignment>
    {
        private readonly IWorkAssignmentService workAssignmentService;
        private readonly IRoleService roleService;
        private readonly IVisibilityGroupService visibilityGroupService;
        private readonly ISiteConfigurationService siteConfigurationService;

        private readonly List<WorkAssignment> assignments;
        private SiteConfigurationDefaults defaults = null;
        
        public CreateOrEditAssignmentFormPresenter(ICreateOrEditAssignmentView view, List<WorkAssignment> assignments) : this(view, null, assignments)
        {
        }

        public CreateOrEditAssignmentFormPresenter(ICreateOrEditAssignmentView view, WorkAssignment editObject, List<WorkAssignment> assignments)
            : this(view, editObject, assignments, ClientServiceRegistry.Instance.GetService<IRoleService>(), ClientServiceRegistry.Instance.GetService<IWorkAssignmentService>(), 
                ClientServiceRegistry.Instance.GetService<IVisibilityGroupService>(), ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>())
        {
        }

        public CreateOrEditAssignmentFormPresenter(ICreateOrEditAssignmentView view, WorkAssignment editObject, List<WorkAssignment> assignments, 
            IRoleService roleService, IWorkAssignmentService workAssignmentService, IVisibilityGroupService visibilityGroupService, ISiteConfigurationService siteConfigurationService) : base(view, editObject)
        {
            this.assignments = assignments;
            this.workAssignmentService = workAssignmentService;
            this.roleService = roleService;
            this.visibilityGroupService = visibilityGroupService;
            this.siteConfigurationService = siteConfigurationService;
        }
       
        public override void HandleSaveAndCloseButtonClick(object sender, EventArgs eventArgs)
        {
            SaveOrUpdate(true);
        }

        protected override void SaveOrUpdateComplete(bool saveOrUpdateSucceeded)
        {
            if (saveOrUpdateSucceeded)
            {
                view.SetDialogResultOK();
            }
        }

        public void HandleFormLoad(object sender, EventArgs e)
        {
            Site site = userContext.Site;
            view.AssignmentSite = site.Name;
            List<Role> roles = GetSortedRoleList();
            
            defaults = siteConfigurationService.QuerySiteConfigurationDefaultsBySiteId(ClientSession.GetUserContext().SiteId);
           
            view.Categories = GetUniqueCategories(assignments);

            view.Roles = roles;
            
            if(!IsEdit)
            {
                Role role = null;

                if (roles.Count > 0)
                {
                    role = roles[0];
                }

                editObject = new WorkAssignment(null, null, null, userContext.SiteId, role);
                editObject.CopyTargetAlertResponseToLog = defaults.CopyTargetAlertResponseToLog;

                view.ViewTitle = StringResources.CreateOrEditWorkAssignmentCreateFormTitle;            
            }

            UpdateViewFromEditObject();

            view.VisibilityGroupAdapters = CreateVisibilityGroupGridAdapter();
        }

        private List<WorkAssignmentVisibilityGroupGridDisplayAdapter> CreateVisibilityGroupGridAdapter()
        {
            List<VisibilityGroup> visibilityGroups = visibilityGroupService.QueryAll(userContext.Site);
            List<WorkAssignmentVisibilityGroupGridDisplayAdapter> adapters = new List<WorkAssignmentVisibilityGroupGridDisplayAdapter>(visibilityGroups.Count);

            foreach(VisibilityGroup group in visibilityGroups)
            {
                bool canWrite = (!IsEdit && group.IsSiteDefault) || (IsEdit && editObject.CanWrite(group));
                bool canRead = (!IsEdit && group.IsSiteDefault) || (IsEdit && editObject.CanRead(group));
                WorkAssignmentVisibilityGroupGridDisplayAdapter adapter = new WorkAssignmentVisibilityGroupGridDisplayAdapter(group, canRead, canWrite);
                adapters.Add(adapter);
            }
            return adapters;
        }

        private static List<string> GetUniqueCategories(IEnumerable<WorkAssignment> workAssignments)
        {
            List<string> categories = new List<string>();

            foreach (WorkAssignment assignment in workAssignments)
            {
                categories.AddAndSort(assignment.Category);
            }

            return categories;
        }

        private List<Role> GetSortedRoleList()
        {
            List<Role> rolesToDisplayToUser = roleService.QueryRolesBySite(userContext.Site);

            if (IsEdit)
            {
                Role roleForAssignment = editObject.Role;

                bool assignmentRoleExistsInRoleListFromDatabase = 
                    rolesToDisplayToUser.Exists(role => role.IdValue == roleForAssignment.IdValue);

                // This will happen if a role is assigned to a WorkAssignment, but then all role elements are unassociated
                // from that Role. It won't show up in the DB query since the query is based on the RoleElementTemplate table.
                if (!assignmentRoleExistsInRoleListFromDatabase)
                {
                    rolesToDisplayToUser.Add(roleForAssignment);
                }
            }

            rolesToDisplayToUser.Sort(Role.CompareByName);            
            return rolesToDisplayToUser;
        }

        private void UpdateViewFromEditObject()
        {
            view.AssignmentName = editObject.Name;
            view.AssignmentDescription = editObject.Description;
            view.Category = editObject.Category;
            view.ViewTitle = StringResources.CreateOrEditWorkAssignmentEditFormTitle;
            view.SelectedRole = editObject.Role;            
        }

        public override bool ValidateViewHasError()
        {
            view.ClearErrorProviders();

            bool hasError = false;

            string name = view.AssignmentName;
            string description = view.AssignmentDescription;
            Role role = view.SelectedRole;

            if (name.IsNullOrEmptyOrWhitespace())
            {
                view.ShowNameIsEmptyError();
                hasError = true;
            }
            else if (ExistingAssignmentListContainsDesiredName(name))
            {
                view.ShowNameAlreadyExistsError();
                hasError = true;
            }

            if (description.IsNullOrEmptyOrWhitespace())
            {
                view.ShowDescriptionIsEmptyError();
                hasError = true;
            }

            if (role == null)
            {
                view.ShowRoleIsNullError();
                hasError = true;
            }

            if (!HasAtLeastOneVisibilityGroupWithReadAndWrite())
            {
                view.ShowNoGroupWithBothReadAndWriteError();
                hasError = true;
            }
            return hasError;
        }

        private bool HasAtLeastOneVisibilityGroupWithReadAndWrite()
        {
            return view.VisibilityGroupAdapters.Exists(a => a.CanRead && a.CanWrite);
        }

        private bool ExistingAssignmentListContainsDesiredName(string name)
        {
            if (editObject != null) // editing
            {
                return assignments.Exists(obj => editObject.Id != obj.Id && name.Equals(obj.Name));
            }
            return assignments.Exists(obj => name.Equals(obj.Name));
        }

        public override void Insert(SaveUpdateDomainObjectContainer<WorkAssignment> workAssignment)
        {                                   
            workAssignmentService.Insert(workAssignment.Item);
        }

        public override void Update(SaveUpdateDomainObjectContainer<WorkAssignment> workAssignment)
        {            
            workAssignmentService.Update(workAssignment.Item);
        }

        protected override SaveUpdateDomainObjectContainer<WorkAssignment> GetPopulatedEditObjectToUpdate()
        {
            SetViewDataOnEditObject();
            return new SaveUpdateDomainObjectContainer<WorkAssignment>(editObject);
        }

        protected override SaveUpdateDomainObjectContainer<WorkAssignment> GetNewObjectToInsert()
        {
            SetViewDataOnEditObject();
            return new SaveUpdateDomainObjectContainer<WorkAssignment>(editObject);
        }

        private void SetViewDataOnEditObject()
        {
            List<WorkAssignmentVisibilityGroup> adapters = GetWorkAssignmentVisibilityGroups();

            editObject.SetVisibilityGroups(adapters);

            editObject.Name = view.AssignmentName;
            editObject.Description = view.AssignmentDescription;
            editObject.Category = view.Category;
            editObject.Role = view.SelectedRole;                 
            
        }

        private List<WorkAssignmentVisibilityGroup> GetWorkAssignmentVisibilityGroups()
        {
            ReadOnlyCollection<WorkAssignmentVisibilityGroup> currentConfiguration = IsEdit
                                                                                  ? editObject.WorkAssignmentVisibilityGroups
                                                                                  : new ReadOnlyCollection<WorkAssignmentVisibilityGroup>(new List<WorkAssignmentVisibilityGroup>(0));

            long? workAssignmentId = IsEdit ? editObject.Id : null;

            List<WorkAssignmentVisibilityGroup> newConfiguration = new List<WorkAssignmentVisibilityGroup>();

            foreach (WorkAssignmentVisibilityGroupGridDisplayAdapter adapter in view.VisibilityGroupAdapters)
            {
                if (adapter.CanRead)
                {
                    WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup = currentConfiguration.Find(g => g.VisibilityGroupId == adapter.IdValue && g.VisibilityType == VisibilityType.Read);
                    if (workAssignmentVisibilityGroup != null)
                    {
                        newConfiguration.Add(workAssignmentVisibilityGroup);
                    }
                    else
                    {
                        WorkAssignmentVisibilityGroup newGroup = new WorkAssignmentVisibilityGroup(null, workAssignmentId, adapter.IdValue, adapter.GroupName, VisibilityType.Read);
                        newConfiguration.Add(newGroup);
                    }
                }
                if (adapter.CanWrite)
                {
                    WorkAssignmentVisibilityGroup workAssignmentVisibilityGroup = currentConfiguration.Find(g => g.VisibilityGroupId == adapter.IdValue && g.VisibilityType == VisibilityType.Write);
                    if (workAssignmentVisibilityGroup != null)
                    {
                        newConfiguration.Add(workAssignmentVisibilityGroup);
                    }
                    else
                    {
                        WorkAssignmentVisibilityGroup newGroup = new WorkAssignmentVisibilityGroup(null, workAssignmentId, adapter.IdValue, adapter.GroupName, VisibilityType.Write);
                        newConfiguration.Add(newGroup);
                    }
                }
            }
            return newConfiguration;
        }

        public void HandleAdvancedButtonClick(object sender, EventArgs e)
        {           
            WorkAssignmentAdvancedConfigurationFormPresenter advancedConfigurationFormPresenter = new WorkAssignmentAdvancedConfigurationFormPresenter(editObject, IsEdit, defaults);
            advancedConfigurationFormPresenter.Run(view);            
        }
    }
}