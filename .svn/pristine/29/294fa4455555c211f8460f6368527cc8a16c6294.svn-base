using System;
using System.Net;
using Castle.Core.Internal;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class FormDocumentSuggestionPagePresenterHelper
    {
        public static void ShowEmail(string formTypeName, long formNumber, string toRecipients = null, string ccRecipients = null)
        {
            var body = String.Format(StringResources.EmailFormBody, formTypeName, formNumber);
            var subject = String.Format(StringResources.EmailFormSubject, formTypeName, formNumber);

            ShowEmail(subject, body, toRecipients, ccRecipients);
        }

        public static void ShowEmailForInitialReview(DocumentSuggestion form)
        {
            const string subjectFormat = @"Document Suggestion eForm #{0} is waiting for your review.";
            const string bodyFormat =
@"<html>
<body STYLE='font-size : 12pt; font-family : Calibri'>
<p>Document Suggestion eForm #{0} is waiting for your review. <b>Please log into OLT to review the content and suggested completion date, or provide a reason why the idea/enhancement is not approved.</b></p>
<p><b>Document #:</b> {1}<br>
<b>Document Title:</b> {2}<br>
<b>Suggested Completion Date:</b> {3}</p>
<p><b>Idea/Enhancement Summary:</b><br>{4}</p><br>
<p STYLE='font-size : 10pt'><b>Note:</b> Document Suggestion eForms not reviewed by the Suggested Completion Date above will be flagged as “Late” in OLT.</p>
</body>
</html>";

            var toRecipients = string.Empty;
            var ccRecipients = string.Empty;

            var htmlEncodedDocumentNumber = WebUtility.HtmlEncode(form.DocumentNumber);
            var htmlEncodedDocumentTitle = WebUtility.HtmlEncode(form.DocumentTitle);
            var htmlEncodedSuggestedCompletionDate = WebUtility.HtmlEncode(form.ToDateTime.ToLongDateAndTimeString());
            var htmlEncodedDescription = WebUtility.HtmlEncode(TruncateDescriptionWithEllipses(form));

            var subject = String.Format(subjectFormat, form.FormNumber);
            var body = String.Format(bodyFormat, form.FormNumber, htmlEncodedDocumentNumber, htmlEncodedDocumentTitle,
                htmlEncodedSuggestedCompletionDate, htmlEncodedDescription);

            ShowEmail(subject, body, toRecipients, ccRecipients);
        }

        public static void ShowEmailForOwnerReview(DocumentSuggestion form)
        {
            const string subjectFormat = @"Document Suggestion eForm #{0} is waiting for your review.";
            const string bodyFormat =
@"<html>
<body STYLE='font-size : 12pt; font-family : Calibri'>
<p>Document Suggestion eForm #{0} is waiting for your review. <b>Please log into OLT to review the content and enter a scheduled completion date, or provide a reason why the idea/enhancement is not approved.</b></p>
<p><b>Document #:</b> {1}<br>
<b>Document Title:</b> {2}<br>
<b>Suggested Completion Date:</b> {3}</p>
<p><b>Idea/Enhancement Summary:</b><br>{4}</p><br>
<p STYLE='font-size : 10pt'><b>Note:</b> Document Suggestion eForms not reviewed by the Suggested Completion Date above will be flagged as “Late” in OLT.</p>
</body>
</html>";

            var toRecipients = string.Empty;
            var ccRecipients = form.CreatedBy.Username;

            var htmlEncodedDocumentNumber = WebUtility.HtmlEncode(form.DocumentNumber);
            var htmlEncodedDocumentTitle = WebUtility.HtmlEncode(form.DocumentTitle);
            var htmlEncodedSuggestedCompletionDate = WebUtility.HtmlEncode(form.ToDateTime.ToLongDateAndTimeString());
            var htmlEncodedDescription = WebUtility.HtmlEncode(TruncateDescriptionWithEllipses(form));

            var subject = String.Format(subjectFormat, form.FormNumber);
            var body = String.Format(bodyFormat, form.FormNumber, htmlEncodedDocumentNumber, htmlEncodedDocumentTitle,
                htmlEncodedSuggestedCompletionDate, htmlEncodedDescription);

            ShowEmail(subject, body, toRecipients, ccRecipients);
        }

        public static void ShowEmailForDocumentIssuedOrArchived(DocumentSuggestion form)
        {
            const string subjectFormat = @"Document Suggestion eForm #{0} is completed.";
            const string bodyFormat =
@"<html>
<body STYLE='font-size : 12pt; font-family : Calibri'>
<p>Document Suggestion eForm #{0} is completed and the document has been <b>{1}</b>.</p>
<p><b>Document #:</b> {2}<br>
<b>Document Title:</b> {3}</p>
<p><b>Idea/Enhancement Summary:</b><br>{4}</p>
</body>
</html>";

            var toRecipients = form.CreatedBy.Username;
            var ccRecipients = ExtractUsernameFromApproverFullnameWithUsername(form.InitialReviewApprovedBy);

            var htmlEncodedDocumentNumber = WebUtility.HtmlEncode(form.DocumentNumber);
            var htmlEncodedDocumentTitle = WebUtility.HtmlEncode(form.DocumentTitle);
            var htmlEncodedDescription = WebUtility.HtmlEncode(TruncateDescriptionWithEllipses(form));

            var subject = String.Format(subjectFormat, form.FormNumber);
            var body = String.Format(bodyFormat, form.FormNumber, form.RecommendedToBeArchived ? "archived" : "issued", htmlEncodedDocumentNumber, htmlEncodedDocumentTitle,
                htmlEncodedDescription);

            ShowEmail(subject, body, toRecipients, ccRecipients);
        }

        public static void ShowEmailForNotApproved(DocumentSuggestion form)
        {
            const string subjectFormat = @"Document Suggestion eForm #{0} is not approved.";
            const string bodyFormat =
@"<html>
<body STYLE='font-size : 12pt; font-family : Calibri'>
<p>Document Suggestion eForm #{0} is not approved. The following information has been recorded in OLT.</p>
<p><b>Document #:</b> {1}<br>
<b>Document Title:</b> {2}</p>
<p><b>Idea/Enhancement Summary:</b><br>{3}</p>
<p><b>Reason(s) For Not Approving:</b><br>{4}</p>
</body>
</html>";

            var toRecipients = form.CreatedBy.Username;
            var ccRecipients = ExtractUsernameFromApproverFullnameWithUsername(form.InitialReviewApprovedBy);

            var htmlEncodedDocumentNumber = WebUtility.HtmlEncode(form.DocumentNumber);
            var htmlEncodedDocumentTitle = WebUtility.HtmlEncode(form.DocumentTitle);
            var htmlEncodedDescription = WebUtility.HtmlEncode(TruncateDescriptionWithEllipses(form));
            var htmlEncodedNotApprovedReason = WebUtility.HtmlEncode(form.NotApprovedReason);

            var subject = String.Format(subjectFormat, form.FormNumber);
            var body = String.Format(bodyFormat, form.FormNumber, htmlEncodedDocumentNumber, htmlEncodedDocumentTitle,
                htmlEncodedDescription, htmlEncodedNotApprovedReason);

            ShowEmail(subject, body, toRecipients, ccRecipients);
        }

        private static string ExtractUsernameFromApproverFullnameWithUsername(string fullnameWithUsername)
        {
            // i.e. fullnameWithUsername will be in this format: "Superuserup1winger, John [superuserup1winger]"

            if (fullnameWithUsername.IsNullOrEmpty()) return null;

            var tokens = fullnameWithUsername.Split('[', ']');

            return tokens.Length >= 2 ? tokens[1] : null;
        }

        private static string TruncateDescriptionWithEllipses(DocumentSuggestion form)
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