using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    class WorkPermitTemplatePagePresenter : WorkPermitPagePresenter
    {

        private readonly Date today;

        public WorkPermitTemplatePagePresenter()
            : base(new WorkPermitTemplatePage())
        {
            //today = new Date(Clock.Now);
        }
        //protected override Range<Date> GetDefaultDateRange()
        //{
        //    return new Range<Date>(today, today);
        //}
        private static bool ActiveTemplate(WorkPermit workPermit)
        {
            return workPermit != null && workPermit.IsTemplate == true ;//&& workPermit.IsActiveTemplate == true;
        }

        protected override bool ShouldBeDisplayed(WorkPermit item)
        {
            return base.ShouldBeDisplayed(item) && ActiveTemplate(item);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.WorkPermitsTemplatePage; }
        }
    }
}
