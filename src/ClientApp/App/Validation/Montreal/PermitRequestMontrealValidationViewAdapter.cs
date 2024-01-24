using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Validation.Montreal;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Validation.Montreal
{
    public class PermitRequestMontrealValidationViewAdapter : PermitRequestMontrealBaseValidationAdapter
    {
        private readonly IPermitRequestMontrealFormView view;

        public PermitRequestMontrealValidationViewAdapter(IPermitRequestMontrealFormView view)
        {
            this.view = view;
        }

        public override void ClearErrors()
        {
            view.ClearErrorProviders();
        }

        public override WorkPermitMontrealType WorkPermitType
        {
            get { return view.WorkPermitType; }
        }

        public override void ActionForNoWorkPermitTypeSelected()
        {
            view.ShowNoWorkPermitTypeSelectedError();
        }

        public override List<FunctionalLocation> FunctionalLocations
        {
            get { return view.FunctionalLocations; }
        }

        public override void ActionForNoFunctionalLocationsSelected()
        {
            view.ShowNoFunctionalLocationsSelectedError();
        }

        public override string Trade
        {
            get { return view.Trade; }
        }

        public override void ActionForNoTradeSelected()
        {
            view.ShowTradeIsEmptyError();
        }

        public override string Description
        {
            get { return view.Description; }
        }

        public override void ActionForEmptyDescription()
        {
            view.ShowDescriptionIsEmptyError();
        }

        public override WorkPermitMontrealGroup RequestedByGroup
        {
            get { return view.RequestedByGroup; }
        }

        public override void ActionForNoRequestedByGroupSelected()
        {
            view.ShowNoRequestedByGroupSelectedError();
        }

        public override Date StartDate
        {
            get { return view.StartDate; }
        }

        public override Date EndDate
        {
            get { return view.EndDate; }
        }

        public override void ActionForEndDateMustBeOnOrAfterToday()
        {
            view.ShowEndDateMustBeOnOrAfterTodayError();
        }

        public override void ActionForStartDateMustBeBeforeEndDate()
        {
            view.ShowStartDateMustBeBeforeEndDateError();
        }
    }
}
