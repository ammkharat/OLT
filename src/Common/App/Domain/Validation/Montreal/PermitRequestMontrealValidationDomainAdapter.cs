using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Domain.Validation.Montreal
{
    public class PermitRequestMontrealValidationDomainAdapter : PermitRequestMontrealBaseValidationAdapter
    {
        private readonly PermitRequestMontreal permitRequest;

        public PermitRequestMontrealValidationDomainAdapter(PermitRequestMontreal permitRequest)
        {
            this.permitRequest = permitRequest;
        }

        public override WorkPermitMontrealType WorkPermitType
        {
            get { return permitRequest.WorkPermitType; }
        }

        public override List<FunctionalLocation> FunctionalLocations
        {
            get { return permitRequest.FunctionalLocations; }
        }

        public override string Trade
        {
            get { return permitRequest.Trade; }
        }

        public override string Description
        {
            get { return permitRequest.Description; }
        }

        public override WorkPermitMontrealGroup RequestedByGroup
        {
            get { return permitRequest.RequestedByGroup; }
        }

        public override Date StartDate
        {
            get { return permitRequest.StartDate; }
        }

        public override Date EndDate
        {
            get { return permitRequest.EndDate; }
        }

        public override void ClearErrors()
        {
        }
    }
}