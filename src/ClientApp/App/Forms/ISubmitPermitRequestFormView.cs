using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ISubmitPermitRequestFormView : IBaseForm
    {
        event EventHandler SubmitButtonClicked;
        event EventHandler CancelButtonClicked;

        Date Date { get; set; }
        bool DateEnabled { set; }

        void ClearErrors();
        void SetErrorForDate(string message);
        void SetErrorForDateNotInRange(Date startDate, Date endDate);
        void SetErrorForNoRequestsShareAnyDates();
    }
}
