using System;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class DirectivePage : AbstractPage<DirectiveDTO, IDirectiveDetails>, IDirectivePage
    {
        public DirectivePage()
            : base(
                new DomainSummaryGrid<DirectiveDTO>(new DirectiveGridRenderer(), OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT, "directiveGrid"),
                new DirectiveDetails())
        {
        }

        protected override bool IsCreatedByCurrentUser(DirectiveDTO dto)
        {
            return (dto != null && dto.CreatedByUserId == ClientSession.GetUserContext().User.Id);
        }

        protected override bool IsUpdatedByCurrentUser(DirectiveDTO dto)
        {
            return (dto != null && dto.LastModifiedByUserId == ClientSession.GetUserContext().User.Id);
        }

        public override PageKey PageKey
        {
            get { return PageKey.DIRECTIVE_PAGE; }
        }

        public void ExpireSuccessfulMessage()
        {
            OltMessageBox.Show(Form.ActiveForm, StringResources.ExpireSuccessfulMessage, StringResources.ExpireDialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public DialogResult ShowEditingActiveDirectiveWarning()
        {
            return OltMessageBox.Show(Form.ActiveForm, StringResources.ChangingActiveDirectiveWarning, StringResources.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, ContentAlignment.MiddleLeft);
        }

        public DialogResult ShowExpireAndCloneActiveReadDirectiveWarning()
        {
            return OltMessageBox.Show(Form.ActiveForm, StringResources.ChangingActiveReadDirectiveWarning, StringResources.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, ContentAlignment.MiddleLeft);
        }
    }
}
