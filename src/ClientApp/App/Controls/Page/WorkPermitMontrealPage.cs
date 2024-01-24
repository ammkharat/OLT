using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class WorkPermitMontrealPage : AbstractPage<WorkPermitMontrealDTO, IWorkPermitMontrealDetails>, IWorkPermitMontrealPage
    {
        public WorkPermitMontrealPage()
            : base(new DomainSummaryGrid<WorkPermitMontrealDTO>(
            new WorkPermitMontrealGridRenderer(), OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT, "workPermitPageGrid"),
                new WorkPermitMontrealDetails())
        {
        }

        public override PageKey PageKey
        {
            get { return PageKey.WORK_PERMIT_PAGE; }
        }

        public void DisplayInvalidPrintMessage(string message)
        {
            OltMessageBox.Show(Form.ActiveForm, message, StringResources.WorkPermitPrintFailureMessageBoxCaption, 
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void OpenDocument(string document)
        {
            FileUtility.OpenFileOrDirectoryOrWebsite(document);
        }

        protected override bool IsCreatedByCurrentUser(WorkPermitMontrealDTO permit)
        {
            return (permit != null && permit.CreatedByUserId == ClientSession.GetUserContext().User.Id);
        }

        protected override bool IsUpdatedByCurrentUser(WorkPermitMontrealDTO permit)
        {
            return (permit != null && permit.LastModifiedByByUserId == ClientSession.GetUserContext().User.Id);
        }

        public DialogResult ShowUserHasNotReadDocumentLinksMessage()
        {
            return OltMessageBox.Show(Form.ActiveForm,
                StringResources.UnreadDocumentLinksOnOneOrMorePermits,
                StringResources.UnreadDocumentLinksOnOneOrMorePermits_Title,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
        }

        public void ShowAssociatedLogForm(List<LogDTO> logDtos)
        {
            ReferencedLogForm form = new ReferencedLogForm(logDtos, MainParentForm);
            form.SetTitle(StringResources.AssociatedLogsPageTitle);
            form.ShowDialog(this);
        }
    }
}