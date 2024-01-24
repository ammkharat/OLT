using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class SAPNotificationPage : AbstractPage<SAPNotificationDTO, ISAPNotificationDetails>, ISAPNotificationPage
    {
        public SAPNotificationPage(): base
                (
                new DomainSummaryGrid<SAPNotificationDTO>(new SAPNotificationGridRenderer(), OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT, string.Empty),
                new SAPNotificationDetails()
                )
        {
        }

        public override PageKey PageKey
        {
            get { return PageKey.SAP_NOTIFICATION_PAGE; }
        }

        protected override bool IsCreatedByCurrentUser(SAPNotificationDTO dto)
        {
            // This will never be created by a user of the app since it's updated in SAP
            return false;
        }

        protected override bool IsUpdatedByCurrentUser(SAPNotificationDTO dto)
        {
            return false;
        }

    }
}
