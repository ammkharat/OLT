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
    public class ConfigureWorkPermitGroupsPresenter : 
        BaseFormPresenter<IConfigureWorkPermitGroupsView>, IBackgroundingFriendly<ConfigureWorkPermitGroupsPresenter.BackGroundWorkerArgument, ConfigureWorkPermitGroupsPresenter.BackgroundWorkerResult>
    {
        private readonly BackgroundHelper<BackGroundWorkerArgument, BackgroundWorkerResult> backgroundHelper;

        private readonly IWorkPermitMontrealService service;

        private readonly List<WorkPermitMontrealGroup> deleteList = new List<WorkPermitMontrealGroup>();
        private readonly List<WorkPermitMontrealGroup> updateList = new List<WorkPermitMontrealGroup>();

        // TODO: turn off sorting by name

        public ConfigureWorkPermitGroupsPresenter(IConfigureWorkPermitGroupsView view) : base(view)
        {
            service = ClientServiceRegistry.Instance.GetService<IWorkPermitMontrealService>();
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
            AddWorkPermitMontrealGroupPresenter presenter = new AddWorkPermitMontrealGroupPresenter(new AddEditWorkPermitMontrealGroupForm(), view.Groups);
            presenter.Run(view);

            WorkPermitMontrealGroup newGroup = presenter.NewGroup;
            if (newGroup != null)
            {
                int highestDisplayOrder = GetHighestDisplayOrder();
                newGroup.DisplayOrder = highestDisplayOrder + 1;
                List<WorkPermitMontrealGroup> groups = view.Groups;
                groups.Add(newGroup);
                view.Groups = groups;
                view.Selected = newGroup;
            }
        }

        private int GetHighestDisplayOrder()
        {            
            List<WorkPermitMontrealGroup> groups = view.Groups;

            if (groups.Count == 0)
            {
                return 0;
            }

            groups.Sort((x, y) => CompareGroupsForDisplay(y, x));
            return groups[0].DisplayOrder;
        }

        private void HandleEditButtonClicked()
        {            
            WorkPermitMontrealGroup group = view.Selected;
            EditWorkPermitMontrealGroupPresenter editPresenter = new EditWorkPermitMontrealGroupPresenter(new AddEditWorkPermitMontrealGroupForm(), group, view.Groups);
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
            WorkPermitMontrealGroup group = view.Selected;
            List<WorkPermitMontrealGroup> groups = view.Groups;

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
            List<WorkPermitMontrealGroup> allGroupsFromUI = view.Groups;

            List<WorkPermitMontrealGroup> groupsToInsert = allGroupsFromUI.FindAll(g => !g.IsInDatabase());

            service.SaveWorkPermitGroups(groupsToInsert, updateList, deleteList);

            view.Close();
        }

        public BackgroundWorkerResult DoWork(BackGroundWorkerArgument argument)
        {
            List<WorkPermitMontrealGroup> allGroups = service.QueryAllGroups();
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
            List<WorkPermitMontrealGroup> groups = result.WorkPermitMontrealGroupList;
            groups.Sort(CompareGroupsForDisplay);
            view.Groups = groups;
            view.SelectFirstRow();
        }

        private int CompareGroupsForDisplay(WorkPermitMontrealGroup x, WorkPermitMontrealGroup y)
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
            public BackgroundWorkerResult(List<WorkPermitMontrealGroup> groups)
            {
                WorkPermitMontrealGroupList = groups;
            }

            public List<WorkPermitMontrealGroup> WorkPermitMontrealGroupList { get; private set; }
        }

        public class BackGroundWorkerArgument
        {
            // Empty
        }

        private void HandleMoveUpButtonClicked()
        {
            List<WorkPermitMontrealGroup> groups = view.Groups;

            if (groups.Count == 0)
            {
                return;
            }

            groups.Sort(CompareGroupsForDisplay);
            WorkPermitMontrealGroup selectedGroup = view.Selected;
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
            List<WorkPermitMontrealGroup> groups = view.Groups;

            if (groups.Count == 0)
            {
                return;
            }

            groups.Sort(CompareGroupsForDisplay);
            WorkPermitMontrealGroup selectedGroup = view.Selected;
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

        private void AddAllGroupsInDBToUpdateList(List<WorkPermitMontrealGroup> groups)
        {
            foreach (WorkPermitMontrealGroup workPermitGroup in groups)
            {
                if (workPermitGroup.IsInDatabase() && !updateList.Contains(workPermitGroup))
                {
                    updateList.Add(workPermitGroup);
                }
            }
        }
    }
}
