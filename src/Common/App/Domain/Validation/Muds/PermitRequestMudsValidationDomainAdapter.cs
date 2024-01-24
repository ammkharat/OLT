using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Domain.Validation.Muds
{
    public class PermitRequestMudsValidationDomainAdapter : PermitRequestMudsBaseValidationAdapter
    {
        private readonly PermitRequestMuds permitRequest;

        public PermitRequestMudsValidationDomainAdapter(PermitRequestMuds permitRequest)
        {
            this.permitRequest = permitRequest;
        }

        public override WorkPermitMudsType WorkPermitType
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

        public override WorkPermitMudsGroup RequestedByGroup
        {
            get { return permitRequest.RequestedByGroup; }
        }

        public override string RequestedByGroupText
        {
            get { return permitRequest.RequestedByGroupText; }
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