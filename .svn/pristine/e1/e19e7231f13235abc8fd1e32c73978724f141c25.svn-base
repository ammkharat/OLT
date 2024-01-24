using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public class SubmitPermitRequestValidator<TPermitRequestDTO>
        where TPermitRequestDTO : BasePermitRequestDTO
    {
        private readonly ISubmitPermitRequestFormView view;
        private bool hasErrors;

        public SubmitPermitRequestValidator(ISubmitPermitRequestFormView view)
        {
            this.view = view;
        }

        public bool HasErrors
        {
            get { return hasErrors; }
        }

        public void ValidateAndSetErrors(List<TPermitRequestDTO> requests)
        {
            hasErrors = false;
            view.ClearErrors();

            if (view.Date < Clock.DateNow)
            {
                view.SetErrorForDate(StringResources.DateCannotBeInThePast);
                hasErrors = true;
            }

            if (requests.Exists(obj => view.Date > obj.EndDate || view.Date < obj.StartDate))
            {
                SubmitPermitRequestFormPresenterHelper<TPermitRequestDTO> helper = new SubmitPermitRequestFormPresenterHelper<TPermitRequestDTO>();
                DateRange sharedDates = helper.GetSharedDates(requests);

                if (sharedDates == null)
                {
                    view.SetErrorForNoRequestsShareAnyDates();
                }
                else
                {
                    Date startDate = new Date(sharedDates.SqlFriendlyStart);
                    Date endDate = new Date(sharedDates.SqlFriendlyEnd);

                    view.SetErrorForDateNotInRange(startDate, endDate);
                }
                
                hasErrors = true;
            }
        }


    }
}
