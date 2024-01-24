using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class OnPremisePersonnelAuditPage : AbstractPage<OnPremisePersonnelAuditDTO, IOnPremisePersonnelDetails>, IOnPremisePersonnelAuditPage
    {
        public OnPremisePersonnelAuditPage()
            : base(
                new DomainSummaryGrid<OnPremisePersonnelAuditDTO>(new OnPremisePersonnelAuditGridRenderer(), OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT,
                    "onPremisePersonnelAuditGrid"),
                new OnPremisePersonnelDetails())
        {
            splitContainer.SplitterDistance = splitContainer.Height - ((OnPremisePersonnelDetails)details).toolStrip.Height;
            splitContainer.IsSplitterFixed = true;
            splitContainer.FixedPanel = FixedPanel.Panel2;
            details.HideRefreshButton();
        }

        protected override bool IsCreatedByCurrentUser(OnPremisePersonnelAuditDTO dto)
        {
            return false;
        }

        protected override bool IsUpdatedByCurrentUser(OnPremisePersonnelAuditDTO dto)
        {
            return false;
        }

        public override PageKey PageKey
        {
            get { return PageKey.ON_PREMISE_PERSONNEL_AUDIT_PAGE; }
        }
    }
}