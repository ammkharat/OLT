using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class WorkPermitFortHillsPage : AbstractPage<WorkPermitFortHillsDTO, IWorkPermitFortHillsDetails>,
        IWorkPermitFortHillsPage
    {
        private readonly PageKey pageKey;

        public WorkPermitFortHillsPage(OltGridAppearance appearance, PageKey pageKey)
            : base(
                new DomainSummaryGrid<WorkPermitFortHillsDTO>(new WorkPermitFortHillsGridRenderer(), appearance,
                    "workPermitFortHillsGrid"),
                new WorkPermitFortHillsDetails())
        {
            this.pageKey = pageKey;
        }

        public override PageKey PageKey
        {
            get { return pageKey; }
        }

        public void DisplayInvalidPrintMessage(string message)
        {
            OltMessageBox.Show(Form.ActiveForm, message, StringResources.WorkPermitPrintFailureMessageBoxCaption,
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void DisplayInvalidMergeDueToFunctionalLocationMessage()
        {
            OltMessageBox.Show(Form.ActiveForm, StringResources.WorkPermitMergeFailureDueToDifferentAreasMessageBoxText,
                StringResources.WorkPermitMergeFailureMessageBoxCaption, MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        public bool DisplayInvalidMergeDueToParticularFieldsMessage(List<string> fieldNames)
        {
            var dialogResult =
                OltListMessageBox.Show(Form.ActiveForm,
                    StringResources.WorkPermitMergeFailureDueToIncompatibleFieldValuesMessageBoxText_MessageOne,
                    StringResources.WorkPermitMergeFailureDueToIncompatibleFieldValuesMessageBoxText_MessageTwo,
                    fieldNames, StringResources.WorkPermitMergeFailureMessageBoxCaption, MessageBoxIcon.Exclamation,
                    false);

            return dialogResult == DialogResult.Yes;
        }

        public void ShowAssociatedLogForm(List<LogDTO> associatedLogDtos)
        {
            var form = new ReferencedLogForm(associatedLogDtos, MainParentForm);
            form.SetTitle(StringResources.AssociatedLogsPageTitle);
            form.ShowDialog(this);
        }

        public bool? AskIfTheyWantToPrintTheForms()
        {
            var dialogResult =
              OltMessageBox.Show(Form.ActiveForm, "Do you want to print all forms associated to this safe work permit?",
                  "Print Forms?", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Cancel) return null;
            return dialogResult == DialogResult.Yes;
        }

        protected override bool IsCreatedByCurrentUser(WorkPermitFortHillsDTO permit)
        {
            return (permit != null && permit.CreatedByUserId == ClientSession.GetUserContext().User.Id);
        }

        protected override bool IsUpdatedByCurrentUser(WorkPermitFortHillsDTO permit)
        {
            return (permit != null && permit.LastModifiedUserId == ClientSession.GetUserContext().User.Id);
        }
    }
}