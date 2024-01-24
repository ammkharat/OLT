using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Validation.Muds;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Validation.Muds
{
    public class PermitRequestMudsValidationViewAdapter : PermitRequestMudsBaseValidationAdapter
    {
        private readonly IPermitRequestMudsFormView view;

        public PermitRequestMudsValidationViewAdapter(IPermitRequestMudsFormView view)
        {
            this.view = view;
        }

        public override void ClearErrors()
        {
            view.ClearErrorProviders();
        }

        public override WorkPermitMudsType WorkPermitType
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

        public override WorkPermitMudsGroup RequestedByGroup
        {
            get { return view.RequestedByGroup; }
        }

        public override string RequestedByGroupText
        {
            get { return view.RequestedByGroupText; }
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
