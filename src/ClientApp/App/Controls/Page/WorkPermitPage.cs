using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class WorkPermitPage : AbstractPage<WorkPermitDTO, IWorkPermitDetails>, IWorkPermitPage
    {
        public WorkPermitPage() : base(new DomainSummaryGrid<WorkPermitDTO>(
            new WorkPermitGridRenderer(), OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT, "workPermitPageGrid"), 
                new WorkPermitFormsFactory().Build().DetailsForm())
        {
        }

        public override PageKey PageKey
        {
            get { return PageKey.WORK_PERMIT_PAGE; }
        }

        public void DisplayInvalidWorkPermitMessage(string message, string title)
        {
            OltMessageBox.Show(Form.ActiveForm, message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public bool DisplayOptionalInvalidWorkPermitMessage(string message, string title)
        {
            return DialogResult.Yes == OltMessageBox.Show(Form.ActiveForm, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        public void DisplayInvalidPrintMessage(string message)
        {
            OltMessageBox.Show(Form.ActiveForm, message, StringResources.WorkPermitPrintFailureMessageBoxCaption, 
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void DisplayInvalidActionMessage(string message, string title)
        {
            OltMessageBox.Show(Form.ActiveForm, message, StringResources.WorkPermitApprovalFailureMessageBoxCaption, 
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public bool ShowYesNoDialog(string message, string title)
        {
            return DialogResult.Yes == OltMessageBox.Show(Form.ActiveForm, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public void DisplayCommentsForm(WorkPermit workPermit)
        {
            IWorkPermitCloseFormView workPermitCommentView = new WorkPermitCloseForm();
            new WorkPermitCommentFormPresenter(workPermitCommentView, workPermit);
            workPermitCommentView.ShowDialog(ParentForm);
        }

        protected override bool IsCreatedByCurrentUser(WorkPermitDTO permit)
        {
            return (permit != null && permit.CreatedByFullNameWithUserName.Equals((ClientSession.GetUserContext().User.FullNameWithUserName)));
        }

        protected override bool IsUpdatedByCurrentUser(WorkPermitDTO permit)
        {
            return (permit != null && permit.LastModifiedByUserId == ClientSession.GetUserContext().User.Id);
        }

    }
}