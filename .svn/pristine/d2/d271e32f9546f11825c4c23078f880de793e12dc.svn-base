using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO.Excursions;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class ExcursionResponsePage : AbstractPage<OpmExcursionResponseDTO, IExcursionResponseDetails>,
        IExcursionResponsePage
    {
        public ExcursionResponsePage()
            : base(
                new DomainSummaryGrid<OpmExcursionResponseDTO>(new ExcursionResponseGridRenderer(),
                    OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT, "opmExcursionResponsesGrid"),
                new ExcursionResponseDetails())
        {
        }

        public override PageKey PageKey
        {
            get { return PageKey.EXCURSION_RESPONSE_PAGE; }
        }

        protected override bool IsCreatedByCurrentUser(OpmExcursionResponseDTO dto)
        {
            return false;
        }

        protected override bool IsUpdatedByCurrentUser(OpmExcursionResponseDTO dto)
        {
            return false;
        }
    }
}