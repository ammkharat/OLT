using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkAssignmentAdvancedConfigurationFormPresenter :
        BaseFormPresenter<IWorkAssignmentAdvancedConfigurationView>
    {
        private readonly SiteConfigurationDefaults defaults;
        private readonly bool isEdit;
        private readonly WorkAssignment workAssignment;

        public WorkAssignmentAdvancedConfigurationFormPresenter(WorkAssignment workAssignment, bool isEdit,
            SiteConfigurationDefaults defaults) : base(new WorkAssignmentAdvancedConfigurationForm())
        {
            this.workAssignment = workAssignment;
            this.isEdit = isEdit;
            this.defaults = defaults;

            view.OkButtonClick += HandleOKButtonClick;
            view.CancelButtonClick += HandleCancelButtonClick;
            view.Load += HandleLoad;
        }

        private void HandleLoad(object sender, EventArgs e)
        {
            if (isEdit)
            {
                LoadFormFromWorkAssignment();
            }
            else
            {
                LoadFormWithDefaults();
            }
        }

        private void HandleOKButtonClick()
        {
            SaveValuesToWorkAssignment();
            view.Close();
        }

        private void HandleCancelButtonClick()
        {
            view.Close();
        }

        private void LoadFormFromWorkAssignment()
        {
            var userContext = ClientSession.GetUserContext();
            view.ShowActionItemsOnHandoverBasedOnWorkAssignmentAndFlocs =
                workAssignment.UseWorkAssignmentForActionItemHandoverDisplay;
            view.CopyTargetAlertResponseToLog = workAssignment.CopyTargetAlertResponseToLog;
            view.ShowLubesCsdOnShiftHandoverReportIsVisible = ClientSession.GetUserContext().IsLubesSite;
            view.ShowLubesCsdOnShiftHandoverReport = workAssignment.ShowLubesCsdOnShiftHandoverReport;
            view.ShowEventExcursionsIsVisible =
                userContext.UserRoleElements.AuthorizedTo(RoleElement.VIEW_EVENTS_NAVIGATION);
            view.ShowEventExcursionsOnShiftHandoverReport = workAssignment.ShowEventExcursionsOnShiftHandoverReport;
        }

        private void SaveValuesToWorkAssignment()
        {
            workAssignment.UseWorkAssignmentForActionItemHandoverDisplay =
                view.ShowActionItemsOnHandoverBasedOnWorkAssignmentAndFlocs;
            workAssignment.CopyTargetAlertResponseToLog = view.CopyTargetAlertResponseToLog;
            workAssignment.ShowLubesCsdOnShiftHandoverReport = view.ShowLubesCsdOnShiftHandoverReport;
            workAssignment.ShowEventExcursionsOnShiftHandoverReport = view.ShowEventExcursionsOnShiftHandoverReport;
        }

        private void LoadFormWithDefaults()
        {
            view.ShowActionItemsOnHandoverBasedOnWorkAssignmentAndFlocs = true;
            view.CopyTargetAlertResponseToLog = defaults.CopyTargetAlertResponseToLog;
        }
    }
}