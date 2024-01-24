using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class FormEdmontonPagePresenterHelper
    {
        public static void ShowEmail(string formTypeName, long formNumber)
        {
            var body = String.Format(StringResources.EmailFormBody, formTypeName, formNumber);
            var subject = String.Format(StringResources.EmailFormSubject, formTypeName, formNumber);

            ShowEmail(formTypeName, formNumber, subject, body);
        }

        public static void ShowEmail(string formTypeName, long formNumber, string subject, string body)
        {
            var emailPresenter = new EmailPresenter();
            emailPresenter.Email(subject, body);
        }
    }
}