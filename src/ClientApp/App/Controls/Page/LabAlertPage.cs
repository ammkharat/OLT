using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class LabAlertPage : AbstractPage<LabAlertDTO, ILabAlertDetails>, ILabAlertPage
    {
        public LabAlertPage()
            : base(new DomainSummaryGrid<LabAlertDTO>(
                new LabAlertGridRenderer(true), OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT, string.Empty), 
                new LabAlertDetails())
        {
        }

        public override PageKey PageKey
        {
            get { return PageKey.LAB_ALERT_PAGE; }
        }

        protected override bool IsCreatedByCurrentUser(LabAlertDTO dto)
        {
            return dto != null
                   && dto.LastModifiedByUserId == ClientSession.GetUserContext().User.Id;
        }

        protected override bool IsUpdatedByCurrentUser(LabAlertDTO dto)
        {
            return dto != null
                   && dto.LastModifiedByUserId == ClientSession.GetUserContext().User.Id;
        }

    }
}