using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class ConfinedSpacePage: AbstractPage<ConfinedSpaceDTO, IConfinedSpaceDetails>, IConfinedSpacePage
    {
        public ConfinedSpacePage(OltGridAppearance appearance): base(
            new DomainSummaryGrid<ConfinedSpaceDTO>(new ConfinedSpaceGridRenderer(), appearance, "confinedSpaceGrid"),
            new ConfinedSpaceDetails())
        {
        }

        protected override bool IsCreatedByCurrentUser(ConfinedSpaceDTO dto)
        {
            return (dto != null && dto.CreatedByUserId == ClientSession.GetUserContext().User.Id);
        }

        protected override bool IsUpdatedByCurrentUser(ConfinedSpaceDTO dto)
        {
            return (dto != null && dto.LastModifiedByFullnameWithUserName.Equals(ClientSession.GetUserContext().User.FullNameWithUserName));
        }

        public override PageKey PageKey
        {
            get { return PageKey.CONFINED_SPACE_PAGE; }
        }

        public void DisplayInvalidPrintMessage(string message)
        {
            OltMessageBox.Show(Form.ActiveForm, message, StringResources.ConfinedSpacePrintFailureMessageBoxCaption,
                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}