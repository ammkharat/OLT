using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class StandingOrderPage : AbstractLogDefinitionPage
    {
        public StandingOrderPage() : base(new LogDefinitionGridRenderer(true))
        {
        }

        public override PageKey PageKey
        {
            get { return PageKey.STANDING_ORDERS_PAGE; }
        }
    }
}
