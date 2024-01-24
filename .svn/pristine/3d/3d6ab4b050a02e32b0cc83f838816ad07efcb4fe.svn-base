using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class OnPremisePersonnelSupervisorPage : AbstractPage<OnPremisePersonnelSupervisorDTO, IOnPremisePersonnelDetails>, IOnPremisePersonnelSupervisorPage
    {
        public OnPremisePersonnelSupervisorPage()
            : base(
                new DomainSummaryGrid<OnPremisePersonnelSupervisorDTO>(new OnPremisePersonnelSupervisorGridRenderer(),
                    OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT,
                    "onPremisePersonnelSupervisorGrid"),
                new OnPremisePersonnelDetails())
        {
            splitContainer.SplitterDistance = splitContainer.Height - ((OnPremisePersonnelDetails) details).toolStrip.Height;
            splitContainer.IsSplitterFixed = true;
            splitContainer.FixedPanel = FixedPanel.Panel2;
        }

        public override PageKey PageKey { get { return PageKey.ON_PREMISE_PERSONNEL_SUPERVISOR_PAGE; } }

        protected override bool IsCreatedByCurrentUser(OnPremisePersonnelSupervisorDTO dto)
        {
            return false;
        }

        protected override bool IsUpdatedByCurrentUser(OnPremisePersonnelSupervisorDTO dto)
        {
            return false;
        }
    }
}