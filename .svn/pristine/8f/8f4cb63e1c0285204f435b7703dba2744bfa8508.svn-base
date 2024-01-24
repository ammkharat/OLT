using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class PermitRequestMontrealPage : AbstractPage<PermitRequestMontrealDTO, IPermitRequestMontrealDetails>, IPermitRequestMontrealPage
    {
        public PermitRequestMontrealPage() : base(
            new DomainSummaryGrid<PermitRequestMontrealDTO>(
                new PermitRequestMontrealGridRenderer(),
                OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT,
                "permitRequestMontrealGrid"),
            new PermitRequestMontrealDetails()
            )
        {
        }

        public override PageKey PageKey
        {
            get { return PageKey.PERMIT_REQUEST_PAGE; }
        }

        protected override bool IsCreatedByCurrentUser(PermitRequestMontrealDTO dto)
        {
            return (dto != null && dto.CreatedByUserId == ClientSession.GetUserContext().User.Id);  
        }

        protected override bool IsUpdatedByCurrentUser(PermitRequestMontrealDTO dto)
        {
            return (dto != null && dto.LastModifiedByFullnameWithUserName.Equals(ClientSession.GetUserContext().User.FullNameWithUserName));
        }

    }
}
