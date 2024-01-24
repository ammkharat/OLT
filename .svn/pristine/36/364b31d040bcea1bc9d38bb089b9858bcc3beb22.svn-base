using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureMudsWorkPermitGroupsPresenter : 
        BaseFormPresenter<IConfigureMudsWorkPermitGroupsView>, IBackgroundingFriendly<ConfigureMudsWorkPermitGroupsPresenter.BackGroundWorkerArgument, ConfigureMudsWorkPermitGroupsPresenter.BackgroundWorkerResult>
    {
        private readonly BackgroundHelper<BackGroundWorkerArgument, BackgroundWorkerResult> backgroundHelper;

        private readonly IWorkPermitMudsService service;

        private readonly List<WorkPermitMudsGroup> deleteList = new List<WorkPermitMudsGroup>();
        private readonly List<WorkPermitMudsGroup> updateList = new List<WorkPermitMudsGroup>();

        // TODO: turn off sorting by name

        public ConfigureMudsWorkPermitGroupsPresenter(IConfigureMudsWorkPermitGroupsView view) : base(view)
        {
            service = ClientServiceRegistry.Instance.GetService<IWorkPermitMudsService>();
            backgroundHelper = new BackgroundHelper<BackGroundWorkerArgument, BackgroundWorkerResult>(new ClientBackgroundWorker(), this);

            view.Load += Load;
            view.MoveUpButtonClicked += HandleMoveUpButtonClicked;
            view.MoveDownButtonClicked += HandleMoveDownButtonClicked;
            view.AddButtonClicked += HandleAddButtonClicked;
            view.DeleteButtonClicked += HandleDeleteButtonClicked;
            view.EditButtonClicked += HandleEditButtonClicked;
            view.SaveButtonClicked += HandleSaveButtonClicked;
            view.CancelButtonClicked += CloseButton_Clicked;
        }

        public void Load(object sender, EventArgs e)
        {
            ReloadGrid();
        }

        private void ReloadGrid()
        {
            backgroundHelper.Run(null);
        }

        private void HandleAddButtonClicked()
        {
            AddWorkPermitMudsGroupPresenter presenter = new AddWorkPermitMudsGroupPresenter(new AddEditWorkPermitMudsGroupForm(), view.Groups);
            presenter.Run(view);

            WorkPermitMudsGroup newGroup = presenter.NewGroup;
            if (newGroup != null)
            {
                int highestDisplayOrder = GetHighestDisplayOrder();
                newGroup.DisplayOrder = highestDisplayOrder + 1;
                List<WorkPermitMudsGroup> groups = view.Groups;
                groups.Add(newGroup);
                view.Groups = groups;
                view.Selected = newGroup;
            }
        }

        private int GetHighestDisplayOrder()
        {            
            List<WorkPermitMudsGroup> groups = view.Groups;

            if (groups.Count == 0)
            {
                return 0;
            }

            groups.Sort((x, y) => CompareGroupsForDisplay(y, x));
            return groups[0].DisplayOrder;
        }

        private void HandleEditButtonClicked()
        {            
            WorkPermitMudsGroup group = view.Selected;
            EditWorkPermitMudsGroupPresenter editPresenter = new EditWorkPermitMudsGroupPresenter(new AddEditWorkPermitMudsGroupForm(), group, view.Groups);
            editPresenter.Run(view);

            if (group.IsInDatabase() && !updateList.Contains(group))
            {
                updateList.Add(group);
            }

            view.RefreshGrid();
            view.Selected = group;
        }

        private void HandleDeleteButtonClicked()
        {
            WorkPermitMudsGroup group = view.Selected;
            List<WorkPermitMudsGroup> groups = view.Groups;

            if (group.IsInDatabase() && !deleteList.Contains(group))
            {
                deleteList.Add(group);
            }
            
            groups.Remove(group);
            DisplayOrderHelper.ResetDisplayValues(groups);
            view.Groups = groups;
            view.SelectFirstRow();
        }

        private void HandleSaveButtonClicked()
        {
            List<WorkPermitMudsGroup> allGroupsFromUI = view.Groups;

            List<WorkPermitMudsGroup> groupsToInsert = allGroupsFromUI.FindAll(g => !g.IsInDatabase());

            service.SaveWorkPermitGroups(groupsToInsert, updateList, deleteList);

            view.Close();
        }

        public BackgroundWorkerResult DoWork(BackGroundWorkerArgument argument)
        {
            List<WorkPermitMudsGroup> allGroups = service.QueryAllGroups();
            return new BackgroundWorkerResult(allGroups);
        }

        public void BeforeDoingWork()
        {
            view.DisableView();
        }

        public void AfterDoingWork()
        {
            view.EnableView();
        }

        public void WorkSuccessfullyCompleted(BackgroundWorkerResult result)
        {
            List<WorkPermitMudsGroup> groups = result.WorkPermitMudsGroupList;
            groups.Sort(CompareGroupsForDisplay);
            view.Groups = groups;
            view.SelectFirstRow();
        }

        private int CompareGroupsForDisplay(WorkPermitMudsGroup x, WorkPermitMudsGroup y)
        {
            return x.DisplayOrder.CompareTo(y.DisplayOrder);  
        }

        public void OnError(Exception e)
        {
        
        }

        public void WorkCompletedOrCancelled()
        {
            
        }

        public static string CreateLockIdentifier(Site site)
        {
            return "Configure Work Permit Groups for Site: " + site.IdValue;
        }

        public class BackgroundWorkerResult
        {
            public BackgroundWorkerResult(List<WorkPermitMudsGroup> groups)
            {
                WorkPermitMudsGroupList = groups;
            }

            public List<WorkPermitMudsGroup> WorkPermitMudsGroupList { get; private set; }
        }

        public class BackGroundWorkerArgument
        {
            // Empty
        }

        private void HandleMoveUpButtonClicked()
        {
            List<WorkPermitMudsGroup> groups = view.Groups;

            if (groups.Count == 0)
            {
                return;
            }

            groups.Sort(CompareGroupsForDisplay);
            WorkPermitMudsGroup selectedGroup = view.Selected;
            int index = groups.IndexOf(selectedGroup);

            if (index == 0)
            {
                return;
            }

            groups.Remove(selectedGroup);
            groups.Insert(index - 1, selectedGroup);
            DisplayOrderHelper.ResetDisplayValues(groups);

            AddAllGroupsInDBToUpdateList(groups);

            view.Groups = groups;
            view.Selected = selectedGroup;
        }

        private void HandleMoveDownButtonClicked()
        {            
            List<WorkPermitMudsGroup> groups = view.Groups;

            if (groups.Count == 0)
            {
                return;
            }

            groups.Sort(CompareGroupsForDisplay);
            WorkPermitMudsGroup selectedGroup = view.Selected;
            int index = groups.IndexOf(selectedGroup);

            if (index == groups.Count - 1)
            {
                return;
            }

            groups.Remove(selectedGroup);
            groups.Insert(index + 1, selectedGroup);
            DisplayOrderHelper.ResetDisplayValues(groups);

            AddAllGroupsInDBToUpdateList(groups);

            view.Groups = groups;
            view.Selected = selectedGroup;
        }

        private void AddAllGroupsInDBToUpdateList(List<WorkPermitMudsGroup> groups)
        {
            foreach (WorkPermitMudsGroup workPermitGroup in groups)
            {
                if (workPermitGroup.IsInDatabase() && !updateList.Contains(workPermitGroup))
                {
                    updateList.Add(workPermitGroup);
                }
            }
        }
    }
}
