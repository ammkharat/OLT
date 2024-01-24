using System;
using System.Net;
using Castle.Core.Internal;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class FormProcedureDeviationPagePresenterHelper
    {
        public static void ShowEmail(string formTypeName, long formNumber, string toRecipients = null, string ccRecipients = null)
        {
            var body = String.Format(StringResources.EmailFormBody, formTypeName, formNumber);
            var subject = String.Format(StringResources.EmailFormSubject, formTypeName, formNumber);

            ShowEmail(subject, body, toRecipients, ccRecipients);
        }

        public static void ShowEmailForRevisionRequired(ProcedureDeviation form)
        {
            const string subjectFormat = @"Operating Procedure Deviation eForm #{0} is waiting for your revision.";
            const string bodyFormat =
@"<html>
<body STYLE='font-size : 12pt; font-family : Calibri'>
<p>Operating Procedure Deviation eForm #{0} is waiting for your revision. <b>Please log into OLT to review the content and general comments, and approve or complete the operating procedure deviation.</b></p>
<p><b>Operating Procedure #:</b> {1}<br>
<b>Operating Procedure Title:</b> {2}<br>
<b>End Date:</b> {3}</p>
<p><b>General Comments:</b><br>{4}</p><br>
<p STYLE='font-size : 10pt'><b>Note:</b> Operating Procedure Deviation eForms not completed by the End Date above will be flagged as “Expired” in OLT.</p>
</body>
</html>";

            var toRecipients = string.Empty;
            var ccRecipients = string.Empty;

            var htmlEncodedOperatingProcedureNumber = WebUtility.HtmlEncode(form.OperatingProcedureNumber);
            var htmlEncodedOperatingProcedureTitle = WebUtility.HtmlEncode(form.OperatingProcedureTitle);
            var htmlEncodedSuggestedCompletionDate = WebUtility.HtmlEncode(form.ToDateTime.ToLongDateAndTimeString());
            var htmlEncodedDescription = WebUtility.HtmlEncode(TruncateDescriptionWithEllipses(form));

            var subject = String.Format(subjectFormat, form.FormNumber);
            var body = String.Format(bodyFormat, form.FormNumber, htmlEncodedOperatingProcedureNumber, htmlEncodedOperatingProcedureTitle,
                htmlEncodedSuggestedCompletionDate, htmlEncodedDescription);

            ShowEmail(subject, body, toRecipients, ccRecipients);
        }

        private static string ExtractUsernameFromApproverFullnameWithUsername(string fullnameWithUsername)
        {
            // i.e. fullnameWithUsername will be in this format: "Superuserup1winger, John [superuserup1winger]"

            if (fullnameWithUsername.IsNullOrEmpty()) return null;

            var tokens = fullnameWithUsername.Split('[', ']');

            return tokens.Length >= 2 ? tokens[1] : null;
        }

        private static string TruncateDescriptionWithEllipses(ProcedureDeviation form)
        {
            const int maxCharsToDisplay = 200;

            if (form.Description.IsNullOrEmptyOrWhitespace() || form.Description.Length < maxCharsToDisplay) return form.Description;

            return form.Description.Truncate(maxCharsToDisplay) + " [see OLT for detailed information]";
        }

        private static void ShowEmail(string subject, string body, string toRecipients, string ccRecipients)
        {
            var emailPresenter = new EmailPresenter();
            emailPresenter.Email(subject, body, true, toRecipients, ccRecipients);
        }
    }
}