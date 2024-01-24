using System.Collections.Generic;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Reports.Printing
{
    public class EdmontonGN1FormPrintActions : EdmontonFormPrintActions<FormGN1, FormGN1Report, FormGN1ReportAdapter>
    {
        private readonly bool printedFromWorkPermit;
        private readonly IFormEdmontonService formService;
        private string meetingTemplateRtf;

        public EdmontonGN1FormPrintActions(bool printedFromWorkPermit, IFormEdmontonService formService)
        {
            this.printedFromWorkPermit = printedFromWorkPermit;
            this.formService = formService;
        }

        protected override FormGN1Report CreateSpecificReport()
        {
            return new FormGN1Report();
        }

        public override void BeforeCreateReportAdapter()
        {
            FormTemplate meetingTemplate = formService.QueryFormTemplateByFormTypeAndKey(EdmontonFormType.GN1, FormTemplateKeys.GN1_INITIAL_ENTRY_MTG);
            meetingTemplateRtf = meetingTemplate != null ? meetingTemplate.Template : RichTextUtilities.ConvertTextToRTF(string.Empty);
        }

        protected override void AddPageSpecificWatermarks(FormGN1Report report, IEnumerable<FormGN1ReportAdapter> adapters)
        {
            if (printedFromWorkPermit)
            {
                AddPageSpecificWatermarksBasedOnDeletedAndStatus(report, adapters);
            }
            else
            {
                base.AddPageSpecificWatermarks(report, adapters);
            }
        }

        protected override List<FormGN1ReportAdapter> CreateReportAdapter(FormGN1 domainObject)
        {
            FormGN1ReportAdapter formReportAdapter = new FormGN1ReportAdapter(domainObject, meetingTemplateRtf);
            return new List<FormGN1ReportAdapter>{formReportAdapter};
        }
    }

    public class EdmontonGN1FormSingleTradeChecklistPrintActions : EdmontonFormPrintActions<FormGN1, FormGN1SingleTradeChecklistReport, FormGN1TradeChecklistReportAdapter>
    {
        private readonly TradeChecklist tradeChecklist;

        public EdmontonGN1FormSingleTradeChecklistPrintActions(TradeChecklist tradeChecklist)
        {
            this.tradeChecklist = tradeChecklist;
        }

        protected override FormGN1SingleTradeChecklistReport CreateSpecificReport()
        {
            return new FormGN1SingleTradeChecklistReport();
        }

        protected override List<FormGN1TradeChecklistReportAdapter> CreateReportAdapter(FormGN1 domainObject)
        {
            FormGN1TradeChecklistReportAdapter formReportAdapter = new FormGN1TradeChecklistReportAdapter(domainObject, tradeChecklist);
            return new List<FormGN1TradeChecklistReportAdapter> { formReportAdapter };
        }
    }

}