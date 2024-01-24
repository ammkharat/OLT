using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class PriorityPageSectionConfigurationFormPresenter : BaseFormPresenter<IPriorityPageSectionConfigurationFormView>
    {
        private readonly PriorityPageSectionKey priorityPageSectionKey;
        private readonly User user;
        private PriorityPageSectionConfiguration editObject;
        private bool saveWasSuccessful;
        private bool preferencesCleared;

        private readonly IPriorityPageSectionConfigurationService sectionConfigurationService;
        private readonly IWorkAssignmentService workAssignmentService;
        
        public PriorityPageSectionConfigurationFormPresenter(PriorityPageSectionKey priorityPageSectionKey, User user) : base(new PriorityPageSectionConfigurationForm())
        {
            this.priorityPageSectionKey = priorityPageSectionKey;
            this.user = user;
            sectionConfigurationService = ClientServiceRegistry.Instance.GetService<IPriorityPageSectionConfigurationService>();
            workAssignmentService = ClientServiceRegistry.Instance.GetService<IWorkAssignmentService>();

            view.Load += HandleLoad;
            view.SaveAndCloseClicked += HandleSaveAndCloseClicked;
            view.ClearPreferencesClicked += HandleClearPreferencesClicked;
            view.CancelClicked += HandleCancelClicked;
        }

        private void HandleSaveAndCloseClicked()
        {                        
            LoadEditObjectFromView();
            sectionConfigurationService.Save(editObject);
            saveWasSuccessful = true;
            view.Close();
        }

        private void HandleClearPreferencesClicked()
        {
            if (editObject.IsInDatabase())
            {
                sectionConfigurationService.DeleteConfiguration(editObject.IdValue);
            }

            saveWasSuccessful = false;
            preferencesCleared = true;
            editObject = null;

            view.Close();
        }

        public bool PreferencesWereCleared
        {
            get { return preferencesCleared; }
        }

        private void LoadEditObjectFromView()
        {
            editObject.SectionExpandedByDefault = view.DefaultToExpanded;
            editObject.WorkAssignments.Clear();
            editObject.WorkAssignments.AddRange(view.SelectedWorkAssignments);
        }

        private void HandleCancelClicked()
        {
            view.Close();
        }

        private void HandleLoad(object sender, EventArgs e)
        {
            view.HideWorkAssignmentSection(); // Do this first so there's no lag

            editObject = sectionConfigurationService.QueryBySectionKeyAndUserId(priorityPageSectionKey, user.IdValue);

            if (editObject == null)
            {
                view.ClearPreferencesButtonEnabled = false;
                editObject = new PriorityPageSectionConfiguration(priorityPageSectionKey, user, true, new List<WorkAssignment>(), Clock.Now);
            }
            else
            {
                view.ClearPreferencesButtonEnabled = true;
            }

            if (priorityPageSectionKey.EnableFilteringByWorkAssignment)
            {
                view.ShowWorkAssignmentSection();

                List<WorkAssignment> selectedWorkAssignments = editObject.WorkAssignments;
                List<WorkAssignment> allWorkAssignmentsForSite = workAssignmentService.QueryBySite(ClientSession.GetUserContext().Site);
              
                // Remove the user's current work assignment from the list
                WorkAssignment workAssignment = ClientSession.GetUserContext().Assignment;
                if (workAssignment != null)
                {
                    allWorkAssignmentsForSite.Remove(workAssignment);
                }

                view.SetWorkAssignments(allWorkAssignmentsForSite, selectedWorkAssignments);                                            
            }

            LoadViewFromEditObject();

            view.FormTitle = string.Format(StringResources.PriorityPageSectionConfigurationFormTitle, priorityPageSectionKey.SectionName);
        }

        private void LoadViewFromEditObject()
        {           
            view.DefaultToExpanded = editObject.SectionExpandedByDefault;                                        
        }

        public DialogResultAndOutput<PriorityPageSectionConfiguration> RunAndReturnTheEditObject(IBaseForm parent)
        {
            Run(parent);

            if (saveWasSuccessful || preferencesCleared)
            {
                return new DialogResultAndOutput<PriorityPageSectionConfiguration>(DialogResult.OK, editObject);
            }

            return new DialogResultAndOutput<PriorityPageSectionConfiguration>(DialogResult.Cancel, null);
        }
    }
}
