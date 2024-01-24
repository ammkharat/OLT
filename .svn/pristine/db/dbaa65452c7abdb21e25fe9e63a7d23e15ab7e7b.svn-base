using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Domain.Validation.Montreal
{
    public abstract class PermitRequestMontrealBaseValidationAdapter
    {
        public abstract WorkPermitMontrealType WorkPermitType { get; }

        public abstract List<FunctionalLocation> FunctionalLocations { get; }

        public abstract string Trade { get; }

        public abstract string Description { get; }

        public abstract WorkPermitMontrealGroup RequestedByGroup { get; }

        public abstract Date StartDate { get; }
        public abstract Date EndDate { get; }
        public abstract void ClearErrors();

        public virtual void ActionForNoWorkPermitTypeSelected()
        {
        }

        public virtual void ActionForNoFunctionalLocationsSelected()
        {
        }

        public virtual void ActionForNoTradeSelected()
        {
        }

        public virtual void ActionForEmptyDescription()
        {
        }

        public virtual void ActionForNoRequestedByGroupSelected()
        {
        }

        public virtual void ActionForStartDateMustBeBeforeEndDate()
        {
        }

        public virtual void ActionForEndDateMustBeOnOrAfterToday()
        {
        }
    }
}