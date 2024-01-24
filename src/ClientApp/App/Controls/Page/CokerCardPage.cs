using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class CokerCardPage : AbstractPage<CokerCardDTO, ICokerCardDetails>, ICokerCardPage
    {
        public CokerCardPage() : base(
            new DomainSummaryGrid<CokerCardDTO>(
                new CokerCardGridRenderer(), OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT, string.Empty),
                new CokerCardDetails()
            )
        {
        }

        public override PageKey PageKey
        {
            get { return PageKey.COKER_CARD_PAGE; }
        }

        protected override bool IsCreatedByCurrentUser(CokerCardDTO dto)
        {
            return (dto != null && dto.CreatedByUserId == ClientSession.GetUserContext().User.Id);  
        }

        protected override bool IsUpdatedByCurrentUser(CokerCardDTO dto)
        {
            // TODO: 
            return false;
        }

    }
}
