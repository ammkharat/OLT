using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class DeviationAlertPage : AbstractPage<DeviationAlertDTO, IDeviationAlertDetails>, IDeviationAlertPage
    {
        public DeviationAlertPage()
            : base(new DomainSummaryGrid<DeviationAlertDTO>(
                new DeviationAlertGridRenderer(true), OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT, string.Empty), 
                    new DeviationAlertDetails())
        {
        }

        public override PageKey PageKey
        {
            get { return PageKey.DEVIATION_ALERT_PAGE; }
        }

        protected override bool IsCreatedByCurrentUser(DeviationAlertDTO deviationAlertDTO)
        {
            // TODO: This should use created by user.
            return deviationAlertDTO != null
                   && deviationAlertDTO.LastModifiedUserId == ClientSession.GetUserContext().User.Id;
        }

        protected override bool IsUpdatedByCurrentUser(DeviationAlertDTO deviationAlertDTO)
        {
            return deviationAlertDTO != null
                   && deviationAlertDTO.LastModifiedUserId == ClientSession.GetUserContext().User.Id;
        }

    }
}