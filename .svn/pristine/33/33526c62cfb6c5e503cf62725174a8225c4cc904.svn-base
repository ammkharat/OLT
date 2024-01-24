using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class PermitRequestMudsPage : AbstractPage<PermitRequestMudsDTO, IPermitRequestMudsDetails>, IPermitRequestMudsPage
    {
        public PermitRequestMudsPage()
            : base(
            new DomainSummaryGrid<PermitRequestMudsDTO>(
                new PermitRequestMudsGridRenderer(),
                OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT,
                "permitRequestMudsGrid"),
            new PermitRequestMudsDetails()
            )
        {
        }

        public override PageKey PageKey
        {
            get { return PageKey.PERMIT_REQUEST_PAGE; }
        }

        protected override bool IsCreatedByCurrentUser(PermitRequestMudsDTO dto)
        {
            return (dto != null && dto.CreatedByUserId == ClientSession.GetUserContext().User.Id);  
        }

        protected override bool IsUpdatedByCurrentUser(PermitRequestMudsDTO dto)
        {
            return (dto != null && dto.LastModifiedByFullnameWithUserName.Equals(ClientSession.GetUserContext().User.FullNameWithUserName));
        }

    }
}
