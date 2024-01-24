using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class WorkPermitForTodayPagePresenter : WorkPermitPagePresenter
    {
        private readonly Date today;

        public WorkPermitForTodayPagePresenter() : base(new WorkPermitForTodayPage())
        {
            today = new Date(Clock.Now);
        }

        protected override Range<Date> GetDefaultDateRange()
        {
            return new Range<Date>(today, today);
        }

        protected override bool ShouldBeDisplayed(WorkPermit item)
        {
            return IsItemInDateRange(item, GetDefaultDateRange());
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.WorkPermitsForToday; }
        }
    }
}
