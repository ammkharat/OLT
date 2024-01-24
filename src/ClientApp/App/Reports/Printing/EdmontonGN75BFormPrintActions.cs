using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class EdmontonGN75BFormPrintActions : PrintActions<FormGN75B, FormGN75BReport, FormGN75BReportAdapter>
    {
        private  IFormEdmontonService formService;              //ayman Sarnia eip DMND0008992
        private readonly AbstractMultiGridPage page;

        public EdmontonGN75BFormPrintActions(IFormEdmontonService formService) : this(formService, null)
        {
        }

        public EdmontonGN75BFormPrintActions(IFormEdmontonService formService, AbstractMultiGridPage page)
        {
            this.formService = formService;
            this.page = page;
        }

        protected override FormGN75BReport CreateSpecificReport()
        {
            return new FormGN75BReport();
        }

        protected override List<FormGN75BReportAdapter> CreateReportAdapter(FormGN75B domainObject)
        {
            if (domainObject.FormType == EdmontonFormType.GN75BTemplate)
            {
                formService = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();
            var gn75bFormNumbers = formService.QueryFormGN75BTemplateByIdAndSiteId(domainObject.IdValue,ClientSession.GetUserContext().SiteId);
                List<long> formnmber = new List<long>();
                formnmber.Add(gn75bFormNumbers.IdValue);
            var formReportAdapter = new FormGN75BReportAdapter(domainObject, formnmber);
                
            return new List<FormGN75BReportAdapter> {formReportAdapter};
            }
            else
            {
            var gn75AFormNumbers = formService.QueryAllGN75AFormsAssociatedToFormGN75B(domainObject.IdValue);
            var formReportAdapter = new FormGN75BReportAdapter(domainObject, gn75AFormNumbers);
            return new List<FormGN75BReportAdapter> {formReportAdapter};
            }
        }

        public override string ReportTitle(FormGN75B domainObject)
        {
            return domainObject.FormType.Name;
        }

        protected override ReportPrintPreference CreateReportPrintPreference(FormGN75BReport report, UserPrintPreference userPrintPreferences)
        {
            return new ReportPrintPreference(report, 1, true, false, string.Empty, true);
        }

        protected override void AddAssociatedReports(FormGN75BReport mainReport, FormGN75B domainObject)
        {
            XtraReport rosterReport = new EdmontonGN75RosterPrintActions<FormGN75B>().CreateReport(domainObject);
            mainReport.Pages.AddRange(rosterReport.Pages);
        }

        protected override void AddPageSpecificWatermarks(FormGN75BReport report, IEnumerable<FormGN75BReportAdapter> adapters)
        {
            foreach (var adapter in adapters)
            {
                var watermarkText = adapter.WatermarkText;
                if (!watermarkText.IsNullOrEmptyOrWhitespace())
                {
                    var textWatermark = CreateTextWatermark(watermarkText);
                    foreach (Page reportPage in report.Pages)
                    {
                        reportPage.AssignWatermark(textWatermark);
                    }
                }
            }
        }

        public override bool BeforeFirstPrint(List<FormGN75B> objectsToPrint)
        {
            // Some areas just use the print action to preview but not actually print
            if (page == null)
            {
                return true;
            }

            var formsWithLinks = objectsToPrint.FindAll(f => f.DocumentLinks.Count > 0);

            var thereAreFormsWithLinks = formsWithLinks.Count > 0;
            var userReadAtLeastOneDocumentLinkInEachPermit = false;

            if (thereAreFormsWithLinks)
            {
                userReadAtLeastOneDocumentLinkInEachPermit =
                    formService.HasUserReadAtLeastOneDocumentLinkOnEveryFormGN75BInList(ClientSession.GetUserContext().User.IdValue,
                        formsWithLinks.ConvertAll(p => p.IdValue));
            }

            if (thereAreFormsWithLinks && !userReadAtLeastOneDocumentLinkInEachPermit)
            {
                // "There are linked document(s) that you haven't reviewed for one or more GN75 Appendix B that you are attempting to print. Would you like to continue printing?"
                var result = page.ShowOKCancelDialog(StringResources.FormGN75BLinkedDocumentsNotReviewed, StringResources.LinkedDocumentsNotReviewedTitle);
                if (!result)
                {
                    return false;
                }
            }

            return true;
        }
    }
}